using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone.Entities
{
    public class GuideRecord// Yeni istifadeci elave et 
    {
        //evez olunmayan tip
        public Guid _ID { get; set; }
        public string _name { get; set; }
        public string _surname { get; set; }
        public string _phoneNumber1 { get; set; }
        public string _phoneNumber2 { get; set; }
        public string _phoneNumber3 { get; set; }
        public string _adress { get; set; }
        public string _emailAdress { get; set; }
        public string _text { get; set; }

        public override string ToString()
        {
            return $"{_name}  {_surname}";
        }
    }
}
