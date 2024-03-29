namespace FitnessApp.Domain.Entities;

public class User
{
    public User(Guid id, string username, string hashedPassword, string email, Role role)
    {
        Id = id;
        Username = username;
        PasswordHashed = hashedPassword;
        Email = email;
        Role = role;
    }
    public User() { }

    public Guid Id { get; set; }
    public Role Role { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHashed { get; set; }

    public static User Create(Guid id, string username, string hashedPassword, string email, Role role)
    {
        return new User(id, username, hashedPassword, email, role);
    }
}
