namespace BEGaugesDemo
{
    partial class FormMain
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
            this._groupCircularGauges = new System.Windows.Forms.GroupBox();
            this._btnClockControl = new System.Windows.Forms.Button();
            this._groupCircularGauges.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupCircularGauges
            // 
            this._groupCircularGauges.Controls.Add(this._btnClockControl);
            this._groupCircularGauges.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupCircularGauges.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._groupCircularGauges.Location = new System.Drawing.Point(0, 0);
            this._groupCircularGauges.Name = "_groupCircularGauges";
            this._groupCircularGauges.Size = new System.Drawing.Size(551, 542);
            this._groupCircularGauges.TabIndex = 0;
            this._groupCircularGauges.TabStop = false;
            this._groupCircularGauges.Text = "Circular Gauges";
            // 
            // _btnClockControl
            // 
            this._btnClockControl.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnClockControl.Location = new System.Drawing.Point(3, 25);
            this._btnClockControl.Name = "_btnClockControl";
            this._btnClockControl.Size = new System.Drawing.Size(545, 62);
            this._btnClockControl.TabIndex = 0;
            this._btnClockControl.Text = "Clock Control";
            this._btnClockControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnClockControl.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 542);
            this.Controls.Add(this._groupCircularGauges);
            this.Name = "FormMain";
            this.Text = "Demo";
            this._groupCircularGauges.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupCircularGauges;
        private System.Windows.Forms.Button _btnClockControl;
    }
}

