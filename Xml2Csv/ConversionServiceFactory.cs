namespace Xml2Csv.Core
{
    public class ConversionServiceFactory
    {
        public ConversionService GetConversionService(char fieldSeperator, string recordSeperator, bool overwriteFileIfExists)
        {
            RecordConverterOptions recordConverterOptions = new RecordConverterOptions { FieldSeperator = fieldSeperator };

            HeaderConverter headerConverter = new HeaderConverter(recordConverterOptions);
            RecordConverter recordConverter = new RecordConverter(recordConverterOptions);
            DocumentConverter documentConverter = new DocumentConverter(headerConverter, recordConverter, new DocumentConverterOptions { RecordSeperator = recordSeperator });
            XmlContentConverter fileConverter = new XmlContentConverter(documentConverter);
            ConversionService conversionService = new ConversionService(new ConversionServiceOptions { OverwriteFileIfExists = overwriteFileIfExists }, fileConverter);

            return conversionService;
        }
    }
}
