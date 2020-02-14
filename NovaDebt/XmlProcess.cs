using AutoMapper;
using NovaDebt.Models;
using NovaDebt.Models.DTOs;
using NovaDebt.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

using static NovaDebt.DataSettings;

namespace NovaDebt
{
    public static class XmlProcess
    {
        public static IEnumerable<Transactor> DeserializeXmlWithTransactorType(string path, TransactorType transactorType)
        {
            if (path == null)
            {
                throw new NullReferenceException(ErrorMessage.PathCannotBeNull);
            }
            if (!File.Exists(path))
            {
                throw new InvalidOperationException(ErrorMessage.FileDoesntExist);
            }

            string xmlText = File.ReadAllText(path);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TransactorDTO[]),
                                          new XmlRootAttribute(XmlRoot));

            TransactorDTO[] transactorDTOs = (TransactorDTO[])xmlSerializer.Deserialize(new StringReader(xmlText));

            Transactor[] transactors = Mapper.Map<Transactor[]>(transactorDTOs)
                                       .Where(t => t.TransactorType.ToLower() == transactorType.ToString().ToLower())
                                       .ToArray();

            return transactors;
        }

        public static void AddTransactorToXml(string path, string name, string since, string dueDate, string phone, string email, decimal amount, string facebook, string transactorType)
        {
            if (path == null)
            {
                throw new NullReferenceException(ErrorMessage.PathCannotBeNull);
            }
            if (!File.Exists(path))
            {
                throw new InvalidOperationException(ErrorMessage.FileDoesntExist);
            }

            Transactor transactor = new Transactor(name, since, dueDate, phone, email, facebook, amount, transactorType);
            int idCount = int.Parse(File.ReadAllText(IdCounterFilePath));
            transactor.Id = idCount++;
            File.WriteAllText(IdCounterFilePath, idCount.ToString());

            XDocument xmlDocument = XDocument.Load(TransactorsFilePath);

            IEnumerable<XElement> transactorsWithType = xmlDocument
                .Element("Transactors")
                .Elements("Transactor")
                .Where(x => x.Element("TransactorType").Value == transactorType);

            transactor.No = transactorsWithType.Count() + 1;


            xmlDocument.Element("Transactors")
                .Add(new XElement("Transactor", new XAttribute("id", transactor.Id), new XAttribute("no", transactor.No),
                        new XElement("Name", name),
                        new XElement("Since", since),
                        new XElement("DueDate", dueDate),
                        new XElement("PhoneNumber", phone),
                        new XElement("Email", email),
                        new XElement("Facebook", facebook),
                        new XElement("Amount", amount),
                        new XElement("TransactorType", transactorType)));

            xmlDocument.Save(TransactorsFilePath, SaveOptions.DisableFormatting);
        }
    }
}
