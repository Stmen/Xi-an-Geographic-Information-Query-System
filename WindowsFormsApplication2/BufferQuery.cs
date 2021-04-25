using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;

namespace WindowsFormsApplication2
{
    public partial class BufferQuery : Form
    {
        private IMapControl4 m_mapcontrol;
        private IMap m_map;
        IActiveView activeView;

        private IGeometryCollection queryGeometry;
        private IEngineEditor EngineEditor = null;
        IEnumLayer layers;
        ILayer layer;

        IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
        IWorkspace workspace;
        IFeatureWorkspace featureWorkspace;
        IFeatureClass featureClass;
        IDataset dataSet;
        ILayerEffects LayerEffects;
        IEnumFeature EnumFeature;

        //空间关系
        string strSpatialRelationship = "";    

        //临时图层名
        private static string tempFeatureLayerName="New Layer";

        IFields Fields = new FieldsClass();
        IFieldsEdit FieldsEdit;
        IField fieldUserDefined = new FieldClass();
        IFieldEdit FieldEdit;
        private IFeatureLayer m_featurelayer;
        IFeatureLayer FeatureLayer;
        IFeatureCursor featureCursor;
        IFeature feature;

        IGeometryDef GeometryDef = new GeometryDefClass();
        IGeometryDefEdit GeometryDefEdit;
        UID CLSID = new UIDClass();
        //是否可以选择
        bool seleDraw;
        //string featurelayername;//XtingWarning
        ITopologicalOperator pTopo;
        //缓冲区
        private double bufferDistance;
        string polygonBufferType = "多边形边界内外缓冲";//类型

        IGeometry pBuffer;
        ISpatialFilter SpatialFilter = new SpatialFilterClass();
        object missing = Type.Missing;

        public BufferQuery(IMapControl4 mapcontrol)
        {
            InitializeComponent();
            this.m_mapcontrol = mapcontrol;
            this.m_map = mapcontrol.ActiveView.FocusMap;

            EngineEditor = new EngineEditorClass();
            queryGeometry = new MultipointClass();
        }

        private void BufferQuery_Load(object sender, EventArgs e)
        { 
            layers = Getlayers();
            while ((layer = layers.Next()) != null)
            {
                if (layer is IFeatureLayer)
                    comboBox1.Items.Add(layer.Name);
            }
            this.comboBox1.SelectedIndex = 0;
            buttonQuery.Enabled = false;
            grpPolygonbufferType.Enabled = false;
        }
        //取得地图所有图层
        private IEnumLayer Getlayers()
        {
            if (m_map.LayerCount == 0) return null;
            layers = m_map.get_Layers(null, true);
            layers.Reset();
            return layers;
        }

       
        // 删除临时图层
        private bool DeleteTempFeatureClass()
        {
            try
            {
                workspace = workspaceFactory.OpenFromFile(System.IO.Path.GetTempPath(), 0);
                featureWorkspace = workspace as IFeatureWorkspace;
                featureClass = featureWorkspace.OpenFeatureClass(tempFeatureLayerName);
                dataSet = featureClass as IDataset;
                if (dataSet.CanDelete())
                {
                    dataSet.Delete();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false; 
            }
        }
        private void RemoveTempLayer()
        {
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                if (m_map.get_Layer(i).Name == tempFeatureLayerName)
                {
                    m_map.DelayEvents(true);
                    m_map.DeleteLayer(m_map.get_Layer(i));
                    break;
                }
            }
        }

