using Full_Stack.DataAccess;
using Full_Stack.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Stack.Repository.Implementations
{
    public  class MenuRepository: RepositoryBase<Menu, ApplicationDbContext>,IMenuRepository 
    {
        public MenuRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
