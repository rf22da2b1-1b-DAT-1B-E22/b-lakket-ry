using b_lakket_ry.abstractDatastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_lakket_ry.model
{
    /// <summary>
    /// Implementering der benytter List
    /// </summary>
    public class RyBilerListe : IRyBiler
    {
        private List<Bil> _biler;

        public RyBilerListe()
        {
            _biler = new List<Bil>(MockDataFactory.GetBiler);
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
            return _biler.Last();   // or
            //return _biler[_biler.Count - 1];

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
            return _biler.First();     // or
            //return _biler[0];
        }

        public ICollection<Bil> HentAlleBiler()
        {
            return new List<Bil>(_biler);
        }

        public void Tilføj(Bil bil)
        {
            try
            {
                FindBilVedId(bil.Id);
                throw new ArgumentException("Bil findes i forvejen");
            }
            catch(KeyNotFoundException knfe)
            {
                // findes ikke => altså indsættes
                _biler.Add(bil);
            }
        }
    }
}
