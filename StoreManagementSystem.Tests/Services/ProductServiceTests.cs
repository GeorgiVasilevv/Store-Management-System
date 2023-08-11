
using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Services.Interfaces;
using StoreManagementSystem.Core.Services;
using StoreManagementSystem.Data.Contexts;
using static StoreManagementSystem.Tests.DatabaseSeeder;
using StoreManagementSystem.Core.Models.ViewModels.Products;
using StoreManagementSystem.Data.Entities.Models;
using StoreManagementSystem.Core.Models.ViewModels.Order;

namespace StoreManagementSystem.Tests.Services
{
    public class ProductServiceTests
    {
        private StoreManagementDbContext dbContext;
        private DbContextOptions<StoreManagementDbContext> dbOptions;

        private IProductService productService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<StoreManagementDbContext>()
                .UseInMemoryDatabase("StoreManagementInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new StoreManagementDbContext(dbOptions);

            SeedDatabase(dbContext);

            productService = new ProductService(dbContext);
        }

        [Test]
        public async Task CategoryExistsByIdAsyncExistingCategoryShouldReturnTrue()
        {
            // Act
            var exists = await productService.CategoryExistsByIdAsync(1);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task CategoryExistsByIdAsyncNonExistentCategoryShouldReturnFalse()
        {
            // Act
            var exists = await productService.CategoryExistsByIdAsync(999); // Assuming category with Id 999 doesn't exist

            // Assert
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task ConditionExistsByIdAsyncExistingConditionShouldReturnTrue()
        {
            // Act
            var exists = await productService.ConditionExistsByIdAsync(1);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ConditionExistsByIdAsyncExistingConditionShouldReturnFalse()
        {
            // Act
            var exists = await productService.ConditionExistsByIdAsync(999); // Assuming condition with Id 999 doesn't exist

            // Assert
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task CreateAndReturnIdAsyncShouldCreateProductAndReturnId()
        {
            // Arrange
            var productModel = new ProductAddFormModel
            {
                Title = "Test Product",
                Description = "Test Description",
                Price = 100,
                ImageUrl = "https://example.com/test-image.jpg",
                CategoryId = 1,
                ConditionId = 1
            };

            // Act
            var createdProductId = await productService.CreateAndReturnIdAsync(productModel, 1);

            // Assert
            var createdProduct = dbContext.Products.FirstOrDefault(p => p.Id == createdProductId);
            Assert.IsNotNull(createdProduct);
            Assert.That(createdProduct.Title, Is.EqualTo(productModel.Title));
            Assert.That(createdProduct.Description, Is.EqualTo(productModel.Description));
            Assert.That(createdProduct.Price, Is.EqualTo(productModel.Price));
            Assert.That(createdProduct.ImageUrl, Is.EqualTo(productModel.ImageUrl));
            Assert.That(createdProduct.CategoryId, Is.EqualTo(productModel.CategoryId));
            Assert.That(createdProduct.ConditionId, Is.EqualTo(productModel.ConditionId));
            Assert.That(createdProduct.StoreId, Is.EqualTo(1));

            // Clean up - remove the created product from the database
            dbContext.Products.Remove(createdProduct);
            await dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task DeleteAsyncValidProductIdShouldSoftDeleteProduct()
        {
            // Arrange

            var product = new Product
            {
                Title = "Test Product",
                Description = "Test Description",
                Price = 100,
                ImageUrl = "https://example.com/test-image.jpg",
                CategoryId = 1,
                ConditionId = 1,
                IsDeleted = false
            };

            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();

            // Act
            await productService.DeleteAsync(product.Id);

            // Assert
            var deletedProduct = await dbContext.Products.FindAsync(product.Id);
            Assert.NotNull(deletedProduct);
            Assert.IsTrue(deletedProduct.IsDeleted);
        }

        [Test]
        public async Task DetailsAsyncExistingProductIdShouldReturnProductDetails()
        {
            // Act
            var productDetails = await productService.DetailsAsync(Product4.Id);

            // Assert
            Assert.NotNull(productDetails);
            Assert.That(productDetails.Id, Is.EqualTo(Product4.Id));
            Assert.That(productDetails.Title, Is.EqualTo(Product4.Title));
            Assert.That(productDetails.Description, Is.EqualTo(Product4.Description));
            Assert.That(productDetails.Price, Is.EqualTo(Product4.Price));
            Assert.That(productDetails.ImageUrl, Is.EqualTo(Product4.ImageUrl));
            Assert.That(productDetails.CategoryName, Is.EqualTo(Product4.Category.Title));
            Assert.That(productDetails.ConditionName, Is.EqualTo(Product4.Condition.Title));
        }

        [Test]
        public async Task EditAsyncValidProductIdShouldUpdateProductDetails()
        {
            var updatedModel = new ProductAddFormModel
            {
                Title = "New Title",
                Description = "New Description",
                Price = 200,
                ImageUrl = "https://example.com/new-image.jpg",
                CategoryId = 1, // Assuming the category with ID 1 exists in seeded data
                ConditionId = 1, // Assuming the condition with ID 1 exists in seeded data
            };

            // Act
            await productService.EditAsync(Product4.Id, updatedModel);

            // Assert
            var editedProduct = await dbContext.Products.FindAsync(Product4.Id);
            Assert.NotNull(editedProduct);
            Assert.That(editedProduct.Title, Is.EqualTo(updatedModel.Title));
            Assert.That(editedProduct.Description, Is.EqualTo(updatedModel.Description));
            Assert.That(editedProduct.Price, Is.EqualTo(updatedModel.Price));
            Assert.That(editedProduct.ImageUrl, Is.EqualTo(updatedModel.ImageUrl));
            Assert.That(editedProduct.CategoryId, Is.EqualTo(updatedModel.CategoryId));
            Assert.That(editedProduct.ConditionId, Is.EqualTo(updatedModel.ConditionId));
        }

        [Test]
        public async Task ExistsByIdAsyncExistingProductIdShouldReturnTrue()
        {
            // Act
            var exists = await productService.ExistsByIdAsync(Product3.Id);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsByIdAsyncNonExistentProductIdShouldReturnFalse()
        {
            // Act
            var exists = await productService.ExistsByIdAsync(999); // Assuming product with ID 999 doesn't exist

            // Assert
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task FillOrderFormModelWithValidUserIdShouldFillOrderFormModel()
        {

            var userId = "F1CCA3DF-6437-423B-6256-08DB7EE9BE60";

            var orderFormModel = new OrderFormModel
            {
                Address = "Test Address",
                FirstName = "John",
                LastName = "Doe",
                CityName = "Test City"
            };

            // Act
            var filledOrderFormModel = await productService.FillOrderFormModel(orderFormModel, userId);

            // Assert
            Assert.That(filledOrderFormModel.Address, Is.EqualTo("Test street 104"));
            Assert.That(filledOrderFormModel.FirstName, Is.EqualTo("Test"));
            Assert.That(filledOrderFormModel.LastName, Is.EqualTo("Test"));
            Assert.That(filledOrderFormModel.CityName, Is.EqualTo("Vratsa"));
        }

        [Test]
        public async Task GetAllCategoriesAsyncShouldReturnAllCategories()
        {

            // Act
            var categories = await productService.GetAllCategoriesAsync();

            // Assert
            Assert.That(categories.Count(), Is.EqualTo(2));
            var firstCategory = categories.First();
            Assert.That(firstCategory.Id, Is.EqualTo(1));
            Assert.That(firstCategory.Title, Is.EqualTo("T-Shirt"));
        }

        [Test]
        public async Task GetAllConditionsAsyncShouldReturnAllConditions()
        {

            // Act
            var conditions = await productService.GetAllConditionsAsync();

            // Assert
            Assert.That(conditions.Count(), Is.EqualTo(2));
            var firstCondition = conditions.First();
            Assert.That(firstCondition.Id, Is.EqualTo(1));
            Assert.That(firstCondition.Title, Is.EqualTo("New"));
        }

        [Test]
        public async Task GetProductForDeleteAsyncShouldReturnProductForDelete()
        {
            // Arrange
            var productId = 1;

            // Act
            var product = await productService.GetProductForDeleteAsync(productId);

            // Assert
            Assert.IsNotNull(product);
            Assert.That(product.Title, Is.EqualTo("T-Shirt - GUESS"));
            Assert.That(product.Description, Is.EqualTo("Made with 100% cotton"));
            Assert.That(product.Price, Is.EqualTo(50.99M));
            Assert.That(product.ImageUrl, Is.EqualTo("https://d010205.bibloo.bg/_galerie/varianty/190/1902771-z.jpg"));
        }

        [Test]
        public async Task GetProductForEditByIdAsyncShouldReturnProductForEdit()
        {
            // Arrange
            
            var productId = 1; 

            // Act
            var productModel = await productService.GetProductForEditByIdAsync(productId);

            // Assert
            Assert.IsNotNull(productModel);
            Assert.That(productModel.Title, Is.EqualTo("T-Shirt - GUESS"));
            Assert.That(productModel.Description, Is.EqualTo("Made with 100% cotton"));
            Assert.That(productModel.Price, Is.EqualTo(50.99M));
            Assert.That(productModel.ImageUrl, Is.EqualTo("https://d010205.bibloo.bg/_galerie/varianty/190/1902771-z.jpg"));
            Assert.That(productModel.CategoryId, Is.EqualTo(1));
            Assert.That(productModel.ConditionId, Is.EqualTo(1));
        }

        [Test]
        public async Task OrderAsyncShouldCreateOrder()
        {
            // Arrange
            var orderFormModel = new OrderFormModel
            {
                Address = "Test Address",
                FirstName = "John",
                LastName = "Doe",
                CityName = "Test City"
            };
            var productId = 1; 
            var storeId = 1; 
            var userId = "F1CCA3DF-6437-423B-6256-08DB7EE9BE60"; 

            // Act
            await productService.OrderAsync(orderFormModel, productId, storeId, userId);

            // Assert
            var createdOrder = await dbContext.Orders.FirstOrDefaultAsync(o => o.ProductId == productId);

            Assert.IsNotNull(createdOrder);
            Assert.That(createdOrder.Address, Is.EqualTo("104 St."));
            Assert.That(createdOrder.FirstName, Is.EqualTo("Bob"));
            Assert.That(createdOrder.LastName, Is.EqualTo("Marley"));
            Assert.That(createdOrder.City, Is.EqualTo("Dermanci"));
            Assert.That(createdOrder.ProductId, Is.EqualTo(productId));
            Assert.That(createdOrder.StoreId, Is.EqualTo(storeId));
        }

    }
}
