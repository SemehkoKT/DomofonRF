using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект2
{
    class DataBase1
    {
        private static Entities _context;
        public static Entities GetContext()
        {
            if (_context == null)
                _context = new Entities();
            return _context; 
            
            _context.SaveChanges();
            _context.ChangeTracker.Entries().ToList().ForEach(p =>p.Reload());

        }
       
        public static void SaveChanges()
        {
          
        }
    }
}
