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
            this.editEventBtn.Click += new System.EventHandler(this.editEventBtn_Click);
            // 
            // EditEventView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.editEventBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditEventView";
            this.Text = "EditEventView";
            this.Load += new System.EventHandler(this.EditEventView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editEventBtn;
    }
}