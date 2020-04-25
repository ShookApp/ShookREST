using System;
using System.Threading;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ShookREST.Utils.Authorization
{
    /// <summary>
    /// This class generates a random api key every 24 hours.
    /// </summary>
    public class ApiKeyGenerator
    {
        private readonly Thread _generatorThread = new Thread(
            new ThreadStart(GenerateAndWrite));

        public static DateTime Created { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ApiKeyGenerator()
        {
            _generatorThread.Start();
        }

        /// <summary>
        /// Receives the api key and saves it to the <see cref="StaticStrings"/> class.
        /// </summary>
        private static void GenerateAndWrite()
        {
            // TODO: Improve loop.
            while (true)
            {
                StaticStrings.ApiKey = GetHash();
                Created = DateTime.Now;
                Thread.Sleep(86400000);
            }
        }

        #region private methods

        /// <summary>
        /// Gets the mac address of every network interface of the machine.
        /// </summary>
        /// <returns>A list of strings that includes the mac addresses of every available network interface.</returns>
        private static List<string> GetMacAddresses()
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            var adapters = new List<string>();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                adapters.Add(networkInterface.GetPhysicalAddress().ToString());
            }

            return adapters;
        }

        /// <summary>
        /// Creates a hash of a mac address and a random string.
        /// </summary>
        /// <returns>A string that is a hash of a mac address and a random string.</returns>
        private static string GetHash()
        {
            var macAddresses = GetMacAddresses();

            var provider = MD5.Create();

            var salt = RandomString(12, false);
            var password = macAddresses[11];

            var bytes = provider.ComputeHash(Encoding.ASCII.GetBytes(salt + password));

            return BitConverter.ToString(bytes);
        }

        /// <summary>
        /// Creates a random string.
        /// </summary>
        /// <param name="size">The amount of characters.</param>
        /// <param name="lowerCase">Should the string be lower case only?</param>
        /// <returns>A random string.</returns>
        private static string RandomString(int size, bool lowerCase)
        {
            var builder = new StringBuilder();

            var random = new Random();

            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            if (lowerCase)
                return builder.ToString().ToLower();

            return builder.ToString();
        }

        #endregion
    }
}