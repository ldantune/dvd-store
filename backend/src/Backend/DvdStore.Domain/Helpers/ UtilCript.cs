using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DvdStore.Domain.Helpers;

public class UtilCript
{
    private const string actionKey = "EA81AA1D5FC1EC53E84F30AA746139EEBAFF8A9B76638895";
    private const string actionIv = "87AF7EA221F3FFF5";
    private TripleDESCryptoServiceProvider des3;

    public UtilCript()
    {
        des3 = new TripleDESCryptoServiceProvider();
        des3.Mode = CipherMode.CBC; 
    }


    public string GenerateKey()
    {
        des3.GenerateKey();
        return BytesToHex(des3.Key);
    }

    public string GenerateIV()
    {
        des3.GenerateIV();
        return BytesToHex(des3.IV);
    }



    public string Encrypt(string data, string key, string iv)
    {
        byte[] bdata = Encoding.UTF8.GetBytes(data);
        byte[] bkey = HexToBytes(key);
        byte[] biv = HexToBytes(iv);

        MemoryStream stream = new MemoryStream();
        CryptoStream encStream = new CryptoStream(stream, des3.CreateEncryptor(bkey, biv), CryptoStreamMode.Write);

        encStream.Write(bdata, 0, bdata.Length);
        encStream.FlushFinalBlock();
        encStream.Close();

        return BytesToHex(stream.ToArray());
    }

    public string Decrypt(string data, string key, string iv)
    {
        byte[] bdata = HexToBytes(data);
        byte[] bkey = HexToBytes(key);
        byte[] biv = HexToBytes(iv);

        MemoryStream stream = new MemoryStream();
        CryptoStream encStream = new CryptoStream(stream,
         des3.CreateDecryptor(bkey, biv), CryptoStreamMode.Write);

        if (bdata.Length > 0)
        {
            encStream.Write(bdata, 0, bdata.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return Encoding.UTF8.GetString(stream.ToArray());
        }
        else
        {
            return null;
        }

    }

    private byte[] HexToBytes(string hex)
    {
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < hex.Length / 2; i++)
        {
            string code = hex.Substring(i * 2, 2);
            bytes[i] = byte.Parse(code, System.Globalization.NumberStyles.HexNumber);
        }
        return bytes;
    }

    private string BytesToHex(byte[] bytes)
    {
        StringBuilder hex = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
            hex.AppendFormat("{0:X2}", bytes[i]);
        return hex.ToString();
    }


    public string ActionEncrypt(string data)
    {
        return Encrypt(data, actionKey, actionIv);
    }

    public string ActionDecrypt(string data)
    {
        return Decrypt(data, actionKey, actionIv);
    }
}
