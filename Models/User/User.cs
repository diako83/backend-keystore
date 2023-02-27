using backend_keystore.Models.Receipts;


namespace backend_keystore.Models.User;

public class User
{
 public string Id { get; set; } = string.Empty;
 public string Username { get; set; } = string.Empty;
 public byte[] PasswordHash { get; set; } = new byte[0];
 public byte[] PasswordSalt { get; set; } = new byte[0];
 public List<Receipt>? Receipts { get; set; }
}