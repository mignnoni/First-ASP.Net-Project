using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain1
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SecretIdentity SecretIdentity { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<HeroBattle> HeroesBattles { get; set; }

        public static implicit operator Task<object>(Hero v)
        {
            throw new NotImplementedException();
        }
    }
}
