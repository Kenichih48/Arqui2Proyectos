using System.ComponentModel;
using System.Data;

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

            ConfigDataViews();
            Cache1DataView.DataSource = cache1.cacheLines;
        }

        /// <summary>
        /// Configures the DataViews.
        /// </summary>
        private void ConfigDataViews()
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
        /// Handles the click event for the "Generate" button.
        /// Generates instructions for all processing elements and displays them in respective text boxes.
        /// </summary>
        private void generate_Click(object sender, EventArgs e)
        {
            LoggerT.Start();
            pe1.GenerateInstructions();
            instrList1 = pe1.InstrList;
            pe2.GenerateInstructions();
            instrList2 = pe2.InstrList;
            pe3.GenerateInstructions();
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
                Cache1DataView.DataSource = cache1.cacheLines;

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
                    PC1.Text = "" + pe1.PC;
                    pe1.ExecuteInstr();
                }
                Cache1DataView.Refresh();
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
                Cache1DataView.DataSource = cache1.cacheLines;

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
                    PC2.Text = "" + pe2.PC;
                    pe2.ExecuteInstr();
                }
                Cache1DataView.Refresh();
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
                Cache1DataView.DataSource = cache1.cacheLines;

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
                    PC3.Text = "" + pe3.PC;
                    pe3.ExecuteInstr();
                }
                Cache1DataView.Refresh();
            }
        }

        /// <summary>
        /// Handles the click event for the "Auto1" button.
        /// </summary>
        private void auto1_Click(object sender, EventArgs e)
        {
            if (validateInstr())
            {
                Cache1DataView.DataSource = cache1.cacheLines;

                ExecuteAllBtn.Enabled = false;
                protocol.Enabled = false;
                step1.Enabled = false;
                auto1.Enabled = false;
                pe1.ExecuteAll();
                PC1.Text = "" + (pe1.PC - 1);
                Cache1DataView.Refresh();
            }
        }
        /// <summary>
        /// Handles the click event for the "Auto2" button.
        /// </summary>
        private void auto2_Click(object sender, EventArgs e)
        {
            if (validateInstr())
            {
                Cache1DataView.DataSource = cache1.cacheLines;

                ExecuteAllBtn.Enabled = false;
                protocol.Enabled = false;
                step2.Enabled = false;
                auto2.Enabled = false;
                pe2.ExecuteAll();
                PC2.Text = "" + (pe2.PC - 1);
                Cache1DataView.Refresh();
            }
        }
        /// <summary>
        /// Handles the click event for the "Auto3" button.
        /// </summary>
        private void auto3_Click(object sender, EventArgs e)
        {
            if (validateInstr())
            {
                Cache1DataView.DataSource = cache1.cacheLines;

                ExecuteAllBtn.Enabled = false;
                protocol.Enabled = false;
                step3.Enabled = false;
                auto3.Enabled = false;
                pe3.ExecuteAll();
                PC3.Text = "" + (pe3.PC - 1);
                Cache1DataView.Refresh();
            }
        }

        /// <summary>
        /// Event handler for the Execute All button.
        /// </summary>
        /// <param name="sender">The sender of the event, which is a Button.</param>
        /// <param name="e">The event arguments.</param>
        private void ExecuteAllBtn_Click(object sender, EventArgs e)
        {
            Cache1DataView.DataSource = cache1.cacheLines;
            step1.Enabled = false;
            step2.Enabled = false;
            step3.Enabled = false;
            auto1.Enabled = false;
            auto2.Enabled = false;
            auto3.Enabled = false;
            ExecuteAllBtn.Enabled = false;
            LoggerT.Start();
            TopLvl.StartThreads();
            Cache1DataView.Refresh();
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
    }
}
