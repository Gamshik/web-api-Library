using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Jwt
    {
        public string? Token { get; set; }
        public List<Claim> Claims { get; set; }
    }
}
