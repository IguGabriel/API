using Microsoft.AspNetCore.Identity;

namespace RO.DevTest.Domain.Entities
{
    public class User : IdentityUser
    {
        
        
        public string UserName { get; set; } 
        public string Name { get; set; }    
        public string Role { get; set; }     

        
    }
}
