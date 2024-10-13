namespace DebraEventManagementDesktop
{
    partial class createevent
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelEventName = new System.Windows.Forms.Label();
            this.textBoxEventName = new System.Windows.Forms.TextBox();
            this.labelEventDescription = new System.Windows.Forms.Label();
            this.textBoxEventDescription = new System.Windows.Forms.TextBox();
            this.labelEventDate = new System.Windows.Forms.Label();
            this.textBoxEventDate = new System.Windows.Forms.TextBox();
            this.labelEventTime = new System.Windows.Forms.Label();
            this.textBoxEventTime = new System.Windows.Forms.TextBox();
            this.labelLocation = new System.Windows.Forms.Label();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.labelLink = new System.Windows.Forms.Label();
            this.textBoxLink = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelEventName
            // 
            this.labelEventName.AutoSize = true;
            this.labelEventName.Location = new System.Drawing.Point(13, 13);
            this.labelEventName.Name = "labelEventName";
            this.labelEventName.Size = new System.Drawing.Size(67, 13);
            this.labelEventName.TabIndex = 0;
            this.labelEventName.Text = "Event Name";
            // 
            // textBoxEventName
            // 
            this.textBoxEventName.Location = new System.Drawing.Point(120, 10);
            this.textBoxEventName.Name = "textBoxEventName";
            this.textBoxEventName.Size = new System.Drawing.Size(200, 20);
            this.textBoxEventName.TabIndex = 1;
            // 
            // labelEventDescription
            // 
            this.labelEventDescription.AutoSize = true;
            this.labelEventDescription.Location = new System.Drawing.Point(13, 39);
            this.labelEventDescription.Name = "labelEventDescription";
            this.labelEventDescription.Size = new System.Drawing.Size(89, 13);
            this.labelEventDescription.TabIndex = 2;
            this.labelEventDescription.Text = "Event Description";
            // 
            // textBoxEventDescription
            // 
            this.textBoxEventDescription.Location = new System.Drawing.Point(120, 36);
            this.textBoxEventDescription.Multiline = true;
            this.textBoxEventDescription.Name = "textBoxEventDescription";
            this.textBoxEventDescription.Size = new System.Drawing.Size(200, 60);
            this.textBoxEventDescription.TabIndex = 3;
            // 
            // labelEventDate
            // 
            this.labelEventDate.AutoSize = true;
            this.labelEventDate.Location = new System.Drawing.Point(13, 105);
            this.labelEventDate.Name = "labelEventDate";
            this.labelEventDate.Size = new System.Drawing.Size(61, 13);
            this.labelEventDate.TabIndex = 4;
            this.labelEventDate.Text = "Event Date";
            // 
            // textBoxEventDate
            // 
            this.textBoxEventDate.Location = new System.Drawing.Point(120, 102);
            this.textBoxEventDate.Name = "textBoxEventDate";
            this.textBoxEventDate.Size = new System.Drawing.Size(200, 20);
            this.textBoxEventDate.TabIndex = 5;
            // 
            // labelEventTime
            // 
            this.labelEventTime.AutoSize = true;
            this.labelEventTime.Location = new System.Drawing.Point(13, 131);
            this.labelEventTime.Name = "labelEventTime";
            this.labelEventTime.Size = new System.Drawing.Size(61, 13);
            this.labelEventTime.TabIndex = 6;
            this.labelEventTime.Text = "Event Time";
            // 
            // textBoxEventTime
            // 
            this.textBoxEventTime.Location = new System.Drawing.Point(120, 128);
            this.textBoxEventTime.Name = "textBoxEventTime";
            this.textBoxEventTime.Size = new System.Drawing.Size(200, 20);
            this.textBoxEventTime.TabIndex = 7;
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(13, 157);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(48, 13);
            this.labelLocation.TabIndex = 8;
            this.labelLocation.Text = "Location";
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(120, 154);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(200, 20);
            this.textBoxLocation.TabIndex = 9;
            // 
            // labelLink
            // 
            this.labelLink.AutoSize = true;
            this.labelLink.Location = new System.Drawing.Point(13, 183);
            this.labelLink.Name = "labelLink";
            this.labelLink.Size = new System.Drawing.Size(27, 13);
            this.labelLink.TabIndex = 10;
            this.labelLink.Text = "Link";
            // 
            // textBoxLink
            // 
            this.textBoxLink.Location = new System.Drawing.Point(120, 180);
            this.textBoxLink.Name = "textBoxLink";
            this.textBoxLink.Size = new System.Drawing.Size(200, 20);
            this.textBoxLink.TabIndex = 11;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(245, 206);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 12;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // createevent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 241);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxLink);
            this.Controls.Add(this.labelLink);
            this.Controls.Add(this.textBoxLocation);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.textBoxEventTime);
            this.Controls.Add(this.labelEventTime);
            this.Controls.Add(this.textBoxEventDate);
            this.Controls.Add(this.labelEventDate);
            this.Controls.Add(this.textBoxEventDescription);
            this.Controls.Add(this.labelEventDescription);
            this.Controls.Add(this.textBoxEventName);
            this.Controls.Add(this.labelEventName);
            this.Name = "createevent";
            this.Text = "Create Event";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelEventName;
        private System.Windows.Forms.TextBox textBoxEventName;
        private System.Windows.Forms.Label labelEventDescription;
        private System.Windows.Forms.TextBox textBoxEventDescription;
        private System.Windows.Forms.Label labelEventDate;
        private System.Windows.Forms.TextBox textBoxEventDate;
        private System.Windows.Forms.Label labelEventTime;
        private System.Windows.Forms.TextBox textBoxEventTime;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Label labelLink;
        private System.Windows.Forms.TextBox textBoxLink;
        private System.Windows.Forms.Button buttonSubmit;
    }
}
