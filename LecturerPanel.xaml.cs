using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        private int editableItemId = 0;

        public LecturerPanel() //konstruktorius
        {
            InitializeComponent();
        }

        public LecturerPanel(IUser user) //konstruktorius
        {
            InitializeComponent();

            User = user;

            UserMetadata.Content = User.Name + " " + User.LastName;

            FillGradeTable();

            FillSubjectDropdownList();
            FillStudentDropdownList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Prisijungimas().Show();
            this.Hide();
        }

        private void SubjectDropdownList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddGradeButton_Click(object sender, RoutedEventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
            //conn.Open();

            //string query = "INSERT INTO dbo.Grades (StudentId, LecturerSubjectId, Grade)";

            //SqlCommand cmd = new SqlCommand(query, conn);
            //SqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    var row = dataTable.NewRow();
            //    row["Id"] = reader[0].ToString();
            //    row["Dalykas"] = reader[1].ToString();
            //    row["Studentas"] = reader[2].ToString() + " " + reader[3].ToString();
            //    row["Pažymys"] = float.Parse(reader[4].ToString());

            //    dataTable.Rows.Add(row);
            //}

            //reader.Close();
            //conn.Close();
        }

        private void FillGradeTable()
        {
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Id" });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Dalykas" });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Studentas" });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Pažymys" });

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
            
            SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
            conn.Open();

            string query = "SELECT[Id], [Name] FROM [Praktika_moodle].[dbo].[Subject]";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            SubjectDropdownList.Items.Add("");
            while (reader.Read())
            {
                SubjectDropdownList.Items.Add(reader[1].ToString());
            }

            reader.Close();
            conn.Close();
        }

        private void FillStudentDropdownList()
        {

            SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
            conn.Open();

            string query = "Exec GetAllStudents";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            StudentDropdownList.Items.Add("");
            while (reader.Read())
            {
                StudentDropdownList.Items.Add(reader[1].ToString() + " " + reader[2].ToString());
            }

            reader.Close();
            conn.Close();
        }

        private void Grades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Grades.SelectedIndex != -1)
            {
                SubjectDropdownList.SelectedItem = dataTable.Rows[Grades.SelectedIndex][1];
                StudentDropdownList.SelectedItem = dataTable.Rows[Grades.SelectedIndex][2];
                GradeTextBox.Text = dataTable.Rows[Grades.SelectedIndex][3].ToString();
            }
            else
            {
                SubjectDropdownList.SelectedItem = "";
                StudentDropdownList.SelectedItem = "";
                GradeTextBox.Text = "";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Grades.SelectedIndex = -1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
