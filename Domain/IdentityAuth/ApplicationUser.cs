﻿using Microsoft.AspNetCore.Identity;

namespace Domain.IdentityAuth
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    }
}
