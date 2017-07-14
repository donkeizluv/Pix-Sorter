using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pix_Sorter
{
    public partial class Logger : Form
    {
        public DataGridView DataGridLog
        {
            get
            {
                return dataGridViewLog;

            }
        }

        public Logger()
        {
            InitializeComponent();
        }
        public void AddLog(string hr, string mess)
        {
            var row = (DataGridViewRow)DataGridLog.RowTemplate.Clone();
            row.CreateCells(DataGridLog, new object[] { hr, mess });
            DataGridLog.Rows.Add(row);
            //return row;
        }
        private void Logger_Load(object sender, EventArgs e)
        {
            //pass
        }

        private void Logger_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
