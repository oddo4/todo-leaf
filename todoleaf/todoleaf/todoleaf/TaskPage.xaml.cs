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
        public TaskPage ()
		{
			InitializeComponent();
            TodoItem item = new TodoItem();
            listTasks.Add(item);

            listViewTasks.ItemsSource = listTasks;
        }
        public TaskPage(string title)
        {
            this.Title = title;

            TodoItem task = new TodoItem("Kat 1", "Ahoj", 0);

            listTasks.Add(task);

            listViewTasks.ItemsSource = listTasks;
        }
        private void SelectedTask(object sender, ItemTappedEventArgs e)
        {
            
        }
        private void EditTask_Clicked(object sender, EventArgs e)
        {

        }
    }
}