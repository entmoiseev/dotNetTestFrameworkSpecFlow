using Library.Config;
using TechTalk.SpecFlow;

using BookLibraryTestProject.Models;
using BookLibraryTestProject.Actions;
using Library;

namespace BookLibraryTestProject.Steps
{
    [Binding]
    public class LibrarySteps
    {

        private readonly ScenarioContext ScenarioContext;
        private readonly ApplicationContext ApplicationContext;

        private readonly LibraryActions libraryActions;


        public LibrarySteps(ScenarioContext scenarioContext, ApplicationContext applicationContext)
        {
            this.ScenarioContext = scenarioContext;
            this.ApplicationContext = applicationContext;
            this.libraryActions = new LibraryActions(this.ApplicationContext);

        }


        [Given(@"add new '(.*)' to library")]
        public void GivenAddNewBookToLibrary(string product, Table table)
        {
            Product Product = this.libraryActions.CreateProduct(product, table);
            this.ScenarioContext.Add(product, Product);

        }

        [Then(@"verify that '(.*)' was added")]
        public void ThenVerifyThatBookWasAdded(string type)
        {

            Product book = this.ScenarioContext.Get<Product>(type);
            this.libraryActions.VerifyProduct(type, book);

        }

        [When(@"update last created '(.*)' info with following parameters")]
        public void UpdateLastCreatedProduct(string type, Table table)
        {
            Product product = this.ScenarioContext.Get<Product>(type);
            this.libraryActions.UpdateProduct(type, product, table);
            Product expectedProduct = this.libraryActions.GetProductById(type, product.Id);
            this.ScenarioContext.Remove(type);
            this.ScenarioContext.Add(type, expectedProduct);

        }


        [When(@"delete last created '(.*)' info")]
        public void DeleteLastCreatedProduct(string type)
        {
            Product product = this.ScenarioContext.Get<Product>(type);
            this.libraryActions.RemoveProduct(type, product);
        }

        [Then(@"last created '(.*)' was updated with following parameters")]
        public void LastCreatedProductWasUpdated(string type, Table table)
        {
            Product product = this.ScenarioContext.Get<Product>(type);
            this.libraryActions.ValidateProduct(type, product, table);

        }

        [Then(@"last created '(.*)' was deleted")]
        public void LastCreatedProductWasDeleted(string type)
        {
            Product product = this.ScenarioContext.Get<Product>(type);
            Product expectedProduct =  this.libraryActions.GetProductById(type, product.Id);
            this.libraryActions.ValidateProductIsDeleted(expectedProduct);

        }
    }
}
