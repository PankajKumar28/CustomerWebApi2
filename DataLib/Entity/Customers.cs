using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Entity
{
    public class Customers
    {
        [Key]
        public Guid CustomerId { get; set; }
        public string? FullName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        //public int AddedBy { get; set; }
        //public int? ModifiedBy { get; set; }
    }
}
