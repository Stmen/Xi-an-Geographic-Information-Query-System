namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.数据加载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图文档加载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载shpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.多边形查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除查询结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间分析kToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加目的景点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.规划路线ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.清空路线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.景点周边ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.景点周边ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.地图布局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.指北针ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.比例尺ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出行建议ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.目的点建议ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.blank = new System.Windows.Forms.ToolStripStatusLabel();
            this.scale = new System.Windows.Forms.ToolStripStatusLabel();
            this.position = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(216, 62);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(875, 557);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.axMapControl1);
            this.tabPage1.Controls.Add(this.axLicenseControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(867, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "地图视图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl1.Location = new System.Drawing.Point(3, 3);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(858, 525);
            this.axMapControl1.TabIndex = 0;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnAfterDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterDrawEventHandler(this.axMapControl1_OnAfterDraw);
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(73, 142);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.axPageLayoutControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(867, 531);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "布局视图";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(861, 525);
            this.axPageLayoutControl1.TabIndex = 0;
            this.axPageLayoutControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(this.axPageLayoutControl1_OnMouseDown);
            // 
            // axMapControl2
            // 
            this.axMapControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.axMapControl2.Location = new System.Drawing.Point(12, 486);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(195, 129);
            this.axMapControl2.TabIndex = 3;
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据加载ToolStripMenuItem,
            this.操作ToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.空间分析kToolStripMenuItem,
            this.数据编辑ToolStripMenuItem,
            this.景点周边ToolStripMenuItem,
            this.地图布局ToolStripMenuItem,
            this.出行建议ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1096, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 数据加载ToolStripMenuItem
            // 
            this.数据加载ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.地图文档加载ToolStripMenuItem,
            this.加载shpToolStripMenuItem,
            this.地图保存ToolStripMenuItem});
            this.数据加载ToolStripMenuItem.Name = "数据加载ToolStripMenuItem";
            this.数据加载ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据加载ToolStripMenuItem.Text = "数据加载";
            // 
            // 地图文档加载ToolStripMenuItem
            // 
            this.地图文档加载ToolStripMenuItem.Name = "地图文档加载ToolStripMenuItem";
            this.地图文档加载ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.地图文档加载ToolStripMenuItem.Text = "打开地图文档";
            this.地图文档加载ToolStripMenuItem.Click += new System.EventHandler(this.地图文档加载ToolStripMenuItem_Click);
            // 
            // 加载shpToolStripMenuItem
            // 
            this.加载shpToolStripMenuItem.Name = "加载shpToolStripMenuItem";
            this.加载shpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.加载shpToolStripMenuItem.Text = "加载shp";
            this.加载shpToolStripMenuItem.Click += new System.EventHandler(this.加载shpToolStripMenuItem_Click);
            // 
            // 地图保存ToolStripMenuItem
            // 
            this.地图保存ToolStripMenuItem.Name = "地图保存ToolStripMenuItem";
            this.地图保存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.地图保存ToolStripMenuItem.Text = "地图保存";
            this.地图保存ToolStripMenuItem.Click += new System.EventHandler(this.地图保存ToolStripMenuItem_Click);
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.放大ToolStripMenuItem,
            this.缩小ToolStripMenuItem,
            this.移动ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.操作ToolStripMenuItem.Text = "地图操作";
            // 
            // 放大ToolStripMenuItem
            // 
            this.放大ToolStripMenuItem.Name = "放大ToolStripMenuItem";
            this.放大ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.放大ToolStripMenuItem.Text = "放大";
            this.放大ToolStripMenuItem.Click += new System.EventHandler(this.放大ToolStripMenuItem_Click);
            // 
            // 缩小ToolStripMenuItem
            // 
            this.缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            this.缩小ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.缩小ToolStripMenuItem.Text = "缩小";
            this.缩小ToolStripMenuItem.Click += new System.EventHandler(this.缩小ToolStripMenuItem_Click);
            // 
            // 移动ToolStripMenuItem
            // 
            this.移动ToolStripMenuItem.Name = "移动ToolStripMenuItem";
            this.移动ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.移动ToolStripMenuItem.Text = "移动";
            this.移动ToolStripMenuItem.Click += new System.EventHandler(this.移动ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据查询ToolStripMenuItem,
            this.多边形查询ToolStripMenuItem,
            this.清除查询结果ToolStripMenuItem});
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.查询ToolStripMenuItem.Text = "数据查询";
            // 
            // 数据查询ToolStripMenuItem
            // 
            this.数据查询ToolStripMenuItem.Name = "数据查询ToolStripMenuItem";
            this.数据查询ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.数据查询ToolStripMenuItem.Text = "数据查询";
            this.数据查询ToolStripMenuItem.Click += new System.EventHandler(this.数据查询ToolStripMenuItem_Click);
            // 
            // 多边形查询ToolStripMenuItem
            // 
            this.多边形查询ToolStripMenuItem.Name = "多边形查询ToolStripMenuItem";
            this.多边形查询ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.多边形查询ToolStripMenuItem.Text = "多边形查询";
            this.多边形查询ToolStripMenuItem.Click += new System.EventHandler(this.多边形查询ToolStripMenuItem_Click);
            // 
            // 清除查询结果ToolStripMenuItem
            // 
            this.清除查询结果ToolStripMenuItem.Name = "清除查询结果ToolStripMenuItem";
            this.清除查询结果ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.清除查询结果ToolStripMenuItem.Text = "清除查询结果";
            this.清除查询结果ToolStripMenuItem.Click += new System.EventHandler(this.清除查询结果ToolStripMenuItem_Click);
            // 
            // 空间分析kToolStripMenuItem
            // 
            this.空间分析kToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加目的景点ToolStripMenuItem,
            this.规划路线ToolStripMenuItem1,
            this.清空路线ToolStripMenuItem});
            this.空间分析kToolStripMenuItem.Name = "空间分析kToolStripMenuItem";
            this.空间分析kToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.空间分析kToolStripMenuItem.Text = "空间分析";
            // 
            // 添加目的景点ToolStripMenuItem
            // 
            this.添加目的景点ToolStripMenuItem.Name = "添加目的景点ToolStripMenuItem";
            this.添加目的景点ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加目的景点ToolStripMenuItem.Text = "添加目的点";
            this.添加目的景点ToolStripMenuItem.Click += new System.EventHandler(this.添加目的景点ToolStripMenuItem_Click);
            // 
            // 规划路线ToolStripMenuItem1
            // 
            this.规划路线ToolStripMenuItem1.Name = "规划路线ToolStripMenuItem1";
            this.规划路线ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.规划路线ToolStripMenuItem1.Text = "规划路线";
            this.规划路线ToolStripMenuItem1.Click += new System.EventHandler(this.规划路线ToolStripMenuItem_Click);
            // 
            // 清空路线ToolStripMenuItem
            // 
            this.清空路线ToolStripMenuItem.Name = "清空路线ToolStripMenuItem";
            this.清空路线ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.清空路线ToolStripMenuItem.Text = "清空路线";
            this.清空路线ToolStripMenuItem.Click += new System.EventHandler(this.清空路线ToolStripMenuItem_Click);
            // 
            // 数据编辑ToolStripMenuItem
            // 
            this.数据编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启动编辑ToolStripMenuItem,
            this.保存编辑ToolStripMenuItem,
            this.停止编辑ToolStripMenuItem});
            this.数据编辑ToolStripMenuItem.Name = "数据编辑ToolStripMenuItem";
            this.数据编辑ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据编辑ToolStripMenuItem.Text = "数据编辑";
            // 
            // 启动编辑ToolStripMenuItem
            // 
            this.启动编辑ToolStripMenuItem.Name = "启动编辑ToolStripMenuItem";
            this.启动编辑ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.启动编辑ToolStripMenuItem.Text = "启动编辑";
            this.启动编辑ToolStripMenuItem.Click += new System.EventHandler(this.启动编辑ToolStripMenuItem_Click);
            // 
            // 保存编辑ToolStripMenuItem
            // 
            this.保存编辑ToolStripMenuItem.Name = "保存编辑ToolStripMenuItem";
            this.保存编辑ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存编辑ToolStripMenuItem.Text = "保存编辑";
            this.保存编辑ToolStripMenuItem.Click += new System.EventHandler(this.保存编辑ToolStripMenuItem_Click);
            // 
            // 停止编辑ToolStripMenuItem
            // 
            this.停止编辑ToolStripMenuItem.Name = "停止编辑ToolStripMenuItem";
            this.停止编辑ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.停止编辑ToolStripMenuItem.Text = "停止编辑";
            this.停止编辑ToolStripMenuItem.Click += new System.EventHandler(this.停止编辑ToolStripMenuItem_Click);
            // 
            // 景点周边ToolStripMenuItem
            // 
            this.景点周边ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.景点周边ToolStripMenuItem1});
            this.景点周边ToolStripMenuItem.Name = "景点周边ToolStripMenuItem";
            this.景点周边ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.景点周边ToolStripMenuItem.Text = "景点周边";
            // 
            // 景点周边ToolStripMenuItem1
            // 
            this.景点周边ToolStripMenuItem1.Name = "景点周边ToolStripMenuItem1";
            this.景点周边ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.景点周边ToolStripMenuItem1.Text = "景点周边";
            this.景点周边ToolStripMenuItem1.Click += new System.EventHandler(this.景点周边ToolStripMenuItem1_Click);
            // 
            // 地图布局ToolStripMenuItem
            // 
            this.地图布局ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.指北针ToolStripMenuItem,
            this.比例尺ToolStripMenuItem,
            this.图例ToolStripMenuItem});
            this.地图布局ToolStripMenuItem.Name = "地图布局ToolStripMenuItem";
            this.地图布局ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.地图布局ToolStripMenuItem.Text = "地图布局";
            // 
            // 指北针ToolStripMenuItem
            // 
            this.指北针ToolStripMenuItem.Name = "指北针ToolStripMenuItem";
            this.指北针ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.指北针ToolStripMenuItem.Text = "指北针";
            this.指北针ToolStripMenuItem.Click += new System.EventHandler(this.指北针ToolStripMenuItem_Click);
            // 
            // 比例尺ToolStripMenuItem
            // 
            this.比例尺ToolStripMenuItem.Name = "比例尺ToolStripMenuItem";
            this.比例尺ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.比例尺ToolStripMenuItem.Text = "比例尺";
            this.比例尺ToolStripMenuItem.Click += new System.EventHandler(this.比例尺ToolStripMenuItem_Click);
            // 
            // 图例ToolStripMenuItem
            // 
            this.图例ToolStripMenuItem.Name = "图例ToolStripMenuItem";
            this.图例ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.图例ToolStripMenuItem.Text = "图例";
            this.图例ToolStripMenuItem.Click += new System.EventHandler(this.图例ToolStripMenuItem_Click);
            // 
            // 出行建议ToolStripMenuItem
            // 
            this.出行建议ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.目的点建议ToolStripMenuItem});
            this.出行建议ToolStripMenuItem.Name = "出行建议ToolStripMenuItem";
            this.出行建议ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.出行建议ToolStripMenuItem.Text = "出行建议";
            // 
            // 目的点建议ToolStripMenuItem
            // 
            this.目的点建议ToolStripMenuItem.Name = "目的点建议ToolStripMenuItem";
            this.目的点建议ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.目的点建议ToolStripMenuItem.Text = "目的点建议";
            this.目的点建议ToolStripMenuItem.Click += new System.EventHandler(this.目的点建议ToolStripMenuItem_Click);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(12, 28);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(723, 28);
            this.axToolbarControl1.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blank,
            this.scale,
            this.position});
            this.statusStrip1.Location = new System.Drawing.Point(0, 622);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1096, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // blank
            // 
            this.blank.Name = "blank";
            this.blank.Size = new System.Drawing.Size(981, 17);
            this.blank.Spring = true;
            // 
            // scale
            // 
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(44, 17);
            this.scale.Text = "比例尺";
            // 
            // position
            // 
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(56, 17);
            this.position.Text = "当前位置";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(918, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(163, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(849, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "查询图层：";
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.axTOCControl1.Location = new System.Drawing.Point(12, 63);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(198, 417);
            this.axTOCControl1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(742, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "自定义菜单";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 644);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.axMapControl2);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "西安交通信息查询系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.ToolStripMenuItem 多边形查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除查询结果ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间分析kToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel blank;
        private System.Windows.Forms.ToolStripStatusLabel scale;
        private System.Windows.Forms.ToolStripStatusLabel position;
        private System.Windows.Forms.ToolStripMenuItem 添加目的景点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 规划路线ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 清空路线ToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem 数据查询ToolStripMenuItem;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private System.Windows.Forms.ToolStripMenuItem 数据加载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图文档加载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载shpToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem 数据编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图布局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 指北针ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 比例尺ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图例ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出行建议ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 目的点建议ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图保存ToolStripMenuItem;
        public ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.ToolStripMenuItem 景点周边ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 景点周边ToolStripMenuItem1;
    }
}

