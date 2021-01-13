using Library.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryTestProject.Service.Implementation
{
    public class ServiceCrudFactory
    {

        public static AbstractServiceImplementation GetFactory(string product, ApplicationContext applicationContext)
        {

            AbstractServiceImplementation abstractServiceImplementation = null;
            switch (product)
            {
                case "book":
                    abstractServiceImplementation = new BookCrudServiceImplementation(applicationContext);
                    break;
                case "journal":
                    abstractServiceImplementation = new JournalCrudServiceImplementation(applicationContext);
                    break;

            }

            return abstractServiceImplementation;
        }
    }
}
