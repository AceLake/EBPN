using EBPN_Network.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

public class OutreachRequestDAO
{
    private readonly IMongoCollection<OutreachRequest> _outreachRequests;

    public OutreachRequestDAO()
    {
        var client = new MongoClient("mongodb+srv://Ace:squirty115@cluster0.og5dfyn.mongodb.net/?retryWrites=true&w=majority");
        var database = client.GetDatabase("OutreachAppDB");
        _outreachRequests = database.GetCollection<OutreachRequest>("outreachRequests");
    }

    // Create a new request
    public async Task Create(OutreachRequest request)
    {
        await _outreachRequests.InsertOneAsync(request);
    }

    // Get request by ID
    public OutreachRequest GetById(string id)
    {
        var filter = Builders<OutreachRequest>.Filter.Eq(r => r.RequestID, id);
        return _outreachRequests.Find(filter).FirstOrDefault();
    }

    // Get all requests
    public async Task<List<OutreachRequest>> GetAll()
    {
        return await _outreachRequests.Find(_ => true).ToListAsync();
    }

    // Update request
    public void Update(string id, OutreachRequest updatedRequest)
    {
        var filter = Builders<OutreachRequest>.Filter.Eq(r => r.RequestID, id);
        _outreachRequests.ReplaceOne(filter, updatedRequest);
    }

    // Delete request
    public void Delete(string id)
    {
        var filter = Builders<OutreachRequest>.Filter.Eq(r => r.RequestID, id);
        _outreachRequests.DeleteOne(filter);
    }
}
