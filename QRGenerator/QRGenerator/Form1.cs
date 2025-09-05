using QRCoder;
using static QRCoder.QRCodeGenerator;
namespace QRGenerator
{
    public partial class Form1 : Form
    {
        public int PixelPerModule { get; set; } = 20; // mac dinh

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please text something!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                QRCodeGenerator.ECCLevel eccLevel;
                eccLevel = GetAutoECC(textBox1.Text);
                // Generate QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(textBox1.Text, eccLevel, true, true, EciMode.Default, -1);
                QRCode qrCode = new QRCode(qrCodeData);

                Bitmap qrCodeImage = qrCode.GetGraphic(PixelPerModule); // do phan giai 20

                // Hien thi len picture boxx
                pictureBox1.Image = qrCodeImage;
            }
        }
        // Ham chon ECC tu dong
        private QRCodeGenerator.ECCLevel GetAutoECC(string text)
        {
            int length = text.Length;

            if (length < 20)
                return QRCodeGenerator.ECCLevel.H;  // ngan -> sua loi cao
            else if (length < 100)
                return QRCodeGenerator.ECCLevel.Q;  // trung binh
            else if (length < 200)
                return QRCodeGenerator.ECCLevel.M;  // dai hon
            else
                return QRCodeGenerator.ECCLevel.L;  // rat dai
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please generate a QR code first!",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save QR Code";
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.FileName = "QRCode.png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lay dinh dang file theo extension
                    System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                    if (saveFileDialog.FileName.EndsWith(".jpg"))
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                    else if (saveFileDialog.FileName.EndsWith(".bmp"))
                        format = System.Drawing.Imaging.ImageFormat.Bmp;

                    pictureBox1.Image.Save(saveFileDialog.FileName, format);

                    MessageBox.Show("QR Code saved successfully!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
