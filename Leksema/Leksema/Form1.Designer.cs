namespace Leksema
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
            this.OpenFile = new System.Windows.Forms.Button();
            this.ActivateTranslater = new System.Windows.Forms.Button();
            this.EditingText = new System.Windows.Forms.RichTextBox();
            this.SaveInFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(541, 12);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(75, 23);
            this.OpenFile.TabIndex = 1;
            this.OpenFile.Text = "Open File";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // ActivateTranslater
            // 
            this.ActivateTranslater.Location = new System.Drawing.Point(541, 41);
            this.ActivateTranslater.Name = "ActivateTranslater";
            this.ActivateTranslater.Size = new System.Drawing.Size(75, 23);
            this.ActivateTranslater.TabIndex = 2;
            this.ActivateTranslater.Text = "Translater";
            this.ActivateTranslater.UseVisualStyleBackColor = true;
            this.ActivateTranslater.Click += new System.EventHandler(this.ActivateTranslater_Click);
            // 
            // EditingText
            // 
            this.EditingText.Location = new System.Drawing.Point(12, 12);
            this.EditingText.Name = "EditingText";
            this.EditingText.Size = new System.Drawing.Size(523, 328);
            this.EditingText.TabIndex = 3;
            this.EditingText.Text = "";
            // 
            // SaveInFile
            // 
            this.SaveInFile.Location = new System.Drawing.Point(541, 70);
            this.SaveInFile.Name = "SaveInFile";
            this.SaveInFile.Size = new System.Drawing.Size(75, 23);
            this.SaveInFile.TabIndex = 4;
            this.SaveInFile.Text = "Save";
            this.SaveInFile.UseVisualStyleBackColor = true;
            this.SaveInFile.Click += new System.EventHandler(this.SaveInFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 352);
            this.Controls.Add(this.SaveInFile);
            this.Controls.Add(this.EditingText);
            this.Controls.Add(this.ActivateTranslater);
            this.Controls.Add(this.OpenFile);
            this.Name = "Form1";
            this.Text = "Анализ";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button ActivateTranslater;
        private System.Windows.Forms.Button SaveInFile;
        public System.Windows.Forms.RichTextBox EditingText;
    }
}

