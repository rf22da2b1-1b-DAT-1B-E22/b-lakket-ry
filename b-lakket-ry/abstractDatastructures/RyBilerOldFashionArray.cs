using b_lakket_ry.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_lakket_ry.abstractDatastructures
{
    public class RyBilerOldFashionArray : IRyBiler
    {
        private Bil[] _biler;
        private int _nextBil = 0;

        public RyBilerOldFashionArray()
        {
            _biler = new Bil[20];
            foreach (Bil b in MockDataFactory.GetBiler)
            {
                _biler[_nextBil++] = b;
            }
        }





        /*
         * Implementerer interface
         */
        public Bil FindBilVedId(int id)
        {
            for (int i = 0; i < _nextBil; i++)
            {
                if (_biler[i].Id == id)
                {
                    return _biler[i];
                }
            }

            throw new KeyNotFoundException();
        }

        public Bil FindBilVedRegistreringsNummer(string regNummer)
        {
            for (int i = 0; i < _nextBil; i++)
            {
                if (_biler[i].RegistreringsNr == regNummer)
                {
                    return _biler[i];
                }
            }

            throw new KeyNotFoundException();
        }

        public Bil FindNyesteBil()
        {
            if (_biler.Length == 0)
            {
                throw new ArgumentException("no cars in collection");
            }
            return _biler[_nextBil-1];

        }

        public ICollection<Bil> FindRødeBiler()
        {
            ICollection<Bil> rødeBiler = new List<Bil>();
            for (int i = 0; i < _nextBil; i++)
            {
                if (_biler[i].Farve.ToLower() == "rød")
                {
                    rødeBiler.Add(_biler[i]);
                }
            }

            return rødeBiler;
        }

        public Bil FindÆldsteBil()
        {
            if (_nextBil == 0)
            {
                throw new ArgumentException("no cars in collection");
            }
            return _biler[0];
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
            catch (KeyNotFoundException knfe)
            {
                // findes ikke => altså indsættes
                _biler[_nextBil++] = bil;
            }
        }
    }
}
