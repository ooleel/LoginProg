
namespace PayApplication
{
    partial class CalculatorForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.hoursWorkedTextbox = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.employeeDetailsListBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.paySlipTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hours Worked (hrs)";
            // 
            // hoursWorkedTextbox
            // 
            this.hoursWorkedTextbox.Location = new System.Drawing.Point(164, 275);
            this.hoursWorkedTextbox.Name = "hoursWorkedTextbox";
            this.hoursWorkedTextbox.Size = new System.Drawing.Size(92, 22);
            this.hoursWorkedTextbox.TabIndex = 3;
            this.hoursWorkedTextbox.Text = "0";
            this.hoursWorkedTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hoursWorkedTextbox.TextChanged += new System.EventHandler(this.hoursWorkedTextbox_TextChanged);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(210, 349);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(91, 23);
            this.calculateButton.TabIndex = 4;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.employeeDetailsListBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.hoursWorkedTextbox);
            this.groupBox1.Location = new System.Drawing.Point(46, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 379);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Details";
            // 
            // employeeDetailsListBox
            // 
            this.employeeDetailsListBox.FormattingEnabled = true;
            this.employeeDetailsListBox.ItemHeight = 16;
            this.employeeDetailsListBox.Location = new System.Drawing.Point(29, 48);
            this.employeeDetailsListBox.Name = "employeeDetailsListBox";
            this.employeeDetailsListBox.Size = new System.Drawing.Size(226, 212);
            this.employeeDetailsListBox.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.saveButton);
            this.groupBox2.Controls.Add(this.paySlipTextBox);
            this.groupBox2.Location = new System.Drawing.Point(402, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 379);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment Summary";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(181, 321);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // paySlipTextBox
            // 
            this.paySlipTextBox.Location = new System.Drawing.Point(23, 43);
            this.paySlipTextBox.Multiline = true;
            this.paySlipTextBox.Name = "paySlipTextBox";
            this.paySlipTextBox.ReadOnly = true;
            this.paySlipTextBox.Size = new System.Drawing.Size(234, 254);
            this.paySlipTextBox.TabIndex = 0;
            this.paySlipTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "CalculatorForm";
            this.Text = "Weekly Payment Calculator";
            this.Load += new System.EventHandler(this.CalculatorForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hoursWorkedTextbox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox paySlipTextBox;
        private System.Windows.Forms.ListBox employeeDetailsListBox;
        private System.Windows.Forms.Button saveButton;
    }
}

