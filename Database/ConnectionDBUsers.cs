using DotNetEnv;
using HerosAndGuilds.UserAndHero;
using MongoDB.Driver;

using System.Threading.Tasks;

namespace HerosAndGuilds.Database
{
    public class ConnectionDBUsers
    {
            private readonly string connectionString;
            private readonly string dbName;
            private readonly IMongoCollection<User> userCollection;

            // Konstruktor körs när objektet skapas
            public ConnectionDBUsers()
            {
                // Ladda miljövariabler från .env (om du använder en sådan)
                Env.Load();

                // Hämta variabler
                connectionString = Environment.GetEnvironmentVariable("MONGO_URI");
                dbName = Environment.GetEnvironmentVariable("MONGO_DB");

                // Anslut till databasen
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(dbName);

                // Hämta "Users"-kollektionen
                userCollection = database.GetCollection<User>("Users");
            }
            public async Task AddUserDB(User newUser)
        {
            try
            {
              
                await userCollection.InsertOneAsync(newUser);
            }
            catch (MongoException ex)
            {
                Console.WriteLine("Ett fel uppstod vid MongoDB-anslutning: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ett oväntat fel inträffade: " + ex.Message);
            }
        }

        public async Task<List<User>> FetchUsers()
        {
            try
            {
                return await userCollection.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid hämtning av användare: " + ex.Message);
                return new List<User>();
            }
        }
    }
}
