using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly ExamDynamicsDbContext _context;

        public BookmarkRepository(ExamDynamicsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Bookmark>> GetAllAsync()
        {
            return await _context.Bookmarks.ToListAsync();
        }

        public async Task<Bookmark?> GetByIdAsync(int id)
        {
            return await _context.Bookmarks.FindAsync(id);
        }

        public async Task AddAsync(Bookmark bookmark)
        {
            await _context.Bookmarks.AddAsync(bookmark);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bookmark bookmark)
        {
            _context.Bookmarks.Update(bookmark);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Bookmark bookmark)
        {
            _context.Bookmarks.Remove(bookmark);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bookmark>> GetByUserIdAsync(int userId)
        {
            return await _context.Bookmarks
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }
    }
}
