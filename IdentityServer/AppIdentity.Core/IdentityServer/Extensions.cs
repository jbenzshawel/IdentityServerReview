using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityServer4.Stores;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AppIdentity.Core.IdentityServer
{
    public static class Extensions
    {
        /// <summary>
        /// Determines whether the client is configured to use PKCE.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="client_id">The client identifier.</param>
        /// <returns></returns>
        public static async Task<bool> IsPkceClientAsync(this IClientStore store, string client_id)
        {
            if (!string.IsNullOrWhiteSpace(client_id))
            {
                var client = await store.FindEnabledClientByIdAsync(client_id);
                return client?.RequirePkce == true;
            }

            return false;
        }

        /// <summary>
        /// Adds signing credentials for an X509Certificate2 key file
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="options"></param>
        public static void AddCertificateFromFile(
            this IIdentityServerBuilder builder,
            IConfigurationSection options)
        {
            var keyFilePath = options.GetValue<string>("KeyFilePath");

            if (!File.Exists(keyFilePath))
            {
                throw new FileNotFoundException($"Key file located at {keyFilePath} does not exist");

            }

            var keyFilePassword = options.GetValue<string>("KeyFilePassword");

            builder.AddSigningCredential(new X509Certificate2(keyFilePath, keyFilePassword));
        }
    }
}
