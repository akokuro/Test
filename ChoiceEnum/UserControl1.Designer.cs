namespace ChoiceEnum
{
    partial class UserControl1
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxEnum = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxEnum
            // 
            this.listBoxEnum.FormattingEnabled = true;
            this.listBoxEnum.Location = new System.Drawing.Point(14, 22);
            this.listBoxEnum.Name = "listBoxEnum";
            this.listBoxEnum.Size = new System.Drawing.Size(493, 147);
            this.listBoxEnum.TabIndex = 0;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxEnum);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(524, 187);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxEnum;
    }
}
