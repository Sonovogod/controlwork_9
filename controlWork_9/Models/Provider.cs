namespace controlWork_9.Models;

public class Provider
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<AccountProvider>? Accounts { get; set; }
}