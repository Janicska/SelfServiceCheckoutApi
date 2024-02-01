using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SelfServiceCheckoutApi.Models
{
    public class Stock //each property represents a type of bill or coin, the value means how many the machine has 
    {
        public int Id { get; set; }
        //coins
        [Required]
        public int HUF5 { get; set; }
        [Required]
        public int HUF10 { get; set; }
        [Required]
        public int HUF20 { get; set; }
        [Required]
        public int HUF50 { get; set; }
        [Required]
        public int HUF100 { get; set; }
        [Required]
        public int HUF200 { get; set; }

        //bills
        [Required]
        public int HUF500 { get; set; }
        [Required]
        public int HUF1000 { get; set; }
        [Required]
        public int HUF2000 { get; set; }
        [Required]
        public int HUF5000 { get; set; }
        [Required]
        public int HUF10000 { get; set; }
        [Required]
        public int HUF20000 { get; set; }

        //total value of the stock
        public int TotalValueInHUF => HUF5 * 5 + HUF10 * 10 + HUF20 * 20 + HUF50 * 50 + HUF100 * 100 + HUF200 * 200 +
            HUF500 * 500 + HUF1000 * 1000 + HUF2000 * 2000 + HUF5000 * 5000 + HUF10000 * 10000 + HUF20000 * 20000;

        //loading the stock with an other one
        public void AddStock(Stock newStock)
        {
            HUF5 += newStock.HUF5;
            HUF10 += newStock.HUF10;
            HUF20 += newStock.HUF20;
            HUF50 += newStock.HUF50;
            HUF100 += newStock.HUF100;
            HUF200 += newStock.HUF200;

            HUF500 += newStock.HUF500;
            HUF1000 += newStock.HUF1000;
            HUF2000 += newStock.HUF2000;
            HUF5000 += newStock.HUF5000;
            HUF10000 += newStock.HUF10000;
            HUF20000 += newStock.HUF20000;
        }
    }
}
