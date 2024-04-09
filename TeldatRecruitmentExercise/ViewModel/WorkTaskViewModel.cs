
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Input;
using TeldatRecruitmentExercise.Core;
using TeldatRecruitmentExercise.Data;
using TeldatRecruitmentExercise.Models;

namespace TeldatRecruitmentExercise.ViewModel
{
    class WorkTaskViewModel : BaseModel
    {
        private WorkTask Model { get; set; } = new WorkTask();
        private WorkTaskDbContext DbContext { get; set; }
        private ObservableCollection<WorkTask> Tasks { get; set; }  = new ObservableCollection<WorkTask>();

        public WorkTaskViewModel()
        {
            DbContext = new WorkTaskDbContext();
            AddTaskCommand = new RelayCommand(AddTask);
            ShowTaskCommand = new RelayCommand(ShowTask);
            UpdateTaskCommand = new RelayCommand(UpdateTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask);
            ShowAllTasksCommand = new RelayCommand(ShowAllTasks);
        }

        public ICommand AddTaskCommand {  get; set; }
        public ICommand ShowTaskCommand { get; set; }
        public ICommand UpdateTaskCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }
        public ICommand ShowAllTasksCommand { get; set; }

        public ObservableCollection<WorkTask> TasksList
        {
            get => Tasks;
            set
            {
                Tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public string Name
        {
            get => Model.Name;
            set
            {
                Model.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public DateTime AddDateTime
        {
            get => Model.AddDateTime;
            set
            {
                Model.AddDateTime = value;
                OnPropertyChanged(nameof(AddDateTime));
            }
        }

        public async void ShowTask(object e)
        {
            await CheckUpcomingTasks();
            await RefreshTaskList();
        }

        public async void ShowAllTasks(object e) 
        {
            TasksList.Clear();
            var list = await DbContext.WorkTasks.ToListAsync();
            foreach (var task in list)
                Tasks.Add(task);
        }

        public async Task RefreshTaskList()
        {
            TasksList.Clear();
            var list = await DbContext.WorkTasks.ToListAsync();
            foreach (var task in list.Where(x => x.AddDateTime.CompareTo(AddDateTime) == 0))
                Tasks.Add(task);
        }

        public async Task CheckUpcomingTasks()
        {
            var currentDate = DateTime.Today;
            var list = await DbContext.WorkTasks.ToListAsync();
            var UpcomingTasks = list.Where(x => x.AddDateTime.CompareTo(currentDate) == 0);

            MessageBox.Show($"Number of upcoming tasks: {UpcomingTasks.Count()}");
        }

        public async void AddTask(object e)
        {
            if (Name != null)
            {
                DbContext.WorkTasks.Add(new WorkTask()
                {
                    Name = Name,
                    AddDateTime = AddDateTime
                });
                await DbContext.SaveChangesAsync();
                await RefreshTaskList();
            }
            else
                MessageBox.Show("Insert Name to add element!");
        }

        public async void UpdateTask(object e)
        {      
            if (Name != null)
            {
                WorkTask? tsk = e as WorkTask;
                var list = await DbContext.WorkTasks.ToListAsync();
                if (tsk != null)
                {
                    var task = list.FirstOrDefault(x => x.Id == tsk.Id);

                    if (task != null)
                    {
                        task.Name = Name;
                        task.AddDateTime = AddDateTime;
                        await DbContext.SaveChangesAsync();
                        await RefreshTaskList();
                    }
                }
            }
            else
                MessageBox.Show("Insert Name to update element!");
        }

        public async void DeleteTask(object e) 
        {
            WorkTask? tsk = e as WorkTask;
            var list = await DbContext.WorkTasks.ToListAsync();
            if (tsk != null)
            {
                var task = list.FirstOrDefault(x => x.Id == tsk.Id);

                if (task != null)
                {
                    DbContext.WorkTasks.Remove(task);
                    await DbContext.SaveChangesAsync();
                    await RefreshTaskList();
                    MessageBox.Show("Element Deleted!");
                }
            }
        }
    }
}
