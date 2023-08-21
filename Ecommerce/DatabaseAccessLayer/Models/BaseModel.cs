using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Models
{
    public abstract class BaseModel //Abstract classs - class that does not have a
                           //constructor, members can be overridden and must be
                           //inherited for it to be used
    {
        public DateTime CreatedAt { set;  get; } = DateTime.Now;
        public DateTime? UpdatedAt { set; get; } // The ? implies its nullable
        public Guid Id { set; get; } = Guid.NewGuid(); //similar to uuid in python
        // Automatically assigns a new Id to an instance
        public string? UserId { set; get; }

    }
}
