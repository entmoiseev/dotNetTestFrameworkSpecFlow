using BookLibraryTestProject.Models;
using Library;
using Library.Config;
using Library.Service;


namespace BookLibraryTestProject.Service.Implementation
{
    public class BookCrudServiceImplementation : AbstractServiceImplementation
    {
        private readonly ApplicationContext ApplicationContext;

        public BookCrudServiceImplementation(ApplicationContext applicationContext)
        {
            this.ApplicationContext = applicationContext;
        }

        public override void Create(Product book)
        {
            this.ApplicationContext.Books.Add((Book)book);
            this.ApplicationContext.SaveChanges();
        }


        public override Product GetById(int id)
        {
            return this.ApplicationContext.Books.Find(id);
        }

        public override void Remove(Product product)
        {
            this.ApplicationContext.Books.Remove((Book)product);
            this.ApplicationContext.SaveChanges();
        }

        public override void Update(Product product, Product expectedProduct)
        {
            var Update = this.ApplicationContext.Books.Find(product.Id);
            Update.BookName = ((Book)expectedProduct).BookName;
            Update.Author = ((Book)expectedProduct).Author;

            this.ApplicationContext.Entry(Update).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.ApplicationContext.SaveChanges();
        }
    }
}
