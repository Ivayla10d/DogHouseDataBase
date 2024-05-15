using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsHouse11d.Model
{
    public class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //"1:M
        public ICollection<Dog> Dogs { get; set; }
    }
}
