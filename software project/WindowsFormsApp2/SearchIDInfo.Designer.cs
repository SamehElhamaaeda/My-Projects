
namespace WindowsFormsApp2
{
    partial class SearchIDInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchIDInfo));
            this.txt_Inquire = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rich_InfoID = new System.Windows.Forms.RichTextBox();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.btn_Inquire = new System.Windows.Forms.Button();
            this.txt_filter = new System.Windows.Forms.TextBox();
            this.rich_FilterByPrice = new System.Windows.Forms.RichTextBox();
            this.btn_filter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_cheapestRoom = new System.Windows.Forms.Label();
            this.radio_more = new System.Windows.Forms.RadioButton();
            this.radio_less = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_FoundID = new System.Windows.Forms.TextBox();
            this.txt_LName = new System.Windows.Forms.TextBox();
            this.txt_FName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Inquire
            // 
            this.txt_Inquire.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_Inquire.Location = new System.Drawing.Point(344, 271);
            this.txt_Inquire.Name = "txt_Inquire";
            this.txt_Inquire.Size = new System.Drawing.Size(100, 22);
            this.txt_Inquire.TabIndex = 1;
            this.txt_Inquire.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(113, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Room Reserved BY ID";
            // 
            // rich_InfoID
            // 
            this.rich_InfoID.Enabled = false;
            this.rich_InfoID.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rich_InfoID.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rich_InfoID.Location = new System.Drawing.Point(12, 299);
            this.rich_InfoID.Name = "rich_InfoID";
            this.rich_InfoID.ReadOnly = true;
            this.rich_InfoID.Size = new System.Drawing.Size(776, 139);
            this.rich_InfoID.TabIndex = 6;
            this.rich_InfoID.Text = "";
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // btn_Inquire
            // 
            this.btn_Inquire.BackColor = System.Drawing.Color.Lime;
            this.btn_Inquire.Font = new System.Drawing.Font("Sylfaen", 8.25F);
            this.btn_Inquire.Location = new System.Drawing.Point(464, 271);
            this.btn_Inquire.Name = "btn_Inquire";
            this.btn_Inquire.Size = new System.Drawing.Size(75, 23);
            this.btn_Inquire.TabIndex = 9;
            this.btn_Inquire.Text = "GO";
            this.btn_Inquire.UseVisualStyleBackColor = false;
            this.btn_Inquire.Click += new System.EventHandler(this.btn_Inquire_Click_1);
            // 
            // txt_filter
            // 
            this.txt_filter.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_filter.Location = new System.Drawing.Point(73, 69);
            this.txt_filter.Name = "txt_filter";
            this.txt_filter.Size = new System.Drawing.Size(100, 25);
            this.txt_filter.TabIndex = 12;
            // 
            // rich_FilterByPrice
            // 
            this.rich_FilterByPrice.Enabled = false;
            this.rich_FilterByPrice.Font = new System.Drawing.Font("Sylfaen", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rich_FilterByPrice.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rich_FilterByPrice.Location = new System.Drawing.Point(12, 125);
            this.rich_FilterByPrice.Name = "rich_FilterByPrice";
            this.rich_FilterByPrice.ReadOnly = true;
            this.rich_FilterByPrice.Size = new System.Drawing.Size(776, 131);
            this.rich_FilterByPrice.TabIndex = 14;
            this.rich_FilterByPrice.Text = "";
            // 
            // btn_filter
            // 
            this.btn_filter.BackColor = System.Drawing.Color.Lime;
            this.btn_filter.ForeColor = System.Drawing.Color.Black;
            this.btn_filter.Location = new System.Drawing.Point(208, 71);
            this.btn_filter.Name = "btn_filter";
            this.btn_filter.Size = new System.Drawing.Size(43, 23);
            this.btn_filter.TabIndex = 15;
            this.btn_filter.Text = "Go";
            this.btn_filter.UseVisualStyleBackColor = false;
            this.btn_filter.Click += new System.EventHandler(this.btn_filter_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Controls.Add(this.lbl_cheapestRoom);
            this.groupBox1.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Lime;
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 60);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rooms Prices Start With ";
            // 
            // lbl_cheapestRoom
            // 
            this.lbl_cheapestRoom.AutoSize = true;
            this.lbl_cheapestRoom.BackColor = System.Drawing.Color.Black;
            this.lbl_cheapestRoom.Font = new System.Drawing.Font("Sylfaen", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cheapestRoom.ForeColor = System.Drawing.Color.Lime;
            this.lbl_cheapestRoom.Location = new System.Drawing.Point(75, 23);
            this.lbl_cheapestRoom.Name = "lbl_cheapestRoom";
            this.lbl_cheapestRoom.Size = new System.Drawing.Size(66, 28);
            this.lbl_cheapestRoom.TabIndex = 21;
            this.lbl_cheapestRoom.Text = "label2";
            // 
            // radio_more
            // 
            this.radio_more.AutoSize = true;
            this.radio_more.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.radio_more.ForeColor = System.Drawing.Color.Lime;
            this.radio_more.Location = new System.Drawing.Point(141, 24);
            this.radio_more.Name = "radio_more";
            this.radio_more.Size = new System.Drawing.Size(78, 30);
            this.radio_more.TabIndex = 21;
            this.radio_more.TabStop = true;
            this.radio_more.Text = "More";
            this.radio_more.UseVisualStyleBackColor = true;
            // 
            // radio_less
            // 
            this.radio_less.AutoSize = true;
            this.radio_less.Font = new System.Drawing.Font("Sylfaen", 12F);
            this.radio_less.ForeColor = System.Drawing.Color.Lime;
            this.radio_less.Location = new System.Drawing.Point(56, 24);
            this.radio_less.Name = "radio_less";
            this.radio_less.Size = new System.Drawing.Size(67, 30);
            this.radio_less.TabIndex = 22;
            this.radio_less.TabStop = true;
            this.radio_less.Text = "Less";
            this.radio_less.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radio_more);
            this.groupBox2.Controls.Add(this.radio_less);
            this.groupBox2.Controls.Add(this.btn_filter);
            this.groupBox2.Controls.Add(this.txt_filter);
            this.groupBox2.Font = new System.Drawing.Font("Sylfaen", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Lime;
            this.groupBox2.Location = new System.Drawing.Point(243, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 116);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Room Filter By Price";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txt_FoundID);
            this.groupBox3.Controls.Add(this.txt_LName);
            this.groupBox3.Controls.Add(this.txt_FName);
            this.groupBox3.Font = new System.Drawing.Font("Sylfaen", 8.25F);
            this.groupBox3.ForeColor = System.Drawing.Color.Lime;
            this.groupBox3.Location = new System.Drawing.Point(550, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 110);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Find ID By Name";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(187, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "GO";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_FoundID
            // 
            this.txt_FoundID.Enabled = false;
            this.txt_FoundID.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_FoundID.Location = new System.Drawing.Point(49, 65);
            this.txt_FoundID.Name = "txt_FoundID";
            this.txt_FoundID.ReadOnly = true;
            this.txt_FoundID.Size = new System.Drawing.Size(100, 26);
            this.txt_FoundID.TabIndex = 2;
            this.txt_FoundID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_LName
            // 
            this.txt_LName.Location = new System.Drawing.Point(98, 30);
            this.txt_LName.Name = "txt_LName";
            this.txt_LName.Size = new System.Drawing.Size(77, 26);
            this.txt_LName.TabIndex = 1;
            // 
            // txt_FName
            // 
            this.txt_FName.Location = new System.Drawing.Point(16, 30);
            this.txt_FName.Name = "txt_FName";
            this.txt_FName.Size = new System.Drawing.Size(73, 26);
            this.txt_FName.TabIndex = 0;
            // 
            // button2
            // 
            //this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(80, 4);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(5);
            this.button2.Size = new System.Drawing.Size(61, 56);
            this.button2.TabIndex = 25;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SearchIDInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rich_FilterByPrice);
            this.Controls.Add(this.btn_Inquire);
            this.Controls.Add(this.rich_InfoID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Inquire);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "SearchIDInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchIDInfo";
            this.Load += new System.EventHandler(this.SearchIDInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_Inquire;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rich_InfoID;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Button btn_Inquire;
        private System.Windows.Forms.TextBox txt_filter;
        private System.Windows.Forms.RichTextBox rich_FilterByPrice;
        private System.Windows.Forms.Button btn_filter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_cheapestRoom;
        private System.Windows.Forms.RadioButton radio_more;
        private System.Windows.Forms.RadioButton radio_less;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_FoundID;
        private System.Windows.Forms.TextBox txt_LName;
        private System.Windows.Forms.TextBox txt_FName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}