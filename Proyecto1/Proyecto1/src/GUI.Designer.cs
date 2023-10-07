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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
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
            CleanDataButton = new Button();
            ExecuteAllBtn = new Button();
            Cache1DataView = new DataGridView();
            Cache2DataView = new DataGridView();
            Cache3DataView = new DataGridView();
            dataGridView1 = new DataGridView();
            fontDialog1 = new FontDialog();
            Regs1 = new DataGridView();
            Regs2 = new DataGridView();
            Regs3 = new DataGridView();
            MemoryLbl = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            ReportButton = new Button();
            ((System.ComponentModel.ISupportInitialize)Cache1DataView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Cache2DataView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Cache3DataView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Regs1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Regs2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Regs3).BeginInit();
            SuspendLayout();
            // 
            // generate
            // 
            generate.BackColor = SystemColors.Control;
            generate.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            generate.Location = new Point(12, 12);
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
            Reset.Location = new Point(12, 48);
            Reset.Name = "Reset";
            Reset.Size = new Size(97, 27);
            Reset.TabIndex = 3;
            Reset.Text = "Clean All";
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
            label5.Location = new Point(416, -1);
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
            protocol.Location = new Point(144, 13);
            protocol.Name = "protocol";
            protocol.Size = new Size(121, 29);
            protocol.TabIndex = 24;
            protocol.SelectedIndexChanged += protocol_SelectedIndexChanged;
            // 
            // CleanDataButton
            // 
            CleanDataButton.BackColor = SystemColors.Control;
            CleanDataButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CleanDataButton.Location = new Point(115, 48);
            CleanDataButton.Name = "CleanDataButton";
            CleanDataButton.Size = new Size(97, 27);
            CleanDataButton.TabIndex = 25;
            CleanDataButton.Text = "Clean Data";
            CleanDataButton.UseVisualStyleBackColor = false;
            CleanDataButton.Click += CleanData_Click;
            // 
            // ExecuteAllBtn
            // 
            ExecuteAllBtn.BackColor = SystemColors.Control;
            ExecuteAllBtn.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ExecuteAllBtn.Location = new Point(12, 86);
            ExecuteAllBtn.Name = "ExecuteAllBtn";
            ExecuteAllBtn.Size = new Size(158, 27);
            ExecuteAllBtn.TabIndex = 26;
            ExecuteAllBtn.Text = "Execute All PEs";
            ExecuteAllBtn.UseVisualStyleBackColor = false;
            ExecuteAllBtn.Click += ExecuteAllBtn_Click;
            // 
            // Cache1DataView
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Cache1DataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Cache1DataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Cache1DataView.DefaultCellStyle = dataGridViewCellStyle2;
            Cache1DataView.Location = new Point(517, 201);
            Cache1DataView.Name = "Cache1DataView";
            Cache1DataView.RowHeadersWidth = 51;
            Cache1DataView.RowTemplate.Height = 25;
            Cache1DataView.Size = new Size(410, 158);
            Cache1DataView.TabIndex = 27;
            // 
            // Cache2DataView
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            Cache2DataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            Cache2DataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            Cache2DataView.DefaultCellStyle = dataGridViewCellStyle4;
            Cache2DataView.Location = new Point(517, 440);
            Cache2DataView.Name = "Cache2DataView";
            Cache2DataView.RowHeadersWidth = 51;
            Cache2DataView.RowTemplate.Height = 25;
            Cache2DataView.Size = new Size(410, 158);
            Cache2DataView.TabIndex = 28;
            // 
            // Cache3DataView
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            Cache3DataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            Cache3DataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            Cache3DataView.DefaultCellStyle = dataGridViewCellStyle6;
            Cache3DataView.Location = new Point(517, 696);
            Cache3DataView.Name = "Cache3DataView";
            Cache3DataView.RowHeadersWidth = 51;
            Cache3DataView.RowTemplate.Height = 25;
            Cache3DataView.Size = new Size(410, 158);
            Cache3DataView.TabIndex = 29;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(991, 201);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(410, 623);
            dataGridView1.TabIndex = 30;
            // 
            // Regs1
            // 
            Regs1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Regs1.Location = new Point(517, 119);
            Regs1.Name = "Regs1";
            Regs1.RowHeadersWidth = 51;
            Regs1.RowTemplate.Height = 25;
            Regs1.Size = new Size(410, 76);
            Regs1.TabIndex = 31;
            // 
            // Regs2
            // 
            Regs2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Regs2.Location = new Point(517, 393);
            Regs2.Name = "Regs2";
            Regs2.RowHeadersWidth = 51;
            Regs2.RowTemplate.Height = 25;
            Regs2.Size = new Size(410, 41);
            Regs2.TabIndex = 32;
            // 
            // Regs3
            // 
            Regs3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Regs3.Location = new Point(517, 649);
            Regs3.Name = "Regs3";
            Regs3.RowHeadersWidth = 51;
            Regs3.RowTemplate.Height = 25;
            Regs3.Size = new Size(410, 41);
            Regs3.TabIndex = 33;
            // 
            // MemoryLbl
            // 
            MemoryLbl.AutoSize = true;
            MemoryLbl.Font = new Font("Yu Gothic UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            MemoryLbl.Location = new Point(1135, 154);
            MemoryLbl.Name = "MemoryLbl";
            MemoryLbl.Size = new Size(133, 41);
            MemoryLbl.TabIndex = 34;
            MemoryLbl.Text = "Memory";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(398, 119);
            label4.Name = "label4";
            label4.Size = new Size(113, 32);
            label4.TabIndex = 35;
            label4.Text = "Registers";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(398, 393);
            label6.Name = "label6";
            label6.Size = new Size(113, 32);
            label6.TabIndex = 36;
            label6.Text = "Registers";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(398, 649);
            label7.Name = "label7";
            label7.Size = new Size(113, 32);
            label7.TabIndex = 37;
            label7.Text = "Registers";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(431, 201);
            label8.Name = "label8";
            label8.Size = new Size(80, 32);
            label8.TabIndex = 38;
            label8.Text = "Cache";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(431, 440);
            label9.Name = "label9";
            label9.Size = new Size(80, 32);
            label9.TabIndex = 39;
            label9.Text = "Cache";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(431, 696);
            label10.Name = "label10";
            label10.Size = new Size(80, 32);
            label10.TabIndex = 40;
            label10.Text = "Cache";
            // 
            // ReportButton
            // 
            ReportButton.BackColor = SystemColors.Control;
            ReportButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ReportButton.Location = new Point(1271, 12);
            ReportButton.Name = "ReportButton";
            ReportButton.Size = new Size(151, 27);
            ReportButton.TabIndex = 41;
            ReportButton.Text = "Generate Report";
            ReportButton.UseVisualStyleBackColor = false;
            ReportButton.Click += ReportButton_Click;
            // 
            // GUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(1434, 926);
            Controls.Add(ReportButton);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(MemoryLbl);
            Controls.Add(Regs3);
            Controls.Add(Regs2);
            Controls.Add(Regs1);
            Controls.Add(dataGridView1);
            Controls.Add(Cache3DataView);
            Controls.Add(Cache2DataView);
            Controls.Add(Cache1DataView);
            Controls.Add(ExecuteAllBtn);
            Controls.Add(CleanDataButton);
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
            Load += GUI_Load;
            ((System.ComponentModel.ISupportInitialize)Cache1DataView).EndInit();
            ((System.ComponentModel.ISupportInitialize)Cache2DataView).EndInit();
            ((System.ComponentModel.ISupportInitialize)Cache3DataView).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Regs1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Regs2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Regs3).EndInit();
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
        private Button CleanDataButton;
        private Button ExecuteAllBtn;
        private DataGridView Cache1DataView;
        private DataGridView Cache2DataView;
        private DataGridView Cache3DataView;
        private DataGridView dataGridView1;
        private FontDialog fontDialog1;
        private DataGridView Regs1;
        private DataGridView Regs2;
        private DataGridView Regs3;
        private Label MemoryLbl;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button ReportButton;
    }
}