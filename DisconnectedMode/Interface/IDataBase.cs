using System.Collections;
using System.Data;
using DisconnectedMode.Model;

namespace DisconnectedMode.Interface;

public interface IDataBase
{
    Task<IList<Author>> GetAllAuthorsAsync();
    Task<DataTable?> GetAllAuthorsBooksAsync(int authorId);
}