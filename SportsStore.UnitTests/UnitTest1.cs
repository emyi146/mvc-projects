using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain;
using SportsStore.Web.Controllers;
using SportsStore.Web.HtmlHelpers;
using SportsStore.Web.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
                new Product {ProductId = 4, Name = "P4"},
                new Product {ProductId = 5, Name = "P5"},
                new Product {ProductId = 6, Name = "P6"}
            });
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Act
            ProductListViewModel result = (ProductListViewModel)controller.List(null, 2).Model;

            //Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 3);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            //Arrange - define an HTML helper we need to do this
            // in order to apply the extension method
            HtmlHelper myHelper = null;
            //Arrage - create PaginInfo data
            SortingPagingInfo pagingInfo = new SortingPagingInfo
            {
                CurrentPage = 2,
                ItemsPerPage = 20,
                TotalItems = 45
            };

            //Arrange - set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => String.Format("Page{0}", i);

            //Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            //Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>" + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>" + @"<a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString());
        }


        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            //Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]{
                new Product { ProductId = 1, Name = "P1" },
                new Product { ProductId = 2, Name = "P2" },
                new Product { ProductId = 3, Name = "P3" },
                new Product { ProductId = 4, Name = "P4" },
                new Product { ProductId = 5, Name = "P5" },
                new Product { ProductId = 6, Name = "P6" }
            });

            //Arrange
            ProductController productController = new ProductController(mock.Object);
            productController.PageSize = 3;

            //Act
            ProductListViewModel result = (ProductListViewModel)productController.List(null, 2).Model;


            //Assert
            SortingPagingInfo pagingInfo = result.SortingPagingInfo;
            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
            Assert.AreEqual(pagingInfo.TotalItems, 6);
            Assert.AreEqual(pagingInfo.TotalPages, 2);
        }



        [TestMethod]
        public void Can_Filter_Products()
        {
            // Arrange

            // Create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductId = 1, Name = "P1", Category = "Cat1"},
                new Product {ProductId = 2, Name = "P2", Category = "Cat1"},
                new Product {ProductId = 3, Name = "P3", Category = "Cat1"},
                new Product {ProductId = 4, Name = "P4", Category = "Cat1"},
                new Product {ProductId = 5, Name = "P5", Category = "Cat1"},
                new Product {ProductId = 6, Name = "P6", Category = "Cat2"},
                new Product {ProductId = 7, Name = "P7", Category = "Cat2"},
                new Product {ProductId = 8, Name = "P8", Category = "Cat2"},
                new Product {ProductId = 9, Name = "P9", Category = "Cat3"},
                new Product {ProductId = 10, Name = "P10", Category = "Cat3"}
            });


            // Create a controller
            ProductController productController = new ProductController(mock.Object);
            productController.PageSize = 3;

            //Act
            ProductListViewModel productListViewModel = (ProductListViewModel)productController.List("Cat1", 2).Model;

            //Assert
            Product[] products = productListViewModel.Products.ToArray();

            SortingPagingInfo pagingInfo = productListViewModel.SortingPagingInfo;
            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
            Assert.AreEqual(pagingInfo.TotalItems, 5);
            Assert.AreEqual(pagingInfo.TotalPages, 2);
            Assert.IsTrue(products[0].Name == "P4" && products[0].Category == "Cat1");
            Assert.IsTrue(products[1].Name == "P5" && products[1].Category == "Cat1");
            Assert.AreEqual(products.Length, 2);
        }


        [TestMethod]
        public void Can_Create_Categories()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductId = 1, Name = "P1", Category = "Cat3"},
                new Product{ProductId = 2, Name = "P2", Category = "Cat1"},
                new Product{ProductId = 3, Name = "P3", Category = "Cat2"},
                new Product{ProductId = 4, Name = "P4", Category = "Cat3"},
                new Product{ProductId = 5, Name = "P5", Category = "Cat3"},
                new Product{ProductId = 6, Name = "P6", Category = "Cat1"},
                new Product{ProductId = 7, Name = "P7", Category = "Cat1"}
            });

            // Create the controller
            NavController navController = new NavController(mock.Object);

            // Act
            string[] categories = ((IEnumerable<string>)navController.Menu().Model).ToArray();

            // Assert
            Assert.AreEqual(categories.Length, 3);
            Assert.AreEqual(categories[0], "Cat1");
            Assert.AreEqual(categories[1], "Cat2");
            Assert.AreEqual(categories[2], "Cat3");
        }

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new Product[]
                {
                    new Product{ProductId = 1, Description = "P1", Category = "Cat1"},
                    new Product{ProductId = 2, Description = "P2", Category = "Cat3"},
                    new Product{ProductId = 3, Description = "P3", Category = "Cat2"},
                    new Product{ProductId = 4, Description = "P4", Category = "Cat1"},
                    new Product{ProductId = 5, Description = "P5", Category = "Cat1"},
                    new Product{ProductId = 6, Description = "P6", Category = "Cat2"},
                }
            );

            // Arrange - Controller
            NavController controller = new NavController(mock.Object);

            // Act
            string selectedCategory = controller.Menu("Cat2").ViewBag.SelectedCategory;

            // Assert
            Assert.AreEqual(selectedCategory, "Cat2");

        }

        [TestMethod]
        public void Generate_Category_Specific_Product()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new Product[]
                {
                    new Product{ProductId = 1, Name = "P1", Category = "Cat1"},
                    new Product{ProductId = 2, Name = "P2", Category = "Cat2"},
                    new Product{ProductId = 3, Name = "P3", Category = "Cat1"},
                    new Product{ProductId = 4, Name = "P4", Category = "Cat2"},
                    new Product{ProductId = 5, Name = "P5", Category = "Cat3"},
                    new Product{ProductId = 6, Name = "P6", Category = "Cat2"},
                    new Product{ProductId = 7, Name = "P7", Category = "Cat2"},
                }
            );

            // Arrange
            ProductController controller =  new ProductController(mock.Object);
            controller.PageSize = 3;

            // Act
            int result1 = ((ProductListViewModel)controller.List("Cat1", 1).Model).SortingPagingInfo.TotalItems;
            int result2 = ((ProductListViewModel)controller.List("Cat2", 1).Model).SortingPagingInfo.TotalItems;
            int result3 = ((ProductListViewModel)controller.List("Cat2", 2).Model).SortingPagingInfo.TotalItems;
            int result4 = ((ProductListViewModel)controller.List(null, 1).Model).SortingPagingInfo.TotalItems;
       
        
            // Assert
            Assert.AreEqual(result1, 2);
            Assert.AreEqual(result2, 4);
            Assert.AreEqual(result3, 4);
            Assert.AreEqual(result4, 7);
            
        }
    }
}
