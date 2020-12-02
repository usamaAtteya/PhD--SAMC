using SAMC2.ModelConverter;
using StaadConverter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SapConverter;
using Antlr4.Runtime;
using StaadConverter.StaadReader;
using IFCModelConverter.Ifc_2x3_modified.IFCWriter;

namespace TestConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ifcConverter = new IFCModelConverter.IFCModelConverter();
            //var staadSectionsProvider = new StaadDocumentSectionsWritersProvider();
            //var staadWriter = new StaadWriter(staadSectionsProvider);

            //var writtenModel = Convert(ifcConverter, staadWriter);
            ////  var model = ifcConverter.ReadModel();
            //// var writtenModel = staadWriter.WriteContent(model);
            //File.WriteAllText("F:\\str7\\firstIssue-WrittenModel.std", writtenModel);
            var model = new IFCModelConverter.Ifc_2x3_modified.IFCReader.IFCModelReader().GetModel(@"C:\Users\Usama\Source\Workspaces\SamcTfs2\TestConversions\2AreaSections.ifc");
            var ifcWriter = new IfcWriter(null).WriteContent(model);
           // var sapWriter = new SapConverter.SapWriter.SapWriter(new SapConverter.SapWriter.SapDocumentSectionWriterProvider());
           //File.WriteAllText(@"C:\Users\Usama\Source\Workspaces\SamcTfs2\TestConversions\first issue+GlobalZLoads -Generated .$2k", sapWriter.WriteContent(model));

            //string input2 = File.ReadAllText();
            //var inputStream = new AntlrInputStream(input2);
            //var spreadsheetLexer = new StaadParserLexer(inputStream);
            //var commonTokenStream = new CommonTokenStream(spreadsheetLexer);
            //var spreadsheetParser = new StaadParserParser(commonTokenStream);

            //var expressionContext = spreadsheetParser.file();
            //var visitor = new StaadVisitor();

            //visitor.Visit(expressionContext);
        }
        static string Convert(IModelReader modelReader, DocumentWriter documentWriter)
        {
            var model = modelReader.GetModel("F:\\str7\\first issue.ifc");
            return documentWriter.WriteContent(model);
        }
    }
}
