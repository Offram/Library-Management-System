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

namespace Library_Management_System
{
    public partial class Reg : Form
    {
        SqlConnection con;
        SqlCommand cmd;

        public Reg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int x = 0;
                
                do
                {
                        if (string.IsNullOrEmpty(txt_id.Text))
                            MessageBox.Show("Member ID cannot be blank");
                        else if (string.IsNullOrEmpty(txt_fname.Text))
                            MessageBox.Show("First Name cannot be Empty");
                        else if (txt_fname.Text.Any(char.IsDigit))
                            MessageBox.Show("First Name cannot have numbers");
                        else if (string.IsNullOrEmpty(txt_lname.Text))
                            MessageBox.Show("Last Name cannot be Empty");
                        else if (txt_lname.Text.Any(char.IsDigit))
                            MessageBox.Show("Last Name cannot have numbers");
                        else if (string.IsNullOrEmpty(txt_fullname.Text))
                            MessageBox.Show("Full Name cannot be Empty");
                        else if (txt_fullname.Text.Any(char.IsDigit))
                            MessageBox.Show("Full Name cannot have numbers");
                        else if (string.IsNullOrEmpty(dtp_dob.Text))
                            MessageBox.Show("Date of Birth cannot be Empty");
                        else if (string.IsNullOrEmpty(txt_addr.Text))
                            MessageBox.Show("Full Address cannot be Empty");
                        else if (string.IsNullOrEmpty(txt_pc.Text))
                            MessageBox.Show("Postal Code cannot be Empty");
                        else if (string.IsNullOrEmpty(txt_nic.Text))
                            MessageBox.Show("NIC cannot be Empty");
                        else if (rbtn_male.Checked == false & rbtn_female.Checked == false)
                            MessageBox.Show("Gender cannot be Empty");
                        else
                        {
                            x = 1;
                            int gender = 1;

                            if (rbtn_male.Checked == true)
                            { gender = 1; }
                            else if (rbtn_female.Checked == true)
                            { gender = 0; }

                            con.Open();
                            cmd = new SqlCommand("INSERT INTO Member VALUES ('" + txt_id.Text + "','" + txt_fname.Text + "','" + txt_lname.Text + "','" + txt_fullname.Text + "','" + dtp_dob.Value.Date + "','" + txt_addr.Text + "','" + txt_pc.Text + "','" + txt_nic.Text + "',@g)", con);
                            cmd.Parameters.AddWithValue("g", gender);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Data successfully saved in database");
                        }

                }
                 while (x == 0);

                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Reg_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(@"Data Source=DESKTOP-99OKMBM\MSSQLDEV;Initial Catalog=LibraryManagement;Integrated Security=True");
                error_dob.SetError(dtp_dob, "Date of Birth is required");
                error_gender.SetError(grpBx_gender, "Gender is required");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txt_fname_TextChanged(object sender, EventArgs e)
        {
            if (txt_fname.Text.Length > 0)
                error_fname.Clear();
            else if (txt_fname.Text.Length == 0)
                error_fname.SetError(txt_fname, "First Name is required");
        }

        private void txt_lname_TextChanged(object sender, EventArgs e)
        {
            if (txt_lname.Text.Length > 0)
                error_lname.Clear();
            else if (txt_lname.Text.Length == 0)
                error_lname.SetError(txt_lname, "Last Name is required");
        }

        private void txt_fullname_TextChanged(object sender, EventArgs e)
        {
            if (txt_fullname.Text.Length > 0)
                error_fullname.Clear();
            else if (txt_fullname.Text.Length == 0)
                error_fullname.SetError(txt_fullname, "Full Name is required");
        }

        private void txt_addr_TextChanged(object sender, EventArgs e)
        {
            if (txt_addr.Text.Length > 0)
                error_addr.Clear();
            else if (txt_addr.Text.Length == 0)
                error_addr.SetError(txt_addr, "Full Address is required");
        }

        private void txt_pc_TextChanged(object sender, EventArgs e)
        {
            if (txt_pc.Text.Length > 0)
                error_pc.Clear();
            else if (txt_pc.Text.Length == 0)
                error_pc.SetError(txt_pc, "Postal Code is required");
        }

        private void dtp_dob_ValueChanged(object sender, EventArgs e)
        {
            error_dob.Clear();
        }

        private void grpBx_gender_Enter(object sender, EventArgs e)
        {
            error_gender.Clear();
        }

        private void txt_nic_TextChanged(object sender, EventArgs e)
        {
            if (txt_nic.Text.Length > 0)
            {
                error_nic.Clear();
                if (txt_nic.Text.Length==10 & !txt_nic.Text.EndsWith("v"))
                { error_nic.SetError(txt_nic, "NIC Should end with 'v'"); }
                else if(txt_nic.Text.Length>10)
                { error_nic.SetError(txt_nic, "NIC cannot be more than 10 characters"); }
                
            }
            else if (txt_nic.Text.Length == 0)
                error_nic.SetError(txt_nic, "NIC is required");
        }

        private void txt_tp_TextChanged(object sender, EventArgs e)
        {
            if (txt_tp.Text.Length > 0)
                error_tp.Clear();
            else if (txt_tp.Text.Length == 0)
                error_tp.SetError(txt_tp, "Telephone Number is required");
        }

        private void txt_nic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^v]") && !(e.KeyChar == (char)8))
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }
        }

        private void txt_pc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9]") && !(e.KeyChar == (char)8))
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }
        }

        private void txt_fname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt_lname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt_fullname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt_tp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9]") && !(char.IsControl(e.KeyChar)))
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }
        }
    }
}
