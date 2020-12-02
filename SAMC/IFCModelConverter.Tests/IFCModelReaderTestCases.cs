using IFCModelConverter.Ifc_2x3_modified.IFCReader;
using NUnit.Framework;
using SAMC2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConverters.Tests
{
    [TestFixture]
    public class IFCModelReaderTestCases
    {
        static string _filesBasePath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug", "Files");
        static string _generalFilePath = _filesBasePath + @"-RFEM-Example-06.ifc";
        static string _loadsTestFilePath = _filesBasePath + @"SAP-TestLoadCoordinates.ifc";
        static string _twoAreaSectionsFilePath = _filesBasePath + @"2AreaSections.ifc";
        static Model _generalModel = new IFCModelReader().GetModel(_generalFilePath);
        static Model _loadTestModel = new IFCModelReader().GetModel(_loadsTestFilePath);
        static Model _twoAreaSectionsModel = new IFCModelReader().GetModel(_twoAreaSectionsFilePath);

        public static IEnumerable<TestCaseData> Units_Model_TestCases
        {
            get
            {

                yield return new TestCaseData(_generalModel
                      , new ProjectUnits() { ForceUnit = ForceUnit.N, LengthUnit = LengthUnit.M, TemperatureUnit = TemperatureUnit.C });
                yield return new TestCaseData(new IFCModelReader().GetModel(_filesBasePath + "Model-Units-KIP-IN-F.ifc")
                                , new ProjectUnits() { ForceUnit = ForceUnit.Kip, LengthUnit = LengthUnit.In, TemperatureUnit = TemperatureUnit.F });


            }
        }

        public static IEnumerable<TestCaseData> Materials_Count_TestCases
        {
            get
            {

                yield return new TestCaseData(_generalModel, 2);
            }
        }



        public static IEnumerable<TestCaseData> Materials_NameAtIndex_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0, "CONCRETEfc=4000PSI");
                yield return new TestCaseData(_generalModel, 1, "A992");

            }
        }
        public static IEnumerable<TestCaseData> Material_FromModel_TestCases
        {

            get
            {
                var modelMaterial = _generalModel.Materials.First(m => m.Name.Equals("CONCRETEfc=4000PSI"));
                var expectedMaterial = new Material()
                {
                    Name = "CONCRETEfc=4000PSI",
                    PoissonRatio = 0.25,
                    ShearModulus = 2222,
                    ThermalExpanssionC = 5.550E-04,
                    Type = MaterialType.Concrete,
                    WeightDensity = 5555.0005,
                    YoungModulus = 5555
                };
                yield return new TestCaseData(modelMaterial, expectedMaterial);
                //   yield return new TestCaseData(_generalModel, 1, "kareem");

            }
        }
        public static IEnumerable<TestCaseData> Elements_Count_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 11);
            }
        }
        public static IEnumerable<TestCaseData> Elements_FromModel_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel);
            }
        }
        public static IEnumerable<TestCaseData> LoadCombosAndLoadCases_FromModel_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel);
            }
        }
        public static IEnumerable<TestCaseData> FrameElements_Count_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 9);
            }
        }


        public static IEnumerable<TestCaseData> FrameElements_CountVerticesOfEach_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 2);
            }
        }

        public static IEnumerable<TestCaseData> AreaElements_CountVerticesOfEach_GreaterThanOrEqual_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 4);
            }
        }

        public static IEnumerable<TestCaseData> AreaElements_Count_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 2);
            }
        }

        public static IEnumerable<TestCaseData> FrameSections_Count_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 3);
            }
        }

        public static IEnumerable<TestCaseData> FrameSections_RectangularProfileSectionsCount_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 2);
            }
        }

        public static IEnumerable<TestCaseData> FrameElemets_FirstElementLastVertix_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0, 0, -3.9624);
            }
        }

        public static IEnumerable<TestCaseData> FrameSections_LastRectProfSectDimnsRounded4_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0.3048, 0.3048);
            }
        }

        public static IEnumerable<TestCaseData> FrameSections_LastRectProfSectName_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, "304.799987792969X304.799987792969");
            }
        }

        public static IEnumerable<TestCaseData> Sections_MaterialAndSectionProfile_NotNull_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel);
            }
        }

        public static IEnumerable<TestCaseData> Elements_SectionAndVertices_NotNull_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel);
            }
        }

        public static IEnumerable<TestCaseData> ElementsPoints_Count_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 14);
            }
        }

        public static IEnumerable<TestCaseData> ElementsPoints_SameZGroupsCount_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 2);
            }
        }

        public static IEnumerable<TestCaseData> ElementsPoints_SameYGroupsCount_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 3);
            }
        }

        public static IEnumerable<TestCaseData> ElementsPoints_SameXGroupsCount_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 3);
            }
        }

        public static IEnumerable<TestCaseData> Elements_Ids_GreaterThanZero_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel);
            }
        }

        public static IEnumerable<TestCaseData> FrameSections_LastIShapeProfSectName_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, "W18X50");
            }
        }

        public static IEnumerable<TestCaseData> FrameSections_IShapeProfileSectionsCount_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 1);
            }
        }

        //public static IEnumerable<TestCaseData> AreaSections_Count_TestCases
        //{
        //    get
        //    {
        //        yield return new TestCaseData(_generalModel, 1);
        //    }
        //}

        public static IEnumerable<TestCaseData> Sections_Count_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 4);
            }
        }


        public static IEnumerable<TestCaseData> Sections_CountAreaSectionsFromModel_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 1);
                yield return new TestCaseData(_twoAreaSectionsModel, 2);

            }
        }

        public static IEnumerable<TestCaseData> FrameSections_LastIShapeProfDimnsRounded4_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, new IShapeProfile() { OverallHeight = .4572, WebThickness = .0091, TopFlangeWidth = .1905, BottomFlangeWidth = .1905, TopFlangeThickness = .0145, BottomFlangeThickness = .0145 });
            }
        }
        public static IEnumerable<TestCaseData> LoadCombinations_Count_ExpectedCount_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 3);
            }
        }
        public static IEnumerable<TestCaseData> LoadCases_NameAtIndex_ExpectedValue_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0, "LC1");
                yield return new TestCaseData(_generalModel, 1, "LC2");
                yield return new TestCaseData(_generalModel, 2, "LC3");
                yield return new TestCaseData(_generalModel, 3, "LC4");
            }
        }


        public static IEnumerable<TestCaseData> LoadCase_FirstLoadCaseFirstLoad_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, new Load() { AppliedOnId = 532, LoadForce = new SurfaceLoadForce { ForceX = 0, ForceY = 0, ForceZ = -718.2039 } });
            }
        }

        public static IEnumerable<TestCaseData> LoadForce_FromModel_TestCases
        {
            get
            {
                var loadsToTest = _loadTestModel.LoadCases.First(l => l.Name.Equals("Osama")).Loads;
                yield return new TestCaseData(loadsToTest[0].LoadForce, new LinearLoadForce() { Coordinates = LoadForceCoordinates.Local, ForceY = -12 }); //LocalInY Linear Force
                yield return new TestCaseData(loadsToTest[1].LoadForce, new SurfaceLoadForce() { Coordinates = LoadForceCoordinates.Local, ForceZ = 30 });//LocalInZ Surface Force
                yield return new TestCaseData(loadsToTest[2].LoadForce, new SurfaceLoadForce() { Coordinates = LoadForceCoordinates.Global_Projected_Length, ForceY = 30 });//GlobalProjectedInY Surface Force
                yield return new TestCaseData(loadsToTest[3].LoadForce, new SurfaceLoadForce() { Coordinates = LoadForceCoordinates.Global_True_Length, ForceY = 30 });//GlobalTrueInY Surface Force

            }
        }
        public static IEnumerable<TestCaseData> LoadCases_FirstLoadCaseType_AsExpected_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, LoadCaseType.Dead);
            }
        }
        public static IEnumerable<TestCaseData> LoadCases_FirstSelfWeightCoefficient_AsExpected_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 1);
            }
        }
        public static IEnumerable<TestCaseData> LoadCases_FirstId_AsExpected_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 593);
            }
        }
        public static IEnumerable<TestCaseData> LoadCombinations_FirstLoadCombinationItemsCount_AsExpected_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 3);
            }
        }
        //
        public static IEnumerable<TestCaseData> LoadCombinations_FirstLoadComboFirstItem_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, new LoadCombinationItem() { LoadCaseId = 593, LoadCaseName = "LC1", Factor = 1.2 });
            }
        }
        //LoadCase_FirstLoadCaseLoadsCount_TestCases
        public static IEnumerable<TestCaseData> LoadCase_FirstLoadCaseLoadsCount_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 2);
            }
        }
        //LoadCombination_NameAtIndex_TestCases
        //[TestCase(0, "LG1")]
        //[TestCase(1, "LG2")]
        //[TestCase(2, "LG3")]
        public static IEnumerable<TestCaseData> LoadCombination_NameAtIndex_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0, "LG1");
                yield return new TestCaseData(_generalModel, 1, "LG2");
                yield return new TestCaseData(_generalModel, 2, "LG3");
            }
        }
        //LoadCombination_IdAtIndex_TestCases
        //[TestCase(0, 715)]
        //[TestCase(1, 725)]
        //[TestCase(2, 737)]
        public static IEnumerable<TestCaseData> LoadCombination_IdAtIndex_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0, 715);
                yield return new TestCaseData(_generalModel, 1, 725);
                yield return new TestCaseData(_generalModel, 2, 737);
            }
        }
        public static IEnumerable<TestCaseData> LoadCases_Count_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 4);
            }
        }
        //BoundaryConditions_Count_TestCases
        public static IEnumerable<TestCaseData> BoundaryConditions_Count_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 7);
            }
        }
        //[TestCase(0, 0, 0, -3.9624)]
        //BoundaryConditionsPoints_PointCordinatesAtIndex_TestCases
        public static IEnumerable<TestCaseData> BoundaryConditionsPoints_PointCordinatesAtIndex_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0, new Point() { X = 0, Y = 0, Z = -3.9624 });
            }
        }
        //BoundaryConditionsPoints_PointIdAtIndex_TestCases
        public static IEnumerable<TestCaseData> BoundaryConditionsPoints_PointIdAtIndex_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0, 101);
            }
        }
        public static IEnumerable<TestCaseData> BoundaryConditionsPoints_BoundaryConditionAtIndex_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0, new BoundaryCondition() { IsFreeMomentX = true, IsFreeMomentY = true });
            }
        }
    }
}
