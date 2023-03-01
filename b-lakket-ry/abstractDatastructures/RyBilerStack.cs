using b_lakket_ry.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_lakket_ry.abstractDatastructures
{
    /// <summary>
    /// Implementering der benytter Stack
    /// </summary>
    public class RyBilerStack : IRyBiler
    {
        private Stack<Bil> _biler;

        public RyBilerStack()
        {
            _biler = new Stack<Bil>(MockDataFactory.GetBiler);
        }




        /*
         * Implementerer interface
         */
        public Bil FindBilVedId(int id)
        {
            /*
             * Not really meaning of a stack to look inside the stack
             */
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
            /*
             * Not really meaning of a stack to look inside the stack
             */
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
            return _biler.Peek();  // look at the top
        }

        public ICollection<Bil> FindRødeBiler()
        {
            /*
             * Not really meaning of a stack to look inside the stack
             */
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

            /*
             * Not really meaning of a stack to look at the buttom of the stack
             */
            return _biler.First();
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
                _biler.Push(bil);
            }
        }
    }
}
