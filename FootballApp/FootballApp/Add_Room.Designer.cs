
namespace FootballApp
{
    partial class Add_Room
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Room));
            this.label1 = new System.Windows.Forms.Label();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nmMaxUser = new System.Windows.Forms.NumericUpDown();
            this.chkIsVIP = new System.Windows.Forms.CheckBox();
            this.dtgRoom = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(50, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Room Number";
            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Location = new System.Drawing.Point(55, 60);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.Size = new System.Drawing.Size(339, 34);
            this.txtRoomNumber.TabIndex = 1;
            this.txtRoomNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoomNumber_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(50, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "MaxUser";
            // 
            // nmMaxUser
            // 
            this.nmMaxUser.Location = new System.Drawing.Point(55, 150);
            this.nmMaxUser.Name = "nmMaxUser";
            this.nmMaxUser.Size = new System.Drawing.Size(339, 34);
            this.nmMaxUser.TabIndex = 3;
            // 
            // chkIsVIP
            // 
            this.chkIsVIP.AutoSize = true;
            this.chkIsVIP.Location = new System.Drawing.Point(55, 202);
            this.chkIsVIP.Name = "chkIsVIP";
            this.chkIsVIP.Size = new System.Drawing.Size(98, 31);
            this.chkIsVIP.TabIndex = 4;
            this.chkIsVIP.Text = "IsVIP";
            this.chkIsVIP.UseVisualStyleBackColor = true;
            // 
            // dtgRoom
            // 
            this.dtgRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRoom.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgRoom.BackgroundColor = System.Drawing.Color.White;
            this.dtgRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRoom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgRoom.GridColor = System.Drawing.Color.DimGray;
            this.dtgRoom.Location = new System.Drawing.Point(0, 508);
            this.dtgRoom.Name = "dtgRoom";
            this.dtgRoom.RowHeadersWidth = 51;
            this.dtgRoom.RowTemplate.Height = 24;
            this.dtgRoom.Size = new System.Drawing.Size(1074, 262);
            this.dtgRoom.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Teal;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(52, 272);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(339, 63);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(48, 362);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(190, 20);
            this.lblError.TabIndex = 25;
            this.lblError.Text = "Room name is empty!";
            this.lblError.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(400, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(672, 499);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // Add_Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1074, 770);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtgRoom);
            this.Controls.Add(this.chkIsVIP);
            this.Controls.Add(this.nmMaxUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRoomNumber);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Add_Room";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Room";
            this.Load += new System.EventHandler(this.Add_Room_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nmMaxUser;
        private System.Windows.Forms.CheckBox chkIsVIP;
        private System.Windows.Forms.DataGridView dtgRoom;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}