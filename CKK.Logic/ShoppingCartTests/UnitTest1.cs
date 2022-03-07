using System;
using Xunit;
using CKK.Logic.Models;

namespace ShoppingCartTests
{
    public class UnitTest1
    {
        [Fact]
        public void Tests_Add_Store_Item_Should_Return_True()
        {
            //initialize? assemble
            Customer _Joe = new Customer(123456, "Joe Shmoe", "123 LU st");
            Product _apples = new Product(654321, "Apples", 2.50m);

            ShoppingCart _shoppingCart = new ShoppingCart(_Joe);

            //act         
            _shoppingCart.AddStoreItem(_apples, 2);

            var expected = _shoppingCart.GetProductById(654321);
            var actual = _shoppingCart.GetProduct(1);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tests_Remove_Store_Item_When_Subtract_All_Quantity_Should_Return_True()
        {
            //initialize? assemble
            Customer _Joe = new Customer(123456, "Joe Shmoe", "123 LU st");
            Product _apples = new Product(654321, "Apples", 2.50m);

            ShoppingCart _shoppingCart = new ShoppingCart(_Joe);
            _shoppingCart.AddStoreItem(_apples, 2);

            //act         
            _shoppingCart.RemoveStoreItem(_apples, 2);

            ShoppingCartItem expected = null;
            var actual = _shoppingCart.GetProduct(1);



            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tests_Remove_Store_Item_When_Subtract_Some_Quantity_Should_Return_True()
        {
            //initialize? assemble
            Customer _Joe = new Customer(123456, "Joe Shmoe", "123 LU st");
            Product _apples = new Product(654321, "Apples", 2.50m);

            ShoppingCart _shoppingCart = new ShoppingCart(_Joe);
            _shoppingCart.AddStoreItem(_apples, 2);

            //act         
            _shoppingCart.RemoveStoreItem(_apples, 1);

            var expected = 1;
            var actual = _shoppingCart.GetProduct(1).GetQuantity();



            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Tests_Get_Total_Should_Return_True()
        {
            //initialize? assemble
            Customer _Joe = new Customer(123456, "Joe Shmoe", "123 LU st");
            Product _apples = new Product(654321, "Apples", 2.50m);
            Product _bananas = new Product(543210, "Bananas", 3.50m);
            Product _carrots = new Product(765432, "Carrots", 2.00m);

            ShoppingCart _shoppingCart = new ShoppingCart(_Joe);
            _shoppingCart.AddStoreItem(_apples, 2); 
            _shoppingCart.AddStoreItem(_bananas, 1); 
            _shoppingCart.AddStoreItem(_carrots, 4); 

            //act            
            var expected = 16.50m;
            var actual = _shoppingCart.GetTotal(); 

            //assert
            Assert.Equal(expected, actual);
        }

        
    }
}
