using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using ToDoApp.Core;
using ToDoApp.Data;
using ToDoApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDoApp.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Windows.Data;
using Microsoft.VisualBasic;

namespace ToDoApp.ViewModel
{
    class WorkTaskViewModel : BaseViewModel
    {
        // TODO zapis zadań do pliku 
        // Dodanie serwisów 
        // Dodanie Dto
        // Dodanie pola opisu zadania 
        // podkreślenie zadań zrealizowanych 
        // widok wczytywania danych

        private WorkTask Model { get; set; } = new WorkTask();
        private WorkTaskDbContext DbContext { get; set; } = new WorkTaskDbContext();
        public ObservableCollection<WorkTask> Tasks { get; set; } = new ObservableCollection<WorkTask>();
        private readonly ITaskSerive _taskService;

        public WorkTaskViewModel()
        {
            AddTaskCommand = new RelayCommand(AddTask);
            ShowTaskCommand = new RelayCommand(ShowTask);
            UpdateTaskCommand = new RelayCommand(UpdateTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask);
            ShowAllTasksCommand = new RelayCommand(ShowAllTasks);
            ClearTasksCommand = new RelayCommand((object e) => Tasks.Clear());
            _taskService = new TaskService(DbContext);
        }

        public ICommand AddTaskCommand { get; set; }
        public ICommand ShowTaskCommand { get; set; }
        public ICommand UpdateTaskCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }
        public ICommand ShowAllTasksCommand { get; set; }
        public ICommand ClearTasksCommand { get; set; }

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
            get => Model.Name!;
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

        public bool IsDone
        {
            get => Model.IsDone;
            set
            {
                Model.IsDone = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }
   
        public async void ShowTask(object e)
        {
            await CheckUpcomingTasks();
            await RefreshTaskList();
        }

        public async void ShowAllTasks(object e)
        {
            Tasks.Clear();
            var result = await _taskService.GetAllTasks();

            foreach (var item in result)
            {
                Tasks.Add(item);
            }
        }

        public async Task RefreshTaskList()
        {
            if (DbContext.Database.CanConnect())
            {
                Tasks.Clear();
                var list = await DbContext.WorkTasks.ToListAsync();
                foreach (var task in list.Where(x => x.AddDateTime.CompareTo(AddDateTime) == 0))
                    Tasks.Add(task);
            }
            else
                MessageBox.Show("Can`t connect to database!");
        }

        public async Task CheckUpcomingTasks()
        {
            if (DbContext.Database.CanConnect())
            {
                var currentDate = DateTime.Today;
                var list = await DbContext.WorkTasks.ToListAsync();
                var UpcomingTasks = list.Where(x => x.AddDateTime.CompareTo(currentDate) == 0);

                MessageBox.Show($"Number of upcoming tasks: {UpcomingTasks.Count()}");
            }
            else
                MessageBox.Show("Can`t connect to database!");
        }

        public async void AddTask(object e)
        {
            await _taskService.CreateTask(Name, AddDateTime);
            await RefreshTaskList();
            Name = string.Empty;
        }

        public async void UpdateTask(object e)
        {
            await _taskService.UpdateTask(e, Name, AddDateTime);
            await RefreshTaskList();
            Name = string.Empty;
        }

        public async void DeleteTask(object e)
        {
            await _taskService.RemoveTask(e);
            await RefreshTaskList();
        }
    }
}
