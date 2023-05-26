using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Stack.Entity
{
    [Table("Menu")]
    public class Menu
    {
        public int Id { get; set; }
        public int? ParentID { get; set; }
        public string Name { get; set; }
    }
}
