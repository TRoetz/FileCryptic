using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace FileCryptic
{
   public partial class frmMain : Form
   {
      public frmMain()
      {
         InitializeComponent();
      }

      private string inFile;
      private string outFile;

      // Rfc2898DeriveBytes constants:
      public readonly byte[] salt = new byte[] { 0x03, 0x01, 0x12, 0x60, 0x10, 0x17, 0x50, 0x23 }; // Must be at least eight bytes.  MAKE THIS SALTIER!
      public const int iterations = 1042; // Recommendation is >= 1000.

      /// <summary>Decrypt a file.</summary>
      /// <remarks>NB: "Padding is invalid and cannot be removed." is the Universal CryptoServices error.  Make sure the password, salt and iterations are correct before getting nervous.</remarks>
      /// <param name="sourceFilename">The full path and name of the file to be decrypted.</param>
      /// <param name="destinationFilename">The full path and name of the file to be output.</param>
      /// <param name="password">The password for the decryption.</param>
      /// <param name="salt">The salt to be applied to the password.</param>
      /// <param name="iterations">The number of iterations Rfc2898DeriveBytes should use before generating the key and initialization vector for the decryption.</param>
      public void DecryptFile(string sourceFilename, string destinationFilename, string password, byte[] salt, int iterations)
      {
         AesManaged aes = new AesManaged();
         aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
         aes.KeySize = aes.LegalKeySizes[0].MaxSize;
         // NB: Rfc2898DeriveBytes initialization and subsequent calls to   GetBytes   must be eactly the same, including order, on both the encryption and decryption sides.
         Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, iterations);
         aes.Key = key.GetBytes(aes.KeySize / 8);
         aes.IV = key.GetBytes(aes.BlockSize / 8);
         aes.Mode = CipherMode.CBC;
         ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);

         using (FileStream destination = new FileStream(destinationFilename, FileMode.CreateNew, FileAccess.Write, FileShare.None))
         {
            using (CryptoStream cryptoStream = new CryptoStream(destination, transform, CryptoStreamMode.Write))
            {
               try
               {
                  using (FileStream source = new FileStream(sourceFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
                  {
                     source.CopyTo(cryptoStream);
                  }
               }
               catch (CryptographicException exception)
               {
                  if (exception.Message == "Padding is invalid and cannot be removed.")
                     throw new ApplicationException("Universal Microsoft Cryptographic Exception (Not to be believed!)", exception);
                  else
                     throw;
               }
            }
         }
      }

      /// <summary>Encrypt a file.</summary>
      /// <param name="sourceFilename">The full path and name of the file to be encrypted.</param>
      /// <param name="destinationFilename">The full path and name of the file to be output.</param>
      /// <param name="password">The password for the encryption.</param>
      /// <param name="salt">The salt to be applied to the password.</param>
      /// <param name="iterations">The number of iterations Rfc2898DeriveBytes should use before generating the key and initialization vector for the decryption.</param>
      public void EncryptFile(string sourceFilename, string destinationFilename, string password, byte[] salt, int iterations)
      {
         AesManaged aes = new AesManaged();
         aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
         aes.KeySize = aes.LegalKeySizes[0].MaxSize;
         // NB: Rfc2898DeriveBytes initialization and subsequent calls to   GetBytes   must be eactly the same, including order, on both the encryption and decryption sides.
         Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, iterations);
         aes.Key = key.GetBytes(aes.KeySize / 8);
         aes.IV = key.GetBytes(aes.BlockSize / 8);
         aes.Mode = CipherMode.CBC;
         ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);

         using (FileStream destination = new FileStream(destinationFilename, FileMode.CreateNew, FileAccess.Write, FileShare.None))
         {
            using (CryptoStream cryptoStream = new CryptoStream(destination, transform, CryptoStreamMode.Write))
            {
               using (FileStream source = new FileStream(sourceFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
               {
                  source.CopyTo(cryptoStream);
               }
            }
         }
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         toolStripStatusLabel.Text = "Ready";
      }

      private void button1_Click(object sender, EventArgs e)
      {
         if (String.IsNullOrWhiteSpace(textBoxPassword.Text))
         {
            MessageBox.Show("Please provide a password.", "Password Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }

         if (openFileDialog.ShowDialog() == DialogResult.OK)
         {
            inFile = openFileDialog.FileName;

            if (File.Exists(inFile))
            {
               outFile = inFile + ".cryptic";
               try
               {
                  EncryptFile(inFile, outFile, textBoxPassword.Text, salt, iterations);
               }
               catch(Exception ex)
               {
                  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
               }
               toolStripStatusLabel.Text = "File: " + inFile + " Encrypted";
            }
         }
      }

      private void button2_Click(object sender, EventArgs e)
      {
         openFileDialog.Filter = "cryptic files (*.cryptic)|*.cryptic|All files (*.*)|*.*";
         openFileDialog.FilterIndex = 2;
         openFileDialog.RestoreDirectory = true;
         openFileDialog.Multiselect = false;

         if (String.IsNullOrWhiteSpace(textBoxPassword.Text))
         {
            MessageBox.Show("Please provide a password.", "Password Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }

         if (openFileDialog.ShowDialog() == DialogResult.OK)
         {
            inFile = openFileDialog.FileName;

            if (File.Exists(inFile))
            {
               outFile = inFile.Replace(".cryptic","");
               try
               {
                  DecryptFile(inFile, outFile, textBoxPassword.Text, salt, iterations);
               }
               catch (Exception ex)
               {
                  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
               }
               toolStripStatusLabel.Text = "File: " + outFile + " Decrypted";
            }
         }
      }

   }
}
