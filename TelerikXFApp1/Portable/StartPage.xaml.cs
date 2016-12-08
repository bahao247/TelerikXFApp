using System;
using Xamarin.Forms;

namespace Portable
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        { 
            InitializeComponent();
            updateButton.Clicked += UpdateButton_Clicked;

            // C# test
            //numericalAxis.LabelFormat = Xamarin.Forms.Device.OnPlatform("%.2f", "%.2f", "N2");
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            await Core.GetStocks();
        }
    }
}