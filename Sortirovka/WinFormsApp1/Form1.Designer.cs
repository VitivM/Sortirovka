namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            listView1 = new ListView();
            listView2 = new ListView();
            listView3 = new ListView();
            label2 = new Label();
            listView4 = new ListView();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 0;
            label1.Text = "Размер массива: 100";
            // 
            // button1
            // 
            button1.Location = new Point(138, 5);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Старт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(11, 54);
            listView1.Name = "listView1";
            listView1.Size = new Size(318, 303);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            listView2.Location = new Point(335, 54);
            listView2.Name = "listView2";
            listView2.Size = new Size(317, 303);
            listView2.TabIndex = 3;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView3
            // 
            listView3.Location = new Point(12, 394);
            listView3.Name = "listView3";
            listView3.Size = new Size(317, 295);
            listView3.TabIndex = 4;
            listView3.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 36);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 6;
            label2.Text = "Оригинал";
            // 
            // listView4
            // 
            listView4.Location = new Point(335, 394);
            listView4.Name = "listView4";
            listView4.Size = new Size(317, 295);
            listView4.TabIndex = 7;
            listView4.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(335, 36);
            label3.Name = "label3";
            label3.Size = new Size(138, 15);
            label3.TabIndex = 8;
            label3.Text = "Сортировка пузырьком";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 376);
            label4.Name = "label4";
            label4.Size = new Size(120, 15);
            label4.TabIndex = 9;
            label4.Text = "Быстрая сортировка";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(335, 376);
            label5.Name = "label5";
            label5.Size = new Size(117, 15);
            label5.TabIndex = 10;
            label5.Text = "Сортировка вставка";
            // 
            // button2
            // 
            button2.Location = new Point(495, 9);
            button2.Name = "button2";
            button2.Size = new Size(160, 23);
            button2.TabIndex = 11;
            button2.Text = "Перемножение матриц";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 704);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(listView4);
            Controls.Add(label2);
            Controls.Add(listView3);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Сортировка";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private ListView listView1;
        private ListView listView2;
        private ListView listView3;
        private Label label2;
        private ListView listView4;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button2;
    }
}
