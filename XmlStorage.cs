using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace BudzetDomowy
{
    public static class XmlStorageTypes //Dodaje typy do listy typów
    {
        private static readonly List<Type> KnownTypes = new List<Type>() { typeof(object) };

        public static void Register<T>()
        {
            Type _oType = typeof(T);

            if (!KnownTypes.Contains(_oType))
            {
                KnownTypes.Add(_oType);
            }
        }

        public static Type[] GetArray() => KnownTypes.ToArray();
    }

    [DataContract]
    public abstract class XmlStorage<T> : IXmlStorage where T : class
    {
        [IgnoreDataMember]
        public T BaseObject { get; protected set; }

        public virtual bool FromXml(Stream a_oStream) //Odczyt z XML
        {
            DataContractSerializer _oSerializer = new DataContractSerializer(typeof(T), XmlStorageTypes.GetArray());

            using var _oReader = XmlDictionaryReader.CreateTextReader(a_oStream, new XmlDictionaryReaderQuotas());

            return InitializeFromObject((T)_oSerializer.ReadObject(_oReader, false));
        }

        public virtual MemoryStream ToXml() //Zapis do XML
        {
            DataContractSerializer _oSerializer = new DataContractSerializer(typeof(T), XmlStorageTypes.GetArray());

            using var _oStream = new MemoryStream();

            using var _oWriter = XmlDictionaryWriter.CreateTextWriter(_oStream, Encoding.UTF8);

            _oSerializer.WriteObject(_oWriter, this);

            return _oStream;
        }

        public abstract bool InitializeFromObject(T Object); // potrzebne do przywracaania z XML
    }
}
