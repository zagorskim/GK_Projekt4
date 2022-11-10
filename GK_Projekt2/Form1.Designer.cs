using ObjParser;

namespace GK_Projekt2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImport = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAnimation = new System.Windows.Forms.Button();
            this.cbMesh = new System.Windows.Forms.CheckBox();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.tlpSliders = new System.Windows.Forms.TableLayoutPanel();
            this.sbLightB = new System.Windows.Forms.HScrollBar();
            this.lblLightB = new System.Windows.Forms.Label();
            this.sbLightG = new System.Windows.Forms.HScrollBar();
            this.lblLightG = new System.Windows.Forms.Label();
            this.sbLightR = new System.Windows.Forms.HScrollBar();
            this.lblLightR = new System.Windows.Forms.Label();
            this.sbm = new System.Windows.Forms.HScrollBar();
            this.lblm = new System.Windows.Forms.Label();
            this.sbLightZ = new System.Windows.Forms.HScrollBar();
            this.lblLightZ = new System.Windows.Forms.Label();
            this.sbLightY = new System.Windows.Forms.HScrollBar();
            this.lblLightY = new System.Windows.Forms.Label();
            this.sbLightX = new System.Windows.Forms.HScrollBar();
            this.lblLightX = new System.Windows.Forms.Label();
            this.sbKs = new System.Windows.Forms.HScrollBar();
            this.lblKs = new System.Windows.Forms.Label();
            this.lblKd = new System.Windows.Forms.Label();
            this.sbKd = new System.Windows.Forms.HScrollBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.flpMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.tlpSliders.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(5, 5);
            this.btnImport.Margin = new System.Windows.Forms.Padding(5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(73, 77);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.flpMenu, 0, 0);
            this.tlpMain.Controls.Add(this.pbCanvas, 0, 1);
            this.tlpMain.Controls.Add(this.tlpSliders, 1, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Size = new System.Drawing.Size(800, 888);
            this.tlpMain.TabIndex = 1;
            // 
            // flpMenu
            // 
            this.flpMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flpMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpMain.SetColumnSpan(this.flpMenu, 2);
            this.flpMenu.Controls.Add(this.btnImport);
            this.flpMenu.Controls.Add(this.btnAnimation);
            this.flpMenu.Controls.Add(this.cbMesh);
            this.flpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenu.Location = new System.Drawing.Point(0, 0);
            this.flpMenu.Margin = new System.Windows.Forms.Padding(0);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(800, 88);
            this.flpMenu.TabIndex = 3;
            // 
            // btnAnimation
            // 
            this.btnAnimation.Location = new System.Drawing.Point(88, 5);
            this.btnAnimation.Margin = new System.Windows.Forms.Padding(5);
            this.btnAnimation.Name = "btnAnimation";
            this.btnAnimation.Size = new System.Drawing.Size(71, 77);
            this.btnAnimation.TabIndex = 1;
            this.btnAnimation.Text = "Start Animation";
            this.btnAnimation.UseVisualStyleBackColor = true;
            this.btnAnimation.Click += new System.EventHandler(this.btnAnimation_Click);
            // 
            // cbMesh
            // 
            this.cbMesh.AutoSize = true;
            this.cbMesh.Checked = true;
            this.cbMesh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMesh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMesh.Location = new System.Drawing.Point(167, 3);
            this.cbMesh.Name = "cbMesh";
            this.cbMesh.Size = new System.Drawing.Size(55, 81);
            this.cbMesh.TabIndex = 2;
            this.cbMesh.Text = "Mesh";
            this.cbMesh.UseVisualStyleBackColor = true;
            this.cbMesh.CheckedChanged += new System.EventHandler(this.cbMesh_CheckedChanged);
            // 
            // pbCanvas
            // 
            this.pbCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCanvas.Location = new System.Drawing.Point(10, 98);
            this.pbCanvas.Margin = new System.Windows.Forms.Padding(10);
            this.pbCanvas.MaximumSize = new System.Drawing.Size(380, 380);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(380, 380);
            this.pbCanvas.TabIndex = 2;
            this.pbCanvas.TabStop = false;
            // 
            // tlpSliders
            // 
            this.tlpSliders.ColumnCount = 1;
            this.tlpSliders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSliders.Controls.Add(this.sbLightB, 0, 17);
            this.tlpSliders.Controls.Add(this.lblLightB, 0, 16);
            this.tlpSliders.Controls.Add(this.sbLightG, 0, 15);
            this.tlpSliders.Controls.Add(this.lblLightG, 0, 14);
            this.tlpSliders.Controls.Add(this.sbLightR, 0, 13);
            this.tlpSliders.Controls.Add(this.lblLightR, 0, 12);
            this.tlpSliders.Controls.Add(this.sbm, 0, 5);
            this.tlpSliders.Controls.Add(this.lblm, 0, 4);
            this.tlpSliders.Controls.Add(this.sbLightZ, 0, 11);
            this.tlpSliders.Controls.Add(this.lblLightZ, 0, 10);
            this.tlpSliders.Controls.Add(this.sbLightY, 0, 9);
            this.tlpSliders.Controls.Add(this.lblLightY, 0, 8);
            this.tlpSliders.Controls.Add(this.sbLightX, 0, 7);
            this.tlpSliders.Controls.Add(this.lblLightX, 0, 6);
            this.tlpSliders.Controls.Add(this.sbKs, 0, 3);
            this.tlpSliders.Controls.Add(this.lblKs, 0, 2);
            this.tlpSliders.Controls.Add(this.lblKd, 0, 0);
            this.tlpSliders.Controls.Add(this.sbKd, 0, 1);
            this.tlpSliders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSliders.Location = new System.Drawing.Point(403, 91);
            this.tlpSliders.Name = "tlpSliders";
            this.tlpSliders.RowCount = 19;
            this.tlpMain.SetRowSpan(this.tlpSliders, 2);
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSliders.Size = new System.Drawing.Size(394, 794);
            this.tlpSliders.TabIndex = 4;
            // 
            // sbLightB
            // 
            this.sbLightB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbLightB.Location = new System.Drawing.Point(0, 510);
            this.sbLightB.Name = "sbLightB";
            this.sbLightB.Size = new System.Drawing.Size(394, 30);
            this.sbLightB.TabIndex = 21;
            this.sbLightB.Value = 100;
            this.sbLightB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbLightB_Scroll);
            // 
            // lblLightB
            // 
            this.lblLightB.AutoSize = true;
            this.lblLightB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLightB.Location = new System.Drawing.Point(3, 495);
            this.lblLightB.Name = "lblLightB";
            this.lblLightB.Size = new System.Drawing.Size(388, 15);
            this.lblLightB.TabIndex = 20;
            this.lblLightB.Text = "Light B Value";
            // 
            // sbLightG
            // 
            this.sbLightG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbLightG.Location = new System.Drawing.Point(0, 450);
            this.sbLightG.Name = "sbLightG";
            this.sbLightG.Size = new System.Drawing.Size(394, 30);
            this.sbLightG.TabIndex = 19;
            this.sbLightG.Value = 100;
            this.sbLightG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbLightG_Scroll);
            // 
            // lblLightG
            // 
            this.lblLightG.AutoSize = true;
            this.lblLightG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLightG.Location = new System.Drawing.Point(3, 435);
            this.lblLightG.Name = "lblLightG";
            this.lblLightG.Size = new System.Drawing.Size(388, 15);
            this.lblLightG.TabIndex = 18;
            this.lblLightG.Text = "Light G Value";
            // 
            // sbLightR
            // 
            this.sbLightR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbLightR.Location = new System.Drawing.Point(0, 390);
            this.sbLightR.Name = "sbLightR";
            this.sbLightR.Size = new System.Drawing.Size(394, 30);
            this.sbLightR.TabIndex = 17;
            this.sbLightR.Value = 100;
            this.sbLightR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbLightR_Scroll);
            // 
            // lblLightR
            // 
            this.lblLightR.AutoSize = true;
            this.lblLightR.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLightR.Location = new System.Drawing.Point(3, 375);
            this.lblLightR.Name = "lblLightR";
            this.lblLightR.Size = new System.Drawing.Size(388, 15);
            this.lblLightR.TabIndex = 16;
            this.lblLightR.Text = "Light R Value";
            // 
            // sbm
            // 
            this.sbm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbm.Location = new System.Drawing.Point(0, 150);
            this.sbm.Minimum = 1;
            this.sbm.Name = "sbm";
            this.sbm.Size = new System.Drawing.Size(394, 30);
            this.sbm.TabIndex = 15;
            this.sbm.Value = 1;
            this.sbm.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbm_Scroll);
            // 
            // lblm
            // 
            this.lblm.AutoSize = true;
            this.lblm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblm.Location = new System.Drawing.Point(3, 135);
            this.lblm.Name = "lblm";
            this.lblm.Size = new System.Drawing.Size(388, 15);
            this.lblm.TabIndex = 14;
            this.lblm.Text = "m Value";
            // 
            // sbLightZ
            // 
            this.sbLightZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbLightZ.Location = new System.Drawing.Point(0, 330);
            this.sbLightZ.Name = "sbLightZ";
            this.sbLightZ.Size = new System.Drawing.Size(394, 30);
            this.sbLightZ.TabIndex = 13;
            this.sbLightZ.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbLightZ_Scroll);
            // 
            // lblLightZ
            // 
            this.lblLightZ.AutoSize = true;
            this.lblLightZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLightZ.Location = new System.Drawing.Point(3, 315);
            this.lblLightZ.Name = "lblLightZ";
            this.lblLightZ.Size = new System.Drawing.Size(388, 15);
            this.lblLightZ.TabIndex = 12;
            this.lblLightZ.Text = "Light Z";
            // 
            // sbLightY
            // 
            this.sbLightY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbLightY.Location = new System.Drawing.Point(0, 270);
            this.sbLightY.Name = "sbLightY";
            this.sbLightY.Size = new System.Drawing.Size(394, 30);
            this.sbLightY.TabIndex = 11;
            this.sbLightY.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbLightY_Scroll);
            // 
            // lblLightY
            // 
            this.lblLightY.AutoSize = true;
            this.lblLightY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLightY.Location = new System.Drawing.Point(3, 255);
            this.lblLightY.Name = "lblLightY";
            this.lblLightY.Size = new System.Drawing.Size(388, 15);
            this.lblLightY.TabIndex = 10;
            this.lblLightY.Text = "Light Y";
            // 
            // sbLightX
            // 
            this.sbLightX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbLightX.Location = new System.Drawing.Point(0, 210);
            this.sbLightX.Name = "sbLightX";
            this.sbLightX.Size = new System.Drawing.Size(394, 30);
            this.sbLightX.TabIndex = 9;
            this.sbLightX.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbLightX_Scroll);
            // 
            // lblLightX
            // 
            this.lblLightX.AutoSize = true;
            this.lblLightX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLightX.Location = new System.Drawing.Point(3, 195);
            this.lblLightX.Name = "lblLightX";
            this.lblLightX.Size = new System.Drawing.Size(388, 15);
            this.lblLightX.TabIndex = 8;
            this.lblLightX.Text = "Light X";
            // 
            // sbKs
            // 
            this.sbKs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbKs.Location = new System.Drawing.Point(0, 90);
            this.sbKs.Name = "sbKs";
            this.sbKs.Size = new System.Drawing.Size(394, 30);
            this.sbKs.TabIndex = 7;
            this.sbKs.Value = 100;
            this.sbKs.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbKs_Scroll);
            // 
            // lblKs
            // 
            this.lblKs.AutoSize = true;
            this.lblKs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKs.Location = new System.Drawing.Point(3, 75);
            this.lblKs.Name = "lblKs";
            this.lblKs.Size = new System.Drawing.Size(388, 15);
            this.lblKs.TabIndex = 5;
            this.lblKs.Text = "Ks value";
            // 
            // lblKd
            // 
            this.lblKd.AutoSize = true;
            this.lblKd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKd.Location = new System.Drawing.Point(3, 15);
            this.lblKd.Name = "lblKd";
            this.lblKd.Size = new System.Drawing.Size(388, 15);
            this.lblKd.TabIndex = 4;
            this.lblKd.Text = "Kd value";
            // 
            // sbKd
            // 
            this.sbKd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbKd.Location = new System.Drawing.Point(0, 30);
            this.sbKd.Name = "sbKd";
            this.sbKd.Size = new System.Drawing.Size(394, 30);
            this.sbKd.TabIndex = 6;
            this.sbKd.Value = 100;
            this.sbKd.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.hScrollBar2, 0, 7);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hScrollBar2.Location = new System.Drawing.Point(0, 140);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(200, 20);
            this.hScrollBar2.TabIndex = 11;
            this.hScrollBar2.Value = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ks value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 888);
            this.Controls.Add(this.tlpMain);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tlpMain.ResumeLayout(false);
            this.flpMenu.ResumeLayout(false);
            this.flpMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.tlpSliders.ResumeLayout(false);
            this.tlpSliders.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnImport;
        private TableLayoutPanel tlpMain;
        private FlowLayoutPanel flpMenu;
        private Button btnAnimation;
        private PictureBox pbCanvas;
        private CheckBox cbMesh;
        private TableLayoutPanel tlpSliders;
        private Label lblKs;
        private Label lblKd;
        private HScrollBar sbKd;
        private HScrollBar sbKs;
        private Label lblLightX;
        private HScrollBar sbLightZ;
        private Label lblLightZ;
        private HScrollBar sbLightY;
        private Label lblLightY;
        private HScrollBar sbLightX;
        private TableLayoutPanel tableLayoutPanel1;
        private HScrollBar hScrollBar2;
        private Label label2;
        private HScrollBar sbm;
        private Label lblm;
        private HScrollBar sbLightB;
        private Label lblLightB;
        private HScrollBar sbLightG;
        private Label lblLightG;
        private HScrollBar sbLightR;
        private Label lblLightR;
    }

}