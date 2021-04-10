using FootballApp.Helper;
using FootballApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballApp
{
    public partial class Form1 : Form
    {
        FootballDbEntities _context = new FootballDbEntities();
        public Form1()
        {
            InitializeComponent();
        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (Utilities.IsEmpty(username,password))
            {
                Worker selectedWorker = _context.Workers.FirstOrDefault(x => x.Username == username);
                if (selectedWorker != null)
                {
                    if (selectedWorker.Password == password.HashCode())
                    {
                        if (chkRemember.Checked)
                        {
                            Properties.Settings.Default.password = txtPassword.Text;
                            Properties.Settings.Default.username = txtUsername.Text;
                            Properties.Settings.Default.isChecked = true;
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            Properties.Settings.Default.password = string.Empty;
                            Properties.Settings.Default.username = string.Empty;
                            Properties.Settings.Default.isChecked = false;
                            Properties.Settings.Default.Save();
                        }

                        switch (selectedWorker.RoleId)
                        {
                            case 1:
                                AdminForm dashboard = new AdminForm(selectedWorker);
                                dashboard.ShowDialog();
                                break;
                            case 2:
                                WorkerDashboard workerDashboard = new WorkerDashboard(selectedWorker);
                                workerDashboard.ShowDialog();
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username or Password isn't valid!","error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Username doesn't exist!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.isChecked)
            {
                txtUsername.Text = Properties.Settings.Default.username;
                txtPassword.Text = Properties.Settings.Default.password;
                chkRemember.Checked = true;
            }
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
