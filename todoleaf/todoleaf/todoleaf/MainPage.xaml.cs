using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace todoleaf
{
	public partial class MainPage : ContentPage
	{
        ObservableCollection<Category> listCategory = new ObservableCollection<Category>();
        public MainPage()
		{
			InitializeComponent();
            Category cat = new Category("Kat 1");
            listCategory.Add(cat);

            listViewCategories.ItemsSource = listCategory;
		}
        private void SelectedCategory(object sender, ItemTappedEventArgs e)
        {
            var selected = (Category)listViewCategories.SelectedItem;
            TaskPage taskPage = new TaskPage(selected.Name);
            Navigation.PushAsync(taskPage);
        }
        private void EditCat_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
