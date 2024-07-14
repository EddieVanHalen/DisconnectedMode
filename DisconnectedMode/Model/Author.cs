namespace DisconnectedMode.Model;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }
}