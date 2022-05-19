
namespace WindowsFormsApp2
{
    partial class Dis1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dis1));
            this.radio_Reserved = new System.Windows.Forms.RadioButton();
            this.radio_Available = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox_showRooms = new System.Windows.Forms.GroupBox();
            this.btn_Load_infomation = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox_showRooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radio_Reserved
            // 
            this.radio_Reserved.AutoSize = true;
            this.radio_Reserved.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Bold);
            this.radio_Reserved.ForeColor = System.Drawing.Color.Lime;
            this.radio_Reserved.Location = new System.Drawing.Point(9, 21);
            this.radio_Reserved.Name = "radio_Reserved";
            this.radio_Reserved.Size = new System.Drawing.Size(105, 26);
            this.radio_Reserved.TabIndex = 0;
            this.radio_Reserved.TabStop = true;
            this.radio_Reserved.Text = "Reserved";
            this.radio_Reserved.UseVisualStyleBackColor = true;
            this.radio_Reserved.CheckedChanged += new System.EventHandler(this.radio_Reserved_CheckedChanged);
            // 
            // radio_Available
            // 
            this.radio_Available.AutoSize = true;
            this.radio_Available.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Bold);
            this.radio_Available.ForeColor = System.Drawing.Color.Lime;
            this.radio_Available.Location = new System.Drawing.Point(120, 21);
            this.radio_Available.Name = "radio_Available";
            this.radio_Available.Size = new System.Drawing.Size(109, 26);
            this.radio_Available.TabIndex = 1;
            this.radio_Available.TabStop = true;
            this.radio_Available.Text = "Available";
            this.radio_Available.UseVisualStyleBackColor = true;
            this.radio_Available.CheckedChanged += new System.EventHandler(this.radio_Available_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(73, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(643, 273);
            this.dataGridView1.TabIndex = 3;
            // 
            // groupBox_showRooms
            // 
            this.groupBox_showRooms.Controls.Add(this.radio_Available);
            this.groupBox_showRooms.Controls.Add(this.radio_Reserved);
            this.groupBox_showRooms.Font = new System.Drawing.Font("Sylfaen", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox_showRooms.ForeColor = System.Drawing.Color.Lime;
            this.groupBox_showRooms.Location = new System.Drawing.Point(300, 12);
            this.groupBox_showRooms.Name = "groupBox_showRooms";
            this.groupBox_showRooms.Size = new System.Drawing.Size(233, 56);
            this.groupBox_showRooms.TabIndex = 4;
            this.groupBox_showRooms.TabStop = false;
            this.groupBox_showRooms.Text = "Show Rooms";
            this.groupBox_showRooms.Enter += new System.EventHandler(this.groupBox_showRooms_Enter);
            // 
            // btn_Load_infomation
            // 
            this.btn_Load_infomation.BackColor = System.Drawing.Color.Lime;
            this.btn_Load_infomation.Location = new System.Drawing.Point(329, 88);
            this.btn_Load_infomation.Name = "btn_Load_infomation";
            this.btn_Load_infomation.Size = new System.Drawing.Size(181, 23);
            this.btn_Load_infomation.TabIndex = 5;
            this.btn_Load_infomation.Text = "Load_infomation";
            this.btn_Load_infomation.UseVisualStyleBackColor = false;
            this.btn_Load_infomation.Click += new System.EventHandler(this.btn_Load_infomation_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Lime;
            this.btn_save.Location = new System.Drawing.Point(329, 405);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(164, 23);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Save Changes";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(73, 33);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(5);
            this.button1.Size = new System.Drawing.Size(81, 78);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(616, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Dis1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(794, 462);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_Load_infomation);
            this.Controls.Add(this.groupBox_showRooms);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Dis1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dis1";
            this.Load += new System.EventHandler(this.Dis1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox_showRooms.ResumeLayout(false);
            this.groupBox_showRooms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radio_Reserved;
        private System.Windows.Forms.RadioButton radio_Available;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox_showRooms;
        private System.Windows.Forms.Button btn_Load_infomation;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}