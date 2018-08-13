namespace Gobang
{
    partial class Gobang
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
            this.backgroundpicture = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重新开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PlayerWin = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.showStep = new System.Windows.Forms.CheckBox();
            this.helpAI = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ComputerWin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.showScore = new System.Windows.Forms.CheckBox();
            this.ComputerFirst = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.startGame = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.HistoryData = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundpicture)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundpicture
            // 
            this.backgroundpicture.Location = new System.Drawing.Point(1, 28);
            this.backgroundpicture.Name = "backgroundpicture";
            this.backgroundpicture.Size = new System.Drawing.Size(524, 524);
            this.backgroundpicture.TabIndex = 0;
            this.backgroundpicture.TabStop = false;
            this.backgroundpicture.Paint += new System.Windows.Forms.PaintEventHandler(this.backgroundpicture_Paint);
            this.backgroundpicture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.backgroundpicture_MouseClick);
            this.backgroundpicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.backgroundpicture_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(747, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重新开始ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 重新开始ToolStripMenuItem
            // 
            this.重新开始ToolStripMenuItem.Name = "重新开始ToolStripMenuItem";
            this.重新开始ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.重新开始ToolStripMenuItem.Text = "重新开始";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PlayerWin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.showStep);
            this.groupBox1.Controls.Add(this.helpAI);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.ComputerWin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.showScore);
            this.groupBox1.Controls.Add(this.ComputerFirst);
            this.groupBox1.Location = new System.Drawing.Point(531, 410);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 106);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "属性";
            // 
            // PlayerWin
            // 
            this.PlayerWin.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlayerWin.Location = new System.Drawing.Point(154, 50);
            this.PlayerWin.Name = "PlayerWin";
            this.PlayerWin.Size = new System.Drawing.Size(23, 24);
            this.PlayerWin.TabIndex = 8;
            this.PlayerWin.Text = "0";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(139, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = ":";
            // 
            // showStep
            // 
            this.showStep.AutoSize = true;
            this.showStep.Location = new System.Drawing.Point(143, 20);
            this.showStep.Name = "showStep";
            this.showStep.Size = new System.Drawing.Size(48, 16);
            this.showStep.TabIndex = 6;
            this.showStep.Text = "步数";
            this.showStep.UseVisualStyleBackColor = true;
            // 
            // helpAI
            // 
            this.helpAI.Location = new System.Drawing.Point(99, 77);
            this.helpAI.Name = "helpAI";
            this.helpAI.Size = new System.Drawing.Size(75, 23);
            this.helpAI.TabIndex = 5;
            this.helpAI.Text = "帮助";
            this.helpAI.UseVisualStyleBackColor = true;
            this.helpAI.Click += new System.EventHandler(this.helpAI_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "悔棋";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ComputerWin
            // 
            this.ComputerWin.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComputerWin.Location = new System.Drawing.Point(125, 50);
            this.ComputerWin.Name = "ComputerWin";
            this.ComputerWin.Size = new System.Drawing.Size(23, 24);
            this.ComputerWin.TabIndex = 3;
            this.ComputerWin.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(19, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "电脑:用户";
            // 
            // showScore
            // 
            this.showScore.AutoSize = true;
            this.showScore.Location = new System.Drawing.Point(86, 20);
            this.showScore.Name = "showScore";
            this.showScore.Size = new System.Drawing.Size(48, 16);
            this.showScore.TabIndex = 1;
            this.showScore.Text = "得分";
            this.showScore.UseVisualStyleBackColor = true;
            // 
            // ComputerFirst
            // 
            this.ComputerFirst.AutoSize = true;
            this.ComputerFirst.Location = new System.Drawing.Point(11, 21);
            this.ComputerFirst.Name = "ComputerFirst";
            this.ComputerFirst.Size = new System.Drawing.Size(72, 16);
            this.ComputerFirst.TabIndex = 0;
            this.ComputerFirst.Text = "电脑先手";
            this.ComputerFirst.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 555);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(747, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // startGame
            // 
            this.startGame.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startGame.Location = new System.Drawing.Point(538, 523);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(202, 29);
            this.startGame.TabIndex = 5;
            this.startGame.Text = "开     始";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(551, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "历   史   记   录";
            // 
            // HistoryData
            // 
            this.HistoryData.FormattingEnabled = true;
            this.HistoryData.ItemHeight = 12;
            this.HistoryData.Location = new System.Drawing.Point(531, 54);
            this.HistoryData.Name = "HistoryData";
            this.HistoryData.Size = new System.Drawing.Size(209, 340);
            this.HistoryData.TabIndex = 7;
            // 
            // Gobang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 577);
            this.Controls.Add(this.HistoryData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.backgroundpicture);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Gobang";
            this.Text = "Gobang";
            this.Load += new System.EventHandler(this.Gobang_Load);
            this.Shown += new System.EventHandler(this.Gobang_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.backgroundpicture)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox backgroundpicture;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重新开始ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ComputerFirst;
        private System.Windows.Forms.CheckBox showScore;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label ComputerWin;
        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox showStep;
        private System.Windows.Forms.Button helpAI;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label PlayerWin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox HistoryData;
    }
}

