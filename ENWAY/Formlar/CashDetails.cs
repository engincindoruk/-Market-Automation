using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENWAY
{
    public partial class CashDetails : Form
    {

        Casa casa;
        string CasaDetailsclienttype = "customer";
        public CashDetails(string text)
        {
            InitializeComponent();
            Text = text;
            casa = new Casa();
        }

        void clear()
        {
            lblCasaDetailsid.Text = "";
            lblCasaDetailsClientName.Text = "";
            lblCasaDetailsTotal.Text = "";
            cbCasaDetailsAdminName.Text = "";
            cbCashDetailsMovement.Text = "";
            cbCashDetailsType.Text = "";

        }
        void refresh()
        {
            if (CasaDetailsclienttype == "customer")
            {
                btnCashDetailCustomer.BackColor = Color.White;
                CasaDetailsclienttype = "customer";
                btnCashDetailArtisan.BackColor = Color.Transparent;
                dataGridView1.DataSource = casa.GetCustomersCash();
            }
            else
            {
                btnCashDetailCustomer.BackColor = Color.Transparent;
                CasaDetailsclienttype = "artisan";
                btnCashDetailArtisan.BackColor = Color.White;
                dataGridView1.DataSource = casa.GetArtisansCash();
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Enway enway = new Enway();
            enway.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Enway enway = new Enway();
            enway.Show();
            this.Close();
        }

        private void GetChart1()
        {
            chart1.Series[","].Points.Clear();
            DataTable dt3 = casa.GetIncomeTopPrice();

            foreach (DataRow dr in dt3.Rows)
            {
                chart1.Series[","].Points.AddXY(dr["CashTypeName"].ToString(), dr["Total"]);
            }
        }

        private void GetChart2()
        {
            chart2.Series["."].Points.Clear();
            DataTable dt4 = casa.GetExportTopPrice();

            foreach (DataRow dr in dt4.Rows)
            {
                chart2.Series["."].Points.AddXY(dr["CashTypeName"].ToString(), dr["Total"]);
            }


        }

        private void CashDetails_Load(object sender, EventArgs e)
        {
            try
            {
                if (Text != "")
                {
                    lbl__Name.Text = Text;
                }

                DataTable dt = casa.GetCashExport();
                DataTable dt2 = casa.GetCashIncome();
                foreach (DataRow dr in dt.Rows)
                {
                    lblTotalexport.Text = dr["total"].ToString();
                }
                foreach (DataRow dr in dt2.Rows)
                {
                    lblTotalincome.Text = dr["total"].ToString();
                }
                lblCasaRevenues.Text = (Convert.ToInt16(lblTotalincome.Text) - Convert.ToInt16(lblTotalexport.Text)).ToString();
              
                GetChart1();
                GetChart2();
               
                btnCashDetailCustomer.BackColor = Color.White;
                dataGridView1.DataSource = casa.GetCustomersCash();

                DataTable dt5 = casa.GetCashMovement();
                foreach (DataRow dr in dt5.Rows)
                {
                    cbCashDetailsMovement.Items.Add(dr["CashMovementName"].ToString());
                }
                DataTable dt6 = casa.GetCashType();
                foreach (DataRow dr in dt6.Rows)
                {
                    cbCashDetailsType.Items.Add(dr["CashTypeName"].ToString());
                }
                Admin admin = new Admin();
                DataTable dt7 = admin.getAdmin();
                foreach (DataRow dr in dt7.Rows)
                {
                    cbCasaDetailsAdminName.Items.Add(dr["AdminName"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

        }

        private void btnCashDetailArtisan_Click(object sender, EventArgs e)
        {
            btnCashDetailCustomer.BackColor = Color.Transparent;
            CasaDetailsclienttype = "artisan";
            btnCashDetailArtisan.BackColor = Color.White;
            dataGridView1.DataSource = casa.GetArtisansCash();
        }

        private void btnCashDetailCustomer_Click(object sender, EventArgs e)
        {
            btnCashDetailCustomer.BackColor = Color.White;
            CasaDetailsclienttype = "customer";
            btnCashDetailArtisan.BackColor = Color.Transparent;
            dataGridView1.DataSource = casa.GetCustomersCash();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dataGridView1.SelectedCells[0].RowIndex;
                lblCasaDetailsid.Text= dataGridView1.Rows[index].Cells[0].Value.ToString();
                lblCasaDetailsClientName.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                dtpCasaDetailstime.Value = Convert.ToDateTime(dataGridView1.Rows[index].Cells[4].Value.ToString());
                lblCasaDetailsTotal.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                cbCasaDetailsAdminName.Text= dataGridView1.Rows[index].Cells[6].Value.ToString();
                cbCashDetailsMovement.Text= dataGridView1.Rows[index].Cells[3].Value.ToString();
                cbCashDetailsType.Text= dataGridView1.Rows[index].Cells[2].Value.ToString();

            }
            catch (Exception )
            {
                MessageBox.Show("Please Select One in Casa List");
            }
        }

        private void btnCashDetailsRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnCashDetailsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCasaDetailsid.Text != "")
                {
                    var delete = casa.DeleteCash(Convert.ToInt16(lblCasaDetailsid.Text.Trim()));
                    lblErrorCashDetails.Text = "Deleting Successfully";
                    GetChart1();
                    GetChart2();
                    wait(1000);
                    lblErrorCashDetails.Text = "";
                    clear();
                    refresh();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Select One in Cash List");
            }
        }

        private void btnCashDetailsEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int clientid = 0;
                if (lblCasaDetailsid.Text != "")
                {
                    string Cashmovementidgetch = "", CashTypeidgetch = "", adminid = "";

                    DataTable dt = casa.GetidfromCashmovement(cbCashDetailsMovement.Text);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Cashmovementidgetch = dr["id"].ToString();
                    }
                    DataTable dt2 = casa.GetidfromCashtype(cbCashDetailsType.Text);
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        CashTypeidgetch = dr2["id"].ToString();
                    }

                    Admin admin = new Admin();
                    DataTable dt4 = admin.GetidfromName(cbCasaDetailsAdminName.Text);
                    foreach (DataRow dr in dt4.Rows)
                    {
                        adminid = dr["Adminid"].ToString();
                    }

                    if (CasaDetailsclienttype=="customer")
                    {
                        DataTable dt5 = casa.GetidfromClientNameForc(lblCasaDetailsClientName.Text.Trim());
                        foreach (DataRow dr in dt5.Rows)
                        {
                            clientid = Convert.ToInt16(dr["Customerid"].ToString());
                        }
                    }
                    else 
                    {
                        DataTable dt6 = casa.GetidfromClientNameForA(lblCasaDetailsClientName.Text.Trim());
                        foreach (DataRow dr in dt6.Rows)
                        {
                            clientid = Convert.ToInt16(dr["Artisanid"].ToString());
                        }

                    }

                    if (cbCashDetailsType.Text != "" && cbCashDetailsMovement.Text != "" && cbCasaDetailsAdminName.Text != "" &&
                        casa.UpdateCasa(Convert.ToInt16(lblCasaDetailsid.Text), clientid,CasaDetailsclienttype, Convert.ToInt16(CashTypeidgetch.Trim()), Convert.ToInt16(Cashmovementidgetch.Trim()), dtpCasaDetailstime.Value.ToShortDateString(), Convert.ToInt16(lblCasaDetailsTotal.Text), Convert.ToInt16(adminid)) > 0)
                    {
                        lblErrorCashDetails.Text = "Updating Succesfully";
                        refresh();
                        clear();
                        GetChart1();
                        GetChart2();
                        wait(1500);
                        lblErrorCashDetails.Text = "";

                    }
                    else
                    {
                        lblErrorCashDetails.Text = "Check The Information";
                        wait(1000);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select One in CashList");
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }
    }
}
