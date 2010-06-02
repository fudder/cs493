namespace AttributesDemo
{
    partial class CategoryListForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.categoryListBox = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AllRadioButton = new System.Windows.Forms.RadioButton();
            this.BothRadioButton = new System.Windows.Forms.RadioButton();
            this.ItemSpecificsOnlyRadioButton = new System.Windows.Forms.RadioButton();
            this.AttributesOnlyRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.categoryListBox);
            this.groupBox1.Location = new System.Drawing.Point(253, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 331);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Category";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "A: Attributes    S: ItemSpecifics";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(296, 478);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(401, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Continue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // categoryListBox
            // 
            this.categoryListBox.FormattingEnabled = true;
            this.categoryListBox.Location = new System.Drawing.Point(6, 19);
            this.categoryListBox.Name = "categoryListBox";
            this.categoryListBox.Size = new System.Drawing.Size(265, 277);
            this.categoryListBox.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AttributesDemo.Properties.Resources.ebay;
            this.pictureBox1.Location = new System.Drawing.Point(307, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AllRadioButton);
            this.groupBox2.Controls.Add(this.BothRadioButton);
            this.groupBox2.Controls.Add(this.ItemSpecificsOnlyRadioButton);
            this.groupBox2.Controls.Add(this.AttributesOnlyRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(536, 299);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 113);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "type";
            // 
            // AllRadioButton
            // 
            this.AllRadioButton.AutoSize = true;
            this.AllRadioButton.Checked = true;
            this.AllRadioButton.Location = new System.Drawing.Point(6, 88);
            this.AllRadioButton.Name = "AllRadioButton";
            this.AllRadioButton.Size = new System.Drawing.Size(36, 17);
            this.AllRadioButton.TabIndex = 3;
            this.AllRadioButton.TabStop = true;
            this.AllRadioButton.Text = "All";
            this.AllRadioButton.UseVisualStyleBackColor = true;
            this.AllRadioButton.CheckedChanged += new System.EventHandler(this.AllRadioButton_CheckedChanged);
            // 
            // BothRadioButton
            // 
            this.BothRadioButton.AutoSize = true;
            this.BothRadioButton.Location = new System.Drawing.Point(6, 63);
            this.BothRadioButton.Name = "BothRadioButton";
            this.BothRadioButton.Size = new System.Drawing.Size(47, 17);
            this.BothRadioButton.TabIndex = 2;
            this.BothRadioButton.Text = "Both";
            this.BothRadioButton.UseVisualStyleBackColor = true;
            this.BothRadioButton.CheckedChanged += new System.EventHandler(this.BothRadioButton_CheckedChanged);
            // 
            // ItemSpecificsOnlyRadioButton
            // 
            this.ItemSpecificsOnlyRadioButton.AutoSize = true;
            this.ItemSpecificsOnlyRadioButton.Location = new System.Drawing.Point(6, 38);
            this.ItemSpecificsOnlyRadioButton.Name = "ItemSpecificsOnlyRadioButton";
            this.ItemSpecificsOnlyRadioButton.Size = new System.Drawing.Size(115, 17);
            this.ItemSpecificsOnlyRadioButton.TabIndex = 1;
            this.ItemSpecificsOnlyRadioButton.Text = "Item Specifics Only";
            this.ItemSpecificsOnlyRadioButton.UseVisualStyleBackColor = true;
            this.ItemSpecificsOnlyRadioButton.CheckedChanged += new System.EventHandler(this.ItemSpecificsOnlyRadioButton_CheckedChanged);
            // 
            // AttributesOnlyRadioButton
            // 
            this.AttributesOnlyRadioButton.AutoSize = true;
            this.AttributesOnlyRadioButton.Location = new System.Drawing.Point(6, 13);
            this.AttributesOnlyRadioButton.Name = "AttributesOnlyRadioButton";
            this.AttributesOnlyRadioButton.Size = new System.Drawing.Size(93, 17);
            this.AttributesOnlyRadioButton.TabIndex = 0;
            this.AttributesOnlyRadioButton.Text = "Attributes Only";
            this.AttributesOnlyRadioButton.UseVisualStyleBackColor = true;
            this.AttributesOnlyRadioButton.CheckedChanged += new System.EventHandler(this.AttributesOnlyRadioButton_CheckedChanged);
            // 
            // CategoryListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Category List";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox categoryListBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton ItemSpecificsOnlyRadioButton;
        private System.Windows.Forms.RadioButton AttributesOnlyRadioButton;
        private System.Windows.Forms.RadioButton BothRadioButton;
        private System.Windows.Forms.RadioButton AllRadioButton;

    }
}