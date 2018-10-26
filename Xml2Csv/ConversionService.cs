using System.IO;

namespace Xml2Csv.Core
{
    public class ConversionService
    {
        private readonly ConversionServiceOptions options;
        private readonly XmlContentConverter xmlContentConverter;

        public ConversionService(ConversionServiceOptions options, XmlContentConverter xmlContentConverter)
        {
            this.options = options;
            this.xmlContentConverter = xmlContentConverter;
        }

        public void Convert(string inputFile, string outputFile)
        {
            if (!File.Exists(inputFile))
            {
                throw new FileNotFoundException("Input file not found", inputFile);
            }

            if (File.Exists(outputFile) && !options.OverwriteFileIfExists)
            {
                throw new IOException("File {outputFile} already exists");
            }

            var xmlContent = File.ReadAllText(inputFile); 
            var csvContent = xmlContentConverter.Convert(xmlContent);          

            File.WriteAllText(outputFile, csvContent);
        }
    }
}
