namespace BEGaugesDemo.CircularGauges
{
    partial class ClockForm
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
            this._clockControl = new BEGaugesDemo.CircularGauges.ClockControl();
            this.SuspendLayout();
            // 
            // _clockControl
            // 
            this._clockControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._clockControl.Location = new System.Drawing.Point(0, 0);
            this._clockControl.Name = "_clockControl";
            this._clockControl.Padding = new System.Windows.Forms.Padding(5);
            this._clockControl.Size = new System.Drawing.Size(547, 449);
            this._clockControl.TabIndex = 0;
            // 
            // ClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 449);
            this.Controls.Add(this._clockControl);
            this.Name = "ClockForm";
            this.Text = "Simple Clock";
            this.ResumeLayout(false);

        }

        #endregion

        private ClockControl _clockControl;
    }
}