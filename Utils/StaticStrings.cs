using System;
namespace ShookREST.Util
{
    public class StaticStrings
    {
        // The ConnectionString of the database. The string is set at startup
        // of the application.
        public static string DB_CONNECTION_STRING;

        // The API key that is valid for 24 hours. After 24 hours the
        // APIKeyGenerator should generate a new key.
        public static string API_KEY;
    }
}
