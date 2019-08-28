using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;

namespace Explorer
{
    public partial class Form2 : Form
    {
        String leftPath = "";
        String rightPath = "";
        int lengthDrivers = 0;
        int indexsolid1 = 0;
        int indexsolid2;
        bool searchfirstsolid = true;
        bool searchsecondsolid = true;

        public Form2()
        {
            InitializeComponent();
            indexsolid2 = indexsolid1;

            // определяем превые два жестких диска системы
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady && drive.DriveType == DriveType.Fixed)
                {                   
                    if (searchfirstsolid)
                    {
                        indexsolid1 = lengthDrivers;
                        indexsolid2 = indexsolid1;
                        searchfirstsolid = false;
                    }
                    if (searchsecondsolid && !searchfirstsolid)
                    {
                        indexsolid2 = lengthDrivers;
                    }
                    
                }
                lengthDrivers++;
            }            

            if (lengthDrivers > 0) 
            {
                leftPath = drives[indexsolid1].ToString();
                rightPath = drives[indexsolid2].ToString();

                TreeNode nodeLeft = new TreeNode(leftPath);
                nodeLeft.Tag = drives[indexsolid1];
                nodeLeft.Expand();
                nodeLeft.Nodes.Add("...");
                treeLeft.Nodes.Add(nodeLeft);

                TreeNode nodeRight = new TreeNode(rightPath);
                nodeRight.Tag = drives[indexsolid2];
                nodeRight.Expand();
                nodeRight.Nodes.Add("...");
                treeRight.Nodes.Add(nodeRight);

                // запускаем событие выбора вида проводника с дерева (таблица, дерево, список и т.д.)
                toolStripComboBoxLeft.SelectedIndex = 5;
                // now attach the event handler
                toolStripComboBoxLeft.SelectedIndexChanged += new
                    EventHandler(toolStripComboBoxLeft_SelectedIndexChanged);

                toolStripComboBoxRight.SelectedIndex = 4;
                // now attach the event handler
                toolStripComboBoxRight.SelectedIndexChanged += new
                    EventHandler(toolStripComboBoxRight_SelectedIndexChanged);
            }
            else
            {
                MessageBox.Show("Жесткие диски в системе не обнаружены.");
            }

        }            
        
        private void ShowListView(string path, ListView listview, bool largeicon)
        {
            listview.Items.Clear();
            GetListViewDirectories(path, listview, largeicon);
        }

        private void GetListViewDirectories(string path, ListView listview, bool largeicon)
        {            
            DirectoryInfo listDirInfo = new DirectoryInfo(path);// (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo directory in listDirInfo.GetDirectories())
            {
                item = new ListViewItem(directory.Name, 
                    GetImageKey(directory.FullName, directory.Extension, largeicon));
                subItems = new ListViewItem.ListViewSubItem[]
                {
                    new ListViewItem.ListViewSubItem(item, "Directory"),
                    new ListViewItem.ListViewSubItem(item,
                    directory.LastAccessTime.ToShortDateString())
                };
                
                listview.Items.Add(item);            
                
            }

            foreach (FileInfo file in listDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name,
                    GetImageKey(file.FullName, file.Extension, largeicon));
                subItems = new ListViewItem.ListViewSubItem[]
                {
                    new ListViewItem.ListViewSubItem(item, "File"),
                    new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString()),
                    new ListViewItem.ListViewSubItem(item,
                    (file.Length/1000 < 1000?Math.Round(((float)file.Length/1000),1)
                    :Math.Round(((float)file.Length/1000000),1)).ToString()
                    + (file.Length/1000 < 1000?" Kb":" Mb"))
                };
                item.SubItems.AddRange(subItems);
                
                listview.Items.Add(item);             
                
            }

            listViewLeft.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewRight.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        private void GetDirectories(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    //get the list of sub direcotires
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name);//, 0, 1);
                        node.ImageKey = GetImageKey(di.FullName, di.Extension, false);

                        try
                        {
                            //keep the directory full path in the tag for use later
                            node.Tag = dir;

                            //if the directory has sub directories add the place holder
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);

                            foreach (var file in di.GetFiles())
                            {
                                TreeNode n = new TreeNode(file.Name);//, 13, 13);
                                n.ImageKey = GetImageKey(file.FullName, file.Extension, false);
                                node.Nodes.Add(n);
                            }

                        }
                        catch (UnauthorizedAccessException)
                        {
                            //display a locked folder icon
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {                         
                            e.Node.Nodes.Add(node);
                        }
                    }

                    //add files of rootdirectory
                    DirectoryInfo rootDir = new DirectoryInfo(e.Node.Tag.ToString());
                    foreach (var file in rootDir.GetFiles())
                    {
                        TreeNode n = new TreeNode(file.Name);//, 13, 13);
                        n.ImageKey = GetImageKey(file.FullName, file.Extension, false);
                        e.Node.Nodes.Add(n);
                    }
                }
            }
        }

        private void toolStripComboBoxLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBoxLeft.SelectedItem.ToString())
            {
                case "LargeIcon":                    
                    listViewLeft.View = View.LargeIcon;
                    treeLeft.Visible = false;
                    listViewLeft.Visible = true;
                    ShowListView(leftPath, listViewLeft, true);
                    break;

                case "SmallIcon":                    
                    listViewLeft.View = View.SmallIcon;
                    treeLeft.Visible = false;
                    listViewLeft.Visible = true;
                    ShowListView(leftPath, listViewLeft, false);
                    break;

                case "Tile":                    
                    listViewLeft.View = View.Tile;
                    treeLeft.Visible = false;
                    listViewLeft.Visible = true;
                    ShowListView(leftPath, listViewLeft, false);
                    break;

                case "List":                    
                    listViewLeft.View = View.List;
                    treeLeft.Visible = false;
                    listViewLeft.Visible = true;
                    ShowListView(leftPath, listViewLeft, false);
                    break;

                case "Details":                    
                    listViewLeft.View = View.Details;
                    treeLeft.Visible = false;
                    listViewLeft.Visible = true;
                    ShowListView(leftPath, listViewLeft, false);
                    break;

                case "Tree":
                    toolStripPathNameLeft.Text = leftPath;
                    listViewLeft.Visible = false;
                    treeLeft.Visible = true;
                    treeLeft.Focus();
                    break;
            }
            
        }
                
        private void toolStripComboBoxRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBoxRight.SelectedItem.ToString())
            {
                case "LargeIcon":
                    listViewRight.View = View.LargeIcon;
                    treeRight.Visible = false;
                    listViewRight.Visible = true;
                    ShowListView(rightPath, listViewRight, true);
                    break;

                case "SmallIcon":
                    listViewRight.View = View.SmallIcon;
                    treeRight.Visible = false;
                    listViewRight.Visible = true;
                    ShowListView(rightPath, listViewRight, false);
                    break;

                case "Tile":
                    listViewRight.View = View.Tile;
                    treeRight.Visible = false;
                    listViewRight.Visible = true;
                    ShowListView(rightPath, listViewRight, false);
                    break;

                case "List":
                    listViewRight.View = View.List;
                    treeRight.Visible = false;
                    listViewRight.Visible = true;
                    ShowListView(rightPath, listViewRight, false);
                    break;

                case "Details":
                    listViewRight.View = View.Details;
                    treeRight.Visible = false;
                    listViewRight.Visible = true;
                    ShowListView(rightPath, listViewRight, false);
                    break;

                case "Tree":
                    toolStripPathNameRight.Text = rightPath;
                    listViewRight.Visible = false;
                    treeRight.Visible = true;
                    treeRight.Focus();
                    break;
            }
            
        }

        private void treeLeft_AfterSelect(System.Object sender,
    System.Windows.Forms.TreeViewEventArgs e)
        {
            leftPath = e.Node.FullPath;
            toolStripPathNameLeft.Text = leftPath;
        }

        private void treeRight_AfterSelect(System.Object sender,
    System.Windows.Forms.TreeViewEventArgs e)
        {
            rightPath = e.Node.FullPath;
            toolStripPathNameRight.Text = rightPath;
        }

        /////////////// иконки
        private string GetImageKey(string fullName, string extension, bool largeicon)
        {
            Icon iconForFileSmall = SystemIcons.WinLogo;
            Icon iconForFileLarge = SystemIcons.WinLogo;
            IntPtr hImgSmall;
            IntPtr hImgLarge;
            SHFILEINFO shinfo = new SHFILEINFO();
            if (string.IsNullOrEmpty(extension))
                extension = "folder";
            if (!largeicon)
            {
                if (!imageList1.Images.ContainsKey(extension))
                {
                    hImgSmall = NativeMethods.SHGetFileInfo(fullName, 0,
                        ref shinfo, (uint)Marshal.SizeOf(shinfo),
                        NativeMethods.SHGFI_ICON | NativeMethods.SHGFI_SMALLICON);

                    iconForFileSmall = Icon.FromHandle(shinfo.hIcon);
                    imageList1.Images.Add(extension, iconForFileSmall);

                }
            }
            else
            {
                if (!imageList2.Images.ContainsKey(extension))
                {
                    hImgLarge = NativeMethods.SHGetFileInfo(fullName, 0,
                        ref shinfo, (uint)Marshal.SizeOf(shinfo),
                        NativeMethods.SHGFI_ICON | NativeMethods.SHGFI_LARGEICON);

                    iconForFileLarge = Icon.FromHandle(shinfo.hIcon);
                    imageList2.Images.Add(extension, iconForFileLarge);
                }
            }            

            return extension;
        }

    }
 
}
