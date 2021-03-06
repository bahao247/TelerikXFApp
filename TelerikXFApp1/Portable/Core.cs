﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Portable.Annotations;

namespace Portable
{
    class Core : INotifyPropertyChanged
    {
        private ObservableCollection<StockData> categoricalChartDataCollection1;
        private List<Stock> listStock;
        
        public Core()
        {
            using (var data = new DataAccess())
            {
                listStock = data.GetStock();
            }

            List<StockData> tempList = new List<StockData>();

            StockData tempStock;

            for (int i = 0; i < listStock.Count; i++)
            {
                tempStock = new StockData();

                tempStock.Category = listStock[i].DateStock.Date.ToString("dd/MM/yyyy");
                tempStock.Value = listStock[i].ValueCloseStockEntry;

                tempList.Add(tempStock);
            }

            categoricalChartDataCollection1 = new ObservableCollection<StockData>(tempList);
        }

        public ObservableCollection<StockData> CategoricalChartDataCollection
        {
            get {
                return categoricalChartDataCollection1;
            }
            set
            {
                categoricalChartDataCollection1 = value;
                OnPropertyChanged();
            }
        }

        public class StockData
        {
            public string Category { get; set; }
            public float Value { get; set; }
        }

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        public static async Task<Stock> GetStocks(StockCharts stockcharts)
        {
            string queryString = String.Format(
                "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.historicaldata%20where%20symbol%20in%20(%22{0}%22)%20and%20startDate%20=%20%27{1:yyyy/MM/dd}%27%20and%20endDate%20=%20%27{2:yyyy/MM/dd}%27&diagnostics=false&format=json&env=store://datatables.org/alltableswithkeys",
                stockcharts.SymbolStockCharts, stockcharts.BeginDateStockCharts.Date, stockcharts.EndDateStockCharts.Date);

            var results = await StockService.getDataFromService(queryString).ConfigureAwait(false);

            int count = (int)results["query"]["count"];
            if (count == 0)
            {
                return null;
            }

            Stock stock = new Stock();
            stock.IDStock = 0;

            int id = 1;

            while (count > 0)
            {
                stock.IDStock = id;
                stock.IDsCharts = stockcharts.IDStockCharts;
                stock.SymbolStock = (string)results["query"]["results"]["quote"][count - 1]["Symbol"];
                stock.ValueCloseStockEntry = (float)results["query"]["results"]["quote"][count - 1]["Close"];
                stock.DateStock = ((DateTime)results["query"]["results"]["quote"][count - 1]["Date"]).AddHours(TimeZoneInfo.Local.BaseUtcOffset.Hours);
                
                using (var data = new DataAccess())
                {
                    data.InsertStock(stock);
                }
                --count;
                ++id;
            }
            return stock;
        }
    }
}
