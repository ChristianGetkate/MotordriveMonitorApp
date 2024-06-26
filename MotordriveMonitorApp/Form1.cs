namespace MotordriveMonitorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
        }

        private void close_Application_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
