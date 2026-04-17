using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Storage.Blobs;
using System.Security.Cryptography;


namespace KashafImageApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Removed to protect sensitive information
            string tenantId = "";
            string clientId = "";
            string clientSecret = "";

            string keyVaultUrl = "https://kashuiivault.vault.azure.net/";
            string keyName = "";

            string blobUrl = "https://krazastorage.blob.core.windows.net/";
            string containerName = "image";

            string inputFile = "input.jpg";
            string outputFile = "output.jpg";
            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

            // Key Vault
            var keyClient = new KeyClient(new Uri(keyVaultUrl), credential);
            var key = await keyClient.GetKeyAsync(keyName);
            var cryptoClient = new CryptographyClient(key.Value.Id, credential);

            using Aes aes = Aes.Create();
            aes.GenerateKey();
            aes.GenerateIV();

            // Read image
            byte[] imageBytes = File.ReadAllBytes(inputFile);

            // Encrypt image
            var encryptor = aes.CreateEncryptor();
            byte[] encryptedImage = encryptor.TransformFinalBlock(imageBytes, 0, imageBytes.Length);

            // Wrap AES key
            var wrappedKey = await cryptoClient.WrapKeyAsync(KeyWrapAlgorithm.RsaOaep, aes.Key);

            // Combine data
            using MemoryStream ms = new MemoryStream();
            ms.Write(BitConverter.GetBytes(wrappedKey.EncryptedKey.Length));
            ms.Write(wrappedKey.EncryptedKey);
            ms.Write(aes.IV);
            ms.Write(encryptedImage);

            byte[] finalData = ms.ToArray();

            // Upload to Blob
            BlobClient blobClient = new BlobClient(new Uri($"{blobUrl}{containerName}/encrypted.bin"), credential);

            using MemoryStream uploadStream = new MemoryStream(finalData);
            await blobClient.UploadAsync(uploadStream, overwrite: true);

            Console.WriteLine("✅ Encrypted image uploaded!");



            var download = await blobClient.DownloadContentAsync();
            byte[] data = download.Value.Content.ToArray();

            using MemoryStream ms2 = new MemoryStream(data);

            byte[] lenBytes = new byte[4];
            ms2.Read(lenBytes);
            int keyLength = BitConverter.ToInt32(lenBytes);

            byte[] encryptedKey = new byte[keyLength];
            ms2.Read(encryptedKey);

            byte[] iv = new byte[16];
            ms2.Read(iv);

            byte[] encryptedImg = new byte[ms2.Length - ms2.Position];
            ms2.Read(encryptedImg);

            var unwrappedKey = await cryptoClient.UnwrapKeyAsync(KeyWrapAlgorithm.RsaOaep, encryptedKey);

            using Aes aes2 = Aes.Create();
            aes2.Key = unwrappedKey.Key;
            aes2.IV = iv;

            var decryptor = aes2.CreateDecryptor();
            byte[] decryptedImage = decryptor.TransformFinalBlock(encryptedImg, 0, encryptedImg.Length);

            File.WriteAllBytes(outputFile, decryptedImage);

            Console.WriteLine("✅ Image decrypted and saved!");

        }
    }
}
