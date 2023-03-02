using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Encryption
{
	public class Crypto
	{

		#region Constants

		private const string DefaultKey = "23B6895C63D64F6AB312BFC10527709D";

		#endregion Constants

		#region Local Vars
		#endregion Local Vars

		#region Properties
		#endregion Properties

		#region Constructors

		#endregion Constructors

		#region Methods

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion Protected Methods

		#region Public Methods

		/// <summary>
		/// Generates the key encryption.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public string GenerateKeyEncryption(string key = DefaultKey)
		{
			if (key == "")
			{
				key = Guid.NewGuid().ToString();
			}
			var charArray = key.Replace("-", string.Empty).ToCharArray().Reverse<char>();

			return EncryptOneWay(new string(charArray.ToArray()));
		}

		/// <summary>
		/// Encrypts the data one way (ie the data can not be decrypted)
		/// </summary>
		/// <param name="data">The data to encrypt.</param>
		/// <returns>
		///     The encrypted value 
		/// </returns>
		public string EncryptOneWay(string data)
		{
			if (string.IsNullOrWhiteSpace(data))
			{
				throw new Exception("Invalid data parameter to EncryptOneWay!");
			}

			var encoding = new UnicodeEncoding();
			var byteText = encoding.GetBytes(data);
			using (var sha = new SHA256Managed())
			{
				var hashValue = sha.ComputeHash(byteText);
				return Convert.ToBase64String(hashValue);
			}
		}

		/// <summary>
		/// Encrypts the specified data.
		/// </summary>
		/// <param name="dataToEncrypt">The data to encrypt.</param>
		/// <param name="key">The key.</param>
		/// <returns>
		///     The encrypted value 
		/// </returns>
		public string Encrypt(string dataToEncrypt, string key = DefaultKey)
		{
			if (string.IsNullOrWhiteSpace(dataToEncrypt))
			{
				throw new Exception("Invalid dataToEncrypt parameter to Encrypt!");
			}
			if (string.IsNullOrWhiteSpace(key))
			{
				throw new Exception("Invalid key parameter to Encrypt!");
			}

			var aesCipher = new AesManaged { Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7, KeySize = 256, BlockSize = 128 };

			var pwdBytes = Encoding.UTF8.GetBytes(key);
			var keyBytes = new byte[32];

			var len = pwdBytes.Length;
			if (len > keyBytes.Length)
			{
				len = keyBytes.Length;
			}

			Array.Copy(pwdBytes, keyBytes, len);

			aesCipher.Key = keyBytes;
			aesCipher.IV = keyBytes.Take(16).ToArray();

			var encodedBytes = Encoding.UTF8.GetBytes(dataToEncrypt);

			var encryptedBytes = aesCipher.CreateEncryptor().TransformFinalBlock(encodedBytes, 0, dataToEncrypt.Length);

			return Convert.ToBase64String(encryptedBytes);
		}

		/// <summary>
		/// Decrypts the specified encrypted data.
		/// </summary>
		/// <param name="data">The encrypted data.</param>
		/// <param name="key">The key.</param>
		/// <returns>
		///     The decrypted data
		/// </returns>
		public string Decrypt(string data, string key = DefaultKey)
		{
			if (string.IsNullOrWhiteSpace(data))
			{
				throw new Exception("Invalid data parameter to Decrypt!");
			}
			if (string.IsNullOrWhiteSpace(key))
			{
				throw new Exception("Invalid key parameter to Decrypt!");
			}

			var aesCipher = new AesManaged { Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7, KeySize = 256, BlockSize = 128 };

			var encryptedData = Convert.FromBase64String(data);
			var pwdBytes = Encoding.UTF8.GetBytes(key);
			var keyBytes = new byte[32];

			var len = pwdBytes.Length;
			if (len > keyBytes.Length) len = keyBytes.Length;

			Array.Copy(pwdBytes, keyBytes, len);

			aesCipher.Key = keyBytes;
			aesCipher.IV = keyBytes.Take(16).ToArray();

			var decrypted = aesCipher.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);

			return Encoding.UTF8.GetString(decrypted);
		}

		#endregion Public Methods

		#endregion Methods

	}
}
