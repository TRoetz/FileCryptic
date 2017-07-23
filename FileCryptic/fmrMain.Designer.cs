namespace FileCryptic
{
   partial class frmMain
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
         this.buttonEncrypt = new System.Windows.Forms.Button();
         this.statusStripInfo = new System.Windows.Forms.StatusStrip();
         this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this.buttonDecrypt = new System.Windows.Forms.Button();
         this.labelPassword = new System.Windows.Forms.Label();
         this.textBoxPassword = new System.Windows.Forms.TextBox();
         this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
         this.statusStripInfo.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonEncrypt
         // 
         this.buttonEncrypt.Location = new System.Drawing.Point(12, 8);
         this.buttonEncrypt.Name = "buttonEncrypt";
         this.buttonEncrypt.Size = new System.Drawing.Size(115, 23);
         this.buttonEncrypt.TabIndex = 0;
         this.buttonEncrypt.Text = "Encrypt File";
         this.buttonEncrypt.UseVisualStyleBackColor = true;
         this.buttonEncrypt.Click += new System.EventHandler(this.button1_Click);
         // 
         // statusStripInfo
         // 
         this.statusStripInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
         this.statusStripInfo.Location = new System.Drawing.Point(0, 59);
         this.statusStripInfo.Name = "statusStripInfo";
         this.statusStripInfo.Size = new System.Drawing.Size(330, 22);
         this.statusStripInfo.TabIndex = 1;
         this.statusStripInfo.Text = "statusStrip1";
         // 
         // toolStripStatusLabel
         // 
         this.toolStripStatusLabel.Name = "toolStripStatusLabel";
         this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
         this.toolStripStatusLabel.Text = "Ready";
         // 
         // buttonDecrypt
         // 
         this.buttonDecrypt.Location = new System.Drawing.Point(203, 8);
         this.buttonDecrypt.Name = "buttonDecrypt";
         this.buttonDecrypt.Size = new System.Drawing.Size(115, 23);
         this.buttonDecrypt.TabIndex = 2;
         this.buttonDecrypt.Text = "Decrypt File";
         this.buttonDecrypt.UseVisualStyleBackColor = true;
         this.buttonDecrypt.Click += new System.EventHandler(this.button2_Click);
         // 
         // labelPassword
         // 
         this.labelPassword.AutoSize = true;
         this.labelPassword.Location = new System.Drawing.Point(13, 38);
         this.labelPassword.Name = "labelPassword";
         this.labelPassword.Size = new System.Drawing.Size(56, 13);
         this.labelPassword.TabIndex = 3;
         this.labelPassword.Text = "Password:";
         // 
         // textBoxPassword
         // 
         this.textBoxPassword.Location = new System.Drawing.Point(67, 35);
         this.textBoxPassword.Name = "textBoxPassword";
         this.textBoxPassword.Size = new System.Drawing.Size(251, 20);
         this.textBoxPassword.TabIndex = 4;
         // 
         // openFileDialog
         // 
         this.openFileDialog.FileName = "openFileDialog";
         // 
         // frmMain
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(330, 81);
         this.Controls.Add(this.textBoxPassword);
         this.Controls.Add(this.labelPassword);
         this.Controls.Add(this.buttonDecrypt);
         this.Controls.Add(this.statusStripInfo);
         this.Controls.Add(this.buttonEncrypt);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "frmMain";
         this.Text = "FileCryptic";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.statusStripInfo.ResumeLayout(false);
         this.statusStripInfo.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button buttonEncrypt;
      private System.Windows.Forms.StatusStrip statusStripInfo;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
      private System.Windows.Forms.Button buttonDecrypt;
      private System.Windows.Forms.Label labelPassword;
      private System.Windows.Forms.TextBox textBoxPassword;
      private System.Windows.Forms.OpenFileDialog openFileDialog;
   }
}

