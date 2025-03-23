using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Online_MarketPlace
{
    public partial class LoginForm : Form
    {
        public static LoginForm lf;

        public static string loggedInUsername;

        public LoginForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=ALVI08\SQLEXPRESS;Initial Catalog=Online_MarketPlace;Integrated Security=True;Encrypt=False");

        private void label1_Click(object sender, EventArgs e)
        {
            //alviz online market
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //username
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //password
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //LogIn

            // textBox1.Text
            //textBox2.Text
            /* string username = textBox1.Text;
             string password = textBox2.Text;

             if (textBox1.Text == null || textBox2.Text == null)
             {
                 MessageBox.Show("Fill the username/id & password field", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             else
             {
                 string querry = "SELECT * FROM  Login_Info Username = '"+textBox1.Text + "' AND User_password = '"+textBox2.Text + "'";
                 SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                 DataTable dt = new DataTable();
                 sda.Fill(dt);
                 if (dt.Rows.Count > 0)
                 {
                     username = textBox1.Text;
                     password = textBox2.Text;

                     OwnerForm form2 = new OwnerForm();
                     form2.Show();
                     this.Hide();

                 }






                else
                 {
                     MessageBox.Show("Invalid username or password. Please provide valid credentials.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     textBox1.Clear();
                     textBox2.Clear();
                 }
             }*/
            
                string username = textBox1.Text;
                string password = textBox2.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please fill in both username and password fields.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = "SELECT * FROM Login_Info WHERE Username = @username AND User_password = @password";

                using (SqlConnection connection = new SqlConnection(@"Data Source=ALVI08\SQLEXPRESS;Initial Catalog=Online_MarketPlace;Integrated Security=True;Encrypt=False"))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            // Successful login
                            loggedInUsername = username;
                            OwnerForm form2 = new OwnerForm();
                            form2.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Invalid login
                            MessageBox.Show("Invalid username or password. Please provide valid credentials.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Clear();
                            textBox2.Clear();
                        }
                    }
                }
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();

        }
        private void clear()
        {
            textBox1.Text = null;
            textBox2.Text = null;


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}   


