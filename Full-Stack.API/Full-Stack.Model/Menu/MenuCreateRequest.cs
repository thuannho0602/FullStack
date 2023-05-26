using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Stack.Model.Menu
{
    public class MenuCreateRequest
    {
        public int Id { get; set; }
        public int? ParentID { get; set; }
        public string Name { get; set; }
    }
}
