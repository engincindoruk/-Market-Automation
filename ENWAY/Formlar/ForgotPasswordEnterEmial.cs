using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace ENWAY
{
    public partial class ForgotPasswordEnterEmial : Form
    {
        public ForgotPasswordEnterEmial()
        {
            InitializeComponent();
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            if (tbEmail.Text == "")
            {
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }


        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
 
        public string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        public void wait(int milliseconds)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string name = "";
                int id=0;
                var mail = tbEmail.Text.Trim();
                Admin admin = new Admin();
                

                DataTable dt= admin.ForgotPasswordCheckMail(mail);
                foreach (DataRow dr in dt.Rows)
                {
                    name = dr[0].ToString();
                    id = Convert.ToInt16(dr[1].ToString());
                }
                if (name!="")
                {
                    if (MessageBox.Show("Are you " + name, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        SmtpClient sc = new SmtpClient();
                        sc.Port = 587;
                        sc.Host = "smtp.gmail.com";
                        sc.EnableSsl = true;

                        sc.Credentials = new NetworkCredential("", "");
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress("");
                        mailMessage.To.Add(mail);
                        mailMessage.Subject = "Verification Code To Refresh Password";
                        mailMessage.IsBodyHtml = true;
                        var code = RandomPassword();
                        mailMessage.Body = "Verification code: " +code.Trim();

                        try
                        {
                            sc.Send(mailMessage);
                            MessageBox.Show("Please Check Your Mail And Receive Sent Verification Code ");

                            if (admin.ForgotPasswordDeletePassword(id)>0)
                            {
                                AdminChangePassword acp = new AdminChangePassword(mail, code, id);
                                acp.Show();
                                this.Close();

                            }

                        }
                        catch (Exception )
                        {
                            MessageBox.Show("Not Sent The Mail For The Change Password Check Your Mail Settings");
                        }

                    }
                }
                else if(tbEmail.Text=="")
                {
                    lblError.Text = "Fill The Email Adress";
                    wait(1500);
                    lblError.Text = "";
                }

                else
                {
                    lblError.Text = "Not Defined This Email Adress";
                    wait(1500);
                    lblError.Text = "";
                    tbEmail.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Check Again Or Context Your Developer");
            }
        }
    }
}
