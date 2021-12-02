using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
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
    /// Interaction logic for StudentPanel.xaml
    /// </summary>
    public partial class StudentPanel : Window
    {
        private IUser User;

        public StudentPanel()
        {
            InitializeComponent();
        }

        public StudentPanel(IUser user)
        {
            InitializeComponent();
            User = user;

            UserMetadata.Content = User.Name + " " + User.LastName + " " + User.Group.Name;
            FillGradeTable();
        }

        private void FillGradeTable()
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add(new DataColumn() { ColumnName = "Dalykas" });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Dėstytojas" });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Pažymys" });

            SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
            conn.Open();

            string query = "exec GetAllStudentGrades @StudentId = " + User.Id + ", @GroupId = " + User.Group.Id;

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var row = dataTable.NewRow();
                row["Dalykas"] = reader[0].ToString();
                row["Dėstytojas"] = reader[1].ToString() + " " + reader[2].ToString();
                row["Pažymys"] = float.Parse(reader[3].ToString());

                dataTable.Rows.Add(row);
            }

            reader.Close();
            conn.Close();

            Grades.ItemsSource = dataTable.DefaultView;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Prisijungimas().Show();
            this.Hide();
        }

        private void Grades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
