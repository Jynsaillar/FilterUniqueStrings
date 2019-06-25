using System;
using System.IO;
using System.Windows.Forms;
using FilterUniqueStrings.BusinessLogic;

namespace FilterUniqueStrings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            FormClosing += Form1_FormClosing;
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox1.Text.Length < 1)
            {
                return;
            }

            var directory = Path.GetDirectoryName(Application.ExecutablePath);
            var filePath = Path.Combine(directory, "filterList.txt");
            File.WriteAllText(filePath, textBox1.Text);
        }

        private bool _ignoreTextChange = false;

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (_ignoreTextChange)
            {
                return;
            }

            if (textBox1.Text.Length < 1)
            {
                return;
            }

            _ignoreTextChange = true; // Toggles this event off to edit the value of the TextBox.

            var originalKeywords = textBox1.Text.Split('\n');
            textBox1.Text = Filtering.JoinStrings(Filtering.FilterUniques(originalKeywords));

            _ignoreTextChange = false; // Toggles the TextChanged event back on since the text has been properly modified.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var directory = Path.GetDirectoryName(Application.ExecutablePath);
            var filePath = Path.Combine(directory, "filterList.txt");
            if (!File.Exists(filePath))
            {
                return;
            }

            textBox1.Text = (File.ReadAllText(filePath));
        }
    }
}
