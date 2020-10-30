using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace GettingStarted
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void AllButton_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        void SearchBar_SearchButtonPressed(System.Object sender, System.EventArgs e)
        {
        }

        void SearchBar_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var height = SearchGrid.Height;
                await MainScroll.ScrollToAsync(0, height, true);
            });
        }

        void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
        }
    }

    //public magicGradients : SfGradientView
    //    {

    //    }

}
