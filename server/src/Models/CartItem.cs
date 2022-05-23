using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class CartItem
    {
        public Product Product {get;set;}

        [Range(0, int.MaxValue, ErrorMessage ="Must be positive number")]
        public int Quantity {get;set;}

        public override bool Equals(object? obj)
        {
            return this.Product.Equals(((CartItem)obj).Product);
        }
    }
}