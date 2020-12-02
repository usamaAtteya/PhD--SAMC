using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SAMC2;
using StaadConverter;

namespace StaadConverter.Tests
{
    [TestFixture]
    public class StaadWriterTestCases
    {
        public static IEnumerable<TestCaseData> WrtPoints_1FElmntModel_ExpectedOutput_TestCases
        {
            get
            {
                var model = new Model();
                List<Point> points = new List<Point>() { new Point() { Id = 1, X = 1, Y = 1, Z = 1 }, new Point() { Id = 2, X = 2, Y = 2, Z = 2 } };
                Element e = new FrameElement() { Id = 1, Vertices = points };
                model.Elements.Add(e);
                var text = new StringBuilder();
                text.AppendLine("JOINT COORDINATES");
                text.AppendLine("1 1 1 1;2 2 2 2;");
                yield return new TestCaseData(model, text.ToString());

            }
        }
        public static IEnumerable<TestCaseData> WrtElmntJonts_1FElmntMod_ExcpectedOut_TestCases
        {
            get
            {
                var model = new Model();
                List<Point> points = new List<Point>() { new Point() { Id = 1, X = 1, Y = 1, Z = 1 }, new Point() { Id = 2, X = 2, Y = 2, Z = 2 } };
                Element e = new FrameElement() { Id = 1, Vertices = points };
                model.Elements.Add(e);
                var text = new StringBuilder();
                text.AppendLine("MEMBER INCIDENCES");
                text.AppendLine("1 1 2;");
                yield return new TestCaseData(model, text.ToString());

            }
        }
        public static IEnumerable<TestCaseData> WrtElmntJonts_1AElmntMod_ExcpectedOut_TestCases
        {
            get
            {
                var model = new Model();
                List<Point> points = new List<Point>() { new Point() { Id = 1, X = 1, Y = 1, Z = 1 }, new Point() { Id = 2, X = 2, Y = 2, Z = 2 }, new Point() { Id = 3, X = 3, Y = 3, Z = 3 }, new Point() { Id = 4, X = 4, Y = 4, Z = 4 } };
                Element e = new AreaElement() { Id = 1, Vertices = points };
                model.Elements.Add(e);
                var text = new StringBuilder();
                text.AppendLine("ELEMENT INCIDENCES SHELL");
                text.AppendLine("1 1 2 3 4;");
                yield return new TestCaseData(model, text.ToString());

            }
        }

        //public static IEnumerable<TestCaseData> WriteFramElementsProperties_2FElements_ExpectedOut_TestCases
        //{
        //    get
        //    {

        //        yield return new TestCaseData();
        //    }
        //}
        public static IEnumerable<TestCaseData> UnitesWriter_ExpectedModel_TestCases
        {
            get
            {
                yield return new TestCaseData(new Model()
                {
                    Units = new ProjectUnits() { ForceUnit = ForceUnit.Tonf, LengthUnit = LengthUnit.M }
                },
                    new StringBuilder().AppendLine("UNIT METER MTON").ToString()
                );


            }
        }
        




