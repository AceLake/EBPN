using Google.Cloud.Firestore;
using System.Threading.Tasks;
using EBPN_Network.Models;

public class UserDAO
{
    private readonly FirestoreDb _firestoreDb;
    private readonly string _collectionName = "users"; // The name of your Firestore collection

    public UserDAO(FirestoreDb firestoreDb)
    {
        _firestoreDb = firestoreDb;
    }

    public UserDAO()
    {
    }

    // Create a new user
    public async Task Create(User user)
    {
        DocumentReference docRef = _firestoreDb.Collection(_collectionName).Document(user.Id);
        await docRef.SetAsync(user);
    }

    // Get user by ID
    public async Task<User> GetById(string id)
    {
        DocumentReference docRef = _firestoreDb.Collection(_collectionName).Document(id);
        DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
        if (snapshot.Exists)
        {
            return snapshot.ConvertTo<User>();
        }
        return null;
    }

    // Get user by email and password
    public async Task<User> GetByEmailAndPassword(string email, string password)
    {
        QuerySnapshot snapshot = await _firestoreDb.Collection(_collectionName)
            .WhereEqualTo("Email", email)
            .WhereEqualTo("Password", password)
            .GetSnapshotAsync();

        if (snapshot.Documents.Count > 0)
        {
            return snapshot.Documents[0].ConvertTo<User>();
        }
        return null;
    }

    // Update user
    public async Task Update(string id, User updatedUser)
    {
        DocumentReference docRef = _firestoreDb.Collection(_collectionName).Document(id);
        await docRef.SetAsync(updatedUser, SetOptions.MergeAll);
    }

    // Delete user
    public async Task Delete(string id)
    {
        DocumentReference docRef = _firestoreDb.Collection(_collectionName).Document(id);
        await docRef.DeleteAsync();
    }
}
