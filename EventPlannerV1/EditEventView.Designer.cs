namespace EventPlannerV1
{
    partial class EditEventView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.repeatEventDropdown = new System.Windows.Forms.ComboBox();
            this.taskRadBtn = new System.Windows.Forms.RadioButton();
            this.appointRadBtn = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.endDtPicker = new System.Windows.Forms.DateTimePicker();
            this.startDtPicker = new System.Windows.Forms.DateTimePicker();
            this.NoteLbl = new System.Windows.Forms.Label();
            this.eventNoteTxt = new System.Windows.Forms.TextBox();
            this.titleTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.editEventBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 54);
            this.panel1.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(338, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Edit Event";
            // 
            // repeatEventDropdown
            // 
            this.repeatEventDropdown.BackColor = System.Drawing.Color.Azure;
            this.repeatEventDropdown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatEventDropdown.ForeColor = System.Drawing.Color.RoyalBlue;
            this.repeatEventDropdown.FormattingEnabled = true;
            this.repeatEventDropdown.Items.AddRange(new object[] {
            "Repeat",
            "Don\'t Repeat"});
            this.repeatEventDropdown.Location = new System.Drawing.Point(137, 181);
            this.repeatEventDropdown.MaxDropDownItems = 2;
            this.repeatEventDropdown.Name = "repeatEventDropdown";
            this.repeatEventDropdown.Size = new System.Drawing.Size(319, 24);
            this.repeatEventDropdown.TabIndex = 57;
            this.repeatEventDropdown.Text = "Repeat";
            // 
            // taskRadBtn
            // 
            this.taskRadBtn.AutoSize = true;
            this.taskRadBtn.Checked = true;
            this.taskRadBtn.ForeColor = System.Drawing.Color.Navy;
            this.taskRadBtn.Location = new System.Drawing.Point(137, 231);
            this.taskRadBtn.Name = "taskRadBtn";
            this.taskRadBtn.Size = new System.Drawing.Size(49, 17);
            this.taskRadBtn.TabIndex = 56;
            this.taskRadBtn.TabStop = true;
            this.taskRadBtn.Text = "Task";
            this.taskRadBtn.UseVisualStyleBackColor = true;
            // 
            // appointRadBtn
            // 
            this.appointRadBtn.AutoSize = true;
            this.appointRadBtn.ForeColor = System.Drawing.Color.Navy;
            this.appointRadBtn.Location = new System.Drawing.Point(271, 231);
            this.appointRadBtn.Name = "appointRadBtn";
            this.appointRadBtn.Size = new System.Drawing.Size(84, 17);
            this.appointRadBtn.TabIndex = 55;
            this.appointRadBtn.Text = "Appointment";
            this.appointRadBtn.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(482, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 18);
            this.label8.TabIndex = 54;
            this.label8.Text = "Ends At";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(9, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 18);
            this.label7.TabIndex = 53;
            this.label7.Text = "Starts At";
            // 
            // endDtPicker
            // 
            this.endDtPicker.CalendarForeColor = System.Drawing.Color.Navy;
            this.endDtPicker.CalendarMonthBackground = System.Drawing.Color.Azure;
            this.endDtPicker.CalendarTitleForeColor = System.Drawing.Color.Navy;
            this.endDtPicker.CustomFormat = "MMMM, dd, yyyy hh:mm:ss";
            this.endDtPicker.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDtPicker.Location = new System.Drawing.Point(572, 80);
            this.endDtPicker.Name = "endDtPicker";
            this.endDtPicker.Size = new System.Drawing.Size(216, 21);
            this.endDtPicker.TabIndex = 52;
            // 
            // startDtPicker
            // 
            this.startDtPicker.CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDtPicker.CalendarForeColor = System.Drawing.Color.Navy;
            this.startDtPicker.CalendarMonthBackground = System.Drawing.Color.Azure;
            this.startDtPicker.CalendarTitleForeColor = System.Drawing.Color.Navy;
            this.startDtPicker.CustomFormat = "MMMM, dd, yyyy hh:mm:ss";
            this.startDtPicker.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDtPicker.Location = new System.Drawing.Point(137, 83);
            this.startDtPicker.Name = "startDtPicker";
            this.startDtPicker.Size = new System.Drawing.Size(218, 21);
            this.startDtPicker.TabIndex = 51;
            // 
            // NoteLbl
            // 
            this.NoteLbl.AutoSize = true;
            this.NoteLbl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteLbl.ForeColor = System.Drawing.Color.Navy;
            this.NoteLbl.Location = new System.Drawing.Point(12, 274);
            this.NoteLbl.Name = "NoteLbl";
            this.NoteLbl.Size = new System.Drawing.Size(47, 18);
            this.NoteLbl.TabIndex = 50;
            this.NoteLbl.Text = "Note";
            // 
            // eventNoteTxt
            // 
            this.eventNoteTxt.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventNoteTxt.ForeColor = System.Drawing.Color.RoyalBlue;
            this.eventNoteTxt.Location = new System.Drawing.Point(137, 274);
            this.eventNoteTxt.Multiline = true;
            this.eventNoteTxt.Name = "eventNoteTxt";
            this.eventNoteTxt.Size = new System.Drawing.Size(319, 94);
            this.eventNoteTxt.TabIndex = 49;
            // 
            // titleTxt
            // 
            this.titleTxt.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTxt.ForeColor = System.Drawing.Color.RoyalBlue;
            this.titleTxt.Location = new System.Drawing.Point(137, 132);
            this.titleTxt.Name = "titleTxt";
            this.titleTxt.Size = new System.Drawing.Size(319, 23);
            this.titleTxt.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(12, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 47;
            this.label4.Text = "Event Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(12, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 18);
            this.label3.TabIndex = 46;
            this.label3.Text = "Repeat Event";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(12, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 18);
            this.label2.TabIndex = 45;
            this.label2.Text = "Event Title";
            // 
            // editEventBtn
            // 
            this.editEventBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editEventBtn.AutoSize = true;
            this.editEventBtn.BackColor = System.Drawing.Color.Azure;
            this.editEventBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editEventBtn.FlatAppearance.BorderSize = 2;
            this.editEventBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editEventBtn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editEventBtn.ForeColor = System.Drawing.Color.Navy;
            this.editEventBtn.Location = new System.Drawing.Point(343, 414);
            this.editEventBtn.Name = "editEventBtn";
            this.editEventBtn.Size = new System.Drawing.Size(155, 39);
            this.editEventBtn.TabIndex = 44;
            this.editEventBtn.Text = "Edit Event";
            this.editEventBtn.UseVisualStyleBackColor = false;
            // 
            // EditEventView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.repeatEventDropdown);
            this.Controls.Add(this.taskRadBtn);
            this.Controls.Add(this.appointRadBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.endDtPicker);
            this.Controls.Add(this.startDtPicker);
            this.Controls.Add(this.NoteLbl);
            this.Controls.Add(this.eventNoteTxt);
            this.Controls.Add(this.titleTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.editEventBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditEventView";
            this.Text = "EditEventView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox repeatEventDropdown;
        private System.Windows.Forms.RadioButton taskRadBtn;
        private System.Windows.Forms.RadioButton appointRadBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker endDtPicker;
        private System.Windows.Forms.DateTimePicker startDtPicker;
        private System.Windows.Forms.Label NoteLbl;
        private System.Windows.Forms.TextBox eventNoteTxt;
        private System.Windows.Forms.TextBox titleTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button editEventBtn;
    }
}