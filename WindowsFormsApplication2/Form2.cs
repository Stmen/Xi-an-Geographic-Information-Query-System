using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        Form1 par;
        int maxNum = 5000; // 阈值
        public Form2(Form1 p)
        {
            InitializeComponent();
            par = p;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text; //名称
            if (name == "")
            {
                MessageBox.Show("查询内容为空，无法提供查询", "提示");
            }
            else
            {
                //找到图层
                IFeatureLayer pfeaturelayer = new FeatureLayer();
                pfeaturelayer = par.axMapControl1.get_Layer(0) as IFeatureLayer;

                //找到要素
                IQueryFilter pQueryFilter = new QueryFilter();
                pQueryFilter.WhereClause = "NAME like '%" + name + "%'";

                IFeatureCursor pFeatureCur = pfeaturelayer.Search(pQueryFilter, false);
                IFeatureSelection pFeatureSelection = pfeaturelayer as IFeatureSelection;
                pFeatureSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                IFeature pFeature = pFeatureCur.NextFeature();

                List<IFeature> pFeatureList = new List<IFeature>();

                while (pFeature != null)
                {
                    pFeatureList.Add(pFeature);
                    pFeature = pFeatureCur.NextFeature();
                }

                IFeature pF = pFeatureList[0];
               int con = Convert.ToInt32(pF.get_Value(6).ToString());

               if (maxNum < con)
               {
                   label2.Text = "景点人流超过阈值,不建议前往";
               }
               else {
                   label2.Text = "景点人流未超过阈值,可以前往";
               }
               
            }
        }
    }
}
