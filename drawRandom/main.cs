using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace drawRandom
{
    public partial class main : Form
    {
        private string ver = "v3.1";

        private string nameFilePath = @"name.in";
        private string saveFilePath = @"save.out";

        private int nowDrawingClass = 0;
        private int maxClass = 10; //最多班级数

        private List<Class> Classes = new List<Class>();

        public main(int defaultClass = 0)
        {
            InitializeComponent();
            this.Text = "drawRandom " + ver;

            nowDrawingClass = defaultClass;

            if (!File.Exists(nameFilePath))
            {
                MessageBox.Show("姓名文件不存在!请先利用模板xls文件生成或检查程序是否有权限访问本目录文件!", 
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
            StreamReader nameStream = new StreamReader(nameFilePath, Encoding.Default);
            string nextLine = nameStream.ReadLine();
            if(nextLine == null)
            {
                MessageBox.Show("姓名文件内容为空!请利用模板xls文件生成后再运行!",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
            while (nextLine != null)
            {
                nextLine = nextLine.Trim();
                int classCharStart = nextLine.IndexOf('[');
                int classCharEnd = nextLine.LastIndexOf(']');
                if(classCharStart >= 0 && classCharEnd >= 0 && classCharStart != classCharEnd)
                {
                    if(Classes.Count == maxClass)
                    {
                        //达到最大班级数
                        MessageBox.Show("达到最大班级数:"+maxClass+"!后续将不会导入.最后一个导入的班级:"+Classes[Classes.Count-1].Name, 
                            "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    string className = nextLine.Substring(classCharStart + 1, classCharEnd - classCharStart - 1);
                    Classes.Add(new Class(className));
                    chooseClassCombo.Items.Add(className);
                }
                else
                {
                    //非班级标识行
                    if (Classes.Count == 0)
                    {
                        //错误，没有配套班级标识符
                        MessageBox.Show("缺少班级标识符!请检查name.in文件是否按照规则填写!", 
                            "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Environment.Exit(0);
                    }
                    int blankspacePos = nextLine.IndexOf(' ');
                    string id = nextLine.Substring(0, blankspacePos);
                    string name = nextLine.Substring(blankspacePos + 1);
                    if(!Classes[Classes.Count-1].Add(id, name)) //将学生信息写入
                    {
                        //班级满员
                        MessageBox.Show("班级"+Classes[Classes.Count].Name+"达到最大人数:"+Classes[Classes.Count-1].Max+"人,请予以纠正!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Environment.Exit(0);
                    }
                }
                nextLine = nameStream.ReadLine();
            }
            nameStream.Close();

            int savedCount = 0;
            int lastClassPos = -1;
            if (File.Exists(saveFilePath))
            {
                StreamReader saveStream = new StreamReader(saveFilePath, Encoding.UTF8);
                while (!string.IsNullOrEmpty(nextLine = saveStream.ReadLine()))
                {
                    if (savedCount > maxClass) break;
                    nextLine = nextLine.Trim();
                    int saveCharStart = nextLine.IndexOf('[');
                    int saveCharEnd = nextLine.LastIndexOf(']');
                    if (saveCharStart >= 0 && saveCharEnd >= 0 && saveCharStart != saveCharEnd)
                    {
                        //班级标识
                        string className = nextLine.Substring(saveCharStart + 1, saveCharEnd - saveCharStart - 1);
                        bool ifFindClass = false;
                        for(int i = 0;i < Classes.Count;i++)
                        {
                            if (Classes[i].Name == className)
                            {
                                lastClassPos = i;
                                ifFindClass = true;
                                break;
                            }
                        }
                        if(!ifFindClass)
                        {
                            //没有找到对应班级
                            MessageBox.Show("保存进度错误,找不到已经保存的班级,将不会继续读取抽签进度!",
                               "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                    else
                    {
                        //非班级标识行
                        if (lastClassPos == -1)
                        {
                            //错误，没有配套班级标识符
                            MessageBox.Show("保存进度错误,无配套班级标识,将不会继续读取抽签进度!",
                                "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        int saveStuNum = -1;
                        if(Int32.TryParse(nextLine, out saveStuNum))
                        {
                            //转换成功
                            Classes[lastClassPos].ImportDraw(saveStuNum);
                        }
                        else
                        {
                            //转换失败
                            MessageBox.Show("保存进度错误,有非数字字符,将不会继续读取抽签进度!",
                                "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Classes[lastClassPos].Clear();
                            break;
                        }
                    }
                }
                saveStream.Close();
            }
        }

        public void Refresh(string drawLabelText = null, string drawNumLabel = null)
        {
            nowDrawNameLabel.Text = drawLabelText;
            nowDrawNumLabel.Text = drawNumLabel;
            totalPersonLabel.Text = Classes[nowDrawingClass].Count + "";
            drawedPersonLabel.Text = Classes[nowDrawingClass].DrawCount + "";
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("drawRandom " + ver + "\nPowered By C#\n2020 BYTEGOING\nGithub: https://www.github.com/BYTEGOING", 
                "关于", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ChooseClassCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nowDrawingClass == chooseClassCombo.SelectedIndex) return;
            nowDrawingClass = chooseClassCombo.SelectedIndex;
            Refresh("等待抽取");
            MessageBox.Show("切换到班级[" + chooseClassCombo.SelectedItem + "]成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //记得保存
            Save();
            DialogResult result = MessageBox.Show("确定要退出吗？", "drawRandom " + ver, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Classes[nowDrawingClass].Clear();
            Refresh("清除完毕");
        }

        private void DrawBtn_Click(object sender, EventArgs e)
        {
            Student nowDraw = Classes[nowDrawingClass].Draw();
            if(nowDraw == null)
            {
                //抽完了
                MessageBox.Show("全部抽取完毕!将清除抽签记录...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearBtn.PerformClick();
                return;
            }
            Refresh(nowDraw.Name, nowDraw.ID);
        }

        private void Save()
        {
            StreamWriter sw1 = new StreamWriter(saveFilePath);
            string finalOutput = "";
            for(int i = 0;i < Classes.Count;i++)
            {
                finalOutput += Classes[i].Export();
            }
            sw1.Write(finalOutput);
            sw1.Close();
            Refresh("保存完成");
        }

        private void FixBtn_Click(object sender, EventArgs e)
        {
            if (this.TopMost)
            {
                FixBtn.Image = Properties.Resources.fix;
                toolTip.SetToolTip(this.FixBtn, "不保持在最前方(非PPT模式)");
            }
            else
            {
                FixBtn.Image = Properties.Resources._fixed;
                toolTip.SetToolTip(this.FixBtn, "保持在最前方(PPT模式)");
            }
            this.TopMost = !this.TopMost;
        }

        private void HideBtn_Click(object sender, EventArgs e)
        {
            Save();
            this.Hide();
            HideFrm HideForm = new HideFrm(nowDrawingClass);
            HideForm.Show(this);
            HideForm.Location = new Point(this.Location.X, this.Location.Y); //在窗体位置打开缩小栏
            HideForm.Focus();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            chooseClassCombo.SelectedIndex = nowDrawingClass; //设置好班级
            Refresh("等待抽取");
            //设置悬停说明
            toolTip.IsBalloon = true;
            toolTip.SetToolTip(this.hideBtn, "点我最小化");
            //默认开启窗口前置，一定要比设置悬停说明晚，因为涉及toolTip
            FixBtn.PerformClick();
        }
    }
    class Student
    {
        private string id;
        private string name;
        private bool draw = false;

        public Student(string ID, string NAME)
        {
            id = ID;
            name = NAME;
        }

        public string ID
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

        }
        public bool Draw
        {
            get
            {
                return draw;
            }
            set
            {
                draw = value;
            }
        }
    }
    class Class
    {
        private const int max = 150; //最大学生个数
        private int count = 0; //现在有几个学生
        private int drawCount = 0; //已经抽完多少了
        private Student[] StudentList = new Student[max];
        private string name;

        public int Max
        {
            get
            {
                return max;
            }
        } //仅读取

        public int Count
        {
            get
            {
                return count;
            }
        } //仅读取

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int DrawCount
        {
            get
            {
                return drawCount;
            }
        }

        public Class(string name)
        {
            this.Name = name;
        }
        public bool Add(string id, string name)
        {
            if (count == max) return false; //若超出最大值则无法加入
            //添加学生入班
            StudentList[count] = new Student(id, name);
            count++;
            return true;
        }
        public Student Draw()
        {
            //随机抽签,返回值为被抽到的学生信息
            if (drawCount == Count) return null;
            int num;
            do
            {
                num = new Random(Guid.NewGuid().GetHashCode()).Next(0, count);
            } while (StudentList[num].Draw);
            StudentList[num].Draw = true;
            drawCount++;
            return GetInfo(num);
        }
        public Student GetInfo(int num)
        {
            //由次序获取学生信息
            return this.StudentList[num];
        }
        public void ImportDraw(string id)
        {
            //由学号导入已经抽过的学生信息
            for(int i = 0;i < Count;i++)
            {
                if (StudentList[i].ID == id) StudentList[i].Draw = true;
            }
            drawCount++;
        }
        public void ImportDraw(int num)
        {
            //由次序导入已经抽过的学生信息
            if (num >= Count) return; //意外情况，防止数组越界
            StudentList[num].Draw = true;
            drawCount++;
        }
        public void Clear()
        {
            //清除所有学生的抽签状态
            for(int i = 0;i < Count;i++)
            {
                StudentList[i].Draw = false;
            }
            drawCount = 0;
        }
        public string Export()
        {
            string rtn = "[" + Name + "]\r\n";
            if (drawCount == 0) return rtn;
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    if (StudentList[i].Draw)
                    {
                        rtn += i;
                        rtn += "\r\n";
                    }
                }
                return rtn;
            }
        }
    }
}
