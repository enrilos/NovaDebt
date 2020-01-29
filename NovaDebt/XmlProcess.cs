using AutoMapper;
using NovaDebt.Models;
using NovaDebt.Models.Contracts;
using NovaDebt.Models.DTOs;
using NovaDebt.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace NovaDebt
{
    public static class XmlProcess
    {
        public static IEnumerable<ITransactor> DeserializeXml(string path, TransactorType transactorType)
        {
            if (path == null)
            {
                throw new ArgumentNullException("Path cannot be null.");
            }
            if (!File.Exists(path))
            {
                throw new InvalidOperationException("File doesn't exist.");
            }

            string xmlText = File.ReadAllText(path);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TransactorDTO[]),
                                          new XmlRootAttribute("Transactors"));

            TransactorDTO[] transactorDTOs = (TransactorDTO[])xmlSerializer.Deserialize(new StringReader(xmlText));

            Transactor[] transactors = Mapper.Map<Transactor[]>(transactorDTOs)
                                       .Where(t => t.TransactorType.ToLower() == transactorType.ToString().ToLower())
                                       .ToArray();

            for (int i = 0; i < transactors.Length; i++)
            {
                transactors[i].Id = i + 1;
            }

            return transactors;
        }
    }
}
