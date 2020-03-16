using System;
using System.Threading;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ShookREST.Util.Authorization
{
    public class APIKeyGenerator
    {
        private readonly Thread _generatorThread = new Thread(
            new ThreadStart(GenerateAndWrite));

        public static DateTime Created { get; private set; }

        public APIKeyGenerator()
        {
            _generatorThread.Start();
        }

        private static void GenerateAndWrite()
        {
            // TODO: Improve loop.
            while (true)
            {
                StaticStrings.API_KEY = GetHash();
                Created = DateTime.Now;
                Thread.Sleep(86400000);
            }
        }

        #region private methods

        private static List<string> GetMacAddresses()
        {
            NetworkInterface[] _networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            List<string> _adapters = new List<string>();

            foreach (NetworkInterface networkInterface in _networkInterfaces)
            {
                _adapters.Add(networkInterface.GetPhysicalAddress().ToString());
            }

            return _adapters;
        }

        private static string GetHash()
        {
            List<string> _macAddresses = GetMacAddresses();

            MD5 provider = MD5.Create();

            string salt = RandomString(12, false); //RANDOM STRING!
            string password = _macAddresses[11];

            byte[] bytes = provider.ComputeHash(Encoding.ASCII.GetBytes(salt + password));

            return BitConverter.ToString(bytes);
        }

        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();

            Random random = new Random();

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