namespace MotordriveMonitorApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ShowNewForm = new Button();
            close_Application = new Button();
            SuspendLayout();
            // 
            // ShowNewForm
            // 
            ShowNewForm.Location = new Point(238, 127);
            ShowNewForm.Name = "ShowNewForm";
            ShowNewForm.Size = new Size(125, 23);
            ShowNewForm.TabIndex = 0;
            ShowNewForm.Text = "Show New Form";
            ShowNewForm.UseVisualStyleBackColor = true;
            ShowNewForm.Click += button1_Click;
            // 
            // close_Application
            // 
            close_Application.Location = new Point(238, 176);
            close_Application.Name = "close_Application";
            close_Application.Size = new Size(125, 23);
            close_Application.TabIndex = 1;
            close_Application.Text = "Close app";
            close_Application.UseVisualStyleBackColor = true;
            close_Application.Click += close_Application_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(close_Application);
            Controls.Add(ShowNewForm);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button ShowNewForm;
        private Button close_Application;
    }
}
