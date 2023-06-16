using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMenuStrip
{
    public partial class Form2 : Form
    {
        string nameFile;
        public Form2(string nameFile)
        {
            this.nameFile = nameFile;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CreateMenu createMenu = new CreateMenu(nameFile, menuStrip1);
            createMenu.Create();
            {
                this.menuStrip1.Items.OfType<ToolStripMenuItem>().ToList().ForEach(x =>
                {
                    x.MouseHover += (obj, arg) => ((ToolStripDropDownItem)obj).ShowDropDown();//При наведении мышки на пункт, показывается подменю
                });
            }
        }

    }
}
