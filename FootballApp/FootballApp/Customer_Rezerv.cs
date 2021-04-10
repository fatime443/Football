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
    public partial class Customer_Rezerv : Form
    {
        FootballDbEntities _context = new FootballDbEntities();
        Reservation selectedReservation;
        public Customer_Rezerv()
        {
            InitializeComponent();
        }
        private void FillCustomerNameComboBox()
        {
            cmbCustomerName.Items.AddRange(_context.Customers.Select(x => x.Name).ToArray());
        }


        private void FillStadiumNameComboBox()
        {
            cmbStadiumName.Items.AddRange(_context.Stadiums.Select(x => x.Name).ToArray());
        }
        private void FillWorkerComboBox()
        {
            cmbWorkerName.Items.AddRange(_context.Workers.Select(x => x.Name).ToArray());
        }
        private void FillField()
        {
            FillCustomerNameComboBox();
            FillStadiumNameComboBox();
            FillWorkerComboBox();
        }
        private void FillReservationDataGridView()
        {
            dtgRezerv.DataSource = _context.Reservations.Select(x => new
            {
                x.Id,
                x.CustomerId,
                x.StadiumId,
                x.WorkerId,
                x.PlayersCount,
                x.Price,
                x.Date,
                x.Description

            }).ToList();
            dtgRezerv.Columns[0].Visible = true;
            for (int i = 0; i < dtgRezerv.Rows.Count; i++)
            {
                if (dtgRezerv.Rows[i].Index % 2 ==0)
                {
                    dtgRezerv.Rows[i].DefaultCellStyle.BackColor = Color.Teal;
                    dtgRezerv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
        private void ClearAllField()
        {
            cmbCustomerName.Text = cmbStadiumName.Text = cmbWorkerName.Text =rtDescription.Text = string.Empty;
            nmPlayersCount.Value = 0;
            nmPrice.Value = 0;
            dtpDate.Value = DateTime.Now;
        }
        private void Customer_Rezerv_Load(object sender, EventArgs e)
        {
            FillReservationDataGridView();
            FillField();
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "MM/dd/yyyy HH:mm";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ButtonVisible(string text)
        {
            if (text == "Add")
            {
                btnRezerv.Visible = false;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                btnRezerv.Visible = true;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = false;

            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private int FindCustomer(string customerName)
        {
            Customer selectedCustomer = _context.Customers.FirstOrDefault(x => x.Name == customerName);
            if (selectedCustomer == null)
            {
                Customer customer = new Customer();
                customer.Name = customerName;
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return customer.Id;

            }
            return selectedCustomer.Id;

        }
        private int FindStadium(string stadiumName)
        {
            Stadium selectedStadium = _context.Stadiums.FirstOrDefault(x => x.Name == stadiumName);
            if (selectedStadium == null)
            {
                Customer customer = new Customer();
                customer.Name = stadiumName;
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return customer.Id;

            }
            return selectedStadium.Id;

        }
        private int FindWorker(string workerName)
        {
            Worker selectedWorker = _context.Workers.FirstOrDefault(x => x.Name == workerName);
            if (selectedWorker == null)
            {
                Customer customer = new Customer();
                customer.Name = workerName;
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return customer.Id;

            }
            return selectedWorker.Id;

        }
        private void btnRezerv_Click(object sender, EventArgs e)
        {
            string customerName = cmbCustomerName.Text;
            string stadiumName = cmbStadiumName.Text;
            string workerName = cmbWorkerName.Text;
            int playersCount = (int)nmPlayersCount.Value;
            decimal Price = nmPrice.Value;
            DateTime Date = dtpDate.Value;
            string Description = rtDescription.Text;
            if (Utilities.IsEmpty(customerName,stadiumName,workerName))
            {
                lblError.Visible = false;
                int customerId = FindCustomer(customerName);
                int stadiumId = FindStadium(stadiumName);
                int workerId = FindWorker(workerName);
                Reservation reservation = new Reservation();
                reservation.Price = Price;
                reservation.PlayersCount = playersCount;
                reservation.Date = Date;
                reservation.Description = Description;
                reservation.CustomerId = customerId;
                reservation.StadiumId = stadiumId;
                reservation.WorkerId = workerId;
                _context.Reservations.Add(reservation);
                _context.SaveChanges();
                MessageBox.Show($"{customerName} received successfully!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillReservationDataGridView();
                ClearAllField();
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
            FillReservationDataGridView();
            lblError.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Utilities.IsEmpty(cmbCustomerName.Text, cmbStadiumName.Text, cmbWorkerName.Text))
            {
                lblError.Visible = false;
                selectedReservation.Customer.Name = cmbCustomerName.Text;
                selectedReservation.Stadium.Name= cmbStadiumName.Text;
                selectedReservation.Worker.Name = cmbWorkerName.Text;
                selectedReservation.PlayersCount = (int)nmPlayersCount.Value;
                selectedReservation.Price = nmPrice.Value;
                selectedReservation.Date = dtpDate.Value;
                selectedReservation.Description = rtDescription.Text;
                _context.SaveChanges();
                ClearAllField();
                FillReservationDataGridView();
                ButtonVisible("Edit");
            }
            else
            {
                lblError.Visible = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete this Rezervation?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.OK)
            {
                _context.Reservations.Remove(selectedReservation);
                _context.SaveChanges();
                ClearAllField();
                FillReservationDataGridView();
                ButtonVisible("Delete");
                MessageBox.Show("Rezervation deleted successfully!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                ClearAllField();
                FillReservationDataGridView();
                ButtonVisible("Add");

            }
        }

        private void dtgRezerv_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ButtonVisible("Add");
            int reservationId = (int)dtgRezerv.Rows[e.RowIndex].Cells[0].Value;
            selectedReservation = _context.Reservations.First(b => b.Id == reservationId);
            cmbCustomerName.Text = selectedReservation.Customer.Name;
            cmbStadiumName.Text = selectedReservation.Stadium.Name;
            cmbWorkerName.Text = selectedReservation.Worker.Name;
            nmPlayersCount.Value = selectedReservation.PlayersCount;
            nmPrice.Value = selectedReservation.Price;
            dtpDate.Value = selectedReservation.Date;
            rtDescription.Text = selectedReservation.Description;
        }
    }
}
