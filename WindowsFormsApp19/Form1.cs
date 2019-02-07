using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Speech.Synthesis;
using System.IO;

namespace WindowsFormsApp19
{
    public partial class Form1 : Form
    {
        int counter;
        string filename;
        public Form1()
        {
            InitializeComponent();

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

        }
        
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            button3.Enabled = true;
            string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var item in droppedFiles)
            {

                filename = item;
                counter = 2;

                listView1.Items.Add(System.IO.Path.GetFileName(filename));
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            
            e.Effect = DragDropEffects.Copy;
        }
        public void Read (string path)
            {
            PdfReader reader = new PdfReader(path);
            string text = string.Empty;
            for (int page = counter; page <= counter; page++)
            {
                text += PdfTextExtractor.GetTextFromPage(reader, page);
                textBox1.Text = text;
            }
            var a = new SpeechSynthesizer();
            a.SelectVoiceByHints(VoiceGender.Female);
            a.Speak(text.ToString());
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            counter++;
            Read(filename);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           textBox1.Text = string.Empty;

            counter--;
            Read(filename);
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Read(filename);
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
