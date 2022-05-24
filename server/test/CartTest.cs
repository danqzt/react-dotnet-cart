using System.Linq;
using Server.Models;
using Xunit;


namespace Test;

[CollectionDefinition("Test Collection")]
public class TestCollection : ICollectionFixture<TestFixture> {}

[Collection("Test Collection")]
public class CartTest 
{
    private readonly TestFixture fixture;

    public CartTest(TestFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void AddItemToCart()
    {
        var cartName = "Test1";
        var productSvc = fixture.ProductRepoMock.Object;
        var item1 = new CartItem
        {
             Product = productSvc.GetById("A"),
             Quantity = 3,
        };
        var item2 = new CartItem
        {
             Product = productSvc.GetById("B"),
             Quantity = 1,
        };
        var cartSvc = fixture.CartService;
        cartSvc.Update(cartName, item1);
        cartSvc.Update(cartName, item2);
        var cart = cartSvc.GetbyId(cartName);
        
        Assert.Equal(4, cart.TotalQuantity);
        Assert.Equal(6m, cart.TotalPrice);
    }

    [Fact]
    public void ChangeCountry()
    {
        var cartName = "Test2";
        var productSvc = fixture.ProductRepoMock.Object;
        var item1 = new CartItem
        {
             Product = productSvc.GetById("A"),
             Quantity = 3,
        };
        var item2 = new CartItem
        {
             Product = productSvc.GetById("B"),
             Quantity = 1,
        };
        var cartSvc = fixture.CartService;
        cartSvc.Update(cartName, item1);
        cartSvc.Update(cartName, item2);
        cartSvc.SetCountry(cartName, fixture.CountryRepoMoc.Object.GetCountries()[1]);
        
        var cart = cartSvc.GetbyId(cartName);
        
        Assert.Equal(4, cart.TotalQuantity);
        Assert.Equal(12m, cart.TotalPrice);
    }

    [Fact]
    public void DeleteItem()
    {
        var cartName = "Test3";
        var productSvc = fixture.ProductRepoMock.Object;
        var item1 = new CartItem
        {
             Product = productSvc.GetById("A"),
             Quantity = 3,
        };
        var item2 = new CartItem
        {
             Product = productSvc.GetById("B"),
             Quantity = 4,
        };
        var cartSvc = fixture.CartService;
        cartSvc.Update(cartName, item1);
        cartSvc.Update(cartName, item2);
        cartSvc.SetCountry(cartName, fixture.CountryRepoMoc.Object.GetCountries()[1]);
        cartSvc.Delete(cartName, item1);
        
        var cart = cartSvc.GetbyId(cartName);
        
        Assert.Equal(4, cart.TotalQuantity);
        Assert.Equal((4*3)*2, cart.TotalPrice);
    }
}