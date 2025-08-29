using ExamDynamicsAPI.Core.DTOs.FaqDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services

{
    public class FaqService : IFaqService
    {
        private readonly IFaqRepository _faqRepository;

        public FaqService(IFaqRepository faqRepository)
        {
            _faqRepository = faqRepository;
        }

        public async Task<IEnumerable<FaqDto>> GetAllAsync()
        {
            var faqs = await _faqRepository.GetAllAsync();
            return faqs.Select(f => new FaqDto
            {
                FaqId = f.FaqId, 
                Question = f.Question,
                Answer = f.Answer
            }).ToList();
        }

        public async Task<FaqDto?> GetByIdAsync(int id)
        {
            var faq = await _faqRepository.GetByIdAsync(id);
            if (faq == null) return null;

            return new FaqDto
            {
                FaqId = faq.FaqId,
                Question = faq.Question,
                Answer = faq.Answer
            };
        }

        public async Task<FaqDto> CreateAsync(FaqDto faqDto)
        {
            var faq = new Faq
            {
                Question = faqDto.Question,
                Answer = faqDto.Answer
            };

            await _faqRepository.AddAsync(faq);

            faqDto.FaqId = faq.FaqId;
            return faqDto;
        }

        public async Task<FaqDto?> UpdateAsync(int id, FaqDto faqDto)
        {
            var faq = await _faqRepository.GetByIdAsync(id);
            if (faq == null) return null;

            faq.Question = faqDto.Question;
            faq.Answer = faqDto.Answer;

            await _faqRepository.UpdateAsync(faq);

            return faqDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var faq = await _faqRepository.GetByIdAsync(id);
            if (faq == null) return false;

            await _faqRepository.DeleteAsync(id);
            return true;
        }
    }
}
