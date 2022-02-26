using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security;

namespace Database_for_esdl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string username;
        public String password;
        public string sqlserver;
        MySqlConnection conn;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string username, String password, string sqlserver)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.sqlserver = sqlserver;
            conn = new MySqlConnection("datasource=" + sqlserver + ";port=3306;username=" + username + ";password=" + password + ";database=clglib");
            textBox1.Clear();
            textBox2.Clear();
            updatetable();
        }

        void updatetable()
        {
            try
            {
                conn.Open();
                String query1 = "select Student.User_ID as 'User ID',Student.Name as 'Student Name',Book.ISBN_no as 'ISBN Number',Book.Name as 'Name of Book',Date_of_recieve as 'Date of recieve' from Student,Book,transaction where Student.User_ID=transaction.User_ID and Book.ISBN_no=transaction.ISBN_no;";
                MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                using (MySqlDataAdapter ad = new MySqlDataAdapter(cmd1))
                {
                    System.Data.DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                                        
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
            Students stu = new Students(username,password,sqlserver);
            stu.ShowDialog();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Books b = new Books(username, password, sqlserver);
            b.ShowDialog();
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            String a1 = textBox1.Text;
            String a2 = textBox2.Text;
            if (a1.Length == 0 || a2.Length == 0)
            {
                MessageBox.Show("Please enter the information");
                return;
            }

            try
            {
                conn.Open();
                string query = "select * from Student where User_ID=" + textBox1.Text + ";";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if(!reader.Read())
                {
                    MessageBox.Show("Invalid UserID!");
                    return;
                }
                reader.Close();

                query = "select * from Book where ISBN_no=" + textBox2.Text + ";";
                MySqlCommand cmd1 = new MySqlCommand(query, conn);
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                if (!reader1.Read())
                {
                    MessageBox.Show("Invalid ISBN number!");
                    return;
                }
                reader1.Close();

                query = "select * from transaction where ISBN_no=" + textBox2.Text + " and User_ID=" + textBox1.Text + ";";
                MySqlCommand cmd2 = new MySqlCommand(query, conn);
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    MessageBox.Show("This user has already issued same book");
                    return;
                }
                reader2.Close();

               
               
                query = "select book from Student where User_ID=" + a1 + ";";
                MySqlCommand cmd3 = new MySqlCommand(query, conn);
                MySqlDataReader reader3 = cmd3.ExecuteReader();
                int book = 0;
                if(reader3.Read())
                    book = Int32.Parse(reader3.GetString(0));
                if(book > 2)
                {
                    MessageBox.Show("This user already issued 3 books");
                    return;
                }
                reader3.Close();
               
                query = "select Available_copies from Book where ISBN_no=" + textBox2.Text + ";";
                MySqlCommand cmd4 = new MySqlCommand(query, conn);
                MySqlDataReader reader4 = cmd4.ExecuteReader();
                int copies=0;
                if(reader4.Read())
                    copies= reader4.GetInt32(0);
                reader4.Close();

                if(copies < 0)
                {
                    MessageBox.Show("Requested book is currently unavailable");
                }

                query = "insert into transaction values('" + textBox1.Text + "','" + textBox2.Text + "','" + DateTime.Now + "');";
                MySqlCommand cmd5 = new MySqlCommand(query, conn);
                MySqlDataReader reader5 = cmd5.ExecuteReader();
                reader5.Close();

                book++;
                query = "update Student set book=" + book + " where User_ID='" + textBox1.Text + "';";
                MySqlCommand cmd6 = new MySqlCommand(query, conn);
                MySqlDataReader reader6 = cmd6.ExecuteReader();
                reader6.Close();

                copies--;
                query = "update Book set Available_copies=" + copies + " where ISBN_no='" + textBox2.Text + "';";
                MySqlCommand cmd7 = new MySqlCommand(query, conn);
                MySqlDataReader reader7 = cmd7.ExecuteReader();
                reader7.Close();
   
                MessageBox.Show("Book issued Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                textBox1.Clear();
                textBox2.Clear();
                updatetable();
            }
        }
                       

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            String a1 = textBox1.Text;
            String a2 = textBox2.Text;
            if (a1.Length == 0 || a2.Length == 0)
            {
                MessageBox.Show("Please enter the information");
                return;
            }

            try
            {
                conn.Open();
                String query;
                
                query = "select * from Student where User_ID=" + textBox1.Text + ";";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Invalid UserID!");
                    return;
                }
                reader.Close();

                query = "select * from Book where ISBN_no=" + textBox2.Text + ";";
                MySqlCommand cmd1 = new MySqlCommand(query, conn);
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                if (!reader1.Read())
                {
                    MessageBox.Show("Invalid ISBN number!");
                    return;
                }
                reader1.Close();

                query = "select * from transaction where ISBN_no=" + textBox2.Text + " and User_ID=" + textBox1.Text + ";";
                MySqlCommand cmd2 = new MySqlCommand(query, conn);
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                if (!reader2.Read())
                {
                    MessageBox.Show("This user hasnot issued this book");
                    return;
                }
                reader2.Close();

                query = "select Date_of_recieve from transaction where ISBN_no=" + textBox2.Text + " and User_ID=" + textBox1.Text + ";";
                MySqlCommand cmd3 = new MySqlCommand(query, conn);
                MySqlDataReader reader3 = cmd3.ExecuteReader();
                DateTime issue = DateTime.Now, ret = DateTime.Now;
                if (reader3.Read())
                {
                    issue = DateTime.Parse(reader3.GetString(0));
                }
                TimeSpan a = ret - issue;
                reader3.Close();

                query = "delete from transaction where ISBN_no=" + textBox2.Text + " and User_ID=" + textBox1.Text + ";";
                MySqlCommand cmd4 = new MySqlCommand(query, conn);
                MySqlDataReader reader4 = cmd4.ExecuteReader();
                reader4.Close();

                query = "update Student set book=book-1 where User_ID='" + textBox1.Text + "';";
                MySqlCommand cmd5 = new MySqlCommand(query, conn);
                MySqlDataReader reader5 = cmd5.ExecuteReader();
                reader5.Close();

                query = "update Book set Available_copies=Available_copies+1 where ISBN_no='" + textBox2.Text + "';";
                MySqlCommand cmd6 = new MySqlCommand(query, conn);
                MySqlDataReader reader6 = cmd6.ExecuteReader();
                reader6.Close();
                
                int t = a.Days;

                if (t > 20)
                {
                    MessageBox.Show("Please pay Rs." + (t - 20));
                }
                else
                {
                    MessageBox.Show("Book returned Successfull");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                textBox1.Clear();
                textBox2.Clear();
                updatetable();
            }
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            String a1 = textBox1.Text;
            String a2 = textBox2.Text;
            if (a1.Length == 0 || a2.Length == 0)
            {
                MessageBox.Show("Please enter the information");
                return;
            }

            try
            {
                conn.Open();
                String query;

                query = "select * from Student where User_ID=" + textBox1.Text + ";";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Invalid UserID!");
                    return;
                }
                reader.Close();

                query = "select * from Book where ISBN_no=" + textBox2.Text + ";";
                MySqlCommand cmd1 = new MySqlCommand(query, conn);
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                if (!reader1.Read())
                {
                    MessageBox.Show("Invalid ISBN number!");
                    return;
                }
                reader1.Close();

                query = "select * from transaction where ISBN_no=" + textBox2.Text + " and User_ID=" + textBox1.Text + ";";
                MySqlCommand cmd2 = new MySqlCommand(query, conn);
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                if (!reader2.Read())
                {
                    MessageBox.Show("This user hasnot issued this book");
                    return;
                }
                reader2.Close();

                query = "select Date_of_recieve from transaction where ISBN_no=" + textBox2.Text + " and User_ID=" + textBox1.Text + ";";
                MySqlCommand cmd3 = new MySqlCommand(query, conn);
                MySqlDataReader reader3 = cmd3.ExecuteReader();
                DateTime issue = DateTime.Now, ret = DateTime.Now;
                if (reader3.Read())
                {
                    issue = DateTime.Parse(reader3.GetString(0));
                }
                TimeSpan a = ret - issue;
                reader3.Close();

                query = "delete from transaction where ISBN_no=" + textBox2.Text + " and User_ID=" + textBox1.Text + ";";
                MySqlCommand cmd4 = new MySqlCommand(query, conn);
                MySqlDataReader reader4 = cmd4.ExecuteReader();
                reader4.Close();

                query = "update Student set book=book-1 where User_ID='" + textBox1.Text + "';";
                MySqlCommand cmd5 = new MySqlCommand(query, conn);
                MySqlDataReader reader5 = cmd5.ExecuteReader();
                reader5.Close();

                query = "select Price from Book where ISBN_no=" + textBox2.Text + ";";
                MySqlCommand cmd6 = new MySqlCommand(query, conn);
                MySqlDataReader reader6 = cmd6.ExecuteReader();
                int cost = 0;
                if (reader6.Read())
                {
                    cost = Int32.Parse(reader6.GetString(0));
                }
                reader6.Close();


                query = "update Book set Stock=Stock-1 where ISBN_no='" + textBox2.Text + "';";
                MySqlCommand cmd7 = new MySqlCommand(query, conn);
                MySqlDataReader reader7 = cmd7.ExecuteReader();
                reader7.Close();

                int t = a.Days;

                if (t > 20)
                {
                    int due = t - 20 + cost + 100;
                    MessageBox.Show("Please pay Rs." + (t - 20)+"+"+cost+"+100 = "+due);
                }
                else
                {
                    int due = cost + 100;
                    MessageBox.Show("Please pay Rs." + cost + "+100 = " + due);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                textBox1.Clear();
                textBox2.Clear();
                updatetable();
            }
        }
    }
}