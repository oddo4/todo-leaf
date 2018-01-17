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
        ObservableCollection<TodoItem> listTasks = new ObservableCollection<TodoItem>();
        public TaskPage()
		{
			InitializeComponent();
            TodoItem item = new TodoItem();
            listTasks.Add(item);

            listViewTasks.ItemsSource = listTasks;
        }
        public TaskPage(string title)
        {
            InitializeComponent();
            this.Title = title;

            TodoItem task = new TodoItem("Kat 1", "Ahoj Svete 1", 0);
            //App.Database.SaveItemAsync(task);
            //App.Database.DeleteAllAsync();

            foreach(TodoItem item in App.Database.GetItemsAsync(title).Result)
            {
                item.SetTickIcon();
                listTasks.Add(item);
            }

            listViewTasks.ItemsSource = listTasks;
        }
        private void SelectedTask(object sender, ItemTappedEventArgs e)
        {
            listViewTasks.SelectedItem = null;
        }
        private void EditTask_Clicked(object sender, EventArgs e)
        {
            EditTask editTask = new EditTask(listTasks);

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

            App.Database.SaveItemAsync(saveItem);
        }
        public void EditTask(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }
        public void DeleteTask(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }
    }
}