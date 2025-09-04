using System.IO.Ports;
namespace ConnectHandle
{
    public partial class Form1 : Form
    {
        //Khai bao cap do class de su dung duoc o nhieu noi
        SerialPort port = new SerialPort();
        public Form1()
        {
            InitializeComponent();
            initializeSerialPort();
            SetConnectionStatus(false);
        }
        private void initializeSerialPort()
        {
            // khoi tao COM
            port.PortName = "COM1";
            port.BaudRate = 115200;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.DataBits = 8;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Neu cong dang dong, mo cong
            port.Open();
            SetConnectionStatus(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            port.Close();
            SetConnectionStatus(false);
        }
        
        private void SetConnectionStatus(bool isConnected)
        {
            if (isConnected)
            {
                label1.Text = "Connected";
                label1.ForeColor = Color.Green;
            }
            else
            {
                label1.Text = "Disconnected";
                label1.ForeColor = Color.Red;
            }
    }
}
