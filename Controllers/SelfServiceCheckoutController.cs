using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfServiceCheckoutApi.Models;
using SelfServiceCheckoutApi.Services;
using System.Text.Json;

namespace SelfServiceCheckoutApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class SelfServiceCheckoutController : ControllerBase
    {
        private readonly ILogger<SelfServiceCheckoutController> _logger;

        public SelfServiceCheckoutController(ILogger<SelfServiceCheckoutController> logger)
        {
            _logger = logger;
        }

        //calculating the change
        private Stock? CalculateChange(int change, Stock stock)
        {
            Stock changeStock = new();
            int remainingPrice = change;

            //first trying with the higher bills to make the change with the less amount of bills
            while (remainingPrice >= 20000 && stock.HUF20000 > 0) //if the remaining change can be decreased by this bill and the machine has in stock
            {
                remainingPrice -= 20000; //decrease the remaining price
                stock.HUF20000--; //decrease the number of these bills in the stock
                changeStock.HUF20000++; //add it to the change stock
            }
            while (remainingPrice >= 10000 && stock.HUF10000 > 0)
            {
                remainingPrice -= 10000;
                stock.HUF10000--;
                changeStock.HUF10000++;
            }
            while (remainingPrice >= 5000 && stock.HUF5000 > 0)
            {
                remainingPrice -= 5000;
                stock.HUF5000--;
                changeStock.HUF5000++;
            }
            while (remainingPrice >= 2000 && stock.HUF2000 > 0)
            {
                remainingPrice -= 2000;
                stock.HUF2000--;
                changeStock.HUF2000++;
            }
            while (remainingPrice >= 1000 && stock.HUF1000 > 0)
            {
                remainingPrice -= 1000;
                stock.HUF1000--;
                changeStock.HUF1000++;
            }
            while (remainingPrice >= 500 && stock.HUF500 > 0)
            {
                remainingPrice -= 500;
                stock.HUF500--;
                changeStock.HUF500++;
            }

            while (remainingPrice >= 200 && stock.HUF200 > 0)
            {
                remainingPrice -= 200;
                stock.HUF200--;
                changeStock.HUF200++;
            }
            while (remainingPrice >= 100 && stock.HUF100 > 0)
            {
                remainingPrice -= 100;
                stock.HUF100--;
                changeStock.HUF100++;
            }
            while (remainingPrice >= 50 && stock.HUF50 > 0)
            {
                remainingPrice -= 50;
                stock.HUF50--;
                changeStock.HUF50++;
            }
            while (remainingPrice >= 20 && stock.HUF20 > 0)
            {
                remainingPrice -= 20;
                stock.HUF20--;
                changeStock.HUF20++;
            }
            while (remainingPrice >= 10 && stock.HUF10 > 0)
            {
                remainingPrice -= 10;
                stock.HUF10--;
                changeStock.HUF10++;
            }
            while (remainingPrice >= 5 && stock.HUF5 > 0)
            {
                remainingPrice -= 5;
                stock.HUF5--;
                changeStock.HUF5++;
            }

            return remainingPrice == 0 ? changeStock : null; //if there is no remaining left (means the machine can give back a proper change) returns the change
        }

        [HttpPost("Stock")]
        public IActionResult LoadStock(string jsonString) //loading the current stock with adding the value of a new one
        {
            _logger.LogInformation($"LoadStock method was called with parameter: {jsonString}");
            try
            {
                //converts the body of the request into a stock
                Stock newStock = StockJsonConverter.ConvertJsonStringIntoStock(jsonString);
                using var db = new StockDbContext();
                //receives the current stock from the database
                Stock stock = db.Stock.First();

                //adds the value of the new stock to the current stock, so the machine is loaded
                stock.AddStock(newStock);

                //saving the change in the database
                _logger.LogInformation("Saving stock to database!");
                db.SaveChanges();

                //returns status code 200 with the properly serialized stock
                string stockString = StockJsonConverter.ConvertStockIntoJsonString(stock);
                _logger.LogInformation($"LoadStock returning with: {stockString}");
                return Ok(stockString);
            }
            //returns status code 400 with error message and the exception
            catch (Exception ex)
            {
                _logger.LogError($"There was an error during LoadStock method!");
                return BadRequest($"There was an error during the request! --- {ex}");
            }
        }

        [HttpGet("Stock")]
        public IActionResult GetStock() //gets the current stock
        {
            _logger.LogInformation($"GetStock method was called.");
            try
            {
                using var db = new StockDbContext();
                //receives the current stock from the database
                Stock stock = db.Stock.First();

                //returns status code 200 with the properly serialized stock
                string stockString = StockJsonConverter.ConvertStockIntoJsonString(stock);
                _logger.LogInformation($"GetStock returning with: {stockString}");
                return Ok(stockString);
            }
            //returns status code 400 with error message and the exception
            catch (Exception ex)
            {
                _logger.LogError($"There was an error during GetStock method!");
                return BadRequest($"There was an error during the request! --- {ex}");
            }
        }

        [HttpPost("Checkout")]
        public IActionResult Checkout(string jsonString) //proceeds a checkout method with the given price and inserted parameters, returns the change on success, or the error on failure
        {
            _logger.LogInformation($"Checkout method was called with parameter: {jsonString}");
            try
            {
                //convert the input into a stock and a price
                CheckoutInput input = StockJsonConverter.ConvertJsonStringIntoCheckoutInput(jsonString);
                using var db = new StockDbContext();
                //receives the current stock from the database
                Stock stock = db.Stock.First();

                //adding the value of the instered bill to the stock
                stock.AddStock(input.Stock);
                //calculating the value of the change
                int change = input.Stock.TotalValueInHUF - input.Price;

                if (input.Stock.TotalValueInHUF < input.Price) //if the user paid less than the actual price, returns with error
                {
                    _logger.LogInformation("Customer has not enough money for checkout!");
                    return BadRequest("Customer does not have enough money!");
                }

                Stock? changeStock = CalculateChange(change, stock); //calculating the change, on success returns with a stock with the change inside, on failure returns with a null
                if (changeStock is null)
                {
                    _logger.LogInformation("The machine couldn't give change to a customer during a checkout!");
                    return BadRequest("Machine cannot give change!"); //returning with error, the machine can't give a proper change
                }

                //if there was no error, saving the changes of the stock to the database
                _logger.LogInformation("Saving stock to database.");
                db.SaveChanges();
                //returns status code 200 with the properly serialized change
                string stockString = StockJsonConverter.ConvertStockIntoJsonString(changeStock);
                _logger.LogInformation($"Checkout returning with: {stockString}");
                return Ok(stockString);
            }
            //returns status code 400 with error message and the exception
            catch (Exception ex)
            {
                _logger.LogError($"There was an error during Checkout method!");
                return BadRequest($"There was an error during the request! --- {ex}");
            }
        }

        [HttpGet("BlockedBills")]
        public IActionResult BlockedBills() //returning the list of bills, that the machine could not handle if they were the value of the change
        {                                   //(without a given price, this meaning for the task was the logical for me)
            _logger.LogInformation($"BlockedBills method was called.");
            try
            {
                //type of values for the bills
                List<int> allBills = [5, 10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000];
                List<string> blockedBills = [];
                using var db = new StockDbContext();
                //receives the current stock from the database
                Stock stock = db.Stock.First();
                foreach (var bill in allBills)
                {
                    //copying the stock to not be affected by the value change
                    Stock stockCopy = new();
                    stockCopy.AddStock(stock);

                    if (CalculateChange(bill, stockCopy) is null) //if the returned value is null, the machine could not give change at that value, so the bill is blocked
                        blockedBills.Add(bill.ToString());
                }
                //returns status code 200 with the list of blocked bills
                string stockString = JsonSerializer.Serialize(blockedBills);
                _logger.LogInformation($"BlockedBills returning with: {stockString}");
                return Ok(stockString);
            }
            //returns status code 400 with error message and the exception
            catch (Exception ex)
            {
                _logger.LogError($"There was an error during BlockedBills method!");
                return BadRequest($"There was an error during the request! --- {ex}");
            }
        }
    }
}
