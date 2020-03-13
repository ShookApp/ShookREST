using System;
using System.Threading;

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
                // TODO: Add method to generate a super secret key.
                StaticStrings.API_KEY = "SuperSecretAPIKey";
                Created = DateTime.Now;
                Thread.Sleep(86400000);
            } 
        }
    }
}