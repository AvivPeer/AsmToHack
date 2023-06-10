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

namespace WindowsFormsApp2
{



    public partial class AsmToHack : Form
    {
        IDictionary<string, string> cInstructCmpAZer = new Dictionary<string, string>();
        IDictionary<string, string> cInstructCmpA = new Dictionary<string, string>();
        IDictionary<string, string> cInstructJmp = new Dictionary<string, string>();
        IDictionary<string, string> cInstructDest = new Dictionary<string, string>();
        IDictionary<string, string> SymbolTable = new Dictionary<string, string>();
        int VarCounter = 16;
        public AsmToHack()
        {
            InitializeComponent();
            makeTable();
        }
       
        private string regularCmdConvert(string ln)
        {
            if (ln.Contains('('))
            {
                return "Skip"; ;
            }
            string a = "";
            bool isJump = ln.Contains(';');
            bool isEqual = ln.Contains("=");
            string searchJmp = ";";
            string searchEqual = "=";
            string jumpValue = "null";
            string CompValue = "";
            string DestValue = "null";

            string finalString = "";
            if (isJump)
            {
                jumpValue = ln.Substring(ln.IndexOf(searchJmp) + searchJmp.Length);
                ln = ln.Substring(0, ln.IndexOf(searchJmp));
                
            }
            if (isEqual)
            {
                DestValue = ln.Substring(0, ln.IndexOf(searchEqual));
                CompValue = ln.Substring(ln.IndexOf(searchEqual) + searchEqual.Length);
               
            }
            else
            {
                CompValue = ln;
            }
            DestValue = cInstructDest[DestValue];
            jumpValue = cInstructJmp[jumpValue];
            if (cInstructCmpA.ContainsKey(CompValue))
            {
                a = "1";
                CompValue = cInstructCmpA[CompValue];
            }
            else
            {
                CompValue = cInstructCmpAZer[CompValue];
                a = "0";
            }

            finalString = "111" + a + CompValue + DestValue + jumpValue;
            return finalString;
        }
        private string convert_to_Bin(int num)
        {
            string binary = Convert.ToString(num, 2).PadLeft(16,'0');
            int result = Convert
  .ToString(num, 2) // Binary representation
  .PadLeft(16, '0')   // Ensure it is 16 characters long
  .Reverse()          // Reverse
  .Aggregate(0, (s, a) => s * 2 + a - '0'); // Back to decimal


            return binary;
        }
        private void AddToSymbolTable(string name, int line,bool isLable)
        {
            if (isLable)
            {
                SymbolTable.Add(name,(line).ToString());
            }
            else
            {
                int numericValue;
                bool isNumber = int.TryParse(name, out numericValue);
                if (!isNumber)
                {
                    SymbolTable.Add(name, VarCounter.ToString());
                    VarCounter++;
                }
            }
            
        }
        private void makeTable()
        {
            //Comp
            //If a==0
            cInstructCmpAZer.Add("0", "101010");
            cInstructCmpAZer.Add("1", "111111");
            cInstructCmpAZer.Add("-1", "111010");
            cInstructCmpAZer.Add("D", "001100");
            cInstructCmpAZer.Add("A", "110000");
            cInstructCmpAZer.Add("!D", "001101");
            cInstructCmpAZer.Add("!A", "110001");
            cInstructCmpAZer.Add("-D", "001111");
            cInstructCmpAZer.Add("-A", "110011");
            cInstructCmpAZer.Add("D+1", "011111");
            cInstructCmpAZer.Add("1+D", "011111");
            cInstructCmpAZer.Add("A+1", "110111");
            cInstructCmpAZer.Add("1+A", "110111");
            cInstructCmpAZer.Add("D-1", "001110");
            cInstructCmpAZer.Add("A-1", "110010");
            cInstructCmpAZer.Add("D+A", "000010");
            cInstructCmpAZer.Add("A+D", "000010");
            cInstructCmpAZer.Add("D-A", "010011");
            cInstructCmpAZer.Add("A-D", "000111");
            cInstructCmpAZer.Add("D&A", "000000");
            cInstructCmpAZer.Add("A&D", "000000");
            cInstructCmpAZer.Add("D|A", "010101");
            cInstructCmpAZer.Add("A|D", "010101");

            //if a==1
            cInstructCmpA.Add("M", "110000");
            cInstructCmpA.Add("!M", "110001");
            cInstructCmpA.Add("-M", "101010");
            cInstructCmpA.Add("M+1", "110111");
            cInstructCmpA.Add("1+M", "110111");
            cInstructCmpA.Add("M-1", "110010");
            cInstructCmpA.Add("D+M", "000010");
            cInstructCmpA.Add("M+D", "000010");
            cInstructCmpA.Add("D-M", "010011");
            cInstructCmpA.Add("M-D", "000111");
            cInstructCmpA.Add("D&M", "000000");
            cInstructCmpA.Add("M&D", "000000");
            cInstructCmpA.Add("D|M", "010101");
            cInstructCmpA.Add("M|D", "010101");

            //Dest
            cInstructDest.Add("null", "000");
            cInstructDest.Add("M", "001");
            cInstructDest.Add("D", "010");
            cInstructDest.Add("DM", "011");
            cInstructDest.Add("MD", "011");
            cInstructDest.Add("A", "100");
            cInstructDest.Add("AM", "101");
            cInstructDest.Add("MA", "101");
            cInstructDest.Add("AD", "110");
            cInstructDest.Add("DA", "110");
            cInstructDest.Add("ADM", "111");
            cInstructDest.Add("AMD", "111");
            cInstructDest.Add("DMA", "111");
            cInstructDest.Add("DAM", "111");
            cInstructDest.Add("MAD", "111");
            cInstructDest.Add("MDA", "111");

            //Jump
            cInstructJmp.Add( "null", "000");
            cInstructJmp.Add( "JGT", "001");
            cInstructJmp.Add( "JEQ", "010");
            cInstructJmp.Add( "JGE", "011");
            cInstructJmp.Add( "JLT", "100");
            cInstructJmp.Add( "JNE", "101");
            cInstructJmp.Add( "JLE", "110");
            cInstructJmp.Add( "JMP", "111");

            //SymbolTable
            SymbolTable.Add( "R0", "0");
            SymbolTable.Add("R1", "1");
            SymbolTable.Add("R2", "2");
            SymbolTable.Add("R3", "3");
            SymbolTable.Add("R4", "4");
            SymbolTable.Add("R5", "5");
            SymbolTable.Add("R6", "6");
            SymbolTable.Add("R7", "7");
            SymbolTable.Add("R8", "8");
            SymbolTable.Add("R9", "9");
            SymbolTable.Add("R10", "10");
            SymbolTable.Add("R11", "11");
            SymbolTable.Add("R12", "12");
            SymbolTable.Add("R13", "13");
            SymbolTable.Add("R14", "14");
            SymbolTable.Add("R15", "15");
            SymbolTable.Add("SCREEN", "16384");
            SymbolTable.Add("KBD", "24576");
            SymbolTable.Add("SP", "0");
            SymbolTable.Add("LCL", "1");
            SymbolTable.Add("ARG", "2");
            SymbolTable.Add("THIS", "3");
            SymbolTable.Add("THAT", "4");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Error, File not found...");
                return;
            }
            
