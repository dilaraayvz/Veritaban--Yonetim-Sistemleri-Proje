namespace SinemaOtomasyonu
{
    partial class FormBiletFatura
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataGridViewBilet = new System.Windows.Forms.DataGridView();
            this.btnExitt = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBilet)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(294, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(425, 30);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Bilet ve Fatura Bilgileri";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dataGridViewBilet
            // 
            this.dataGridViewBilet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBilet.Location = new System.Drawing.Point(49, 139);
            this.dataGridViewBilet.Name = "dataGridViewBilet";
            this.dataGridViewBilet.RowHeadersWidth = 51;
            this.dataGridViewBilet.RowTemplate.Height = 24;
            this.dataGridViewBilet.Size = new System.Drawing.Size(898, 102);
            this.dataGridViewBilet.TabIndex = 5;
            // 
            // btnExitt
            // 
            this.btnExitt.AccessibleName = "";
            this.btnExitt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExitt.Location = new System.Drawing.Point(881, 12);
            this.btnExitt.Name = "btnExitt";
            this.btnExitt.Size = new System.Drawing.Size(101, 43);
            this.btnExitt.TabIndex = 39;
            this.btnExitt.Text = "ÇIKIŞ";
            this.btnExitt.UseVisualStyleBackColor = true;
            this.btnExitt.Click += new System.EventHandler(this.btnExitt_Click);
            // 
            // btnGeri
            // 
            this.btnGeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeri.Location = new System.Drawing.Point(34, 12);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(75, 37);
            this.btnGeri.TabIndex = 38;
            this.btnGeri.Text = "GERİ";
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(31, 264);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(64, 16);
            this.lblUser.TabIndex = 51;
            this.lblUser.Text = "Account : ";
            // 
            // FormBiletFatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 299);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnExitt);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.dataGridViewBilet);
            this.Controls.Add(this.textBox1);
            this.Name = "FormBiletFatura";
            this.Text = "FormBiletFatura";
            this.Load += new System.EventHandler(this.FormBiletFatura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBilet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dataGridViewBilet;
        private System.Windows.Forms.Button btnExitt;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Label lblUser;
    }
}