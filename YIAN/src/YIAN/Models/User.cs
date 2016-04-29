using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace YIAN.Models
{
    public class User:IdentityUser<long>
    {
        public string Name { get; set; }
    }
}
