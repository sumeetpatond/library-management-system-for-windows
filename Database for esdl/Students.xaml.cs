using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    /// <summary>
    /// Interaction logic for applicants.xaml
    /// </summary>
    
    public partial class Students : Window
    {
        MySqlConnection conn;
        private string username;
        private string password;
        private string sqlserver;

        public Students()
        {
            InitializeComponent();

            textBox1.Text = null;
            textBox2.Text = null;
            textBox4.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;

            updatetable();
            List<String> data = new List<string>();
            data.Add("First Year");
            data.Add("Second Year");
            data.Add("Third Year");
            data.Add("Final Year");
            comboBox1.ItemsSource=data;

            List<String> data1 = new List<string>();
            data1.Add("Computer");
            data1.Add("I.T.");
            data1.Add("E&TC");
            data1.Add("Mechanical");
            data1.Add("Printing");
            data1.Add("Civil");
            comboBox2.ItemsSource = data1;

        }

        public Students(string username, string password, string sqlserver)
        {
            this.username = username;
            this.password = password;
            this.sqlserver = sqlserver;

            conn = new MySqlConnection("datasource=" + sqlserver + ";port=3306;username=" + username + ";password=" + password + ";database=clglib");

            InitializeComponent();

            textBox1.Text = null;
            textBox2.Text = null;
            textBox4.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;

            updatetable();
            List<String> data = new List<string>();
            data.Add("First Year");
            data.Add("Second Year");
            data.Add("Third Year");
            data.Add("Final Year");
            comboBox1.ItemsSource = data;

            List<String> data1 = new List<string>();
            data1.Add("Computer");
            data1.Add("I.T.");
            data1.Add("E&TC");
            data1.Add("Mechanical");
            data1.Add("Printing");
            data1.Add("Civil");
            comboBox2.ItemsSource = data1;
        }

        void updatetable()
        {
            try
            {
                conn.Open();
                String query1 = "select User_ID as 'User ID',Name,Address,Class,Branch,Mob_no as 'Mobile Number',book as 'Issued Book' from Student;";
                MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                using (MySqlDataAdapter ad = new MySqlDataAdapter(cmd1))
                {
                    System.Data.DataTable dt = new DataTable();
                   
                    ad.Fill(dt);
                    grid1.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                String a, b, c, d, ee, f;
                a = textBox1.Text;
                b = textBox2.Text;
                c = textBox4.Text;
                d = comboBox1.Text;
                ee = comboBox2.Text;
                f = textBox6.Text;
                
                if (a.Length == 0 || b.Length == 0 || c.Length == 0 || d.Length == 0 || ee.Length == 0 || f.Length == 0)
                {
                    MessageBox.Show("Please enter the information");
                    return;
                }
                                
                String query = "insert into Student values('";
                query += b + "','";
                query += c + "','";
                query += d + "','";
                query += ee + "',0,";
                query += a + ",";
                query += f + ");";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                updatetable();

                textBox1.Text = null;
                textBox2.Text = null;
                textBox4.Text = null;
                textBox6.Text = null;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = textBox7.Text;
                if (a.Length==0)
                {
                    MessageBox.Show("Please enter User ID");
                    return;
                }
                conn.Open();

                String query = "select * from Student where User_ID=" + a + ";";
                MySqlCommand cmd1 = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd1.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Please enter valid User ID");
                    return;                    
                }

                reader.Close();
                query = "delete from Student where User_ID='" + textBox7.Text + "';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader r = cmd.ExecuteReader();
                r.Close();
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                updatetable();
                textBox7.Clear();
            }

        }
    }
}
