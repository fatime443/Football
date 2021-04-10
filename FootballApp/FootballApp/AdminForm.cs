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
    public partial class AdminForm : Form
    {
        FootballDbEntities _context = new FootballDbEntities();
        public AdminForm(Worker worker)
        {
            _activeWorker = worker;
            InitializeComponent();
        }
        private readonly Worker _activeWorker;
        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.FormClosed += (s, args) => this.Close();
            form1.ShowDialog();
        }

        private void lblAddCustomer_Click(object sender, EventArgs e)
        {
            Add_Customer add_Customer = new Add_Customer();
            add_Customer.ShowDialog();
        }

        private void lblAddStadium_Click(object sender, EventArgs e)
        {
            Add_Stadium add_Stadium = new Add_Stadium();
            add_Stadium.ShowDialog();
        }

        private void lblAddRooms_Click(object sender, EventArgs e)
        {
            Add_Room add_Room = new Add_Room();
            add_Room.ShowDialog();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome " + _activeWorker.Name;
        }

        
    }
}
