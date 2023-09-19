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
            auto1 = new Button();
            Reset = new Button();
            instrBox1 = new TextBox();
            instrBox2 = new TextBox();
            instrBox3 = new TextBox();
            step2 = new Button();
            step3 = new Button();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            PC3 = new Label();
            PC2 = new Label();
            PC1 = new Label();
            label5 = new Label();
            auto2 = new Button();
            auto3 = new Button();
            protocol = new ComboBox();
            SuspendLayout();
            // 
            // generate
            // 
            generate.BackColor = SystemColors.Control;
            generate.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            generate.Location = new Point(34, 12);
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
            step1.Location = new Point(176, 330);
            step1.Name = "step1";
            step1.Size = new Size(97, 32);
            step1.TabIndex = 1;
            step1.Text = "Step";
            step1.UseVisualStyleBackColor = false;
            step1.Click += step1_Click;
            // 
            // auto1
            // 
            auto1.BackColor = SystemColors.Control;
            auto1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            auto1.Location = new Point(176, 297);
            auto1.Name = "auto1";
            auto1.Size = new Size(97, 27);
            auto1.TabIndex = 2;
            auto1.Text = "Start";
            auto1.UseVisualStyleBackColor = false;
            auto1.Click += auto1_Click;
            // 
            // Reset
            // 
            Reset.BackColor = SystemColors.Control;
            Reset.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Reset.Location = new Point(48, 46);
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
            instrBox1.Location = new Point(12, 119);
            instrBox1.Multiline = true;
            instrBox1.Name = "instrBox1";
            instrBox1.Size = new Size(158, 254);
            instrBox1.TabIndex = 4;
            // 
            // instrBox2
            // 
            instrBox2.Enabled = false;
            instrBox2.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            instrBox2.Location = new Point(12, 379);
            instrBox2.Multiline = true;
            instrBox2.Name = "instrBox2";
            instrBox2.Size = new Size(158, 254);
            instrBox2.TabIndex = 5;
            // 
            // instrBox3
            // 
            instrBox3.Enabled = false;
            instrBox3.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            instrBox3.Location = new Point(12, 639);
            instrBox3.Multiline = true;
            instrBox3.Name = "instrBox3";
            instrBox3.Size = new Size(158, 254);
            instrBox3.TabIndex = 6;
            // 
            // step2
            // 
            step2.BackColor = SystemColors.Control;
            step2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            step2.Location = new Point(176, 601);
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
            step3.Location = new Point(176, 860);
            step3.Name = "step3";
            step3.Size = new Size(97, 32);
            step3.TabIndex = 9;
            step3.Text = "Step";
            step3.UseVisualStyleBackColor = false;
            step3.Click += step3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(176, 273);
            label2.Name = "label2";
            label2.Size = new Size(154, 21);
            label2.TabIndex = 12;
            label2.Text = "Current Instruction #";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(176, 547);
            label1.Name = "label1";
            label1.Size = new Size(154, 21);
            label1.TabIndex = 13;
            label1.Text = "Current Instruction #";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(176, 803);
            label3.Name = "label3";
            label3.Size = new Size(154, 21);
            label3.TabIndex = 14;
            label3.Text = "Current Instruction #";
            // 
            // PC3
            // 
            PC3.AutoSize = true;
            PC3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PC3.Location = new Point(336, 803);
            PC3.Name = "PC3";
            PC3.Size = new Size(14, 21);
            PC3.TabIndex = 17;
            PC3.Text = " ";
            // 
            // PC2
            // 
            PC2.AutoSize = true;
            PC2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PC2.Location = new Point(336, 547);
            PC2.Name = "PC2";
            PC2.Size = new Size(14, 21);
            PC2.TabIndex = 18;
            PC2.Text = " ";
            // 
            // PC1
            // 
            PC1.AutoSize = true;
            PC1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PC1.Location = new Point(336, 273);
            PC1.Name = "PC1";
            PC1.Size = new Size(14, 21);
            PC1.TabIndex = 19;
            PC1.Text = " ";
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
            // auto2
            // 
            auto2.BackColor = SystemColors.Control;
            auto2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            auto2.Location = new Point(176, 571);
            auto2.Name = "auto2";
            auto2.Size = new Size(97, 27);
            auto2.TabIndex = 22;
            auto2.Text = "Start";
            auto2.UseVisualStyleBackColor = false;
            auto2.Click += auto2_Click;
            // 
            // auto3
            // 
            auto3.BackColor = SystemColors.Control;
            auto3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            auto3.Location = new Point(176, 827);
            auto3.Name = "auto3";
            auto3.Size = new Size(97, 27);
            auto3.TabIndex = 23;
            auto3.Text = "Start";
            auto3.UseVisualStyleBackColor = false;
            auto3.Click += auto3_Click;
            // 
            // protocol
            // 
            protocol.DropDownStyle = ComboBoxStyle.DropDownList;
            protocol.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            protocol.FormattingEnabled = true;
            protocol.Items.AddRange(new object[] { "MESI", "MOESI" });
            protocol.Location = new Point(34, 79);
            protocol.Name = "protocol";
            protocol.Size = new Size(121, 29);
            protocol.TabIndex = 24;
            protocol.SelectedIndexChanged += protocol_SelectedIndexChanged;
            // 
            // GUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(1434, 905);
            Controls.Add(protocol);
            Controls.Add(auto3);
            Controls.Add(auto2);
            Controls.Add(label5);
            Controls.Add(PC1);
            Controls.Add(PC2);
            Controls.Add(PC3);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(step3);
            Controls.Add(step2);
            Controls.Add(instrBox3);
            Controls.Add(instrBox2);
            Controls.Add(instrBox1);
            Controls.Add(Reset);
            Controls.Add(auto1);
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
        private Button auto1;
        private Button Reset;
        private TextBox instrBox1;
        private TextBox instrBox2;
        private TextBox instrBox3;
        private Button step2;
        private Button step3;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label PC3;
        private Label PC2;
        private Label PC1;
        private Label label5;
        private Button auto2;
        private Button auto3;
        private ComboBox protocol;
    }
}