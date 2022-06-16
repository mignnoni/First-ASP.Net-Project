using EFCore.Domain1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo1
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly HeroContext _context;

        public EFCoreRepository(HeroContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {

            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Hero[]> GetAllHeroes()
        {
            IQueryable<Hero> query = _context.Heroes
                .Include(h => h.SecretIdentity)
                .Include(h => h.Weapons);

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }


        public async Task<Hero> GetHeroById(int id)
        {
            IQueryable<Hero> hero = _context.Heroes.Where(h => h.Id == id)
                             .Include(h => h.Weapons).Include(h => h.SecretIdentity);
            hero = hero.AsNoTracking();
            if (hero != null)
            {
                return await hero.FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<Hero> GetHeroByName(string name)
        {
            IQueryable<Hero> hero = _context.Heroes.Where(h => h.Name.Contains(name))
                 .Include(h => h.Weapons).Include(h => h.SecretIdentity);
            hero = hero.AsNoTracking();
            if (hero != null)
            {
                return await hero.FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<Battle[]> GetAllBattles()
        {
            IQueryable<Battle> battlesQuery = _context.Battles;

            battlesQuery = battlesQuery.AsNoTracking().OrderBy(b => b.Id);

            return await battlesQuery.ToArrayAsync();
        }

        public async Task<Battle> GetBattleById(int id)
        {
            IQueryable<Battle> battle = _context.Battles.Where(b => b.Id == id);
            battle = battle.AsNoTracking();
            if (battle != null)
            {
                return await battle.FirstOrDefaultAsync();
            }

            return null;
        }
    }
}
