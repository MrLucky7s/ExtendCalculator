using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IronPython.Hosting;
using IronPython.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace ExtendCalculator
{
    public partial class Form1 : Form
    {
         ScriptEngine pyEngine = null; //Globalne varijable za rad s .NET frameworkom
         ScriptScope pyScope = null;

        public Form1()
        {
            InitializeComponent();
            pyEngine = Python.CreateEngine();//Izvršni dio skriptnog jezika
            pyScope = pyEngine.CreateScope();//Okruženje sa svim objektima kojima skripta pristupa
        }

        private void loadExtensionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();//Prikazivanje open file dijaloga klikom na "Load extension"
          
            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)                                   
            {
                ScriptSource scriptSource = pyEngine.CreateScriptSourceFromFile(openFileDialog1.FileName); //Generiranje ScriptEngine objekta
                scriptSource.Execute(pyScope);
                dynamic modifyFunc = pyScope.GetVariable("LoadScript");
                modifyFunc(this);
            }

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtA.Text) && !String.IsNullOrEmpty(txtB.Text))//Provjerava postoji li unos u tekst boxu
            {
                decimal a = Convert.ToDecimal(txtA.Text);               //Funkcija koja tekst iz tekstboksa pretvara u broj
                decimal b = Convert.ToDecimal(txtB.Text);
                decimal result = a + b; //operacija zbrajanja
                txtResult.Text = Convert.ToString(result);//prikazivanje rezultata
            }
            else txtResult.Text = "";//ako su polja prazna, result polje ostaje prazno
        }//SVE FUNKCIJE SU RAĐENE NA OVU ŠABLONU

        private void subtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtA.Text) && !String.IsNullOrEmpty(txtB.Text))
            {
                decimal a = Convert.ToDecimal(txtA.Text);
                decimal b = Convert.ToDecimal(txtB.Text);
                decimal result = a - b;
                txtResult.Text = Convert.ToString(result);
            }
            else txtResult.Text = "";
        }

        private void multiplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtA.Text) && !String.IsNullOrEmpty(txtB.Text))
            {
                decimal a = Convert.ToDecimal(txtA.Text);
                decimal b = Convert.ToDecimal(txtB.Text);
                decimal result = a * b;
                txtResult.Text = Convert.ToString(result);
            }
            else txtResult.Text = "";
        }

        private void divideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtA.Text) && !String.IsNullOrEmpty(txtB.Text))
            {
                decimal a = Convert.ToDecimal(txtA.Text);
                decimal b = Convert.ToDecimal(txtB.Text);
                decimal result = a / b;
                txtResult.Text = Convert.ToString(result);
            }
            else txtResult.Text = "";
        }
    }
}
