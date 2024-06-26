namespace MotordriveMonitorApp
{
    partial class MotordriveMonitorMainForm
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
            cmbAmsNetId = new ComboBox();
            nudPort = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            btnConnect = new Button();
            ((System.ComponentModel.ISupportInitialize)nudPort).BeginInit();
            SuspendLayout();
            // 
            // cmbAmsNetId
            // 
            cmbAmsNetId.FormattingEnabled = true;
            cmbAmsNetId.Location = new Point(151, 81);
            cmbAmsNetId.Margin = new Padding(3, 4, 3, 4);
            cmbAmsNetId.Name = "cmbAmsNetId";
            cmbAmsNetId.Size = new Size(245, 28);
            cmbAmsNetId.TabIndex = 0;
            cmbAmsNetId.SelectedIndexChanged += cmbAmsNetId_SelectedIndexChanged;
            // 
            // nudPort
            // 
            nudPort.Location = new Point(151, 136);
            nudPort.Margin = new Padding(3, 4, 3, 4);
            nudPort.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudPort.Name = "nudPort";
            nudPort.Size = new Size(137, 27);
            nudPort.TabIndex = 1;
            nudPort.Value = new decimal(new int[] { 801, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 85);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 2;
            label1.Text = "AMS Net ID";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 139);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 3;
            label2.Text = "ADS Port";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(514, 119);
            btnConnect.Margin = new Padding(3, 4, 3, 4);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(115, 48);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // MotordriveMonitorMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 288);
            Controls.Add(btnConnect);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nudPort);
            Controls.Add(cmbAmsNetId);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MotordriveMonitorMainForm";
            Text = "MotordriveMonitorMainForm";
            Load += MotordriveMonitorMainForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudPort).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbAmsNetId;
        private NumericUpDown nudPort;
        private Label label1;
        private Label label2;
        private Button btnConnect;
    }
}