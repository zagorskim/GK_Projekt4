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
            this.btnFillMesh = new System.Windows.Forms.Button();
            this.cbMesh = new System.Windows.Forms.CheckBox();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.tlpMain.SuspendLayout();
            this.flpMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(5, 5);
            this.btnImport.Margin = new System.Windows.Forms.Padding(5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(66, 77);
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
            this.flpMenu.Controls.Add(this.btnFillMesh);
            this.flpMenu.Controls.Add(this.cbMesh);
            this.flpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenu.Location = new System.Drawing.Point(0, 0);
            this.flpMenu.Margin = new System.Windows.Forms.Padding(0);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(800, 88);
            this.flpMenu.TabIndex = 3;
            // 
            // btnFillMesh
            // 
            this.btnFillMesh.Location = new System.Drawing.Point(81, 5);
            this.btnFillMesh.Margin = new System.Windows.Forms.Padding(5);
            this.btnFillMesh.Name = "btnFillMesh";
            this.btnFillMesh.Size = new System.Drawing.Size(70, 77);
            this.btnFillMesh.TabIndex = 1;
            this.btnFillMesh.Text = "Fill Mesh";
            this.btnFillMesh.UseVisualStyleBackColor = true;
            this.btnFillMesh.Click += new System.EventHandler(this.btnFillMesh_Click);
            // 
            // cbMesh
            // 
            this.cbMesh.AutoSize = true;
            this.cbMesh.Checked = true;
            this.cbMesh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMesh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMesh.Location = new System.Drawing.Point(159, 3);
            this.cbMesh.Name = "cbMesh";
            this.cbMesh.Size = new System.Drawing.Size(55, 81);
            this.cbMesh.TabIndex = 2;
            this.cbMesh.Text = "Mesh";
            this.cbMesh.UseVisualStyleBackColor = true;
            // 
            // pbCanvas
            // 
            this.pbCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCanvas.Location = new System.Drawing.Point(10, 98);
            this.pbCanvas.Margin = new System.Windows.Forms.Padding(10);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(380, 380);
            this.pbCanvas.TabIndex = 2;
            this.pbCanvas.TabStop = false;
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
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnImport;
        private TableLayoutPanel tlpMain;
        private FlowLayoutPanel flpMenu;
        private Button btnFillMesh;
        private PictureBox pbCanvas;
        private CheckBox cbMesh;
    }

}