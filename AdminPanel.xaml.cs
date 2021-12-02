using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
        private List<IUser> Users = new List<IUser>();

        public AdminPanel()
        {
            InitializeComponent();
        }

        public AdminPanel(IUser user)
        {
            InitializeComponent();
            User = user;

            ReadUsers();
        }

        private void AdminPasswordChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserOldPasswordCheckTextBox.Password.Trim() != "" &&
                //UserOldPasswordCheckTextBox.Password.Trim() == User.GetPassword() &&
                UserNewPasswordTextBox.Password.Trim() != "" &&
                UserNewPasswordCheckTextBox.Password.Trim() != "" &&
                UserNewPasswordTextBox.Password.Trim() == UserNewPasswordCheckTextBox.Password.Trim())
            {
                ChangePassword(UserNewPasswordTextBox.Password.Trim());
            }
            else
            {
                MessageBox.Show("no go");
            }
        }

        private void ChangePassword(string newPassword)
        {
            //SqlConnection conn = new SqlConnection(@"Server=.;Database=3_praktine;Trusted_Connection=True;");
            //conn.Open();
            ////string query = "update [dbo].[User] set Password = '" + newPassword + "' where Username = '" + User.GetUserName() + "'";
            //SqlCommand cmd = new SqlCommand(query, conn);

            //int temp = cmd.ExecuteNonQuery();

            //if (temp == 1)
            //{
            //    MessageBox.Show("Slaptažodis pakeistas sėkmingai");
            //}
            //else
            //{
            //    MessageBox.Show("Slaptažodis nepakeistas");
            //}

            //conn.Close();
        }

        private void AdminChangePictureButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage picture;

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                picture = new BitmapImage(new Uri(op.FileName));
                UserPictureImageBox.Source = picture;

                byte[] data;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(picture));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();

                    //UploadImage(data);
                }
            }
        }


        private void RemoveImage()
        {
            //SqlConnection conn = new SqlConnection(@"Server=.;Database=3_praktine;Trusted_Connection=True;");
            //conn.Open();
            //string query = "update [dbo].[User] set Picture = NULL where Username = '" + User.GetUserName() + "'";
            //SqlCommand cmd = new SqlCommand(query, conn);

            //int temp = cmd.ExecuteNonQuery();

            //if (temp == 1)
            //{
            //    UserPictureImageBox.Source = null;
            //    MessageBox.Show("Nuotrauka ištrinta sėkmingai");
            //}
            //else
            //{
            //    MessageBox.Show("Nuotrauka neištrinta");
            //}

            //conn.Close();
        }

        private void AdminDeletePictureButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveImage();
        }
        private void ReadUsers()
        {
            //IUser user = null;
            //Users.Clear();

            //SqlConnection conn = new SqlConnection(@"Server=.;Database=3_praktine;Trusted_Connection=True;");
            //conn.Open();
            //string query = "select * from [dbo].[User] where Username <> '" + User.GetUserName() + "'";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //SqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    if (Convert.ToBoolean(reader[7].ToString()))
            //    {
            //        user = new AdminUser(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(),
            //            Convert.ToDateTime(reader[3].ToString()), reader[4].ToString(), reader[5].ToString(), Encoding.ASCII.GetBytes(reader[6].ToString()));
            //    }
            //    else
            //    {
            //        user = new Student(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(),
            //            Convert.ToDateTime(reader[3].ToString()), reader[4].ToString(), reader[5].ToString(), Encoding.ASCII.GetBytes(reader[6].ToString()));
            //    }

            ////    Users.Add(user);
            //}

            //reader.Close();
            //conn.Close();

            //RegisteredUsersListBox.ItemsSource = Users.Select(user => user.GetUserName()); // radau intike
        }

        private void AdminDeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if(RegisteredUsersListBox.SelectedItem != null)
            {
                SqlConnection conn = new SqlConnection(@"Server=.;Database=3_praktine;Trusted_Connection=True;");
                conn.Open();
                string query = "delete from [dbo].[User] where Username = '" + RegisteredUsersListBox.SelectedItem.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, conn);

                int temp = cmd.ExecuteNonQuery();

                if (temp == 1)
                {
                    MessageBox.Show("Naudotojas ištrintas sėkmingai");
                }
                else
                {
                    MessageBox.Show("Naudotojas neištrintas");
                }

                conn.Close();
            }

            ReadUsers();
        }
    }
}
