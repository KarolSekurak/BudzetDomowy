using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace BudzetDomowy.BusinessLogic
{
    [DataContract]
    public class User : XmlStorage<User>
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Imie { get; set; }
        [DataMember]
        public string Nazwisko { get; set; }
        [DataMember]
        public int id_usera { get; set; }
        [DataMember]
        public DateTime DodanieUzytkownika { get; set; }


        static public void DodajUsera(string _login, string _haslo, string _Imie, string _Nazwisko, int _id_usera, DateTime _DodanieUzytkownika) { }
        static public int WyszukajUsera() { return 0; }
        static public void UsunUsera(int _id_usera) { }
        static public void EdytujUsera(int _id_usera) { }
        static public void WyswietlUsera(int _id_usera) { }

        public User()
        {
            this.BaseObject = this;
        }

        public override bool InitializeFromObject(User Object)
        {
            this.Login = Object.Login;
            this.Password = Object.Password;

            return true;
        }
    }
}
