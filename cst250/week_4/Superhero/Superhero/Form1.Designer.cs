namespace Superhero
{
    partial class Form1
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
            this.heroName = new System.Windows.Forms.TextBox();
            this.offensiveCheckList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.heroHometown = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.heroDOB = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.supportCheckList = new System.Windows.Forms.CheckedListBox();
            this.defensiveCheckList = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.allyEnemyBox = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.enemyButton = new System.Windows.Forms.RadioButton();
            this.allyButton = new System.Windows.Forms.RadioButton();
            this.moralScroll = new System.Windows.Forms.HScrollBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.luckLabel = new System.Windows.Forms.Label();
            this.luckScroll = new System.Windows.Forms.HScrollBar();
            this.potentialScroll = new System.Windows.Forms.HScrollBar();
            this.potentialLabel = new System.Windows.Forms.Label();
            this.motivationScroll = new System.Windows.Forms.HScrollBar();
            this.motivationLabel = new System.Windows.Forms.Label();
            this.moralLabel = new System.Windows.Forms.Label();
            this.looksBar = new System.Windows.Forms.TrackBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.heroColor3 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.heroColor2 = new System.Windows.Forms.PictureBox();
            this.heroColor1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.looksBar)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heroColor3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroColor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroColor1)).BeginInit();
            this.SuspendLayout();
            // 
            // heroName
            // 
            this.heroName.Location = new System.Drawing.Point(7, 37);
            this.heroName.Name = "heroName";
            this.heroName.Size = new System.Drawing.Size(220, 23);
            this.heroName.TabIndex = 0;
            // 
            // offensiveCheckList
            // 
            this.offensiveCheckList.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.offensiveCheckList.FormattingEnabled = true;
            this.offensiveCheckList.Items.AddRange(new object[] {
            "Super Strength",
            "Eye Beams",
            "Telekinesis",
            "Super Speed",
            "Elasticity",
            "Time Manipulation",
            "Flight",
            "Shape-Shifting"});
            this.offensiveCheckList.Location = new System.Drawing.Point(6, 39);
            this.offensiveCheckList.Name = "offensiveCheckList";
            this.offensiveCheckList.Size = new System.Drawing.Size(181, 140);
            this.offensiveCheckList.TabIndex = 1;
            this.offensiveCheckList.SelectedIndexChanged += new System.EventHandler(this.offensiveCheckList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.heroHometown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.heroDOB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.heroName);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(14, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 188);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hero\'s Identity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hometown";
            // 
            // heroHometown
            // 
            this.heroHometown.Location = new System.Drawing.Point(7, 146);
            this.heroHometown.Name = "heroHometown";
            this.heroHometown.Size = new System.Drawing.Size(220, 23);
            this.heroHometown.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(7, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date of Birth";
            // 
            // heroDOB
            // 
            this.heroDOB.Location = new System.Drawing.Point(7, 92);
            this.heroDOB.Name = "heroDOB";
            this.heroDOB.Size = new System.Drawing.Size(220, 23);
            this.heroDOB.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.supportCheckList);
            this.groupBox2.Controls.Add(this.defensiveCheckList);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.offensiveCheckList);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(256, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 187);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Special Abilities";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(380, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Support";
            // 
            // supportCheckList
            // 
            this.supportCheckList.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.supportCheckList.FormattingEnabled = true;
            this.supportCheckList.Items.AddRange(new object[] {
            "Healing",
            "Enhanced Intelligence",
            "Summoning",
            "Illusions",
            "Tactical Mastery",
            "Techno Genius",
            "Environmnet Adaption",
            "Telepathy"});
            this.supportCheckList.Location = new System.Drawing.Point(380, 41);
            this.supportCheckList.Name = "supportCheckList";
            this.supportCheckList.Size = new System.Drawing.Size(181, 140);
            this.supportCheckList.TabIndex = 10;
            // 
            // defensiveCheckList
            // 
            this.defensiveCheckList.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.defensiveCheckList.FormattingEnabled = true;
            this.defensiveCheckList.Items.AddRange(new object[] {
            "Regeneration",
            "Healing Powers",
            "Super Reflexes",
            "Phasing",
            "Size Alteration",
            "Super Resistances",
            "Force Field",
            "Super Durability"});
            this.defensiveCheckList.Location = new System.Drawing.Point(193, 39);
            this.defensiveCheckList.Name = "defensiveCheckList";
            this.defensiveCheckList.Size = new System.Drawing.Size(181, 140);
            this.defensiveCheckList.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(193, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Defensive";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Offensive";
            // 
            // allyEnemyBox
            // 
            this.allyEnemyBox.FormattingEnabled = true;
            this.allyEnemyBox.ItemHeight = 14;
            this.allyEnemyBox.Items.AddRange(new object[] {
            "Batman",
            "Superman",
            "Spider-Man",
            "Wonder Woman",
            "Iron Man",
            "Captain America",
            "The Flash",
            "Thor",
            "Hulk",
            "Black Widow",
            "Green Lantern",
            "Aquaman",
            "Black Panther",
            "Doctor Strange",
            "Ant-Man",
            "Green Arrow",
            "Wolverine",
            "Deadpool",
            "Hawkeye"});
            this.allyEnemyBox.Location = new System.Drawing.Point(7, 35);
            this.allyEnemyBox.Name = "allyEnemyBox";
            this.allyEnemyBox.Size = new System.Drawing.Size(181, 186);
            this.allyEnemyBox.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.enemyButton);
            this.groupBox3.Controls.Add(this.allyButton);
            this.groupBox3.Controls.Add(this.allyEnemyBox);
            this.groupBox3.Location = new System.Drawing.Point(14, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 232);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Closest Ally/Enemy";
            // 
            // enemyButton
            // 
            this.enemyButton.AutoSize = true;
            this.enemyButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.enemyButton.Location = new System.Drawing.Point(63, 16);
            this.enemyButton.Name = "enemyButton";
            this.enemyButton.Size = new System.Drawing.Size(69, 17);
            this.enemyButton.TabIndex = 6;
            this.enemyButton.TabStop = true;
            this.enemyButton.Text = "Enemy";
            this.enemyButton.UseVisualStyleBackColor = true;
            this.enemyButton.CheckedChanged += new System.EventHandler(this.enemyButton_CheckedChanged);
            // 
            // allyButton
            // 
            this.allyButton.AutoSize = true;
            this.allyButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.allyButton.Location = new System.Drawing.Point(7, 16);
            this.allyButton.Name = "allyButton";
            this.allyButton.Size = new System.Drawing.Size(50, 17);
            this.allyButton.TabIndex = 5;
            this.allyButton.TabStop = true;
            this.allyButton.Text = "Ally";
            this.allyButton.UseVisualStyleBackColor = true;
            this.allyButton.CheckedChanged += new System.EventHandler(this.allyButton_CheckedChanged);
            // 
            // moralScroll
            // 
            this.moralScroll.Location = new System.Drawing.Point(6, 36);
            this.moralScroll.Maximum = 109;
            this.moralScroll.Name = "moralScroll";
            this.moralScroll.Size = new System.Drawing.Size(216, 24);
            this.moralScroll.TabIndex = 6;
            this.moralScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.moralScroll_Scroll);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.luckLabel);
            this.groupBox4.Controls.Add(this.luckScroll);
            this.groupBox4.Controls.Add(this.potentialScroll);
            this.groupBox4.Controls.Add(this.potentialLabel);
            this.groupBox4.Controls.Add(this.motivationScroll);
            this.groupBox4.Controls.Add(this.motivationLabel);
            this.groupBox4.Controls.Add(this.moralLabel);
            this.groupBox4.Controls.Add(this.moralScroll);
            this.groupBox4.Location = new System.Drawing.Point(214, 205);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(244, 232);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Attributes";
            // 
            // luckLabel
            // 
            this.luckLabel.AutoSize = true;
            this.luckLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.luckLabel.Location = new System.Drawing.Point(6, 182);
            this.luckLabel.Name = "luckLabel";
            this.luckLabel.Size = new System.Drawing.Size(46, 15);
            this.luckLabel.TabIndex = 13;
            this.luckLabel.Text = "Luck: 0";
            // 
            // luckScroll
            // 
            this.luckScroll.Location = new System.Drawing.Point(6, 197);
            this.luckScroll.Maximum = 109;
            this.luckScroll.Name = "luckScroll";
            this.luckScroll.Size = new System.Drawing.Size(216, 24);
            this.luckScroll.TabIndex = 12;
            this.luckScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.luckScroll_Scroll);
            // 
            // potentialScroll
            // 
            this.potentialScroll.Location = new System.Drawing.Point(6, 141);
            this.potentialScroll.Maximum = 109;
            this.potentialScroll.Name = "potentialScroll";
            this.potentialScroll.Size = new System.Drawing.Size(216, 24);
            this.potentialScroll.TabIndex = 11;
            this.potentialScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.potentialScroll_Scroll);
            // 
            // potentialLabel
            // 
            this.potentialLabel.AutoSize = true;
            this.potentialLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.potentialLabel.Location = new System.Drawing.Point(6, 126);
            this.potentialLabel.Name = "potentialLabel";
            this.potentialLabel.Size = new System.Drawing.Size(73, 15);
            this.potentialLabel.TabIndex = 10;
            this.potentialLabel.Text = "Potential : 0";
            // 
            // motivationScroll
            // 
            this.motivationScroll.Location = new System.Drawing.Point(6, 86);
            this.motivationScroll.Maximum = 109;
            this.motivationScroll.Name = "motivationScroll";
            this.motivationScroll.Size = new System.Drawing.Size(216, 24);
            this.motivationScroll.TabIndex = 9;
            this.motivationScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.motivationScroll_Scroll);
            // 
            // motivationLabel
            // 
            this.motivationLabel.AutoSize = true;
            this.motivationLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.motivationLabel.Location = new System.Drawing.Point(6, 71);
            this.motivationLabel.Name = "motivationLabel";
            this.motivationLabel.Size = new System.Drawing.Size(84, 15);
            this.motivationLabel.TabIndex = 8;
            this.motivationLabel.Text = "Motivation : 0";
            // 
            // moralLabel
            // 
            this.moralLabel.AutoSize = true;
            this.moralLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.moralLabel.Location = new System.Drawing.Point(6, 21);
            this.moralLabel.Name = "moralLabel";
            this.moralLabel.Size = new System.Drawing.Size(69, 15);
            this.moralLabel.TabIndex = 7;
            this.moralLabel.Text = "Morality : 0";
            // 
            // looksBar
            // 
            this.looksBar.Location = new System.Drawing.Point(6, 41);
            this.looksBar.Name = "looksBar";
            this.looksBar.Size = new System.Drawing.Size(344, 45);
            this.looksBar.TabIndex = 7;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.heroColor3);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.heroColor2);
            this.groupBox5.Controls.Add(this.heroColor1);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.looksBar);
            this.groupBox5.Location = new System.Drawing.Point(464, 205);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(358, 232);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Image";
            // 
            // heroColor3
            // 
            this.heroColor3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.heroColor3.Location = new System.Drawing.Point(248, 115);
            this.heroColor3.Name = "heroColor3";
            this.heroColor3.Size = new System.Drawing.Size(104, 111);
            this.heroColor3.TabIndex = 18;
            this.heroColor3.TabStop = false;
            this.heroColor3.Click += new System.EventHandler(this.heroColor3_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(6, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 15);
            this.label12.TabIndex = 17;
            this.label12.Text = "Color Way";
            // 
            // heroColor2
            // 
            this.heroColor2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.heroColor2.Location = new System.Drawing.Point(129, 115);
            this.heroColor2.Name = "heroColor2";
            this.heroColor2.Size = new System.Drawing.Size(104, 111);
            this.heroColor2.TabIndex = 16;
            this.heroColor2.TabStop = false;
            this.heroColor2.Click += new System.EventHandler(this.heroColor2_Click);
            // 
            // heroColor1
            // 
            this.heroColor1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.heroColor1.Location = new System.Drawing.Point(6, 115);
            this.heroColor1.Name = "heroColor1";
            this.heroColor1.Size = new System.Drawing.Size(104, 111);
            this.heroColor1.TabIndex = 15;
            this.heroColor1.TabStop = false;
            this.heroColor1.Click += new System.EventHandler(this.heroColor1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(6, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 15);
            this.label11.TabIndex = 14;
            this.label11.Text = "Looks";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(808, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 470);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "Hero Maker";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.looksBar)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heroColor3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroColor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heroColor1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox heroName;
        private CheckedListBox offensiveCheckList;
        private GroupBox groupBox1;
        private Label label2;
        private DateTimePicker heroDOB;
        private Label label1;
        private Label label3;
        private TextBox heroHometown;
        private GroupBox groupBox2;
        private Label label6;
        private CheckedListBox supportCheckList;
        private CheckedListBox defensiveCheckList;
        private Label label5;
        private Label label4;
        private ListBox allyEnemyBox;
        private GroupBox groupBox3;
        private HScrollBar moralScroll;
        private GroupBox groupBox4;
        private Label luckLabel;
        private HScrollBar luckScroll;
        private HScrollBar potentialScroll;
        private Label potentialLabel;
        private HScrollBar motivationScroll;
        private Label motivationLabel;
        private Label moralLabel;
        private TrackBar looksBar;
        private GroupBox groupBox5;
        private PictureBox heroColor1;
        private Label label11;
        private ColorDialog colorDialog1;
        private ColorDialog colorDialog2;
        private PictureBox heroColor3;
        private Label label12;
        private PictureBox heroColor2;
        private Button button1;
        private RadioButton enemyButton;
        private RadioButton allyButton;
        private ColorDialog colorDialog3;
    }
}