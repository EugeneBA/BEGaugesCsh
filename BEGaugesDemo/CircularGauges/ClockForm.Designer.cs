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
            this.components = new System.ComponentModel.Container();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._clockControl = new BEGaugesDemo.CircularGauges.ClockControl();
            this.SuspendLayout();
            // 
            // _timer
            // 
            this._timer.Enabled = true;
            this._timer.Interval = 500;
            this._timer.Tick += new System.EventHandler(this._timer_Tick);
            // 
            // _clockControl
            // 
            this._clockControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._clockControl.Location = new System.Drawing.Point(0, 0);
            this._clockControl.Name = "_clockControl";
            this._clockControl.Padding = new System.Windows.Forms.Padding(20);
            this._clockControl.Size = new System.Drawing.Size(768, 562);
            this._clockControl.TabIndex = 0;
            // 
            // ClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 562);
            this.Controls.Add(this._clockControl);
            this.Name = "ClockForm";
            this.Text = "Simple Clock";
            this.ResumeLayout(false);

        }

        #endregion

        private ClockControl _clockControl;
        private System.Windows.Forms.Timer _timer;
    }
}