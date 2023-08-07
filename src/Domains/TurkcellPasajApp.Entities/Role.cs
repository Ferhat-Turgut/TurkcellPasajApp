using Microsoft.AspNetCore.Identity;

namespace TurkcellPasajApp.Entities
{
    public enum Role:int
    {
        Admin,    //RoleId=0
        Seller,   //RoleId=1
        Customer  //RoleId=2
    }
}
