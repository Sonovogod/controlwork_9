using Microsoft.AspNetCore.Identity;

namespace controlWork_9.Models;

public class User : IdentityUser
{
    public string Avatar { get; set; }
    public decimal Balance { get; set; }
    public DateTime DateOfCreate { get; set; }
}

