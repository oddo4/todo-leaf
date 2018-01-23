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
	public partial class EditCategories : ContentPage
	{
        ObservableCollection<Category> listCategory = new ObservableCollection<Category>();
        public EditCategories()
        {
            InitializeComponent();
        }
        public EditCategories(ObservableCollection<Category> listCat)
        {
            InitializeComponent();
            listCategory = listCat;
            MessagingCenter.Subscribe<EditCategories>(this, "UpdateList", (sender) => {
                listCategory = new ObservableCollection<Category>();

                foreach (Category item in App.DatabaseCategories.GetAllAsync().Result)
                {
                    listCategory.Add(item);
                }

                listViewCategories.ItemsSource = listCategory;
            });
            listViewCategories.ItemsSource = listCategory;
        }
        private void SelectedCategory(object sender, ItemTappedEventArgs e)
        {
            EditCategory editCat = new EditCategory(listCategory, (Category)listViewCategories.SelectedItem, this);
            Navigation.PushAsync(editCat);
        }
        private void AddCat_Clicked(object sender, EventArgs e)
        {
            EditCategory editCat = new EditCategory(listCategory, new Category(""), this);
            Navigation.PushAsync(editCat);
        }

    }
}