using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace todoleaf
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditTask : ContentPage
	{
        TaskPage TaskPage;
        ObservableCollection<TodoItem> listTasks = new ObservableCollection<TodoItem>();
        ObservableCollection<Category> listCat = new ObservableCollection<Category>();
        List<string> listCategory = new List<string>();
        TodoItem task = new TodoItem();
        public EditTask()
        {
            InitializeComponent();
        }
        public EditTask(ObservableCollection<TodoItem> listTasks, ObservableCollection<Category> listCat, TodoItem task, TaskPage taskPage = null)
        {
            InitializeComponent();
            this.task = task;
            this.listCat = listCat;
            this.listTasks = listTasks;
            TaskPage = taskPage;
            foreach (Category cat in listCat)
            {
                if(!listCategory.Contains(cat.Name))
                {
                    listCategory.Add(cat.Name);
                }
            }
            entText.Text = task.Text;
            pkrCategories.ItemsSource = listCategory;
            pkrCategories.SelectedIndex = listCategory.FindIndex(x => x.StartsWith(this.task.Name));
        }
        /*private void SelectedTask(object sender, ItemTappedEventArgs e)
        {

        }*/
        private void SaveTask_Clicked(object sender, EventArgs e)
        {
            App.Database.DeleteItemAsync(task);
            task = new TodoItem((string)pkrCategories.SelectedItem, entText.Text, 0);
            App.Database.SaveItemAsync(task);
            MessagingCenter.Send(TaskPage, "UpdateList", task.Name);
            Navigation.PopAsync();
        }
        private void DeleteTask_Clicked(object sender, EventArgs e)
        {
            App.Database.DeleteItemAsync(task);
            TaskPage taskPage = new TaskPage(task.Name, listCat);
            MessagingCenter.Send(TaskPage, "UpdateList", task.Name);
            Navigation.PopAsync();
        }
    }
}