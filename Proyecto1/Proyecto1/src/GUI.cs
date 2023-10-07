using System.ComponentModel;
using System.Data;
using static Proyecto1.Memory;

namespace Proyecto1
{
    /// <summary>
    /// Represents the main GUI form for the Proyecto1 application.
    /// </summary>
    public partial class GUI : Form
    {
        private List<string> instrList1;
        private List<string> instrList2;
        private List<string> instrList3;
        private ProcessingElement pe1;
        private ProcessingElement pe2;
        private ProcessingElement pe3;
        private Cache cache1;
        private Cache cache2;
        private Cache cache3;
        private Memory memory;
        private TopLevel TopLvl;


        /// <summary>
        /// Initializes a new instance of the <see cref="GUI"/> class.
        /// </summary>
        public GUI()
        {
            instrList1 = new List<string>();
            instrList2 = new List<string>();
            instrList3 = new List<string>();
            TopLvl = new TopLevel("MESI");
            pe1 = TopLvl.PE1;
            pe2 = TopLvl.PE2;
            pe3 = TopLvl.PE3;
            cache1 = TopLvl.Cache1;
            cache2 = TopLvl.Cache2;
            cache3 = TopLvl.Cache3;
            memory = TopLvl.Memory;
            InitializeComponent();
            step1.Enabled = false;
            step2.Enabled = false;
            step3.Enabled = false;
            auto1.Enabled = false;
            auto2.Enabled = false;
            auto3.Enabled = false;
            ExecuteAllBtn.Enabled = false;
            protocol.SelectedIndex = 0;

            ConfigDataView1();
            ConfigDataView2();
            ConfigDataView3();
            ConfigRegs1();
            ConfigRegs2();
            ConfigRegs3();
            ConfigMem();
            SetCacheLines();
            SetRegs();
            SetMem();
        }

