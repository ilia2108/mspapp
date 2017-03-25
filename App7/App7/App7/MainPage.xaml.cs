using App7.ChildContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App7
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            menuListView.ItemsSource=Enumerable.Range(1, 10).Select(i=>new MenuElement()
            {
                Text="Menu "+i,
                PageType=i%2==0 ? typeof(View1) : typeof(View2)
            });
        }

        private void menuListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menuElement = e.SelectedItem as MenuElement;
            ChildPagePresenter.Content = Activator.CreateInstance(menuElement.PageType) as View;
        }
    }

    public class MenuElement
    {
        public string Text { get; set; }
        public string ImageSource { get; set; }

        public Type PageType { get; set; }
    }
}
