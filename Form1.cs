using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace GuiReg
{
   



    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "") 
            {
                String[] ss = reginit.loads(openFileDialog1.FileName);
                String sss = "";
                foreach (String s in ss) {
                    sss = sss + s+"\r\n";
                
                }
                textBox1.Text = sss;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "") 
            {
                String[] s=textBox1.Text.Trim().Split('\n');
                for (int i = 0; i < s.Length; i++) 
                {
                    s[0] = s[0].Trim();

                }
                reginit.save(s, saveFileDialog1.FileName);


            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                String[] s = textBox1.Text.Trim().Split('\n');
                for (int i = 0; i < s.Length; i++)
                {
                    s[0] = s[0].Trim();

                }
                reginit.save(s, saveFileDialog1.FileName);


            }
            textBox1.Text = "";
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                String[] s = textBox1.Text.Trim().Split('\n');
                for (int i = 0; i < s.Length; i++)
                {
                    s[0] = s[0].Trim();

                }
                reginit.save(s, saveFileDialog1.FileName);


            }
            textBox1.Text = "";
        }
    }
    class reginit


    {
        public static void Writer(String s)
        {

            Console.WriteLine(s);


        }
        public static void lists(String[] ss)
        {
            foreach (String s in ss)
            {
                Writer(s);



            }



        }
        public static String[] sets(String[] ss, String s, String ss1)
        {
            String s1 = "";
            String[] h = { };
            int counts = 0;
            Array.Sort(ss);

            foreach (String s2 in ss)
            {
                s1 = s2.Trim();
                h = s1.Split('=');
                if (h.Length > 1)
                {

                    if (h[0].Trim() == s.Trim())
                    {
                        ss[counts] = h[0] + "=" + ss1;
                        return ss;
                    }

                }
                counts++;
            }

            Array.Resize(ref ss, ss.Length + 1);
            ss[ss.Length - 1] = s + "=" + ss1;

            return ss;



        }
        public static String gets(String[] ss, String s)
        {
            String s1 = "";
            String[] h = { };
            Array.Sort(ss);

            foreach (String s2 in ss)
            {
                s1 = s2.Trim();
                h = s1.Split('=');
                if (h.Length > 1)
                {

                    if (h[0].Trim() == s.Trim()) return h[1];

                }

            }
            return "";
        }

        public static void save(String[] ss, String files)

        {
            String Value = "";
            String v = "";
            foreach (String s in ss)
            {
                v = s.Replace("=", "\x02");
                Value = Value + v + "\x01";



            }
            File.WriteAllText(files, Value);


        }
        public static String[] Splint(String s)

        {
            String[] ss = s.Split('\n');
            return ss;

        }



   
        public static String[] loads(String files)
        {
            String[] s = File.ReadAllText(files).Split('\x01');
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = s[i].Replace('\x02', '=');



            }
            return s;



        }

    }
 }