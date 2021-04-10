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
    public partial class Add_Room : Form
    {
        FootballDbEntities _context = new FootballDbEntities();
        public Add_Room()
        {
            InitializeComponent();
        }
        private void ClearAllField()
        {
            txtRoomNumber.Text = string.Empty;
            nmMaxUser.Value = 0;
        }
        private void FillRoomDataGridView()
        {
            dtgRoom.DataSource = _context.Rooms.Select(x => new
            {
                x.Id,
                x.Room_Number,
                x.MaxUser,
                x.isVIP
            }).ToList();
            dtgRoom.Columns[0].Visible = false;
            for (int i = 0; i < dtgRoom.Rows.Count; i++)
            {
                if (dtgRoom.Rows[i].Index % 2 == 0)
                {
                    dtgRoom.Rows[i].DefaultCellStyle.BackColor = Color.Teal;
                    dtgRoom.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }
            }
        }
        private void Add_Room_Load(object sender, EventArgs e)
        {
            FillRoomDataGridView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int roomNumber = Convert.ToInt32(txtRoomNumber.Text);
            int maxUser = (int)nmMaxUser.Value;
            if (Utilities.IsEmpty(Convert.ToString(roomNumber)))
            {
                Room selectedRoom = _context.Rooms.FirstOrDefault(x => x.Room_Number == roomNumber);
                if (selectedRoom == null)
                {

                    Room room = new Room()
                    {
                        Room_Number = roomNumber,
                        MaxUser = maxUser,
                        isVIP = chkIsVIP.Checked ? true : false
                    };
                    _context.Rooms.Add(room);
                    _context.SaveChanges();
                    MessageBox.Show("Room created successfully!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllField();
                    FillRoomDataGridView();
                }
                else
                {
                    lblError.Visible = true;

                }

            }
            else
            {
                lblError.Visible = true;
            }
        }

        private void txtRoomNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 47 || e.KeyChar > 58) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }
    }
}
