using NUnit.Framework;
using SAMC2;
using SapConverter.SapReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConverters.Tests
{
    [TestFixture]

    public class SapReaderTestCases
    {
        static string _filesBasePath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug", "Files");
        static string _generalFilePath = _filesBasePath + @"first issue+GlobalZLoads .$2k";
        static Model _generalModel = new SapReader().GetModel(_generalFilePath);

        public static IEnumerable<TestCaseData> Units_Model_TestCases
        {
            get
            {

                yield return new TestCaseData(_generalModel
                      , new ProjectUnits() { ForceUnit = ForceUnit.KN, LengthUnit = LengthUnit.M, TemperatureUnit = TemperatureUnit.C });

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
                yield return new TestCaseData(_generalModel, 0, "A992Fy50");
                yield return new TestCaseData(_generalModel, 1, "kareem");

            }
        }
        public static IEnumerable<TestCaseData> Material_FromModel_TestCases
        {
         
            get
            {
                var modelMaterial = _generalModel.Materials.First(m => m.Name.Equals("kareem"));
                var expectedMaterial = new Material()
                {
                    Name = "kareem",
                    PoissonRatio = 0.4,
                    ShearModulus = 71428571.4285714,
                    ThermalExpanssionC = 6E-06,
                    Type = MaterialType.Other,
                    WeightDensity = 50.00000038136,
                    YoungModulus = 200000000
                };
                yield return new TestCaseData(modelMaterial,expectedMaterial);
             //   yield return new TestCaseData(_generalModel, 1, "kareem");

            }
        }
        public static IEnumerable<TestCaseData> Elements_Count_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 208);
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
                yield return new TestCaseData(_generalModel, 58);
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
                yield return new TestCaseData(_generalModel, 150);
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
                yield return new TestCaseData(_generalModel, -9, -6, 3);
            }
        }

        public static IEnumerable<TestCaseData> FrameSections_LastRectProfSectDimnsRounded4_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 1, 0.2);
            }
        }

        public static IEnumerable<TestCaseData> FrameSections_LastRectProfSectName_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, "B100x20");
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
                yield return new TestCaseData(_generalModel, 200);
            }
        }

        public static IEnumerable<TestCaseData> ElementsPoints_SameZGroupsCount_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 3);
            }
        }

        public static IEnumerable<TestCaseData> ElementsPoints_SameYGroupsCount_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 11);
            }
        }

        public static IEnumerable<TestCaseData> ElementsPoints_SameXGroupsCount_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 16);
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
                yield return new TestCaseData(_generalModel, "I beam");
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
            }
        }

        public static IEnumerable<TestCaseData> FrameSections_LastIShapeProfDimnsRounded4_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, new IShapeProfile() { OverallHeight = 0.3, WebThickness = 6.000E-03, TopFlangeWidth = 0.1, BottomFlangeWidth = 0.1, TopFlangeThickness = 0.01, BottomFlangeThickness = 9.000E-03 });
            }
        }
        public static IEnumerable<TestCaseData> LoadCombinations_Count_ExpectedCount_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 1);
            }
        }
        public static IEnumerable<TestCaseData> LoadCases_NameAtIndex_ExpectedValue_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0, "DEAD");
                yield return new TestCaseData(_generalModel, 1, "DLOAD");
                yield return new TestCaseData(_generalModel, 2, "LLOAD");
            }
        }
        public static IEnumerable<TestCaseData> LoadCase_FirstLoadCaseFirstLoad_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, new Load() { AppliedOnId = 8, LoadForce = new PointLoadForce { ForceX = 10, ForceY = 20, ForceZ = 30 } });
            }
        }
        public static IEnumerable<TestCaseData> LoadForce_FromModel_TestCases
        {

            get
            {
                var deadLoadCaseLoads = _generalModel.LoadCases.First(l => l.Name.Equals("DEAD")).Loads;
                yield return new TestCaseData(deadLoadCaseLoads.Select(l => l.LoadForce).OfType<LinearLoadForce>().First(), new LinearLoadForce() { Coordinates = LoadForceCoordinates.Local, ForceZ = -10 }); //LocalInZ Linear Force
                yield return new TestCaseData(deadLoadCaseLoads.Select(l => l.LoadForce).OfType<SurfaceLoadForce>().First(), new SurfaceLoadForce() { Coordinates = LoadForceCoordinates.Global_True_Length, ForceY = -15 });////GlobalTrueInY Surface Force
                yield return new TestCaseData(deadLoadCaseLoads.Select(l => l.LoadForce).OfType<SurfaceLoadForce>().First(f => f.Coordinates == LoadForceCoordinates.Global_Projected_Length), new SurfaceLoadForce() { Coordinates = LoadForceCoordinates.Global_Projected_Length, ForceY = -60 });//GlobalProjectedInY Surface Force
                var liveLoadCaseLoads = _generalModel.LoadCases.First(l => l.Name.Equals("LLOAD")).Loads; ;
                yield return new TestCaseData(liveLoadCaseLoads.Select(l => l.LoadForce).OfType<SurfaceLoadForce>().First(), new SurfaceLoadForce() { Coordinates = LoadForceCoordinates.Local, ForceZ = -50 });//LocalInZ Surface Force
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
                yield return new TestCaseData(_generalModel, 1);
            }
        }
        public static IEnumerable<TestCaseData> LoadCombinations_FirstLoadCombinationItemsCount_AsExpected_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 2);
            }
        }
        public static IEnumerable<TestCaseData> LoadCombinations_FirstLoadComboFirstItem_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, new LoadCombinationItem() { LoadCaseId = 1, LoadCaseName = "DEAD", Factor = 1.8 });
            }
        }
        public static IEnumerable<TestCaseData> LoadCase_FirstLoadCaseLoadsCount_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 4);
            }
        }
        public static IEnumerable<TestCaseData> LoadCombination_NameAtIndex_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0, "FirstCombo");
            }
        }
        public static IEnumerable<TestCaseData> LoadCombination_IdAtIndex_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0, 4);
            }
        }
        public static IEnumerable<TestCaseData> LoadCases_Count_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 3);
            }
        }
        public static IEnumerable<TestCaseData> BoundaryConditions_Count_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 12);
            }
        }
        public static IEnumerable<TestCaseData> BoundaryConditionsPoints_PointCordinatesAtIndex_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0, new Point() { X = -9, Y = -6, Z = 0 });
            }
        }
        public static IEnumerable<TestCaseData> BoundaryConditionsPoints_PointIdAtIndex_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0, 1);
            }
        }
        public static IEnumerable<TestCaseData> BoundaryConditionsPoints_BoundaryConditionAtIndex_TestCases
        {
            get
            {
                yield return new TestCaseData(_generalModel, 0, new BoundaryCondition() { IsFreeMomentX = false, IsFreeMomentY = false, IsFreeMomentZ = false, IsFreeTransX = false, IsFreeTransY = false, IsFreeTransZ = false });
            }
        }
    }
}
