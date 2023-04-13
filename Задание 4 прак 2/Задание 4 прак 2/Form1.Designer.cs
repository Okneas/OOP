namespace Задание_4_прак_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.firstMatrix = new System.Windows.Forms.DataGridView();
            this.secondMatrix = new System.Windows.Forms.DataGridView();
            this.resultMatrix = new System.Windows.Forms.DataGridView();
            this.raws2 = new System.Windows.Forms.Label();
            this.raws1 = new System.Windows.Forms.Label();
            this.col2 = new System.Windows.Forms.Label();
            this.col1 = new System.Windows.Forms.Label();
            this.raw1 = new System.Windows.Forms.TextBox();
            this.columns1 = new System.Windows.Forms.TextBox();
            this.columns2 = new System.Windows.Forms.TextBox();
            this.raw2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.firstMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // firstMatrix
            // 
            this.firstMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.firstMatrix.Location = new System.Drawing.Point(38, 185);
            this.firstMatrix.Name = "firstMatrix";
            this.firstMatrix.RowTemplate.Height = 24;
            this.firstMatrix.Size = new System.Drawing.Size(288, 216);
            this.firstMatrix.TabIndex = 0;
            // 
            // secondMatrix
            // 
            this.secondMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.secondMatrix.Location = new System.Drawing.Point(442, 185);
            this.secondMatrix.Name = "secondMatrix";
            this.secondMatrix.RowTemplate.Height = 24;
            this.secondMatrix.Size = new System.Drawing.Size(288, 216);
            this.secondMatrix.TabIndex = 1;
            // 
            // resultMatrix
            // 
            this.resultMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultMatrix.Location = new System.Drawing.Point(914, 55);
            this.resultMatrix.Name = "resultMatrix";
            this.resultMatrix.RowTemplate.Height = 24;
            this.resultMatrix.Size = new System.Drawing.Size(526, 473);
            this.resultMatrix.TabIndex = 2;
            // 
            // raws2
            // 
            this.raws2.AutoSize = true;
            this.raws2.Location = new System.Drawing.Point(467, 137);
            this.raws2.Name = "raws2";
            this.raws2.Size = new System.Drawing.Size(47, 17);
            this.raws2.TabIndex = 3;
            this.raws2.Text = "Строк";
            // 
            // raws1
            // 
            this.raws1.AutoSize = true;
            this.raws1.Location = new System.Drawing.Point(64, 137);
            this.raws1.Name = "raws1";
            this.raws1.Size = new System.Drawing.Size(47, 17);
            this.raws1.TabIndex = 4;
            this.raws1.Text = "Строк";
            // 
            // col2
            // 
            this.col2.AutoSize = true;
            this.col2.Location = new System.Drawing.Point(645, 137);
            this.col2.Name = "col2";
            this.col2.Size = new System.Drawing.Size(79, 17);
            this.col2.TabIndex = 5;
            this.col2.Text = "Стролбцов";
            // 
            // col1
            // 
            this.col1.AutoSize = true;
            this.col1.Location = new System.Drawing.Point(244, 137);
            this.col1.Name = "col1";
            this.col1.Size = new System.Drawing.Size(71, 17);
            this.col1.TabIndex = 6;
            this.col1.Text = "Столбцов";
            // 
            // raw1
            // 
            this.raw1.Location = new System.Drawing.Point(38, 157);
            this.raw1.Name = "raw1";
            this.raw1.Size = new System.Drawing.Size(94, 22);
            this.raw1.TabIndex = 7;
            // 
            // columns1
            // 
            this.columns1.Location = new System.Drawing.Point(234, 157);
            this.columns1.Name = "columns1";
            this.columns1.Size = new System.Drawing.Size(92, 22);
            this.columns1.TabIndex = 8;
            // 
            // columns2
            // 
            this.columns2.Location = new System.Drawing.Point(639, 157);
            this.columns2.Name = "columns2";
            this.columns2.Size = new System.Drawing.Size(91, 22);
            this.columns2.TabIndex = 9;
            // 
            // raw2
            // 
            this.raw2.Location = new System.Drawing.Point(442, 157);
            this.raw2.Name = "raw2";
            this.raw2.Size = new System.Drawing.Size(96, 22);
            this.raw2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(798, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 39);
            this.label1.TabIndex = 11;
            this.label1.Text = "=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(368, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 39);
            this.label2.TabIndex = 12;
            this.label2.Text = "*";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 24);
            this.button1.TabIndex = 13;
            this.button1.Text = "Установить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(544, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 24);
            this.button2.TabIndex = 14;
            this.button2.Text = "Установить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(764, 213);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 60);
            this.button3.TabIndex = 15;
            this.button3.Text = "Вычислить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(138, 104);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Очистить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(544, 104);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 23);
            this.button5.TabIndex = 17;
            this.button5.Text = "Очистить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 597);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.raw2);
            this.Controls.Add(this.columns2);
            this.Controls.Add(this.columns1);
            this.Controls.Add(this.raw1);
            this.Controls.Add(this.col1);
            this.Controls.Add(this.col2);
            this.Controls.Add(this.raws1);
            this.Controls.Add(this.raws2);
            this.Controls.Add(this.resultMatrix);
            this.Controls.Add(this.secondMatrix);
            this.Controls.Add(this.firstMatrix);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.firstMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView firstMatrix;
        private System.Windows.Forms.DataGridView secondMatrix;
        private System.Windows.Forms.DataGridView resultMatrix;
        private System.Windows.Forms.Label raws2;
        private System.Windows.Forms.Label raws1;
        private System.Windows.Forms.Label col2;
        private System.Windows.Forms.Label col1;
        private System.Windows.Forms.TextBox raw1;
        private System.Windows.Forms.TextBox columns1;
        private System.Windows.Forms.TextBox columns2;
        private System.Windows.Forms.TextBox raw2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

