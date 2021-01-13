using BookLibraryTestProject.Models;
using BookLibraryTestProject.Service.Implementation;

using Library;
using Library.Config;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

using FluentAssertions;

namespace BookLibraryTestProject.Actions
{
    public class LibraryActions
    {
        private readonly ApplicationContext ApplicationContext;

        public LibraryActions(ApplicationContext applicationContext)
        {
            this.ApplicationContext = applicationContext;

        }
        public Product CreateProduct(string type, Table table)
        {
            AbstractServiceImplementation abstractServiceImplementation = ServiceCrudFactory.GetFactory(type, this.ApplicationContext);
            Product product = ConvertDataTableToProduct(type, table);
            abstractServiceImplementation.Create(product);

            return product;
        }

        public Product GetProductById(string type, int id)
        {
            AbstractServiceImplementation abstractServiceImplementation = ServiceCrudFactory.GetFactory(type, this.ApplicationContext);
            return abstractServiceImplementation.GetById(id);
        }

        public void VerifyProduct(string type, Product product)
        {
            AbstractServiceImplementation abstractServiceImplementation = ServiceCrudFactory.GetFactory(type, this.ApplicationContext);
            Product expectedProduct = this.GetProductById(type, product.Id);
            expectedProduct.Should().NotBeNull();
        }

        public void UpdateProduct(string type, Product product, Table table)
        {
            AbstractServiceImplementation abstractServiceImplementation = ServiceCrudFactory.GetFactory(type, this.ApplicationContext);
            Product expectedProduct = ConvertDataTableToProduct(type, table);
            abstractServiceImplementation.Update(product, expectedProduct);
        }

        public void RemoveProduct(string type, Product product)
        {
            AbstractServiceImplementation abstractServiceImplementation = ServiceCrudFactory.GetFactory(type, this.ApplicationContext);
            abstractServiceImplementation.Remove(product);
        }

        public void ValidateProduct(string type, Product product, Table table)
        {
            Product expectedProduct = this.ConvertDataTableToProduct(type, table);
            if (type == "book")
            {
                ((Book)product).Should().BeEquivalentTo((Book)expectedProduct, options => options.Excluding(x => x.Id));
            }
            else
            {
                ((Journal)product).Should().BeEquivalentTo((Journal)expectedProduct, options => options.Excluding(x => x.Id));
            }

        }

        public void ValidateProductIsDeleted(Product product)
        {
            product.Should().BeNull();
        }


        private Product ConvertDataTableToProduct(string type, Table table)
        {
            Product product;
            if (type == "book")
            {
                product = table.CreateInstance<Book>();
            }
            else
            {
                product = table.CreateInstance<Journal>();
            }
            return product;
        }
    }
}