        /// <summary>
        /// Configures the Cache1DataView.
        /// </summary>
        private void ConfigDataView1()
        {
            Cache1DataView.AutoGenerateColumns = false;

            Cache1DataView.ColumnAdded += (sender, e) =>
            {
                e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            };

            // data array
            for (int i = 0; i < 4; i++)
            {
                DataGridViewTextBoxColumn column = new()
                {
                    DataPropertyName = $"Data{i}", // bind to data[i]
                    HeaderText = $"Block {i}", // Column header text
                    Resizable = DataGridViewTriState.False
                };
                // Add the column to the DataGridView
                Cache1DataView.Columns.Add(column);
            }
            // state
            DataGridViewColumn stateMachineColumn = new(new StateMachineCell())
            {
                DataPropertyName = "StateMachine", // Bind to StateMachine property
                HeaderText = "State" // Column header text
            };
            Cache1DataView.Columns.Add(stateMachineColumn);

            // configuration
            Cache1DataView.ReadOnly = true;
            Cache1DataView.RowHeadersVisible = false;
            Cache1DataView.AllowUserToResizeRows = false;
            Cache1DataView.AllowUserToResizeColumns = false;
            Cache1DataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cache1DataView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        /// <summary>
        /// Configures the Cache2DataView.
        /// </summary>
        private void ConfigDataView2()
        {
            Cache2DataView.AutoGenerateColumns = false;

            Cache2DataView.ColumnAdded += (sender, e) =>
            {
                e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            };

            // data array
            for (int i = 0; i < 4; i++)
            {
                DataGridViewTextBoxColumn column = new()
                {
                    DataPropertyName = $"Data{i}", // bind to data[i]
                    HeaderText = $"Block {i}", // Column header text
                    Resizable = DataGridViewTriState.False
                };
                // Add the column to the DataGridView
                Cache2DataView.Columns.Add(column);
            }
            // state
            DataGridViewColumn stateMachineColumn = new(new StateMachineCell())
            {
                DataPropertyName = "StateMachine", // Bind to StateMachine property
                HeaderText = "State" // Column header text
            };
            Cache2DataView.Columns.Add(stateMachineColumn);

            // configuration
            Cache2DataView.ReadOnly = true;
            Cache2DataView.RowHeadersVisible = false;
            Cache2DataView.AllowUserToResizeRows = false;
            Cache2DataView.AllowUserToResizeColumns = false;
            Cache2DataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cache2DataView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        /// <summary>
        /// Configures the Cache2DataView.
        /// </summary>
        private void ConfigDataView3()
        {
            Cache3DataView.AutoGenerateColumns = false;

            Cache3DataView.ColumnAdded += (sender, e) =>
            {
                e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            };

            // data array
            for (int i = 0; i < 4; i++)
            {
                DataGridViewTextBoxColumn column = new()
                {
                    DataPropertyName = $"Data{i}", // bind to data[i]
                    HeaderText = $"Block {i}", // Column header text
                    Resizable = DataGridViewTriState.False
                };
                // Add the column to the DataGridView
                Cache3DataView.Columns.Add(column);
            }

            // state
            DataGridViewColumn stateMachineColumn = new(new StateMachineCell())
            {
                DataPropertyName = "StateMachine", // Bind to StateMachine property
                HeaderText = "State" // Column header text
            };
            Cache3DataView.Columns.Add(stateMachineColumn);

            // configuration
            Cache3DataView.ReadOnly = true;
            Cache3DataView.RowHeadersVisible = false;
            Cache3DataView.AllowUserToResizeRows = false;
            Cache3DataView.AllowUserToResizeColumns = false;
            Cache3DataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cache3DataView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        /// <summary>
        /// Configures the Regs1 DataView.
        /// </summary>
        private void ConfigRegs1()
        {
            Regs1.AutoGenerateColumns = false;

            Regs1.ColumnAdded += (sender, e) =>
            {
                e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            };

            // data array
            for (int i = 0; i < 9; i++)
            {
                DataGridViewTextBoxColumn column = new()
                {
                    DataPropertyName = $"Reg{i}", // bind to data[i]
                    HeaderText = $"r{i}", // Column header text
                    Resizable = DataGridViewTriState.False
                };
                // Add the column to the DataGridView
                Regs1.Columns.Add(column);
            }

            // configuration
            Regs1.ReadOnly = true;
            Regs1.RowHeadersVisible = false;
            Regs1.AllowUserToResizeRows = false;
            Regs1.AllowUserToResizeColumns = false;
            Regs1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Regs1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        /// <summary>
        /// Configures the Regs2 DataView.
        /// </summary>
        private void ConfigRegs2()
        {
            Regs2.AutoGenerateColumns = false;

            Regs2.ColumnAdded += (sender, e) =>
            {
                e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            };

            // data array
            for (int i = 0; i < 9; i++)
            {
                DataGridViewTextBoxColumn column = new()
                {
                    DataPropertyName = $"Reg{i}", // bind to data[i]
                    HeaderText = $"r{i}", // Column header text
                    Resizable = DataGridViewTriState.False
                };
                // Add the column to the DataGridView
                Regs2.Columns.Add(column);
            }

            // configuration
            Regs2.ReadOnly = true;
            Regs2.RowHeadersVisible = false;
            Regs2.AllowUserToResizeRows = false;
            Regs2.AllowUserToResizeColumns = false;
            Regs2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Regs2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        /// <summary>
        /// Configures the Regs3 DataView.
        /// </summary>
        private void ConfigRegs3()
        {
            Regs3.AutoGenerateColumns = false;

            Regs3.ColumnAdded += (sender, e) =>
            {
                e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            };

            // data array
            for (int i = 0; i < 9; i++)
            {
                DataGridViewTextBoxColumn column = new()
                {
                    DataPropertyName = $"Reg{i}", // bind to data[i]
                    HeaderText = $"r{i}", // Column header text
                    Resizable = DataGridViewTriState.False
                };
                // Add the column to the DataGridView
                Regs3.Columns.Add(column);
            }

            // configuration
            Regs3.ReadOnly = true;
            Regs3.RowHeadersVisible = false;
            Regs3.AllowUserToResizeRows = false;
            Regs3.AllowUserToResizeColumns = false;
            Regs3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Regs3.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        /// <summary>
        /// Configures the MemDataView DataView.
        /// </summary>
        private void ConfigMem()
        {
            MemDataView.AutoGenerateColumns = false;

            MemDataView.ColumnAdded += (sender, e) =>
            {
                e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            };

            // line number
            DataGridViewTextBoxColumn columnLine = new()
            {
                DataPropertyName = $"LineNumber",
                HeaderText = $"Line", // Column header text
                Resizable = DataGridViewTriState.False
            };
            // Add the column to the DataGridView
            MemDataView.Columns.Add(columnLine);

            // data array
            for (int i = 0; i < 4; i++)
            {
                DataGridViewTextBoxColumn column = new()
                {
                    DataPropertyName = $"Data{i}",
                    HeaderText = $"Block {i}", // Column header text
                    Resizable = DataGridViewTriState.False
                };
                // Add the column to the DataGridView
                MemDataView.Columns.Add(column);
            }

            // configuration
            MemDataView.ReadOnly = true;
            MemDataView.RowHeadersVisible = false;
            MemDataView.AllowUserToResizeRows = false;
            MemDataView.AllowUserToResizeColumns = false;
            MemDataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            MemDataView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        /// <summary>
        /// Cell for the cache line State
        /// </summary>
        public class StateMachineCell : DataGridViewTextBoxCell
        {
            protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
            {
                // Check if the value is a StateMachine object
                if (value is StateMachine stateMachine)
                {
                    // Format the state as a string
                    return stateMachine.GetCurrentState().ToString();
                }
                return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
            }
        }

        /// <summary>
        /// Set data sources for cache DataViews
        /// </summary>
        private void SetCacheLines()
        {
            Cache1DataView.DataSource = cache1.cacheLines;
            Cache2DataView.DataSource = cache2.cacheLines;
            Cache3DataView.DataSource = cache3.cacheLines;
        }

        /// <summary>
        /// Set data sources for memory DataView
        /// </summary>
        private void SetMem()
        {
            MemDataView.DataSource = memory.memory;
        }

        /// <summary>
        /// Set data sources for register DataViews
        /// </summary>
        private void SetRegs()
        {
            List<ProcessingElement> list1 = new()
            {
                pe1
            };
            List<ProcessingElement> list2 = new()
            {
                pe2
            };
            List<ProcessingElement> list3 = new()
            {
                pe3
            };
            Regs1.DataSource = list1;
            Regs2.DataSource = list2;
            Regs3.DataSource = list3;
        }

        /// <summary>
        /// Refreshes the cache DataViews.
        /// </summary>
        private void CacheRefresh()
        {
            Cache1DataView.Refresh();
            Cache2DataView.Refresh();
            Cache3DataView.Refresh();
        }

        /// <summary>
        /// Refreshes the registers DataViews.
        /// </summary>
        private void RegsRefresh()
        {
            Regs1.Refresh();
            Regs2.Refresh();
            Regs3.Refresh();
        }

        /// <summary>
        /// Refreshes the memory DataViews.
        /// </summary>
        private void MemRefresh()
        {
            MemDataView.Refresh();
        }

        /// <summary>
        /// Handles the click event for the "Generate" button.
        /// Generates instructions for all processing elements and displays them in respective text boxes.
        /// </summary>
        private void generate_Click(object sender, EventArgs e)
        {
            LoggerT.Start();
            TopLvl.GenerateInstructions();
            instrList1 = pe1.InstrList;
            instrList2 = pe2.InstrList;
            instrList3 = pe3.InstrList;
            string textInstr1 = "";
            string textInstr2 = "";
            string textInstr3 = "";
            for (int i = 0; i < instrList1.Count; i++)
            {
                textInstr1 += i + ". " + instrList1[i] + Environment.NewLine;
            }
            for (int i = 0; i < instrList2.Count; i++)
            {
                textInstr2 += i + ". " + instrList2[i] + Environment.NewLine;
            }
            for (int i = 0; i < instrList3.Count; i++)
            {
                textInstr3 += i + ". " + instrList3[i] + Environment.NewLine;
            }
            instrBox1.Text = textInstr1;
            instrBox2.Text = textInstr2;
            instrBox3.Text = textInstr3;
            generate.Enabled = false;
            step1.Enabled = true;
            step2.Enabled = true;
            step3.Enabled = true;
            auto1.Enabled = true;
            auto2.Enabled = true;
            auto3.Enabled = true;
            ExecuteAllBtn.Enabled = true;
        }

        /// <summary>
        /// Handles the click event for the "Reset" button.
        /// </summary>
        private void reset_Click(object sender, EventArgs e)
        {
            TopLvl.Clean();
            step1.Enabled = false;
            step2.Enabled = false;
            step3.Enabled = false;
            auto1.Enabled = false;
            auto2.Enabled = false;
            auto3.Enabled = false;
            FillMemBtn.Enabled = true;
            ExecuteAllBtn.Enabled = false;
            generate.Enabled = true;
            instrBox1.Text = "";
            instrBox2.Text = "";
            instrBox3.Text = "";
            PC1.Text = "";
            PC2.Text = "";
            PC3.Text = "";
            instrList1 = pe1.InstrList;
            instrList2 = pe2.InstrList;
            instrList3 = pe3.InstrList;
            protocol.SelectedIndex = -1;
            protocol.Enabled = true;
            Cache1DataView.DataSource = null;
            Cache2DataView.DataSource = null;
            Cache3DataView.DataSource = null;
            Regs1.DataSource = null;
            Regs2.DataSource = null;
            Regs3.DataSource = null;
            MemDataView.DataSource = null;
            LoggerT.FinishLog();
        }

        /// <summary>
        /// Event handler for the Clean Data button.
        /// </summary>
        /// <param name="sender">The sender of the event, which is a Button.</param>
        /// <param name="e">The event arguments.</param>
        private void CleanData_Click(object sender, EventArgs e)
        {
            TopLvl.CleanData();
            generate.Enabled = false;
            PC1.Text = "";
            PC2.Text = "";
            PC3.Text = "";
            instrList1 = pe1.InstrList;
            instrList2 = pe2.InstrList;
            instrList3 = pe3.InstrList;
            protocol.Enabled = true;
            ExecuteAllBtn.Enabled = true;
            step1.Enabled = true;
            step2.Enabled = true;
            step3.Enabled = true;
            auto1.Enabled = true;
            auto2.Enabled = true;
            auto3.Enabled = true;
            Cache1DataView.DataSource = null;
            Cache2DataView.DataSource = null;
            Cache3DataView.DataSource = null;
            Regs1.DataSource = null;
            Regs2.DataSource = null;
            Regs3.DataSource = null;
            MemDataView.DataSource = null;
            LoggerT.FinishLog();
            LoggerT.Start();
        }

        /// <summary>
        /// Validates if instructions have been generated for all processing elements.
        /// Displays an error message if instructions are missing.
        /// </summary>
        /// <returns>True if instructions are available; otherwise, false.</returns>
        private bool validateInstr()
        {
            if (instrList1.Count == 0 || instrList2.Count == 0 || instrList3.Count == 0)
            {
                MessageBox.Show("You must generate the instructions first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Handles the click event for the "Step 1" button.
        /// Validates instructions and executes the next instruction for Processing Element 1.
        /// </summary>
        private void step1_Click(object sender, EventArgs e)
        {
            if (validateInstr())
            {
                SetCacheLines();
                SetRegs();
                SetMem();

                ExecuteAllBtn.Enabled = false;
                if (pe1.PC == instrList1.Count - 1)
                {
                    step1.Enabled = false;
                    PC1.Text = "" + pe1.PC;
                }
                else
                {
                    protocol.Enabled = false;
                    auto1.Enabled = false;
                    FillMemBtn.Enabled = false;
                    PC1.Text = "" + pe1.PC;
                    pe1.ExecuteInstr();
                }
                CacheRefresh();
                RegsRefresh();
                MemRefresh();
            }
        }

        /// <summary>
        /// Handles the click event for the "Step 2" button.
        /// Validates instructions and executes the next instruction for Processing Element 2.
        /// </summary>
        private void step2_Click(object sender, EventArgs e)
        {
            if (validateInstr())
            {
                SetCacheLines();
                SetRegs();
                SetMem();

                ExecuteAllBtn.Enabled = false;
                if (pe2.PC == instrList2.Count - 1)
                {
                    step2.Enabled = false;
                    PC2.Text = "" + pe2.PC;
                }
                else
                {
                    protocol.Enabled = false;
                    auto2.Enabled = false;
                    FillMemBtn.Enabled = false;
                    PC2.Text = "" + pe2.PC;
                    pe2.ExecuteInstr();
                }
                CacheRefresh();
                RegsRefresh();
                MemRefresh();
            }
        }

        /// <summary>
        /// Handles the click event for the "Step 3" button.
        /// Validates instructions and executes the next instruction for Processing Element 3.
        /// </summary>
        private void step3_Click(object sender, EventArgs e)
        {
            if (validateInstr())
            {
                SetCacheLines();
                SetRegs();
                SetMem();

                ExecuteAllBtn.Enabled = false;
                if (pe3.PC == instrList3.Count - 1)
                {
                    step3.Enabled = false;
                    PC3.Text = "" + pe3.PC;
                }
                else
                {
                    protocol.Enabled = false;
                    auto3.Enabled = false;
                    FillMemBtn.Enabled = false;
                    PC3.Text = "" + pe3.PC;
                    pe3.ExecuteInstr();
                }
                CacheRefresh();
                RegsRefresh();
                MemRefresh();
            }
        }

        /// <summary>
        /// Handles the click event for the "Auto1" button.
        /// </summary>
        private void auto1_Click(object sender, EventArgs e)
        {
            if (validateInstr())
            {
                SetCacheLines();
                SetRegs();
                SetMem();

                ExecuteAllBtn.Enabled = false;
                protocol.Enabled = false;
                step1.Enabled = false;
                auto1.Enabled = false;
                FillMemBtn.Enabled = false;
                pe1.ExecuteAll();
                PC1.Text = "" + (pe1.PC - 1);
                CacheRefresh();
                RegsRefresh();
                MemRefresh();
            }
        }
        /// <summary>
        /// Handles the click event for the "Auto2" button.
        /// </summary>
        private void auto2_Click(object sender, EventArgs e)
        {
            if (validateInstr())
            {
                SetCacheLines();
                SetRegs();
                SetMem();

                ExecuteAllBtn.Enabled = false;
                protocol.Enabled = false;
                step2.Enabled = false;
                auto2.Enabled = false;
                FillMemBtn.Enabled = false;
                pe2.ExecuteAll();
                PC2.Text = "" + (pe2.PC - 1);
                CacheRefresh();
                RegsRefresh();
                MemRefresh();
            }
        }
        /// <summary>
        /// Handles the click event for the "Auto3" button.
        /// </summary>
        private void auto3_Click(object sender, EventArgs e)
        {
            if (validateInstr())
            {
                SetCacheLines();
                SetRegs();
                SetMem();

                ExecuteAllBtn.Enabled = false;
                protocol.Enabled = false;
                step3.Enabled = false;
                auto3.Enabled = false;
                FillMemBtn.Enabled = false;
                pe3.ExecuteAll();
                PC3.Text = "" + (pe3.PC - 1);
                CacheRefresh();
                RegsRefresh();
                MemRefresh();
            }
        }

        /// <summary>
        /// Event handler for the Execute All button.
        /// </summary>
        /// <param name="sender">The sender of the event, which is a Button.</param>
        /// <param name="e">The event arguments.</param>
        private void ExecuteAllBtn_Click(object sender, EventArgs e)
        {
            SetCacheLines();
            SetRegs();
            SetMem();

            step1.Enabled = false;
            step2.Enabled = false;
            step3.Enabled = false;
            auto1.Enabled = false;
            auto2.Enabled = false;
            auto3.Enabled = false;
            ExecuteAllBtn.Enabled = false;
            FillMemBtn.Enabled = false;
            TopLvl.StartThreads();
            CacheRefresh();
            RegsRefresh();
            MemRefresh();
        }

        /// <summary>
        /// Event handler for the selected index change in the protocol ComboBox.
        /// </summary>
        /// <param name="sender">The sender of the event, which is a ComboBox.</param>
        /// <param name="e">The event arguments.</param>
        private void protocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender; // Cast the sender to ComboBox

            if (comboBox.SelectedItem != null)
            {
                string selectedValue = comboBox.SelectedItem.ToString();
                TopLvl.SetProtocol(selectedValue);
                step1.Enabled = true;
                step2.Enabled = true;
                step3.Enabled = true;
                auto1.Enabled = true;
                auto2.Enabled = true;
                auto3.Enabled = true;
            }
        }

        /// <summary>
        /// Event handler for the Report Button button.
        /// </summary>
        /// <param name="sender">The sender of the event, which is a Button.</param>
        /// <param name="e">The event arguments.</param>
        private void ReportButton_Click(object sender, EventArgs e)
        {
            LoggerT.FinishLog();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
        }

        private void FillMemBtn_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            // Recorrer la lista y randomizar cada elemento
            foreach (MemByteArray array in memory.memory)
            {
                for (int i = 0; i < array.Data.Length; i++)
                {
                    // Generar un valor aleatorio para cada elemento del array
                    array.Data[i] = (byte)random.Next(256); // Suponemos que los valores están en el rango de 0 a 255
                }
            }
            MemRefresh();
        }
    }
}
