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
    public partial class Add_Customer : Form
    {
        FootballDbEntities _context = new FootballDbEntities();
        Customer selectedCustomer;
        public Add_Customer()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Add_Customer_Load(object sender, EventArgs e)
        {
            FillCustomerDataGridView();
        }
        private void ClearAllField()
        {
            txtCusSurname.Text = txtCustomerName.Text = txtPhone.Text = string.Empty;
        }
        private void FillCustomerDataGridView()
        {
            dtgCustomer.DataSource = _context.Customers.Select(x => new {
                x.Id,
                x.Name,
                x.Surname,
                x.Phone
            }).ToList();
            dtgCustomer.Columns[0].Visible = false;
            for (int i = 0; i < dtgCustomer.Rows.Count; i++)
            {
                if (dtgCustomer.Rows[i].Index % 2 ==0)
                {
                    dtgCustomer.Rows[i].DefaultCellStyle.BackColor = Color.Teal;
                    dtgCustomer.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
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
       

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 47 || e.KeyChar > 58) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void dtgCustomer_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ButtonVisible("Add");
            int customerId = (int)dtgCustomer.Rows[e.RowIndex].Cells[0].Value;
            selectedCustomer = _context.Customers.First(b => b.Id == customerId);
            txtCustomerName.Text = selectedCustomer.Name;
            txtCusSurname.Text = selectedCustomer.Surname;
            txtPhone.Text = selectedCustomer.Phone;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ButtonVisible("Cancel");
            ClearAllField();
            FillCustomerDataGridView();
            lblError.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            string customerSurname = txtCusSurname.Text;
            string customerPhone = txtPhone.Text;
            if (Utilities.IsEmpty(customerName, customerSurname, customerPhone))
            {
                Customer selecetedCustom = _context.Customers.FirstOrDefault(a => a.Name == customerName);
                if (selecetedCustom == null)
                {
                    lblError.Visible = false;
                    Customer customer = new Customer
                    {
                        Name = customerName,
                        Surname = customerSurname,
                        Phone = customerPhone
                    };
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                    MessageBox.Show("Customer created successfully!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllField();
                    FillCustomerDataGridView();
                }
                else
                {
                    lblError.Text = "Customer name already exist!";
                    lblError.Visible = true;
                }

            }
            else
            {
                lblError.Text = "Please, fill all field!";
                lblError.Visible = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete this Customer?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.OK)
            {
                _context.Customers.Remove(selectedCustomer);
                _context.SaveChanges();
                ClearAllField();
                FillCustomerDataGridView();
                ButtonVisible("Delete");
                MessageBox.Show("Customer deleted successfully!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                ClearAllField();
                FillCustomerDataGridView();
                ButtonVisible("Add");

            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Utilities.IsEmpty(txtCustomerName.Text,txtCusSurname.Text,txtPhone.Text))
            {
                lblError.Visible = false;
                selectedCustomer.Name = txtCustomerName.Text;
                selectedCustomer.Surname = txtCusSurname.Text;
                selectedCustomer.Phone = txtPhone.Text;
                _context.SaveChanges();
                ClearAllField();
                FillCustomerDataGridView();
                ButtonVisible("Edit");
            }
            else
            {
                lblError.Visible = true;
            }
          
        }
    }
}
