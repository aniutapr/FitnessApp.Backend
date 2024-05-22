namespace FitnessApp.Domain.Entities;

public class User
{
    public User(Guid id, string username, string hashedPassword, string email)
    {
        Id = id;
        Username = username;
        PasswordHashed = hashedPassword;
        Email = email;
    }
    public User() { }

    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHashed { get; set; }

    public static User Create(Guid id, string username, string hashedPassword, string email)
    {
        return new User(id, username, hashedPassword, email);
    }
}
