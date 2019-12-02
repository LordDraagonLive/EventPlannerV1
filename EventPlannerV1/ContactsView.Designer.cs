namespace EventPlannerV1
{
    partial class ContactsView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contactsBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.updateContactBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.contactNoteTxt = new System.Windows.Forms.TextBox();
            this.contactTelTxt = new System.Windows.Forms.TextBox();
            this.contactAddressTxt = new System.Windows.Forms.TextBox();
            this.contactEmailTxt = new System.Windows.Forms.TextBox();
            this.contactNameTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contactsDtGrd = new System.Windows.Forms.DataGridView();
            this.backBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactsDtGrd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(370, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "CONTACTS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.backBtn);
            this.panel1.Controls.Add(this.contactsBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 46);
            this.panel1.TabIndex = 5;
            // 
            // contactsBtn
            // 
            this.contactsBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.contactsBtn.AutoSize = true;
            this.contactsBtn.BackColor = System.Drawing.Color.Azure;
            this.contactsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.contactsBtn.FlatAppearance.BorderSize = 2;
            this.contactsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.contactsBtn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactsBtn.ForeColor = System.Drawing.Color.Navy;
            this.contactsBtn.Location = new System.Drawing.Point(776, 9);
            this.contactsBtn.Name = "contactsBtn";
            this.contactsBtn.Size = new System.Drawing.Size(101, 29);
            this.contactsBtn.TabIndex = 8;
            this.contactsBtn.Text = "Add Contact";
            this.contactsBtn.UseVisualStyleBackColor = false;
            this.contactsBtn.Click += new System.EventHandler(this.contactsBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Snow;
            this.panel2.Controls.Add(this.updateContactBtn);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.contactNoteTxt);
            this.panel2.Controls.Add(this.contactTelTxt);
            this.panel2.Controls.Add(this.contactAddressTxt);
            this.panel2.Controls.Add(this.contactEmailTxt);
            this.panel2.Controls.Add(this.contactNameTxt);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(528, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 472);
            this.panel2.TabIndex = 7;
            // 
            // updateContactBtn
            // 
            this.updateContactBtn.Enabled = false;
            this.updateContactBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateContactBtn.ForeColor = System.Drawing.Color.Navy;
            this.updateContactBtn.Location = new System.Drawing.Point(84, 406);
            this.updateContactBtn.Name = "updateContactBtn";
            this.updateContactBtn.Size = new System.Drawing.Size(226, 41);
            this.updateContactBtn.TabIndex = 26;
            this.updateContactBtn.Text = "Update";
            this.updateContactBtn.UseVisualStyleBackColor = true;
            this.updateContactBtn.Click += new System.EventHandler(this.updateContactBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(7, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 18);
            this.label6.TabIndex = 25;
            this.label6.Text = "Note";
            // 
            // contactNoteTxt
            // 
            this.contactNoteTxt.Enabled = false;
            this.contactNoteTxt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactNoteTxt.ForeColor = System.Drawing.Color.RoyalBlue;
            this.contactNoteTxt.Location = new System.Drawing.Point(30, 301);
            this.contactNoteTxt.Multiline = true;
            this.contactNoteTxt.Name = "contactNoteTxt";
            this.contactNoteTxt.Size = new System.Drawing.Size(319, 81);
            this.contactNoteTxt.TabIndex = 24;
            // 
            // contactTelTxt
            // 
            this.contactTelTxt.Enabled = false;
            this.contactTelTxt.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactTelTxt.ForeColor = System.Drawing.Color.RoyalBlue;
            this.contactTelTxt.Location = new System.Drawing.Point(30, 240);
            this.contactTelTxt.Name = "contactTelTxt";
            this.contactTelTxt.Size = new System.Drawing.Size(319, 26);
            this.contactTelTxt.TabIndex = 23;
            // 
            // contactAddressTxt
            // 
            this.contactAddressTxt.Enabled = false;
            this.contactAddressTxt.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactAddressTxt.ForeColor = System.Drawing.Color.RoyalBlue;
            this.contactAddressTxt.Location = new System.Drawing.Point(30, 183);
            this.contactAddressTxt.Name = "contactAddressTxt";
            this.contactAddressTxt.Size = new System.Drawing.Size(319, 26);
            this.contactAddressTxt.TabIndex = 22;
            // 
            // contactEmailTxt
            // 
            this.contactEmailTxt.Enabled = false;
            this.contactEmailTxt.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactEmailTxt.ForeColor = System.Drawing.Color.RoyalBlue;
            this.contactEmailTxt.Location = new System.Drawing.Point(30, 123);
            this.contactEmailTxt.Name = "contactEmailTxt";
            this.contactEmailTxt.Size = new System.Drawing.Size(319, 26);
            this.contactEmailTxt.TabIndex = 21;
            // 
            // contactNameTxt
            // 
            this.contactNameTxt.Enabled = false;
            this.contactNameTxt.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactNameTxt.ForeColor = System.Drawing.Color.RoyalBlue;
            this.contactNameTxt.Location = new System.Drawing.Point(30, 67);
            this.contactNameTxt.Name = "contactNameTxt";
            this.contactNameTxt.Size = new System.Drawing.Size(319, 26);
            this.contactNameTxt.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(7, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = "Contact Tel.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(7, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "Contact Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(7, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Contact Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Contact Name";
            // 
            // contactsDtGrd
            // 
            this.contactsDtGrd.AllowUserToAddRows = false;
            this.contactsDtGrd.AllowUserToDeleteRows = false;
            this.contactsDtGrd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contactsDtGrd.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.contactsDtGrd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.contactsDtGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contactsDtGrd.Location = new System.Drawing.Point(12, 82);
            this.contactsDtGrd.Name = "contactsDtGrd";
            this.contactsDtGrd.ReadOnly = true;
            this.contactsDtGrd.Size = new System.Drawing.Size(480, 424);
            this.contactsDtGrd.TabIndex = 8;
            this.contactsDtGrd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.contactsDtGrd_CellClick);
            // 
            // backBtn
            // 
            this.backBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.backBtn.AutoSize = true;
            this.backBtn.BackColor = System.Drawing.Color.Azure;
            this.backBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.backBtn.FlatAppearance.BorderSize = 2;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backBtn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.Navy;
            this.backBtn.Location = new System.Drawing.Point(12, 9);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(101, 29);
            this.backBtn.TabIndex = 9;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // ContactsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 518);
            this.Controls.Add(this.contactsDtGrd);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "ContactsView";
            this.Text = "ContactsView";
            this.Activated += new System.EventHandler(this.ContactsView_Activated);
            this.Load += new System.EventHandler(this.ContactsView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactsDtGrd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button contactsBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView contactsDtGrd;
        private System.Windows.Forms.TextBox contactTelTxt;
        private System.Windows.Forms.TextBox contactAddressTxt;
        private System.Windows.Forms.TextBox contactEmailTxt;
        private System.Windows.Forms.TextBox contactNameTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox contactNoteTxt;
        private System.Windows.Forms.Button updateContactBtn;
        private System.Windows.Forms.Button backBtn;
    }
}