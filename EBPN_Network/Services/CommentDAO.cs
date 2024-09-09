using EBPN_Network.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

public class CommentDAO
{
    private readonly IMongoCollection<Comment> _comments;

    public CommentDAO()
    {
        var client = new MongoClient("your-mongo-db-connection-string");
        var database = client.GetDatabase("OutreachAppDB");
        _comments = database.GetCollection<Comment>("comments");
    }

    // Create a new comment
    public async Task Create(Comment comment)
    {
        await _comments.InsertOneAsync(comment);
    }

    // Get comment by ID
    public Comment GetById(string id)
    {
        var filter = Builders<Comment>.Filter.Eq(c => c.CommentID, id);
        return _comments.Find(filter).FirstOrDefault();
    }

    // Get comments for a specific request
    public async Task<List<Comment>> GetByRequestId(string requestId)
    {
        var filter = Builders<Comment>.Filter.Eq(c => c.RequestID, requestId);
        return await _comments.Find(filter).ToListAsync();
    }

    // Delete comment
    public void Delete(string id)
    {
        var filter = Builders<Comment>.Filter.Eq(c => c.CommentID, id);
        _comments.DeleteOne(filter);
    }
}
