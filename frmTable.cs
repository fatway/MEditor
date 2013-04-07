using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MEditor
{
    public partial class frmTable : Form
    {
        public frmTable()
        {
            InitializeComponent();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Utils.tableText = "";
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<table>");

            string[] lines = textBox1.Text.Split(new string[] {"\r\n"}, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Trim() == string.Empty)
                    continue;

                builder.AppendLine("  <tr>");

                string[] tabs = lines[i].Split('\t');
                builder.Append("    ");
                foreach (string tab in tabs)
                {
                    if (i == 0 && chkHasHead.Checked)
                    {
                        builder.Append(string.Format("<th>{0}</th>", tab));
                    }
                    else
                    {
                        builder.Append(string.Format("<td>{0}</td>", tab));
                    }
                }
                builder.AppendLine();
                builder.AppendLine("  </tr>");
            }
            builder.AppendLine("</table>");


            //MessageBox.Show(builder.ToString());
            Utils.tableText = builder.ToString();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
