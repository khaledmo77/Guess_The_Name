namespace ClientSideImp
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label1 = new Label();
            pictureBox2 = new PictureBox();
            LoginTextBox = new ReaLTaiizor.Controls.CyberRichTextBox();
            pictureBox3 = new PictureBox();
            PlayBtnCyber = new ReaLTaiizor.Controls.CyberButton();
            ExitBtn = new ReaLTaiizor.Controls.CyberButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Name = "label1";
            label1.Click += label1_Click;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // LoginTextBox
            // 
            LoginTextBox.Alpha = 20;
            LoginTextBox.BackColor = Color.Transparent;
            LoginTextBox.Background_WidthPen = 3F;
            LoginTextBox.BackgroundPen = true;
            LoginTextBox.ColorBackground = Color.FromArgb(255, 81, 47);
            LoginTextBox.ColorBackground_Pen = Color.FromArgb(221, 36, 118);
            LoginTextBox.ColorLighting = Color.FromArgb(255, 81, 47);
            LoginTextBox.ColorPen_1 = Color.FromArgb(255, 81, 47);
            LoginTextBox.ColorPen_2 = Color.FromArgb(255, 81, 47);
            LoginTextBox.CyberRichTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            resources.ApplyResources(LoginTextBox, "LoginTextBox");
            LoginTextBox.ForeColor = Color.FromArgb(245, 245, 245);
            LoginTextBox.Lighting = false;
            LoginTextBox.LinearGradientPen = false;
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.PenWidth = 15;
            LoginTextBox.RGB = false;
            LoginTextBox.Rounding = true;
            LoginTextBox.RoundingInt = 60;
            LoginTextBox.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            LoginTextBox.Tag = "Cyber";
            LoginTextBox.TextButton = "";
            LoginTextBox.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            LoginTextBox.Timer_RGB = 300;
            // 
            // pictureBox3
            // 
            resources.ApplyResources(pictureBox3, "pictureBox3");
            pictureBox3.Name = "pictureBox3";
            pictureBox3.TabStop = false;
            // 
            // PlayBtnCyber
            // 
            PlayBtnCyber.Alpha = 20;
            PlayBtnCyber.BackColor = Color.Transparent;
            PlayBtnCyber.Background = true;
            PlayBtnCyber.Background_WidthPen = 4F;
            PlayBtnCyber.BackgroundPen = true;
            PlayBtnCyber.ColorBackground = Color.FromArgb(255, 81, 47);
            PlayBtnCyber.ColorBackground_1 = Color.FromArgb(221, 36, 118);
            PlayBtnCyber.ColorBackground_2 = Color.FromArgb(255, 81, 47);
            PlayBtnCyber.ColorBackground_Pen = Color.FromArgb(255, 81, 47);
            PlayBtnCyber.ColorLighting = Color.FromArgb(255, 81, 47);
            PlayBtnCyber.ColorPen_1 = Color.FromArgb(255, 81, 47);
            PlayBtnCyber.ColorPen_2 = Color.FromArgb(255, 81, 47);
            PlayBtnCyber.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            PlayBtnCyber.Effect_1 = true;
            PlayBtnCyber.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            PlayBtnCyber.Effect_1_Transparency = 25;
            PlayBtnCyber.Effect_2 = true;
            PlayBtnCyber.Effect_2_ColorBackground = Color.White;
            PlayBtnCyber.Effect_2_Transparency = 20;
            resources.ApplyResources(PlayBtnCyber, "PlayBtnCyber");
            PlayBtnCyber.ForeColor = Color.FromArgb(245, 245, 245);
            PlayBtnCyber.Lighting = false;
            PlayBtnCyber.LinearGradient_Background = false;
            PlayBtnCyber.LinearGradientPen = false;
            PlayBtnCyber.Name = "PlayBtnCyber";
            PlayBtnCyber.PenWidth = 15;
            PlayBtnCyber.Rounding = true;
            PlayBtnCyber.RoundingInt = 70;
            PlayBtnCyber.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            PlayBtnCyber.Tag = "Cyber";
            PlayBtnCyber.TextButton = "Login";
            PlayBtnCyber.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            PlayBtnCyber.Timer_Effect_1 = 5;
            PlayBtnCyber.Timer_RGB = 300;
            PlayBtnCyber.Click += PlayBtnCyber_Click;
            // 
            // ExitBtn
            // 
            ExitBtn.Alpha = 20;
            ExitBtn.BackColor = Color.Transparent;
            ExitBtn.Background = true;
            ExitBtn.Background_WidthPen = 4F;
            ExitBtn.BackgroundPen = true;
            ExitBtn.ColorBackground = Color.FromArgb(255, 81, 47);
            ExitBtn.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            ExitBtn.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            ExitBtn.ColorBackground_Pen = Color.FromArgb(255, 81, 47);
            ExitBtn.ColorLighting = Color.FromArgb(29, 200, 238);
            ExitBtn.ColorPen_1 = Color.FromArgb(37, 52, 68);
            ExitBtn.ColorPen_2 = Color.FromArgb(41, 63, 86);
            ExitBtn.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            ExitBtn.Effect_1 = true;
            ExitBtn.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            ExitBtn.Effect_1_Transparency = 25;
            ExitBtn.Effect_2 = true;
            ExitBtn.Effect_2_ColorBackground = Color.White;
            ExitBtn.Effect_2_Transparency = 20;
            resources.ApplyResources(ExitBtn, "ExitBtn");
            ExitBtn.ForeColor = Color.FromArgb(245, 245, 245);
            ExitBtn.Lighting = false;
            ExitBtn.LinearGradient_Background = false;
            ExitBtn.LinearGradientPen = false;
            ExitBtn.Name = "ExitBtn";
            ExitBtn.PenWidth = 15;
            ExitBtn.Rounding = true;
            ExitBtn.RoundingInt = 70;
            ExitBtn.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            ExitBtn.Tag = "Cyber";
            ExitBtn.TextButton = "Exit";
            ExitBtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            ExitBtn.Timer_Effect_1 = 5;
            ExitBtn.Timer_RGB = 300;
            ExitBtn.Click += ExitBtn_Click;
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ExitBtn);
            Controls.Add(PlayBtnCyber);
            Controls.Add(pictureBox3);
            Controls.Add(LoginTextBox);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private ReaLTaiizor.Controls.CyberRichTextBox LoginTextBox;
        private PictureBox pictureBox3;
        private ReaLTaiizor.Controls.CyberButton PlayBtnCyber;
        private ReaLTaiizor.Controls.CyberButton ExitBtn;
    }
}
