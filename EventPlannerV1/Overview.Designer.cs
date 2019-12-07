using System;

namespace EventPlannerV1
{
    partial class Overview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Overview));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.contactsBtn = new System.Windows.Forms.Button();
            this.showPredictBtn = new System.Windows.Forms.Button();
            this.addEventBtn = new System.Windows.Forms.Button();
            this.startDtPicker = new System.Windows.Forms.DateTimePicker();
            this.endDtPicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.profileBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(26)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 54);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(26)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "OVERVIEW";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(26)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.profileBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(768, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(201, 54);
            this.panel3.TabIndex = 0;
            // 
            // contactsBtn
            // 
            this.contactsBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.contactsBtn.AutoSize = true;
            this.contactsBtn.BackColor = System.Drawing.Color.Azure;
            this.contactsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.contactsBtn.FlatAppearance.BorderSize = 2;
            this.contactsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.contactsBtn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(26)))), ((int)(((byte)(64)))));
            this.contactsBtn.Location = new System.Drawing.Point(802, 269);
            this.contactsBtn.Margin = new System.Windows.Forms.Padding(10);
            this.contactsBtn.Name = "contactsBtn";
            this.contactsBtn.Size = new System.Drawing.Size(155, 37);
            this.contactsBtn.TabIndex = 1;
            this.contactsBtn.Text = "Contacts";
            this.contactsBtn.UseVisualStyleBackColor = false;
            this.contactsBtn.Click += new System.EventHandler(this.contactsBtn_Click);
            // 
            // showPredictBtn
            // 
            this.showPredictBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.showPredictBtn.AutoSize = true;
            this.showPredictBtn.BackColor = System.Drawing.Color.Azure;
            this.showPredictBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showPredictBtn.FlatAppearance.BorderSize = 2;
            this.showPredictBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPredictBtn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPredictBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(26)))), ((int)(((byte)(64)))));
            this.showPredictBtn.Location = new System.Drawing.Point(802, 426);
            this.showPredictBtn.Name = "showPredictBtn";
            this.showPredictBtn.Size = new System.Drawing.Size(155, 39);
            this.showPredictBtn.TabIndex = 3;
            this.showPredictBtn.Text = "Monthly Prediction";
            this.showPredictBtn.UseVisualStyleBackColor = false;
            // 
            // addEventBtn
            // 
            this.addEventBtn.AutoSize = true;
            this.addEventBtn.BackColor = System.Drawing.Color.Azure;
            this.addEventBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addEventBtn.FlatAppearance.BorderSize = 2;
            this.addEventBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addEventBtn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEventBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(26)))), ((int)(((byte)(64)))));
            this.addEventBtn.Location = new System.Drawing.Point(802, 124);
            this.addEventBtn.Name = "addEventBtn";
            this.addEventBtn.Size = new System.Drawing.Size(155, 38);
            this.addEventBtn.TabIndex = 4;
            this.addEventBtn.Text = "Add Event";
            this.addEventBtn.UseVisualStyleBackColor = false;
            this.addEventBtn.Click += new System.EventHandler(this.addEventBtn_Click);
            // 
            // startDtPicker
            // 
            this.startDtPicker.CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDtPicker.CalendarForeColor = System.Drawing.Color.Navy;
            this.startDtPicker.CalendarMonthBackground = System.Drawing.Color.Azure;
            this.startDtPicker.CalendarTitleForeColor = System.Drawing.Color.Navy;
            this.startDtPicker.CustomFormat = "MMMM, dd, yyyy HH:mm:ss";
            this.startDtPicker.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDtPicker.Location = new System.Drawing.Point(171, 75);
            this.startDtPicker.Name = "startDtPicker";
            this.startDtPicker.Size = new System.Drawing.Size(218, 21);
            this.startDtPicker.TabIndex = 6;
            this.startDtPicker.Value = new System.DateTime(2019, 11, 3, 8, 26, 31, 679);
            this.startDtPicker.ValueChanged += new System.EventHandler(this.startDtPicker_ValueChanged);
            // 
            // endDtPicker
            // 
            this.endDtPicker.CalendarForeColor = System.Drawing.Color.Navy;
            this.endDtPicker.CalendarMonthBackground = System.Drawing.Color.Azure;
            this.endDtPicker.CalendarTitleForeColor = System.Drawing.Color.Navy;
            this.endDtPicker.CustomFormat = "MMMM, dd, yyyy HH:mm:ss";
            this.endDtPicker.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDtPicker.Location = new System.Drawing.Point(566, 75);
            this.endDtPicker.Name = "endDtPicker";
            this.endDtPicker.Size = new System.Drawing.Size(216, 21);
            this.endDtPicker.TabIndex = 7;
            this.endDtPicker.Value = new System.DateTime(2020, 1, 3, 8, 26, 31, 682);
            this.endDtPicker.ValueChanged += new System.EventHandler(this.endDtPicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(26)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Start Date/Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(26)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(418, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "End Date/Time";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Azure;
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(17, 124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 430);
            this.panel2.TabIndex = 19;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(765, 430);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // profileBtn
            // 
            this.profileBtn.AutoSize = true;
            this.profileBtn.BackColor = System.Drawing.Color.Transparent;
            this.profileBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("profileBtn.BackgroundImage")));
            this.profileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.profileBtn.FlatAppearance.BorderSize = 2;
            this.profileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileBtn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileBtn.ForeColor = System.Drawing.Color.Navy;
            this.profileBtn.Location = new System.Drawing.Point(126, 0);
            this.profileBtn.Name = "profileBtn";
            this.profileBtn.Size = new System.Drawing.Size(63, 55);
            this.profileBtn.TabIndex = 0;
            this.profileBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.profileBtn.UseVisualStyleBackColor = false;
            this.profileBtn.Click += new System.EventHandler(this.profileBtn_Click);
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(969, 566);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endDtPicker);
            this.Controls.Add(this.startDtPicker);
            this.Controls.Add(this.showPredictBtn);
            this.Controls.Add(this.contactsBtn);
            this.Controls.Add(this.addEventBtn);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Overview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Overview";
            this.Activated += new System.EventHandler(this.Overview_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Overview_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button profileBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button contactsBtn;
        private System.Windows.Forms.Button addEventBtn;
        private System.Windows.Forms.Button showPredictBtn;
        private System.Windows.Forms.DateTimePicker startDtPicker;
        private System.Windows.Forms.DateTimePicker endDtPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}