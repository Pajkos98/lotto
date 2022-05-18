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

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        List<Sorsolas> sorsolas_list = new List<Sorsolas>();
        List<Szam> szamok = new List<Szam>();
        public Form1()
        {
            InitializeComponent();
            string[] lines = File.ReadAllLines("sorsolas.txt");

            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Sorsolas sorsolas_object = new Sorsolas(values[0], values[1], values[2], values[3], values[4], values[5]);
                sorsolas_list.Add(sorsolas_object);
            }
            //3.feladat
            int db = 0;
            for (int i = 1; i < 91; i++)
            {
                foreach (var item in sorsolas_list)
                {
                    if (i == item.szam1 || i == item.szam2 || i == item.szam3 || i == item.szam4 || i == item.szam5)
                        db++;
                }
                Szam szam_object = new Szam(i, db);
                szamok.Add(szam_object);
                db = 0;
            }

            int max_db = int.MinValue;
            int max_szam = 0;

            foreach (var item in szamok)
            {
                if (item.db > max_db)
                {
                    max_db = item.db;
                    max_szam = item.szam;
                }
                //5. Feladat 4(label4)
                if (item.szam == 4)
                    label4.Text = $"5.feladat:4-es: {item.db} db";
                //6. Feladat 73(label5)
                if (item.szam == 73)
                    label5.Text = $"6.feladat:73-as: {item.db} db";
            }
            label2.Text = $"3.Feladat:Legtöbbször kihúzva: {max_szam}: {max_db}";
            //4.Feladat
            int paros_db = 0;
            foreach (var item in szamok)
            {
                if (item.szam % 2 == 0)
                {
                    paros_db += item.db;
                }
            }
            label3.Text = $"4. Feladat: páros szám: {paros_db} db.";

            //7.feladat
            foreach (var item in szamok)
            {
                dataGridView1.Rows.Add(item.szam, item.db);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in sorsolas_list)
            {
                if (numericUpDown1.Value == item.het)
                {
                    label1.Text = $"2.feladat: Hét:{item.het}, Számok: {item.szam1},{item.szam2},{item.szam3},{item.szam4},{item.szam5}";
                }
            }
        }
    }
}
