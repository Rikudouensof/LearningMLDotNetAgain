using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningML.Models.MachineLerningModels
{
    public class UserSalaryResponse
    {
        [ColumnName("Score")]
        public float Salary { get; set; }
    }
}
