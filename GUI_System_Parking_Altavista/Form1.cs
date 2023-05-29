namespace GUI_System_Parking_Altavista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            registrar_Parking rp = new registrar_Parking();
            rp.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}