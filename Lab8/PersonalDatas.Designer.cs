namespace Lab8
{
    partial class PersonalDatas
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
            this.Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bday = new System.Windows.Forms.MaskedTextBox();
            this.Passport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MaleBox = new System.Windows.Forms.CheckBox();
            this.FemaleBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(151, 18);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(100, 20);
            this.Name.TabIndex = 0;
            this.Name.Validating += new System.ComponentModel.CancelEventHandler(this.Name_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Дата рождения";
            // 
            // bday
            // 
            this.bday.Location = new System.Drawing.Point(151, 70);
            this.bday.Mask = "00/00/0000";
            this.bday.Name = "bday";
            this.bday.Size = new System.Drawing.Size(100, 20);
            this.bday.TabIndex = 2;
            this.bday.ValidatingType = typeof(System.DateTime);
            this.bday.Validating += new System.ComponentModel.CancelEventHandler(this.bday_Validating);
            // 
            // Passport
            // 
            this.Passport.Location = new System.Drawing.Point(151, 96);
            this.Passport.Name = "Passport";
            this.Passport.Size = new System.Drawing.Size(126, 20);
            this.Passport.TabIndex = 0;
            this.Passport.Validating += new System.ComponentModel.CancelEventHandler(this.Passport_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Серия и номер паспорта";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Пол";
            // 
            // MaleBox
            // 
            this.MaleBox.AutoSize = true;
            this.MaleBox.Location = new System.Drawing.Point(0, 3);
            this.MaleBox.Name = "MaleBox";
            this.MaleBox.Size = new System.Drawing.Size(35, 17);
            this.MaleBox.TabIndex = 3;
            this.MaleBox.Text = "М";
            this.MaleBox.UseVisualStyleBackColor = true;
            // 
            // FemaleBox
            // 
            this.FemaleBox.AutoSize = true;
            this.FemaleBox.Location = new System.Drawing.Point(53, 2);
            this.FemaleBox.Name = "FemaleBox";
            this.FemaleBox.Size = new System.Drawing.Size(37, 17);
            this.FemaleBox.TabIndex = 3;
            this.FemaleBox.Text = "Ж";
            this.FemaleBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.24887F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.502262F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.24887F));
            this.tableLayoutPanel1.Controls.Add(this.buttonPrev, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonNext, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelID, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 191);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 35);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrev.Location = new System.Drawing.Point(3, 3);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(147, 29);
            this.buttonPrev.TabIndex = 0;
            this.buttonPrev.Text = "<";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrevClick);
            // 
            // buttonNext
            // 
            this.buttonNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNext.Location = new System.Drawing.Point(188, 3);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(149, 29);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNextClick);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.BackColor = System.Drawing.SystemColors.Control;
            this.labelID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelID.Location = new System.Drawing.Point(156, 3);
            this.labelID.Margin = new System.Windows.Forms.Padding(3);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(26, 29);
            this.labelID.TabIndex = 2;
            this.labelID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MaleBox);
            this.panel1.Controls.Add(this.FemaleBox);
            this.panel1.Location = new System.Drawing.Point(151, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 20);
            this.panel1.TabIndex = 5;
            this.panel1.Validating += new System.ComponentModel.CancelEventHandler(this.panel1_Validating);
            // 
            // PersonalDatas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 226);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.bday);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Passport);
            this.Controls.Add(this.Name);
            this.Text = "PersonalDatas";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox bday;
        private System.Windows.Forms.TextBox Passport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox MaleBox;
        private System.Windows.Forms.CheckBox FemaleBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Panel panel1;
    }
}