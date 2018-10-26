using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Xml2Csv.Core
{
    public class HeaderConverter
    {
        private readonly RecordConverterOptions recordConverterOptions;

        public HeaderConverter(RecordConverterOptions recordConverterOptions)
        {
            this.recordConverterOptions = recordConverterOptions;
        }

        public string Convert(XmlNode headerNode)
        {
            StringBuilder csvRecordStringBuilder = new StringBuilder();
            foreach (XmlNode childNode in headerNode.ChildNodes)
            {
                csvRecordStringBuilder.Append(childNode.LocalName);
                csvRecordStringBuilder.Append(recordConverterOptions.FieldSeperator);
            }

            return csvRecordStringBuilder.ToString();
        }
    }
}
