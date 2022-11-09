using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Myproject
{
    
    public partial class Form4 : Form
    {
        string choice;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form4(string choice)
        {

            InitializeComponent();
            this.choice = choice;
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f25 = new Form2();
            f25.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (choice.Equals("Doctor")&& textBox6.Text==textBox7.Text)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into DOCTOR_DETAILS values(@name,@dob,@nationality,@certificate_picture,@pro_picture,@cv_picture,@email_addr,@passwrd)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                
                cmd.Parameters.AddWithValue("@dob", textBox2.Text);
                cmd.Parameters.AddWithValue("@nationality", textBox3.Text);
                cmd.Parameters.AddWithValue("@email_addr", textBox5.Text);
                cmd.Parameters.AddWithValue("@passwrd", textBox6.Text);
                cmd.Parameters.AddWithValue("@certificate_picture", SavePhoto(pictureBox1.Image));
                cmd.Parameters.AddWithValue("@pro_picture", SavePhoto(pictureBox2.Image));
                cmd.Parameters.AddWithValue("@cv_picture", SavePhoto(pictureBox3.Image));


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

            else if (textBox6.Text != textBox7.Text)
            {
                MessageBox.Show("password not matched");
            }

            else
            {
                string name, dob, nationality, email_address, password,re_enter_password;
                byte[] certificate_image, cv_image, pro_picture;

                name = textBox1.Text;
                dob = textBox2.Text;
                nationality = textBox3.Text;
                email_address = textBox5.Text;
                password = textBox6.Text;
               
                certificate_image = SavePhoto(pictureBox1.Image);
                cv_image = SavePhoto(pictureBox3.Image);
                pro_picture = SavePhoto(pictureBox2.Image);
                re_enter_password = textBox7.Text;

                this.Hide();
                Form5 f25 = new Form5(name, dob, nationality, email_address, password, certificate_image, cv_image, pro_picture,re_enter_password);
                f25.Show();
            }
        }

        private byte[] SavePhoto(Image pic)
        {
            MemoryStream ms = new MemoryStream();
          
            pic.Save(ms, pic.RawFormat);

            return ms.GetBuffer();
        }

        

       

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "SELECT IMAGE";
            of.Filter = "SELECT IMAGE (ALL FILES) *.*)|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(of.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
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

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Enter Date of birth!");

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
                errorProvider3.SetError(this.textBox3, "Enter Nationality!");

            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) == true)
            {
                textBox5.Focus();
                errorProvider4.SetError(this.textBox5, "Enter Email Address!");

            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text) == true)
            {
                textBox6.Focus();
                errorProvider5.SetError(this.textBox6, "Enter Passwird!");

            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text) == true)
            {
                textBox7.Focus();
                errorProvider6.SetError(this.textBox7, "Enter re-enter password!");

            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox6.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox6.UseSystemPasswordChar = true;
                    break;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox2.Checked;
            switch (status)
            {
                case true:
                    textBox7.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox7.UseSystemPasswordChar = true;
                    break;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Choose image";
            OFD.Filter = "All Files (*.*)|*.*";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(OFD.FileName);
               
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Choose image";
            OFD.Filter = "All Files (*.*)|*.*";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(OFD.FileName);

            }
             
            }

        private void button6_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            pictureBox1.Image = Properties.Resources.No_Image_Available;
            pictureBox2.Image = Properties.Resources.No_Image_Available;
            pictureBox3.Image = Properties.Resources.No_Image_Available;
            

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        }
    }

