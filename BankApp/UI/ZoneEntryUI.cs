using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankApp.BLL;
using BankApp.Model;

namespace BankApp
{
    public partial class ZoneEntryUI : Form
    {
        public ZoneEntryUI()
        {
            InitializeComponent();
        }


        ZoneManager zoneManager = new ZoneManager();
        private void saveZoneTypeButton_Click(object sender, EventArgs e)
        {
            
            Zone zone=new Zone();
            zone.Type = zoneTypeNameEntryTextBox.Text;
            zone.NumberOfVisitors = 0;
           string messag= zoneManager.Save(zone);
            MessageBox.Show(messag);
            LoadZoneList();

        }

        private void ZoneEntryUI_Load(object sender, EventArgs e)
        {
            LoadZoneList();
        }

        public void LoadZoneList()
        {
            int serial = 1;
            zoneTypeListView.Items.Clear();
            foreach (var zone in zoneManager.GetAllZones())
            {
                ListViewItem item = new ListViewItem();
                item.Tag = (Zone)zone;
                item.Text = serial.ToString();
                item.SubItems.Add(zone.Type);

                zoneTypeListView.Items.Add(item);
                serial++;
            }

        }

       
    }
}
