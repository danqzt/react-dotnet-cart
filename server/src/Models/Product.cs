namespace Server.Models
{
    public class Product
    {
        public string Id {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public decimal Price {get;set;}
        public string Image{get;set;}
        public int StockQuantity {get;set;}

        public override bool Equals(object? obj)
        {
            return this.Id.Equals(((Product)obj)?.Id);
        }
    }
}