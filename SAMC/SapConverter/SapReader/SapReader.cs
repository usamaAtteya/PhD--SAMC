using SAMC2.ModelConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
using System.IO;
using Antlr4.Runtime;

namespace SapConverter.SapReader
{
    public class SapReader : IModelReader
    {
        public Model GetModel(string filePath)
        {
            string input = File.ReadAllText(filePath);
            var inputStream = new AntlrInputStream(input);
            var sapLexer = new SapParserLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(sapLexer);
            var sapParser = new SapParserParser(commonTokenStream);
            SapParserParser.FileContext fileRuleCtx;
            try
            {
               sapParser.ErrorHandler = new BailErrorStrategy();

                sapParser.Interpreter.PredictionMode = Antlr4.Runtime.Atn.PredictionMode.SLL;
                fileRuleCtx = sapParser.file();
            }
            catch (Exception)
            {
                sapParser.ErrorHandler = new DefaultErrorStrategy();
                commonTokenStream.Reset();
                sapParser.Reset();
                sapParser.Interpreter.PredictionMode = Antlr4.Runtime.Atn.PredictionMode.LL;
                fileRuleCtx = sapParser.file();
            }
            var visitor = new SapVisitor();
            return visitor.Visit(fileRuleCtx) as Model;
        }
    }
}
