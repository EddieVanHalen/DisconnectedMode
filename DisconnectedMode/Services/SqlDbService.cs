using System.Data;
using System.Data.SqlClient;
using DisconnectedMode.Interface;
using DisconnectedMode.Model;
using System.Linq;

namespace DisconnectedMode.Services;

public class SqlDbService : IDataBase
{
    private SqlConnection _connection;
    private SqlCommandBuilder _builder = new SqlCommandBuilder();

    public SqlDbService(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
    }

    public async Task<IList<Author>> GetAllAuthorsAsync()
    {
        IList<Author> authors = new List<Author>();

        try
        {
            var dataSet = new DataSet();
            var query = "SELECT * FROM Authors";
            var adapter = new SqlDataAdapter(query, _connection);
            _builder.DataAdapter = adapter;
            adapter.Fill(dataSet, "Authors");
            var temp = dataSet.Tables["Authors"]!;

            foreach (DataRow row in temp.Rows)
            {
                var temp_author = new Author
                {
                    Id = (int)row["Id"],
                    FirstName = row["FirstName"].ToString()!,
                    LastName = row["LastName"].ToString()!
                };

                authors.Add(temp_author);
            }
        }
        catch (Exception e)
        {
            return authors;
        }

        return authors;
    }

    public async Task<DataTable?> GetAllAuthorsBooksAsync(int authorId)
    {
        try
        {
            var dataSet = new DataSet();
            var query = "SELECT * FROM Books WHERE Id_Author = @idAuthor";
            var command = new SqlCommand(query, _connection);
            command.Parameters.Add("idAuthor", SqlDbType.Int).Value = authorId;
            var adapter = new SqlDataAdapter(command);
            _builder.DataAdapter = adapter;
            adapter.Fill(dataSet, "Books");
            return dataSet.Tables["Books"]!;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}