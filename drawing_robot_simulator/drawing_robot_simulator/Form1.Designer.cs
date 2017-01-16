namespace drawing_robot_simulator
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Sheet = new System.Windows.Forms.PictureBox();
            this.StartDrawingButton = new System.Windows.Forms.Button();
            this.lblDevArm1BaseAxis = new System.Windows.Forms.Label();
            this.lblDevArm1RayAxis = new System.Windows.Forms.Label();
            this.lblDevArm2BaseAxis = new System.Windows.Forms.Label();
            this.lblDevArm2RayAxis = new System.Windows.Forms.Label();
            this.DisplayBoxbotArm = new System.Windows.Forms.GroupBox();
            this.CheckBoxDevMod = new System.Windows.Forms.CheckBox();
            this.graphicalOverlay = new CodeProject.GraphicalOverlay(this.components);
            this.ThumbnailBox = new System.Windows.Forms.PictureBox();
            this.ImportImageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Sheet)).BeginInit();
            this.DisplayBoxbotArm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Sheet
            // 
            this.Sheet.BackColor = System.Drawing.Color.Transparent;
            this.Sheet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Sheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Sheet.Location = new System.Drawing.Point(12, 12);
            this.Sheet.Name = "Sheet";
            this.Sheet.Size = new System.Drawing.Size(891, 630);
            this.Sheet.TabIndex = 0;
            this.Sheet.TabStop = false;
            // 
            // StartDrawingButton
            // 
            this.StartDrawingButton.Location = new System.Drawing.Point(909, 168);
            this.StartDrawingButton.Name = "StartDrawingButton";
            this.StartDrawingButton.Size = new System.Drawing.Size(75, 23);
            this.StartDrawingButton.TabIndex = 9;
            this.StartDrawingButton.TabStop = false;
            this.StartDrawingButton.Text = "Draw";
            this.StartDrawingButton.UseVisualStyleBackColor = true;
            this.StartDrawingButton.Click += new System.EventHandler(this.StartDrawingButton_Click);
            // 
            // lblDevArm1BaseAxis
            // 
            this.lblDevArm1BaseAxis.AutoSize = true;
            this.lblDevArm1BaseAxis.Location = new System.Drawing.Point(18, 29);
            this.lblDevArm1BaseAxis.Name = "lblDevArm1BaseAxis";
            this.lblDevArm1BaseAxis.Size = new System.Drawing.Size(20, 13);
            this.lblDevArm1BaseAxis.TabIndex = 3;
            this.lblDevArm1BaseAxis.Text = "1A";
            // 
            // lblDevArm1RayAxis
            // 
            this.lblDevArm1RayAxis.AutoSize = true;
            this.lblDevArm1RayAxis.Location = new System.Drawing.Point(18, 51);
            this.lblDevArm1RayAxis.Name = "lblDevArm1RayAxis";
            this.lblDevArm1RayAxis.Size = new System.Drawing.Size(20, 13);
            this.lblDevArm1RayAxis.TabIndex = 4;
            this.lblDevArm1RayAxis.Text = "1B";
            // 
            // lblDevArm2BaseAxis
            // 
            this.lblDevArm2BaseAxis.AutoSize = true;
            this.lblDevArm2BaseAxis.Location = new System.Drawing.Point(18, 102);
            this.lblDevArm2BaseAxis.Name = "lblDevArm2BaseAxis";
            this.lblDevArm2BaseAxis.Size = new System.Drawing.Size(20, 13);
            this.lblDevArm2BaseAxis.TabIndex = 5;
            this.lblDevArm2BaseAxis.Text = "2A";
            // 
            // lblDevArm2RayAxis
            // 
            this.lblDevArm2RayAxis.AutoSize = true;
            this.lblDevArm2RayAxis.Location = new System.Drawing.Point(18, 124);
            this.lblDevArm2RayAxis.Name = "lblDevArm2RayAxis";
            this.lblDevArm2RayAxis.Size = new System.Drawing.Size(20, 13);
            this.lblDevArm2RayAxis.TabIndex = 6;
            this.lblDevArm2RayAxis.Text = "2B";
            // 
            // DisplayBoxbotArm
            // 
            this.DisplayBoxbotArm.Controls.Add(this.lblDevArm1BaseAxis);
            this.DisplayBoxbotArm.Controls.Add(this.lblDevArm2RayAxis);
            this.DisplayBoxbotArm.Controls.Add(this.lblDevArm1RayAxis);
            this.DisplayBoxbotArm.Controls.Add(this.lblDevArm2BaseAxis);
            this.DisplayBoxbotArm.Location = new System.Drawing.Point(909, 12);
            this.DisplayBoxbotArm.Name = "DisplayBoxbotArm";
            this.DisplayBoxbotArm.Size = new System.Drawing.Size(308, 150);
            this.DisplayBoxbotArm.TabIndex = 10;
            this.DisplayBoxbotArm.TabStop = false;
            this.DisplayBoxbotArm.Text = "Bot arms";
            // 
            // CheckBoxDevMod
            // 
            this.CheckBoxDevMod.AutoSize = true;
            this.CheckBoxDevMod.Location = new System.Drawing.Point(1147, 174);
            this.CheckBoxDevMod.Name = "CheckBoxDevMod";
            this.CheckBoxDevMod.Size = new System.Drawing.Size(70, 17);
            this.CheckBoxDevMod.TabIndex = 7;
            this.CheckBoxDevMod.Text = "Dev Mod";
            this.CheckBoxDevMod.UseVisualStyleBackColor = true;
            // 
            // graphicalOverlay
            // 
            this.graphicalOverlay.Paint += new System.EventHandler<System.Windows.Forms.PaintEventArgs>(this.graphicalOverlay_Paint);
            // 
            // ThumbnailBox
            // 
            this.ThumbnailBox.BackColor = System.Drawing.Color.Transparent;
            this.ThumbnailBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ThumbnailBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThumbnailBox.Location = new System.Drawing.Point(909, 226);
            this.ThumbnailBox.Name = "ThumbnailBox";
            this.ThumbnailBox.Size = new System.Drawing.Size(297, 210);
            this.ThumbnailBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ThumbnailBox.TabIndex = 11;
            this.ThumbnailBox.TabStop = false;
            // 
            // ImportImageButton
            // 
            this.ImportImageButton.Location = new System.Drawing.Point(910, 198);
            this.ImportImageButton.Name = "ImportImageButton";
            this.ImportImageButton.Size = new System.Drawing.Size(75, 23);
            this.ImportImageButton.TabIndex = 12;
            this.ImportImageButton.Text = "Import";
            this.ImportImageButton.UseVisualStyleBackColor = true;
            this.ImportImageButton.Click += new System.EventHandler(this.ImportImageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 741);
            this.Controls.Add(this.ImportImageButton);
            this.Controls.Add(this.ThumbnailBox);
            this.Controls.Add(this.CheckBoxDevMod);
            this.Controls.Add(this.DisplayBoxbotArm);
            this.Controls.Add(this.StartDrawingButton);
            this.Controls.Add(this.Sheet);
            this.Name = "Form1";
            this.Text = "Drawing Robot Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Sheet)).EndInit();
            this.DisplayBoxbotArm.ResumeLayout(false);
            this.DisplayBoxbotArm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Sheet;
        private System.Windows.Forms.Button StartDrawingButton;
        private System.Windows.Forms.Label lblDevArm1BaseAxis;
        private System.Windows.Forms.Label lblDevArm1RayAxis;
        private System.Windows.Forms.Label lblDevArm2BaseAxis;
        private System.Windows.Forms.Label lblDevArm2RayAxis;
        private CodeProject.GraphicalOverlay graphicalOverlay;
        private System.Windows.Forms.GroupBox DisplayBoxbotArm;
        private System.Windows.Forms.CheckBox CheckBoxDevMod;
        private System.Windows.Forms.PictureBox ThumbnailBox;
        private System.Windows.Forms.Button ImportImageButton;
    }
}

