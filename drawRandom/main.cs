using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace drawRandom
{
    public partial class main : Form
    {
        private string ver = "v2.0beta";

        private string nameFilePath = @"name.in";
        private string saveFilePath = @"save.out";

        private string[] name = new string[101];
        private bool[] drawed = new bool  [101];

        private int totalNum = 1;
        private int totalSave= 0;

        private int randomNum()
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next(1, totalNum);
        }

        private void clean()
        {
            draw.Text = "清理中...";
            for (int i = 0; i <= 100; i++) drawed[i] = false;
            totalSave = 0;
            drawedLabel.Text = "0";
            draw.Text = "清理完毕";
            //MessageBox.Show("清理完毕","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void save()
        {
            int saveItem = 0;
            StreamWriter sw1 = new StreamWriter(saveFilePath);
            for (int i = 1; i <= totalNum; i++)
            {
                if(drawed[i])
                {
                    saveItem++;
                    sw1.WriteLine(i);
                }
            }
            sw1.Close();
            //MessageBox.Show("保存完毕,共保存"+saveItem+"人", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            draw.Text = "保存" + saveItem + "人";
        }

        public main()
        {
            InitializeComponent();
            this.Text = "drawRandom " + ver;
            for (int i = 0; i <= 100; i++) drawed[i] = false;
            if (!File.Exists(nameFilePath))
            {
                MessageBox.Show("姓名文件不存在!请检查目录下是否存在name.in文件或检查程序是否有权限访问本目录文件!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            StreamReader nameStream = new StreamReader(nameFilePath, Encoding.Default);
            string nextLine;
            while( (nextLine = nameStream.ReadLine()) != null)
            {
                name[totalNum] = nextLine;
                totalNum++;
            }
            nameStream.Close();
            if(totalNum == 1)
            {
                MessageBox.Show("姓名文件为空!请编辑name.in来添加姓名,每行一个", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            MessageBox.Show("导入成功!共导入" + (totalNum - 1) + "人", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            totalLabel.Text = (totalNum - 1) + "";

            int nextDrawed = 0;
            string tips = "[ ";
            if (File.Exists(saveFilePath))
            {
                StreamReader saveStream = new StreamReader(saveFilePath, Encoding.Default);
                while (!string.IsNullOrEmpty(nextLine = saveStream.ReadLine()))
                {
                    try
                    {
                        nextDrawed = int.Parse(nextLine);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("进度文件损坏,内有非数字字符.清空进度...", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        totalSave = 0;
                        clean();
                        break;
                    }
                    drawed[nextDrawed] = true;
                    totalSave++;
                    tips += name[nextDrawed];
                    tips += " ";
                }
                saveStream.Close();
            }
            tips += "]";
            if (totalSave > 0)
            {
                MessageBox.Show("已经抽取" + totalSave + "人，分别为：" + tips, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                draw.Text = nextDrawed + name[nextDrawed];
            }
            else
            {
                MessageBox.Show("抽签记录为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                draw.Text = "等待抽签";
            }
            drawedLabel.Text = totalSave + "";

        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("drawRandom "+ver+"\nPowered By C#\n2019 BYTEGOING\nGithub: https://www.github.com/BYTEGOING", "关于", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            save();
            DialogResult result = MessageBox.Show("确定要退出吗？", "drawRandom "+ver, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            draw.Text = "正在抽签";
            int nextNum = randomNum();
            while(drawed[nextNum])
            {
                nextNum = randomNum();
            }
            drawed[nextNum] = true;
            //draw.Text = nextNum+name[nextNum];
            draw.Text = name[nextNum];
            totalSave++;
            drawedLabel.Text = totalSave + "";
            if (totalSave == totalNum - 1)
            {
                draw.Text = "抽取完毕";
                MessageBox.Show("已经将所有人抽完,清理中...","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clean();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clean();
        }
    }
}
