using EBPN_Network.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBPN_Network.Services
{
    public class UserDAO
    {
        private readonly IMongoCollection<User> _users;

        // Constructor that initializes the MongoDB collection
        public UserDAO(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("users");
        }

        // Create a new user
        public async Task CreateUserAsync(User user)
        {
            user.CreatedAt = DateTime.UtcNow;
            await _users.InsertOneAsync(user);
        }

        // Retrieve a user by their unique identifier (Id)
        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        // Update an existing user
        public async Task UpdateUserAsync(User user)
        {
            user.UpdatedAt = DateTime.UtcNow;
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            await _users.ReplaceOneAsync(filter, user);
        }

        // Delete a user by their unique identifier
        public async Task DeleteUserAsync(string id)
        {
            await _users.DeleteOneAsync(u => u.Id == id);
        }

        // Retrieve all users
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _users.Find(_ => true).ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            // Define the filter to find the user by email
            var filter = Builders<User>.Filter.Eq(u => u.Email, email);

            // Query the database to find the user
            var user = await _users.Find(filter).FirstOrDefaultAsync();

            return user;  // Returns null if no user is found
        }
    }
}
