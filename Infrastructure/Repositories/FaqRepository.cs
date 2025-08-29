using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Repositories
{
    public class FaqRepository : IFaqRepository
    {
        private readonly ExamDynamicsDbContext _context;

        public FaqRepository(ExamDynamicsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Faq>> GetAllAsync()
        {
            return await _context.Faqs.ToListAsync();
        }

        public async Task<Faq?> GetByIdAsync(int id)
        {
            return await _context.Faqs.FindAsync(id);
        }

        public async Task AddAsync(Faq faq)
        {
            await _context.Faqs.AddAsync(faq);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Faq faq)
        {
            _context.Faqs.Update(faq);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var faq = await _context.Faqs.FindAsync(id);
            if (faq != null)
            {
                _context.Faqs.Remove(faq);
                await _context.SaveChangesAsync();
            }
        }
    }
}