        //添加临时图层
        private IFeatureLayer AddTempFeatureLayer()
        {
            try
            {
                featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetTempPath(), 0);
                featureClass = featureWorkspace.OpenFeatureClass(tempFeatureLayerName);
                m_featurelayer.FeatureClass = featureClass;
                m_featurelayer.Name = featureClass.AliasName;
                m_featurelayer.Visible = true;
                LayerEffects = m_featurelayer as ILayerEffects;
                LayerEffects.Transparency = 60;
                activeView = m_mapcontrol.ActiveView;
                activeView.FocusMap.AddLayer(m_featurelayer);
                activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                return m_featurelayer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // 绘制要素
        private IFeatureClass CreateFeatureClass(string geometrytype, ISpatialReference SpatialReference)
        {

                featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetTempPath(), 0);
                FieldsEdit = (IFieldsEdit)Fields;
                //只写属性
                FieldsEdit.FieldCount_2 = 2;

                FieldEdit = (IFieldEdit)fieldUserDefined;
                FieldEdit.Name_2 = "FID";
                FieldEdit.AliasName_2 = "OBJECT ID";
                FieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;

                FieldsEdit.set_Field(0, fieldUserDefined);

                fieldUserDefined = new FieldClass();
                FieldEdit = (IFieldEdit)fieldUserDefined;
                GeometryDefEdit = (IGeometryDefEdit)GeometryDef;

                switch (geometrytype)
                {
                    case "point":
                        GeometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
                        break;
                    case "polyline":
                        GeometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
                        break;
                    case "polygon":
                        GeometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
                        break;
                }
                GeometryDefEdit.GridCount_2 = 1;
                GeometryDefEdit.set_GridSize(0, 0);
                GeometryDefEdit.HasM_2 = false;
                GeometryDefEdit.HasZ_2 = false;

                if (SpatialReference != null)
                    GeometryDefEdit.SpatialReference_2 = SpatialReference;
                FieldEdit.Name_2 = "SHAPE";
                FieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
                FieldEdit.GeometryDef_2 = GeometryDef;
                FieldEdit.IsNullable_2 = true;
                FieldEdit.Required_2 = true;
                FieldsEdit.set_Field(1, fieldUserDefined);

                CLSID.Value = "esriGeoDatabase.Feature";
                return featureWorkspace.CreateFeatureClass(tempFeatureLayerName, Fields, CLSID, null, esriFeatureType.esriFTSimple, "SHAPE", "");

        }

        //开始编辑临时图层
        private void StartEditTempLayer(ILayer templayer)
        {
            if (templayer == null) return;
                if (EngineEditor == null) return;
                if (EngineEditor.EditState == esriEngineEditState.esriEngineStateEditing)
                    return;
                try
                {
                    dataSet = templayer as IDataset;
                    workspace = dataSet.Workspace;
                    EngineEditor.StartEditing(workspace, m_map);
                    ((IEngineEditLayers)EngineEditor).SetTargetLayer(templayer as IFeatureLayer, 0);
                }
                catch (Exception) { }
        }
        
        // 停止编辑并保存
        private void StopEditAndTempLayer(IFeatureLayer templayer, bool save)
        {
            if (templayer == null) return;
                if (EngineEditor.EditState == esriEngineEditState.esriEngineStateEditing)
                {
                    if (EngineEditor.HasEdits() == false)
                        EngineEditor.StopEditing(false);
                    EngineEditor.StopEditing(save);
                }
        }
        
        //制定选择工具
        private void SetSelectToolAsCurrentTool()
        {
            if (m_mapcontrol != null)
            {
                ICommand tool = new ControlsSelectFeaturesToolClass();
                tool.OnCreate(m_mapcontrol);
                m_mapcontrol.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
                m_mapcontrol.CurrentTool = tool as ITool;
            }
            else
                MessageBox.Show("请加载目标图层！");
        }
        
        // 设置自定义点工具
        private void SetCurrentSketchTool()
        {
            if (m_mapcontrol != null)
            {
                ICommand tool = null;
                tool = new ControlsEditingSketchToolClass();
                if (tool == null) return;
                tool.OnCreate(m_mapcontrol);
                m_mapcontrol.CurrentTool = tool as ITool;
            }
        }

      
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue >=0)
                return;
            else
            {
                MessageBox.Show("这里只能输入数字，请重试！");
                textBox1.Clear();
                return;
            }
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            //buttonQuery.Enabled = false;
            DeleteGraphics(); 
            if(radioButton1.Checked)
            {
                SaveSelectedFeaturesToQueryFeatureClass();
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("请选择图层！");
                return;
            }
            //创建缓冲区
            IGeometryCollection geometries = CreateBufferPolygons();
            if (geometries == null) return;
            StopEditAndTempLayer(m_featurelayer, true);

