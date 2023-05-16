using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Friend_File
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void writeNameButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Create variables
                StreamWriter outputFile;

                // Open the Friends.txt file for appending and geting a new StreamWriter object
                outputFile = File.AppendText("Freinds.txt");

                // Wrie the firends name to the file by getting the name entered into the text box
                outputFile.WriteLine(nameTextBox.Text);

                // Show a message indicating that the name was written
                MessageBox.Show("The name was written.");

                // Show friends.txt file with the name written
                outputFile.Close();
            }
            
            catch (Exception ex)
            {
                // Display an error message
                MessageBox.Show(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
