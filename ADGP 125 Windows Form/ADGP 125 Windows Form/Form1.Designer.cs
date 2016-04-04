using System.Windows.Forms;
using System.Drawing;

namespace ADGP_125_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CurrentUnit = new System.Windows.Forms.Label();
            this.cuName = new System.Windows.Forms.Label();
            this.cuHealth = new System.Windows.Forms.Label();
            this.cuSpeed = new System.Windows.Forms.Label();
            this.cuAttack = new System.Windows.Forms.Label();
            this.cuCurExp = new System.Windows.Forms.Label();
            this.cuLevel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.startBattle = new System.Windows.Forms.Button();
            this.battleTextBox = new System.Windows.Forms.RichTextBox();
            this.switchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ggPhase = new System.Windows.Forms.Label();
            this.bgPhase = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadGame = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.GPCurrentUnit = new System.Windows.Forms.Label();
            this.BPCurrentUnit = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.switchButtonReverse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CurrentUnit
            // 
            this.CurrentUnit.AutoSize = true;
            this.CurrentUnit.BackColor = System.Drawing.SystemColors.Control;
            this.CurrentUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CurrentUnit.Location = new System.Drawing.Point(335, 264);
            this.CurrentUnit.Name = "CurrentUnit";
            this.CurrentUnit.Size = new System.Drawing.Size(92, 17);
            this.CurrentUnit.TabIndex = 2;
            this.CurrentUnit.Text = "Selected Unit";
            // 
            // cuName
            // 
            this.cuName.AutoSize = true;
            this.cuName.BackColor = System.Drawing.SystemColors.Control;
            this.cuName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuName.Location = new System.Drawing.Point(401, 286);
            this.cuName.Name = "cuName";
            this.cuName.Size = new System.Drawing.Size(45, 17);
            this.cuName.TabIndex = 3;
            this.cuName.Text = "Name";
            // 
            // cuHealth
            // 
            this.cuHealth.AutoSize = true;
            this.cuHealth.BackColor = System.Drawing.SystemColors.Control;
            this.cuHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuHealth.Location = new System.Drawing.Point(401, 308);
            this.cuHealth.Name = "cuHealth";
            this.cuHealth.Size = new System.Drawing.Size(68, 17);
            this.cuHealth.TabIndex = 4;
            this.cuHealth.Text = "AUHealth";
            // 
            // cuSpeed
            // 
            this.cuSpeed.AutoSize = true;
            this.cuSpeed.BackColor = System.Drawing.SystemColors.Control;
            this.cuSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuSpeed.Location = new System.Drawing.Point(401, 355);
            this.cuSpeed.Name = "cuSpeed";
            this.cuSpeed.Size = new System.Drawing.Size(68, 17);
            this.cuSpeed.TabIndex = 5;
            this.cuSpeed.Text = "AUSpeed";
            // 
            // cuAttack
            // 
            this.cuAttack.AutoSize = true;
            this.cuAttack.BackColor = System.Drawing.SystemColors.Control;
            this.cuAttack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuAttack.Location = new System.Drawing.Point(401, 330);
            this.cuAttack.Name = "cuAttack";
            this.cuAttack.Size = new System.Drawing.Size(66, 17);
            this.cuAttack.TabIndex = 6;
            this.cuAttack.Text = "AUAttack";
            // 
            // cuCurExp
            // 
            this.cuCurExp.AutoSize = true;
            this.cuCurExp.BackColor = System.Drawing.SystemColors.Control;
            this.cuCurExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuCurExp.Location = new System.Drawing.Point(401, 382);
            this.cuCurExp.Name = "cuCurExp";
            this.cuCurExp.Size = new System.Drawing.Size(72, 17);
            this.cuCurExp.TabIndex = 7;
            this.cuCurExp.Text = "AUCurExp";
            // 
            // cuLevel
            // 
            this.cuLevel.AutoSize = true;
            this.cuLevel.BackColor = System.Drawing.SystemColors.Control;
            this.cuLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuLevel.Location = new System.Drawing.Point(401, 407);
            this.cuLevel.Name = "cuLevel";
            this.cuLevel.Size = new System.Drawing.Size(61, 17);
            this.cuLevel.TabIndex = 9;
            this.cuLevel.Text = "AULevel";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 51);
            this.button1.TabIndex = 10;
            this.button1.Text = "Next Phase";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.nextFSMPhase);
            // 
            // startBattle
            // 
            this.startBattle.BackColor = System.Drawing.Color.Red;
            this.startBattle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBattle.Location = new System.Drawing.Point(567, 12);
            this.startBattle.Name = "startBattle";
            this.startBattle.Size = new System.Drawing.Size(118, 96);
            this.startBattle.TabIndex = 11;
            this.startBattle.Text = "Start Battle";
            this.startBattle.UseVisualStyleBackColor = false;
            this.startBattle.Click += new System.EventHandler(this.startFSM);
            // 
            // battleTextBox
            // 
            this.battleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.battleTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.battleTextBox.Location = new System.Drawing.Point(12, 9);
            this.battleTextBox.Name = "battleTextBox";
            this.battleTextBox.ReadOnly = true;
            this.battleTextBox.Size = new System.Drawing.Size(521, 175);
            this.battleTextBox.TabIndex = 12;
            this.battleTextBox.Text = "";
            this.battleTextBox.Visible = false;
            // 
            // switchButton
            // 
            this.switchButton.Location = new System.Drawing.Point(404, 427);
            this.switchButton.Name = "switchButton";
            this.switchButton.Size = new System.Drawing.Size(131, 23);
            this.switchButton.TabIndex = 13;
            this.switchButton.Text = "Switch Unit(Down List)";
            this.switchButton.UseVisualStyleBackColor = true;
            this.switchButton.Visible = false;
            this.switchButton.Click += new System.EventHandler(this.switchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(335, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(335, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Health:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(335, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Attack:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(335, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Speed:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(335, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "EXP:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(335, 407);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Level:";
            // 
            // ggPhase
            // 
            this.ggPhase.AutoSize = true;
            this.ggPhase.BackColor = System.Drawing.SystemColors.Control;
            this.ggPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggPhase.Location = new System.Drawing.Point(153, 266);
            this.ggPhase.Name = "ggPhase";
            this.ggPhase.Size = new System.Drawing.Size(72, 17);
            this.ggPhase.TabIndex = 21;
            this.ggPhase.Text = "GP Phase";
            // 
            // bgPhase
            // 
            this.bgPhase.AutoSize = true;
            this.bgPhase.BackColor = System.Drawing.SystemColors.Control;
            this.bgPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bgPhase.Location = new System.Drawing.Point(153, 394);
            this.bgPhase.Name = "bgPhase";
            this.bgPhase.Size = new System.Drawing.Size(70, 17);
            this.bgPhase.TabIndex = 22;
            this.bgPhase.Text = "BP Phase";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Good Party\'s Phase:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 392);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Bad Party\'s Phase:";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(12, 510);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(136, 25);
            this.saveButton.TabIndex = 25;
            this.saveButton.Text = "Save Game";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadGame
            // 
            this.loadGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadGame.Location = new System.Drawing.Point(12, 541);
            this.loadGame.Name = "loadGame";
            this.loadGame.Size = new System.Drawing.Size(136, 26);
            this.loadGame.TabIndex = 26;
            this.loadGame.Text = "Load Last Game";
            this.loadGame.UseVisualStyleBackColor = true;
            this.loadGame.Click += new System.EventHandler(this.loadGame_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 286);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "GP Current Unit:";
            // 
            // GPCurrentUnit
            // 
            this.GPCurrentUnit.AutoSize = true;
            this.GPCurrentUnit.BackColor = System.Drawing.SystemColors.Control;
            this.GPCurrentUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GPCurrentUnit.Location = new System.Drawing.Point(153, 286);
            this.GPCurrentUnit.Name = "GPCurrentUnit";
            this.GPCurrentUnit.Size = new System.Drawing.Size(100, 17);
            this.GPCurrentUnit.TabIndex = 29;
            this.GPCurrentUnit.Text = "GPCurrentUnit";
            // 
            // BPCurrentUnit
            // 
            this.BPCurrentUnit.AutoSize = true;
            this.BPCurrentUnit.BackColor = System.Drawing.SystemColors.Control;
            this.BPCurrentUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPCurrentUnit.Location = new System.Drawing.Point(153, 416);
            this.BPCurrentUnit.Name = "BPCurrentUnit";
            this.BPCurrentUnit.Size = new System.Drawing.Size(98, 17);
            this.BPCurrentUnit.TabIndex = 31;
            this.BPCurrentUnit.Text = "BPCurrentUnit";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 416);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "BP Current Unit:";
            // 
            // switchButtonReverse
            // 
            this.switchButtonReverse.Location = new System.Drawing.Point(277, 427);
            this.switchButtonReverse.Name = "switchButtonReverse";
            this.switchButtonReverse.Size = new System.Drawing.Size(111, 23);
            this.switchButtonReverse.TabIndex = 32;
            this.switchButtonReverse.Text = "Switch Unit(Up List)";
            this.switchButtonReverse.UseVisualStyleBackColor = true;
            this.switchButtonReverse.Visible = false;
            this.switchButtonReverse.Click += new System.EventHandler(this.switchButtonReverse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(697, 678);
            this.Controls.Add(this.switchButtonReverse);
            this.Controls.Add(this.BPCurrentUnit);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.GPCurrentUnit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.loadGame);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bgPhase);
            this.Controls.Add(this.ggPhase);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.switchButton);
            this.Controls.Add(this.battleTextBox);
            this.Controls.Add(this.startBattle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cuLevel);
            this.Controls.Add(this.cuCurExp);
            this.Controls.Add(this.cuAttack);
            this.Controls.Add(this.cuSpeed);
            this.Controls.Add(this.cuHealth);
            this.Controls.Add(this.cuName);
            this.Controls.Add(this.CurrentUnit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label CurrentUnit;
        private System.Windows.Forms.Label cuName;
        private System.Windows.Forms.Label cuHealth;
        private System.Windows.Forms.Label cuSpeed;
        private System.Windows.Forms.Label cuAttack;
        private System.Windows.Forms.Label cuCurExp;
        private System.Windows.Forms.Label cuLevel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button startBattle;
        private System.Windows.Forms.RichTextBox battleTextBox;
        private System.Windows.Forms.Button switchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ggPhase;
        private System.Windows.Forms.Label bgPhase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Button saveButton;
        private Button loadGame;
        private Label label9;
        private Label GPCurrentUnit;
        private Label BPCurrentUnit;
        private Label label11;
        private Button switchButtonReverse;
    }
}

