using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private List<string> instrList4;
        private ProcessingElement pe1;
        private ProcessingElement pe2;
        private ProcessingElement pe3;
        private ProcessingElement pe4;

        /// <summary>
        /// Initializes a new instance of the <see cref="GUI"/> class.
        /// </summary>
        public GUI()
        {
            instrList1 = new List<string>();
            instrList2 = new List<string>();
            instrList3 = new List<string>();
            instrList4 = new List<string>();
            pe1 = new ProcessingElement(1, 7, 9);
            pe2 = new ProcessingElement(2, 7, 9);
            pe3 = new ProcessingElement(3, 7, 9);
            pe4 = new ProcessingElement(4, 7, 9);
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event for the "Generate" button.
        /// Generates instructions for all processing elements and displays them in respective text boxes.
        /// </summary>
        private void generate_Click(object sender, EventArgs e)
        {
            pe1.GenerateInstructions();
            instrList1 = pe1.InstrList;
            pe2.GenerateInstructions();
            instrList2 = pe2.InstrList;
            pe3.GenerateInstructions();
            instrList3 = pe3.InstrList;
            pe4.GenerateInstructions();
            instrList4 = pe4.InstrList;
            string textInstr1 = "";
            string textInstr2 = "";
            string textInstr3 = "";
            string textInstr4 = "";
            foreach (string instr in instrList1)
            {
                textInstr1 += instr + Environment.NewLine;
            }
            foreach (string instr in instrList2)
            {
                textInstr2 += instr + Environment.NewLine;
            }
            foreach (string instr in instrList3)
            {
                textInstr3 += instr + Environment.NewLine;
            }
            foreach (string instr in instrList4)
            {
                textInstr4 += instr + Environment.NewLine;
            }
            instrBox1.Text = textInstr1;
            instrBox2.Text = textInstr2;
            instrBox3.Text = textInstr3;
            instrBox4.Text = textInstr4;
        }

        /// <summary>
        /// Handles the click event for the "Auto" button.
        /// </summary>
        private void auto_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Handles the click event for the "Reset" button.
        /// </summary>
        private void reset_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Handles the click event for the "Step 1" button.
        /// Validates instructions and executes the next instruction for Processing Element 1.
        /// </summary>
        private void step1_Click(object sender, EventArgs e)
        {
            if (validateInstr())
            {
                PC1.Text = "" + pe1.PC;
                pe1.ExecuteInstr();
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
                PC2.Text = "" + pe2.PC;
                pe2.ExecuteInstr();
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
                PC3.Text = "" + pe3.PC;
                pe3.ExecuteInstr();
            }
        }

        /// <summary>
        /// Handles the click event for the "Step 4" button.
        /// Validates instructions and executes the next instruction for Processing Element 4.
        /// </summary>
        private void step4_Click(object sender, EventArgs e)
        {
            if (validateInstr())
            {
                PC4.Text = "" + pe4.PC;
                pe4.ExecuteInstr();
            }
        }

        /// <summary>
        /// Validates if instructions have been generated for all processing elements.
        /// Displays an error message if instructions are missing.
        /// </summary>
        /// <returns>True if instructions are available; otherwise, false.</returns>
        private bool validateInstr()
        {
            if (instrList1.Capacity == 0 || instrList2.Capacity == 0 || instrList3.Capacity == 0 || instrList4.Capacity == 0)
            {
                MessageBox.Show("You must generate the instructions first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
