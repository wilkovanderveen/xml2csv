using System.Xml;

namespace Xml2Csv.Core
{
    public class XmlContentConverter
    {
        private readonly DocumentConverter documentConverter;

        public XmlContentConverter(DocumentConverter documentConverter)
        {
            this.documentConverter = documentConverter;
        }

        public string Convert(string inputXml)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(inputXml);

            return documentConverter.Convert(xmlDocument);
        }
    }
}
