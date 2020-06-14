namespace drawRandom
{
    partial class main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.drawBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalPersonLabel = new System.Windows.Forms.Label();
            this.drawedPersonLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nowDrawNameLabel = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nowDrawNumLabel = new System.Windows.Forms.Label();
            this.chooseClassCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.FixBtn = new System.Windows.Forms.Button();
            this.hideBtn = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // drawBtn
            // 
            this.drawBtn.Font = new System.Drawing.Font("黑体", 40F);
            this.drawBtn.Location = new System.Drawing.Point(23, 205);
            this.drawBtn.Margin = new System.Windows.Forms.Padding(4);
            this.drawBtn.Name = "drawBtn";
            this.drawBtn.Size = new System.Drawing.Size(480, 89);
            this.drawBtn.TabIndex = 0;
            this.drawBtn.Text = "抽 签";
            this.drawBtn.UseVisualStyleBackColor = true;
            this.drawBtn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Font = new System.Drawing.Font("黑体", 15F);
            this.clearBtn.Location = new System.Drawing.Point(23, 301);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(4);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(233, 78);
            this.clearBtn.TabIndex = 1;
            this.clearBtn.Text = "清 除 已 抽";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 15F);
            this.label1.Location = new System.Drawing.Point(31, 395);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "共有";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 15F);
            this.label2.Location = new System.Drawing.Point(145, 395);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "人 已抽取";
            // 
            // totalPersonLabel
            // 
            this.totalPersonLabel.AutoSize = true;
            this.totalPersonLabel.Font = new System.Drawing.Font("黑体", 15F);
            this.totalPersonLabel.Location = new System.Drawing.Point(88, 395);
            this.totalPersonLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalPersonLabel.Name = "totalPersonLabel";
            this.totalPersonLabel.Size = new System.Drawing.Size(64, 25);
            this.totalPersonLabel.TabIndex = 4;
            this.totalPersonLabel.Text = "0000";
            // 
            // drawedPersonLabel
            // 
            this.drawedPersonLabel.AutoSize = true;
            this.drawedPersonLabel.Font = new System.Drawing.Font("黑体", 15F);
            this.drawedPersonLabel.Location = new System.Drawing.Point(267, 395);
            this.drawedPersonLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.drawedPersonLabel.Name = "drawedPersonLabel";
            this.drawedPersonLabel.Size = new System.Drawing.Size(64, 25);
            this.drawedPersonLabel.TabIndex = 7;
            this.drawedPersonLabel.Text = "0000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 15F);
            this.label4.Location = new System.Drawing.Point(323, 395);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "人";
            // 
            // nowDrawNameLabel
            // 
            this.nowDrawNameLabel.AutoSize = true;
            this.nowDrawNameLabel.Font = new System.Drawing.Font("黑体", 68F, System.Drawing.FontStyle.Bold);
            this.nowDrawNameLabel.Location = new System.Drawing.Point(-9, 78);
            this.nowDrawNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nowDrawNameLabel.Name = "nowDrawNameLabel";
            this.nowDrawNameLabel.Size = new System.Drawing.Size(508, 114);
            this.nowDrawNameLabel.TabIndex = 8;
            this.nowDrawNameLabel.Text = "正在处理";
            this.nowDrawNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("黑体", 15F);
            this.exitBtn.Location = new System.Drawing.Point(264, 301);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(239, 78);
            this.exitBtn.TabIndex = 9;
            this.exitBtn.Text = "保 存 并 退 出";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // aboutBtn
            // 
            this.aboutBtn.Location = new System.Drawing.Point(445, 389);
            this.aboutBtn.Margin = new System.Windows.Forms.Padding(4);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(52, 31);
            this.aboutBtn.TabIndex = 20;
            this.aboutBtn.Text = "关于";
            this.aboutBtn.UseVisualStyleBackColor = true;
            this.aboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(13, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 38);
            this.label3.TabIndex = 21;
            this.label3.Text = "编号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nowDrawNumLabel
            // 
            this.nowDrawNumLabel.AutoSize = true;
            this.nowDrawNumLabel.Font = new System.Drawing.Font("黑体", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nowDrawNumLabel.Location = new System.Drawing.Point(103, 43);
            this.nowDrawNumLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nowDrawNumLabel.Name = "nowDrawNumLabel";
            this.nowDrawNumLabel.Size = new System.Drawing.Size(297, 38);
            this.nowDrawNumLabel.TabIndex = 24;
            this.nowDrawNumLabel.Text = "00000000000000";
            this.nowDrawNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chooseClassCombo
            // 
            this.chooseClassCombo.FormattingEnabled = true;
            this.chooseClassCombo.Location = new System.Drawing.Point(144, 12);
            this.chooseClassCombo.Name = "chooseClassCombo";
            this.chooseClassCombo.Size = new System.Drawing.Size(256, 23);
            this.chooseClassCombo.TabIndex = 25;
            this.chooseClassCombo.SelectedIndexChanged += new System.EventHandler(this.ChooseClassCombo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("黑体", 15F);
            this.label7.Location = new System.Drawing.Point(9, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 25);
            this.label7.TabIndex = 26;
            this.label7.Text = "选择班级:";
            // 
            // FixBtn
            // 
            this.FixBtn.Image = global::drawRandom.Properties.Resources.fix;
            this.FixBtn.Location = new System.Drawing.Point(422, 6);
            this.FixBtn.Name = "FixBtn";
            this.FixBtn.Size = new System.Drawing.Size(32, 32);
            this.FixBtn.TabIndex = 27;
            this.FixBtn.UseVisualStyleBackColor = true;
            this.FixBtn.Click += new System.EventHandler(this.FixBtn_Click);
            // 
            // hideBtn
            // 
            this.hideBtn.Image = global::drawRandom.Properties.Resources.minimize;
            this.hideBtn.Location = new System.Drawing.Point(469, 6);
            this.hideBtn.Name = "hideBtn";
            this.hideBtn.Size = new System.Drawing.Size(32, 32);
            this.hideBtn.TabIndex = 28;
            this.hideBtn.UseVisualStyleBackColor = true;
            this.hideBtn.Click += new System.EventHandler(this.HideBtn_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 439);
            this.ControlBox = false;
            this.Controls.Add(this.hideBtn);
            this.Controls.Add(this.FixBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chooseClassCombo);
            this.Controls.Add(this.nowDrawNumLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.aboutBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.nowDrawNameLabel);
            this.Controls.Add(this.drawedPersonLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.totalPersonLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.drawBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "main";
            this.Text = "drawRandom";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button drawBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalPersonLabel;
        private System.Windows.Forms.Label drawedPersonLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label nowDrawNameLabel;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nowDrawNumLabel;
        private System.Windows.Forms.ComboBox chooseClassCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button FixBtn;
        private System.Windows.Forms.Button hideBtn;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

