using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace LotteryMachine
{
    public partial class Form1 : Form
    {
        DataConfig data;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data = DeserializeBinary();
            if (!File.Exists("Config"))
                return;
            label1.Text = data.Label1;
            label2.Text = data.Label2;
            label3.Text = data.Label3;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random ran = new Random(Guid.NewGuid().GetHashCode());
            label4.Text = data.Label1Content.Split('，')[ran.Next(data.Label1Content.Split(',').Length) + 1];
            label5.Text = data.Label2Content.Split('，')[ran.Next(data.Label2Content.Split(',').Length) + 1];
            label6.Text = data.Label3Content.Split('，')[ran.Next(data.Label3Content.Split(',').Length) + 1];
        }

        private DataConfig DeserializeBinary()
        {
            if (File.Exists("Config"))
            {
                FileStream fileStream = new FileStream("Config", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                DataConfig data = (DataConfig)formatter.Deserialize(fileStream);
                fileStream.Close();
                fileStream.Dispose();
                return data;
            }
            else
            {
                DialogResult result = MessageBox.Show("抽獎內容尚未設定!!");
                if (result == DialogResult.OK)
                {
                    Setting setting = new Setting
                    {
                        Visible = true
                    };
                }
                return null;
            }
        }
    }
}
