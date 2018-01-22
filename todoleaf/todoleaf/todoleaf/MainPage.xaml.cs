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
            /*Category cat1 = new Category("Kat 1");
            Category cat2 = new Category("Kat 2");
            listCategory.Add(cat1);
            listCategory.Add(cat2);*/

            var result = App.Database.GetAllAsync().Result;
            List<string> listString = new List<string>();

            foreach (TodoItem item in result)
            {
                if(!listString.Contains(item.Name))
                {
                    listString.Add(item.Name);
                }                
            }

            foreach (string str in listString)
            {
                Category newCat = new Category(str);
                listCategory.Add(newCat);
            }

            listViewCategories.ItemsSource = listCategory;
		}
        private void SelectedCategory(object sender, ItemTappedEventArgs e)
        {
            var selected = (Category)listViewCategories.SelectedItem;
            TaskPage taskPage = new TaskPage(selected.Name, listCategory);
            listViewCategories.SelectedItem = null;
            Navigation.PushAsync(taskPage);
        }
        private void EditCat_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            var item = listViewCategories.SelectedItem;
        }
        private void DeleteCat_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
