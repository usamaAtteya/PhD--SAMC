using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SAMC2;
using SAMC2.ModelConverter;
using StaadConverter.StaadWriter;
namespace StaadConverter.Tests
{
    [TestFixture]
    class StaadWriterTests
    {
        public StaadWriterTests()
        { }
        //[Test]
        //public void WrtPoints_WithNoElemnt_OnlyHeader()
        //{
        //    Model _model = new Model();
        //    StaadWriter Writer = new StaadWriter(_model);
        //    var text = new StringBuilder();
        //    text.AppendLine("JOINT COORDINATES");
        //    text.AppendLine();
        //    Assert.AreEqual(text.ToString(), Writer.WrtJointsCordnts());
        //}
        [TestCaseSource(typeof(StaadWriterTestCases), "WrtPoints_1FElmntModel_ExpectedOutput_TestCases")]
        public void WrtPoints_1FElmntModel_ExpectedOutput(Model expecteModel, string expectedOutput)
            => Assert.AreEqual(expectedOutput, new JointsWriter().WriteContent(expecteModel));

        [TestCaseSource(typeof(StaadWriterTestCases), "WrtElmntJonts_1FElmntMod_ExcpectedOut_TestCases")]
        public void WrtElmntJonts_1FElmntMod_ExcpectedOut(Model expectedModel, string expected)
            => Assert.AreEqual(expected, new FramElementsWriter().WriteContent(expectedModel));

        [TestCaseSource(typeof(StaadWriterTestCases), "WrtElmntJonts_1AElmntMod_ExcpectedOut_TestCases")]
        public void WrtElmntJonts_1AElmntMod_ExcpectedOut(Model expectedModel, string expected)
            => Assert.AreEqual(expected, new AreaElementsWriter().WriteContent(expectedModel));

        [TestCaseSource(typeof(StaadWriterTestCases) , "UnitesWriter_ExpectedModel_TestCases")]
        public void UnitesWriter_ExpectedModel_ExpectedResult(Model expectedModel, string expectedResult)
            => TestWriterOfType<UnitsWriter>(expectedModel,expectedResult);
      //  [TestCaseSource(typeof(StaadWriterTestCases), "WriteLoadCases_2LoadCases_ExcpectedOut_TestCases")]
        public void WriteLoadCases_2LoadCases_ExcpectedOut(Model expectedModel, string expected)
            => Assert.AreEqual(expected, new LoadCasesWriter().WriteContent(expectedModel));

        [TestCaseSource(typeof(StaadWriterTestCases), "WriteLoadCombinations_2LoadCombs_ExpectedOut_TestCases")]
        public void WriteLoadCombinations_2LoadCombs_ExpectedOut(Model expectedModel, string expected)
            => Assert.AreEqual(expected, new LoadCombinationWriter().WriteContent(expectedModel));

        [TestCaseSource(typeof(StaadWriterTestCases), "WriteFramElmentsMaterials_2Materials_ExpectedOut_TestCases")]
        public void WriteFramElmentsMaterials_2Materials_ExpectedOut(Model expectedModel, string expected)
            => Assert.AreEqual(expected, new ElmentsMaterialsWriter().WriteContent(expectedModel));

        [TestCaseSource(typeof(StaadWriterTestCases), "WriteAreaElmentsMaterials_2Materials_ExpectedOut_TestCases")]
        public void WriteAreaElmentsMaterials_2Materials_ExpectedOut(Model expectedModel, string expected)
            => Assert.AreEqual(expected, new ElmentsMaterialsWriter().WriteContent(expectedModel));

        //[TestCaseSource(typeof(StaadWriterTestCases), "WriteFramElementsProperties_2FElements_ExpectedOut_TestCases")]
        //public void WriteFramElementsProperties_2FElements_ExpectedOut(Model expectedModel, string expected)
        //    => Assert.AreEqual(expected, new FramElementsPropertiesWriter().WriteContent(expectedModel));





        [TestCaseSource(typeof(StaadWriterTestCases), "BoundaryConditionWriter_ExpectedModel_TestCases")]
        public void BoundaryConditionWriter_ExpectedModel_ExpectedResult(Model expectedModel, string expectedResult)
          => TestWriterOfType<BoundaryConditionWriter>(expectedModel, expectedResult);
        void TestWriterOfType<T>(Model expectedModel, string expectedResult) where T : DocumentSectionWriter, new()
        => Assert.AreEqual(expectedResult, new T().WriteContent(expectedModel));
    }


}
