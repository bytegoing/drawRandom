namespace drawRandom
{
    partial class HideFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HideFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::drawRandom.Properties.Resources.newback;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(128, 64);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HideFrm";
            this.ShowIcon = false;
            this.Text = "HideFrm";
            this.TopMost = true;
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.HideFrm_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HideFrm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HideFrm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HideFrm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}