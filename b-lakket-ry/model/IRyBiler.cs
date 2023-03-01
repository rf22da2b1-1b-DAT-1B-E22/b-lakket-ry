using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_lakket_ry.model
{
    public interface IRyBiler
    {
        public ICollection<Bil> HentAlleBiler();
        public void Tilføj(Bil bil);
        public ICollection<Bil> FindRødeBiler();
        public Bil FindBilVedId(int id);
        public Bil FindBilVedRegistreringsNummer(string regNummer);
        public Bil FindÆldsteBil();
        public Bil FindNyesteBil();
    }
}
