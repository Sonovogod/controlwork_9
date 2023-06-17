namespace controlWork_9.Models;

public class AccountProvider
{
    public int Id { get; set; }
    public string Account { get; set; }
    public decimal Balance { get; set; }
    public int ProviderId { get; set; }
    public Provider Provider { get; set; }
}