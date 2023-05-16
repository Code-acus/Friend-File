using System;
using System.IO;
using System.Linq;
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
                string name = nameTextBox.Text.Trim();

                // Check if the name contains only letters and follows the specified format
                if (IsNameFormatValid(name))
                {
                    // Create a StreamWriter object and open the Friends.txt file for appending
                    using (StreamWriter outputFile = File.AppendText("Friends.txt"))
                    {
                        // Capitalize the first letter of the first name and last name
                        string formattedName = FormatName(name);

                        // Write the formatted name to the file
                        outputFile.WriteLine(formattedName);

                        // Show a message indicating that the name was written
                        MessageBox.Show("The name was written.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid name format. Please enter a name with only letters and follow the specified format.");
                }
            }
            catch (Exception ex)
            {
                // Display a general error message
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private bool IsNameFormatValid(string name)
        {
            // Split the name into individual parts
            string[] nameParts = name.Split(' ');

            // Check if each part starts with an uppercase letter and contains only lowercase letters afterward
            foreach (string part in nameParts)
            {
                if (part.Length < 1 || !char.IsUpper(part[0]) || !part.Substring(1).All(char.IsLower))
                {
                    return false;
                }
            }

            return true;
        }

        private string FormatName(string name)
        {
            // Capitalize the first letter of each part of the name
            string[] nameParts = name.Split(' ');

            for (int i = 0; i < nameParts.Length; i++)
            {
                nameParts[i] = char.ToUpper(nameParts[i][0]) + nameParts[i].Substring(1).ToLower();
            }

            return string.Join(" ", nameParts);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
