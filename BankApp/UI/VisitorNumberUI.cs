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
    public partial class VisitorNumberUI : Form
    {
        ZoneManager zoneManager=new ZoneManager();
        public VisitorNumberUI()
        {
            InitializeComponent();
        }

        public void LoadZoneList()
        {
            int count = 0;
            
           List<Zone>zones=new List<Zone>();
            zones=zoneManager.GetAllZones();
            foreach (var zone in zones )
            {
                ListViewItem item=new ListViewItem(zone.Type);
                item.SubItems.Add(zone.NumberOfVisitors.ToString());
                visitorNumberListView.Items.Add(item);
                count += zone.NumberOfVisitors;

            }

            totalTextBox.Text = count.ToString();
        }

        private void VisitorNumberUI_Load(object sender, EventArgs e)
        {
            LoadZoneList();
        }
    }
}
