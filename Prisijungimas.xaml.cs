using System;
using System.Collections.Generic;
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
    /// Interaction logic for Prisijungimas.xaml
    /// </summary>
    public partial class Prisijungimas : Window
    {
        public Prisijungimas()
        {
            InitializeComponent();
        }

        private void PrisijungtiGOButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameRegistrationTextBox.Text.Trim() != "" &&
                PasswordRegistrationTextBox.Password.Trim() != "")
            {
                Login(UsernameRegistrationTextBox.Text.Trim(), PasswordRegistrationTextBox.Password.Trim());
            }
            else
            {
                MessageBox.Show("no go");
            }
        }

        private void Login(string username, string password)
        {
            IUser user = null;
            int userId = 0;
            string name = "";
            string lastname = "";
            string userUsername = "";
            string userPassword = "";
            bool isUserValid = true;
            bool isAdmin = false;
            bool isLecturer = false;

            SqlConnection conn = new SqlConnection(@"Server=.;Database=Praktika_moodle;Trusted_Connection=True;");
            conn.Open();
            string query = "select top 1 * from [dbo].[User] where Username = '" + username + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader[4].ToString() == password)
                {
                    userId = Convert.ToInt32(reader[0].ToString());
                    name = reader[1].ToString();
                    lastname = reader[2].ToString();
                    userUsername = reader[3].ToString();
                    userPassword = reader[4].ToString();
                }
                else
                {
                    isUserValid = false;
                }
            }

            reader.Close();

            if (isUserValid)
            {
                bool isInAnyRole = true;

                query = "select Id from [dbo].[Admin] where UserId = " + userId.ToString();
                cmd = new SqlCommand(query, conn);
                int adminId = Convert.ToInt32((cmd.ExecuteScalar() ?? 0).ToString());

                if (adminId != 0)
                {
                    isAdmin = true;
                }

                query = "select Id from [dbo].[Lecturer] where UserId = " + userId.ToString();
                cmd = new SqlCommand(query, conn);
                int lecturerId = Convert.ToInt32((cmd.ExecuteScalar() ?? 0).ToString());

                if (lecturerId != 0)
                {
                    isLecturer = true;
                }

                if (isAdmin && isLecturer)
                {
                    if (MessageBox.Show("Ar norite prisijungti kaip administratorius?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        //open lecturer panel
                        user = new Lecturer()
                        {
                            Id = lecturerId,
                            UserId = userId,
                            Name = name,
                            LastName = lastname,
                            Username = userUsername,
                            Password = userPassword
                        };
                        new LecturerPanel(user).Show();
                    }
                    else
                    {
                        //open admin panel
                        user = new AdminUser()
                        {
                            Id = adminId,
                            UserId = userId,
                            Name = name,
                            LastName = lastname,
                            Username = userUsername,
                            Password = userPassword
                        };
                        new AdminPanel(user).Show();
                    }
                }
                else if (isAdmin)
                {
                    //open admin panel
                    user = new AdminUser()
                    {
                        Id = adminId,
                        UserId = userId,
                        Name = name,
                        LastName = lastname,
                        Username = userUsername,
                        Password = userPassword
                    };
                    new AdminPanel(user).Show();
                }
                else if (isLecturer)
                {
                    //open lecturer panel
                    user = new Lecturer()
                    {
                        Id = lecturerId,
                        UserId = userId,
                        Name = name,
                        LastName = lastname,
                        Username = userUsername,
                        Password = userPassword
                    };
                    new LecturerPanel(user).Show();
                }
                else
                {
                    query = "select Id, GroupId from [dbo].[Student] where UserId = " + userId.ToString();
                    cmd = new SqlCommand(query, conn);
                    reader = cmd.ExecuteReader();

                    int studentId = 0;
                    int groupId = 0;
                    string groupName = "";

                    while (reader.Read())
                    {
                        studentId = Convert.ToInt32(reader[0].ToString());
                        groupId = Convert.ToInt32(reader[1].ToString());
                    }

                    reader.Close();

                    if (studentId != 0)
                    {
                        query = "select Name from [dbo].[Group] where Id = " + groupId.ToString();
                        cmd = new SqlCommand(query, conn);
                        reader = cmd.ExecuteReader();

                        bool isGroupFound = false;

                        while (reader.Read())
                        {
                            groupName = reader[0].ToString();
                            isGroupFound = true;
                        }

                        reader.Close();

                        if (isGroupFound)
                        {
                            Group group = new Group()
                            {
                                Id = groupId,
                                Name = groupName
                            };

                            user = new Student()
                            {
                                Id = studentId,
                                UserId = userId,
                                Name = name,
                                LastName = lastname,
                                Username = userUsername,
                                Password = userPassword,
                                Group = group
                            };
                            //open student panel
                            new StudentPanel(user).Show();
                        }
                        else
                        {
                            MessageBox.Show("Kazkas LABAI blogai");
                            isInAnyRole = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nera tokio studento");
                        isInAnyRole = false;
                    }
                }

                if (isInAnyRole)
                {
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("OoPSY nope");
            }
            conn.Close();
        }
    }
}
