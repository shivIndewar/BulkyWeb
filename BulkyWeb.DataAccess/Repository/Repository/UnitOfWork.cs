using BulkyWeb.DataAccess.Data;
using BulkyWeb.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.DataAccess.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _db;
        public ICategoryRepository categoryRepository { get; private set; }
        public IProductRepository productRepository { get; private set; }
        public UnitOfWork(ApplicationDBContext db)
        {
                _db = db;
                categoryRepository = new CategoryRepository(db);
                productRepository = new ProductRepository(db);  
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
