using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain1
{
    public class SecretIdentity
    {
        public int Id { get; set; }
        public string RealName { get; set; }
        public int HeroId { get; set; }
        public Hero Hero { get; set; }
    }
}
