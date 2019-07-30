namespace Final_Project
{
    partial class Form1
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
            this.InputPicture = new System.Windows.Forms.PictureBox();
            this.OutputPicture = new System.Windows.Forms.PictureBox();
            this.SelectBT = new System.Windows.Forms.Button();
            this.RotateBT = new System.Windows.Forms.Button();
            this.SobelBT = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            ((System.ComponentModel.ISupportInitialize)(this.InputPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // InputPicture
            // 
            this.InputPicture.Location = new System.Drawing.Point(12, 12);
            this.InputPicture.Name = "InputPicture";
            this.InputPicture.Size = new System.Drawing.Size(441, 401);
            this.InputPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.InputPicture.TabIndex = 9;
            this.InputPicture.TabStop = false;
            this.InputPicture.Click += new System.EventHandler(this.InputPicture_Click);
            // 
            // OutputPicture
            // 
            this.OutputPicture.Location = new System.Drawing.Point(482, 12);
            this.OutputPicture.Name = "OutputPicture";
            this.OutputPicture.Size = new System.Drawing.Size(441, 401);
            this.OutputPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OutputPicture.TabIndex = 10;
            this.OutputPicture.TabStop = false;
            // 
            // SelectBT
            // 
            this.SelectBT.Location = new System.Drawing.Point(976, 53);
            this.SelectBT.Name = "SelectBT";
            this.SelectBT.Size = new System.Drawing.Size(169, 23);
            this.SelectBT.TabIndex = 12;
            this.SelectBT.Text = "Select image";
            this.SelectBT.UseVisualStyleBackColor = true;
            this.SelectBT.Click += new System.EventHandler(this.SelectBT_Click);
            // 
            // RotateBT
            // 
            this.RotateBT.Location = new System.Drawing.Point(1208, 53);
            this.RotateBT.Name = "RotateBT";
            this.RotateBT.Size = new System.Drawing.Size(129, 23);
            this.RotateBT.TabIndex = 13;
            this.RotateBT.Text = "Rotate Image";
            this.RotateBT.UseVisualStyleBackColor = true;
            this.RotateBT.Click += new System.EventHandler(this.RotateBT_Click);
            // 
            // SobelBT
            // 
            this.SobelBT.Location = new System.Drawing.Point(1081, 91);
            this.SobelBT.Name = "SobelBT";
            this.SobelBT.Size = new System.Drawing.Size(194, 56);
            this.SobelBT.TabIndex = 15;
            this.SobelBT.Text = "Identification";
            this.SobelBT.UseVisualStyleBackColor = true;
            this.SobelBT.Click += new System.EventHandler(this.SobelBT_Click);
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Location = new System.Drawing.Point(1078, 170);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(48, 17);
            this.Result.TabIndex = 16;
            this.Result.Text = "Result";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(1081, 204);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(155, 22);
            this.txtResult.TabIndex = 25;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 420);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(448, 422);
            this.zedGraphControl1.TabIndex = 33;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Location = new System.Drawing.Point(482, 420);
            this.zedGraphControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(448, 422);
            this.zedGraphControl2.TabIndex = 34;
            this.zedGraphControl2.UseExtendedPrintDialog = true;
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.Location = new System.Drawing.Point(951, 420);
            this.zedGraphControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollGrace = 0D;
            this.zedGraphControl3.ScrollMaxX = 0D;
            this.zedGraphControl3.ScrollMaxY = 0D;
            this.zedGraphControl3.ScrollMaxY2 = 0D;
            this.zedGraphControl3.ScrollMinX = 0D;
            this.zedGraphControl3.ScrollMinY = 0D;
            this.zedGraphControl3.ScrollMinY2 = 0D;
            this.zedGraphControl3.Size = new System.Drawing.Size(448, 422);
            this.zedGraphControl3.TabIndex = 35;
            this.zedGraphControl3.UseExtendedPrintDialog = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 883);
            this.Controls.Add(this.zedGraphControl3);
            this.Controls.Add(this.zedGraphControl2);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.SobelBT);
            this.Controls.Add(this.RotateBT);
            this.Controls.Add(this.SelectBT);
            this.Controls.Add(this.OutputPicture);
            this.Controls.Add(this.InputPicture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.InputPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox InputPicture;
        private System.Windows.Forms.PictureBox OutputPicture;
        private System.Windows.Forms.Button SelectBT;
        private System.Windows.Forms.Button RotateBT;
        private System.Windows.Forms.Button SobelBT;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.TextBox txtResult;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private ZedGraph.ZedGraphControl zedGraphControl3;
    }
}

