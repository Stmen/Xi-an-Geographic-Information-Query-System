namespace WindowsFormsApplication2
{
    partial class BufferQuery
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
            this.buttoncancel = new System.Windows.Forms.Button();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSpatialRelationship = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpPolygonbufferType = new System.Windows.Forms.GroupBox();
            this.rdoBndInt = new System.Windows.Forms.RadioButton();
            this.rdoBndExt = new System.Windows.Forms.RadioButton();
            this.rdoBndExtInt = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.grpPolygonbufferType.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttoncancel
            // 
            this.buttoncancel.Location = new System.Drawing.Point(138, 153);
            this.buttoncancel.Name = "buttoncancel";
            this.buttoncancel.Size = new System.Drawing.Size(75, 23);
            this.buttoncancel.TabIndex = 17;
            this.buttoncancel.Text = "取消";
            this.buttoncancel.UseVisualStyleBackColor = true;
            this.buttoncancel.Click += new System.EventHandler(this.buttoncancel_Click);
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(32, 153);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(75, 23);
            this.buttonQuery.TabIndex = 16;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(138, 100);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 21);
            this.textBox1.TabIndex = 14;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "查找半径距离:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(138, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 20);
            this.comboBox1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "选择查找图层：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "选择空间关系：      ";
            // 
            // cboSpatialRelationship
            // 
            this.cboSpatialRelationship.FormattingEnabled = true;
            this.cboSpatialRelationship.Items.AddRange(new object[] {
            "相交",
            "包含",
            "被包含"});
            this.cboSpatialRelationship.Location = new System.Drawing.Point(544, 107);
            this.cboSpatialRelationship.Name = "cboSpatialRelationship";
            this.cboSpatialRelationship.Size = new System.Drawing.Size(196, 20);
            this.cboSpatialRelationship.TabIndex = 33;
            this.cboSpatialRelationship.SelectedIndexChanged += new System.EventHandler(this.cboSpatialRelationship_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "添加景点位置:";
            // 
            // grpPolygonbufferType
            // 
            this.grpPolygonbufferType.Controls.Add(this.rdoBndInt);
            this.grpPolygonbufferType.Controls.Add(this.rdoBndExt);
            this.grpPolygonbufferType.Controls.Add(this.rdoBndExtInt);
            this.grpPolygonbufferType.Location = new System.Drawing.Point(474, 180);
            this.grpPolygonbufferType.Name = "grpPolygonbufferType";
            this.grpPolygonbufferType.Size = new System.Drawing.Size(321, 90);
            this.grpPolygonbufferType.TabIndex = 35;
            this.grpPolygonbufferType.TabStop = false;
            this.grpPolygonbufferType.Text = "缓冲类型";
            // 
            // rdoBndInt
            // 
            this.rdoBndInt.AutoSize = true;
            this.rdoBndInt.Location = new System.Drawing.Point(10, 54);
            this.rdoBndInt.Name = "rdoBndInt";
            this.rdoBndInt.Size = new System.Drawing.Size(119, 16);
            this.rdoBndInt.TabIndex = 2;
            this.rdoBndInt.Text = "多边形边界内缓冲";
            this.rdoBndInt.UseVisualStyleBackColor = true;
            this.rdoBndInt.CheckedChanged += new System.EventHandler(this.rdoBndInt_CheckedChanged);
            // 
            // rdoBndExt
            // 
            this.rdoBndExt.AutoSize = true;
            this.rdoBndExt.Location = new System.Drawing.Point(160, 19);
            this.rdoBndExt.Name = "rdoBndExt";
            this.rdoBndExt.Size = new System.Drawing.Size(119, 16);
            this.rdoBndExt.TabIndex = 1;
            this.rdoBndExt.Text = "多边形边界外缓冲";
            this.rdoBndExt.UseVisualStyleBackColor = true;
            this.rdoBndExt.CheckedChanged += new System.EventHandler(this.rdoBndExt_CheckedChanged);
            // 
            // rdoBndExtInt
            // 
            this.rdoBndExtInt.AutoSize = true;
            this.rdoBndExtInt.Checked = true;
            this.rdoBndExtInt.Location = new System.Drawing.Point(10, 19);
            this.rdoBndExtInt.Name = "rdoBndExtInt";
            this.rdoBndExtInt.Size = new System.Drawing.Size(131, 16);
            this.rdoBndExtInt.TabIndex = 0;
            this.rdoBndExtInt.TabStop = true;
            this.rdoBndExtInt.Text = "多边形边界内外缓冲";
            this.rdoBndExtInt.UseVisualStyleBackColor = true;
            this.rdoBndExtInt.CheckedChanged += new System.EventHandler(this.rdoBndExtInt_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(496, 72);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(107, 16);
            this.radioButton1.TabIndex = 37;
            this.radioButton1.Text = "选择多边形对象";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(138, 57);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 16);
            this.radioButton2.TabIndex = 38;
            this.radioButton2.Text = "手动添加";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 39;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "清除";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BufferQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 250);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.grpPolygonbufferType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboSpatialRelationship);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttoncancel);
            this.Controls.Add(this.buttonQuery);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "BufferQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "景点周边";
            this.Load += new System.EventHandler(this.BufferQuery_Load);
            this.grpPolygonbufferType.ResumeLayout(false);
            this.grpPolygonbufferType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttoncancel;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSpatialRelationship;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpPolygonbufferType;
        private System.Windows.Forms.RadioButton rdoBndInt;
        private System.Windows.Forms.RadioButton rdoBndExt;
        private System.Windows.Forms.RadioButton rdoBndExtInt;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}