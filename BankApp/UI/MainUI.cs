using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalFairApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void visitorEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisitorEntryUI visitor=new VisitorEntryUI();
            visitor.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zoneSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoneEntryUI zone=new ZoneEntryUI();
            zone.Show();
        }

        private void zoneSpecificVisitorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisitorDetailsUI visitorDetails=new VisitorDetailsUI();
            visitorDetails.Show();
        }

        private void zoneWiseVisitorNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisitorNumberUI visitorNumber=new VisitorNumberUI();
            visitorNumber.Show();
        }
    }
}
