using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Myproject
{
    public partial class Form3 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form3()
        {
            InitializeComponent();
           // BindGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(textBox8.Text==textBox9.Text)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into MEMBER_DETAILS values(@name,@age,@gender,@dob,@addr,@email_addr,@mobile_number,@passwrd,@img) ";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", textBox1.Text);

                cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@gender", textBox3.Text);
                cmd.Parameters.AddWithValue("@dob", textBox4.Text);
                cmd.Parameters.AddWithValue("@addr", textBox5.Text);
                cmd.Parameters.AddWithValue("@email_addr", textBox6.Text);
                cmd.Parameters.AddWithValue("@mobile_number", textBox7.Text);
                cmd.Parameters.AddWithValue("@passwrd", textBox8.Text);
                cmd.Parameters.AddWithValue("@img", SavePhoto());


                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show(" Sign up successfull ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(" Sign up not successfull", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Password not matched!Please try again!");
            }
            
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f25 = new Form2();
            f25.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter Name!");

            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(numericUpDown1.Text) == true)
            {
                numericUpDown1.Focus();
                errorProvider2.SetError(this.numericUpDown1, "Enter Age!");

            }
            else
            {
                
                errorProvider2.Clear();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Enter Gender!");

            }
            else
            {
                errorProvider3.Clear();
            }
        }

        

        private void textBox4_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Enter Date-of-birth!");

            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) == true)
            {
                textBox5.Focus();
                errorProvider5.SetError(this.textBox5, "Enter Address!");

            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text) == true)
            {
                textBox6.Focus();
                errorProvider6.SetError(this.textBox6, "Enter email address!");

            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text) == true)
            {
                textBox7.Focus();
                errorProvider7.SetError(this.textBox7, "Enter mobile number!");

            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text) == true)
            {
                textBox8.Focus();
                errorProvider8.SetError(this.textBox8, "Enter password!");

            }
            else
            {
                errorProvider8.Clear();
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox9.Text) == true)
            {
                textBox9.Focus();
                errorProvider9.SetError(this.textBox9, "Re-Enter password !");

            }
            else
            {
                errorProvider9.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox8.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox8.UseSystemPasswordChar = true;
                    break;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox2.Checked;
            switch (status)
            {
                case true:
                    textBox9.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox9.UseSystemPasswordChar = true;
                    break;

            }
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ResetControl();
        }

         void ResetControl()
        {
            textBox1.Clear();
            
            numericUpDown1.Value = 0;
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            pictureBox1.Image = Properties.Resources.No_Image_Available;

        }

         private void button4_Click(object sender, EventArgs e)
         {
             OpenFileDialog of = new OpenFileDialog();
             of.Title = "SELECT IMAGE";
             of.Filter = "SELECT IMAGE (ALL FILES) *.*)|*.*";
             if (of.ShowDialog() == DialogResult.OK)
             {
                 pictureBox1.Image = new Bitmap(of.FileName);
             }
         }

           

        }

       
    }





            
