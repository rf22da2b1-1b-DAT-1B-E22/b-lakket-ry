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
    public class RyBilerHashSet : IRyBiler
    {
        private HashSet<Bil> _biler;

        public RyBilerHashSet()
        {
            _biler = new HashSet<Bil>(MockDataFactory.GetBiler);
        }




        /*
         * Implementerer interface
         */
        public Bil FindBilVedId(int id)
        {
            foreach (var bil in _biler)
            {
                if (bil.Id == id)
                {
                    return bil;
                }
            }
            throw new KeyNotFoundException();
        }

        public Bil FindBilVedRegistreringsNummer(string regNummer)
        {
            foreach (var bil in _biler)
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
            return _biler.Last();
        }

        public ICollection<Bil> FindRødeBiler()
        {
            ICollection<Bil> rødeBiler = new List<Bil>();
            foreach (Bil bil in _biler)
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

            return _biler.First();
        }

        public ICollection<Bil> HentAlleBiler()
        {
            return new List<Bil>(_biler);
        }

        public void Tilføj(Bil bil)
        {
            _biler.Add(bil); // hashset ensures no dublecates
        }

    }
}
