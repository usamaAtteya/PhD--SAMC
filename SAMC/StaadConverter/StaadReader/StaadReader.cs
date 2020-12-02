using SAMC2.ModelConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
using System.IO;
using Antlr4.Runtime;

namespace StaadConverter.StaadReader
{
    public class StaadReader : IModelReader
    {
        public Model GetModel(string filePath)
        {
            string input = File.ReadAllText(filePath);
            var inputStream = new AntlrInputStream(input);
            var staadLexer = new StaadParserLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(staadLexer);
            var staadParser = new StaadParserParser(commonTokenStream);
            StaadParserParser.FileContext fileRuleCtx;
            try
            {
                staadParser.ErrorHandler = new BailErrorStrategy();

                staadParser.Interpreter.PredictionMode = Antlr4.Runtime.Atn.PredictionMode.SLL;
                fileRuleCtx = staadParser.file();
            }
            catch (Exception)
            {
                staadParser.ErrorHandler = new DefaultErrorStrategy();

                commonTokenStream.Reset();
                staadParser.Reset();
                staadParser.Interpreter.PredictionMode = Antlr4.Runtime.Atn.PredictionMode.LL;
                fileRuleCtx = staadParser.file();
            }

            var visitor = new StaadVisitor();
            return visitor.Visit(fileRuleCtx) as Model;
        }
    }
}