            SetAllLayersSelectable();
            ExecuteQuery(geometries);

            //清除临时图层上的选择要素
            IFeatureLayer featureLayer = GetFeatureLayer(tempFeatureLayerName);
            if (featureLayer == null) return;
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
            featureSelection.Clear();

            label6 .Text ="总查询对象个数: " + m_map.SelectionCount.ToString();

            m_mapcontrol.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            m_mapcontrol.Refresh();
        }

        //要素集选择
        private void GetConditionFeatures(string queriedLayer)
        {
            FeatureLayer = GetFeatureLayer(queriedLayer);
            //绘制点要素
            if (seleDraw==false)
            {                
                featureCursor = m_featurelayer.Search(null, true);
                feature = featureCursor.NextFeature();
                while (feature != null)
                {
                    queryGeometry.AddGeometry(feature.Shape, ref missing, ref missing);
                    feature = featureCursor.NextFeature();
                }
            }
            else
            {
                if (m_map.SelectionCount == 0) return;
                EnumFeature = m_map.FeatureSelection as IEnumFeature;
                EnumFeature.Reset();
                feature = EnumFeature.Next();
                while (feature != null)
                {
                    queryGeometry.AddGeometry(feature.Shape, ref missing, ref missing);
                    feature = EnumFeature.Next();
                }
            }
            pTopo = queryGeometry as ITopologicalOperator;
            bufferDistance = Convert.ToDouble(textBox1.Text) ;
            pBuffer = pTopo.Buffer(bufferDistance);
            SpatialFilter.Geometry = pBuffer;
            featureClass = FeatureLayer.FeatureClass;
            //判断各要素选择的条件
            switch (featureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    SpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    SpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    SpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    break;
                default: break;
            }
            IFeatureSelection FeatureSelection = FeatureLayer as IFeatureSelection;
            FeatureSelection.SelectFeatures(SpatialFilter, esriSelectionResultEnum.esriSelectionResultNew, false);

            m_mapcontrol.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            }

        // 取得图层要素
        private IFeatureLayer GetFeatureLayer(string Layername)
        {
            if (Getlayers() == null) return null;
            IEnumLayer layers = Getlayers();
            ILayer Layer = null;
            while ((Layer = layers.Next()) != null)
            {
                if (Layer.Name == Layername)
                    return Layer as IFeatureLayer;
            }
            return null;
        }

        private void buttoncancel_Click(object sender, EventArgs e)
        {
            RemoveTempLayer();
            DeleteGraphics();
            this.Close();
        }

        private void cboSpatialRelationship_SelectedIndexChanged(object sender, EventArgs e)
        {
            strSpatialRelationship = cboSpatialRelationship.SelectedItem.ToString();
            buttonQuery.Enabled = true; 
        }

        private void DeleteGraphics()
        {
            IGraphicsContainer graphicsContainer = m_map as IGraphicsContainer;
            graphicsContainer.DeleteAllElements();
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private IGeometryCollection CreateBufferPolygons()
        {
            IGeometryCollection geometries = new GeometryBagClass() as IGeometryCollection;
            if (featureClass == null) return null;
            if (Information.IsNumeric(textBox1.Text))
            {
                bufferDistance = Convert.ToDouble(textBox1.Text) / 100000;
            }
            else
                return null;
            IFeatureCursor featureCursor = featureClass.Search(null, false);
            IFeature feature = featureCursor.NextFeature();
            while (feature != null)
            {
                IGeometry geometry = feature.ShapeCopy;
                ITopologicalOperator topogeometry = geometry as ITopologicalOperator;
                if (topogeometry == null || geometry == null) return null;
                object obj = Type.Missing;
                IGeometry bufferResult;

                if (featureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                {
                    IPolygon4 polygon = geometry as IPolygon4;
                    IGeometry buffBoundaryExtAndInt;
                    ITopologicalOperator topoBuffer;
                    switch (polygonBufferType)
                    {
                        case "多边形边界内外缓冲":
                            buffBoundaryExtAndInt = BufferExtAndIntBoundary(polygon, bufferDistance, true);
                            geometries.AddGeometry(buffBoundaryExtAndInt, ref obj, ref obj);
                            break;
                        case "多边形边界外缓冲":
                            //与本身求差
                            IGeometry bufferPolygon = topogeometry.Buffer(bufferDistance);
                            topoBuffer = bufferPolygon as ITopologicalOperator;
                            bufferResult = topoBuffer.Difference(geometry);
                            DrawGraphics(bufferResult);
                            geometries.AddGeometry(bufferResult, ref obj, ref obj);
                            break;
                        case "多边形边界内缓冲":
                            //与本身求交
                            buffBoundaryExtAndInt = BufferExtAndIntBoundary(polygon, bufferDistance, false);
                            topoBuffer = buffBoundaryExtAndInt as ITopologicalOperator;
                            bufferResult = topoBuffer.Intersect(geometry, esriGeometryDimension.esriGeometry2Dimension);
                            DrawGraphics(bufferResult);
                            geometries.AddGeometry(bufferResult, ref obj, ref obj);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    bufferResult = topogeometry.Buffer(bufferDistance);
                    DrawGraphics(bufferResult);
                    geometries.AddGeometry(bufferResult, ref obj, ref obj);
                }
                feature = featureCursor.NextFeature();
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);
            ITopologicalOperator topoGeometries = geometries as ITopologicalOperator;
            topoGeometries.Simplify();
            return geometries;
        }

        private void rdoBndExtInt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBndExtInt.Checked)
                polygonBufferType = "多边形边界内外缓冲";
        }

        private void rdoBndExt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBndExt.Checked)
                polygonBufferType = "多边形边界外缓冲";
        }

        private void rdoBndInt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBndInt.Checked)
                polygonBufferType = "多边形边界内缓冲"; 
        }

        private IGeometry BufferExtAndIntBoundary(IPolygon4 polygon, double bufferDistance, bool draw)
        {
            IGeometry bndBuffer;
            object obj = Type.Missing;
            IGeometryCollection bufferGeometries = new GeometryBagClass() as IGeometryCollection;

            IGeometryBag exteriorRings = polygon.ExteriorRingBag;
            IEnumGeometry exteriorRingsEnum = exteriorRings as IEnumGeometry;
            exteriorRingsEnum.Reset();
            IRing currentExteriorRing = exteriorRingsEnum.Next() as IRing;
            while (currentExteriorRing != null)
            {
                bndBuffer = BufferBoundary(currentExteriorRing, bufferDistance, false);
                bufferGeometries.AddGeometry(bndBuffer, ref obj, ref obj);

                IGeometryBag interiorRings = polygon.get_InteriorRingBag(currentExteriorRing);
                IEnumGeometry interiorRingsEnum = interiorRings as IEnumGeometry;
                interiorRingsEnum.Reset();
                IRing currentInteriorRing = interiorRingsEnum.Next() as IRing;
                while (currentInteriorRing != null)
                {
                    bndBuffer = BufferBoundary(currentInteriorRing, bufferDistance, false);
                    bufferGeometries.AddGeometry(bndBuffer, ref obj, ref obj);
                    currentInteriorRing = interiorRingsEnum.Next() as IRing;
                }
                currentExteriorRing = exteriorRingsEnum.Next() as IRing;
            }
            //两缓冲区的合并和简化
            ITopologicalOperator topoBufferGeometries = bufferGeometries as ITopologicalOperator;
            topoBufferGeometries.Simplify();
            IPolygon buffPolygon = new PolygonClass();
            ITopologicalOperator topoPolygon = buffPolygon as ITopologicalOperator;
            IEnumGeometry enumGeometry = bufferGeometries as IEnumGeometry;
            topoPolygon.ConstructUnion(enumGeometry);
            if (draw) DrawGraphics(buffPolygon as IGeometry);
            return buffPolygon as IGeometry;
        }

        private IGeometry BufferBoundary(IRing currentRing, double bufferDistance, bool draw)
        {
            ISegmentCollection polyline = new PolylineClass() as ISegmentCollection;
            ISegmentCollection ringSegmentCollection = currentRing as ISegmentCollection;
            List<ISegment> ringSegments = new List<ISegment>();
            for (int i = 0; i < ringSegmentCollection.SegmentCount; i++)
            {
                ringSegments.Add(ringSegmentCollection.get_Segment(i));
            }
            ISegment[] ringSegmentsArray = ringSegments.ToArray();

            IGeometryBridge geometryBridge = new GeometryEnvironmentClass();
            geometryBridge.AddSegments(polyline, ref ringSegmentsArray);
            ITopologicalOperator topoBndBuffer = polyline as ITopologicalOperator;
            IGeometry bndBuffer = topoBndBuffer.Buffer(bufferDistance);
            if (draw) DrawGraphics(bndBuffer);
            return bndBuffer;
        }

        private void DrawGraphics(IGeometry geometry)
        {
            IRgbColor rgbColor = GetRGBColor(255, 0, 0);
            IRgbColor outlineRgbColor = GetRGBColor(255, 255, 0);
            AddGraphic(m_map, geometry, rgbColor, outlineRgbColor);
        }

        private IRgbColor GetRGBColor(int r, int g, int b)
        {
            IRgbColor color = new RgbColorClass();
            color.Red = r;
            color.Green = g;
            color.Blue = b;
            return color;
        }

        public void AddGraphic(IMap map, IGeometry geometry, IRgbColor rgbColor, IRgbColor outlineRgbColor)
        {
            if (geometry == null) return;
            ESRI.ArcGIS.Carto.IGraphicsContainer graphicsContainer = (ESRI.ArcGIS.Carto.IGraphicsContainer)map;
            ESRI.ArcGIS.Carto.IElement element = null;
            if ((geometry.GeometryType) == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint)
            {
                ESRI.ArcGIS.Display.ISimpleMarkerSymbol simpleMarkerSymbol = new ESRI.ArcGIS.Display.SimpleMarkerSymbolClass();
                simpleMarkerSymbol.Color = rgbColor;
                simpleMarkerSymbol.Outline = true;
                simpleMarkerSymbol.OutlineColor = outlineRgbColor;
                simpleMarkerSymbol.Size = 15;
                simpleMarkerSymbol.Style = ESRI.ArcGIS.Display.esriSimpleMarkerStyle.esriSMSCircle;

                ESRI.ArcGIS.Carto.IMarkerElement markerElement = new ESRI.ArcGIS.Carto.MarkerElementClass();
                markerElement.Symbol = simpleMarkerSymbol;
                element = (ESRI.ArcGIS.Carto.IElement)markerElement; 
            }
            else if ((geometry.GeometryType) == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline)
            {
                ESRI.ArcGIS.Display.ISimpleLineSymbol simpleLineSymbol = new ESRI.ArcGIS.Display.SimpleLineSymbolClass();
                simpleLineSymbol.Color = rgbColor;
                simpleLineSymbol.Style = ESRI.ArcGIS.Display.esriSimpleLineStyle.esriSLSSolid;
                simpleLineSymbol.Width = 5;

                ESRI.ArcGIS.Carto.ILineElement lineElement = new ESRI.ArcGIS.Carto.LineElementClass();
                lineElement.Symbol = simpleLineSymbol;
                element = (ESRI.ArcGIS.Carto.IElement)lineElement;
            }
            else if ((geometry.GeometryType) == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon)
            {
                ESRI.ArcGIS.Display.ISimpleFillSymbol simpleFillSymbol = new ESRI.ArcGIS.Display.SimpleFillSymbolClass();
                simpleFillSymbol.Color = rgbColor;
                simpleFillSymbol.Style = ESRI.ArcGIS.Display.esriSimpleFillStyle.esriSFSForwardDiagonal;
                ESRI.ArcGIS.Carto.IFillShapeElement fillShapeElement = new ESRI.ArcGIS.Carto.PolygonElementClass();
                fillShapeElement.Symbol = simpleFillSymbol;
                element = (ESRI.ArcGIS.Carto.IElement)fillShapeElement; 
            }
            if (!(element == null))
            {
                element.Geometry = geometry;
                graphicsContainer.AddElement(element, 0);
            }
        }

        private void ExecuteQuery(IGeometryCollection geometries)
        {
            //if (featureClass == null || featureClass.FeatureCount(null) == 0)
            //    return;
                SelectOneLayer(comboBox1.SelectedItem.ToString(), geometries);
        }
        private void SelectOneLayer(string queriedLayer, IGeometryCollection geometries)
        {
            IFeatureLayer featureLayer = GetFeatureLayer(queriedLayer);
            if (featureLayer == null) return;
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
            ISpatialFilter spatialFilter = new SpatialFilterClass();
            for (int i = 0; i < geometries.GeometryCount; i++)
            {
                spatialFilter.Geometry = geometries.get_Geometry(i);
                spatialFilter.GeometryField = featureLayer.FeatureClass.ShapeFieldName;
                if (strSpatialRelationship == "") strSpatialRelationship = "相交";
                //switch (strSpatialRelationship)
                //{
                //    case "相交":
                spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                //        break;
                //    case "包含":
                //        spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                //        break;
                //    case "被包含":
                //        spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                //        break;
                //    default:
                //        break;
                //}
                featureSelection.SelectFeatures(spatialFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
            }
        }

        private void SetAllLayersSelectable()
        {
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                IFeatureLayer featureLayer = m_map.get_Layer(i) as IFeatureLayer;
                if (featureLayer == null) return;
                featureLayer.Selectable = true;
            }
        }

        private void SaveSelectedFeaturesToQueryFeatureClass()
        {
            try
            {
                ISelection selection = m_map.FeatureSelection;
                IEnumFeature selFeatures = selection as IEnumFeature;
                selFeatures.Reset();
                IFeature selFeature = selFeatures.Next();
                while (selFeature != null)
                {
                    IFeature feature = featureClass.CreateFeature();
                    feature.Shape = selFeature.Shape;
                    feature.Store();
                    selFeature = selFeatures.Next();
                }
                m_map.ClearSelection();
                activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            }
            catch
            {

            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                m_map.ClearSelection();
                //DeleteGraphics();
                DeleteTempFeatureClass();
                featureClass = CreateFeatureClass("polygon", m_map.SpatialReference);
                if (featureClass == null) return;
                m_featurelayer = new FeatureLayerClass();
                m_featurelayer.FeatureClass = featureClass;
                m_featurelayer.Name = featureClass.AliasName;
                StopEditAndTempLayer(m_featurelayer, false);
                //移除临时图层
                RemoveTempLayer();
                //添加临时图层
                AddTempFeatureLayer();
                //开始编辑
                StartEditTempLayer(m_featurelayer);
                //工具准备
                SetSelectToolAsCurrentTool();
                //SetSelectableLayers
                for (int i = 0; i < m_map.LayerCount; i++)
                {
                    IFeatureLayer featureLayer = m_map.get_Layer(i) as IFeatureLayer;
                    if (featureLayer == null) return;
                    if (featureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                    {
                        featureLayer.Selectable = true;
                    }
                    else
                    {
                        featureLayer.Selectable = false;
                    }
                }

                seleDraw = true;
                grpPolygonbufferType.Enabled = true;
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                m_map.ClearSelection();
                //DeleteGraphics();
                //初始化
                DeleteTempFeatureClass();
                featureClass = CreateFeatureClass("point", m_map.SpatialReference);
                if (featureClass == null) return;
                m_featurelayer = new FeatureLayerClass();
                m_featurelayer.FeatureClass = featureClass;
                m_featurelayer.Name = featureClass.AliasName;
                StopEditAndTempLayer(m_featurelayer, false);
                //移除临时图层
                RemoveTempLayer();
                //添加临时图层
                AddTempFeatureLayer();
                this.buttonQuery.Enabled = true;
                //开始编辑
                StartEditTempLayer(m_featurelayer);

                //工具准备
                SetCurrentSketchTool();
                seleDraw = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RemoveTempLayer();
            DeleteGraphics();

             IFeatureLayer featureLayer = GetFeatureLayer(comboBox1.SelectedItem.ToString());
            ESRI.ArcGIS.Carto.IFeatureSelection featureSelection = featureLayer as ESRI.ArcGIS.Carto.IFeatureSelection;
            activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeoSelection, null, null);
            // 清除所有选择
            featureSelection.Clear();
        }
       
    }
}
