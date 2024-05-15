using DogsHouse11d.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsHouse11d.Controller
{
    public class BreedsControler
    {
        private DogsDbContext _dogsDbContext = new DogsDbContext();

        public List<Breed> GetAllBreeds()
        {
            return _dogsDbContext.Breeds.ToList();
        }
        public string GetBreedById(int id)
        {
            return _dogsDbContext.Breeds.Find(id).Name;
        }
    }
}
