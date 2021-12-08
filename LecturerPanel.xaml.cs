using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _3_praktine
{
    /// <summary>
    /// Interaction logic for LecturerPanel.xaml
    /// </summary>
    public partial class LecturerPanel : Window
    {
        private IUser User;
        private DataTable dataTable = new DataTable();
        private List<Map> subjectList = new List<Map>();
        private List<Map> studentList = new List<Map>();

        public LecturerPanel() //konstruktorius
        {
            InitializeComponent();
        }

        public LecturerPanel(IUser user) //konstruktorius
        {
            InitializeComponent();

            User = user;

            UserMetadata.Content = User.Name + " " + User.LastName;

            dataTable.Columns.Add(new DataColumn() { ColumnName = "Id" });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Dalykas" });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Studentas" });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Pažymys" });

            FillGradeTable();

            FillSubjectDropdownList();
            FillStudentDropdownList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Prisijungimas().Show();
            this.Hide();
        }

        private void RemoveGradeButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
            conn.Open();

            string query = "DELETE FROM [Praktika_moodle].[dbo].[Grade] WHERE Id = " + dataTable.Rows[Grades.SelectedIndex][0];

            SqlCommand cmd = new SqlCommand(query, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                FillGradeTable();
            }

            conn.Close();
        }

        private void FillGradeTable()
        {
            dataTable.Rows.Clear();
            SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
            conn.Open();

            string query = "exec GetAllLecturerGrades @LecturerId = " + User.Id;

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var row = dataTable.NewRow();
                row["Id"] = reader[0].ToString();
                row["Dalykas"] = reader[1].ToString();
                row["Studentas"] = reader[2].ToString() + " " + reader[3].ToString();
                row["Pažymys"] = float.Parse(reader[4].ToString());

                dataTable.Rows.Add(row);
            }

            reader.Close();
            conn.Close();

            Grades.ItemsSource = dataTable.DefaultView;
        }

        private void FillSubjectDropdownList()
        {
            subjectList.Clear();
            SubjectDropdownList.Items.Clear();

            SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
            conn.Open();

            string query = "EXEC GetLecturersSubjects @LecturerId = " + User.Id;

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            SubjectDropdownList.Items.Add("");
            while (reader.Read())
            {
                subjectList.Add(
                    new Map()
                    {
                        Id = Convert.ToInt32(reader[0].ToString()),
                        Name = reader[1].ToString()
                    });

                SubjectDropdownList.Items.Add(reader[1].ToString());
            }

            reader.Close();
            conn.Close();
        }

        private void FillStudentDropdownList()
        {
            studentList.Clear();
            StudentDropdownList.Items.Clear();

            SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
            conn.Open();

            string query = "Exec GetAllStudents";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            StudentDropdownList.Items.Add("");
            while (reader.Read())
            {
                studentList.Add(
                    new Map()
                    {
                        Id = Convert.ToInt32(reader[0].ToString()),
                        Name = reader[1].ToString() + " " + reader[2].ToString()
                    });

                StudentDropdownList.Items.Add(reader[1].ToString() + " " + reader[2].ToString());
            }

            reader.Close();
            conn.Close();
        }

        private void Grades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Grades.SelectedIndex != -1)
            {
                RemoveGradeButton.IsEnabled = true;

                SubjectDropdownList.SelectedItem = dataTable.Rows[Grades.SelectedIndex][1];
                StudentDropdownList.SelectedItem = dataTable.Rows[Grades.SelectedIndex][2];
                GradeTextBox.Text = dataTable.Rows[Grades.SelectedIndex][3].ToString();
            }
            else
            {
                RemoveGradeButton.IsEnabled = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Grades.SelectedIndex = -1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (StudentDropdownList.SelectedItem.ToString() != "" &&
                SubjectDropdownList.SelectedItem.ToString() != "" &&
                int.TryParse(GradeTextBox.Text, out int grade))
            {
                SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
                conn.Open();
                string query = "";

                if (Grades.SelectedIndex != -1)
                {
                    query = "UPDATE [Praktika_moodle].[dbo].[Grade] SET StudentId = " + studentList.First(s => s.Name == StudentDropdownList.SelectedItem.ToString()).Id +
                        ", LecturerSubjectId =" + subjectList.First(s => s.Name == SubjectDropdownList.SelectedItem.ToString()).Id +
                        ", Grade = " + grade + " WHERE Id = " + dataTable.Rows[Grades.SelectedIndex][0];
                }
                else
                {
                    query = "INSERT INTO [Praktika_moodle].[dbo].[Grade] (StudentId, LecturerSubjectId, Grade) VALUES (" +
                        studentList.First(s => s.Name == StudentDropdownList.SelectedItem.ToString()).Id + ", " +
                        subjectList.First(s => s.Name == SubjectDropdownList.SelectedItem.ToString()).Id + ", " +
                        grade + ")";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    FillGradeTable();
                }

                conn.Close();
            }
            else
            {
                if (SubjectDropdownList.SelectedItem.ToString() != "")
                {
                    if (StudentDropdownList.SelectedItem.ToString() != "")
                    {
                        MessageBox.Show("Įveskite pažymį nuo 1 iki 10");
                    }
                    else
                    {
                        MessageBox.Show("Pasirinkite studentą");
                    }
                }
                else
                {
                    MessageBox.Show("Pasirinkite dėstomą dalyką");
                }
            }
        }
    }
}