        public static IEnumerable<TestCaseData> BoundaryConditionWriter_ExpectedModel_TestCases
        {
            get
            {
                #region First Model
                var model1 = new Model();

                model1.Elements.Add(new AreaElement()
                {
                    Vertices = new List<Point>() {
                new Point() { Id = 1, BoundaryCondition = new BoundaryCondition()  } ,
                new Point () {Id = 8 , BoundaryCondition = new BoundaryCondition() },
                }
                });
                var expectedResultModel1 = new StringBuilder().AppendLine("SUPPORTS").AppendLine("1 8 FIXED").ToString();
                yield return new TestCaseData(
                    model1,
                   expectedResultModel1
                );
                #endregion
                #region Second Model
                var model2 = new Model();
                model2.Elements.Add(new AreaElement()
                {
                    Vertices = new List<Point>() {
                new Point() { Id = 2, BoundaryCondition = new BoundaryCondition(){IsFreeMomentX = true , IsFreeTransX = true } },
                new Point() { Id = 18, BoundaryCondition = new BoundaryCondition() {IsFreeMomentX = true , IsFreeTransX = true } },
                new Point() { Id = 4, BoundaryCondition = new BoundaryCondition() {IsFreeMomentY = true , IsFreeTransY = true , IsFreeTransZ =true } },
                new Point() { Id = 12, BoundaryCondition = new BoundaryCondition() {IsFreeMomentZ = true } },
                    }
                });
                var expectedResultModel2 = new StringBuilder().AppendLine("SUPPORTS").AppendLine("2 18 FIXED BUT FX MX")
                  .AppendLine("4 FIXED BUT FY FZ MY")
                  .AppendLine("12 FIXED BUT MZ").ToString();
                yield return new TestCaseData(
                  model2,
                expectedResultModel2
              );
                #endregion
                #region Third Model
                var model3 = new Model();
                model3.Elements.AddRange(model1.AreaElements);
                model3.Elements.AddRange(model2.AreaElements);
                var expectedResultModel3 = new StringBuilder(expectedResultModel1).AppendLine("2 18 FIXED BUT FX MX")
                  .AppendLine("4 FIXED BUT FY FZ MY")
                  .AppendLine("12 FIXED BUT MZ").ToString();
                yield return new TestCaseData(
                  model3,
                expectedResultModel3
              );
                #endregion


            }
        }
        public static IEnumerable<TestCaseData> WriteLoadCases_2LoadCases_ExcpectedOut_TestCases
        {
            get
            {
                var loads_1 = new List<Load>()
                {
                    new Load()
                    {
                        AppliedOnId =3, LoadForce=new PointLoadForce()
                        {
                            ForceX=3,ForceY=3,ForceZ=3,MomentX=3,MomentY=3,MomentZ=3
                        }
                    },
                    new Load()
                    {
                        AppliedOnId =10, LoadForce=new PointLoadForce()
                        {
                            ForceX=3,ForceY=3,ForceZ=3,MomentX=3,MomentY=3,MomentZ=3
                        }
                    },
                    new Load()
                    {
                        AppliedOnId=4, LoadForce= new LinearLoadForce()
                        {
                            ForceX=4,Coordinates=LoadForceCoordinates.Local
                        }
                    },
                    new Load()
                    {
                        AppliedOnId=11, LoadForce= new LinearLoadForce()
                        {
                            ForceX=4,Coordinates=LoadForceCoordinates.Local
                        }
                    },
                    new Load()
                    {
                        AppliedOnId=5,LoadForce=new SurfaceLoadForce()
                        {
                            ForceZ=5,Coordinates=LoadForceCoordinates.Global_True_Length
                        }
                    },
                    new Load()
                    {
                        AppliedOnId=12,LoadForce=new SurfaceLoadForce()
                        {
                            ForceZ=5,Coordinates=LoadForceCoordinates.Global_True_Length
                        }
                    }
                };
                var LoadCases = new List<LoadCase>()
                {
                    new LoadCase() {Id=1,Name="DEAD LOAD",LoadCaseType= LoadCaseType.Dead,Loads=loads_1 }
                    
                };
                var model = new Model();
                model.LoadCases.AddRange( LoadCases);
                var text = new StringBuilder();
                text.AppendLine("LOAD 1 LOADTYPE Dead TITLE DEAD LOAD");
                text.AppendLine("ELEMENT LOAD");
                text.AppendLine("5 12 PR GZ 5");
                text.AppendLine("JOINT LOAD");
                text.AppendLine("3 10 FX 3 FY 3 FZ 3 MX 3 MY 3 MZ 3");
                text.AppendLine("MEMBER LOAD");
                text.AppendLine("4 11 UNI X 4");
                
                yield return new TestCaseData(model, text.ToString());
            }
        }
        public static IEnumerable<TestCaseData> WriteFramElmentsMaterials_2Materials_ExpectedOut_TestCases
        {
            get
            {
                var model = new Model();
                var text = new StringBuilder();
                model.Elements = new List<Element>()
                {
                    new FrameElement()
                    {
                        Id=1, Section=new Section()
                        {
                            Material=new Material(){Name="ahmed"}
                        }
                    },
                    new FrameElement()
                    {
                        Id=2, Section =new Section()
                        {
                            Material=new Material (){Name="moha"}
                        }
                    } 
                };
                text.AppendLine("CONSTANTS");
                text.AppendLine("MATERIAL ahmed MEMB 1");                
                text.AppendLine("MATERIAL moha MEMB 2");
                yield return new TestCaseData(model,text.ToString());
            }
        }

        public static IEnumerable<TestCaseData> WriteAreaElmentsMaterials_2Materials_ExpectedOut_TestCases
        {
            get
            {
                var model = new Model();
                var text = new StringBuilder();
                model.Elements = new List<Element>()
                {
                    new AreaElement()
                    {
                        Id=1, Section=new Section()
                        {
                            Material=new Material(){Name="ahmed"}
                        }
                    },
                    new AreaElement()
                    {
                        Id=2, Section =new Section()
                        {
                            Material=new Material (){Name="moha"}
                        }
                    }
                };
                text.AppendLine("CONSTANTS");
                text.AppendLine("MATERIAL ahmed MEMB 1");
                text.AppendLine("MATERIAL moha MEMB 2");
                yield return new TestCaseData(model, text.ToString());
            }
        }



        public static IEnumerable<TestCaseData> WriteLoadCombinations_2LoadCombs_ExpectedOut_TestCases
        {
            get
            {
                List<LoadCombination> loadCombs = new List<LoadCombination>()
                {
                    new LoadCombination()
                    {
                        Id=3,Name="ay7aga",LoadCombinationItems=new List<LoadCombinationItem>()
                        {
                            new LoadCombinationItem()
                            {
                                LoadCaseId=1,Factor=1.4
                            },
                            new LoadCombinationItem()
                            {
                                LoadCaseId=2,Factor=1.5
                            }

                        }
                    },
                    new LoadCombination()
                    {
                        Id =5,Name="lokisfj",LoadCombinationItems=new List<LoadCombinationItem>()
                        {
                            new LoadCombinationItem()
                            {
                                LoadCaseId=3,Factor=1.2
                            },
                            new LoadCombinationItem()
                            {
                                LoadCaseId=4,Factor=1.8
                            }
                        }
                    }

                };
                var model = new Model();
                model.LoadCombinations.AddRange(loadCombs);
                var text = new StringBuilder();
                text.AppendLine("LOAD COMB 3 ay7aga");
                text.AppendLine("1 1.4 2 1.5 ");
                text.AppendLine("LOAD COMB 5 lokisfj");
                text.AppendLine("3 1.2 4 1.8 ");
                yield return new TestCaseData(model, text.ToString());
            }

        }
    }
}
