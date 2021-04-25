using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile; 
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.NetworkAnalysis;
using System.Text.RegularExpressions;
using ESRI.ArcGIS.Catalog;
using ESRI.ArcGIS.DataSourcesRaster;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        #region 全局变量
        int flag;
        ClsPathFinder CPF;
        IMap pMap;
        IWorkspaceFactory ipWorkspaceFactory;
        IWorkspace ipWorkspace;
        IFeatureWorkspace ipFeatureWorkspace;
        IFeatureDataset pFeatDataset;
        IActiveView pActiveView;
        IElement element = new LineElement();
        Boolean clicke = false;
        private IMapControl3 m_mapControl = null;
        IGeometry pGeometry;
        IPointCollection mPointCollection;
        IGraphicsContainer pGraphicC;
        public static IMapControl4 q_mapControl = null;
        public int layerIndex = 0;
        IMapDocument m_MapDocument;
        String curOper = "";
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        IRgbColor pRGB = new RgbColorClass();  //节点颜色
        IRgbColor lRGB = new RgbColorClass();  //路线颜色

        // 窗口初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            CPF = new ClsPathFinder();
            q_mapControl = this.axMapControl1.Object as IMapControl4;
            m_mapControl = (IMapControl3)axMapControl1.Object;
            pActiveView = axMapControl1.ActiveView;
            pMap = axMapControl1.Map;


            /*加载地图*/
            addMap();

            ICommand command1 = new CreateNewDocument();
            command1.OnCreate(m_mapControl.Object);
            command1.OnClick();
            string sFilePath = System.Windows.Forms.Application.StartupPath + "\\data\\map.mxd";
            axMapControl1.LoadMxFile(sFilePath, 0, Type.Missing);

            pRGB.Red = 96;
            pRGB.Blue = 192;
            pRGB.Green = 24;

            lRGB.Red = 96;
            lRGB.Blue = 192;
            lRGB.Green = 24;
        }

        // 放大
        private void 放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 1;
        }
        // 缩小
        private void 缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 2;
        }
        // 移动
        private void 移动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 3;
        }
        // 传递数据
        private void axMapControl1_OnAfterDraw(object sender, IMapControlEvents2_OnAfterDrawEvent e)
        {
            IObjectCopy objectCopy = new ObjectCopyClass();
            object toCopyMap = axMapControl1.Map;
            object copiedMap = objectCopy.Copy(toCopyMap);
            object toOverwriteMap = axPageLayoutControl1.ActiveView.FocusMap;
            //传递数据()
            objectCopy.Overwrite(copiedMap, ref toOverwriteMap); axPageLayoutControl1.ActiveView.Refresh();
        }
        // 地图范围
        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            IEnvelope pEnv;
            pEnv = e.newEnvelope as IEnvelope;
            IGraphicsContainer pGraphicsContainer;
            IActiveView pActiveView;
            pGraphicsContainer = axMapControl2.Map as IGraphicsContainer;
            pActiveView = pGraphicsContainer as IActiveView;
            pGraphicsContainer.DeleteAllElements();//'获取矩形坐标
            IRectangleElement pRectangleEle;
            pRectangleEle = new RectangleElementClass();
            IElement pEle;
            pEle = pRectangleEle as IElement;
            pEle.Geometry = pEnv;

            IRgbColor pColor;
            pColor = new RgbColorClass();
            pColor.RGB = 255;
            pColor.Transparency = 255;
            ILineSymbol pOutline;
            pOutline = new SimpleLineSymbolClass();
            pOutline.Width = 1;
            pOutline.Color = pColor;
            pColor = new RgbColorClass();
            pColor.RGB = 255;
            pColor.Transparency = 0;

            IFillSymbol pFillSymbol;
            pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutline;
            //构建矩形元素
            IFillShapeElement pFillshapeEle;
            pFillshapeEle = pEle as IFillShapeElement;
            pFillshapeEle.Symbol = pFillSymbol;
            pEle = pFillshapeEle as IElement;
            pGraphicsContainer.AddElement(pEle, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        // 地图更新
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            comboBox1.Items.Clear();
            IMap pMap= axMapControl1.Map;
            axMapControl2.Map.ClearLayers();
            for (int i = pMap.LayerCount - 1; i >= 0; i--)
            {
                axMapControl2.Map.AddLayer(pMap.get_Layer(i));
            }
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                comboBox1.Items.Add(pMap.get_Layer(i).Name);
                comboBox1.SelectedIndex = 0;
            }
        }
         
        // 地图点击
        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            // 放大
            if (flag == 1)
            {
                axMapControl1.Extent = axMapControl1.TrackRectangle();
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
            // 缩小
            else if (flag == 2)
            {
                IEnvelope pEnv = axMapControl1.Extent;
                pEnv.Expand(2, 2, true);
                axMapControl1.Extent = pEnv;
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
            // 移动
            else if (flag == 3)
                axMapControl1.Pan();
 
            /*查询*/
            else if (flag == 6)
            {
                if (e.button == 1)
                {
                    axMapControl1.Map.ClearSelection();
                    axMapControl1.CurrentTool = null;
                    this.axMapControl1.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
                   IGeometry pGeometry = this.axMapControl1.TrackPolygon();
                    //IGeometry pGeometry = this.axMapControl1.TrackCircle();
                    IFeatureLayer pFeatureLayer = this.axMapControl1.get_Layer(layerIndex) as IFeatureLayer;
                    
                    List<IFeature> pFList = this.GetSearchFeatures(pFeatureLayer, pGeometry);

                    if (pFList.Count > 0)
                    {
                        AttributesForm pAttributeForm = new AttributesForm();
                        pAttributeForm.dataGridView1.RowCount = pFList.Count + 1;
                        //设置边界风格
                        pAttributeForm.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
                        //设置列数
                        pAttributeForm.dataGridView1.ColumnCount = pFList[0].Fields.FieldCount;
                        for (int m = 0; m < pFList[0].Fields.FieldCount; m++)
                        {
                            pAttributeForm.dataGridView1.Columns[m].HeaderText = pFList[0].Fields.get_Field(m).AliasName;
                        }
                        //遍历要素
                        for (int i = 0; i < pFList.Count; i++)
                        {
                            IFeature pFeature = pFList[i];
                            for (int j = 0; j < pFeature.Fields.FieldCount; j++)
                            {
                                //填充字段值
                                pAttributeForm.dataGridView1[j, i].Value = pFeature.get_Value(j).ToString();
                            }
                        }
                        //隐藏无用行
                        for (int m = 0; m < pFList[0].Fields.FieldCount; m++)
                        {
                            string Lname = pFList[0].Fields.get_Field(m).AliasName.ToString();

                            if (Lname == "Shape" || Lname == "SHAPE" || Lname == "UserID")
                            {
                                pAttributeForm.dataGridView1.Columns[m].Visible = false;
                            }
                        }
                        axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                        pAttributeForm.Show();
                    }
                    else {
                        MessageBox.Show("未查询到数据，请检查查询图层是否正确");
                    }
                }
            }
            //添加目的景点
            else if (flag == 7 )
            {
                axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair;
                axMapControl1.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
                if (e.button == 1)
                {
                    IPoint pNewPoint = new PointClass();
                    pNewPoint.PutCoords(e.mapX, e.mapY);

                    drawPoint(pNewPoint.X, pNewPoint.Y);
                    if (mPointCollection == null)
                    {
                        mPointCollection = new MultipointClass();
                    }
                    object before = Type.Missing;
                    object after = Type.Missing;
                    mPointCollection.AddPoint(pNewPoint, ref before, ref after);
                }
             }
        }

        IPoint pPoint= new PointClass();
        protected void drawPoint(double ex, double ey)
        {
            pPoint.X = ex;
            pPoint.Y = ey;
            ISimpleMarkerSymbol pMarkerSymbol;
            pMarkerSymbol = new SimpleMarkerSymbol();
            pMarkerSymbol.Size = 9;
            pMarkerSymbol.Color = pRGB;
            pMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
            IMarkerElement pMarkerElement = new MarkerElementClass();
            IElement pElement = pMarkerElement as IElement;
            pElement.Geometry = pPoint as IGeometry;
            pMarkerElement.Symbol = pMarkerSymbol;
            pGraphicC = axMapControl1.Map as IGraphicsContainer;
            pGraphicC.AddElement(pElement, 0);
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        // 地图查询
        private List<IFeature> GetSearchFeatures(IFeatureLayer pFeatureLayer, IGeometry pGeometry)
        {
            try
            {
                List<IFeature> pFeatureList = new List<IFeature>();
                //pFeatureList是一个列表
                ISpatialFilter pSpatialFilter = new SpatialFilterClass();
                //SpatialFilter继承了QueryFilter
                IQueryFilter pQueryFilter = pSpatialFilter as IQueryFilter;
                pSpatialFilter.Geometry = pGeometry;
                pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                IFeatureCursor pFeatureCursor = pFeatureLayer.Search(pQueryFilter, false);
                IFeatureSelection pFeatureSelection = pFeatureLayer as IFeatureSelection;
                //将IFeatureLayer转为了IFeatureSelection
                pFeatureSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                // void SelectFeatures(ESRI.ArcGIS.Geodatabase.IQueryFilter Filter, ESRI.ArcGIS.Carto.esriSelectionResultEnum Method, bool justOne)
                IFeature pFeature = pFeatureCursor.NextFeature();
                while (pFeature != null)
                {
                    pFeatureList.Add(pFeature);
                    //将每个被选择的要素都加入列表中
                    pFeature = pFeatureCursor.NextFeature();
                    //光标指向下一个要素
                }
                return pFeatureList;
                //返回一个要素数列
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, "异常提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return null;
            }
        }
        // 鼠标移动
        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            scale.Text = "比例尺：1 :" + ((long)this.axMapControl1.MapScale).ToString();
            position.Text = " 鼠标位置：X = " + e.mapX.ToString() + " Y = " + e.mapY.ToString() + " " + this.axMapControl1.MapUnits.ToString().Substring(4);
        }

        // 鹰眼操作
        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            IEnvelope pEnv = axMapControl2.TrackRectangle();
            axMapControl1.Extent = pEnv;
            axMapControl1.Refresh();
        }

        private void Drawpoint(double x, double y)
        {
            //创建点的几何对象
            IPoint pPoint = new PointClass();
            pPoint.X = x;
            pPoint.Y = y;
            //创建点的符号样式
            ISimpleMarkerSymbol pMarkerSymbol;
            pMarkerSymbol = new SimpleMarkerSymbolClass();
            pMarkerSymbol.Size = 7;
            pMarkerSymbol.Color = getRGB(255, 0, 0);
            pMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
            //创建点元素，将点几何对象，及符号样式值
            IMarkerElement pMarkerElement = new MarkerElementClass();
            IElement pElement = pMarkerElement as IElement;
            pElement.Geometry = pPoint as IGeometry;
            pGeometry = pElement.Geometry;
            pMarkerElement.Symbol = pMarkerSymbol;
            //向图形容器中增加点符号
            IGraphicsContainer pGraphicC;
            pGraphicC = axMapControl1.Map as IGraphicsContainer;
            pGraphicC.AddElement(pElement, 0);
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        // 获取颜色
        private IRgbColor getRGB(int r, int g, int b)
        {
            IRgbColor pColor;
            pColor = new RgbColorClass();
            pColor.Red = r;
            pColor.Green = g;
            pColor.Blue = b;
            return pColor;
        }

        private void 多边形查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 6;
        }

        private void 清除查询结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 0;
            IActiveView pActiveView = axMapControl1.ActiveView;
            //获得axMapControl1的ActiveView
            IFeatureLayer pFeaturelayer = axMapControl1.get_Layer(layerIndex) as IFeatureLayer;
            //获得第一个图层
            ClearSelectedMapFeatures(pActiveView, pFeaturelayer);
        }
        /*清除查询*/
        public void ClearSelectedMapFeatures(ESRI.ArcGIS.Carto.IActiveView activeView, ESRI.ArcGIS.Carto.IFeatureLayer featureLayer)
        {
            if (activeView == null || featureLayer == null)
            {
                return;
            }
            ESRI.ArcGIS.Carto.IFeatureSelection featureSelection = featureLayer as ESRI.ArcGIS.Carto.IFeatureSelection;
            activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeoSelection, null, null);
            // 清除所有选择
            featureSelection.Clear();
        }
        // 导出图片
        private void 保存地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog pSaveDialog = new SaveFileDialog();
                pSaveDialog.FileName = "";
                pSaveDialog.Filter = "JPG图片(*.JPG)|*.jpg|tif图片(*.tif)|*.tif|PDF文档(*.PDF)|*.pdf";
                if (pSaveDialog.ShowDialog() == DialogResult.OK)
                {
                    double iScreenDispalyResolution = this.axPageLayoutControl1.ActiveView.ScreenDisplay.DisplayTransformation.Resolution;
                    IExporter pExporter = null;
                    if (pSaveDialog.FilterIndex == 0)
                    {
                        pExporter = new JpegExporterClass();
                    }
                    else if (pSaveDialog.FilterIndex == 1)
                    {
                        pExporter = new TiffExporterClass();
                    }
                    else if (pSaveDialog.FilterIndex == 2)
                    {
                        pExporter = new PDFExporterClass();
                    }
                    pExporter.ExportFileName = pSaveDialog.FileName;
                    pExporter.Resolution = (short)iScreenDispalyResolution;
                    tagRECT deviceRect;
                    deviceRect.left = 0;
                    deviceRect.top = 0;
                    deviceRect.right = this.axPageLayoutControl1.ActiveView.ExportFrame.right * (300 / 96);
                    deviceRect.bottom = this.axPageLayoutControl1.ActiveView.ExportFrame.bottom * (300 / 96);
                    IEnvelope pDeviceEnvelope = new EnvelopeClass();
                    pDeviceEnvelope.PutCoords(deviceRect.left, deviceRect.bottom, deviceRect.right, deviceRect.top);
                    pExporter.PixelBounds = pDeviceEnvelope;
                    ITrackCancel pCancle = new CancelTrackerClass();
                    this.axPageLayoutControl1.ActiveView.Output(pExporter.StartExporting(), pExporter.Resolution, ref deviceRect, this.axPageLayoutControl1.ActiveView.Extent, pCancle);
                    Application.DoEvents();
                    pExporter.FinishExporting();
                    MessageBox.Show("输入成功，请查看。", "提示");
                }
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, "输出图片", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 添加道路数据
        private void addMap()
        {
            axMapControl1.Map.ClearLayers();
            string path = System.Windows.Forms.Application.StartupPath;
            ipWorkspaceFactory = new AccessWorkspaceFactoryClass();
            string str = System.Environment.CurrentDirectory;
            ipWorkspace = ipWorkspaceFactory.OpenFromFile(path + "\\data\\road.mdb", 0);
            ipFeatureWorkspace = ipWorkspace as IFeatureWorkspace;
            pFeatDataset = ipFeatureWorkspace.OpenFeatureDataset("road");
            CPF.SetOrGetMap = axMapControl1.Map;
            CPF.OpenFeatureDatasetNetwork(pFeatDataset);

        }
        IPolyline pPolyline;
        // 规划路线
        private void 规划路线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicke = false;
            CPF.StopPoints = mPointCollection;
            CPF.SolvePath("weight");
            pPolyline = CPF.PathPolyLine();
            ISimpleLineSymbol pLineSymbol = new SimpleLineSymbolClass();
            pLineSymbol.Color = lRGB;
            pLineSymbol.Width = 4;
            pLineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            ILineElement pPolylineEle = new LineElementClass();
            pPolylineEle.Symbol = pLineSymbol;
            IElement pEle = pPolylineEle as IElement;
            pEle.Geometry = pPolyline;
            pGraphicC = axMapControl1.ActiveView as IGraphicsContainer;//把地图的当前view作为图片的容器
            pGraphicC.AddElement(pEle, 0);//把刚刚的element转到容器上
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerArrow;
        }

        private void 清空路线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mPointCollection != null)
            {
                flag = 0;
                int count = mPointCollection.PointCount;
                mPointCollection.RemovePoints(0, count);
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                clearline();
            }
            else
            {
                MessageBox.Show("尚未计算路径，请计算后再清除！", "提示");
                return;
            }
        }

        //清除路径
        private void clearline()
        {
            this.axMapControl1.MousePointer = esriControlsMousePointer.esriPointerArrow;
            pGraphicC.DeleteAllElements();
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            axMapControl1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            layerIndex = comboBox1.SelectedIndex;
        }

        private void 添加目的景点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 7;
        }

        private void 景点周边查询ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            q_mapControl = this.axMapControl1.Object as IMapControl4;
            BufferQuery bufferQuery = new BufferQuery(q_mapControl);
            bufferQuery.Show(m_mapControl as IWin32Window);
            if (bufferQuery.IsDisposed)
                this.Activate();
        }

        private void 数据查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProToMap m_ProToMap = new ProToMap(axMapControl1);
            m_ProToMap.ShowDialog();
        }

        private void 地图保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog1;
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "保存地图文档";
            saveFileDialog1.Filter = "地图文档 (*.mxd)|*.mxd";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sFilePath = saveFileDialog1.FileName;
                if (sFilePath == "") return;

                if (m_MapDocument != null)
                {
                    if (sFilePath == m_MapDocument.DocumentFilename)
                    {
                        if (m_MapDocument.get_IsReadOnly(m_MapDocument.
                        DocumentFilename) == true)
                        {
                            MessageBox.Show("该地图文档为只读文件!");
                            return;
                        }
                        m_MapDocument.Save(m_MapDocument.UsesRelativePaths, true);
                    }
                    else
                    {
                        m_MapDocument.SaveAs(sFilePath, true, true);
                        MessageBox.Show("地图文档保存成功!");
                    }
                }
                else
                {
                    IMxdContents pMxdC;
                    pMxdC = axMapControl1.Map as IMxdContents;
                    m_MapDocument = new MapDocumentClass();
                    m_MapDocument.New(sFilePath);
                    m_MapDocument.ReplaceContents(pMxdC);
                    m_MapDocument.Save(true, true);
                }
            }
        }

        private void 指北针ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curOper = "AddNorthArrow";
        }

        private void axPageLayoutControl1_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {
            if (curOper == "AddNorthArrow")
            {
                IEnvelope pEnv = axPageLayoutControl1.TrackRectangle();
                IMapSurround pMapSurround;
                UID pID = new UIDClass();
                pID.Value = "esriCarto.MarkerNorthArrow";
                pMapSurround = CreateSurround(pID, pEnv, "North Arrow", axPageLayoutControl1.PageLayout);

            }
            else if (curOper == "AddLineScale")
            {

                IMapFrame pMapFrame = axPageLayoutControl1.GraphicsContainer.FindFrame(axPageLayoutControl1.ActiveView.FocusMap) as IMapFrame;
                UID uidScale = new UIDClass();
                uidScale.Value = "{6589F140-F7F7-11d2-B872-00600802E603}";
                IMapSurroundFrame pMapSurroundFrame = pMapFrame.CreateSurroundFrame(uidScale, null);
                IMapSurround pMapSurround = pMapSurroundFrame.MapSurround;
                IScaleBar pScaleBar = pMapSurround as IScaleBar;

                IEnvelope pEnv = axPageLayoutControl1.TrackRectangle();
                IElement pEle_ScaleBar = pMapSurroundFrame as IElement;
                pEle_ScaleBar.Geometry = pEnv;

                axPageLayoutControl1.GraphicsContainer.AddElement(pEle_ScaleBar, 0);
                axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
            else if (curOper == "AddLegend")
            {
                IGraphicsContainer pLengendGraphicsContainer = axPageLayoutControl1.GraphicsContainer;
                IMapFrame mapFrame = (IMapFrame)pLengendGraphicsContainer.FindFrame(axPageLayoutControl1.ActiveView.FocusMap);
                if (mapFrame == null)
                    return;
                UID uID = new UID();
                uID.Value = "esriCarto.Legend";
                IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uID, null);

                if (mapSurroundFrame == null)
                    return;
                if (mapSurroundFrame.MapSurround == null)
                    return;
                mapSurroundFrame.MapSurround.Name = "Legend";
                IEnvelope envelopeLegend = (IEnvelope)new Envelope();
                envelopeLegend.PutCoords(1, 1, 10, 10);
                IEnvelope pEnv = axPageLayoutControl1.TrackRectangle();
                IElement pLegendElement = (IElement)mapSurroundFrame;
                pLegendElement.Geometry = pEnv;

                axPageLayoutControl1.AddElement(pLegendElement, Type.Missing, Type.Missing, "Legend", 10);
                ILegend pLegend = (ILegend)mapSurroundFrame.MapSurround;
                pLegend.Name = "Legend";
                pLegend.Title = "图例";
                axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
            curOper = "";
        }

        private void 比例尺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curOper = "AddLineScale";
        }

        private void 图例ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curOper = "AddLegend";
        }

        private IMapSurround CreateSurround(UID pID, IEnvelope pEnv, string strName, IPageLayout pPageLayout)
        {
            IGraphicsContainer pGraphicsC;
            IActiveView pActiveView; IMapFrame pMapFrame;
            IMapSurroundFrame pMapSFrame;
            IElement pElement; IMap pMap;
            pGraphicsC = (IGraphicsContainer)pPageLayout;
            pActiveView = (IActiveView)pPageLayout;
            pMap = pActiveView.FocusMap;
            pMapFrame = (IMapFrame)pGraphicsC.FindFrame(pMap);
            pMapSFrame = pMapFrame.CreateSurroundFrame(pID, null);
            pMapSFrame.MapSurround.Name = strName;
            pElement = (IElement)pMapSFrame;
            pElement.Geometry = pEnv;
            pElement.Activate(pActiveView.ScreenDisplay);
            ITrackCancel pTrack = null;
            pTrack = new CancelTracker();

            pElement.Draw(pActiveView.ScreenDisplay, pTrack);
            pGraphicsC.AddElement(pElement, 0);
            pActiveView.Refresh();
            return pMapSFrame.MapSurround;
        }

        private void 启动编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsEditingStartCommandClass();
            command.OnCreate(axMapControl1.Object);
            command.OnClick();
        }

        private void 保存编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsEditingStopCommandClass();
            command.OnCreate(axMapControl1.Object);
            command.OnClick();
        }

        private void 停止编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsEditingSaveCommandClass();
            command.OnCreate(axMapControl1.Object);
            command.OnClick();
        }

        private void 目的点建议ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fo = new Form2(this);
            fo.Show();
        }

        private void 景点周边ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            q_mapControl = this.axMapControl1.Object as IMapControl4;
            m_mapControl = (IMapControl3)this.axMapControl1.Object;
            BufferQuery bufferQuery = new BufferQuery(q_mapControl);
            bufferQuery.Show(m_mapControl as IWin32Window);
            if (bufferQuery.IsDisposed)
                this.Activate();
        }
        ICustomizeDialog m_CustomizeDialog = new CustomizeDialogClass();
        private void button1_Click(object sender, EventArgs e)
        {
            m_CustomizeDialog.StartDialog(axToolbarControl1.hWnd);
        }

        private void 地图文档加载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog2;
            openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Title = "打开地图文档";
            openFileDialog2.Filter = "地图文档 (*.mxd)|*.mxd";
            openFileDialog2.ShowDialog();
            string sFilePath = openFileDialog2.FileName;
            if (axMapControl1.CheckMxFile(sFilePath))
            {
                axMapControl1.MousePointer =
                esriControlsMousePointer.esriPointerHourglass;
                axMapControl1.LoadMxFile(sFilePath, 0, Type.Missing);
                axMapControl1.MousePointer =
                esriControlsMousePointer.esriPointerDefault;
            }
        }

        private void 加载shpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IWorkspaceFactory pWorkspaceFactory;
            IFeatureWorkspace pFeatureWorkspace;
            IFeatureLayer pFeatureLayer;
            //获取当前路径和文件名
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open SHP Document";
            dlg.Filter = "SHP file(*.SHP)|*.SHP";
            dlg.ShowDialog();
            string strFullPath = dlg.FileName;
            if (strFullPath == "") return;
            int Index = strFullPath.LastIndexOf("\\");
            string filePath = strFullPath.Substring(0, Index);
            string fileName = strFullPath.Substring(Index + 1);
            //打开工作空间并添加shp文件
            pWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
            //注意此处的路径是不能带文件名的
            pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(filePath, 0);
            pFeatureLayer = new FeatureLayerClass();
            //注意这里的文件名是不能带路径的
            pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(fileName);
            pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
            axMapControl1.Map.AddLayer(pFeatureLayer);
            axMapControl1.ActiveView.Refresh();
        }
    }
}