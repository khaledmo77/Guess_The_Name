namespace ClientSideImp
{
    partial class LobbyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LobbyForm));
            Options = new GroupBox();
            label2 = new Label();
            Animals = new RadioButton();
            Vehicle = new RadioButton();
            Food = new RadioButton();
            groupBox1 = new GroupBox();
            CreateRoomBtn = new ReaLTaiizor.Controls.CyberButton();
            Options.SuspendLayout();
            SuspendLayout();
            // 
            // Options
            // 
            Options.BackColor = Color.Transparent;
            Options.Controls.Add(label2);
            Options.Controls.Add(Animals);
            Options.Controls.Add(Vehicle);
            Options.Controls.Add(Food);
            resources.ApplyResources(Options, "Options");
            Options.Name = "Options";
            Options.TabStop = false;
            Options.Enter += Options_Enter;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = Color.DarkOliveGreen;
            label2.Name = "label2";
            // 
            // Animals
            // 
            resources.ApplyResources(Animals, "Animals");
            Animals.Name = "Animals";
            Animals.TabStop = true;
            Animals.UseVisualStyleBackColor = true;
            Animals.CheckedChanged += Animals_CheckedChanged;
            // 
            // Vehicle
            // 
            resources.ApplyResources(Vehicle, "Vehicle");
            Vehicle.Name = "Vehicle";
            Vehicle.TabStop = true;
            Vehicle.UseVisualStyleBackColor = true;
            Vehicle.CheckedChanged += Vehicle_CheckedChanged;
            // 
            // Food
            // 
            resources.ApplyResources(Food, "Food");
            Food.Name = "Food";
            Food.TabStop = true;
            Food.UseVisualStyleBackColor = true;
            Food.CheckedChanged += Food_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // CreateRoomBtn
            // 
            CreateRoomBtn.Alpha = 20;
            CreateRoomBtn.BackColor = Color.Transparent;
            CreateRoomBtn.Background = true;
            CreateRoomBtn.Background_WidthPen = 4F;
            CreateRoomBtn.BackgroundPen = true;
            CreateRoomBtn.ColorBackground = Color.FromArgb(255, 81, 47);
            CreateRoomBtn.ColorBackground_1 = Color.FromArgb(221, 36, 118);
            CreateRoomBtn.ColorBackground_2 = Color.FromArgb(255, 81, 47);
            CreateRoomBtn.ColorBackground_Pen = Color.FromArgb(255, 81, 47);
            CreateRoomBtn.ColorLighting = Color.FromArgb(255, 81, 47);
            CreateRoomBtn.ColorPen_1 = Color.FromArgb(255, 81, 47);
            CreateRoomBtn.ColorPen_2 = Color.FromArgb(255, 81, 47);
            CreateRoomBtn.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            CreateRoomBtn.Effect_1 = true;
            CreateRoomBtn.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            CreateRoomBtn.Effect_1_Transparency = 25;
            CreateRoomBtn.Effect_2 = true;
            CreateRoomBtn.Effect_2_ColorBackground = Color.White;
            CreateRoomBtn.Effect_2_Transparency = 20;
            resources.ApplyResources(CreateRoomBtn, "CreateRoomBtn");
            CreateRoomBtn.ForeColor = Color.FromArgb(245, 245, 245);
            CreateRoomBtn.Lighting = false;
            CreateRoomBtn.LinearGradient_Background = false;
            CreateRoomBtn.LinearGradientPen = false;
            CreateRoomBtn.Name = "CreateRoomBtn";
            CreateRoomBtn.PenWidth = 15;
            CreateRoomBtn.Rounding = true;
            CreateRoomBtn.RoundingInt = 70;
            CreateRoomBtn.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            CreateRoomBtn.Tag = "Cyber";
            CreateRoomBtn.TextButton = "Create Room";
            CreateRoomBtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            CreateRoomBtn.Timer_Effect_1 = 5;
            CreateRoomBtn.Timer_RGB = 300;
            CreateRoomBtn.Click += CreateRoomBtn_Click;
            // 
            // LobbyForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CreateRoomBtn);
            Controls.Add(groupBox1);
            Controls.Add(Options);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LobbyForm";
            Options.ResumeLayout(false);
            Options.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox Options;
        private Label label2;
        private RadioButton Animals;
        private RadioButton Vehicle;
        private RadioButton Food;
        private GroupBox groupBox1;
        private ReaLTaiizor.Controls.CyberButton CreateRoomBtn;
    }
}