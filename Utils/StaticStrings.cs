using System;
namespace ShookREST.Utils
{
    /// <summary>
    /// This class saves important strings.
    /// </summary>
    public static class StaticStrings
    {
        /// <summary>
        /// The ConnectionString of the database. The string is set at startup of the application.
        /// </summary>
        public static string DbConnectionString;

        /// <summary>
        /// The API key that is valid for 24 hours. After 24 hours the APIKeyGenerator should generate a new key.
        /// </summary>
        public static string ApiKey;
    }
}
