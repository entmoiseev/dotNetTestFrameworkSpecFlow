using BookLibraryTestProject.Models;
using Library;
using Library.Config;


namespace BookLibraryTestProject.Service.Implementation
{
    public class JournalCrudServiceImplementation : AbstractServiceImplementation
    {
        private readonly ApplicationContext ApplicationContext;

        public JournalCrudServiceImplementation(ApplicationContext applicationContext)
        {
            this.ApplicationContext = applicationContext;
        }

        public override void Create(Product journal)
        {
            this.ApplicationContext.Journals.Add((Journal)journal);
            this.ApplicationContext.SaveChanges();
        }

        public override Product GetById(int id)
        {
            return this.ApplicationContext.Journals.Find(id);
        }

        public override void Remove(Product product)
        {
            this.ApplicationContext.Journals.Remove((Journal)product);
            this.ApplicationContext.SaveChanges();
        }

        public override void Update(Product product, Product expectedProduct)
        {
            var Update = this.ApplicationContext.Journals.Find(product.Id);
            Update.JournalName = ((Journal)expectedProduct).JournalName;
            Update.Author = ((Journal)expectedProduct).Author;

            this.ApplicationContext.Entry(Update).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.ApplicationContext.SaveChanges();
        }
    }
}
