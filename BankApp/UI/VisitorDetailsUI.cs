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

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            xla.Visible = true;

            Microsoft.Office.Interop.Excel.Workbook wb =
                xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);

            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xla.ActiveSheet;

            int i = 1;

            int j = 1;
            ws.Cells[i, j = 2] = "A Visitor List of digital fair 2015";
            i = 4;
            j = 1;
            ws.Cells[i, j] = "Name";
            ws.Cells[i, j + 1] = "Email";
            ws.Cells[i, j + 2] = "Contact No.";

            i = 6;
            j = 1;



            foreach (ListViewItem comp in loadVisitorListView.Items)
            {

                ws.Cells[i, j] = comp.Text.ToString();

                foreach (ListViewItem.ListViewSubItem drv in comp.SubItems)
                {

                    ws.Cells[i, j] = drv.Text.ToString();

                    j++;

                }

                j = 1;

                i++;
            }
        }
    }
}
