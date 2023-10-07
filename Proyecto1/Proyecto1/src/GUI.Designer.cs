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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
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
            MemDataView = new DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)MemDataView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Regs1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Regs2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Regs3).BeginInit();
            SuspendLayout();
            // 
            // generate
            // 
            generate.BackColor = SystemColors.Control;
            generate.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            generate.Location = new Point(14, 16);
            generate.Margin = new Padding(3, 4, 3, 4);
            generate.Name = "generate";
            generate.Size = new Size(144, 37);
            generate.TabIndex = 0;
            generate.Text = "Generate Code";
            generate.UseVisualStyleBackColor = false;
            generate.Click += generate_Click;
            // 
            // step1
            // 
            step1.BackColor = SystemColors.Control;
            step1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            step1.Location = new Point(201, 440);
            step1.Margin = new Padding(3, 4, 3, 4);
            step1.Name = "step1";
            step1.Size = new Size(111, 43);
            step1.TabIndex = 1;
            step1.Text = "Step";
            step1.UseVisualStyleBackColor = false;
            step1.Click += step1_Click;
            // 
            // auto1
            // 
            auto1.BackColor = SystemColors.Control;
            auto1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            auto1.Location = new Point(201, 396);
            auto1.Margin = new Padding(3, 4, 3, 4);
            auto1.Name = "auto1";
            auto1.Size = new Size(111, 36);
            auto1.TabIndex = 2;
            auto1.Text = "Start";
            auto1.UseVisualStyleBackColor = false;
            auto1.Click += auto1_Click;
            // 
            // Reset
            // 
            Reset.BackColor = SystemColors.Control;
            Reset.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Reset.Location = new Point(14, 64);
            Reset.Margin = new Padding(3, 4, 3, 4);
            Reset.Name = "Reset";
            Reset.Size = new Size(111, 36);
            Reset.TabIndex = 3;
            Reset.Text = "Clean All";
            Reset.UseVisualStyleBackColor = false;
            Reset.Click += reset_Click;
            // 
            // instrBox1
            // 
            instrBox1.Enabled = false;
            instrBox1.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            instrBox1.Location = new Point(14, 159);
            instrBox1.Margin = new Padding(3, 4, 3, 4);
            instrBox1.Multiline = true;
            instrBox1.Name = "instrBox1";
            instrBox1.Size = new Size(180, 337);
            instrBox1.TabIndex = 4;
            // 
            // instrBox2
            // 
            instrBox2.Enabled = false;
            instrBox2.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            instrBox2.Location = new Point(14, 505);
            instrBox2.Margin = new Padding(3, 4, 3, 4);
            instrBox2.Multiline = true;
            instrBox2.Name = "instrBox2";
            instrBox2.Size = new Size(180, 337);
            instrBox2.TabIndex = 5;
            // 
            // instrBox3
            // 
            instrBox3.Enabled = false;
            instrBox3.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            instrBox3.Location = new Point(14, 852);
            instrBox3.Margin = new Padding(3, 4, 3, 4);
            instrBox3.Multiline = true;
            instrBox3.Name = "instrBox3";
            instrBox3.Size = new Size(180, 337);
            instrBox3.TabIndex = 6;
            // 
            // step2
            // 
            step2.BackColor = SystemColors.Control;
            step2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            step2.Location = new Point(201, 801);
            step2.Margin = new Padding(3, 4, 3, 4);
            step2.Name = "step2";
            step2.Size = new Size(111, 43);
            step2.TabIndex = 8;
            step2.Text = "Step";
            step2.UseVisualStyleBackColor = false;
            step2.Click += step2_Click;
            // 
            // step3
            // 
            step3.BackColor = SystemColors.Control;
            step3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            step3.Location = new Point(201, 1147);
            step3.Margin = new Padding(3, 4, 3, 4);
            step3.Name = "step3";
            step3.Size = new Size(111, 43);
            step3.TabIndex = 9;
            step3.Text = "Step";
            step3.UseVisualStyleBackColor = false;
            step3.Click += step3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(201, 364);
            label2.Name = "label2";
            label2.Size = new Size(192, 28);
            label2.TabIndex = 12;
            label2.Text = "Current Instruction #";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(201, 729);
            label1.Name = "label1";
            label1.Size = new Size(192, 28);
            label1.TabIndex = 13;
            label1.Text = "Current Instruction #";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(201, 1071);
            label3.Name = "label3";
            label3.Size = new Size(192, 28);
            label3.TabIndex = 14;
            label3.Text = "Current Instruction #";
            // 
            // PC3
            // 
            PC3.AutoSize = true;
            PC3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PC3.Location = new Point(384, 1071);
            PC3.Name = "PC3";
            PC3.Size = new Size(17, 28);
            PC3.TabIndex = 17;
            PC3.Text = " ";
            // 
            // PC2
            // 
            PC2.AutoSize = true;
            PC2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PC2.Location = new Point(384, 729);
            PC2.Name = "PC2";
            PC2.Size = new Size(17, 28);
            PC2.TabIndex = 18;
            PC2.Text = " ";
            // 
            // PC1
            // 
            PC1.AutoSize = true;
            PC1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PC1.Location = new Point(384, 364);
            PC1.Name = "PC1";
            PC1.Size = new Size(17, 28);
            PC1.TabIndex = 19;
            PC1.Text = " ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(475, -1);
            label5.Name = "label5";
            label5.Size = new Size(867, 106);
            label5.TabIndex = 21;
            label5.Text = "MESI/MOESI Protocols";
            // 
            // auto2
            // 
            auto2.BackColor = SystemColors.Control;
            auto2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            auto2.Location = new Point(201, 761);
            auto2.Margin = new Padding(3, 4, 3, 4);
            auto2.Name = "auto2";
            auto2.Size = new Size(111, 36);
            auto2.TabIndex = 22;
            auto2.Text = "Start";
            auto2.UseVisualStyleBackColor = false;
            auto2.Click += auto2_Click;
            // 
            // auto3
            // 
            auto3.BackColor = SystemColors.Control;
            auto3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            auto3.Location = new Point(201, 1103);
            auto3.Margin = new Padding(3, 4, 3, 4);
            auto3.Name = "auto3";
            auto3.Size = new Size(111, 36);
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
            protocol.Location = new Point(165, 17);
            protocol.Margin = new Padding(3, 4, 3, 4);
            protocol.Name = "protocol";
            protocol.Size = new Size(138, 36);
            protocol.TabIndex = 24;
            protocol.SelectedIndexChanged += protocol_SelectedIndexChanged;
            // 
            // CleanDataButton
            // 
            CleanDataButton.BackColor = SystemColors.Control;
            CleanDataButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CleanDataButton.Location = new Point(131, 64);
            CleanDataButton.Margin = new Padding(3, 4, 3, 4);
            CleanDataButton.Name = "CleanDataButton";
            CleanDataButton.Size = new Size(111, 36);
            CleanDataButton.TabIndex = 25;
            CleanDataButton.Text = "Clean Data";
            CleanDataButton.UseVisualStyleBackColor = false;
            CleanDataButton.Click += CleanData_Click;
            // 
            // ExecuteAllBtn
            // 
            ExecuteAllBtn.BackColor = SystemColors.Control;
            ExecuteAllBtn.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ExecuteAllBtn.Location = new Point(14, 115);
            ExecuteAllBtn.Margin = new Padding(3, 4, 3, 4);
            ExecuteAllBtn.Name = "ExecuteAllBtn";
            ExecuteAllBtn.Size = new Size(181, 36);
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
            Cache1DataView.Location = new Point(591, 249);
            Cache1DataView.Margin = new Padding(3, 4, 3, 4);
            Cache1DataView.Name = "Cache1DataView";
            Cache1DataView.RowHeadersWidth = 51;
            Cache1DataView.RowTemplate.Height = 25;
            Cache1DataView.Size = new Size(469, 201);
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
            Cache2DataView.Location = new Point(591, 597);
            Cache2DataView.Margin = new Padding(3, 4, 3, 4);
            Cache2DataView.Name = "Cache2DataView";
            Cache2DataView.RowHeadersWidth = 51;
            Cache2DataView.RowTemplate.Height = 25;
            Cache2DataView.Size = new Size(469, 201);
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
            Cache3DataView.Location = new Point(591, 951);
            Cache3DataView.Margin = new Padding(3, 4, 3, 4);
            Cache3DataView.Name = "Cache3DataView";
            Cache3DataView.RowHeadersWidth = 51;
            Cache3DataView.RowTemplate.Height = 25;
            Cache3DataView.Size = new Size(469, 201);
            Cache3DataView.TabIndex = 29;
            // 
            // MemDataView
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            MemDataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            MemDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            MemDataView.DefaultCellStyle = dataGridViewCellStyle8;
            MemDataView.Location = new Point(1128, 274);
            MemDataView.Margin = new Padding(3, 4, 3, 4);
            MemDataView.Name = "MemDataView";
            MemDataView.RowHeadersWidth = 51;
            MemDataView.RowTemplate.Height = 25;
            MemDataView.Size = new Size(469, 609);
            MemDataView.TabIndex = 30;
            // 
            // Regs1
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            Regs1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            Regs1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Window;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            Regs1.DefaultCellStyle = dataGridViewCellStyle10;
            Regs1.Location = new Point(591, 159);
            Regs1.Margin = new Padding(3, 4, 3, 4);
            Regs1.Name = "Regs1";
            Regs1.RowHeadersWidth = 51;
            Regs1.RowTemplate.Height = 25;
            Regs1.Size = new Size(469, 73);
            Regs1.TabIndex = 31;
            // 
            // Regs2
            // 
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Control;
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle11.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            Regs2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            Regs2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.Window;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle12.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            Regs2.DefaultCellStyle = dataGridViewCellStyle12;
            Regs2.Location = new Point(591, 505);
            Regs2.Margin = new Padding(3, 4, 3, 4);
            Regs2.Name = "Regs2";
            Regs2.RowHeadersWidth = 51;
            Regs2.RowTemplate.Height = 25;
            Regs2.Size = new Size(469, 73);
            Regs2.TabIndex = 32;
            // 
            // Regs3
            // 
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = SystemColors.Control;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle13.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            Regs3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            Regs3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = SystemColors.Window;
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle14.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
            Regs3.DefaultCellStyle = dataGridViewCellStyle14;
            Regs3.Location = new Point(591, 865);
            Regs3.Margin = new Padding(3, 4, 3, 4);
            Regs3.Name = "Regs3";
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = SystemColors.Control;
            dataGridViewCellStyle15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle15.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            Regs3.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            Regs3.RowHeadersWidth = 51;
            Regs3.RowTemplate.Height = 25;
            Regs3.Size = new Size(469, 73);
            Regs3.TabIndex = 33;
            // 
            // MemoryLbl
            // 
            MemoryLbl.AutoSize = true;
            MemoryLbl.Font = new Font("Yu Gothic UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            MemoryLbl.Location = new Point(1297, 205);
            MemoryLbl.Name = "MemoryLbl";
            MemoryLbl.Size = new Size(164, 50);
            MemoryLbl.TabIndex = 34;
            MemoryLbl.Text = "Memory";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(455, 159);
            label4.Name = "label4";
            label4.Size = new Size(143, 41);
            label4.TabIndex = 35;
            label4.Text = "Registers";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(450, 505);
            label6.Name = "label6";
            label6.Size = new Size(143, 41);
            label6.TabIndex = 36;
            label6.Text = "Registers";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(455, 865);
            label7.Name = "label7";
            label7.Size = new Size(143, 41);
            label7.TabIndex = 37;
            label7.Text = "Registers";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(493, 249);
            label8.Name = "label8";
            label8.Size = new Size(100, 41);
            label8.TabIndex = 38;
            label8.Text = "Cache";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(493, 587);
            label9.Name = "label9";
            label9.Size = new Size(100, 41);
            label9.TabIndex = 39;
            label9.Text = "Cache";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(485, 945);
            label10.Name = "label10";
            label10.Size = new Size(100, 41);
            label10.TabIndex = 40;
            label10.Text = "Cache";
            // 
            // ReportButton
            // 
            ReportButton.BackColor = SystemColors.Control;
            ReportButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ReportButton.Location = new Point(1453, 16);
            ReportButton.Margin = new Padding(3, 4, 3, 4);
            ReportButton.Name = "ReportButton";
            ReportButton.Size = new Size(173, 36);
            ReportButton.TabIndex = 41;
            ReportButton.Text = "Generate Report";
            ReportButton.UseVisualStyleBackColor = false;
            ReportButton.Click += ReportButton_Click;
            // 
            // GUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(1639, 1055);
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
            Controls.Add(MemDataView);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "GUI";
            Text = "CE4302 P1";
            Load += GUI_Load;
            ((System.ComponentModel.ISupportInitialize)Cache1DataView).EndInit();
            ((System.ComponentModel.ISupportInitialize)Cache2DataView).EndInit();
            ((System.ComponentModel.ISupportInitialize)Cache3DataView).EndInit();
            ((System.ComponentModel.ISupportInitialize)MemDataView).EndInit();
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
        private DataGridView MemDataView;
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