using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private IUser User;
        private DataTable userDataTable = new DataTable();
        private DataTable subjectDataTable = new DataTable();
        private List<Map> groupList = new List<Map>();
        private List<Map> lecturerList = new List<Map>();

        public AdminPanel()
        {
            InitializeComponent();
        }

        public AdminPanel(IUser user)
        {
            InitializeComponent();

            User = user;

            UserMetadata.Content = User.Name + " " + User.LastName;

            userDataTable.Columns.Add(new DataColumn() { ColumnName = "Id" });
            userDataTable.Columns.Add(new DataColumn() { ColumnName = "Vardas" });
            userDataTable.Columns.Add(new DataColumn() { ColumnName = "Pavardė" });
            userDataTable.Columns.Add(new DataColumn() { ColumnName = "Ar Dėstytojas" });
            userDataTable.Columns.Add(new DataColumn() { ColumnName = "Grupė" });

            FillUserTable();

            subjectDataTable.Columns.Add(new DataColumn() { ColumnName = "Id" });
            subjectDataTable.Columns.Add(new DataColumn() { ColumnName = "Dėstytojas" });
            subjectDataTable.Columns.Add(new DataColumn() { ColumnName = "Dalykas" });
            subjectDataTable.Columns.Add(new DataColumn() { ColumnName = "Grupė" });

            FillSubjectTable();

            FillGroupDropdownList();
            FillLecturerDropdownList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Prisijungimas().Show();
            this.Hide();
        }

        private void FillUserTable()
        {
            userDataTable.Rows.Clear();
            SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
            conn.Open();

            string query = "exec GetAllUsers";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var row = userDataTable.NewRow();
                row["Id"] = reader[0].ToString();
                row["Vardas"] = reader[1].ToString();
                row["Pavardė"] = reader[2].ToString();
                row["Ar Dėstytojas"] = reader[3].ToString() == "1" ? "Taip" : "Ne";
                row["Grupė"] = reader[4].ToString();

                userDataTable.Rows.Add(row);
            }

            reader.Close();
            conn.Close();

            Users.ItemsSource = userDataTable.DefaultView;
        }

        private void FillSubjectTable()
        {
            subjectDataTable.Rows.Clear();
            SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
            conn.Open();

            string query = "exec GetAllSubjects";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var row = subjectDataTable.NewRow();
                row["Id"] = reader[0].ToString();
                row["Dėstytojas"] = reader[1].ToString() + " " + reader[2].ToString();
                row["Dalykas"] = reader[3].ToString();
                row["Grupė"] = reader[4].ToString();

                subjectDataTable.Rows.Add(row);
            }

            reader.Close();
            conn.Close();

            Subjects.ItemsSource = subjectDataTable.DefaultView;
        }

        private void FillGroupDropdownList()
        {
            groupList.Clear();
            GroupDropdownList.Items.Clear();

            SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
            conn.Open();

            string query = "select * from [dbo].[Group]";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            GroupDropdownList.Items.Add("");
            while (reader.Read())
            {
                groupList.Add(
                    new Map()
                    {
                        Id = Convert.ToInt32(reader[0].ToString()),
                        Name = reader[1].ToString()
                    });

                GroupDropdownList.Items.Add(reader[1].ToString());
            }

            reader.Close();
            conn.Close();
        }

        private void FillLecturerDropdownList()
        {
            lecturerList.Clear();
            LecturerDropdownList.Items.Clear();

            SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
            conn.Open();

            string query = "exec GetAllLecturers";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            LecturerDropdownList.Items.Add("");
            while (reader.Read())
            {
                lecturerList.Add(
                    new Map()
                    {
                        Id = Convert.ToInt32(reader[0].ToString()),
                        Name = reader[1].ToString() + " " + reader[2].ToString()
                    });

                LecturerDropdownList.Items.Add(reader[1].ToString() + " " + reader[2].ToString());
            }

            reader.Close();
            conn.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(!IsLecturerCheckBox.IsChecked.HasValue || !IsLecturerCheckBox.IsChecked.Value)
            {
                GroupTextBox.IsEnabled = true;
            }
            else
            {
                GroupTextBox.Text = "";
                GroupTextBox.IsEnabled = false;
            }
        }

        private void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Users.SelectedIndex != -1)
            {
                RemoveUserButton.IsEnabled = true;

                UsernameTextBox.Text = userDataTable.Rows[Users.SelectedIndex][1].ToString();
                LastnameTextBox.Text = userDataTable.Rows[Users.SelectedIndex][2].ToString();
                IsLecturerCheckBox.IsChecked = userDataTable.Rows[Users.SelectedIndex][3].ToString() == "Taip";

                if (!IsLecturerCheckBox.IsChecked.HasValue || !IsLecturerCheckBox.IsChecked.Value)
                {
                    GroupTextBox.IsEnabled = true;
                }
                else
                {
                    GroupTextBox.Text = "";
                    GroupTextBox.IsEnabled = false;
                }

                GroupTextBox.Text = userDataTable.Rows[Users.SelectedIndex][4].ToString();
            }
            else
            {
                RemoveUserButton.IsEnabled = false;
            }
        }

        private void Subjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Subjects.SelectedIndex != -1)
            {
                RemoveSubjectButton.IsEnabled = true;

                LecturerDropdownList.SelectedItem = subjectDataTable.Rows[Subjects.SelectedIndex][1];
                SubjectTextBox.Text = subjectDataTable.Rows[Subjects.SelectedIndex][2].ToString();
                GroupDropdownList.SelectedItem = subjectDataTable.Rows[Subjects.SelectedIndex][3];
            }
            else
            {
                RemoveSubjectButton.IsEnabled = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Users.SelectedIndex = -1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text.ToString().Trim() != "" &&
                LastnameTextBox.Text.ToString().Trim() != "" &&
                ((!IsLecturerCheckBox.IsChecked.HasValue || !IsLecturerCheckBox.IsChecked.Value) ?
                    GroupTextBox.Text.ToString().Trim() != "" : GroupTextBox.Text.ToString().Trim() == ""))
            {
                SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
                conn.Open();
                string query = "";

                if (!IsLecturerCheckBox.IsChecked.HasValue || !IsLecturerCheckBox.IsChecked.Value)
                {
                    if (Users.SelectedIndex != -1 && userDataTable.Rows[Users.SelectedIndex][3].ToString() == "Ne")
                    {
                        query = "EXEC UpdateStudent @UserId='" + userDataTable.Rows[Users.SelectedIndex][0].ToString() +
                            "', @Name='" + UsernameTextBox.Text.ToString().Trim() +
                            "', @Lastname='" + LastnameTextBox.Text.ToString().Trim() +
                            "', @Group='" + GroupTextBox.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        query = "EXEC InsertNewStudent @Name='" + UsernameTextBox.Text.ToString().Trim() +
                            "', @Lastname='" + LastnameTextBox.Text.ToString().Trim() +
                            "', @Group='" + GroupTextBox.Text.ToString().Trim() + "'";
                    }
                }
                else
                {
                    if (Users.SelectedIndex != -1 && userDataTable.Rows[Users.SelectedIndex][3].ToString() == "Taip")
                    {
                        query = "EXEC UpdateLecturer @UserId='" + userDataTable.Rows[Users.SelectedIndex][0].ToString() +
                            "', @Name='" + UsernameTextBox.Text.ToString().Trim() +
                            "', @Lastname='" + LastnameTextBox.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        query = "EXEC InsertNewLecturer @Name='" + UsernameTextBox.Text.ToString().Trim() +
                            "', @Lastname='" + LastnameTextBox.Text.ToString().Trim() + "'";
                    }
                }

                

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                FillUserTable();
                FillGroupDropdownList();
                FillLecturerDropdownList();

                conn.Close();
            }
            else
            {
                if (UsernameTextBox.Text.ToString().Trim() != "")
                {
                    if (LastnameTextBox.Text.ToString().Trim() != "")
                    {
                        if (!IsLecturerCheckBox.IsChecked.HasValue || !IsLecturerCheckBox.IsChecked.Value)
                        {
                            MessageBox.Show("Įveskite studento grupę");
                        }
                        else
                        {
                            MessageBox.Show("Negalima dėstytojui priskirti grupės, kažkas čia blogai");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Įveskite naudotojo pavardę");
                    }
                }
                else
                {
                    MessageBox.Show("Įveskite naudotojo vardą");
                }
            }
        }

        private void RemoveUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsLecturerCheckBox.IsChecked.HasValue || !IsLecturerCheckBox.IsChecked.Value)
            {
                SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
                conn.Open();

                string query = "DELETE FROM [Praktika_moodle].[dbo].[User] WHERE Id = " + userDataTable.Rows[Users.SelectedIndex][0];

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                FillUserTable();

                conn.Close();
            }
            else
            {
                SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
                conn.Open();

                string query = "DELETE FROM [Praktika_moodle].[dbo].[User] WHERE Id = " + userDataTable.Rows[Users.SelectedIndex][0];

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                FillUserTable();
                FillSubjectTable();
                FillLecturerDropdownList();

                conn.Close();
            }
        }

        private void RemoveSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
            conn.Open();

            string query = "DELETE FROM [Praktika_moodle].[dbo].[Lecturer_subject] WHERE Id = " + subjectDataTable.Rows[Subjects.SelectedIndex][0];

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            FillSubjectTable();

            conn.Close();
        }

        private void SaveButton_Click_2(object sender, RoutedEventArgs e)
        {
            if (GroupDropdownList.SelectedItem.ToString() != "" &&
                LecturerDropdownList.SelectedItem.ToString() != "" &&
                SubjectTextBox.Text.ToString().Trim() != "")
            {
                SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
                conn.Open();
                string query = "";

                if (Subjects.SelectedIndex != -1)
                {
                    query = "EXEC UpdateLecturerSubject @Id=" + subjectDataTable.Rows[Subjects.SelectedIndex][0] +
                        ", @LecturerId=" + lecturerList.First(s => s.Name == LecturerDropdownList.SelectedItem.ToString()).Id +
                        ", @GroupId=" + groupList.First(s => s.Name == GroupDropdownList.SelectedItem.ToString()).Id +
                        ", @Subject='" + SubjectTextBox.Text.ToString().Trim() + "'";
                }
                else
                {
                    query = "EXEC InsertNewLecturerSubject @LecturerId=" + lecturerList.First(s => s.Name == LecturerDropdownList.SelectedItem.ToString()).Id +
                        ", @GroupId=" + groupList.First(s => s.Name == GroupDropdownList.SelectedItem.ToString()).Id +
                        ", @Subject='" + SubjectTextBox.Text.ToString().Trim() + "'";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                FillSubjectTable();

                conn.Close();
            }
            else
            {
                if (GroupDropdownList.SelectedItem.ToString() != "")
                {
                    if (LecturerDropdownList.SelectedItem.ToString() != "")
                    {
                        MessageBox.Show("Įveskite dalyko pavadinimą");
                    }
                    else
                    {
                        MessageBox.Show("Pasirinkite dėstytoją");
                    }
                }
                else
                {
                    MessageBox.Show("Pasirinkite grupę");
                }
            }
        }

        private void UnselectButton_Click_1(object sender, RoutedEventArgs e)
        {
            Subjects.SelectedIndex = -1;
        }
    }
}
