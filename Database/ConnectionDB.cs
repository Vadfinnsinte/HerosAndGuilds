using DotNetEnv;
using HerosAndGuilds.UserAndHero;
using MongoDB.Driver;

using System.Threading.Tasks;

namespace HerosAndGuilds.Database
{
    public class ConnectionDB
    {
        public async Task AddUserDB(User newUser)
        {
            try
            {
                Env.Load();

                var connectionString = Environment.GetEnvironmentVariable("MONGO_URI");
                var dbName = Environment.GetEnvironmentVariable("MONGO_DB");

                // Connection
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(dbName);

                // add user
                var collection = database.GetCollection<User>("Users");
                await collection.InsertOneAsync(newUser);
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
    }
}
