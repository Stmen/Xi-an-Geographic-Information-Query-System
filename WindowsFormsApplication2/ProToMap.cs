using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;

namespace WindowsFormsApplication2
{
    public partial class ProToMap : Form
    {
        #region 变量声明
        AxMapControl pMapCtrl;
        public IMap pMap;
        public static int Layerindex = -1;
        public ITable pTable;
        public int n = -1;
        public static int fieldIndex = -1;
        public string fieldname;
        #endregion

        public ProToMap(AxMapControl MapCtrl)
        {
            InitializeComponent();
            pMapCtrl = MapCtrl;
            pMap = MapCtrl.Map;
        }

        private void ProToMap_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            int layCount = 0;
            layCount = pMap.LayerCount;
            for (int i = 0; i < layCount; i++)
            {
                comboBox1.Items.Add(pMap.get_Layer(i).Name);
            }
        }
        #region  计算器
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += " = ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += " > ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += " < ";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += " <> ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += " >= ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += " <= ";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += " Not ";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += " And ";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += " Or ";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += " % ";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += " ( ";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += " ) ";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += " is ";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += " Like ";
        }
        #endregion

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            textBox1.Text = " ";
            pMapCtrl.Map.ClearSelection();
            Layerindex = comboBox1.SelectedIndex;
            if (pMap.LayerCount == 0)
            {
                MessageBox.Show("请先加载地图！", "提示");
            }
            else
            {
                if (Layerindex != -1)
                {
                    IGeoFeatureLayer pGeoFeatureLayer = (IGeoFeatureLayer)pMap.get_Layer(Layerindex);
                    pTable = (ITable)pGeoFeatureLayer;
                    int num1 = pTable.Fields.FieldCount;
                    listBox1.Items.Clear();
                    for (int i = 0; i < num1; i++)
                    {
                        IField item = pTable.Fields.get_Field(i);
                        if (item.Name.ToString() == "Shape" || item.Name.ToString() == "SHAPE")
                        {
                            n = i;
                            continue;
                        }
                        listBox1.Items.Add(item.Name.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("请先选择图层！", "提示");
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text += listBox1.Text;
            listBox2.Items.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            fieldIndex = listBox1.SelectedIndex;

            if (pMap.LayerCount == 0)
            {
                MessageBox.Show("请先加载地图！", "提示");
            }
            else
            {
                if (Layerindex != -1)
                {
                    if (fieldIndex != -1)
                    {
                        if (fieldIndex >= n)
                            fieldIndex++;
                        fieldname = pTable.Fields.get_Field(fieldIndex).Name;
                        IQueryFilter pQueryFilter;
                        pQueryFilter = new QueryFilterClass();
                        pQueryFilter.AddField(fieldname);
                        ICursor pCursor = pTable.Search(pQueryFilter, false);
                        IRow pRow = pCursor.NextRow();
                        while (pRow != null)
                        {
                            listBox2.Items.Add(pRow.get_Value(fieldIndex).ToString());
                            pRow = pCursor.NextRow();
                        }
                    }
                    else
                    {
                        MessageBox.Show("请先选择图层字段！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请先选择图层！", "提示");
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pTable.Fields.get_Field(fieldIndex).Type.ToString() == "esriFieldTypeString")
                textBox1.Text += "'" + listBox2.SelectedItem + "'";
            else
                textBox1.Text += listBox2.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = " ";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Text = " ";
            Layerindex = -1;
        }

        private void Select_Click(object sender, EventArgs e)
        {
            string pQuerySentence = textBox1.Text;
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.WhereClause = pQuerySentence;
            fieldIndex = listBox1.SelectedIndex;

            if (pMap.LayerCount == 0)
            {
                MessageBox.Show("请先加载地图！", "提示");
            }
            else
            {
                if (Layerindex != -1)
                {
                    if (fieldIndex != -1)
                    {
                        IFeatureSelection pFeatureSelection;
                        pFeatureSelection = (IFeatureSelection)pMap.get_Layer(Layerindex);//aocuo
                        try
                        {
                            pFeatureSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                            pFeatureSelection.SelectionChanged();

                            ISelectionSet pSelectionSet = pFeatureSelection.SelectionSet;
                            ICursor pCursor = null;
                            pSelectionSet.Search(null, false, out pCursor);
                            IFeatureCursor pFeatureCursor = (IFeatureCursor)pCursor;
                            IFeature pFeature = pFeatureCursor.NextFeature();

                            IEnvelope pEnvelope = new EnvelopeClass();
                            int index = 0;
                            bool b = false;
                            IFeature pFea = null;
                            while (pFeature != null)
                            {
                                index++;
                                if (pFeature.Shape.GeometryType == esriGeometryType.esriGeometryPoint)
                                    b = true;
                                pFea = pFeature;
                                pEnvelope.Union(pFeature.Extent);
                                pFeature = pFeatureCursor.NextFeature();
                            }
                            if (index == 1 && b)
                            {
                                IPoint pPoint = pFea.Shape as IPoint;
                                pMapCtrl.CenterAt(pPoint);
                                ICommand pCommand = new ControlsZoomToSelectedCommandClass();
                                pCommand.OnCreate(pMapCtrl.Object);
                                pCommand.OnClick();
                            }
                            else
                            {
                                pEnvelope.Expand(1.5, 1.5, true);
                                pMapCtrl.ActiveView.Extent = pEnvelope;
                            }
                            pMapCtrl.ActiveView.Refresh();
                            pMapCtrl.ActiveView.ScreenDisplay.UpdateWindow();
                            pMapCtrl.FlashShape(pFea.Shape, 3, 500, null);
                        }
                        catch
                        {
                            MessageBox.Show("查询语句无效！语法错误(操作符丢失)在查询表达式'" + pQuerySentence + "'中。", "属性查询", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请先选择图层字段！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请先选择图层！", "提示");
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
