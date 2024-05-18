
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using ToDoApp.Data;
using ToDoApp.Model;

namespace ToDoApp.Services
{
    public interface ITaskSerive
    {
        public Task<IEnumerable<WorkTask>> GetAllTasks();
        public Task UpdateTask(object e, string Name, DateTime AddDateTime);
        public Task CreateTask(string Name, DateTime AddDateTime);
        public Task RemoveTask(object e);
    }

    public class TaskService : ITaskSerive
    {
        private readonly WorkTaskDbContext _dbContext;


        public TaskService(WorkTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTask(string Name, DateTime AddDateTime)
        {
            if (_dbContext.Database.CanConnect())
            {
                if (Name != null)
                {
                    _dbContext.WorkTasks.Add(new WorkTask()
                    {
                        Name = Name,
                        AddDateTime = AddDateTime
                    });
                    await _dbContext.SaveChangesAsync();
                }
                else
                    MessageBox.Show("Insert Name to add element!");
            }
            else
                MessageBox.Show("Can`t connect to database!");
        }

        public async Task<IEnumerable<WorkTask>> GetAllTasks()
        {
            var canConnect = await _dbContext.Database.CanConnectAsync();

            if (canConnect)                        
                return await _dbContext.WorkTasks.ToListAsync();

            MessageBox.Show("Can`t connect to database!");
            return Enumerable.Empty<WorkTask>();
        }

        public async Task RemoveTask(object e)
        {
            if (_dbContext.Database.CanConnect())
            {
                WorkTask? tsk = e as WorkTask;
                var list = await _dbContext.WorkTasks.ToListAsync();
                if (tsk != null)
                {
                    var task = list.FirstOrDefault(x => x.Id == tsk.Id);

                    if (task != null)
                    {
                        _dbContext.WorkTasks.Remove(task);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
            else
                MessageBox.Show("Can`t connect to database!");
        }

        public async Task UpdateTask(object e, string Name, DateTime AddDateTime)
        {
            // sprawdzenie czy zmienione został description lub isdone lub

            if (_dbContext.Database.CanConnect())
            {
                if (Name != null)
                {
                    WorkTask? tsk = e as WorkTask;
                    var list = await _dbContext.WorkTasks.ToListAsync();
                    if (tsk != null)
                    {
                        var task = list.FirstOrDefault(x => x.Id == tsk.Id);

                        if (task != null)
                        {
                            task.Name = Name;
                            task.AddDateTime = AddDateTime;
                            task.IsDone = tsk.IsDone;
                            await _dbContext.SaveChangesAsync();

                        }
                    }
                }
                else
                    MessageBox.Show("Insert Name to update element!");
            }
            else
                MessageBox.Show("Can`t connect to database!");
        }
    }
}
