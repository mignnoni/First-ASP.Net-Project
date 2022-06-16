using EFCore.Domain1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo1
{
    public interface IEFCoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangeAsync();

        Task<Hero[]> GetAllHeroes();
        Task<Hero> GetHeroById(int id);
        Task<Hero> GetHeroByName(string name);

        Task<Battle[]> GetAllBattles();
        Task<Battle> GetBattleById(int id);

    }
}
