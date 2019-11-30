namespace EventPlannerV1.Utilites
{
    partial class EventDetailsPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RemoveEventBtn = new System.Windows.Forms.Button();
            this.EditEventBtn = new System.Windows.Forms.Button();
            this.EventTitle = new System.Windows.Forms.TextBox();
            this.StartDtPicker = new System.Windows.Forms.DateTimePicker();
            this.RepeatStatBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RemoveEventBtn
            // 
            this.RemoveEventBtn.BackgroundImage = global::EventPlannerV1.Properties.Resources.remove;
            this.RemoveEventBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RemoveEventBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveEventBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.RemoveEventBtn.Location = new System.Drawing.Point(709, 4);
            this.RemoveEventBtn.Name = "RemoveEventBtn";
            this.RemoveEventBtn.Size = new System.Drawing.Size(31, 27);
            this.RemoveEventBtn.TabIndex = 0;
            this.RemoveEventBtn.UseVisualStyleBackColor = true;
            this.RemoveEventBtn.Click += new System.EventHandler(this.RemoveEventBtn_Click);
            // 
            // EditEventBtn
            // 
            this.EditEventBtn.BackgroundImage = global::EventPlannerV1.Properties.Resources.edit_button;
            this.EditEventBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EditEventBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditEventBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.EditEventBtn.Location = new System.Drawing.Point(672, 4);
            this.EditEventBtn.Name = "EditEventBtn";
            this.EditEventBtn.Size = new System.Drawing.Size(31, 27);
            this.EditEventBtn.TabIndex = 1;
            this.EditEventBtn.UseVisualStyleBackColor = true;
            this.EditEventBtn.Click += new System.EventHandler(this.EditEventBtn_Click);
            // 
            // EventTitle
            // 
            this.EventTitle.BackColor = System.Drawing.Color.Azure;
            this.EventTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EventTitle.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventTitle.ForeColor = System.Drawing.Color.Navy;
            this.EventTitle.Location = new System.Drawing.Point(6, 8);
            this.EventTitle.Name = "EventTitle";
            this.EventTitle.ReadOnly = true;
            this.EventTitle.Size = new System.Drawing.Size(297, 19);
            this.EventTitle.TabIndex = 2;
            this.EventTitle.Text = "Event Title";
            // 
            // StartDtPicker
            // 
            this.StartDtPicker.CalendarFont = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDtPicker.CalendarForeColor = System.Drawing.Color.Navy;
            this.StartDtPicker.CalendarMonthBackground = System.Drawing.Color.Azure;
            this.StartDtPicker.CalendarTitleForeColor = System.Drawing.Color.Navy;
            this.StartDtPicker.CustomFormat = "MMMM, dd, yyyy hh:mm:ss";
            this.StartDtPicker.Enabled = false;
            this.StartDtPicker.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDtPicker.Location = new System.Drawing.Point(309, 7);
            this.StartDtPicker.Name = "StartDtPicker";
            this.StartDtPicker.Size = new System.Drawing.Size(227, 21);
            this.StartDtPicker.TabIndex = 37;
            // 
            // RepeatStatBtn
            // 
            this.RepeatStatBtn.BackColor = System.Drawing.Color.DimGray;
            this.RepeatStatBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RepeatStatBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RepeatStatBtn.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepeatStatBtn.ForeColor = System.Drawing.Color.Azure;
            this.RepeatStatBtn.Location = new System.Drawing.Point(542, 7);
            this.RepeatStatBtn.Name = "RepeatStatBtn";
            this.RepeatStatBtn.Size = new System.Drawing.Size(52, 21);
            this.RepeatStatBtn.TabIndex = 38;
            this.RepeatStatBtn.Text = "Repeat";
            this.RepeatStatBtn.UseVisualStyleBackColor = false;
            this.RepeatStatBtn.Click += new System.EventHandler(this.RepeatStatBtn_Click);
            // 
            // EventDetailsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.RepeatStatBtn);
            this.Controls.Add(this.StartDtPicker);
            this.Controls.Add(this.EventTitle);
            this.Controls.Add(this.EditEventBtn);
            this.Controls.Add(this.RemoveEventBtn);
            this.Name = "EventDetailsPanel";
            this.Size = new System.Drawing.Size(745, 39);
            this.Load += new System.EventHandler(this.EventDetailsPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RemoveEventBtn;
        private System.Windows.Forms.Button EditEventBtn;
        private System.Windows.Forms.TextBox EventTitle;
        private System.Windows.Forms.DateTimePicker StartDtPicker;
        private System.Windows.Forms.Button RepeatStatBtn;
    }
}
