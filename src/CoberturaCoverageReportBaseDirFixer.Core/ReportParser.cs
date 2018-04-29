using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CoberturaCoverageReportBaseDirFixer.Core
{
    public class ReportParser
    {
        private IFileStreamFactory fileStreamFactory;
        private IBasePathFixer basePathFixer;

        public ReportParser(IFileStreamFactory fileStreamFactory, IBasePathFixer basePathFixer)
        {
            this.fileStreamFactory = fileStreamFactory;
            this.basePathFixer = basePathFixer;
        }

        public void Parse(string inputFileName, string outputFileName, string basePath)
        {
            var inputStream = this.fileStreamFactory.OpenFile(inputFileName);
            var outputStream = this.fileStreamFactory.CreateFile(outputFileName);

            var doc = new XmlDocument();
            doc.Load(inputStream);

            ParseNodes(doc.ChildNodes, basePath);
            doc.Save(outputStream);
          
        }

        private void ParseNodes(XmlNodeList nodes, String basePath)
        {
            foreach(var nodeObject in nodes)
            {
                var node = (XmlNode)nodeObject;

                if (node.Name == "class")
                    node.Attributes["filename"].Value = this.basePathFixer.FixPath(basePath, node.Attributes["filename"].Value);

                ParseNodes(node.ChildNodes, basePath);
            }
        }

        /*public void Parse(string inputFileName, string outputFileName, string basePath)
        {
            var inputStream = this.fileStreamFactory.OpenFile(inputFileName);
            var outputStream = this.fileStreamFactory.CreateFile(outputFileName);

            var reader = XmlReader.Create(inputStream);
            var writer = XmlWriter.Create(outputStream, new XmlWriterSettings()
            {
                ConformanceLevel = ConformanceLevel.Auto
            });
            
            while (!reader.EOF)
            {
                if (reader.Name == "class")
                    ProcessClassNode(reader, writer, basePath);
                else
                    ProcessRegularNode(reader, writer);
            }

            writer.Flush();
        }*/

        /*private void ProcessClassNode(XmlReader reader, XmlWriter writer, string basePath)
        {
            writer.WriteStartElement(reader.Name);
            reader.MoveToFirstAttribute();
            do
            {
                if (reader.Name == "filename")
                    writer.WriteAttributeString("filename", this.basePathFixer.FixPath(basePath, reader.Value));
                else
                    writer.WriteAttributeString(reader.Name, reader.Value);
            }
            while (reader.MoveToNextAttribute() == false);
        }*/

        /*private void ProcessRegularNode(XmlReader reader, XmlWriter writer)
        {
            if (String.IsNullOrEmpty(reader.Name))
            {
                reader.Read();
                return;
            }

            writer.WriteName(reader.Name);
            writer.WriteValue(reader.Value);
            //writer.WriteAttributes(reader, true);
            reader.Read();
        }*/
    }
}
