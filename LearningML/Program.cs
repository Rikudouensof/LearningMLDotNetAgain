using LearningML.MachineLerningContext;
using LearningML.Models.MachineLerningModels;

namespace LearningML
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SalaryContext.Execute(new UserSalaryRequest()
            {
                YearsOfExperience = 4.5F,
            });



            Console.ReadKey();
        }
    }
}
