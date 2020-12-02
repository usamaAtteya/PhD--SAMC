using NUnit.Framework;
using SAMC2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConverters.Tests
{
    [TestFixture]
    public class ModelReaderTests
    {
        [TestCaseSource(typeof(IFCModelReaderTestCases), "Units_Model_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "Units_Model_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "Units_Model_TestCases")]

        public void Units_Model_ExpectedUnites(Model model, ProjectUnits expectedUnits)
        {
            Assert.AreEqual(expectedUnits.ForceUnit , model.Units.ForceUnit);
            Assert.AreEqual(expectedUnits.LengthUnit, model.Units.LengthUnit);
            Assert.AreEqual(expectedUnits.TemperatureUnit, model.Units.TemperatureUnit);

        }
        [TestCaseSource(typeof(IFCModelReaderTestCases), "Materials_Count_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "Materials_Count_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "Materials_Count_TestCases")]

        public void Materials_Count_AsExpected(Model model, int expectedValue)
        => Assert.AreEqual(expectedValue, model.Materials.Count());


        [TestCaseSource(typeof(IFCModelReaderTestCases), "Materials_NameAtIndex_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "Materials_NameAtIndex_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "Materials_NameAtIndex_TestCases")]

        public void Materials_NameAtIndex_ExpectedName(Model model, int matAtIndex, string expectedName)
         => Assert.AreEqual(expectedName, model.Materials.ToList()[matAtIndex].Name);


       [TestCaseSource(typeof(IFCModelReaderTestCases), "Material_FromModel_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "Material_FromModel_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "Material_FromModel_TestCases")]
        public void Material_FromModel_AsExpected(Material modelMaterial , Material expectedMaterial)
        {
            Assert.AreEqual(expectedMaterial.Name, modelMaterial.Name);
            Assert.AreEqual(expectedMaterial.PoissonRatio, modelMaterial.PoissonRatio,.0001);
            Assert.AreEqual(expectedMaterial.ShearModulus, modelMaterial.ShearModulus, .0001);
            Assert.AreEqual(expectedMaterial.ThermalExpanssionC, modelMaterial.ThermalExpanssionC, .0001);
            Assert.AreEqual(expectedMaterial.Type, modelMaterial.Type);
            Assert.AreEqual(expectedMaterial.WeightDensity, modelMaterial.WeightDensity, .001);
            Assert.AreEqual(expectedMaterial.YoungModulus, modelMaterial.YoungModulus, .001);

        }

        [TestCaseSource(typeof(IFCModelReaderTestCases), "Elements_Count_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "Elements_Count_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "Elements_Count_TestCases")]

        public void Elements_Count_AsExpected(Model model, int ecpectedCount)
            => Assert.AreEqual(ecpectedCount, model.Elements.Count);

        [TestCaseSource(typeof(IFCModelReaderTestCases), "Elements_FromModel_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "Elements_FromModel_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "Elements_FromModel_TestCases")]

        public void Elements_FromModel_HaveUniqueIds(Model model)
          => Assert.AreEqual(model.Elements.Count(), model.Elements.GroupBy(e => e.Id).Count());

        [TestCaseSource(typeof(IFCModelReaderTestCases), "LoadCombosAndLoadCases_FromModel_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "LoadCombosAndLoadCases_FromModel_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "LoadCombosAndLoadCases_FromModel_TestCases")]

        public void LoadCombosAndLoadCases_FromModel_HaveUniqueIds(Model model)
            => model.LoadCombinations.ForEach(l => Assert.False(model.LoadCases.Select(lcase => lcase.Id).Contains(l.Id)));
        [TestCaseSource(typeof(IFCModelReaderTestCases), "FrameElements_Count_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "FrameElements_Count_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "FrameElements_Count_TestCases")]

        public void FrameElements_Count_9(Model model, int expectedCount)
       => Assert.AreEqual(expectedCount, model.FrameElements.Count());
        [TestCaseSource(typeof(IFCModelReaderTestCases), "FrameElements_CountVerticesOfEach_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "FrameElements_CountVerticesOfEach_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "FrameElements_CountVerticesOfEach_TestCases")]

        public void FrameElements_CountVerticesOfEach_AsExpected(Model model, int expectedCount)
            => model.FrameElements.ToList().ForEach(e => Assert.AreEqual(expectedCount, e.Vertices.Count));
        [TestCaseSource(typeof(IFCModelReaderTestCases), "AreaElements_CountVerticesOfEach_GreaterThanOrEqual_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "AreaElements_CountVerticesOfEach_GreaterThanOrEqual_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "AreaElements_CountVerticesOfEach_GreaterThanOrEqual_TestCases")]

        public void AreaElements_CountVerticesOfEach_GreaterThanOrEqual_ExpectedValue(Model model, int expectedValue)
      => model.AreaElements.ToList().ForEach(e => Assert.GreaterOrEqual(e.Vertices.Count, expectedValue));
        [TestCaseSource(typeof(IFCModelReaderTestCases), "AreaElements_Count_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "AreaElements_Count_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "AreaElements_Count_TestCases")]

        public void AreaElements_Count_AsExpected(Model model, int expectedCount)
        => Assert.AreEqual(expectedCount, model.AreaElements.Count());
        [TestCaseSource(typeof(IFCModelReaderTestCases), "FrameSections_Count_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "FrameSections_Count_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "FrameSections_Count_TestCases")]

        public void FrameSections_Count_AsExpected(Model model, int expectedCount)
            => Assert.AreEqual(expectedCount, model.FrameSections.Count());
        [TestCaseSource(typeof(IFCModelReaderTestCases), "FrameSections_RectangularProfileSectionsCount_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "FrameSections_RectangularProfileSectionsCount_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "FrameSections_RectangularProfileSectionsCount_TestCases")]

        public void FrameSections_RectangularProfileSectionsCount_AsExpected(Model model, int expectedCount)
        => Assert.AreEqual(expectedCount, model.FrameSections.Where(s => s.Profile is RecangularProfile).Count());


        [TestCaseSource(typeof(IFCModelReaderTestCases), "FrameElemets_FirstElementLastVertix_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "FrameElemets_FirstElementLastVertix_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "FrameElemets_FirstElementLastVertix_TestCases")]

        public void FrameElemets_FirstElementLastVertix_ExpectedValue(Model model, double expectedX, double expectedY, double expectedZ)
        {
            var point = model.FrameElements.First().Vertices.Last();
            Assert.AreEqual(expectedX, point.X);
            Assert.AreEqual(expectedY, point.Y);
            Assert.AreEqual(expectedZ, point.Z);
        }

        [TestCaseSource(typeof(IFCModelReaderTestCases), "FrameSections_LastRectProfSectDimnsRounded4_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "FrameSections_LastRectProfSectDimnsRounded4_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "FrameSections_LastRectProfSectDimnsRounded4_TestCases")]

        public void FrameSections_LastRectProfSectDimnsRounded4_AsExpected(Model model, double expectedDepth, double expectedWidth)
        {
            var lastRectSec = model.FrameSections.Select(s => s.Profile).OfType<RecangularProfile>().Last();
            Assert.AreEqual(expectedDepth, Math.Round(lastRectSec.Depth, 4));
            Assert.AreEqual(expectedWidth, Math.Round(lastRectSec.Width, 4));

        }

        [TestCaseSource(typeof(IFCModelReaderTestCases), "FrameSections_LastRectProfSectName_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "FrameSections_LastRectProfSectName_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "FrameSections_LastRectProfSectName_TestCases")]

        public void FrameSections_LastRectProfSectName_AsExpected(Model model, string expecteName)
        {
            var lastRectSec = model.FrameSections.Select(s => s.Profile).OfType<RecangularProfile>().Last();
            Assert.AreEqual(expecteName, lastRectSec.SectionProfileName);

        }

        [TestCaseSource(typeof(IFCModelReaderTestCases), "FrameSections_LastIShapeProfDimnsRounded4_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "FrameSections_LastIShapeProfDimnsRounded4_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "FrameSections_LastIShapeProfDimnsRounded4_TestCases")]

        public void FrameSections_LastIShapeProfDimnsRounded4_AsExpected(Model model, IShapeProfile expectedIProfile)
        {
            var lastIShapeSec = model.FrameSections.Select(s => s.Profile).OfType<IShapeProfile>().Last();
            Assert.AreEqual(expectedIProfile.OverallHeight, Math.Round(lastIShapeSec.OverallHeight, 4));
            Assert.AreEqual(expectedIProfile.WebThickness, Math.Round(lastIShapeSec.WebThickness, 4));
            Assert.AreEqual(expectedIProfile.TopFlangeWidth, Math.Round(lastIShapeSec.TopFlangeWidth, 4));
            Assert.AreEqual(expectedIProfile.TopFlangeThickness, Math.Round(lastIShapeSec.TopFlangeThickness, 4));
            Assert.AreEqual(expectedIProfile.BottomFlangeWidth, Math.Round(lastIShapeSec.BottomFlangeWidth, 4));
            Assert.AreEqual(expectedIProfile.BottomFlangeThickness, Math.Round(lastIShapeSec.BottomFlangeThickness, 4));
        }
        [TestCaseSource(typeof(IFCModelReaderTestCases), "Sections_MaterialAndSectionProfile_NotNull_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "Sections_MaterialAndSectionProfile_NotNull_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "Sections_MaterialAndSectionProfile_NotNull_TestCases")]

        public void Sections_MaterialAndSectionProfile_NotNull(Model model)
        {
            foreach (var sec in model.Sections)
            {
                Assert.NotNull(sec.Material);
                Assert.NotNull(sec.Profile);
            }
        }
        [TestCaseSource(typeof(IFCModelReaderTestCases), "Elements_SectionAndVertices_NotNull_TestCases")]
       [TestCaseSource(typeof(SapReaderTestCases), "Elements_SectionAndVertices_NotNull_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "Elements_SectionAndVertices_NotNull_TestCases")]

        public void Elements_SectionAndVertices_NotNull(Model model)
        {
            foreach (var elmnt in model.Elements)
            {
                Assert.NotNull(elmnt.Section);
                Assert.NotNull(elmnt.Vertices);
            }
        }
        [TestCaseSource(typeof(IFCModelReaderTestCases), "ElementsPoints_Count_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "ElementsPoints_Count_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "ElementsPoints_Count_TestCases")]

        public void ElementsPoints_Count_ExpectedValue(Model model, int expectedCount)
            => Assert.AreEqual(expectedCount, model.ElementsPoints.Count);


        [TestCaseSource(typeof(IFCModelReaderTestCases), "ElementsPoints_SameZGroupsCount_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "ElementsPoints_SameZGroupsCount_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "ElementsPoints_SameZGroupsCount_TestCases")]

        public void ElementsPoints_SameZGroupsCount_ExpectedValue(Model model, int expectedCount)
            => Assert.AreEqual(expectedCount, model.ElementsPoints.GroupBy(p => p.Z).Count());


        [TestCaseSource(typeof(IFCModelReaderTestCases), "ElementsPoints_SameYGroupsCount_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "ElementsPoints_SameYGroupsCount_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "ElementsPoints_SameYGroupsCount_TestCases")]

        public void ElementsPoints_SameYGroupsCount_ExpectedValue(Model model, int expectedCount)
        => Assert.AreEqual(expectedCount, model.ElementsPoints.GroupBy(p => p.Y).Count());

        [TestCaseSource(typeof(IFCModelReaderTestCases), "ElementsPoints_SameXGroupsCount_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "ElementsPoints_SameXGroupsCount_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "ElementsPoints_SameXGroupsCount_TestCases")]

        public void ElementsPoints_SameXGroupsCount_ExpectedValue(Model model, int expectedCount)
      => Assert.AreEqual(expectedCount, model.ElementsPoints.GroupBy(p => p.X).Count());


        [TestCaseSource(typeof(IFCModelReaderTestCases), "Elements_Ids_GreaterThanZero_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "Elements_Ids_GreaterThanZero_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "Elements_Ids_GreaterThanZero_TestCases")]

        public void Elements_Ids_GreaterThanZero(Model model)
       => model.Elements.ForEach(e => Assert.Greater(e.Id, 0));


        [TestCaseSource(typeof(IFCModelReaderTestCases), "FrameSections_LastIShapeProfSectName_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "FrameSections_LastIShapeProfSectName_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "FrameSections_LastIShapeProfSectName_TestCases")]

        public void FrameSections_LastIShapeProfSectName_AsExpected(Model model, string expecteName)
        {
            var lastIShapeSec = model.FrameSections.Select(s => s.Profile).OfType<IShapeProfile>().Last();
            Assert.AreEqual(expecteName, lastIShapeSec.SectionProfileName);
        }

        [TestCaseSource(typeof(IFCModelReaderTestCases), "FrameSections_IShapeProfileSectionsCount_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "FrameSections_IShapeProfileSectionsCount_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "FrameSections_IShapeProfileSectionsCount_TestCases")]

        public void FrameSections_IShapeProfileSectionsCount_AsExpected(Model model, int expectedCount)
       => Assert.AreEqual(expectedCount, model.FrameSections.Where(s => s.Profile is IShapeProfile).Count());


        //[TestCaseSource(typeof(IFCModelConverterTestCases), "AreaSections_Count_TestCases")]

        //public void AreaSections_Count_AsExpected(Model model, int expectedCount)
        //   => Assert.AreEqual(expectedCount, model.AreaSections.Count());

        [TestCaseSource(typeof(IFCModelReaderTestCases), "Sections_Count_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "Sections_Count_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "Sections_Count_TestCases")]

        public void Sections_Count_AsExpected(Model model, int expectedCount)
        => Assert.AreEqual(expectedCount, model.Sections.Count());


        [TestCaseSource(typeof(IFCModelReaderTestCases), "Sections_CountAreaSectionsFromModel_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "Sections_CountAreaSectionsFromModel_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "Sections_CountAreaSectionsFromModel_TestCases")]

        public void Sections_CountAreaSectionsFromModel_ExpectedCount(Model model, double expectedCount)
        => Assert.AreEqual(expectedCount, model.AreaSections.Count());

        // start here


        [TestCaseSource(typeof(IFCModelReaderTestCases), "LoadCombinations_Count_ExpectedCount_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "LoadCombinations_Count_ExpectedCount_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "LoadCombinations_Count_ExpectedCount_TestCases")]

        public void LoadCombinations_Count_ExpectedCount(Model model, int expectedCount)
        => Assert.AreEqual(expectedCount, model.LoadCombinations.Count());




        [TestCaseSource(typeof(IFCModelReaderTestCases), "LoadCases_NameAtIndex_ExpectedValue_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "LoadCases_NameAtIndex_ExpectedValue_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "LoadCases_NameAtIndex_ExpectedValue_TestCases")]
        public void LoadCases_NameAtIndex_ExpectedValue(Model model, int loadCaseIndex, string expectedName)
            => Assert.AreEqual(expectedName, model.LoadCases[loadCaseIndex].Name);

        [TestCaseSource(typeof(IFCModelReaderTestCases), "LoadCase_FirstLoadCaseFirstLoad_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "LoadCase_FirstLoadCaseFirstLoad_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "LoadCase_FirstLoadCaseFirstLoad_TestCases")]

        public void LoadCases_FirstLoadCaseFirstLoad_ExpectedValue(Model model, Load expectedLoad)
        {
            var actualLoad = model.LoadCases.First().Loads.First();
            Assert.AreEqual(expectedLoad.LoadForce.ForceX, Math.Round(actualLoad.LoadForce?.ForceX ?? 0, 4));
            Assert.AreEqual(expectedLoad.LoadForce.ForceY, Math.Round(actualLoad.LoadForce?.ForceY ?? 0, 4));
            Assert.AreEqual(expectedLoad.LoadForce.ForceZ, Math.Round(actualLoad.LoadForce?.ForceZ ?? 0, 4));
            Assert.AreEqual(expectedLoad.AppliedOnId, actualLoad.AppliedOnId);

        }
        [TestCaseSource(typeof(IFCModelReaderTestCases), "LoadForce_FromModel_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "LoadForce_FromModel_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "LoadForce_FromModel_TestCases")]

        public void LoadForce_FromModel_AsExpected(LoadForce modelLoadForce, LoadForce expectedLoadForce)
         => Assert.AreEqual(expectedLoadForce.ToString(), modelLoadForce.ToString());

        [TestCaseSource(typeof(SapReaderTestCases), "LoadCases_FirstLoadCaseType_AsExpected_TestCases")]
        [TestCaseSource(typeof(IFCModelReaderTestCases), "LoadCases_FirstLoadCaseType_AsExpected_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "LoadCases_FirstLoadCaseType_AsExpected_TestCases")]
        public void LoadCases_FirstLoadCaseType_AsExpected(Model model, LoadCaseType expectedType)
            => Assert.AreEqual(expectedType, model.LoadCases.First().LoadCaseType);

        [TestCaseSource(typeof(IFCModelReaderTestCases), "LoadCases_FirstSelfWeightCoefficient_AsExpected_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "LoadCases_FirstSelfWeightCoefficient_AsExpected_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "LoadCases_FirstSelfWeightCoefficient_AsExpected_TestCases")]
        public void LoadCases_FirstSelfWeightCoefficient_AsExpected(Model model, double expectedCoeffiction)
         => Assert.AreEqual(expectedCoeffiction, model.LoadCases.First().ScaleFactorCoefficient);

        [TestCaseSource(typeof(IFCModelReaderTestCases), "LoadCases_FirstId_AsExpected_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "LoadCases_FirstId_AsExpected_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "LoadCases_FirstId_AsExpected_TestCases")]
        public void LoadCases_FirstId_AsExpected(Model model, double expectedId)
            => Assert.AreEqual(expectedId, model.LoadCases.First().Id);

        [TestCaseSource(typeof(IFCModelReaderTestCases), "LoadCombinations_FirstLoadCombinationItemsCount_AsExpected_TestCases")]
        [TestCaseSource(typeof(SapReaderTestCases), "LoadCombinations_FirstLoadCombinationItemsCount_AsExpected_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "LoadCombinations_FirstLoadCombinationItemsCount_AsExpected_TestCases")]
        public void LoadCombinations_FirstLoadCombinationItemsCount_AsExpected(Model model, int expectedCount)
        => Assert.AreEqual(expectedCount, model.LoadCombinations.First().LoadCombinationItems.Count);

        [TestCaseSource(typeof(SapReaderTestCases), "LoadCombinations_FirstLoadComboFirstItem_TestCases")]
        [TestCaseSource(typeof(IFCModelReaderTestCases), "LoadCombinations_FirstLoadComboFirstItem_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "LoadCombinations_FirstLoadComboFirstItem_TestCases")]
        public void LoadCombinations_FirstLoadComboFirstItem_AsExpected(Model model, LoadCombinationItem expectedLoadComboItem)
        {
            var actual = model.LoadCombinations.First().LoadCombinationItems.First();
            Assert.AreEqual(expectedLoadComboItem.LoadCaseName, actual.LoadCaseName);
            Assert.AreEqual(expectedLoadComboItem.Factor, actual.Factor);
            Assert.AreEqual(expectedLoadComboItem.LoadCaseId, actual.LoadCaseId);

        }
        //[TestCase(2)]
        [TestCaseSource(typeof(SapReaderTestCases), "LoadCase_FirstLoadCaseLoadsCount_TestCases")]
        [TestCaseSource(typeof(IFCModelReaderTestCases), "LoadCase_FirstLoadCaseLoadsCount_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "LoadCase_FirstLoadCaseLoadsCount_TestCases")]
        public void LoadCase_FirstLoadCaseLoadsCount_ExpectedValue(Model model, int expectedCount)
         => Assert.AreEqual(expectedCount, model.LoadCases.First().Loads.Count);
        //[TestCase(0, "LG1")]
        //[TestCase(1, "LG2")]
        //[TestCase(2, "LG3")]
        [TestCaseSource(typeof(SapReaderTestCases), "LoadCombination_NameAtIndex_TestCases")]
        [TestCaseSource(typeof(IFCModelReaderTestCases), "LoadCombination_NameAtIndex_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "LoadCombination_NameAtIndex_TestCases")]
        public void LoadCombination_NameAtIndex_ExpectedValue(Model model, int loadComboIndex, string expectedName)
         => Assert.AreEqual(expectedName, model.LoadCombinations[loadComboIndex].Name);

        //[TestCase(0, 715)]
        //[TestCase(1, 725)]
        //[TestCase(2, 737)]
        [TestCaseSource(typeof(SapReaderTestCases), "LoadCombination_IdAtIndex_TestCases")]
        [TestCaseSource(typeof(IFCModelReaderTestCases), "LoadCombination_IdAtIndex_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "LoadCombination_IdAtIndex_TestCases")]
        public void LoadCombination_IdAtIndex_ExpectedValue(Model model, int loadComboIndex, int expectedId)
            => Assert.AreEqual(expectedId, model.LoadCombinations[loadComboIndex].Id);

        [TestCaseSource(typeof(SapReaderTestCases), "LoadCases_Count_TestCases")]
        [TestCaseSource(typeof(IFCModelReaderTestCases), "LoadCases_Count_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "LoadCases_Count_TestCases")]
        public void LoadCases_Count_Expected(Model model, int expectedCount)
            => Assert.AreEqual(expectedCount, model.LoadCases.Count());

        [TestCaseSource(typeof(SapReaderTestCases), "BoundaryConditions_Count_TestCases")]
        [TestCaseSource(typeof(IFCModelReaderTestCases), "BoundaryConditions_Count_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "BoundaryConditions_Count_TestCases")]
        public void BoundaryConditions_Count_Expected(Model model, int expectedCount)
          => Assert.AreEqual(expectedCount, model.BoundaryConditionsPoints.Count());

        //[TestCase(0, 0, 0, -3.9624)]
        [TestCaseSource(typeof(SapReaderTestCases), "BoundaryConditionsPoints_PointCordinatesAtIndex_TestCases")]
        [TestCaseSource(typeof(IFCModelReaderTestCases), "BoundaryConditionsPoints_PointCordinatesAtIndex_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "BoundaryConditionsPoints_PointCordinatesAtIndex_TestCases")]
        public void BoundaryConditionsPoints_PointCordinatesAtIndex_ExpectedValues(Model model, int bounCndIndex, Point expectedPoint)
        {
            var actualBndCndPnt = model.BoundaryConditionsPoints.ToList()[bounCndIndex];
            Assert.AreEqual(expectedPoint.X, actualBndCndPnt.X);
            Assert.AreEqual(expectedPoint.Y, actualBndCndPnt.Y);
            Assert.AreEqual(expectedPoint.Z, actualBndCndPnt.Z);

        }

        //[TestCase(0, 101)]
        [TestCaseSource(typeof(SapReaderTestCases), "BoundaryConditionsPoints_PointIdAtIndex_TestCases")]
        [TestCaseSource(typeof(IFCModelReaderTestCases), "BoundaryConditionsPoints_PointIdAtIndex_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "BoundaryConditionsPoints_PointIdAtIndex_TestCases")]
        public void BoundaryConditionsPoints_PointIdAtIndex_ExpectedValues(Model model, int bounCndIndex, double expectedId)
        => Assert.AreEqual(expectedId, model.BoundaryConditionsPoints.ToList()[bounCndIndex].Id);
        [TestCaseSource(typeof(SapReaderTestCases), "BoundaryConditionsPoints_BoundaryConditionAtIndex_TestCases")]
        [TestCaseSource(typeof(IFCModelReaderTestCases), "BoundaryConditionsPoints_BoundaryConditionAtIndex_TestCases")]
        [TestCaseSource(typeof(StaadReaderTestCases), "BoundaryConditionsPoints_BoundaryConditionAtIndex_TestCases")]
        public void BoundaryConditionsPoints_BoundaryConditionAtIndex_ExpectedValues(Model model, int bounCndIndex, BoundaryCondition expectedBndCnd)
        {
            var actualBndCnd = model.BoundaryConditionsPoints.ToList()[bounCndIndex].BoundaryCondition;
            Assert.AreEqual(expectedBndCnd.IsFreeTransX, actualBndCnd.IsFreeTransX);
            Assert.AreEqual(expectedBndCnd.IsFreeTransY, actualBndCnd.IsFreeTransY);
            Assert.AreEqual(expectedBndCnd.IsFreeTransZ, actualBndCnd.IsFreeTransZ);
            Assert.AreEqual(expectedBndCnd.IsFreeMomentX, actualBndCnd.IsFreeMomentX);
            Assert.AreEqual(expectedBndCnd.IsFreeMomentY, actualBndCnd.IsFreeMomentY);
            Assert.AreEqual(expectedBndCnd.IsFreeMomentZ, actualBndCnd.IsFreeMomentZ);

        }
    }
}
