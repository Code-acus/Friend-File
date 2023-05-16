using System;
using System.IO;
using System.Windows.Forms;

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
                // Create a StreamWriter object and open the Friends.txt file for appending
                using (StreamWriter outputFile = File.AppendText("Friends.txt"))
                {
                    // Write the friend's name to the file by getting the name entered into the text box
                    outputFile.WriteLine(nameTextBox.Text);

                    // Show a message indicating that the name was written
                    MessageBox.Show("The name was written.");
                }
            }
            catch (Exception ex)
            {
                // Display a general error message
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
