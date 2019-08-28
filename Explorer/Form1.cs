// ГРУППА 3107. Растровров В.О.
// WinForms, Домашнее задание от преподавателя №11 (7).

//С использованием контрола TreeView реализовать приложение, позволяющее просматривать файловую структуру компьютера.
//Корневыми элементами являются логические диски, далее папки и т.д.
//С помощью меню реализовать возможность просмотра дерева каталогов в различных режимах (список, таблица, большие и маленькие иконки). 
//В режиме таблица реализовать просмотр нескольких атрибутов, например: имя, тип, размер, дата создания и т.п.и т.д.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Explorer
{
    public partial class Form1 : Form
    {
        String Path="";

        public Form1()
        {
            InitializeComponent();            
            PopulateTreeView();
        }

        // иконки
        private string GetImageKey(string fullName, string extension)
        {
            Icon iconForFile = SystemIcons.WinLogo;
            IntPtr hImgSmall;
            //IntPtr hImgLarge;
            SHFILEINFO shinfo = new SHFILEINFO();
            if (string.IsNullOrEmpty(extension))
                extension = "folder";

            if (!imageList1.Images.ContainsKey(extension))
            {
                hImgSmall = NativeMethods.SHGetFileInfo(fullName, 0,
                    ref shinfo, (uint)Marshal.SizeOf(shinfo),
                    NativeMethods.SHGFI_ICON | NativeMethods.SHGFI_SMALLICON);
                //hImgLarge = NativeMethods.SHGetFileInfo(fullName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), NativeMethods.SHGFI_ICON | NativeMethods.SHGFI_LARGEICON);
                iconForFile = Icon.FromHandle(shinfo.hIcon);
                imageList1.Images.Add(extension, iconForFile);
                imageList2.Images.Add(extension, iconForFile);
            }
            return extension;
        }

        private void PopulateTreeView()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            //string[] drives = Environment.GetLogicalDrives();
           
            foreach (DriveInfo drive in drives)
            {   
                if (drive.DriveType != DriveType.Fixed ) { continue; }
                TreeNode mn = new TreeNode(drive.Name);
                treeView1.Nodes.Add(mn);
                string str = mn.FullPath;
                DirectoryInfo info1 = new DirectoryInfo(@str);  // I guess the '@' has to (can) be removed
                mn.Tag = info1;  // this has to be added!
                try // исключаем проблему остутствия доступа к папкам вроде "Documents and settings"
                {
                    GetDirectories(info1.GetDirectories(), mn);
                }
                catch { Exception ex; continue; }   
            }
            OnNodeMouseClick(treeView1.Nodes[0], null);
        } 

        private void GetDirectories(DirectoryInfo[] parent, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            //DirectoryInfo[] children;
            foreach (DirectoryInfo child in parent)
            {
                aNode = new TreeNode(child.Name);
                aNode.Tag = child;
                aNode.ImageKey = GetImageKey(child.FullName, child.Extension);
                //children = child.GetDirectories();
                //if (children.Length != 0)
                //GetDirectories(children, aNode);
                nodeToAddTo.Nodes.Add(aNode);
            }
        }
        
        private void OnNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = new TreeNode();

            if (e != null)
            {
                treeView1.SelectedNode = e.Node;// при щелчке на узел, выделяется и иконка
                newSelected = e.Node;
            }
            else if( sender != null)
            {
                treeView1.SelectedNode = (TreeNode)sender;
                newSelected = (TreeNode)sender;
            }
            
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo directory in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(directory.Name, 
                    GetImageKey(directory.FullName, directory.Extension));
                subItems = new ListViewItem.ListViewSubItem[]
                {
                    new ListViewItem.ListViewSubItem(item, "Directory"),
                    new ListViewItem.ListViewSubItem(item, 
                    directory.LastAccessTime.ToShortDateString())
                };
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }

            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 
                    GetImageKey(file.FullName, file.Extension));
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
                listView1.Items.Add(item);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        // обрабатываем клик мышью на listview
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            String ListViewName = listView1.FocusedItem.Text;
            Path = treeView1.SelectedNode.FullPath + "\\" + ListViewName;

            if (listView1.FocusedItem.SubItems[1].Text == "File")
            {
                // "запускаем" файл
                System.Diagnostics.Process.Start(Path);
            }
            else if(listView1.FocusedItem.SubItems[1].Text == "Directory")
            {             
                // открываем папку
                TreeNode mn = new TreeNode();
                // "раскрываем" в treeview узел, кликнутый в listview
                foreach (TreeNode nd in treeView1.SelectedNode.Nodes)
                {
                    if (nd.Text == ListViewName)
                    {
                        mn = nd;
                        break;
                    }
                }

                treeView1.SelectedNode = mn;
                DirectoryInfo info1 = new DirectoryInfo(@Path);  // I guess the '@' has to (can) be removed
                mn.Tag = info1;  // this has to be added!
                try // исключаем проблему остутствия доступа к папкам вроде "Documents and settings"
                {
                    GetDirectories(info1.GetDirectories(), mn);
                }
                catch { Exception ex; }

                // обновляем listview
                TreeNode newSelected = mn;
                treeView1.SelectedNode = newSelected;
                treeView1.Focus();
                listView1.Items.Clear();
                DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
                ListViewItem.ListViewSubItem[] subItems;
                ListViewItem item = null;
                foreach (DirectoryInfo directory in nodeDirInfo.GetDirectories())
                {
                    item = new ListViewItem(directory.Name, 
                        GetImageKey(directory.FullName, directory.Extension));
                    subItems = new ListViewItem.ListViewSubItem[]
                    {
                    new ListViewItem.ListViewSubItem(item, "Directory"),
                    new ListViewItem.ListViewSubItem(item, 
                    directory.LastAccessTime.ToShortDateString())
                    };
                    item.SubItems.AddRange(subItems);
                    listView1.Items.Add(item);
                }
                foreach (FileInfo file in nodeDirInfo.GetFiles())
                {
                    item = new ListViewItem(file.Name, 
                        GetImageKey(file.FullName, file.Extension));
                    subItems = new ListViewItem.ListViewSubItem[]
                    {
                    new ListViewItem.ListViewSubItem(item, "File"),
                    new ListViewItem.ListViewSubItem(item, 
                    file.LastAccessTime.ToShortDateString()),
                    new ListViewItem.ListViewSubItem(item,
                    (file.Length/1000 < 1000?Math.Round(((float)file.Length/1000),1)
                    :Math.Round(((float)file.Length/1000000),1)).ToString()
                    + (file.Length/1000 < 1000?" Kb":" Mb"))
                    };
                    item.SubItems.AddRange(subItems);
                    listView1.Items.Add(item);
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            else
            {
                MessageBox.Show("You click not File or Directory");
            }
        }
        
        // устанавливаем вид(View) listview
        private void cbKindIcon_TextChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBox1.SelectedItem.ToString())
            {
                case "LargeIcon":
                    listView1.View = View.LargeIcon;  
                    
                    break;

                case "SmallIcon":
                    listView1.View = View.SmallIcon;
                    break;

                case "Tile":
                    listView1.View = View.Tile;
                    break;

                case "List":
                    listView1.View = View.List;
                    break;

                case "Details":
                    listView1.View = View.Details;
                    break;
            }      
                
        }
    }

    // иконки
    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };
    class NativeMethods
    {
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
        public const uint SHGFI_SMALLICON = 0x1; // 'Small icon

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes,
            ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
    }

}
