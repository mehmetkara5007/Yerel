using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Web;

namespace Yerel.aws.Infrastructure
{
    public class EncryptionUtility
    {

        // Fields
        private static readonly byte[] Key = { 33, 39, 185, 52, 45, 254, 35, 31, 203, 33, 8, 203, 31, 58, 35, 12, 4, 193, 17, 9, 222, 8, 11, 247, 45, 86, 75, 135, 182, 73, 245, 116 };
        private static readonly byte[] Iv = { 54, 148, 32, 84, 21, 250, 176, 253, 55, 167, 254, 58, 69, 68, 82, 52 };

        // Methods
        public static string Decrypt(string stringToDecrypt)
        {
            RijndaelManaged aesAlg = null;
            CryptoStream csDecrypt = null;
            MemoryStream msDecrypt = null;
            string plaintext;
            StreamReader srDecrypt = null;
            try
            {
                aesAlg = new RijndaelManaged();

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(Key, Iv);
                msDecrypt = new MemoryStream(Convert.FromBase64String(stringToDecrypt));
                csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                srDecrypt = new StreamReader(csDecrypt);
                plaintext = srDecrypt.ReadToEnd();
            }
            finally
            {
                if (srDecrypt != null)
                {
                    srDecrypt.Close();
                }
                if (csDecrypt != null)
                {
                    csDecrypt.Close();
                }
                if (msDecrypt != null)
                {
                    msDecrypt.Close();
                }
                if (aesAlg != null)
                {
                    aesAlg.Clear();
                }
            }
            return plaintext;
        }

        public static string Encrypt(string stringToEncrypt)
        {
            RijndaelManaged aesAlg = null;
            CryptoStream csEncrypt = null;
            MemoryStream msEncrypt = null;
            StreamWriter swEncrypt = null;
            try
            {
                aesAlg = new RijndaelManaged();
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(Key, Iv);
                msEncrypt = new MemoryStream();
                csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                swEncrypt = new StreamWriter(csEncrypt);
                swEncrypt.Write(stringToEncrypt);
            }
            finally
            {
                if (swEncrypt != null)
                {
                    swEncrypt.Close();
                }
                if (csEncrypt != null)
                {
                    csEncrypt.Close();
                }
                if (msEncrypt != null)
                {
                    msEncrypt.Close();
                }
                if (aesAlg != null)
                {
                    aesAlg.Clear();
                }
            }
            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public static bool StringEncrypted(string StringToTest)
        {
            try
            {
                Decrypt(StringToTest);

                return true;
            }
            catch
            {
                return false;
            }


        }
        public int DosyaTipiNe(HttpPostedFileBase fileUpload)
        {


            if (fileUpload != null)
            {
                string resimdosyaTipleri = ConfigurationManager.AppSettings["ResimDosyaTipleri"];
                string videoDosyaTipleri = ConfigurationManager.AppSettings["VideoDosyaTipleri"];
                string dokumanTipi = System.IO.Path.GetExtension(fileUpload.FileName);

                if (resimdosyaTipleri.ToLower().Contains(dokumanTipi.ToLower()))
                {
                    return 1;
                }
                else if (videoDosyaTipleri.ToLower().Contains(dokumanTipi.ToLower()))
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }

        }
        public bool ResimDosyaBoyutKontrol(HttpPostedFileBase fileUpload)
        {

            bool sonuc = false;
            if (fileUpload != null)
            {
                string dosyaTipleri = ConfigurationManager.AppSettings["ResimDosyaTipleri"];
                string dokumanTipi = System.IO.Path.GetExtension(fileUpload.FileName);
                int m_maxFileUploadSize = 0;
                Int32.TryParse(ConfigurationManager.AppSettings["MaxFileUploadSize"], out m_maxFileUploadSize);
                if (m_maxFileUploadSize <= 0)
                {
                    //default 5 MB olarak ayarlanacak config de yok ise
                    m_maxFileUploadSize = 100 * 1014 * 1024;
                }
                if (dosyaTipleri.ToLower().Contains(dokumanTipi.ToLower()))
                {
                    sonuc = (fileUpload.ContentLength <= m_maxFileUploadSize);
                }
            }
            return sonuc;
        }
        public bool VideoDosyaBoyutKontrol(HttpPostedFileBase fileUpload)
        {

            bool sonuc = false;
            if (fileUpload != null)
            {
                string dosyaTipleri = ConfigurationManager.AppSettings["VideoDosyaTipleri"];
                string dokumanTipi = System.IO.Path.GetExtension(fileUpload.FileName);
                int m_maxFileUploadSize = 0;
                Int32.TryParse(ConfigurationManager.AppSettings["MaxFileUploadSize"], out m_maxFileUploadSize);
                if (m_maxFileUploadSize <= 0)
                {
                    //default 5 MB olarak ayarlanacak config de yok ise
                    m_maxFileUploadSize = 100 * 1014 * 1024;
                }
                if (dosyaTipleri.ToLower().Contains(dokumanTipi.ToLower()))
                {
                    sonuc = (fileUpload.ContentLength <= m_maxFileUploadSize);
                }
            }
            return sonuc;
        }
    }
}