using b_lakket_ry.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_lakket_ry.abstractDatastructures
{
    /// <summary>
    /// Implementering der benytter HashSet
    /// </summary>
    public class RyBilerDictionary : IRyBiler
    {
        private Dictionary<int,Bil> _biler;

        public RyBilerDictionary()
        {
            _biler= new Dictionary<int,Bil>();
            foreach (var b in MockDataFactory.GetBiler) 
            {
                _biler.Add(b.Id,b);
            }
        }




        /*
         * Implementerer interface
         */
        public Bil FindBilVedId(int id)
        {
            if (!_biler.ContainsKey(id))
            {
                throw new KeyNotFoundException();
            }
            return _biler[id];
        }

        public Bil FindBilVedRegistreringsNummer(string regNummer)
        {
            foreach (var bil in _biler.Values)  // obs use values
            {
                if (bil.RegistreringsNr == regNummer)
                {
                    return bil;
                }
            }

            throw new KeyNotFoundException();
        }

        public Bil FindNyesteBil()
        {
            if (_biler.Count == 0)
            {
                throw new ArgumentException("no cars in collection");
            }
            return _biler.Last().Value;
        }

        public ICollection<Bil> FindRødeBiler()
        {
            ICollection<Bil> rødeBiler = new List<Bil>();
            foreach (Bil bil in _biler.Values)    // obs use values
            {
                if (bil.Farve.ToLower() == "rød")
                {
                    rødeBiler.Add(bil);
                }
            }

            return rødeBiler;
        }

        public Bil FindÆldsteBil()
        {
            if (_biler.Count == 0)
            {
                throw new ArgumentException("no cars in collection");
            }

            return _biler.First().Value;
        }

        public ICollection<Bil> HentAlleBiler()
        {
            return new List<Bil>(_biler.Values);  // obs use values
        }

        public void Tilføj(Bil bil)
        {
            _biler.Add(bil.Id,bil); 
        }
    }
}
