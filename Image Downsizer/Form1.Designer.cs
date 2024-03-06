namespace Image_Downsizer
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
            this.addImgB = new System.Windows.Forms.Button();
            this.imgSizeLabel = new System.Windows.Forms.Label();
            this.percentTB = new System.Windows.Forms.TrackBar();
            this.wantedSizeLabel = new System.Windows.Forms.Label();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.startResizingButton = new System.Windows.Forms.Button();
            this.imagePB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.percentTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePB)).BeginInit();
            this.SuspendLayout();
            // 
            // addImgB
            // 
            this.addImgB.Location = new System.Drawing.Point(24, 32);
            this.addImgB.Name = "addImgB";
            this.addImgB.Size = new System.Drawing.Size(228, 43);
            this.addImgB.TabIndex = 0;
            this.addImgB.Text = "Select Image";
            this.addImgB.UseVisualStyleBackColor = true;
            this.addImgB.Click += new System.EventHandler(this.addImgB_Click);
            // 
            // imgSizeLabel
            // 
            this.imgSizeLabel.AutoSize = true;
            this.imgSizeLabel.Location = new System.Drawing.Point(365, 46);
            this.imgSizeLabel.Name = "imgSizeLabel";
            this.imgSizeLabel.Size = new System.Drawing.Size(113, 15);
            this.imgSizeLabel.TabIndex = 1;
            this.imgSizeLabel.Text = "Original Image size: ";
            // 
            // percentTB
            // 
            this.percentTB.Location = new System.Drawing.Point(24, 118);
            this.percentTB.Name = "percentTB";
            this.percentTB.Size = new System.Drawing.Size(228, 45);
            this.percentTB.TabIndex = 2;
            this.percentTB.Scroll += new System.EventHandler(this.percentTB_Scroll);
            // 
            // wantedSizeLabel
            // 
            this.wantedSizeLabel.AutoSize = true;
            this.wantedSizeLabel.Location = new System.Drawing.Point(365, 118);
            this.wantedSizeLabel.Name = "wantedSizeLabel";
            this.wantedSizeLabel.Size = new System.Drawing.Size(77, 15);
            this.wantedSizeLabel.TabIndex = 3;
            this.wantedSizeLabel.Text = "Wanted Size: ";
            // 
            // percentageLabel
            // 
            this.percentageLabel.AutoSize = true;
            this.percentageLabel.Location = new System.Drawing.Point(120, 100);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(29, 15);
            this.percentageLabel.TabIndex = 4;
            this.percentageLabel.Text = "10%";
            // 
            // startResizingButton
            // 
            this.startResizingButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.startResizingButton.Location = new System.Drawing.Point(697, 401);
            this.startResizingButton.Name = "startResizingButton";
            this.startResizingButton.Size = new System.Drawing.Size(91, 37);
            this.startResizingButton.TabIndex = 5;
            this.startResizingButton.Text = "Resize";
            this.startResizingButton.UseVisualStyleBackColor = true;
            this.startResizingButton.Click += new System.EventHandler(this.startResizingButton_Click);
            // 
            // imagePB
            // 
            this.imagePB.Location = new System.Drawing.Point(24, 196);
            this.imagePB.Name = "imagePB";
            this.imagePB.Size = new System.Drawing.Size(332, 242);
            this.imagePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagePB.TabIndex = 6;
            this.imagePB.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.imagePB);
            this.Controls.Add(this.startResizingButton);
            this.Controls.Add(this.percentageLabel);
            this.Controls.Add(this.wantedSizeLabel);
            this.Controls.Add(this.percentTB);
            this.Controls.Add(this.imgSizeLabel);
            this.Controls.Add(this.addImgB);
            this.Name = "Form1";
            this.Text = "Image Downscaler";
            ((System.ComponentModel.ISupportInitialize)(this.percentTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button addImgB;
        private Label imgSizeLabel;
        private TrackBar percentTB;
        private Label wantedSizeLabel;
        private Label percentageLabel;
        private Button startResizingButton;
        private PictureBox imagePB;
    }
}