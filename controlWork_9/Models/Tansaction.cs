using controlWork_9.Enums.Transaction;

namespace controlWork_9.Models;

public class Tansaction
{
    public int Id { get; set; }
    public DateTime DateOfCreate { get; set; }
    public Detail Detail { get; set; }
    public decimal Summ { get; set; }
    public string AccountOvnerId { get; set; }
    public User AccountOvner { get; set; }
    public int? ProviderId { get; set; }
    public Provider Provider { get; set; }
    public string? UserId { get; set; }
    public User User { get; set; }
}