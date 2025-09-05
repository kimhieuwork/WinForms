using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QRCoder.QRCodeGenerator;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QRGenerator
{
    public partial class Form2 : Form
    {
        Form1 _form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            _form1.PixelPerModule = (int)numericUpDown1.Value;
            //save
            _form1.Show();
            this.Close();

        }
    }
}
