﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable
{
    class Core
    {
        public static async Task<Stock> GetStocks()
        {
            string queryString = String.Format(
                "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.historicaldata%20where%20symbol%20in%20(%22FB%22)%20and%20startDate%20=%20%272016-11-20%27%20and%20endDate%20=%20%272016-11-30%27&diagnostics=false&format=json&env=store://datatables.org/alltableswithkeys"/*,*/
                /*stockcharts.SymbolStockCharts, stockcharts.BeginDateStockCharts.Date, stockcharts.EndDateStockCharts.Date*/);

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
                //stock.IDsCharts = stockcharts.IDStockCharts;
                stock.SymbolStock = (string)results["query"]["results"]["quote"][count - 1]["Symbol"];
                stock.ValueCloseStockEntry = (float)results["query"]["results"]["quote"][count - 1]["Close"];
                stock.DateStock = (DateTime)results["query"]["results"]["quote"][count - 1]["Date"];

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
