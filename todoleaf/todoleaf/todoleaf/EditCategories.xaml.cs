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
        Category category = new Category();
        public EditCategories()
        {
            InitializeComponent();
        }
        public EditCategories(ObservableCollection<Category> listCat, Category cat)
        {
            InitializeComponent();
            category = cat;
            listCategory = listCat;
            entText.Text = category.Name;
        }
        private void SaveCategory_Clicked(object sender, EventArgs e)
        {

        }
        private void DeleteCategory_Clicked(object sender, EventArgs e)
        {

        }

    }
}