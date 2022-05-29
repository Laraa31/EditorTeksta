using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EditorTeksta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tsbBold_Click(object sender, EventArgs e)
        {
            rtbIspis.Font = new Font(rtbIspis.Font, FontStyle.Bold);
        }
        private void tsbItalic_Click_1(object sender, EventArgs e)
        {
            rtbIspis.Font = new Font(rtbIspis.Font, FontStyle.Italic);
        }

        private void tsbUnderLine_Click(object sender, EventArgs e)
        {
            rtbIspis.Font = new Font(rtbIspis.Font, FontStyle.Underline);
        }

        private void tsbPlain_Click(object sender, EventArgs e)
        {
            rtbIspis.Font = new Font(rtbIspis.Font, FontStyle.Regular);
        }

        private void tsmNew_Click(object sender, EventArgs e)
        {
            rtbIspis.Clear();
        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            Stream st;
            OpenFileDialog d1=new OpenFileDialog();
            if (d1.ShowDialog() == DialogResult.OK)
            {
                if ((st = d1.OpenFile()) != null)
                {
                    StreamReader stream = new StreamReader(d1.FileName);
                    string datoteka = stream.ReadToEnd();
                    rtbIspis.Rtf = datoteka.ToString();
                    stream.Close();
                }
            }
        }

        private void tsmSave_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"c:\TextEditor"))
            {
                Directory.CreateDirectory(@"c:\TextEditor");
                string path = @"c:\TextEditor\text.rtf";
                if (File.Exists(path))
                {
                    StreamWriter sw = new StreamWriter(path);
                    sw.WriteLine(rtbIspis.Rtf);
                    sw.Close();
                }
                else
                {
                    File.Create(path);
                }

            }
            else if (Directory.Exists(@"c:\TextEditor"))
            {

                string path = @"c:\TextEditor\text.rtf";
                if (File.Exists(path))
                {
                    StreamWriter sw = new StreamWriter(path);
                    sw.WriteLine(rtbIspis.Rtf);
                    sw.Close();
                }
                else
                {
                    File.Create(path);
                }
            }
        }

        private void tsmSaveAs_Click(object sender, EventArgs e)
        {

            SaveFileDialog dr = new SaveFileDialog();
            dr.Filter = "Doc File|*.rtf";
            if (dr.ShowDialog() == DialogResult.OK)
            {
                rtbIspis.SaveFile(dr.FileName);
                MessageBox.Show("Saved successfully!", "Address File : "
                    + dr.FileName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
