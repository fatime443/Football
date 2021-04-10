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
    public partial class Add_Stadium : Form
    {
        FootballDbEntities _context = new FootballDbEntities();
        Stadium selectedStadium;
        public Add_Stadium()
        {
            InitializeComponent();
        }
        private void FillStadiumDataGridView()
        {
            dtgStadium.DataSource = _context.Stadiums.Select(x => new {
                x.Id,
                x.Name,
                x.Number
            }).ToList();
            dtgStadium.Columns[0].Visible = false;
            for (int i = 0; i < dtgStadium.Rows.Count; i++)
            {
                if (dtgStadium.Rows[i].Index % 2 == 0)
                {
                    dtgStadium.Rows[i].DefaultCellStyle.BackColor = Color.Teal;
                    dtgStadium.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }
            }
        }
        private void ClearAllField()
        {
            txtStName.Text = txtStNumber.Text = string.Empty;
        }
       

        private void Add_Stadium_Load(object sender, EventArgs e)
        {
            FillStadiumDataGridView();
        }

        private void txtStNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 47 || e.KeyChar > 58) && e.KeyChar != 8 && e.KeyChar !=46)
            {
                e.Handled = true;
            }
        }

        private void dtgStadium_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ButtonVisible("Add");
            int stadiumId = (int)dtgStadium.Rows[e.RowIndex].Cells[0].Value;
            selectedStadium = _context.Stadiums.First(b => b.Id == stadiumId);
            txtStName.Text = selectedStadium.Name;
            txtStNumber.Text = Convert.ToString(selectedStadium.Number);
        }
        private void ButtonVisible(string text)
        {
            if (text == "Add")
            {
                btnAdd.Visible = false;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                btnAdd.Visible = true;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = false;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string stadiumName = txtStName.Text;
            string stadiumNumber = txtStNumber.Text;

            if (Utilities.IsEmpty(stadiumName))
            {
                Stadium selecetedCustom = _context.Stadiums.FirstOrDefault(a => a.Name == stadiumName);
                if (selecetedCustom == null)
                {
                    lblError.Visible = false;
                    Stadium stadium = new Stadium();
                    stadium.Name = stadiumName;
                    stadium.Number = Convert.ToInt32(stadiumNumber);
                    _context.Stadiums.Add(stadium);
                    _context.SaveChanges();
                    MessageBox.Show("Stadium created successfully!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllField();
                    FillStadiumDataGridView();
                }
                else
                {
                    lblError.Text = "Stadium name already exist!";
                    lblError.Visible = true;
                }

            }
            else
            {
                lblError.Text = "Please, fill all field!";
                lblError.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ButtonVisible("Cancel");
            ClearAllField();
            FillStadiumDataGridView();
            lblError.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete this Stadium?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.OK)
            {
                _context.Stadiums.Remove(selectedStadium);
                _context.SaveChanges();
                MessageBox.Show("Stadium deleted successfully!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllField();
                FillStadiumDataGridView();
                ButtonVisible("Delete");

            }
            else
            {
                ClearAllField();
                FillStadiumDataGridView();
                ButtonVisible("Add");

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Utilities.IsEmpty(txtStName.Text,txtStNumber.Text))
            {
                lblError.Visible = false;
                selectedStadium.Name = txtStName.Text;
                selectedStadium.Number = Convert.ToInt32(txtStNumber.Text);
                _context.SaveChanges();
                ClearAllField();
                FillStadiumDataGridView();
            }
            else
            {
                lblError.Visible = true;
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
    
}
