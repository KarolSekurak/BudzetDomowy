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
