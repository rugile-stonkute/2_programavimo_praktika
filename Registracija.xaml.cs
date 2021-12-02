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
    /// Interaction logic for Registracija.xaml
    /// </summary>
    public partial class Registracija : Window
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Patikrinti ar tokis username dar neegzistuoja
            //Jei neegzistuoja sukurti, jei egzistuoja ismesti pranesima

            //Naudotojas turi buti >= 14 metu 

            if (NameTextBox.Text.Trim() != "" &&
                LastNameTextBox.Text.Trim() != "" &&
                Birthday_datePicker.SelectedDate.HasValue &&
                ((DateTime.Today - Birthday_datePicker.SelectedDate.Value).TotalDays / 365) >= 14 &&
                UsernameTextBox.Text.Trim() != "" &&
                PasswordTextBox.Password.Trim() != "")
            {
                //var user = new Student(0, NameTextBox.Text, LastNameTextBox.Text, Birthday_datePicker.SelectedDate.Value, UsernameTextBox.Text, PasswordTextBox.Password, null);
                //InsertNewUser(user);
            }
            else
            {
                MessageBox.Show("Grįžk, kai tau bus 14 ir suvesi į visus laukus informaciją ;)");
            }
        }

        private static void InsertNewUser(IUser user)
        {
        //    SqlConnection conn = new SqlConnection(@"Server=.;Database=3_praktine;Trusted_Connection=True;");
        //    conn.Open();
        //    string query = "select count(*) from [dbo].[User] where Username = '" + user.GetUserName() + "'";
        //    SqlCommand cmd = new SqlCommand(query, conn);
        //    int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

        //    if (temp == 1)
        //    {
        //        MessageBox.Show("Toks naudotojas jau egzistuoja");
        //    }
        //    else
        //    {
        //        query = "insert into [dbo].[User] ([Name], [LastName], [Birthday], [Username], [Password], [IsAdmin]) VALUES('" +
        //            user.GetName() + "', '" + user.GetLastName() + "', '" + user.GetBirthday() + "', '" + user.GetUserName() + "', '" + user.GetPassword() + "', '" + user.IsAdmin() + "')";

        //        cmd = new SqlCommand(query, conn);
        //        temp = cmd.ExecuteNonQuery();

        //        if (temp == 1)
        //        {
        //            MessageBox.Show("Registracija sėkminga");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Registracija nesėkminga");
        //        }
        //    }

        //    conn.Close();
        }
    }
}
