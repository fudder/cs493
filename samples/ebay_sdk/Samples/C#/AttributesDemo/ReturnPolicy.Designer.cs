namespace AttributesDemo
{
    partial class ReturnPolicyForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.returnPolicyGroupBox = new System.Windows.Forms.GroupBox();
            this.returnPolicyLabel = new System.Windows.Forms.Label();
            this.returnAcceptedLabel = new System.Windows.Forms.Label();
            this.refundTypeLabel = new System.Windows.Forms.Label();
            this.ReturnWithinLabel = new System.Windows.Forms.Label();
            this.shippingCostPaidByLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.returnAcceptedComboBox = new System.Windows.Forms.ComboBox();
            this.refundTypeComboBox = new System.Windows.Forms.ComboBox();
            this.returnWithinComboBox = new System.Windows.Forms.ComboBox();
            this.shippingCostPaidByComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.returnPolicyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AttributesDemo.Properties.Resources.ebay;
            this.pictureBox1.Location = new System.Drawing.Point(303, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // returnPolicyGroupBox
            // 
            this.returnPolicyGroupBox.Controls.Add(this.shippingCostPaidByComboBox);
            this.returnPolicyGroupBox.Controls.Add(this.returnWithinComboBox);
            this.returnPolicyGroupBox.Controls.Add(this.refundTypeComboBox);
            this.returnPolicyGroupBox.Controls.Add(this.returnAcceptedComboBox);
            this.returnPolicyGroupBox.Controls.Add(this.descriptionTextBox);
            this.returnPolicyGroupBox.Controls.Add(this.descriptionLabel);
            this.returnPolicyGroupBox.Controls.Add(this.shippingCostPaidByLabel);
            this.returnPolicyGroupBox.Controls.Add(this.ReturnWithinLabel);
            this.returnPolicyGroupBox.Controls.Add(this.refundTypeLabel);
            this.returnPolicyGroupBox.Controls.Add(this.returnAcceptedLabel);
            this.returnPolicyGroupBox.Location = new System.Drawing.Point(217, 147);
            this.returnPolicyGroupBox.Name = "returnPolicyGroupBox";
            this.returnPolicyGroupBox.Size = new System.Drawing.Size(341, 326);
            this.returnPolicyGroupBox.TabIndex = 1;
            this.returnPolicyGroupBox.TabStop = false;
            this.returnPolicyGroupBox.Text = "Return Policy";
            // 
            // returnPolicyLabel
            // 
            this.returnPolicyLabel.AutoSize = true;
            this.returnPolicyLabel.Location = new System.Drawing.Point(280, 122);
            this.returnPolicyLabel.Name = "returnPolicyLabel";
            this.returnPolicyLabel.Size = new System.Drawing.Size(201, 13);
            this.returnPolicyLabel.TabIndex = 2;
            this.returnPolicyLabel.Text = "Return Policy is Enabled for this Category";
            // 
            // returnAcceptedLabel
            // 
            this.returnAcceptedLabel.AutoSize = true;
            this.returnAcceptedLabel.Location = new System.Drawing.Point(34, 48);
            this.returnAcceptedLabel.Name = "returnAcceptedLabel";
            this.returnAcceptedLabel.Size = new System.Drawing.Size(91, 13);
            this.returnAcceptedLabel.TabIndex = 0;
            this.returnAcceptedLabel.Text = "Return Accepted:";
            // 
            // refundTypeLabel
            // 
            this.refundTypeLabel.AutoSize = true;
            this.refundTypeLabel.Location = new System.Drawing.Point(34, 82);
            this.refundTypeLabel.Name = "refundTypeLabel";
            this.refundTypeLabel.Size = new System.Drawing.Size(72, 13);
            this.refundTypeLabel.TabIndex = 0;
            this.refundTypeLabel.Text = "Refund Type:";
            // 
            // ReturnWithinLabel
            // 
            this.ReturnWithinLabel.AutoSize = true;
            this.ReturnWithinLabel.Location = new System.Drawing.Point(34, 116);
            this.ReturnWithinLabel.Name = "ReturnWithinLabel";
            this.ReturnWithinLabel.Size = new System.Drawing.Size(75, 13);
            this.ReturnWithinLabel.TabIndex = 0;
            this.ReturnWithinLabel.Text = "Return Within:";
            // 
            // shippingCostPaidByLabel
            // 
            this.shippingCostPaidByLabel.AutoSize = true;
            this.shippingCostPaidByLabel.Location = new System.Drawing.Point(34, 150);
            this.shippingCostPaidByLabel.Name = "shippingCostPaidByLabel";
            this.shippingCostPaidByLabel.Size = new System.Drawing.Size(114, 13);
            this.shippingCostPaidByLabel.TabIndex = 0;
            this.shippingCostPaidByLabel.Text = "Shipping Cost Paid By:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(37, 204);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(272, 102);
            this.descriptionTextBox.TabIndex = 1;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(34, 188);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Description:";
            // 
            // returnAcceptedComboBox
            // 
            this.returnAcceptedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.returnAcceptedComboBox.FormattingEnabled = true;
            this.returnAcceptedComboBox.Location = new System.Drawing.Point(156, 48);
            this.returnAcceptedComboBox.Name = "returnAcceptedComboBox";
            this.returnAcceptedComboBox.Size = new System.Drawing.Size(121, 21);
            this.returnAcceptedComboBox.TabIndex = 2;
            // 
            // refundTypeComboBox
            // 
            this.refundTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.refundTypeComboBox.FormattingEnabled = true;
            this.refundTypeComboBox.Location = new System.Drawing.Point(156, 79);
            this.refundTypeComboBox.Name = "refundTypeComboBox";
            this.refundTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.refundTypeComboBox.TabIndex = 2;
            // 
            // returnWithinComboBox
            // 
            this.returnWithinComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.returnWithinComboBox.FormattingEnabled = true;
            this.returnWithinComboBox.Location = new System.Drawing.Point(156, 113);
            this.returnWithinComboBox.Name = "returnWithinComboBox";
            this.returnWithinComboBox.Size = new System.Drawing.Size(121, 21);
            this.returnWithinComboBox.TabIndex = 2;
            // 
            // shippingCostPaidByComboBox
            // 
            this.shippingCostPaidByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shippingCostPaidByComboBox.FormattingEnabled = true;
            this.shippingCostPaidByComboBox.Location = new System.Drawing.Point(156, 147);
            this.shippingCostPaidByComboBox.Name = "shippingCostPaidByComboBox";
            this.shippingCostPaidByComboBox.Size = new System.Drawing.Size(121, 21);
            this.shippingCostPaidByComboBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 493);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(403, 493);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Continue";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ReturnPolicyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.returnPolicyLabel);
            this.Controls.Add(this.returnPolicyGroupBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ReturnPolicyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Return Policy";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.returnPolicyGroupBox.ResumeLayout(false);
            this.returnPolicyGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox returnPolicyGroupBox;
        private System.Windows.Forms.Label returnPolicyLabel;
        private System.Windows.Forms.Label shippingCostPaidByLabel;
        private System.Windows.Forms.Label ReturnWithinLabel;
        private System.Windows.Forms.Label refundTypeLabel;
        private System.Windows.Forms.Label returnAcceptedLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.ComboBox returnAcceptedComboBox;
        private System.Windows.Forms.ComboBox shippingCostPaidByComboBox;
        private System.Windows.Forms.ComboBox returnWithinComboBox;
        private System.Windows.Forms.ComboBox refundTypeComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

    }
}