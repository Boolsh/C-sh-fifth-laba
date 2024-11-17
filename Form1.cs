using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharp_Lab5
{
    public partial class Form1 : Form
    {
        private string currentFilePath = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void NewFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            currentFilePath = string.Empty;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Сохранить новый файл";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    File.WriteAllText(saveFileDialog.FileName, textBox1.Text);
                }
            }
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = openFileDialog.FileName;
                    textBox1.Text = File.ReadAllText(currentFilePath);

                }
            }

        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                File.WriteAllText(currentFilePath, textBox1.Text);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName;
                    File.WriteAllText(currentFilePath, textBox1.Text);
                }
            }
        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string word = "СЛОВО";
            if (word != null)
            {
                string processedText = MoveLinesBeforeWord(textBox1.Text, word);
                textBox1.Text = processedText;
            }
        }

        private string MoveLinesBeforeWord(string input, string word)
        {
            StringBuilder result = new StringBuilder();
            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 1; i < lines.Length; i++)
            {
  
                if (lines[i].StartsWith(word, StringComparison.OrdinalIgnoreCase))
                {
                    result.AppendLine(lines[i-1]); 
                }
            }

            return result.ToString();
        }


        //private string PromptForInput(string message, string title)
        //{
        //    Form prompt = new Form()
        //    {
        //        Width = 300,
        //        Height = 150,
        //        FormBorderStyle = FormBorderStyle.FixedDialog,
        //        Text = title,
        //        StartPosition = FormStartPosition.CenterScreen
        //    };
        //    Label textLabel = new Label() { Left = 20, Top = 20, Text = message };
        //    TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 240 };
        //    Button confirmation = new Button() { Text = "Ok", Left = 200, Width = 60, Top = 70 };
        //    confirmation.Click += (sender, e) => { prompt.Close(); };
        //    prompt.Controls.Add(textLabel);
        //    prompt.Controls.Add(textBox);
        //    prompt.Controls.Add(confirmation);
        //    prompt.ShowDialog();
        //    return textBox.Text;
        //}




        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}