using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInstruments.Infrastructure.Repository
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;

        public CommandRepository(IDbContext context)
        {
            this._context = context;
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public int SaveChanges()
        {
           return  _context.SaveChanges();
        }

    }
}
