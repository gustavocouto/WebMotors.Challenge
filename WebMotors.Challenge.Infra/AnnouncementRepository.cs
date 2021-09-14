using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.Challenge.Domain.Interfaces.Repositories;
using WebMotors.Challenge.Domain.Models;
using WebMotors.Challenge.Infra.Context;

namespace WebMotors.Challenge.Infra
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly WebMotorsChallengeContext _context;
        private readonly DbSet<Announcement> _dbSet;

        public AnnouncementRepository(WebMotorsChallengeContext context)
        {
            _context = context;
            _dbSet = context.Set<Announcement>();
        }

        public async Task Create(Announcement announcement)
        {
            _dbSet.Add(announcement);
            await _context.SaveChangesAsync();
        }

        public async Task<Announcement> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<List<Announcement>> GetAll()
        {
            return _dbSet.ToListAsync();
        }

        public async Task Remove(int id)
        {
            var target = await Get(id);
            _dbSet.Remove(target);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Announcement announcement)
        {
            _context.Entry(announcement).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}