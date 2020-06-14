using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace drawRandom
{
    public partial class HideFrm : Form
    {
        int defaultclass = 0;

        public HideFrm(int defaultClass)
        {
            InitializeComponent();
            defaultclass = defaultClass;
        }

        private bool isMove = false; //是否拖动窗体
        private Point point; //记录位置

        private void HideFrm_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            point = e.Location; //记录位置
        }

        private void HideFrm_MouseMove(object sender, MouseEventArgs e)
        {
            //是否移动窗体
            if (isMove)
            {
                //记录鼠标移动后的值
                Point p = e.Location;
                //计算鼠标按下和移动后的距离
                int x = p.X - point.X;
                int y = p.Y - point.Y;
                //窗体的位置
                this.Location = new Point(this.Location.X + x, this.Location.Y + y);
            }
        }

        private void HideFrm_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false; //不允许再移动
        }

        private void HideFrm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //双击回到主界面
            this.Hide();
            main MainFrm = new main(defaultclass);
            MainFrm.Show(this);
            int x = this.Location.X;
            int y = this.Location.Y;
            int totalX = Screen.PrimaryScreen.Bounds.Width;
            int totalY = Screen.PrimaryScreen.Bounds.Height;
            //判断是否超出边界，超出了的话就重置一下
            if (x + MainFrm.Size.Width > totalX) x = totalX - MainFrm.Size.Width;
            if (y + MainFrm.Size.Height > totalY) y = totalY - MainFrm.Size.Height;
            MainFrm.Location = new Point(x, y); //当前位置出现窗口
            MainFrm.Focus();
        }
    }
}
