using LearningML.Models.MachineLerningModels;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningML.MachineLerningContext
{
    public class SalaryContext
    {


        public static void Execute(UserSalaryRequest request)
        {
            MLContext context = new MLContext();
            List<UserSalaryModel> data = new List<UserSalaryModel>();
            Random random = new Random();

            //Bad for float years of expeee
            for (int i = 0; i < 200; i++)
            {
                float yearsOfExperience = (float)Math.Round(random.NextDouble() * 40, 1); // Random years of experience between 0 and 40
                float salary = (float)Math.Round(30000 + (yearsOfExperience * 2000), 2); // Base salary of 30000 with an increment of 2000 per year of experience
                data.Add(new UserSalaryModel { YearsOfExperience = yearsOfExperience, Salary = salary });
            }


            IDataView trainingData = context.Data.LoadFromEnumerable(data);
            var estimator = context.Transforms.Concatenate("Features", new[] { "YearsOfExperience" });
            var pipeline = estimator.Append(context.Regression.Trainers.Sdca(labelColumnName: "Salary", maximumNumberOfIterations: 100));
            var model = pipeline.Fit(trainingData);
            var predictionEngine = context.Model.CreatePredictionEngine<UserSalaryModel, UserSalaryResponse>(model);


            var result = predictionEngine.Predict(new UserSalaryModel()
            {
                YearsOfExperience = request.YearsOfExperience,
            });


            Console.WriteLine($"For {request.YearsOfExperience} years of experience,your salary is {result.Salary}");
        }



    }
}
