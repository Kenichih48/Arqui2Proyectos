namespace Proyecto1
{
    partial class GUI
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
            generate = new Button();
            step1 = new Button();
            auto = new Button();
            Reset = new Button();
            instrBox1 = new TextBox();
            instrBox2 = new TextBox();
            instrBox3 = new TextBox();
            instrBox4 = new TextBox();
            step2 = new Button();
            step3 = new Button();
            step4 = new Button();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            PC3 = new Label();
            PC2 = new Label();
            PC1 = new Label();
            PC4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // generate
            // 
            generate.BackColor = SystemColors.Control;
            generate.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            generate.Location = new Point(27, 32);
            generate.Name = "generate";
            generate.Size = new Size(126, 28);
            generate.TabIndex = 0;
            generate.Text = "Generate Code";
            generate.UseVisualStyleBackColor = false;
            generate.Click += generate_Click;
            // 
            // step1
            // 
            step1.BackColor = SystemColors.Control;
            step1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            step1.Location = new Point(176, 283);
            step1.Name = "step1";
            step1.Size = new Size(97, 32);
            step1.TabIndex = 1;
            step1.Text = "Step";
            step1.UseVisualStyleBackColor = false;
            step1.Click += step1_Click;
            // 
            // auto
            // 
            auto.BackColor = SystemColors.Control;
            auto.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            auto.Location = new Point(44, 66);
            auto.Name = "auto";
            auto.Size = new Size(97, 27);
            auto.TabIndex = 2;
            auto.Text = "Auto";
            auto.UseVisualStyleBackColor = false;
            auto.Click += auto_Click;
            // 
            // Reset
            // 
            Reset.BackColor = SystemColors.Control;
            Reset.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Reset.Location = new Point(44, 99);
            Reset.Name = "Reset";
            Reset.Size = new Size(97, 27);
            Reset.TabIndex = 3;
            Reset.Text = "Reset";
            Reset.UseVisualStyleBackColor = false;
            Reset.Click += reset_Click;
            // 
            // instrBox1
            // 
            instrBox1.Enabled = false;
            instrBox1.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            instrBox1.Location = new Point(12, 141);
            instrBox1.Multiline = true;
            instrBox1.Name = "instrBox1";
            instrBox1.Size = new Size(158, 174);
            instrBox1.TabIndex = 4;
            // 
            // instrBox2
            // 
            instrBox2.Enabled = false;
            instrBox2.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            instrBox2.Location = new Point(12, 332);
            instrBox2.Multiline = true;
            instrBox2.Name = "instrBox2";
            instrBox2.Size = new Size(158, 174);
            instrBox2.TabIndex = 5;
            // 
            // instrBox3
            // 
            instrBox3.Enabled = false;
            instrBox3.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            instrBox3.Location = new Point(12, 522);
            instrBox3.Multiline = true;
            instrBox3.Name = "instrBox3";
            instrBox3.Size = new Size(158, 174);
            instrBox3.TabIndex = 6;
            // 
            // instrBox4
            // 
            instrBox4.Enabled = false;
            instrBox4.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            instrBox4.Location = new Point(12, 721);
            instrBox4.Multiline = true;
            instrBox4.Name = "instrBox4";
            instrBox4.Size = new Size(158, 174);
            instrBox4.TabIndex = 7;
            // 
            // step2
            // 
            step2.BackColor = SystemColors.Control;
            step2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            step2.Location = new Point(176, 474);
            step2.Name = "step2";
            step2.Size = new Size(97, 32);
            step2.TabIndex = 8;
            step2.Text = "Step";
            step2.UseVisualStyleBackColor = false;
            step2.Click += step2_Click;
            // 
            // step3
            // 
            step3.BackColor = SystemColors.Control;
            step3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            step3.Location = new Point(176, 664);
            step3.Name = "step3";
            step3.Size = new Size(97, 32);
            step3.TabIndex = 9;
            step3.Text = "Step";
            step3.UseVisualStyleBackColor = false;
            step3.Click += step3_Click;
            // 
            // step4
            // 
            step4.BackColor = SystemColors.Control;
            step4.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            step4.Location = new Point(176, 863);
            step4.Name = "step4";
            step4.Size = new Size(97, 32);
            step4.TabIndex = 10;
            step4.Text = "Step";
            step4.UseVisualStyleBackColor = false;
            step4.Click += step4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 265);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 12;
            label2.Text = "Current Instruction #";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(176, 456);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 13;
            label1.Text = "Current Instruction #";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(176, 646);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 14;
            label3.Text = "Current Instruction #";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(176, 845);
            label4.Name = "label4";
            label4.Size = new Size(117, 15);
            label4.TabIndex = 15;
            label4.Text = "Current Instruction #";
            // 
            // PC3
            // 
            PC3.AutoSize = true;
            PC3.Location = new Point(299, 646);
            PC3.Name = "PC3";
            PC3.Size = new Size(10, 15);
            PC3.TabIndex = 17;
            PC3.Text = " ";
            // 
            // PC2
            // 
            PC2.AutoSize = true;
            PC2.Location = new Point(299, 456);
            PC2.Name = "PC2";
            PC2.Size = new Size(10, 15);
            PC2.TabIndex = 18;
            PC2.Text = " ";
            // 
            // PC1
            // 
            PC1.AutoSize = true;
            PC1.Location = new Point(299, 265);
            PC1.Name = "PC1";
            PC1.Size = new Size(10, 15);
            PC1.TabIndex = 19;
            PC1.Text = " ";
            // 
            // PC4
            // 
            PC4.AutoSize = true;
            PC4.Location = new Point(299, 845);
            PC4.Name = "PC4";
            PC4.Size = new Size(10, 15);
            PC4.TabIndex = 20;
            PC4.Text = " ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(399, 32);
            label5.Name = "label5";
            label5.Size = new Size(693, 86);
            label5.TabIndex = 21;
            label5.Text = "MESI/MOESI Protocols";
            // 
            // GUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(1415, 959);
            Controls.Add(label5);
            Controls.Add(PC4);
            Controls.Add(PC1);
            Controls.Add(PC2);
            Controls.Add(PC3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(step4);
            Controls.Add(step3);
            Controls.Add(step2);
            Controls.Add(instrBox4);
            Controls.Add(instrBox3);
            Controls.Add(instrBox2);
            Controls.Add(instrBox1);
            Controls.Add(Reset);
            Controls.Add(auto);
            Controls.Add(step1);
            Controls.Add(generate);
            Name = "GUI";
            Text = "CE4302 P1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button generate;
        private Button step1;
        private Button auto;
        private Button Reset;
        private TextBox instrBox1;
        private TextBox instrBox2;
        private TextBox instrBox3;
        private TextBox instrBox4;
        private Button step2;
        private Button step3;
        private Button step4;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label PC3;
        private Label PC2;
        private Label PC1;
        private Label PC4;
        private Label label5;
    }
}