namespace Reaction_Diffusion_Model
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnCreateGrid = new System.Windows.Forms.Button();
            this.btnToggleTimer = new System.Windows.Forms.Button();
            this.btnJump = new System.Windows.Forms.Button();
            this.tbFeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbKill = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.group_Lap = new System.Windows.Forms.GroupBox();
            this.rdo_Lap_Delta = new System.Windows.Forms.RadioButton();
            this.rdo_Lap_Convoltion = new System.Windows.Forms.RadioButton();
            this.rdo_Lap_Perpendicular = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdo_yellowToRed = new System.Windows.Forms.RadioButton();
            this.rdo_lRainbow = new System.Windows.Forms.RadioButton();
            this.rdo_sRainbow = new System.Windows.Forms.RadioButton();
            this.rdo_grayscale = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_LargeSim = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.group_Lap.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateGrid
            // 
            this.btnCreateGrid.Location = new System.Drawing.Point(742, 21);
            this.btnCreateGrid.Name = "btnCreateGrid";
            this.btnCreateGrid.Size = new System.Drawing.Size(144, 40);
            this.btnCreateGrid.TabIndex = 0;
            this.btnCreateGrid.Text = "Create Grid";
            this.btnCreateGrid.UseVisualStyleBackColor = true;
            this.btnCreateGrid.Click += new System.EventHandler(this.btnCreateGrid_Click);
            // 
            // btnToggleTimer
            // 
            this.btnToggleTimer.Location = new System.Drawing.Point(742, 70);
            this.btnToggleTimer.Name = "btnToggleTimer";
            this.btnToggleTimer.Size = new System.Drawing.Size(144, 41);
            this.btnToggleTimer.TabIndex = 1;
            this.btnToggleTimer.Text = "Toggle Timer";
            this.btnToggleTimer.UseVisualStyleBackColor = true;
            this.btnToggleTimer.Click += new System.EventHandler(this.btnToggleTimer_Click);
            // 
            // btnJump
            // 
            this.btnJump.Location = new System.Drawing.Point(742, 124);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(144, 41);
            this.btnJump.TabIndex = 2;
            this.btnJump.Text = "Jump 5000";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // tbFeed
            // 
            this.tbFeed.Location = new System.Drawing.Point(118, 50);
            this.tbFeed.Name = "tbFeed";
            this.tbFeed.Size = new System.Drawing.Size(100, 26);
            this.tbFeed.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Feed Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kill Rate";
            // 
            // tbKill
            // 
            this.tbKill.Location = new System.Drawing.Point(118, 82);
            this.tbKill.Name = "tbKill";
            this.tbKill.Size = new System.Drawing.Size(100, 26);
            this.tbKill.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbKill);
            this.groupBox1.Controls.Add(this.tbFeed);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(474, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 196);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // group_Lap
            // 
            this.group_Lap.Controls.Add(this.rdo_Lap_Delta);
            this.group_Lap.Controls.Add(this.rdo_Lap_Convoltion);
            this.group_Lap.Controls.Add(this.rdo_Lap_Perpendicular);
            this.group_Lap.Location = new System.Drawing.Point(534, 232);
            this.group_Lap.Name = "group_Lap";
            this.group_Lap.Size = new System.Drawing.Size(187, 152);
            this.group_Lap.TabIndex = 12;
            this.group_Lap.TabStop = false;
            this.group_Lap.Text = "Algorithm";
            // 
            // rdo_Lap_Delta
            // 
            this.rdo_Lap_Delta.AutoSize = true;
            this.rdo_Lap_Delta.Location = new System.Drawing.Point(20, 99);
            this.rdo_Lap_Delta.Name = "rdo_Lap_Delta";
            this.rdo_Lap_Delta.Size = new System.Drawing.Size(124, 24);
            this.rdo_Lap_Delta.TabIndex = 2;
            this.rdo_Lap_Delta.TabStop = true;
            this.rdo_Lap_Delta.Text = "Delta Means";
            this.rdo_Lap_Delta.UseVisualStyleBackColor = true;
            // 
            // rdo_Lap_Convoltion
            // 
            this.rdo_Lap_Convoltion.AutoSize = true;
            this.rdo_Lap_Convoltion.Location = new System.Drawing.Point(20, 69);
            this.rdo_Lap_Convoltion.Name = "rdo_Lap_Convoltion";
            this.rdo_Lap_Convoltion.Size = new System.Drawing.Size(108, 24);
            this.rdo_Lap_Convoltion.TabIndex = 1;
            this.rdo_Lap_Convoltion.TabStop = true;
            this.rdo_Lap_Convoltion.Text = "Convoltion";
            this.rdo_Lap_Convoltion.UseVisualStyleBackColor = true;
            // 
            // rdo_Lap_Perpendicular
            // 
            this.rdo_Lap_Perpendicular.AutoSize = true;
            this.rdo_Lap_Perpendicular.Location = new System.Drawing.Point(20, 39);
            this.rdo_Lap_Perpendicular.Name = "rdo_Lap_Perpendicular";
            this.rdo_Lap_Perpendicular.Size = new System.Drawing.Size(131, 24);
            this.rdo_Lap_Perpendicular.TabIndex = 0;
            this.rdo_Lap_Perpendicular.TabStop = true;
            this.rdo_Lap_Perpendicular.Text = "Perpendicular";
            this.rdo_Lap_Perpendicular.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdo_yellowToRed);
            this.groupBox3.Controls.Add(this.rdo_lRainbow);
            this.groupBox3.Controls.Add(this.rdo_sRainbow);
            this.groupBox3.Controls.Add(this.rdo_grayscale);
            this.groupBox3.Location = new System.Drawing.Point(534, 403);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 211);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Brush";
            // 
            // rdo_yellowToRed
            // 
            this.rdo_yellowToRed.AutoSize = true;
            this.rdo_yellowToRed.Location = new System.Drawing.Point(20, 138);
            this.rdo_yellowToRed.Name = "rdo_yellowToRed";
            this.rdo_yellowToRed.Size = new System.Drawing.Size(132, 24);
            this.rdo_yellowToRed.TabIndex = 6;
            this.rdo_yellowToRed.TabStop = true;
            this.rdo_yellowToRed.Text = "Yellow to Red";
            this.rdo_yellowToRed.UseVisualStyleBackColor = true;
            // 
            // rdo_lRainbow
            // 
            this.rdo_lRainbow.AutoSize = true;
            this.rdo_lRainbow.Location = new System.Drawing.Point(20, 108);
            this.rdo_lRainbow.Name = "rdo_lRainbow";
            this.rdo_lRainbow.Size = new System.Drawing.Size(136, 24);
            this.rdo_lRainbow.TabIndex = 5;
            this.rdo_lRainbow.TabStop = true;
            this.rdo_lRainbow.Text = "Long Rainbow";
            this.rdo_lRainbow.UseVisualStyleBackColor = true;
            // 
            // rdo_sRainbow
            // 
            this.rdo_sRainbow.AutoSize = true;
            this.rdo_sRainbow.Location = new System.Drawing.Point(20, 78);
            this.rdo_sRainbow.Name = "rdo_sRainbow";
            this.rdo_sRainbow.Size = new System.Drawing.Size(139, 24);
            this.rdo_sRainbow.TabIndex = 4;
            this.rdo_sRainbow.TabStop = true;
            this.rdo_sRainbow.Text = "Short Rainbow";
            this.rdo_sRainbow.UseVisualStyleBackColor = true;
            // 
            // rdo_grayscale
            // 
            this.rdo_grayscale.AutoSize = true;
            this.rdo_grayscale.Location = new System.Drawing.Point(20, 48);
            this.rdo_grayscale.Name = "rdo_grayscale";
            this.rdo_grayscale.Size = new System.Drawing.Size(105, 24);
            this.rdo_grayscale.TabIndex = 3;
            this.rdo_grayscale.TabStop = true;
            this.rdo_grayscale.Text = "Grayscale";
            this.rdo_grayscale.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(742, 292);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 43);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // btn_LargeSim
            // 
            this.btn_LargeSim.Location = new System.Drawing.Point(742, 210);
            this.btn_LargeSim.Name = "btn_LargeSim";
            this.btn_LargeSim.Size = new System.Drawing.Size(144, 36);
            this.btn_LargeSim.TabIndex = 15;
            this.btn_LargeSim.Text = "Run Large Sim";
            this.btn_LargeSim.UseVisualStyleBackColor = true;
            this.btn_LargeSim.Click += new System.EventHandler(this.btn_LargeSim_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 657);
            this.Controls.Add(this.btn_LargeSim);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.group_Lap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnJump);
            this.Controls.Add(this.btnToggleTimer);
            this.Controls.Add(this.btnCreateGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.group_Lap.ResumeLayout(false);
            this.group_Lap.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateGrid;
        private System.Windows.Forms.Button btnToggleTimer;
        private System.Windows.Forms.Button btnJump;
        private System.Windows.Forms.TextBox tbFeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbKill;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox group_Lap;
        private System.Windows.Forms.RadioButton rdo_Lap_Delta;
        private System.Windows.Forms.RadioButton rdo_Lap_Convoltion;
        private System.Windows.Forms.RadioButton rdo_Lap_Perpendicular;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton rdo_yellowToRed;
        private System.Windows.Forms.RadioButton rdo_lRainbow;
        private System.Windows.Forms.RadioButton rdo_sRainbow;
        private System.Windows.Forms.RadioButton rdo_grayscale;
        private System.Windows.Forms.Button btn_LargeSim;
    }
}

