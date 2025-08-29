using AutoMapper;
using ExamDynamicsAPI.Core.DTOs.BookmarkDTOs;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamDynamicsAPI.Applications.Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IBookmarkRepository _repository;
        private readonly IMapper _mapper;

        public BookmarkService(IBookmarkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookmarkDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookmarkDto>>(entities);
        }

        public async Task<BookmarkDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<BookmarkDto?>(entity);
        }

        public async Task<BookmarkDto> CreateAsync(CreateBookmarkDto dto)
        {
            var entity = _mapper.Map<Bookmark>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<BookmarkDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateBookmarkDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<BookmarkDto>> GetByUserIdAsync(int userId)
        {
            var entities = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<BookmarkDto>>(entities);
        }
    }
}
