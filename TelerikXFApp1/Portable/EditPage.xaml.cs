﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Portable
{
    public partial class EditPage : ContentPage
    {
        private StockCharts stockcharts;

        private int statusNoteSwitchPriority;
        private TimeZoneInfo localZone = TimeZoneInfo.Local;
        public EditPage(StockCharts stockcharts)
        {
            InitializeComponent();
            this.stockcharts = stockcharts;

            saveButton.Clicked += SaveButton_Clicked;
            deleteButton.Clicked += DeleteButton_Clicked;
            updateButton.Clicked += UpdateButton_Clicked;
            showButton.Clicked += showButton_Clicked;

            symbolStockChartsEntry.Text = stockcharts.SymbolStockCharts;
            noteStockChartsEntry.Text = stockcharts.NoteStockCharts;
            beginDateStockChartsPicker.Date = stockcharts.BeginDateStockCharts;
            endDateStockChartsPicker.Date = stockcharts.EndDateStockCharts;

            stockListView.ItemTemplate = new DataTemplate(typeof(StockCell));

            using (var data = new DataAccess())
            {
                data.DeleteStock();
            }
        }

        private async void showButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartPage());
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            using (var data = new DataAccess())
            {
                data.DeleteStock();
            }

            stockcharts.NoteStockCharts = noteStockChartsEntry.Text;
            stockcharts.BeginDateStockCharts = beginDateStockChartsPicker.Date.AddHours(localZone.BaseUtcOffset.Hours);
            stockcharts.EndDateStockCharts = endDateStockChartsPicker.Date.AddHours(localZone.BaseUtcOffset.Hours);

            if (await Core.GetStocks(stockcharts) == null)
            {
                await DisplayAlert("Error", "Check again name and datetime", "Accept");
                return;
            }

            using (var data = new DataAccess())
            {
                data.UpdateStockCharts(stockcharts);
                stockListView.ItemsSource = data.GetStock();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (var data = new DataAccess())
            {
                stockListView.ItemsSource = data.GetStock();
            }
        }

        public async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var rta = await DisplayAlert("Confirm", "Do you want to delete this note?", "Yes", "No");
            if (!rta) return;

            using (var data = new DataAccess())
            {
                data.DeleteStockCharts(stockcharts);
            }

            await DisplayAlert("Confirm", "Note was deleted successfully", "OK");
            await Navigation.PushAsync(new HomePage());
        }

        public async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(symbolStockChartsEntry.Text))
            {
                await DisplayAlert("Error", "You must enter names", "Accept");
                symbolStockChartsEntry.Focus();
                return;
            }

            StockCharts stockcharts = new StockCharts
            {
                IDStockCharts = this.stockcharts.IDStockCharts,
                SymbolStockCharts = symbolStockChartsEntry.Text,
                NoteStockCharts = noteStockChartsEntry.Text,
                BeginDateStockCharts = beginDateStockChartsPicker.Date,
                EndDateStockCharts = endDateStockChartsPicker.Date,
            };

            using (var data = new DataAccess())
            {
                data.UpdateStockCharts(stockcharts);
            }
            await DisplayAlert("Confirm", "Content of note updated correctly", "Accept");
            await Navigation.PushAsync(new HomePage());
        }
    }
}
