using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techMADT2.Core.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        public string Message { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
