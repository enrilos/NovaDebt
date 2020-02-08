using AutoMapper;
using NovaDebt.Models;
using NovaDebt.Models.DTOs;
using NovaDebt.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using static NovaDebt.DataSettings;

namespace NovaDebt
{
    public static class XmlProcess
    {
        public static IEnumerable<Transactor> DeserializeXml(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(ErrorMessage.PathCannotBeNull);
            }
            if (!File.Exists(path))
            {
                throw new InvalidOperationException(ErrorMessage.FileDoesntExist);
            }

            string xmlText = File.ReadAllText(path);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TransactorDTO[]),
                                          new XmlRootAttribute(DefaultXmlRoot));

            TransactorDTO[] transactorDTOs = (TransactorDTO[])xmlSerializer.Deserialize(new StringReader(xmlText));

            Transactor[] transactors = Mapper.Map<Transactor[]>(transactorDTOs).ToArray();

            return transactors;
        }
        
        public static IEnumerable<Transactor> DeserializeXmlWithTransactorType(string path, TransactorType transactorType)
        {
            if (path == null)
            {
                throw new ArgumentNullException(ErrorMessage.PathCannotBeNull);
            }
            if (!File.Exists(path))
            {
                throw new InvalidOperationException(ErrorMessage.FileDoesntExist);
            }

            string xmlText = File.ReadAllText(path);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TransactorDTO[]),
                                          new XmlRootAttribute(DefaultXmlRoot));

            TransactorDTO[] transactorDTOs = (TransactorDTO[])xmlSerializer.Deserialize(new StringReader(xmlText));

            Transactor[] transactors = Mapper.Map<Transactor[]>(transactorDTOs)
                                       .Where(t => t.TransactorType.ToLower() == transactorType.ToString().ToLower())
                                       .ToArray();

            return transactors;
        }

        public static void SerializeXmlWithTransactors(string path, IEnumerable<Transactor> transactors)
        {
            StringBuilder result = new StringBuilder();

            if (path == null)
            {
                throw new ArgumentNullException(ErrorMessage.PathCannotBeNull);
            }
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            else
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(TransactorDTO[]),
                                              new XmlRootAttribute(DefaultXmlRoot));

                // Removing only the unnecessary namespace headers.
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                TransactorDTO[] transactorDTOs = Mapper.Map<TransactorDTO[]>(transactors).ToArray();

                using (StringWriter writer = new StringWriter(result))
                {
                    // TODO: It will be a good idea to serialize without spaces, line breaks.
                    xmlSerializer.Serialize(writer, transactorDTOs, namespaces);
                }

                File.WriteAllText(path, result.ToString());
            }
        }

        public static void AddTransactorToXml(string path, string name, string phone, string email, decimal amount, string facebook, string transactorType)
        {
            if (path == null)
            {
                throw new ArgumentNullException(ErrorMessage.PathCannotBeNull);
            }
            if (!File.Exists(path))
            {
                throw new InvalidOperationException(ErrorMessage.FileDoesntExist);
            }
            if (name == null)
            {
                throw new ArgumentNullException(ErrorMessage.NameCannotBeNull);
            }

            Transactor transactor = new Transactor(name, phone, email, facebook, amount, transactorType);
            HashSet<Transactor> transactors = XmlProcess.DeserializeXml(path).ToHashSet();

            transactor.Id = transactors.Count + 1;

            HashSet<Transactor> transactorTypeNos = transactors.Where(t => t.TransactorType == transactorType).ToHashSet();
            transactor.No = transactorTypeNos.Count + 1;

            // In the adding action, serializing the whole entry is too complex.
            // I just need to put the new record in the last lines of the xml before the root closing tag.
            // 'Cause I don't change the other records in any way.
            // I just get the count of collections of them.
            // That's why it will be a lot better if I just edit the xml file at the end (put the new record)
            // Not to overwrite the whole file just to add a chunk of data.
            transactors.Add(transactor);
            XmlProcess.SerializeXmlWithTransactors(path, transactors.ToArray());
        }
    }
}
