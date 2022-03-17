using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Inforvet.Areas.Identity.Data;

// Add profile data for application users by adding properties to the InforvetUser class
public class InforvetUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NIF { get; set; }
}

