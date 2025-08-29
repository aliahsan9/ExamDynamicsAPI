using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.QuizDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;

namespace ExamDynamicsAPI.Applications.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IMapper _mapper;

        public QuizService(IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuizDto>> GetAllQuizzesAsync()
        {
            var quizzes = await _quizRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<QuizDto>>(quizzes);
        }

        public async Task<QuizDto?> GetQuizByIdAsync(int id)
        {
            var quiz = await _quizRepository.GetByIdAsync(id);
            return quiz == null ? null : _mapper.Map<QuizDto>(quiz);
        }

        public async Task<QuizDto> CreateQuizAsync(QuizCreateDto createDto)
        {
            var quiz = _mapper.Map<Quiz>(createDto);
            var createdQuiz = await _quizRepository.AddAsync(quiz);
            return _mapper.Map<QuizDto>(createdQuiz);
        }

        public async Task<QuizDto?> UpdateQuizAsync(int id, QuizUpdateDto updateDto)
        {
            var existingQuiz = await _quizRepository.GetByIdAsync(id);
            if (existingQuiz == null) return null;

            _mapper.Map(updateDto, existingQuiz);
            var updatedQuiz = await _quizRepository.UpdateAsync(existingQuiz);
            return _mapper.Map<QuizDto>(updatedQuiz);
        }

        public async Task<bool> DeleteQuizAsync(int id)
        {
            return await _quizRepository.DeleteAsync(id);
        }
    }
}
