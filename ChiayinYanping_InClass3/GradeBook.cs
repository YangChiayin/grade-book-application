using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiayinYanping_InClass3
{
    internal class GradeBook
    {
        // Private field to store grades
        private List<Grade> grades;

        public GradeBook()
        {
            // Initialize the list of grades
            grades = new List<Grade>();
        }

        // Method to add a grade to the grade book
        public void AddGrade(Grade grade)
        {
            // Add the grade to the list
            grades.Add(grade);
        }

        // Method to get statistics about the grades
        public (int recordCount, double minGrade, double maxGrade, double averageGrade, int failureCount) GetStats()
        {
            int recordCount = grades.Count;
            double minGrade = grades.Min(g => g.NumericGrade);
            double maxGrade = grades.Max(g => g.NumericGrade);
            double averageGrade = grades.Average(g => g.NumericGrade);
            int failureCount = grades.Count(g => g.NumericGrade < 55);


            // Return a structure containing all statistics
            return (recordCount, minGrade, maxGrade, averageGrade, failureCount);
        }
    }
}
