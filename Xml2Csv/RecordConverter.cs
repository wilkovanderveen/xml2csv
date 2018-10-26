using System;
using System.Text;
using System.Xml;

namespace Xml2Csv.Core
{

    public class RecordConverter
    {
        public RecordConverter(RecordConverterOptions options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        private readonly RecordConverterOptions options;

        public string Convert(XmlNode recordNode)
        {
            StringBuilder csvRecordStringBuilder = new StringBuilder();
            foreach (XmlNode childNode in recordNode.ChildNodes)
            {
                csvRecordStringBuilder.Append(childNode.InnerText);
                csvRecordStringBuilder.Append(options.FieldSeperator);
            }     

            return csvRecordStringBuilder.ToString();
        }
    }
}
