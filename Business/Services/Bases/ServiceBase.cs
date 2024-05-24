using DataAccess.Contexts;

namespace Business.Services.Bases
{
    public abstract class ServiceBase // all services will inherit from this abstract class, therefore Db object injection can be easily made
    {
        protected readonly Db _db; // we set protected as the accessibility modifier, so we can use this field in the inherited service classes

        protected ServiceBase(Db db) // DbContext object constructor injection
        {
            _db = db;
        }
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}