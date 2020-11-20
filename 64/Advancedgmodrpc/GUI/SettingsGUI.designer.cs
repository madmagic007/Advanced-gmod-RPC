namespace Advancedgmodrpc {

    partial class SettingsGUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsGUI));
            this.lblDelay = new System.Windows.Forms.Label();
            this.numericDelay = new System.Windows.Forms.NumericUpDown();
            this.checkTime = new System.Windows.Forms.CheckBox();
            this.checkResetTime = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.checkBoot = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(10, 10);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(181, 13);
            this.lblDelay.TabIndex = 0;
            this.lblDelay.Text = "Update delay (seconds, default = 10)";
            // 
            // numericDelay
            // 
            this.numericDelay.Location = new System.Drawing.Point(231, 8);
            this.numericDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDelay.Name = "numericDelay";
            this.numericDelay.Size = new System.Drawing.Size(70, 20);
            this.numericDelay.TabIndex = 1;
            // 
            // checkTime
            // 
            this.checkTime.AutoSize = true;
            this.checkTime.Location = new System.Drawing.Point(13, 34);
            this.checkTime.Name = "checkTime";
            this.checkTime.Size = new System.Drawing.Size(140, 17);
            this.checkTime.TabIndex = 2;
            this.checkTime.Text = "Display time in presence";
            this.checkTime.UseVisualStyleBackColor = true;
            // 
            // checkResetTime
            // 
            this.checkResetTime.AutoSize = true;
            this.checkResetTime.Location = new System.Drawing.Point(13, 57);
            this.checkResetTime.Name = "checkResetTime";
            this.checkResetTime.Size = new System.Drawing.Size(288, 17);
            this.checkResetTime.TabIndex = 3;
            this.checkResetTime.Text = "Reset time when joining a new server or when in menus";
            this.checkResetTime.UseVisualStyleBackColor = true;
            // 
            // checkBoot
            // 
            this.checkBoot.AutoSize = true;
            this.checkBoot.Location = new System.Drawing.Point(13, 80);
            this.checkBoot.Name = "checkBoot";
            this.checkBoot.Size = new System.Drawing.Size(120, 17);
            this.checkBoot.TabIndex = 5;
            this.checkBoot.Text = "Start with pc startup";
            this.checkBoot.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(226, 86);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // SettingsGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 121);
            this.Controls.Add(this.checkBoot);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.checkResetTime);
            this.Controls.Add(this.checkTime);
            this.Controls.Add(this.numericDelay);
            this.Controls.Add(this.lblDelay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsGUI";
            this.Text = "Gmod RPC Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.NumericUpDown numericDelay;
        private System.Windows.Forms.CheckBox checkTime;
        private System.Windows.Forms.CheckBox checkResetTime;
        private System.Windows.Forms.CheckBox checkBoot;
        private System.Windows.Forms.Button btnSave;
    }
}