using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMenuStrip
{
    internal class CreateMenu
    {
        private string nameFile;
        private MenuStrip menuStrip = new MenuStrip();
        public CreateMenu(string nameFile, MenuStrip menuStrip)
        {
            this.nameFile = nameFile;
            this.menuStrip = menuStrip;
        }
        public void Create()
        {


            int hierarchyLevel = 0;
            List<string> fileLines = File.ReadLines(Environment.CurrentDirectory + "\\" + nameFile).ToList();
            //Записываем в лист строки из файла
            List<ToolStripMenuItem> ListMenu = new List<ToolStripMenuItem>();
            menuStrip.ItemClicked += FileItem_Click; 
            //Триггер нажатия на пункт меню
            for (int i = 0; i < fileLines.Count; i++)
            {
                string[] menuTool = fileLines[i].Split(' ');
                if (Convert.ToInt32(menuTool[0]) > hierarchyLevel)
                    hierarchyLevel = Convert.ToInt32(menuTool[0]);
                if (menuTool[0] == "0" && menuTool[1] !="")
                {
                    ToolStripMenuItem newItem = new ToolStripMenuItem(menuTool[1]);
                    newItem.DropDownItemClicked += FileItem_Click;
                    //Триггер нажатия на пункт подменю
                    menuStrip.Items.Add(newItem);
                    ListMenu.Add(newItem);
                    VisibilityOfMenuItems(ListMenu.Last(), menuTool[2]);
                }
            }
            DropDownMenuBuilder(ListMenu, hierarchyLevel+1, 1, fileLines);
        }
        private void DropDownMenuBuilder(List<ToolStripMenuItem> ListMenu, int n, int count, List<string> fileLines)
            //n-уровень иерархии, count - уровень иерархии сейчас.
        {
            List<ToolStripMenuItem> ListMenu1 = new List<ToolStripMenuItem>();
            if (n == count)
                return;
            for (int i = 0, b = -1; i < fileLines.Count; i++)
            {
                string[] menuTool = fileLines[i].Split(' ');
                if (menuTool[0] == Convert.ToString(count))
                {
                    if (ListMenu.Count != 0)
                    {
                        ToolStripMenuItem newItem = new ToolStripMenuItem(menuTool[1]);
                        newItem.DropDownItemClicked += FileItem_Click;
                        ListMenu[b].DropDownItems.Add(newItem);
                        ListMenu1.Add(newItem);
                        VisibilityOfMenuItems(ListMenu1.Last(), menuTool[2]);
                    }
                }
                else
                {
                    if (menuTool[0] == Convert.ToString(count - 1))
                        b++;
                }
            }
            count++;
            DropDownMenuBuilder(ListMenu1, n, count, fileLines);
        }
        private void VisibilityOfMenuItems(ToolStripMenuItem toolStripMenuItem, string access)
        {
            if (access == "1")
            {
                toolStripMenuItem.Enabled = false;
                toolStripMenuItem.Visible = true;
            }
            if (access == "2")
            {
                toolStripMenuItem.Enabled = false;
                toolStripMenuItem.Visible = false;
            }
        }
        private void FileItem_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            List<string> fileLines = File.ReadLines(Environment.CurrentDirectory + "\\" + nameFile).ToList();
            string nameFuncl = "0";
            string switchItem = e.ClickedItem.Text;
            for (int i = 0; i < fileLines.Count; i++)
            {
                string[] menuTool = fileLines[i].Split(' ');
                if (fileLines[i].Contains(switchItem))
                {
                    if (menuTool.Length == 4)
                    {
                        nameFuncl = menuTool[3];
                        MenuLogic.MenuFunc(nameFuncl);
                    }
                    break;
                }
            }
            
        }
        
    }
}
