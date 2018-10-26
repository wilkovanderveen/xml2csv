using System;
using Xunit;

namespace Xml2Csv.Core.Test
{
   public class DocumentTest
    {
        [Fact]
        public void DoSomething()
        {
            RecordConverterOptions recordConverterOptions = new RecordConverterOptions { FieldSeperator = ';' };

            HeaderConverter headerConverter = new HeaderConverter(recordConverterOptions);
            RecordConverter recordConverter = new RecordConverter(recordConverterOptions);
            DocumentConverter documentConverter = new DocumentConverter(headerConverter, recordConverter, new DocumentConverterOptions { RecordSeperator = "\n" });
            XmlContentConverter contentConverter = new XmlContentConverter(documentConverter);

            var xml = "<document> <record> <id>1</id> <name>RECORD_1</name> <description>First record</description> </record> <record> <id>2</id> <name>RECORD_2</name> <description>Second record</description> </record> <record> <id>3</id> <name>RECORD_3</name> <description>Third record</description> </record> </document> ";

            var csv = contentConverter.Convert(xml);

            Assert.True(!string.IsNullOrWhiteSpace(csv));
            Assert.True(csv.Length == 97);            
        }     
    }
}
