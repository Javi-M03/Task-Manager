using System;
using System.Collections.Generic;
using System.Text;
using Task_Manager.Domain.Entities;
using Task_Manager.Domain.Interfaces;
using Task_Manager.DTOs;

namespace Task_Manager.Services
{
    public class TaskItemService
    {
        private readonly ITaskItemRepository _repo;
        public TaskItemService(ITaskItemRepository repo) => _repo = repo;

        public async Task<List<GetTaskItemDto>> GetAllAsync()
        {
            var task = await _repo.GetAllAsync();
            return task.Select(MapToDto).ToList();
        }

        public async Task<GetTaskItemDto?> GetByIdAsync(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            return task is null ? null : MapToDto(task);
        }

        public async Task<GetTaskItemDto> CreateAsync(CreateTaskItemDto dto)
        {
            var task = new TaskItem(dto.Title,dto.Description);
            await _repo.AddAsync(task);
            await _repo.SaveChangesAsync();
            return MapToDto(task);
        }

        public async Task<bool> UpdateAsync(int id, UpdateTaskItemDto dto)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task is null) return false;
            task.SetTitle(dto.Title);
            if (dto.IsDone) task.Done(); else task.Undone();
            _repo.Update(task);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task is null) return false;

            _repo.Delete(task);
            await _repo.SaveChangesAsync();
            return true;
        }

        private static GetTaskItemDto MapToDto(TaskItem t) => new()
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            IsDone = t.IsDone,
            CreatedAt = t.CreatedAt,
            ModifiedAt = t.ModifiedAt,
        };
    }
}
