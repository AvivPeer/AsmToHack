using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiffMatchPatch;
namespace WindowsFormsApp2
{
    public partial class AsmHackCmp : Form
    {
        public AsmHackCmp()
        {
            InitializeComponent();
        }
        // this is the diff object;
        diff_match_patch DIFF = new diff_match_patch();

        // these are the diffs
        List<Diff> diffs;

        // chunks for formatting the two RTBs:
        List<Chunk> chunklist1;
        List<Chunk> chunklist2;
        bool isDif = false;
        // two color lists:
        Color[] colors1 = new Color[3] { Color.LightGreen, Color.LightSalmon, Color.White };
        Color[] colors2 = new Color[3] { Color.LightSalmon, Color.LightGreen, Color.White };

        public struct Chunk
        {
            public int startpos;
            public int length;
            public Color BackColor;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (File1.Text == "" || File2.Text == "")
            {
                MessageBox.Show("No Files Selected!");
                return;
            }

            diffs = DIFF.diff_main(File1.Text, File2.Text);
            DIFF.diff_cleanupSemanticLossless(diffs);      // <--- see note !

            chunklist1 = collectChunks(File1);
            chunklist2 = collectChunks(File2);

            paintChunks(File1, chunklist1);
            paintChunks(File2, chunklist2);

            File1.SelectionLength = 0;
            File2.SelectionLength = 0;
            if (chunklist1.Count > 1|| chunklist2.Count >1)
            {
                isDif = true;
            }
            if (isDif)
            {
                res.Text = "Files Are NOT identical";
                res.BackColor = Color.Red;
                res.ForeColor = Color.White;
                isDif = false;
            }
            else
            {
                res.Text = "Files Are identical";
                res.BackColor = Color.Green;
                res.ForeColor = Color.White;
            }
        }


        List<Chunk> collectChunks(RichTextBox RTB)
        {
            RTB.Text = "";
            List<Chunk> chunkList = new List<Chunk>();
            foreach (Diff d in diffs)
            {

                if (RTB == File2 && d.operation == Operation.DELETE) continue;  // **
                if (RTB == File1 && d.operation == Operation.INSERT) continue;  // **

                Chunk ch = new Chunk();
                int length = RTB.TextLength;
                RTB.AppendText(d.text);
                ch.startpos = length;
                ch.length = d.text.Length;
                ch.BackColor = RTB == File1 ? colors1[(int)d.operation]
                                           : colors2[(int)d.operation];
                chunkList.Add(ch);
            }
            return chunkList;
        }
        void paintChunks(RichTextBox RTB, List<Chunk> theChunks)
        {
            foreach (Chunk ch in theChunks)
            {
              
                RTB.Select(ch.startpos, ch.length);
                RTB.SelectionBackColor = ch.BackColor;
            }

        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Hack or Asm Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "hack files (*.hack)|*.hack|asm files (*.asm)|*.asm",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
            if (textBox1.Text == "")
            {
                return;
            }

            using (StreamReader file = new StreamReader(textBox1.Text))
            {
                string ln;
                string OutPut = "";
                string newLine = Environment.NewLine;
                while ((ln = file.ReadLine()) != null)
                {
                    OutPut += ln;
                    OutPut += newLine;

                }
                File1.Text = OutPut;
                file.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Hack or Asm Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "hack files (*.hack)|*.hack|asm files (*.asm)|*.asm",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
            }
            if (textBox2.Text == "")
            {
                return;
            }

            using (StreamReader file = new StreamReader(textBox2.Text))
            {
                string ln;
                string OutPut = "";
                string newLine = Environment.NewLine;
                while ((ln = file.ReadLine()) != null)
                {
                    OutPut += ln;
                    OutPut += newLine;

                }
                File2.Text = OutPut;
                file.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
