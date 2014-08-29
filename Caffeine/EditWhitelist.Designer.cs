
namespace Caffeine
{
    partial class EditWhitelist
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.runningList = new System.Windows.Forms.ListBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.whiteList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.removeBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.customProcessBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // runningList
            // 
            this.runningList.FormattingEnabled = true;
            this.runningList.Location = new System.Drawing.Point(12, 38);
            this.runningList.Name = "runningList";
            this.runningList.Size = new System.Drawing.Size(300, 329);
            this.runningList.TabIndex = 0;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(318, 38);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "--->";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.AddBtnClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Running Processes";
            // 
            // whiteList
            // 
            this.whiteList.FormattingEnabled = true;
            this.whiteList.Location = new System.Drawing.Point(399, 38);
            this.whiteList.Name = "whiteList";
            this.whiteList.Size = new System.Drawing.Size(300, 329);
            this.whiteList.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(399, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Whitelisted Processes";
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(318, 67);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeBtn.TabIndex = 5;
            this.removeBtn.Text = "<---";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.RemoveBtnClick);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(318, 341);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.OkBtnClick);
            // 
            // customProcessBtn
            // 
            this.customProcessBtn.Location = new System.Drawing.Point(318, 96);
            this.customProcessBtn.Name = "customProcessBtn";
            this.customProcessBtn.Size = new System.Drawing.Size(75, 23);
            this.customProcessBtn.TabIndex = 7;
            this.customProcessBtn.Text = "Custom";
            this.customProcessBtn.UseVisualStyleBackColor = true;
            this.customProcessBtn.Click += new System.EventHandler(this.CustomProcessBtnClick);
            // 
            // EditWhitelist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 376);
            this.Controls.Add(this.customProcessBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.whiteList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.runningList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Caffeine.Properties.Resources.FullCup;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditWhitelist";
            this.Text = "Edit Whitelist";
            this.Load += new System.EventHandler(this.EditWhitelistLoad);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Button customProcessBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox whiteList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.ListBox runningList;
    }
}
