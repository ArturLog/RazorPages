using Application.Repositories.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Classes
{
    public class GameLeasedRepository(IApplicationDbContext context) : ICrudRepository<GameLeased>
    {
        public async Task<GameLeased> Create(GameLeased entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            context.GamesLeased.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<GameLeased?> Read(int id)
        {
            return await context.GamesLeased.FindAsync(id);
        }

        public async Task<List<GameLeased>> ReadAll()
        {
            return await context.GamesLeased.ToListAsync();
        }

        public async Task<bool> Update(GameLeased entity)
        {
            var gameLeased = await context.GamesLeased.FindAsync(entity.Id);
            if (gameLeased is null)
                return false;
            gameLeased.DateFrom = entity.DateFrom;
            gameLeased.DateTo = entity.DateTo;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var gameLeased = await context.GamesLeased.FindAsync(id);
            if (gameLeased is null)
                return false;
            context.GamesLeased.Remove(gameLeased);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
