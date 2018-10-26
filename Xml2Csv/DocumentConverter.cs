using System.Text;
using System.Xml;

namespace Xml2Csv.Core
{
    public class DocumentConverter
    {
        private readonly HeaderConverter headerConverter;
        private readonly RecordConverter recordConverter;
        private readonly DocumentConverterOptions options;

        public DocumentConverter(HeaderConverter headerConverter, RecordConverter recordConverter, DocumentConverterOptions options)
        {
            this.headerConverter = headerConverter;
            this.recordConverter = recordConverter;
            this.options = options;
        }

        public string Convert(XmlDocument xmlDocument)
        {
            StringBuilder csvDocumentStringBuilder = new StringBuilder();

            var rootNode = xmlDocument.SelectSingleNode("*");

            var headerNode = rootNode.FirstChild;
            csvDocumentStringBuilder.Append(headerConverter.Convert(headerNode));
            csvDocumentStringBuilder.Append(options.RecordSeperator);

            foreach (XmlNode childNode in rootNode.ChildNodes)
            {
                csvDocumentStringBuilder.Append(recordConverter.Convert(childNode));
                csvDocumentStringBuilder.Append(options.RecordSeperator);
            }

            return csvDocumentStringBuilder.ToString();
        }
    }
}
