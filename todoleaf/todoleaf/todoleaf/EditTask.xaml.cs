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
        ObservableCollection<TodoItem> listTasks;
        public EditTask()
        {
            InitializeComponent();
        }
        public EditTask(ObservableCollection<TodoItem> tasks)
        {
            InitializeComponent();
            listTasks = tasks;

            listViewTasks.ItemsSource = listTasks;
        }
        /*private void SelectedTask(object sender, ItemTappedEventArgs e)
        {

        }*/
        private void NewTask_Clicked(object sender, EventArgs e)
        {

        }
    }
}