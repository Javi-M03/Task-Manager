using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Task_Manager.Domain.Entities;
using Task_Manager.Domain.Interfaces;
using Task_Manager.DTOs;
using Task_Manager.Services;

namespace TaskManager.UnitTests
{
    public class TaskItemServiceTest
    {
        private readonly Mock<ITaskItemRepository> _repoMock;
        private readonly TaskItemService _service;

        public TaskItemServiceTest()
        {
            _repoMock = new Mock<ITaskItemRepository>();
            _service = new TaskItemService(_repoMock.Object);
        }

        [Fact]
        public async Task CreateAsyncTitleTest()
        {
            var dto = new CreateTaskItemDto { Title = "Test 1", Description = "" };

            var result = await _service.CreateAsync(dto);

            Assert.Equal("Test 1", result.Title);
            _repoMock.Verify(r => r.AddAsync(It.IsAny<TaskItem>()), Times.Once);
            _repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsyncNullTest()
        {
            _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((TaskItem?)null);

            var result = await _service.GetByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteAsyncFailTest()
        {
            _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((TaskItem?)null);

            var result = await _service.DeleteAsync(999);

            Assert.False(result);
            _repoMock.Verify(r => r.Delete(It.IsAny<TaskItem>()), Times.Never);
        }
    }
}