            using (StreamReader file = new StreamReader(textBox1.Text))
            {
                
                int counter = 0;
                string ln;
                string OutPut = "";
                string fileName = textBox1.Text.Substring(textBox1.Text.LastIndexOf('\\') + 1);
                fileName = fileName.Substring(0, fileName.Length - 4);
                fileName += ".hack";
                string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                File.WriteAllText(destPath, "");
                for (int i = 0; i < 3; i++)
                {
                    counter = 0;
                    file.BaseStream.Position = 0;
                    while ((ln = file.ReadLine()) != null)
                    {
                        if (ln.Equals("") || ln.Contains("/"))
                        {
                            continue;
                        }

                        if (i == 0)
                        {
                            if (ln[0] == '(')
                            {
                                ln=ln.Substring(1, ln.Length-2);
                                AddToSymbolTable(ln, counter, true);
                                counter--;
                            }
                            

                        }
                        else if(i==1)
                        {
                            if (ln[0] == '@')
                            {

                                ln = ln.Substring(1, ln.Length - 1);
                                var isNumeric = int.TryParse(ln, out _);
                                if (!isNumeric)
                                {
                                    if (!SymbolTable.ContainsKey(ln))
                                    {
                                        AddToSymbolTable(ln, counter, false);
                                    }
                                }

                            }



                        }
                        else
                        {

                            string toPrint = "";
                            if(ln[0]=='@'){
                                ln = ln.Substring(1, ln.Length - 1);
                                var isNumeric = int.TryParse(ln, out int num);
                                if (!isNumeric)
                                {
                                    int curVal = int.Parse(SymbolTable[ln]);
                                    toPrint += convert_to_Bin(int.Parse(SymbolTable[ln]));
                                }
                                else
                                {
                                    toPrint += convert_to_Bin(num);
                                }
                                File.AppendAllText(destPath, toPrint);
                                OutPut += toPrint;
                            }
                            else
                            {
                                toPrint = regularCmdConvert(ln);
                                if (toPrint != "Skip")
                                {
                                    
                                    File.AppendAllText(destPath, toPrint);
                                    OutPut += toPrint;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            OutPut += "\n";
                            File.AppendAllText(destPath, "\n");
                          

                        }
                        counter++;

                        

                    }

                }
                textBox2.Text = OutPut;
                file.Close();

                
                fileName = fileName.Substring(0, fileName.Length - 4);
                fileName += ".txt";
                 destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                foreach (var kvp in SymbolTable)
                {
                    File.AppendAllText(destPath, kvp.ToString());
                    File.AppendAllText(destPath, "\n");
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                }
                file.Close();
            }
            button1.Visible = false;
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "asm files (*.asm)|*.asm",
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
                string OutPut="";
                string newLine = Environment.NewLine;
                while ((ln = file.ReadLine()) != null)
                {
                    if (ln.Contains('/') || ln.Equals("")) 
                    {
                        continue;
                    }
                    OutPut += ln;
                    OutPut += newLine;
                    
                }
                Input.Text = OutPut;
                file.Close();
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new AsmToHack();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
