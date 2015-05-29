using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalFairApp.BLL;
using DigitalFairApp.Model;

namespace DigitalFairApp
{
    public partial class VisitorEntryUI : Form
    {
        ZoneManager zoneManager=new ZoneManager();
        VisitorManager visitorManager=new VisitorManager();
        
        public VisitorEntryUI()
        {
            InitializeComponent();
        }

        private void VisitorEntryUI_Load(object sender, EventArgs e)
        {
            LoadZoneListAsCheckBox();
        }

        public void LoadZoneListAsCheckBox()
        {

            List<Zone> zones = zoneManager.GetAllZones();
            int x = 200, y = 30;

            foreach (Zone zone in zones)
            {
                CheckBox checkBox = new CheckBox();

                checkBox.Text = zone.Type;
                checkBox.Name = string.Format(zone.Type + "CheckBox");
                checkBox.Location = new Point(x, y);
                checkBox.Width = 200;
                checkBox.Checked = true;
                showZoneGroupBox.Controls.Add(checkBox);
                y += 30;

            }

        }

        public void SendSelectedChekBox()
        {

            List<string> selectedCheckBoxList = new List<string>();
            int count = 0;
            foreach (Control c in showZoneGroupBox.Controls)
            {

                CheckBox cb = c as CheckBox;
                if (cb != null && cb.Checked)
                {
                    selectedCheckBoxList.Add(cb.Text);
                }

            }
            visitorManager.SetSelectedZoneId(selectedCheckBoxList);




        }

        private void saveVisitorButton_Click(object sender, EventArgs e)
        {
            
            Visitor visitor=new Visitor();

             visitor.Name = nameTextBox.Text;
            visitor.Email = emailTextBox.Text;
            visitor.ContactNo = contactNoTextBox.Text;

            SendSelectedChekBox();

            MessageBox.Show(visitorManager.Save(visitor));
            GetTextBoxesClear();
           

        }

        private void GetTextBoxesClear()
        {
            nameTextBox.Text = "";
            emailTextBox.Text = "";
            contactNoTextBox.Text = "";

        
        }
    }
}
