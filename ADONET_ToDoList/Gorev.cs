using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_ToDoList
{
    public class Gorev
    {
        public int Id { get; set; }
        public string Konu { get; set; }
        public bool Durum { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime? GuncellemeTarihi { get; set; }

        public override string ToString()
        {
            if (Durum == true)
            {
                return Konu + "(Yapıldı)";
            }
            else
            {
                return Konu + "(Yapılacak)";
            }
        }
    }
}
