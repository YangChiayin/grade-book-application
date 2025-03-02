using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiayinYanping_InClass3
{
    internal class Grade
    {
        // Properties
        public string StudentName { get; set; }
        public double NumericGrade { get; set; }

        // Constructor
        public Grade(string studentName, double numericGrade)
        {
            // Validate input parameters
            if (string.IsNullOrEmpty(studentName))
            {
                throw new ArgumentException("Please enter a student name");
            }
            if (numericGrade < 0 || numericGrade > 100)
            {
                throw new ArgumentException("The numeric grade must be a valid number between 0.0 and 100.0.");
            }

            // Assign values to properties
            StudentName = studentName;
            NumericGrade = numericGrade;
        }
    }
}
