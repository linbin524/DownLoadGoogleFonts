namespace DownLoadGoogleFonts
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_fileContent = new System.Windows.Forms.TextBox();
            this.btn_analysisUrl = new System.Windows.Forms.Button();
            this.btn_downloadFont = new System.Windows.Forms.Button();
            this.tb_downLoadRecord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_fileContent
            // 
            this.tb_fileContent.Location = new System.Drawing.Point(12, 38);
            this.tb_fileContent.Multiline = true;
            this.tb_fileContent.Name = "tb_fileContent";
            this.tb_fileContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_fileContent.Size = new System.Drawing.Size(967, 293);
            this.tb_fileContent.TabIndex = 0;
            // 
            // btn_analysisUrl
            // 
            this.btn_analysisUrl.Location = new System.Drawing.Point(994, 36);
            this.btn_analysisUrl.Name = "btn_analysisUrl";
            this.btn_analysisUrl.Size = new System.Drawing.Size(98, 23);
            this.btn_analysisUrl.TabIndex = 1;
            this.btn_analysisUrl.Text = "解析下载字体";
            this.btn_analysisUrl.UseVisualStyleBackColor = true;
            this.btn_analysisUrl.Click += new System.EventHandler(this.btn_analysisUrl_Click);
            // 
            // btn_downloadFont
            // 
            this.btn_downloadFont.Location = new System.Drawing.Point(1006, 378);
            this.btn_downloadFont.Name = "btn_downloadFont";
            this.btn_downloadFont.Size = new System.Drawing.Size(86, 23);
            this.btn_downloadFont.TabIndex = 2;
            this.btn_downloadFont.Text = "下载字体";
            this.btn_downloadFont.UseVisualStyleBackColor = true;
            this.btn_downloadFont.Click += new System.EventHandler(this.btn_downloadFont_Click);
            // 
            // tb_downLoadRecord
            // 
            this.tb_downLoadRecord.Location = new System.Drawing.Point(13, 378);
            this.tb_downLoadRecord.Multiline = true;
            this.tb_downLoadRecord.Name = "tb_downLoadRecord";
            this.tb_downLoadRecord.Size = new System.Drawing.Size(966, 309);
            this.tb_downLoadRecord.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "解析源文件：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "下载记录：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 710);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_downLoadRecord);
            this.Controls.Add(this.btn_downloadFont);
            this.Controls.Add(this.btn_analysisUrl);
            this.Controls.Add(this.tb_fileContent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_fileContent;
        private System.Windows.Forms.Button btn_analysisUrl;
        private System.Windows.Forms.Button btn_downloadFont;
        private System.Windows.Forms.TextBox tb_downLoadRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

