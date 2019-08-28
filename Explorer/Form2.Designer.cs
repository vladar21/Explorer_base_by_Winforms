namespace Explorer
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxLeft = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripPathNameLeft = new System.Windows.Forms.ToolStripTextBox();
            this.listViewLeft = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeLeft = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxRight = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripPathNameRight = new System.Windows.Forms.ToolStripTextBox();
            this.treeRight = new System.Windows.Forms.TreeView();
            this.listViewRight = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.listViewLeft);
            this.splitContainer1.Panel1.Controls.Add(this.treeLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel2.Controls.Add(this.treeRight);
            this.splitContainer1.Panel2.Controls.Add(this.listViewRight);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 399;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBoxLeft,
            this.toolStripComboBox1,
            this.toolStripPathNameLeft});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(399, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel1.Text = "path: ";
            // 
            // toolStripComboBoxLeft
            // 
            this.toolStripComboBoxLeft.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBoxLeft.Items.AddRange(new object[] {
            "LargeIcon",
            "SmallIcon",
            "Tile",
            "List",
            "Details",
            "Tree"});
            this.toolStripComboBoxLeft.Name = "toolStripComboBoxLeft";
            this.toolStripComboBoxLeft.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxLeft.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxLeft_SelectedIndexChanged);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.AutoSize = false;
            this.toolStripComboBox1.DropDownWidth = 21;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(10, 21);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStripPathNameLeft
            // 
            this.toolStripPathNameLeft.Name = "toolStripPathNameLeft";
            this.toolStripPathNameLeft.Size = new System.Drawing.Size(150, 25);
            // 
            // listViewLeft
            // 
            this.listViewLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLeft.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewLeft.LargeImageList = this.imageList2;
            this.listViewLeft.Location = new System.Drawing.Point(0, 25);
            this.listViewLeft.Name = "listViewLeft";
            this.listViewLeft.Size = new System.Drawing.Size(399, 429);
            this.listViewLeft.SmallImageList = this.imageList1;
            this.listViewLeft.TabIndex = 1;
            this.listViewLeft.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Modified";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Size";
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // treeLeft
            // 
            this.treeLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeLeft.ImageIndex = 0;
            this.treeLeft.ImageList = this.imageList1;
            this.treeLeft.Location = new System.Drawing.Point(0, 25);
            this.treeLeft.Name = "treeLeft";
            this.treeLeft.SelectedImageIndex = 0;
            this.treeLeft.Size = new System.Drawing.Size(399, 429);
            this.treeLeft.TabIndex = 2;
            this.treeLeft.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.GetDirectories);
            this.treeLeft.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeLeft_AfterSelect);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxRight,
            this.toolStripLabel2,
            this.toolStripComboBox2,
            this.toolStripPathNameRight});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(397, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripComboBoxRight
            // 
            this.toolStripComboBoxRight.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBoxRight.Items.AddRange(new object[] {
            "LargeIcon",
            "SmallIcon",
            "Tile",
            "List",
            "Details",
            "Tree"});
            this.toolStripComboBoxRight.Name = "toolStripComboBoxRight";
            this.toolStripComboBoxRight.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxRight.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxRight_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel2.Text = "path: ";
            // 
            // toolStripPathNameRight
            // 
            this.toolStripPathNameRight.Name = "toolStripPathNameRight";
            this.toolStripPathNameRight.Size = new System.Drawing.Size(150, 25);
            // 
            // treeRight
            // 
            this.treeRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeRight.ImageIndex = 0;
            this.treeRight.ImageList = this.imageList1;
            this.treeRight.Location = new System.Drawing.Point(0, 25);
            this.treeRight.Name = "treeRight";
            this.treeRight.SelectedImageIndex = 0;
            this.treeRight.Size = new System.Drawing.Size(395, 429);
            this.treeRight.TabIndex = 2;
            this.treeRight.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.GetDirectories);
            this.treeRight.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeRight_AfterSelect);
            // 
            // listViewRight
            // 
            this.listViewRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewRight.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listViewRight.LargeImageList = this.imageList2;
            this.listViewRight.Location = new System.Drawing.Point(0, 25);
            this.listViewRight.Name = "listViewRight";
            this.listViewRight.Size = new System.Drawing.Size(395, 429);
            this.listViewRight.SmallImageList = this.imageList1;
            this.listViewRight.TabIndex = 1;
            this.listViewRight.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Type";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Last Modified";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Size";
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.AutoSize = false;
            this.toolStripComboBox2.DropDownWidth = 21;
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(10, 21);
            this.toolStripComboBox2.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox2_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form2";
            this.Text = "FileManager";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ListView listViewLeft;
        private System.Windows.Forms.TreeView treeRight;
        private System.Windows.Forms.ListView listViewRight;
        private System.Windows.Forms.TreeView treeLeft;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxLeft;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxRight;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ToolStripTextBox toolStripPathNameLeft;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox toolStripPathNameRight;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
    }
}