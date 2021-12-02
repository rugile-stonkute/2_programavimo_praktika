using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
    /// Interaction logic for RegisteredUserProfile.xaml
    /// </summary>
    public partial class RegisteredUserProfile : Window
    {

        private IUser User;

        public RegisteredUserProfile()
        {
            InitializeComponent();
        }

        public RegisteredUserProfile(IUser user)
        {
            InitializeComponent();
            User = user;
        }

        private void UserChangePasswordButton_Click(object sender, RoutedEventArgs e)
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
            //string query = "update [dbo].[User] set Password = '" + newPassword + "' where Username = '" + User.GetUserName() + "'";
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

        private void UserChangePictureButton_Click(object sender, RoutedEventArgs e)
        {
            //BitmapImage picture;

            //OpenFileDialog op = new OpenFileDialog();
            //op.Title = "Select a picture";
            //op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
            //  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            //  "Portable Network Graphic (*.png)|*.png";
            //if (op.ShowDialog() == true)
            //{
            //    picture = new BitmapImage(new Uri(op.FileName));
            //    UserPictureImageBox.Source = picture;

            //    byte[] data;
            //    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            //    encoder.Frames.Add(BitmapFrame.Create(picture));
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        encoder.Save(ms);
            //        data = ms.ToArray();

            //        UploadImage(data);
            //    }
            //}
        }

        private void UploadImage(byte[] newPicture)
        {
            //SqlConnection conn = new SqlConnection(@"Server=.;Database=3_praktine;Trusted_Connection=True;");
            //conn.Open();
            //string query = "update [dbo].[User] set Picture = '" + newPicture + "' where Username = '" + User.GetUserName() + "'";
            //SqlCommand cmd = new SqlCommand(query, conn);

            //int temp = cmd.ExecuteNonQuery();

            //if (temp == 1)
            //{
            //    MessageBox.Show("Nuotrauka pakeista sėkmingai");
            //}
            //else
            //{
            //    MessageBox.Show("Nuotrauka nepakeista");
            //}

            //conn.Close();
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

        private void UserDeletePictureButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveImage();
        }
    }
}
