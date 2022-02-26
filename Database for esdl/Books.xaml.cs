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
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class Books : Window
    {
        MySqlConnection conn;
        private string username;
        private string password;
        private string sqlserver;

        public Books()
        {
            InitializeComponent();
            conn.Open();
            updatetable();
            conn.Close();

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
        }

        public Books(string username, string password, string sqlserver)
        {

            InitializeComponent();
            this.username = username;
            this.password = password;
            this.sqlserver = sqlserver;
            conn = new MySqlConnection("datasource=" + sqlserver + ";port=3306;username="+username+";password="+password+";database=clglib");
            conn.Open();
            updatetable();
            conn.Close();

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;

        }

        void updatetable()
        {
            try
            {
                String query1 = "select ISBN_no as 'ISBN number',Name as 'Title',Author,Publication,Price,Stock as 'Total Stock',Available_copies as 'Available Stock'  from Book;";
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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            try
            {
                String a, b, c, d, ee, f;
                a = textBox1.Text;
                b = textBox2.Text;
                c = textBox3.Text;
                d = textBox4.Text;
                ee = textBox5.Text;
                f = textBox6.Text;

                if (a.Length == 0 || b.Length == 0 || c.Length == 0 || d.Length == 0 || ee.Length == 0 || f.Length == 0)
                {
                    MessageBox.Show("Please enter the information");
                    return;
                }

                String query = "insert into Book values('";
                query += b + "','";
                query += c + "','";
                query += d + "',";
                query += ee + ",";
                query += f + ",";
                query += f + ",";
                query += a + ");";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                conn.Close();
                updatetable();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = textBox7.Text, b = textBox8.Text;
                if (a.Length == 0 || b.Length == 0)
                {
                    MessageBox.Show("Please enter Entries");
                    return;
                }
                conn.Open();
                String query = "select * from Book where ISBN_no="+a+";";
                MySqlCommand cmd1 = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    query = "update Book set Available_copies=Available_copies+" + b + " , Stock=Stock+" + b + " where ISBN_no=" + a + ";";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader r = cmd.ExecuteReader();
                    r.Close();
                }
                else
                {
                    MessageBox.Show("Please enter valid ISBN no");
                }
                textBox7.Text = null;
                textBox8.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                updatetable();
                conn.Close();
            }

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = textBox9.Text;
                if (a.Length == 0)
                {
                    MessageBox.Show("Please provide the ISBN no of the book");
                    return;
                }
                conn.Open();
                String query = "select * from Book where ISBN_no=" + a + ";";
                MySqlCommand cmd1 = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    query = "delete from book where ISBN_no=" + a + ";";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader r = cmd.ExecuteReader();
                    r.Close();
                }
                else
                {
                    MessageBox.Show("Please enter valid ISBN no");
                }
                textBox7.Text = null;
                textBox8.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                updatetable();
                conn.Close();
                textBox9.Clear();
            }
        }
    }
}
