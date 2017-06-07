namespace Pharmacy
{
    partial class Modify
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
            this.label1 = new System.Windows.Forms.Label();
            this.textMmedicine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textMavailable = new System.Windows.Forms.TextBox();
            this.textMdrugType = new System.Windows.Forms.TextBox();
            this.textMbatch = new System.Windows.Forms.TextBox();
            this.textMmrp = new System.Windows.Forms.TextBox();
            this.textMcompany = new System.Windows.Forms.TextBox();
            this.textMexpire = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textMaddQuantity = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a medicine name which to be modified";
            // 
            // textMmedicine
            // 
            this.textMmedicine.Location = new System.Drawing.Point(33, 103);
            this.textMmedicine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textMmedicine.Name = "textMmedicine";
            this.textMmedicine.Size = new System.Drawing.Size(243, 30);
            this.textMmedicine.TabIndex = 1;
            this.textMmedicine.TextChanged += new System.EventHandler(this.textMmedicine_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Available (Adding with existing quantity)";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(324, 206);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(132, 30);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(660, 260);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Drug Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(145, 206);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Set New Expire Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(218, 257);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Batch No.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(623, 307);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Company Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(253, 310);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "MRP";
            // 
            // textMavailable
            // 
            this.textMavailable.Location = new System.Drawing.Point(760, 159);
            this.textMavailable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textMavailable.Name = "textMavailable";
            this.textMavailable.Size = new System.Drawing.Size(132, 30);
            this.textMavailable.TabIndex = 9;
            // 
            // textMdrugType
            // 
            this.textMdrugType.Location = new System.Drawing.Point(760, 260);
            this.textMdrugType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textMdrugType.Name = "textMdrugType";
            this.textMdrugType.Size = new System.Drawing.Size(132, 30);
            this.textMdrugType.TabIndex = 10;
            // 
            // textMbatch
            // 
            this.textMbatch.Location = new System.Drawing.Point(324, 254);
            this.textMbatch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textMbatch.Name = "textMbatch";
            this.textMbatch.Size = new System.Drawing.Size(132, 30);
            this.textMbatch.TabIndex = 11;
            // 
            // textMmrp
            // 
            this.textMmrp.Location = new System.Drawing.Point(324, 307);
            this.textMmrp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textMmrp.Name = "textMmrp";
            this.textMmrp.Size = new System.Drawing.Size(132, 30);
            this.textMmrp.TabIndex = 12;
            // 
            // textMcompany
            // 
            this.textMcompany.Location = new System.Drawing.Point(760, 303);
            this.textMcompany.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textMcompany.Name = "textMcompany";
            this.textMcompany.Size = new System.Drawing.Size(132, 30);
            this.textMcompany.TabIndex = 13;
            // 
            // textMexpire
            // 
            this.textMexpire.Location = new System.Drawing.Point(760, 209);
            this.textMexpire.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textMexpire.Name = "textMexpire";
            this.textMexpire.Size = new System.Drawing.Size(132, 30);
            this.textMexpire.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(591, 216);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Previous Expire Date";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(495, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 35);
            this.button1.TabIndex = 16;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(612, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Existing Quantity";
            // 
            // textMaddQuantity
            // 
            this.textMaddQuantity.Location = new System.Drawing.Point(324, 163);
            this.textMaddQuantity.Name = "textMaddQuantity";
            this.textMaddQuantity.Size = new System.Drawing.Size(132, 30);
            this.textMaddQuantity.TabIndex = 18;
            // 
            // Modify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 425);
            this.Controls.Add(this.textMaddQuantity);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textMexpire);
            this.Controls.Add(this.textMcompany);
            this.Controls.Add(this.textMmrp);
            this.Controls.Add(this.textMbatch);
            this.Controls.Add(this.textMdrugType);
            this.Controls.Add(this.textMavailable);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textMmedicine);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Modify";
            this.Text = "Modify Existing Items";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textMmedicine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textMavailable;
        private System.Windows.Forms.TextBox textMdrugType;
        private System.Windows.Forms.TextBox textMbatch;
        private System.Windows.Forms.TextBox textMmrp;
        private System.Windows.Forms.TextBox textMcompany;
        private System.Windows.Forms.TextBox textMexpire;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textMaddQuantity;
    }
}