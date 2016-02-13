using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zalagaonica.DomanModel;

namespace Zalagaonica
{
   public class TrenutniKorisnik
    {
       private static ZaposleniClass trenutniKorisnik;
       public static ZaposleniClass getTrenutniKorisnik()
       {
           return trenutniKorisnik;
       }
       public static void setTrenutniKorisnik(ZaposleniClass trenutni_korisnik)
       {
           trenutniKorisnik = trenutni_korisnik; 
       }

    }
}
