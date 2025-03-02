/* 
 * Name of Project: ChiayinYanping_InClass2
 * Purpose: Understaing how to create a simple grade book app using C#
 * Revision History: 
 * - Chiayin Yang & Yanping Guo, June 11th 2024, Create basic design and functions.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiayinYanping_InClass3
{
    public partial class SimpleGradeBook : Form
    {
        // Instance of GradeBook to manage grades
        private GradeBook gradeBook;
        public SimpleGradeBook()
        {
            InitializeComponent();

            // Initialize GradeBook instance
            gradeBook = new GradeBook();

            // Initially hide the statistics group box
            groupBox1.Visible = false;
        }

        private void btnRecordGrade_Click(object sender, EventArgs e)
        {
            try
            {
                string studentName = txtStudentName.Text;
                double numericGrade = double.Parse(txtGrade.Text);

                // Validate numeric grade
                if (numericGrade < 0 || numericGrade > 100)
                {
                    // Highlight invalid grade textbox
                    txtGrade.BackColor = Color.LightPink;
                }
                else
                {
                    // Reset textbox color
                    txtGrade.BackColor = Color.White;
                }

                // Validate student name
                if (string.IsNullOrEmpty(studentName))
                {
                    // Highlight empty student name textbox
                    txtStudentName.BackColor = Color.LightPink;
                }
                else
                {
                    // Reset textbox color
                    txtStudentName.BackColor = Color.White;
                }

                // Create a Grade object
                Grade grade = new Grade(studentName, numericGrade);

                // Add the grade to the GradeBook
                gradeBook.AddGrade(grade);

                // Get updated statistics
                var stats = gradeBook.GetStats();

                // Update the statistics display
                UpdateStatsDisplay(stats);

                // Display a success message
                lblMessage.Text = $"The grade {studentName} ({numericGrade}) was recorded";

            }
            catch (Exception ex)
            {
                // Display error message
                lblError.Text = ex.Message;
            }
        }

        // Method to update the statistics display
        private void UpdateStatsDisplay((int recordCount, double minGrade, double maxGrade, double averageGrade, int failureCount) stats)
        {
            lblNumberOfRecords.Text = stats.recordCount.ToString();
            lblMinimum.Text = stats.minGrade.ToString("F1");
            lblMaximum.Text = stats.maxGrade.ToString("F1");
            lblAverage.Text = stats.averageGrade.ToString("F1");
            lblNumberOfFailures.Text = stats.failureCount.ToString();

            // Make the statistics group box visible
            groupBox1.Visible = true;

            // Clear previous error message
            lblError.Text = "";
        }
    }
}

        