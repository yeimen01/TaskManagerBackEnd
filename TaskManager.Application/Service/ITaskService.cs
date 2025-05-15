using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.Service
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetallAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task<TaskItem> CreateAsync(TaskItem item);
        Task<bool> UpdateAsync(TaskItem item);
        Task<bool> DeleteAsyn(int id);
    }
}
