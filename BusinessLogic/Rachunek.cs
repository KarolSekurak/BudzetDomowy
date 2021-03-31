using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BudzetDomowy
{
    [DataContract]
    class Rachunek : XmlStorage<Rachunek>
    {
        [DataMember]
        public int id_rachunku { get; set; }
        [DataMember]
        public DateTime data_wprowadzenia { get; set; }
        [DataMember]
        public int kwota { get; set; }
        [DataMember]
        static public int KtoWprowadzil { get; set; }
        [DataMember]
        static public int KogoDotyczy { get; set; }
        [DataMember]
        public string kategoria { get; set; }



        static public void DodajRachunek(int _id_rachunku, DateTime _data_wprowadzenia, int _Kwota, int _KtoWprowadzil, int _KogoDotyczy) { }
        
        static public int WyszukajRachunek() { return 0; }
        static public void UsunRachunek(int _id_rachunku) { }
        static public void EdytujRachunek(int _id_rachunku) { }
        static public void WyswietlRachunek(int _id_rachunku) { }

        public Rachunek()
        {
            this.BaseObject = this;
        }

        public override bool InitializeFromObject(Rachunek Object)
        {
            //this.Login = Object.Login;
            //this.Password = Object.Password;

            return true;
        }

    }
}
