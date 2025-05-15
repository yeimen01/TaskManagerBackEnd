using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Service;
using TaskManager.Domain;

namespace TaskManager.Infraestructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetallAsync()
        {
            var data = await _context.Task.ToListAsync();
            return data;
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.Task.FindAsync(id);
        }

        public async Task<TaskItem> CreateAsync(TaskItem task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
            {
                throw new ArgumentException("El titulo es requerido.");
            }

            if(task.DueDate < DateTime.Today)
            {
                throw new ArgumentException("La fecha no puede ser menor a la fecha de hoy.");
            }

            _context.Task.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<bool> DeleteAsyn(int id)
        {
            var task = await _context.Task.FindAsync(id);

            if (task == null) return false;

            _context.Task.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> UpdateAsync(TaskItem task)
        {
            if (!_context.Task.Any(t => t.Id == task.Id)) return false;

            _context.Task.Update(task);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
