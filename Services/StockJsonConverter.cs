using Newtonsoft.Json;
using SelfServiceCheckoutApi.Models;

namespace SelfServiceCheckoutApi.Services
{
    public static class StockJsonConverter
    {
        public static string ConvertStockIntoJsonString(Stock stock) //converting the stock object to fit for the required one in the task 
        {
            Dictionary<string, int> stockDic = new();

            if (stock.HUF20000 > 0)
                stockDic.Add("20000", stock.HUF20000);
            if (stock.HUF10000 > 0)
                stockDic.Add("10000", stock.HUF10000);
            if (stock.HUF5000 > 0)
                stockDic.Add("5000", stock.HUF5000);
            if (stock.HUF2000 > 0)
                stockDic.Add("2000", stock.HUF2000);
            if (stock.HUF1000 > 0)
                stockDic.Add("1000", stock.HUF1000);
            if (stock.HUF500 > 0)
                stockDic.Add("500", stock.HUF500);

            if (stock.HUF200 > 0)
                stockDic.Add("200", stock.HUF200);
            if (stock.HUF100 > 0)
                stockDic.Add("100", stock.HUF100);
            if (stock.HUF50 > 0)
                stockDic.Add("50", stock.HUF50);
            if (stock.HUF20 > 0)
                stockDic.Add("20", stock.HUF20);
            if (stock.HUF10 > 0)
                stockDic.Add("10", stock.HUF10);
            if (stock.HUF5 > 0)
                stockDic.Add("5", stock.HUF5);

            return JsonConvert.SerializeObject(stockDic, Formatting.Indented);
        }

        public static Stock ConvertJsonStringIntoStock(string jsonString) //converting the given bills into a stock object
        {
            Stock newStock = new();
            Dictionary<string, int>? stockDic = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonString);
            if (stockDic is not null)
            {
                if (stockDic.ContainsKey("5"))
                    newStock.HUF5 = stockDic["5"];
                if (stockDic.ContainsKey("10"))
                    newStock.HUF10 = stockDic["10"];
                if (stockDic.ContainsKey("20"))
                    newStock.HUF20 = stockDic["20"];
                if (stockDic.ContainsKey("50"))
                    newStock.HUF50 = stockDic["50"];
                if (stockDic.ContainsKey("100"))
                    newStock.HUF100 = stockDic["100"];
                if (stockDic.ContainsKey("200"))
                    newStock.HUF200 = stockDic["200"];

                if (stockDic.ContainsKey("500"))
                    newStock.HUF500 = stockDic["500"];
                if (stockDic.ContainsKey("1000"))
                    newStock.HUF1000 = stockDic["1000"];
                if (stockDic.ContainsKey("2000"))
                    newStock.HUF2000 = stockDic["2000"];
                if (stockDic.ContainsKey("5000"))
                    newStock.HUF5000 = stockDic["5000"];
                if (stockDic.ContainsKey("10000"))
                    newStock.HUF10000 = stockDic["10000"];
                if (stockDic.ContainsKey("20000"))
                    newStock.HUF20000 = stockDic["20000"];

                return newStock;
            }
            else { throw new NullReferenceException(); }
        }

        public static CheckoutInput ConvertJsonStringIntoCheckoutInput(string jsonString) //converting the given bills and the given price into an object
        {
            CheckoutInput input = new();
            dynamic? inputObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
            if (inputObject is not null)
            {
                input.Price = inputObject["price"];

                if (inputObject["inserted"].ContainsKey("5"))
                    input.Stock.HUF5 = inputObject["inserted"]["5"];
                if (inputObject["inserted"].ContainsKey("10"))
                    input.Stock.HUF10 = inputObject["inserted"]["10"];
                if (inputObject["inserted"].ContainsKey("20"))
                    input.Stock.HUF20 = inputObject["inserted"]["20"];
                if (inputObject["inserted"].ContainsKey("50"))
                    input.Stock.HUF50 = inputObject["inserted"]["50"];
                if (inputObject["inserted"].ContainsKey("100"))
                    input.Stock.HUF100 = inputObject["inserted"]["100"];
                if (inputObject["inserted"].ContainsKey("200"))
                    input.Stock.HUF200 = inputObject["inserted"]["200"];

                if (inputObject["inserted"].ContainsKey("500"))
                    input.Stock.HUF500 = inputObject["inserted"]["500"];
                if (inputObject["inserted"].ContainsKey("1000"))
                    input.Stock.HUF1000 = inputObject["inserted"]["1000"];
                if (inputObject["inserted"].ContainsKey("2000"))
                    input.Stock.HUF2000 = inputObject["inserted"]["2000"];
                if (inputObject["inserted"].ContainsKey("5000"))
                    input.Stock.HUF5000 = inputObject["inserted"]["5000"];
                if (inputObject["inserted"].ContainsKey("10000"))
                    input.Stock.HUF10000 = inputObject["inserted"]["10000"];
                if (inputObject["inserted"].ContainsKey("20000"))
                    input.Stock.HUF20000 = inputObject["inserted"]["20000"];

                return input;

            }
            else { throw new NullReferenceException(); }
        }
    }
}
