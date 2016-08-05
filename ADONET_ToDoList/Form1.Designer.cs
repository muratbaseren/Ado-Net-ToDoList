namespace ADONET_ToDoList
{
    partial class ToDoList
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
            this.lstGorevler = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGorev = new System.Windows.Forms.TextBox();
            this.rdbYapildi = new System.Windows.Forms.RadioButton();
            this.rdbYapilacak = new System.Windows.Forms.RadioButton();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstGorevler
            // 
            this.lstGorevler.FormattingEnabled = true;
            this.lstGorevler.Location = new System.Drawing.Point(12, 12);
            this.lstGorevler.Name = "lstGorevler";
            this.lstGorevler.Size = new System.Drawing.Size(160, 290);
            this.lstGorevler.TabIndex = 0;
            this.lstGorevler.SelectedIndexChanged += new System.EventHandler(this.lstGorevler_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Yeni Görev";
            // 
            // txtGorev
            // 
            this.txtGorev.Location = new System.Drawing.Point(236, 60);
            this.txtGorev.Name = "txtGorev";
            this.txtGorev.Size = new System.Drawing.Size(237, 20);
            this.txtGorev.TabIndex = 2;
            // 
            // rdbYapildi
            // 
            this.rdbYapildi.AutoSize = true;
            this.rdbYapildi.Location = new System.Drawing.Point(296, 102);
            this.rdbYapildi.Name = "rdbYapildi";
            this.rdbYapildi.Size = new System.Drawing.Size(56, 17);
            this.rdbYapildi.TabIndex = 3;
            this.rdbYapildi.TabStop = true;
            this.rdbYapildi.Text = "Yapıldı";
            this.rdbYapildi.UseVisualStyleBackColor = true;
            // 
            // rdbYapilacak
            // 
            this.rdbYapilacak.AutoSize = true;
            this.rdbYapilacak.Location = new System.Drawing.Point(360, 102);
            this.rdbYapilacak.Name = "rdbYapilacak";
            this.rdbYapilacak.Size = new System.Drawing.Size(72, 17);
            this.rdbYapilacak.TabIndex = 4;
            this.rdbYapilacak.TabStop = true;
            this.rdbYapilacak.Text = "Yapılacak";
            this.rdbYapilacak.UseVisualStyleBackColor = true;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(236, 134);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 5;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(317, 134);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(75, 23);
            this.btnGuncelle.TabIndex = 6;
            this.btnGuncelle.Text = "Guncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(398, 134);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 7;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ToDoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 320);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.rdbYapilacak);
            this.Controls.Add(this.rdbYapildi);
            this.Controls.Add(this.txtGorev);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstGorevler);
            this.Name = "ToDoList";
            this.Text = "ToDoList";
            this.Load += new System.EventHandler(this.ToDoList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstGorevler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGorev;
        private System.Windows.Forms.RadioButton rdbYapildi;
        private System.Windows.Forms.RadioButton rdbYapilacak;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button button1;
    }
}

