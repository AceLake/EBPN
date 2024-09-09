using EBPN_Network.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

public class UserDAO
{
    private readonly IMongoCollection<User> _users;

    public UserDAO()
    {
        var client = new MongoClient("mongodb+srv://Ace:squirty115@cluster0.og5dfyn.mongodb.net/?retryWrites=true&w=majority");
        var database = client.GetDatabase("EBPN");
        _users = database.GetCollection<User>("users");
    }

    // Create a new user
    public async Task Create(User user)
    {
        await _users.InsertOneAsync(user);
    }

    // Get user by ID
    public User GetById(string id)
    {
        var filter = Builders<User>.Filter.Eq(u => u.UserID, id);
        return _users.Find(filter).FirstOrDefault();
    }

    // Get user by email and password
    public User GetByEmailAndPassword(string email, string password)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Email, email) &
                     Builders<User>.Filter.Eq(u => u.PasswordHash, password);
        return _users.Find(filter).FirstOrDefault();
    }

    // Update user
    public void Update(string id, User updatedUser)
    {
        var filter = Builders<User>.Filter.Eq(u => u.UserID, id);
        _users.ReplaceOne(filter, updatedUser);
    }

    // Delete user
    public void Delete(string id)
    {
        var filter = Builders<User>.Filter.Eq(u => u.UserID, id);
        _users.DeleteOne(filter);
    }
}
