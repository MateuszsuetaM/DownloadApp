using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DownloadApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the UserIdentity class
public class UserIdentity : IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
}

