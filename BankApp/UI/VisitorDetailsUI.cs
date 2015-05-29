using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalFairApp.Model;
using DigitalFairApp.BLL;

namespace DigitalFairApp
{
    public partial class VisitorDetailsUI : Form
    {
        ZoneManager zoneManager=new ZoneManager();
        VisitorManager visitorManager=new VisitorManager();
        public VisitorDetailsUI()
        {
            InitializeComponent();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            LoadVisitorListView();
        }

        public void LoadComboBoxList()
        {
           
        
            
            
            selectZoneComboBox.DataSource=zoneManager.GetAllZones();
            selectZoneComboBox.DisplayMember = "Type";
            selectZoneComboBox.ValueMember = "Id";

        }

        public void LoadVisitorListView()
        {
            int count = 0;
            string typeName = selectZoneComboBox.Text;
            loadVisitorListView.Items.Clear();

            foreach (var list in visitorManager.GetAllVisitorByZoneName(typeName))
            {
                ListViewItem item = new ListViewItem();
                item.Text = list.Name;
                item.SubItems.Add(list.Email);
                item.SubItems.Add(list.ContactNo);

                loadVisitorListView.Items.Add(item);
                count++;
            }

            totalTextBox.Text = count.ToString();

        }

        private void VisitorDetailsUI_Load(object sender, EventArgs e)
        {
            LoadComboBoxList();
            LoadVisitorListView();
        }
    }
}
