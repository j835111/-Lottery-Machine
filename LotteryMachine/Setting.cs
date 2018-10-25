using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace LotteryMachine
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label1label.Text))
            {
                MessageBox.Show("第一欄標題沒填!!");
                return;
            }
            else if (string.IsNullOrEmpty(label1content.Text))
            {
                MessageBox.Show("第一欄內容沒填!!");
                return;
            }
            else if (string.IsNullOrEmpty(label2label.Text))
            {
                MessageBox.Show("第二欄標題沒填!!");
                return;
            }
            else if (string.IsNullOrEmpty(label2content.Text))
            {
                MessageBox.Show("第二欄內容沒填!!");
                return;
            }
            else if (string.IsNullOrEmpty(label3label.Text))
            {
                MessageBox.Show("第三欄標題沒填!!");
                return;
            }
            else if (string.IsNullOrEmpty(label3content.Text))
            {
                MessageBox.Show("第三欄內容沒填!!");
                return;
            }

            DataConfig data = new DataConfig
            {
                Label1 = label1label.Text,
                Label1Content = label1content.Text,
                Label2 = label2label.Text,
                Label2Content = label2content.Text,
                Label3 = label3label.Text,
                Label3Content = label3content.Text
            };
            FileStream fs = new FileStream("Config", FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, data);
            fs.Close();
            fs.Dispose();
            data.Dispose();
            DialogResult result = MessageBox.Show("存檔成功!");
            if (result == DialogResult.OK)
                this.Close();
        }
    }
}
