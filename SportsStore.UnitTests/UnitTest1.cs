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
                new Product {Product_Id = 1, Product_Name = "P1"},
                new Product {Product_Id = 2, Product_Name = "P2"},
                new Product {Product_Id = 3, Product_Name = "P3"},
                new Product {Product_Id = 4, Product_Name = "P4"},
                new Product {Product_Id = 5, Product_Name = "P5"},
                new Product {Product_Id = 6, Product_Name = "P6"}
            });
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Act
            ProductListViewModel result = (ProductListViewModel)controller.List(null, 2).Model;

            //Assert
            ListProductsByCategory_Result[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 3);
            Assert.AreEqual(prodArray[0].Product_Name, "P4");
            Assert.AreEqual(prodArray[1].Product_Name, "P5");
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
                new Product { Product_Id = 1, Product_Name = "P1" },
                new Product { Product_Id = 2, Product_Name = "P2" },
                new Product { Product_Id = 3, Product_Name = "P3" },
                new Product { Product_Id = 4, Product_Name = "P4" },
                new Product { Product_Id = 5, Product_Name = "P5" },
                new Product { Product_Id = 6, Product_Name = "P6" }
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
                new Product {Product_Id = 1, Product_Name = "P1", Product_Category = "Cat1"},
                new Product {Product_Id = 2, Product_Name = "P2", Product_Category = "Cat1"},
                new Product {Product_Id = 3, Product_Name = "P3", Product_Category = "Cat1"},
                new Product {Product_Id = 4, Product_Name = "P4", Product_Category = "Cat1"},
                new Product {Product_Id = 5, Product_Name = "P5", Product_Category = "Cat1"},
                new Product {Product_Id = 6, Product_Name = "P6", Product_Category = "Cat2"},
                new Product {Product_Id = 7, Product_Name = "P7", Product_Category = "Cat2"},
                new Product {Product_Id = 8, Product_Name = "P8", Product_Category = "Cat2"},
                new Product {Product_Id = 9, Product_Name = "P9", Product_Category = "Cat3"},
                new Product {Product_Id = 10, Product_Name = "P10", Product_Category = "Cat3"}
            });


            // Create a controller
            ProductController productController = new ProductController(mock.Object);
            productController.PageSize = 3;

            //Act
            ProductListViewModel productListViewModel = (ProductListViewModel)productController.List("Cat1", 2).Model;

            //Assert
            ListProductsByCategory_Result[] products = productListViewModel.Products.ToArray();

            SortingPagingInfo pagingInfo = productListViewModel.SortingPagingInfo;
            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
            Assert.AreEqual(pagingInfo.TotalItems, 5);
            Assert.AreEqual(pagingInfo.TotalPages, 2);
            Assert.IsTrue(products[0].Product_Name == "P4" && products[0].CategoryLookup_Name == "Cat1");
            Assert.IsTrue(products[1].Product_Name == "P5" && products[1].CategoryLookup_Name == "Cat1");
            Assert.AreEqual(products.Length, 2);
        }


        [TestMethod]
        public void Can_Create_Categories()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{Product_Id = 1, Product_Name = "P1", Product_Category = "Cat3"},
                new Product{Product_Id = 2, Product_Name = "P2", Product_Category = "Cat1"},
                new Product{Product_Id = 3, Product_Name = "P3", Product_Category = "Cat2"},
                new Product{Product_Id = 4, Product_Name = "P4", Product_Category = "Cat3"},
                new Product{Product_Id = 5, Product_Name = "P5", Product_Category = "Cat3"},
                new Product{Product_Id = 6, Product_Name = "P6", Product_Category = "Cat1"},
                new Product{Product_Id = 7, Product_Name = "P7", Product_Category = "Cat1"}
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
        public void Indicates_Selected_Product_Category()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new Product[]
                {
                    new Product{Product_Id = 1, Product_Description = "P1", Product_Category = "Cat1"},
                    new Product{Product_Id = 2, Product_Description = "P2", Product_Category = "Cat3"},
                    new Product{Product_Id = 3, Product_Description = "P3", Product_Category = "Cat2"},
                    new Product{Product_Id = 4, Product_Description = "P4", Product_Category = "Cat1"},
                    new Product{Product_Id = 5, Product_Description = "P5", Product_Category = "Cat1"},
                    new Product{Product_Id = 6, Product_Description = "P6", Product_Category = "Cat2"},
                }
            );

            // Arrange - Controller
            NavController controller = new NavController(mock.Object);

            // Act
            string selectedProduct_Category = controller.Menu("Cat2").ViewBag.SelectedProduct_Category;

            // Assert
            Assert.AreEqual(selectedProduct_Category, "Cat2");

        }

        [TestMethod]
        public void Generate_Product_Category_Specific_Product()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new Product[]
                {
                    new Product{Product_Id = 1, Product_Name = "P1", Product_Category = "Cat1"},
                    new Product{Product_Id = 2, Product_Name = "P2", Product_Category = "Cat2"},
                    new Product{Product_Id = 3, Product_Name = "P3", Product_Category = "Cat1"},
                    new Product{Product_Id = 4, Product_Name = "P4", Product_Category = "Cat2"},
                    new Product{Product_Id = 5, Product_Name = "P5", Product_Category = "Cat3"},
                    new Product{Product_Id = 6, Product_Name = "P6", Product_Category = "Cat2"},
                    new Product{Product_Id = 7, Product_Name = "P7", Product_Category = "Cat2"},
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
