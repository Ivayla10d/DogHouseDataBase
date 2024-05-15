using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsHouse11d.Model
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Registration { get; set; }


        //M:1
        public int BreedsId { get; set; }
        public Breed Breeds { get; set; }
    }
}
