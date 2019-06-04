using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        public string _name { get; set; }
        public string _password { get; set;}
    }
}
