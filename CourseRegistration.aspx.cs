using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class CourseRegistration : System.Web.UI.Page
{
    List<Course> courses = Helper.GetCourses();

    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                chklst.Items.Add(courses[i].ToString());
            }

        }
    }
    protected void submit_Click(object sender, System.EventArgs e)
    {
        if (name.Text == "")
        {
            error.Visible = true;
            error.Text = "<strong class='error'>You have not entered a name</strong>";
        }
        else
        {
            try
            {
                // Student Type
                Student student;
                if (studentType.Items[0].Selected == true)
                {
                    student = new FullTimeStudent(name.Text);
                }
                else if (studentType.Items[1].Selected == true)
                {
                    student = new PartTimeStudent(name.Text);
                }
                else
                {
                    student = new CoopStudent(name.Text);
                }

                // Courses
                for (int i = 0; i < courses.Count; i++)
                {
                    if (chklst.Items[i].Selected)
                    {
                        student.addCourse(courses[i]);
                    }
                }
                form1.Visible = false;

                studentName.Text = "<p>Thank you <i class='emphsis'>" + student.Name + "</i>, for using our online registration system.</p>";

                studentStatus.Text = "<p>You have been registered as a <strong class='distinct'>" + student.ToString() + "</strong> for the following courses</p>";

                // Enrolled Courses
                ArrayList enrolledCourses = student.getEnrolledCourses();

                // Table
                table.Controls.Clear();
                TableHeaderRow newHeaderRow = new TableHeaderRow(); // Create table row
                table.Controls.Add(newHeaderRow); // Insert table row in table

                // Course Code
                TableHeaderCell cellHeaderNew = new TableHeaderCell(); // New table cell
                Label lblNew = new Label() { Text = "Course Code" }; // New label object text
                cellHeaderNew.Controls.Add(lblNew); // Put label in cell
                newHeaderRow.Controls.Add(cellHeaderNew); // Put Cell in table row

                // Course Title
                cellHeaderNew = new TableHeaderCell(); // New table cell
                lblNew = new Label() { Text = "Course Title" }; // New label object text
                cellHeaderNew.Controls.Add(lblNew); // Put label in cell
                newHeaderRow.Controls.Add(cellHeaderNew); // Put Cell in table row

                // Course Title
                cellHeaderNew = new TableHeaderCell(); // New table cell
                lblNew = new Label() { Text = "Weekly Hours" }; // New label object text
                cellHeaderNew.Controls.Add(lblNew); // Put label in cell
                newHeaderRow.Controls.Add(cellHeaderNew); // Put Cell in table row

                // Fee Payable
                cellHeaderNew = new TableHeaderCell(); // New table cell
                lblNew = new Label() { Text = "Fee Payable" }; // New label object text
                cellHeaderNew.Controls.Add(lblNew); // Put label in cell
                newHeaderRow.Controls.Add(cellHeaderNew); // Put Cell in table row

                foreach (Course course in enrolledCourses)
                {
                    // Table
                    TableRow newRow = new TableRow(); // Create table row
                    table.Controls.Add(newRow); // Insert table row in table

                    // Course Code
                    TableCell cellNew = new TableCell(); // New table cell
                    lblNew = new Label() { Text = course.Code }; // New label object text
                    cellNew.Controls.Add(lblNew); // Put label in cell
                    newRow.Controls.Add(cellNew); // Put Cell in table row

                    // Course Title
                    cellNew = new TableCell(); // New table cell
                    lblNew = new Label() { Text = course.Title }; // New label object text
                    cellNew.Controls.Add(lblNew); // Put label in cell
                    newRow.Controls.Add(cellNew); // Put Cell in table row

                    // Course Title
                    cellNew = new TableCell(); // New table cell
                    lblNew = new Label() { Text = course.WeeklyHours.ToString() }; // New label object text
                    cellNew.Controls.Add(lblNew); // Put label in cell
                    newRow.Controls.Add(cellNew); // Put Cell in table row

                    // Fee Payable
                    cellNew = new TableCell(); // New table cell
                    lblNew = new Label() { Text = course.Fee.ToString() }; // New label object text
                    cellNew.Controls.Add(lblNew); // Put label in cell
                    newRow.Controls.Add(cellNew); // Put Cell in table row
                }

                // Table
                TableRow lastRow = new TableRow(); // Create table row
                table.Controls.Add(lastRow); // Insert table row in table

                // Blank
                TableCell lastCell = new TableCell(); // New table cell
                lblNew = new Label() { Text = "" }; // New label object text
                lastCell.Controls.Add(lblNew); // Put label in cell
                lastRow.Controls.Add(lastCell); // Put Cell in table row

                // Total
                lastCell = new TableCell(); // New table cell
                lblNew = new Label() { Text = "Total" }; // New label object text
                lastCell.Style.Add("text-align", "right");
                lastCell.Controls.Add(lblNew); // Put label in cell
                lastRow.Controls.Add(lastCell); // Put Cell in table row

                // Weekly Hours
                lastCell = new TableCell(); // New table cell
                lblNew = new Label() { Text = student.totalWeeklyHours().ToString() }; // New label object text
                lastCell.Controls.Add(lblNew); // Put label in cell
                lastRow.Controls.Add(lastCell); // Put Cell in table row

                // Fee Payable
                lastCell = new TableCell(); // New table cell
                lblNew = new Label() { Text = student.feePayable().ToString() }; // New label object text
                lastCell.Controls.Add(lblNew); // Put label in cell
                lastRow.Controls.Add(lastCell); // Put Cell in table row
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
                error.Visible = true;
            }
        }
    }
}