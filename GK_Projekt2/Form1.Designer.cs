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
            this.btnLoadTexture = new System.Windows.Forms.Button();
            this.btnLoadNormalMap = new System.Windows.Forms.Button();
            this.btnAnimation = new System.Windows.Forms.Button();
            this.btnStopAnimation = new System.Windows.Forms.Button();
            this.flpCheckboxes = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCheckboxes = new System.Windows.Forms.Label();
            this.cbMesh = new System.Windows.Forms.CheckBox();
            this.cbModifiedNormalVector = new System.Windows.Forms.CheckBox();
            this.flpRadioButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.lblObjectColorControl = new System.Windows.Forms.Label();
            this.rbFixedObjectColor = new System.Windows.Forms.RadioButton();
            this.rbTextureObjectColor = new System.Windows.Forms.RadioButton();
            this.flpInterpolationMethod = new System.Windows.Forms.FlowLayoutPanel();
            this.lblInterpolation = new System.Windows.Forms.Label();
            this.rbVectors = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.tlpSliders = new System.Windows.Forms.TableLayoutPanel();
            this.sbObjectB = new System.Windows.Forms.HScrollBar();
            this.lblObjectB = new System.Windows.Forms.Label();
            this.sbObjectG = new System.Windows.Forms.HScrollBar();
            this.lblObjectG = new System.Windows.Forms.Label();
            this.sbObjectR = new System.Windows.Forms.HScrollBar();
            this.lblObjectR = new System.Windows.Forms.Label();
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
            this.pPictureBoxPanel = new System.Windows.Forms.Panel();
            this.tpbCanvas = new System.Windows.Forms.TableLayoutPanel();
            this.pbCanvas4 = new System.Windows.Forms.PictureBox();
            this.pbCanvas3 = new System.Windows.Forms.PictureBox();
            this.pbCanvas2 = new System.Windows.Forms.PictureBox();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.rbHeightMapTrue = new System.Windows.Forms.RadioButton();
            this.rbrbHeightMapFalse = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.flpMenu.SuspendLayout();
            this.flpCheckboxes.SuspendLayout();
            this.flpRadioButtons.SuspendLayout();
            this.flpInterpolationMethod.SuspendLayout();
            this.tlpSliders.SuspendLayout();
            this.pPictureBoxPanel.SuspendLayout();
            this.tpbCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(5, 5);
            this.btnImport.Margin = new System.Windows.Forms.Padding(5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(53, 77);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.Controls.Add(this.flpMenu, 0, 0);
            this.tlpMain.Controls.Add(this.tlpSliders, 1, 1);
            this.tlpMain.Controls.Add(this.pPictureBoxPanel, 0, 1);
            this.tlpMain.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(847, 935);
            this.tlpMain.TabIndex = 1;
            this.tlpMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tlpMain_MouseUp);
            // 
            // flpMenu
            // 
            this.flpMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flpMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpMain.SetColumnSpan(this.flpMenu, 2);
            this.flpMenu.Controls.Add(this.btnImport);
            this.flpMenu.Controls.Add(this.btnLoadTexture);
            this.flpMenu.Controls.Add(this.btnLoadNormalMap);
            this.flpMenu.Controls.Add(this.btnAnimation);
            this.flpMenu.Controls.Add(this.btnStopAnimation);
            this.flpMenu.Controls.Add(this.flpCheckboxes);
            this.flpMenu.Controls.Add(this.flpRadioButtons);
            this.flpMenu.Controls.Add(this.flpInterpolationMethod);
            this.flpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenu.Location = new System.Drawing.Point(0, 0);
            this.flpMenu.Margin = new System.Windows.Forms.Padding(0);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(847, 88);
            this.flpMenu.TabIndex = 3;
            // 
            // btnLoadTexture
            // 
            this.btnLoadTexture.Location = new System.Drawing.Point(68, 5);
            this.btnLoadTexture.Margin = new System.Windows.Forms.Padding(5);
            this.btnLoadTexture.Name = "btnLoadTexture";
            this.btnLoadTexture.Size = new System.Drawing.Size(54, 77);
            this.btnLoadTexture.TabIndex = 5;
            this.btnLoadTexture.Text = "Load Texture";
            this.btnLoadTexture.UseVisualStyleBackColor = true;
            this.btnLoadTexture.Click += new System.EventHandler(this.btnLoadTexture_Click);
            // 
            // btnLoadNormalMap
            // 
            this.btnLoadNormalMap.Location = new System.Drawing.Point(132, 5);
            this.btnLoadNormalMap.Margin = new System.Windows.Forms.Padding(5);
            this.btnLoadNormalMap.Name = "btnLoadNormalMap";
            this.btnLoadNormalMap.Size = new System.Drawing.Size(63, 77);
            this.btnLoadNormalMap.TabIndex = 9;
            this.btnLoadNormalMap.Text = "Load Normal Map";
            this.btnLoadNormalMap.UseVisualStyleBackColor = true;
            this.btnLoadNormalMap.Click += new System.EventHandler(this.btnLoadNormalMap_Click);
            // 
            // btnAnimation
            // 
            this.btnAnimation.Location = new System.Drawing.Point(205, 5);
            this.btnAnimation.Margin = new System.Windows.Forms.Padding(5);
            this.btnAnimation.Name = "btnAnimation";
            this.btnAnimation.Size = new System.Drawing.Size(71, 77);
            this.btnAnimation.TabIndex = 1;
            this.btnAnimation.Text = "Start Animation";
            this.btnAnimation.UseVisualStyleBackColor = true;
            this.btnAnimation.Click += new System.EventHandler(this.btnAnimation_Click);
            // 
            // btnStopAnimation
            // 
            this.btnStopAnimation.Location = new System.Drawing.Point(286, 5);
            this.btnStopAnimation.Margin = new System.Windows.Forms.Padding(5);
            this.btnStopAnimation.Name = "btnStopAnimation";
            this.btnStopAnimation.Size = new System.Drawing.Size(71, 77);
            this.btnStopAnimation.TabIndex = 3;
            this.btnStopAnimation.Text = "Stop Animation";
            this.btnStopAnimation.UseVisualStyleBackColor = true;
            this.btnStopAnimation.Click += new System.EventHandler(this.btnStopAnimation_Click);
            // 
            // flpCheckboxes
            // 
            this.flpCheckboxes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flpCheckboxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpCheckboxes.Controls.Add(this.lblCheckboxes);
            this.flpCheckboxes.Controls.Add(this.cbMesh);
            this.flpCheckboxes.Controls.Add(this.cbModifiedNormalVector);
            this.flpCheckboxes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCheckboxes.Location = new System.Drawing.Point(365, 7);
            this.flpCheckboxes.Name = "flpCheckboxes";
            this.flpCheckboxes.Size = new System.Drawing.Size(162, 73);
            this.flpCheckboxes.TabIndex = 7;
            // 
            // lblCheckboxes
            // 
            this.lblCheckboxes.AutoSize = true;
            this.lblCheckboxes.Location = new System.Drawing.Point(3, 0);
            this.lblCheckboxes.Name = "lblCheckboxes";
            this.lblCheckboxes.Size = new System.Drawing.Size(49, 15);
            this.lblCheckboxes.TabIndex = 7;
            this.lblCheckboxes.Text = "Options";
            // 
            // cbMesh
            // 
            this.cbMesh.AutoSize = true;
            this.cbMesh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMesh.Location = new System.Drawing.Point(3, 18);
            this.cbMesh.Name = "cbMesh";
            this.cbMesh.Size = new System.Drawing.Size(158, 19);
            this.cbMesh.TabIndex = 2;
            this.cbMesh.Text = "Mesh";
            this.cbMesh.UseVisualStyleBackColor = true;
            this.cbMesh.CheckedChanged += new System.EventHandler(this.cbMesh_CheckedChanged);
            // 
            // cbModifiedNormalVector
            // 
            this.cbModifiedNormalVector.AutoSize = true;
            this.cbModifiedNormalVector.Checked = true;
            this.cbModifiedNormalVector.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbModifiedNormalVector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbModifiedNormalVector.Location = new System.Drawing.Point(3, 43);
            this.cbModifiedNormalVector.Name = "cbModifiedNormalVector";
            this.cbModifiedNormalVector.Size = new System.Drawing.Size(158, 19);
            this.cbModifiedNormalVector.TabIndex = 6;
            this.cbModifiedNormalVector.Text = "Normal Vectors Modified";
            this.cbModifiedNormalVector.UseVisualStyleBackColor = true;
            this.cbModifiedNormalVector.CheckedChanged += new System.EventHandler(this.cbModifiedNormalVector_CheckedChanged);
            // 
            // flpRadioButtons
            // 
            this.flpRadioButtons.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flpRadioButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpRadioButtons.Controls.Add(this.lblObjectColorControl);
            this.flpRadioButtons.Controls.Add(this.rbFixedObjectColor);
            this.flpRadioButtons.Controls.Add(this.rbTextureObjectColor);
            this.flpRadioButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpRadioButtons.Location = new System.Drawing.Point(533, 7);
            this.flpRadioButtons.Name = "flpRadioButtons";
            this.flpRadioButtons.Size = new System.Drawing.Size(168, 73);
            this.flpRadioButtons.TabIndex = 4;
            // 
            // lblObjectColorControl
            // 
            this.lblObjectColorControl.AutoSize = true;
            this.lblObjectColorControl.Location = new System.Drawing.Point(3, 0);
            this.lblObjectColorControl.Name = "lblObjectColorControl";
            this.lblObjectColorControl.Size = new System.Drawing.Size(117, 15);
            this.lblObjectColorControl.TabIndex = 4;
            this.lblObjectColorControl.Text = "Object Color Control";
            // 
            // rbFixedObjectColor
            // 
            this.rbFixedObjectColor.AutoSize = true;
            this.rbFixedObjectColor.Location = new System.Drawing.Point(3, 18);
            this.rbFixedObjectColor.Name = "rbFixedObjectColor";
            this.rbFixedObjectColor.Size = new System.Drawing.Size(123, 19);
            this.rbFixedObjectColor.TabIndex = 2;
            this.rbFixedObjectColor.Text = "Fixed Object Color";
            this.rbFixedObjectColor.UseVisualStyleBackColor = true;
            this.rbFixedObjectColor.CheckedChanged += new System.EventHandler(this.rbFixedObjectColor_CheckedChanged);
            // 
            // rbTextureObjectColor
            // 
            this.rbTextureObjectColor.AutoSize = true;
            this.rbTextureObjectColor.Checked = true;
            this.rbTextureObjectColor.Location = new System.Drawing.Point(3, 43);
            this.rbTextureObjectColor.Name = "rbTextureObjectColor";
            this.rbTextureObjectColor.Size = new System.Drawing.Size(164, 19);
            this.rbTextureObjectColor.TabIndex = 3;
            this.rbTextureObjectColor.TabStop = true;
            this.rbTextureObjectColor.Text = "Object Color From Texture";
            this.rbTextureObjectColor.UseVisualStyleBackColor = true;
            // 
            // flpInterpolationMethod
            // 
            this.flpInterpolationMethod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flpInterpolationMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpInterpolationMethod.Controls.Add(this.lblInterpolation);
            this.flpInterpolationMethod.Controls.Add(this.rbVectors);
            this.flpInterpolationMethod.Controls.Add(this.radioButton2);
            this.flpInterpolationMethod.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpInterpolationMethod.Location = new System.Drawing.Point(707, 7);
            this.flpInterpolationMethod.Name = "flpInterpolationMethod";
            this.flpInterpolationMethod.Size = new System.Drawing.Size(129, 73);
            this.flpInterpolationMethod.TabIndex = 8;
            // 
            // lblInterpolation
            // 
            this.lblInterpolation.AutoSize = true;
            this.lblInterpolation.Location = new System.Drawing.Point(3, 0);
            this.lblInterpolation.Name = "lblInterpolation";
            this.lblInterpolation.Size = new System.Drawing.Size(120, 15);
            this.lblInterpolation.TabIndex = 4;
            this.lblInterpolation.Text = "Interpolation Method";
            // 
            // rbVectors
            // 
            this.rbVectors.AutoSize = true;
            this.rbVectors.Checked = true;
            this.rbVectors.Location = new System.Drawing.Point(3, 18);
            this.rbVectors.Name = "rbVectors";
            this.rbVectors.Size = new System.Drawing.Size(63, 19);
            this.rbVectors.TabIndex = 2;
            this.rbVectors.TabStop = true;
            this.rbVectors.Text = "Vectors";
            this.rbVectors.UseVisualStyleBackColor = true;
            this.rbVectors.CheckedChanged += new System.EventHandler(this.rbVectors_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(3, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 19);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.Text = "Colors";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // tlpSliders
            // 
            this.tlpSliders.ColumnCount = 1;
            this.tlpSliders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSliders.Controls.Add(this.sbObjectB, 0, 23);
            this.tlpSliders.Controls.Add(this.lblObjectB, 0, 22);
            this.tlpSliders.Controls.Add(this.sbObjectG, 0, 21);
            this.tlpSliders.Controls.Add(this.lblObjectG, 0, 20);
            this.tlpSliders.Controls.Add(this.sbObjectR, 0, 19);
            this.tlpSliders.Controls.Add(this.lblObjectR, 0, 18);
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
            this.tlpSliders.Location = new System.Drawing.Point(511, 91);
            this.tlpSliders.Name = "tlpSliders";
            this.tlpSliders.RowCount = 25;
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
            this.tlpSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSliders.Size = new System.Drawing.Size(333, 841);
            this.tlpSliders.TabIndex = 4;
            this.tlpSliders.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tlpMain_MouseUp);
            // 
            // sbObjectB
            // 
            this.sbObjectB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbObjectB.Location = new System.Drawing.Point(0, 690);
            this.sbObjectB.Name = "sbObjectB";
            this.sbObjectB.Size = new System.Drawing.Size(333, 30);
            this.sbObjectB.TabIndex = 27;
            this.sbObjectB.Value = 100;
            this.sbObjectB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbObjectB_Scroll);
            // 
            // lblObjectB
            // 
            this.lblObjectB.AutoSize = true;
            this.lblObjectB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblObjectB.Location = new System.Drawing.Point(3, 675);
            this.lblObjectB.Name = "lblObjectB";
            this.lblObjectB.Size = new System.Drawing.Size(327, 15);
            this.lblObjectB.TabIndex = 26;
            this.lblObjectB.Text = "Object B Value";
            // 
            // sbObjectG
            // 
            this.sbObjectG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbObjectG.Location = new System.Drawing.Point(0, 630);
            this.sbObjectG.Name = "sbObjectG";
            this.sbObjectG.Size = new System.Drawing.Size(333, 30);
            this.sbObjectG.TabIndex = 25;
            this.sbObjectG.Value = 100;
            this.sbObjectG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbObjectG_Scroll);
            // 
            // lblObjectG
            // 
            this.lblObjectG.AutoSize = true;
            this.lblObjectG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblObjectG.Location = new System.Drawing.Point(3, 615);
            this.lblObjectG.Name = "lblObjectG";
            this.lblObjectG.Size = new System.Drawing.Size(327, 15);
            this.lblObjectG.TabIndex = 24;
            this.lblObjectG.Text = "Object G Value";
            // 
            // sbObjectR
            // 
            this.sbObjectR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbObjectR.Location = new System.Drawing.Point(0, 570);
            this.sbObjectR.Name = "sbObjectR";
            this.sbObjectR.Size = new System.Drawing.Size(333, 30);
            this.sbObjectR.TabIndex = 23;
            this.sbObjectR.Value = 100;
            this.sbObjectR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbObjectR_Scroll);
            // 
            // lblObjectR
            // 
            this.lblObjectR.AutoSize = true;
            this.lblObjectR.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblObjectR.Location = new System.Drawing.Point(3, 555);
            this.lblObjectR.Name = "lblObjectR";
            this.lblObjectR.Size = new System.Drawing.Size(327, 15);
            this.lblObjectR.TabIndex = 22;
            this.lblObjectR.Text = "Object R Value";
            // 
            // sbLightB
            // 
            this.sbLightB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbLightB.Location = new System.Drawing.Point(0, 510);
            this.sbLightB.Name = "sbLightB";
            this.sbLightB.Size = new System.Drawing.Size(333, 30);
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
            this.lblLightB.Size = new System.Drawing.Size(327, 15);
            this.lblLightB.TabIndex = 20;
            this.lblLightB.Text = "Light B Value";
            // 
            // sbLightG
            // 
            this.sbLightG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbLightG.Location = new System.Drawing.Point(0, 450);
            this.sbLightG.Name = "sbLightG";
            this.sbLightG.Size = new System.Drawing.Size(333, 30);
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
            this.lblLightG.Size = new System.Drawing.Size(327, 15);
            this.lblLightG.TabIndex = 18;
            this.lblLightG.Text = "Light G Value";
            // 
            // sbLightR
            // 
            this.sbLightR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbLightR.Location = new System.Drawing.Point(0, 390);
            this.sbLightR.Name = "sbLightR";
            this.sbLightR.Size = new System.Drawing.Size(333, 30);
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
            this.lblLightR.Size = new System.Drawing.Size(327, 15);
            this.lblLightR.TabIndex = 16;
            this.lblLightR.Text = "Light R Value";
            // 
            // sbm
            // 
            this.sbm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbm.Location = new System.Drawing.Point(0, 150);
            this.sbm.Minimum = 1;
            this.sbm.Name = "sbm";
            this.sbm.Size = new System.Drawing.Size(333, 30);
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
            this.lblm.Size = new System.Drawing.Size(327, 15);
            this.lblm.TabIndex = 14;
            this.lblm.Text = "m Value";
            // 
            // sbLightZ
            // 
            this.sbLightZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbLightZ.Location = new System.Drawing.Point(0, 330);
            this.sbLightZ.Name = "sbLightZ";
            this.sbLightZ.Size = new System.Drawing.Size(333, 30);
            this.sbLightZ.TabIndex = 13;
            this.sbLightZ.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbLightZ_Scroll);
            // 
            // lblLightZ
            // 
            this.lblLightZ.AutoSize = true;
            this.lblLightZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLightZ.Location = new System.Drawing.Point(3, 315);
            this.lblLightZ.Name = "lblLightZ";
            this.lblLightZ.Size = new System.Drawing.Size(327, 15);
            this.lblLightZ.TabIndex = 12;
            this.lblLightZ.Text = "Light Z";
            // 
            // sbLightY
            // 
            this.sbLightY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbLightY.Location = new System.Drawing.Point(0, 270);
            this.sbLightY.Name = "sbLightY";
            this.sbLightY.Size = new System.Drawing.Size(333, 30);
            this.sbLightY.TabIndex = 11;
            this.sbLightY.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbLightY_Scroll);
            // 
            // lblLightY
            // 
            this.lblLightY.AutoSize = true;
            this.lblLightY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLightY.Location = new System.Drawing.Point(3, 255);
            this.lblLightY.Name = "lblLightY";
            this.lblLightY.Size = new System.Drawing.Size(327, 15);
            this.lblLightY.TabIndex = 10;
            this.lblLightY.Text = "Light Y";
            // 
            // sbLightX
            // 
            this.sbLightX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbLightX.Location = new System.Drawing.Point(0, 210);
            this.sbLightX.Name = "sbLightX";
            this.sbLightX.Size = new System.Drawing.Size(333, 30);
            this.sbLightX.TabIndex = 9;
            this.sbLightX.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbLightX_Scroll);
            // 
            // lblLightX
            // 
            this.lblLightX.AutoSize = true;
            this.lblLightX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLightX.Location = new System.Drawing.Point(3, 195);
            this.lblLightX.Name = "lblLightX";
            this.lblLightX.Size = new System.Drawing.Size(327, 15);
            this.lblLightX.TabIndex = 8;
            this.lblLightX.Text = "Light X";
            // 
            // sbKs
            // 
            this.sbKs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbKs.Location = new System.Drawing.Point(0, 90);
            this.sbKs.Name = "sbKs";
            this.sbKs.Size = new System.Drawing.Size(333, 30);
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
            this.lblKs.Size = new System.Drawing.Size(327, 15);
            this.lblKs.TabIndex = 5;
            this.lblKs.Text = "Ks value";
            // 
            // lblKd
            // 
            this.lblKd.AutoSize = true;
            this.lblKd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKd.Location = new System.Drawing.Point(3, 15);
            this.lblKd.Name = "lblKd";
            this.lblKd.Size = new System.Drawing.Size(327, 15);
            this.lblKd.TabIndex = 4;
            this.lblKd.Text = "Kd value";
            // 
            // sbKd
            // 
            this.sbKd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbKd.Location = new System.Drawing.Point(0, 30);
            this.sbKd.Name = "sbKd";
            this.sbKd.Size = new System.Drawing.Size(333, 30);
            this.sbKd.TabIndex = 6;
            this.sbKd.Value = 100;
            this.sbKd.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // pPictureBoxPanel
            // 
            this.pPictureBoxPanel.Controls.Add(this.tpbCanvas);
            this.pPictureBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPictureBoxPanel.Location = new System.Drawing.Point(10, 98);
            this.pPictureBoxPanel.Margin = new System.Windows.Forms.Padding(10);
            this.pPictureBoxPanel.Name = "pPictureBoxPanel";
            this.pPictureBoxPanel.Size = new System.Drawing.Size(488, 488);
            this.pPictureBoxPanel.TabIndex = 5;
            // 
            // tpbCanvas
            // 
            this.tpbCanvas.ColumnCount = 2;
            this.tpbCanvas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpbCanvas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpbCanvas.Controls.Add(this.pbCanvas4, 1, 1);
            this.tpbCanvas.Controls.Add(this.pbCanvas3, 0, 1);
            this.tpbCanvas.Controls.Add(this.pbCanvas2, 1, 0);
            this.tpbCanvas.Controls.Add(this.pbCanvas, 0, 0);
            this.tpbCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpbCanvas.Location = new System.Drawing.Point(0, 0);
            this.tpbCanvas.Margin = new System.Windows.Forms.Padding(0);
            this.tpbCanvas.Name = "tpbCanvas";
            this.tpbCanvas.RowCount = 2;
            this.tpbCanvas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpbCanvas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpbCanvas.Size = new System.Drawing.Size(488, 488);
            this.tpbCanvas.TabIndex = 3;
            // 
            // pbCanvas4
            // 
            this.pbCanvas4.Location = new System.Drawing.Point(247, 247);
            this.pbCanvas4.Name = "pbCanvas4";
            this.pbCanvas4.Size = new System.Drawing.Size(237, 237);
            this.pbCanvas4.TabIndex = 5;
            this.pbCanvas4.TabStop = false;
            // 
            // pbCanvas3
            // 
            this.pbCanvas3.Location = new System.Drawing.Point(3, 247);
            this.pbCanvas3.Name = "pbCanvas3";
            this.pbCanvas3.Size = new System.Drawing.Size(237, 237);
            this.pbCanvas3.TabIndex = 4;
            this.pbCanvas3.TabStop = false;
            // 
            // pbCanvas2
            // 
            this.pbCanvas2.Location = new System.Drawing.Point(247, 3);
            this.pbCanvas2.Name = "pbCanvas2";
            this.pbCanvas2.Size = new System.Drawing.Size(237, 237);
            this.pbCanvas2.TabIndex = 3;
            this.pbCanvas2.TabStop = false;
            // 
            // pbCanvas
            // 
            this.pbCanvas.Location = new System.Drawing.Point(3, 3);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(237, 237);
            this.pbCanvas.TabIndex = 2;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tlpMain_MouseUp);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.rbHeightMapTrue);
            this.flowLayoutPanel1.Controls.Add(this.rbrbHeightMapFalse);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 599);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(502, 73);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Height Map Instead of Normal Map";
            // 
            // rbHeightMapTrue
            // 
            this.rbHeightMapTrue.AutoSize = true;
            this.rbHeightMapTrue.Location = new System.Drawing.Point(3, 18);
            this.rbHeightMapTrue.Name = "rbHeightMapTrue";
            this.rbHeightMapTrue.Size = new System.Drawing.Size(67, 19);
            this.rbHeightMapTrue.TabIndex = 2;
            this.rbHeightMapTrue.Text = "Enabled";
            this.rbHeightMapTrue.UseVisualStyleBackColor = true;
            this.rbHeightMapTrue.CheckedChanged += new System.EventHandler(this.rbHeightMapTrue_CheckedChanged);
            // 
            // rbrbHeightMapFalse
            // 
            this.rbrbHeightMapFalse.AutoSize = true;
            this.rbrbHeightMapFalse.Checked = true;
            this.rbrbHeightMapFalse.Location = new System.Drawing.Point(3, 43);
            this.rbrbHeightMapFalse.Name = "rbrbHeightMapFalse";
            this.rbrbHeightMapFalse.Size = new System.Drawing.Size(70, 19);
            this.rbrbHeightMapFalse.TabIndex = 3;
            this.rbrbHeightMapFalse.TabStop = true;
            this.rbrbHeightMapFalse.Text = "Disabled";
            this.rbrbHeightMapFalse.UseVisualStyleBackColor = true;
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
            this.ClientSize = new System.Drawing.Size(847, 935);
            this.Controls.Add(this.tlpMain);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tlpMain.ResumeLayout(false);
            this.flpMenu.ResumeLayout(false);
            this.flpCheckboxes.ResumeLayout(false);
            this.flpCheckboxes.PerformLayout();
            this.flpRadioButtons.ResumeLayout(false);
            this.flpRadioButtons.PerformLayout();
            this.flpInterpolationMethod.ResumeLayout(false);
            this.flpInterpolationMethod.PerformLayout();
            this.tlpSliders.ResumeLayout(false);
            this.tlpSliders.PerformLayout();
            this.pPictureBoxPanel.ResumeLayout(false);
            this.tpbCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
        private Button btnStopAnimation;
        private Panel pPictureBoxPanel;
        private FlowLayoutPanel flpRadioButtons;
        private RadioButton rbFixedObjectColor;
        private RadioButton rbTextureObjectColor;
        private HScrollBar sbObjectB;
        private Label lblObjectB;
        private HScrollBar sbObjectG;
        private Label lblObjectG;
        private HScrollBar sbObjectR;
        private Label lblObjectR;
        private Button btnLoadTexture;
        private Label lblObjectColorControl;
        private CheckBox cbModifiedNormalVector;
        private FlowLayoutPanel flpCheckboxes;
        private Label lblCheckboxes;
        private FlowLayoutPanel flpInterpolationMethod;
        private Label lblInterpolation;
        private RadioButton rbVectors;
        private RadioButton radioButton2;
        private Button btnLoadNormalMap;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private RadioButton rbHeightMapTrue;
        private RadioButton rbrbHeightMapFalse;
        private TableLayoutPanel tpbCanvas;
        private PictureBox pbCanvas4;
        private PictureBox pbCanvas3;
        private PictureBox pbCanvas2;
    }

}