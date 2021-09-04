using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncryptDescrypt
{
    public class Encrypter
    {
        #region constantes
        private const string _cKey = "12345678";
        private const string _cVec = "12345678";
        #endregion
        /// <summary>
        /// Metodo para Encrypt
        /// </summary>
        /// <param name="campo">Contraseña para encriptar</param>
        /// <returns></returns>
        /// 

        public static string Encrypt(string campo)
        {

            byte[] textoplano;


            textoplano = Encoding.UTF8.GetBytes(campo);

            byte[] keys = Encoding.UTF8.GetBytes(_cKey);

            MemoryStream memdata = new MemoryStream();
            ICryptoTransform transform;
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.CBC;


            transform = des.CreateEncryptor(keys, Encoding.UTF8.GetBytes(_cVec));

            CryptoStream encstream = new CryptoStream(memdata, transform, CryptoStreamMode.Write);

            encstream.Write(textoplano, 0, textoplano.Length);
            encstream.FlushFinalBlock();
            encstream.Close();

            campo = Convert.ToBase64String(memdata.ToArray());

            return campo;
        }

        /// <summary>
        /// Metodo para Descrypt
        /// </summary>
        /// <param name="campo">Contraseña encriptada</param>
        /// <returns></returns>
        public static string Decrypt(string campo)
        {

            byte[] textoplano;

            textoplano = Convert.FromBase64String(campo);

            byte[] keys = Encoding.UTF8.GetBytes(_cKey);

            MemoryStream memdata = new MemoryStream();
            ICryptoTransform transform;
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.CBC;

            transform = des.CreateDecryptor(keys, Encoding.UTF8.GetBytes(_cVec));

            CryptoStream encstream = new CryptoStream(memdata, transform, CryptoStreamMode.Write);

            encstream.Write(textoplano, 0, textoplano.Length);
            encstream.FlushFinalBlock();
            encstream.Close();

            campo = Encoding.UTF8.GetString(memdata.ToArray());

            return campo;
        }
    }
}
