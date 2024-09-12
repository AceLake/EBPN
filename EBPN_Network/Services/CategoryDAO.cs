using EBPN_Network.Models;
using MongoDB.Driver;

namespace EBPN_Network.Services
{
    public class CategoryDAO
    {
        private readonly IMongoCollection<Category> _categories;

        public CategoryDAO()
        {
            var client = new MongoClient("mongodb+srv://Ace:squirty115@cluster0.og5dfyn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("OutreachAppDB");
            _categories = database.GetCollection<Category>("categories");
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categories.Find(_ => true).ToListAsync();
        }

        public async Task Create(Category request)
        {

            await _categories.InsertOneAsync(request);
        }

        public void Update(string id, Category updatedRequest)
        {
            var filter = Builders<Category>.Filter.Eq(r => r.CategoryID, id);
            _categories.ReplaceOne(filter, updatedRequest);
        }

        public void Delete(string id)
        {
            var filter = Builders<Category>.Filter.Eq(r => r.CategoryID, id);
            _categories.DeleteOne(filter);
        }


    }

}
