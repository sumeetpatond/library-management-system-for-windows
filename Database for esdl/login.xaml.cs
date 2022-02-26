using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Database_for_esdl
{
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Password;
            String sqlserver = textBox3.Text;
            
            MySqlConnection conn = new MySqlConnection("datasource=" + sqlserver + ";port=3306;username=" + username + ";password="+password+";database=clglib");
            MainWindow a;
            try
            {
                conn.Open();
                a = new MainWindow(username, password, sqlserver);
                a.Show();
                this.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }     
        }
    }
}
