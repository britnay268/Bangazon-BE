using Bangazon_BE.Models;
namespace Bangazon_BE.Data;

public class UserData
{
    public static List<Users> Users = new List<Users>
    {
        new Users
        {
            Id = 1,
            Username = "bgore268",
            Email = "",
            Uid = "",
            Seller = false
        },
         new Users
        {
            Id = 2,
            Username = "brianagore",
            Email = "",
            Uid = "",
            Seller = true
        },
    };
}
