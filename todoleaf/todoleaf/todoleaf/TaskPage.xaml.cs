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
	public partial class TaskPage : ContentPage
	{
        ObservableCollection<Category> listCategory = new ObservableCollection<Category>();
        ObservableCollection<TodoItem> listTasks = new ObservableCollection<TodoItem>();
        TodoItem selectItem = new TodoItem();
        protected override void OnAppearing()
        {
            base.OnAppearing();
            QueryList(App.Query);
        }
        public TaskPage()
		{
			InitializeComponent();
        }
        public TaskPage(string title, ObservableCollection<Category> listCat)
        {
            InitializeComponent();
            this.Title = title;
            this.listCategory = listCat;
            //TodoItem task = new TodoItem("Kat 2", "Ahoj Svete 4", 0);
            //App.Database.SaveItemAsync(task);
            //App.Database.DeleteAllAsync();

            listViewTasks.ItemsSource = listTasks;
        }
        private void SelectedTask(object sender, ItemTappedEventArgs e)
        {
            var task = (TodoItem)listViewTasks.SelectedItem;
            EditTask editTask = new EditTask(listTasks, listCategory, task);
            //listViewTasks.SelectedItem = null;
            Navigation.PushAsync(editTask);
        }
        private void AddTask_Clicked(object sender, EventArgs e)
        {
            EditTask editTask = new EditTask(listTasks, listCategory, new TodoItem(this.Title, "", 0));

            Navigation.PushAsync(editTask);
        }
        private void TapTick(object sender, EventArgs e)
        {
            var img = (Image)sender;
            var grid = (Grid)img.Parent;
            TodoItem saveItem = new TodoItem();

            switch (img.Source.ToString())
            {
                case "File: tick0.png":
                    img.Source = ImageSource.FromFile("tick1.png");
                    foreach(TodoItem item in listTasks)
                    {
                        if(item.ID == int.Parse(grid.ClassId))
                        {
                            saveItem = item;
                            saveItem.Done = 1;
                        }
                    }
                    break;
                case "File: tick1.png":
                    img.Source = ImageSource.FromFile("tick0.png");
                    foreach (TodoItem item in listTasks)
                    {
                        if (item.ID == int.Parse(grid.ClassId))
                        {
                            saveItem = item;
                            saveItem.Done = 0;
                        }
                    }
                    break;
                default:
                    break;
            }

            App.DatabaseTasks.SaveItemAsync(saveItem);
            App.Query = true;
        }
        private void QueryList(bool query)
        {
            if (query)
            {
                listTasks = new ObservableCollection<TodoItem>();

                foreach (TodoItem item in App.DatabaseTasks.GetItemsAsync(Title).Result)
                {
                    listTasks.Add(item);
                }
                listViewTasks.ItemsSource = listTasks;
                App.Query = false;
            }
        }
    }
}