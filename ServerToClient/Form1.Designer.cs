namespace ServerToClient
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label_name = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label_type = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(43, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(93, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(139, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(199, 68);
            this.button2.TabIndex = 3;
            this.button2.Text = "Отправить на сервер";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_name
            // 
            this.label_name.Location = new System.Drawing.Point(53, 75);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(94, 31);
            this.label_name.TabIndex = 4;
            this.label_name.Text = "Название";
            // 
            // label_date
            // 
            this.label_date.Location = new System.Drawing.Point(182, 75);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(94, 31);
            this.label_date.TabIndex = 5;
            this.label_date.Text = "Дата выпуска";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(330, 109);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 6;
            // 
            // label_type
            // 
            this.label_type.Location = new System.Drawing.Point(345, 75);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(85, 31);
            this.label_type.TabIndex = 7;
            this.label_type.Text = "Тип";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(153, 109);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(147, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(182, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "Товар";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(34, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(496, 121);
            this.label2.TabIndex = 12;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 378);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label_type);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.DateTimePicker dateTimePicker1;

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.TextBox textBox3;

        private System.Windows.Forms.Label label_type;

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;

        #endregion
    }
}