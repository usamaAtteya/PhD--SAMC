using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapReader
{
    class SapVisitor : SapParserBaseVisitor<Object>
    {
        List<Point> _points = new List<Point>();
        ProjectUnits _projectUnits = new ProjectUnits();
        List<Section> _areaSections = new List<Section>();
        List<AreaElement> _areaElements = new List<AreaElement>();
        List<Material> _materials = new List<Material>();
        List<Section> _frameSections = new List<Section>();
        List<FrameElement> _frameElements = new List<FrameElement>();
        List<Load> _loads = new List<Load>();
        List<LoadCase> _loadCases = new List<LoadCase>();
        List<LoadCombination> _loadCombinations = new List<LoadCombination>();
        Dictionary<string, List<Load>> _loadPatLoads = new Dictionary<string, List<Load>>();


        public override object VisitFile([NotNull] SapParserParser.FileContext context)
        {

            var orderedTablesToVisit = new List<SapParserParser.TableContext>();
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.ProgramControlTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.PointsTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.BoundaryConditionsTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.MaterialsPropertiesTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.MaterialsTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.FrameSectionsTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.FrameElementsJointsTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.FrameElementsSectionsTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.AreaSectionsTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.AreaElementsWithoutSectionsTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.AreaSectionAssignmentsTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.LoadPatternsTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.PointsLoadsTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.FrameLoadsTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.AreaLoadsUniformTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.LoadCaseTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.LoadCaseAssignmentsTableContext>(0));
            orderedTablesToVisit.Add(context.GetChild<SapParserParser.LoadCombinationTableContext>(0));

            foreach (var tableCtx in orderedTablesToVisit)
                if (tableCtx != null)
                    Visit(tableCtx);

            return GetModel();
        }

        #region Project Units
        public override object VisitProgramControlTable([NotNull] SapParserParser.ProgramControlTableContext context)
        {
            var sapUnitsText = GetValueOf("CurrUnits", context.table_content().table_row().First());//Visit(context.table_content().table_row().FirstOrDefault()?.table_row_item()?.FirstOrDefault(i => i.TEXT().GetText().Equals("CurrUnits"))?.data());
            if (sapUnitsText != null)
            {
                var sapUnits = sapUnitsText.ToString().Split(new string[] { ", " }, StringSplitOptions.None);
                _projectUnits.ForceUnit = GetForceUnit(sapUnits[0]);
                _projectUnits.LengthUnit = GetLengthUnit(sapUnits[1]);
                _projectUnits.TemperatureUnit = GetTemperUnit(sapUnits[2]);

            }
            return null;//return null;//return base.VisitProgramControlTable(context);
        }
        #endregion
        #region Area Elements
        public override object VisitAreaElementsWithoutSectionsTable([NotNull] SapParserParser.AreaElementsWithoutSectionsTableContext context)
        {
            var sapAreaElmntsCtx = context.table_content().table_row().ToList();
            foreach (var sapAreaElmntCtx in sapAreaElmntsCtx)
            {
                var areaElmnt = new AreaElement() { Id = (int)GetValueOf("Area", sapAreaElmntCtx), Vertices = new List<Point>() };
                var elmntVerticesCtx = sapAreaElmntCtx.table_row_item().Where(ri => ri.TEXT().GetText().StartsWith("Joint"));
                foreach (var elmntVertexCtx in elmntVerticesCtx)
                    areaElmnt.Vertices.Add(_points.First(p => p.Id.Equals(GetValueOf(elmntVertexCtx.TEXT().GetText(), sapAreaElmntCtx))));
                _areaElements.Add(areaElmnt);
            }

            return null;//return base.VisitAreaElementsWithoutSectionsTable(context);
        }
        public override object VisitAreaSectionsTable([NotNull] SapParserParser.AreaSectionsTableContext context)
        {
            var sapAreaSecsCtx = context.table_content().table_row().ToList();
            foreach (var sapAreaSecCtx in sapAreaSecsCtx)
            {
                var sectionName = GetValueOf("Section", sapAreaSecCtx);//Visit(sapAreaSec.table_row_item().First(i => i.TEXT().GetText().Equals("Section")).data());
                var sectionThickness = GetValueOf("Thickness", sapAreaSecCtx);//Visit(sapAreaSec.table_row_item().First(i => i.TEXT().GetText().Equals("Thickness")).data());
                var sectionMaterialName = sapAreaSecCtx.table_row_item().FirstOrDefault(i => i.TEXT().GetText().Equals("Material")) == null ? null : GetValueOf("Material", sapAreaSecCtx); //Visit(sapAreaSec.table_row_item().First(i => i.TEXT().GetText().Equals("Material")).data());
                _areaSections.Add(
            new Section() { Material = sectionMaterialName == null ? null : _materials.FirstOrDefault(m => m.Name.Equals(sectionMaterialName)), Profile = new AreaSectionProfile() { SectionProfileName = sectionName.ToString(), Thickness = Convert.ToDouble(sectionThickness) } }
                   );

            }
            return null;//return base.VisitAreaSectionsTable(context);
        }
        public override object VisitAreaSectionAssignmentsTable([NotNull] SapParserParser.AreaSectionAssignmentsTableContext context)
        {
            var sapAreaSecAssignmentsCtx = context.table_content().table_row().ToList();
            foreach (var sapAssignmentCtx in sapAreaSecAssignmentsCtx)
            {
                var areaElmntId = GetValueOf("Area", sapAssignmentCtx);
                var areaSecName = sapAssignmentCtx.table_row_item().First(i => i.TEXT().GetText().Equals("Section")) == null ? null : GetValueOf("Section", sapAssignmentCtx);
                if (areaSecName != null)
                    _areaElements.First(e => e.Id.Equals(areaElmntId)).Section = _areaSections.FirstOrDefault(s => s.Profile.SectionProfileName.Equals(areaSecName)) ?? new Section();
            }

            return null;//return base.VisitAreaSectionAssignmentsTable(context);
        }
        #endregion
        #region Loads
        public override object VisitPointsLoadsTable([NotNull] SapParserParser.PointsLoadsTableContext context)
        {
            var sapPointsLoadsCtx = context.table_content().table_row().ToList();
            foreach (var sapPointLoadCtx in sapPointsLoadsCtx)
            {
                var loadPat = GetValueOf("LoadPat", sapPointLoadCtx);
                var load = new Load()
                {
                    AppliedOnId = (int)GetValueOf("Joint", sapPointLoadCtx),
                    LoadForce = new PointLoadForce()
                    {
                        ForceX = Convert.ToDouble(GetValueOf("F1", sapPointLoadCtx)),
                        ForceY = Convert.ToDouble(GetValueOf("F2", sapPointLoadCtx)),
                        ForceZ = Convert.ToDouble(GetValueOf("F3", sapPointLoadCtx)),
                        MomentX = Convert.ToDouble(GetValueOf("M1", sapPointLoadCtx)),
                        MomentY = Convert.ToDouble(GetValueOf("M2", sapPointLoadCtx)),
                        MomentZ = Convert.ToDouble(GetValueOf("M3", sapPointLoadCtx)),
                    }
                };
                AddLoadToLists(load, loadPat.ToString());
            }
            return null;//return base.VisitPointsLoadsTable(context);
        }

        public override object VisitFrameLoadsTable([NotNull] SapParserParser.FrameLoadsTableContext context)
        {
            var sapFramesLoadCtxs = context.table_content().table_row().ToList();
            foreach (var sapFrameLoadCtx in sapFramesLoadCtxs)
            {
                //var frameElmntId = GetValueOf("Frame", sapFrameLoadCtx);
                //var load = _loads.FirstOrDefault(l => l.AppliedOnId.Equals(frameElmntId) && l.LoadForce is LinearLoadForce);
                //if (load != null)
                //    AssignLoadForceValue((LinearLoadForce)load.LoadForce, sapFrameLoadCtx);               
                //else
                //CreateLinearLoad(sapFrameLoadCtx);
                var frameElmntId = GetValueOf("Frame", sapFrameLoadCtx);
                var loadPat = GetValueOf("LoadPat", sapFrameLoadCtx);
                var load = new Load()
                {
                    AppliedOnId = (int)frameElmntId
                  ,
                    LoadForce = CreateLinearLoadForceValue(sapFrameLoadCtx)
                };
                AddLoadToLists(load, loadPat.ToString());
            }
            return null;//return base.VisitFrameLoadsTable(context);

        }


        public override object VisitAreaLoadsUniformTable([NotNull] SapParserParser.AreaLoadsUniformTableContext context)
        {
            var sapAreaLoadCtxs = context.table_content().table_row().ToList();
            foreach (var sapAreaLoadCtx in sapAreaLoadCtxs)
            {
                var areaElmntId = GetValueOf("Area", sapAreaLoadCtx);
                var loadPat = GetValueOf("LoadPat", sapAreaLoadCtx);
                var load = new Load()
                {
                    AppliedOnId = (int)areaElmntId
                 ,
                    LoadForce = CreateSurfaceLoadForceValue(sapAreaLoadCtx)
                };
                AddLoadToLists(load, loadPat.ToString());
            }
            return null;//return base.VisitAreaLoadsUniformTable(context);
        }


        LinearLoadForce CreateLinearLoadForceValue(SapParserParser.Table_rowContext tableRowCtx)
        {
            var linearLoadForce = new LinearLoadForce();
            var loadDir = GetValueOf("Dir", tableRowCtx).ToString();
            var loadForceType = GetValueOf("Type", tableRowCtx);

            var loadForceValue = loadForceType.Equals("Force") ? Convert.ToDouble(GetValueOf("FOverLA", tableRowCtx)) : Convert.ToDouble(GetValueOf("MOverLA", tableRowCtx));

            linearLoadForce.Coordinates = GetLoadForceCoordinated(tableRowCtx);// loadCoordSys.Equals("Local") ? LoadForceCoordinates.Local : loadDir.Contains("Proj") ? LoadForceCoordinates.Global_Projected_Length : LoadForceCoordinates.Global_True_Length;


            if (loadDir.Contains("X") | loadDir.Equals("1"))
            {
                if (loadForceType.Equals("Force"))
                    linearLoadForce.ForceX = loadForceValue;
                else
                    linearLoadForce.MomentX = loadForceValue;
            }
            else if (loadDir.Contains("Y") | loadDir.Equals("3"))
            {
                if (loadForceType.Equals("Force"))
                    linearLoadForce.ForceY = loadForceValue;
                else
                    linearLoadForce.MomentY = loadForceValue;
            }
            else
            {
                if (loadForceType.Equals("Force"))
                {
                    linearLoadForce.ForceZ = loadForceValue;
                    if (loadDir.Equals("Gravity"))
                        linearLoadForce.ForceZ *= -1;
                }
                else
                {
                    linearLoadForce.MomentZ = loadForceValue;
                    if (loadDir.Equals("Gravity"))
                        linearLoadForce.MomentZ *= -1;
                }
            }
            return linearLoadForce;

        }
        SurfaceLoadForce CreateSurfaceLoadForceValue(SapParserParser.Table_rowContext tableRowCtx)
        {
            var surfaceLoadForce = new SurfaceLoadForce();
            var loadDir = GetValueOf("Dir", tableRowCtx).ToString();
            var loadForceValue = Convert.ToDouble(GetValueOf("UnifLoad", tableRowCtx));
            surfaceLoadForce.Coordinates = GetLoadForceCoordinated(tableRowCtx); //loadCoordSys.Equals("Local") ? LoadForceCoordinates.Local : LoadForceCoordinates.Global_True_Length;
            if (loadDir.Contains("X") | loadDir.Equals("1"))
                surfaceLoadForce.ForceX = loadForceValue;
            else if (loadDir.Contains("Y") | loadDir.Equals("2"))
                surfaceLoadForce.ForceY = loadForceValue;
            else
            {
                surfaceLoadForce.ForceZ = loadForceValue;
                if (loadDir.Equals("Gravity"))
                    surfaceLoadForce.ForceZ *= -1;
            }
            return surfaceLoadForce;
        }


        LoadForceCoordinates GetLoadForceCoordinated(SapParserParser.Table_rowContext tableRowCtx)
        {
            var loadCoordSys = GetValueOf("CoordSys", tableRowCtx);
            var loadDir = GetValueOf("Dir", tableRowCtx).ToString();
            return loadCoordSys.Equals("Local") ? LoadForceCoordinates.Local : loadDir.Contains("Proj") ? LoadForceCoordinates.Global_Projected_Length : LoadForceCoordinates.Global_True_Length;
        }
        void AddLoadToLists(Load load, string loadPatternName)
        {
            _loads.Add(load);
            _loadPatLoads[loadPatternName].Add(load);
        }
        #endregion
        #region Load Case
        public override object VisitLoadCaseTable([NotNull] SapParserParser.LoadCaseTableContext context)
        {
            var loadCasesDefsRows = context.table_content().table_row().ToList();
            int loadCaseId = 1;
            foreach (var row in loadCasesDefsRows)
            {
                //  var loadPat = GetValueOf("DesignType", row).ToString();
                var loadCaseType = GetValueOf("Type", row);
                if (loadCaseType.Equals("LinStatic"))
                {
                    var loadCas = new LoadCase()
                    {
                        Id = loadCaseId++,
                        Name = (string)GetValueOf("Case", row),
                        LoadCaseType = GetLoadCaseType(GetValueOf("DesignType", row).ToString()),
                        Loads = new List<Load>()
                    };
                    _loadCases.Add(loadCas);
                }
            }
            return null;//return base.VisitLoadCaseTable(context);
        }
        public override object VisitLoadCaseAssignmentsTable([NotNull] SapParserParser.LoadCaseAssignmentsTableContext context)
        {
            var loadCasesRows = context.table_content().table_row();
            foreach (var row in loadCasesRows)
            {
                var loadPat = GetValueOf("LoadName", row).ToString();
                var loadCase = _loadCases.First(l => l.Name.Equals(GetValueOf("Case", row)));
                loadCase.ScaleFactorCoefficient = Convert.ToDouble(GetValueOf("LoadSF", row));
                loadCase.Loads = GetLoadPatLoads(loadPat);
            }
            return null;//return base.VisitLoadCaseAssignmentsTable(context);
        }
        public override object VisitLoadPatternsTable([NotNull] SapParserParser.LoadPatternsTableContext context)
        {
            var loadPatterns = context.table_content().table_row();
            foreach (var row in loadPatterns)
            {
                _loadPatLoads.Add(GetValueOf("LoadPat", row).ToString(), new List<Load>());
            }
            return null;//return base.VisitLoadPatternsTable(context);
        }

        LoadCaseType GetLoadCaseType(string sapLoadCase)
        {
            switch (sapLoadCase)
            {
                case "Dead":
                    return LoadCaseType.Dead;
                case "Live":
                    return LoadCaseType.Live;
                case "Wind":
                    return LoadCaseType.Wind;
                default:
                    return LoadCaseType.Other;
            }
        }

        List<Load> GetLoadPatLoads(string loadPat)
        => _loadPatLoads[loadPat].ToList();
        #endregion
        #region Load Combinations
        public override object VisitLoadCombinationTable([NotNull] SapParserParser.LoadCombinationTableContext context)
        {
            var loadCombRows = context.table_content().table_row();
            int loadCombId = 1;
            foreach (var row in loadCombRows)
            {
                var loadCombName = GetValueOf("ComboName", row).ToString();
                var currLoadCombination = _loadCombinations.FirstOrDefault(l => l.Name.Equals(loadCombName));
                if (currLoadCombination == null)
                {
                    currLoadCombination = new LoadCombination()
                    {
                        Id = loadCombId++,
                        Name = loadCombName,
                        LoadCombinationItems = new List<LoadCombinationItem>()
                    };
                    _loadCombinations.Add(currLoadCombination);
                }
                var loadCaseName = GetValueOf("CaseName", row).ToString();
                var loadCase = _loadCases.FirstOrDefault(l => l.Name.Equals(loadCaseName));
                if (loadCase != null)
                {

                    LoadCombinationItem loadCombItem = new LoadCombinationItem()
                    {
                        LoadCaseId = loadCase.Id,
                        LoadCaseName = loadCaseName,
                        Factor = Convert.ToDouble(GetValueOf("ScaleFactor", row)),

                    };

                    currLoadCombination.LoadCombinationItems.Add(loadCombItem);
                }
            }
            //foreach (var row in loadCombRows)
            //{
            //    var loadCombName = GetValueOf("ComboName", row).ToString();
            //    if (_loadCombinations.Select(l => l.Name).Contains(loadCombName))
            //        continue;
            //    LoadCombination loadComb = new LoadCombination()
            //    {
            //        Id = loadCombId++,
            //        Name = loadCombName,
            //        LoadCombinationItems = new List<LoadCombinationItem>()
            //    };
            //    _loadCombinations.Add(loadComb);
            //}
            //foreach (var row in loadCombRows)
            //{
            //    var loadCombName = GetValueOf("ComboName", row).ToString();
            //    var loadCaseName = GetValueOf("CaseName", row).ToString();
            //    LoadCombinationItem loadCombItem = new LoadCombinationItem()
            //    {
            //        LoadCaseId = _loadCases.First(l => l.Name.Equals(loadCaseName)).Id,
            //        LoadCaseName = loadCaseName,
            //        Factor = (double)GetValueOf("ScaleFactor", row),

            //    };
            //    _loadCombinations.First(lc => lc.Name.Equals(loadCombName)).LoadCombinationItems.Add(loadCombItem);
            //}
            return null;//return base.VisitLoadCombinationTable(context);
        }
        #endregion
        #region Joints
        public override object VisitPointsTable([NotNull] SapParserParser.PointsTableContext context)
        {
            var sapPoints = context.table_content().table_row().ToList();
            foreach (var point in sapPoints)
            {
                Point p = new Point();
                p.Id = Convert.ToInt32(point.table_row_item().First(i => i.TEXT().GetText().Equals("Joint")).data().GetText());
                p.X = Convert.ToDouble(point.table_row_item().First(i => i.TEXT().GetText().Equals("XorR")).data().GetText());
                p.Y = Convert.ToDouble(point.table_row_item().First(i => i.TEXT().GetText().Equals("Y")).data().GetText());
                p.Z = Convert.ToDouble(point.table_row_item().First(i => i.TEXT().GetText().Equals("Z")).data().GetText());
                _points.Add(p);
            }
            return null;//return base.VisitPointsTable(context);
        }
        public override object VisitBoundaryConditionsTable([NotNull] SapParserParser.BoundaryConditionsTableContext context)
        {
            var sapPointsRestraints = context.table_content().table_row().ToList();
            foreach (var item in sapPointsRestraints)
            {
                var jointId = Convert.ToInt32(item.table_row_item().First(i => i.TEXT().GetText().Equals("Joint")).data().GetText());
                _points.First(p => p.Id.Equals(jointId)).BoundaryCondition = new BoundaryCondition()
                {
                    IsFreeTransX = ConvertSapBool(item.table_row_item().First(i => i.TEXT().GetText().Equals("U1")).data().GetText()),
                    IsFreeTransY = ConvertSapBool(item.table_row_item().First(i => i.TEXT().GetText().Equals("U2")).data().GetText()),
                    IsFreeTransZ = ConvertSapBool(item.table_row_item().First(i => i.TEXT().GetText().Equals("U3")).data().GetText()),
                    IsFreeMomentX = ConvertSapBool(item.table_row_item().First(i => i.TEXT().GetText().Equals("R1")).data().GetText()),
                    IsFreeMomentY = ConvertSapBool(item.table_row_item().First(i => i.TEXT().GetText().Equals("R2")).data().GetText()),
                    IsFreeMomentZ = ConvertSapBool(item.table_row_item().First(i => i.TEXT().GetText().Equals("R3")).data().GetText())
                };

            }
            return null;//return base.VisitBoundaryConditionsTable(context);
        }
        bool ConvertSapBool(string text)
            => !(text == "Yes");
        #endregion
        #region Materials
        public override object VisitMaterialsPropertiesTable([NotNull] SapParserParser.MaterialsPropertiesTableContext context)
        {
            var materialsProperties = context.table_content().table_row().ToList();
            foreach (var mtrial in materialsProperties)
            {
                Material m = new Material();
                m.Name = GetValueOf("Material", mtrial).ToString(); //mtrial.table_row_item().First(i => i.TEXT().GetText().Equals("Material")).data().GetText();
                m.ShearModulus = Convert.ToDouble(mtrial.table_row_item().FirstOrDefault(i => i.TEXT().GetText().Equals("G12"))?.data()?.GetText());
                m.ThermalExpanssionC = Convert.ToDouble(mtrial.table_row_item().FirstOrDefault(i => i.TEXT().GetText().Equals("A1"))?.data()?.GetText());
                m.PoissonRatio = Convert.ToDouble(mtrial.table_row_item().FirstOrDefault(i => i.TEXT().GetText().Equals("U12"))?.data()?.GetText());
                m.YoungModulus = Convert.ToDouble(mtrial.table_row_item().FirstOrDefault(i => i.TEXT().GetText().Equals("E1"))?.data()?.GetText());
                m.WeightDensity = Convert.ToDouble(mtrial.table_row_item().FirstOrDefault(i => i.TEXT().GetText().Equals("UnitWeight"))?.data()?.GetText());
                _materials.Add(m);
            }
            return null;
            // return null;//return base.VisitMaterialsPropertiesTable(context);
        }
        public override object VisitMaterialsTable([NotNull] SapParserParser.MaterialsTableContext context)
        {
            var materialsTypes = context.table_content().table_row().ToList();
            foreach (var mtrial in materialsTypes)
            {
                _materials.First(m => m.Name.Equals(GetValueOf("Material", mtrial))).Type = GetType(GetValueOf("Type", mtrial).ToString());
            }
            //  return null;//return base.VisitMaterialsTable(context);
            return null;
        }
        MaterialType GetType(string matrilType)
        {
            switch (matrilType)
            {
                case "Concrete":
                    return MaterialType.Concrete;
                case "Steel":
                    return MaterialType.Steel;
                default:
                    return MaterialType.Other;
            }
        }
        #endregion
        #region FrameSectionsProperties
        public override object VisitFrameSectionsTable([NotNull] SapParserParser.FrameSectionsTableContext context)
        {
            var frameSections = context.table_content().table_row().ToList();
            foreach (var item in frameSections)
            {
                Section framSection = new Section();
                var sectionMaterialName = item.table_row_item().FirstOrDefault(i => i.TEXT().GetText().Equals("Material")) != null ? GetValueOf("Material", item) : null;//item.table_row_item().First(i => i.TEXT().GetText().Equals("Material")).data().GetText();
                framSection.Material = sectionMaterialName == null ? null : _materials.FirstOrDefault(m => m.Name.Equals(sectionMaterialName));
                var sectionProfileShape = (string)GetValueOf("Shape", item);//item.table_row_item().First(i => i.TEXT().GetText().Equals("Shape")).data().GetText();
                if (sectionProfileShape == "Rectangular")
                    framSection.Profile = GetRectangularSectionProfile(item);
                else if (sectionProfileShape.Equals("I/Wide Flange"))
                    framSection.Profile = GetIShapeSectionProfile(item);
                _frameSections.Add(framSection);
            }
            // return null;//return base.VisitFrameSectionsTable(context);
            return null;
        }
        RecangularProfile GetRectangularSectionProfile(SapParserParser.Table_rowContext tableRow)
        {
            RecangularProfile secProfile = new RecangularProfile();
            secProfile.SectionProfileName = (string)GetValueOf("SectionName", tableRow);//tableRow.table_row_item().First(i => i.TEXT().GetText().Equals("SectionName")).data().GetText();
            secProfile.Depth = Convert.ToDouble(GetValueOf("t3", tableRow));//Convert.ToDouble(tableRow.table_row_item().First(i => i.TEXT().GetText().Equals("t3")).data().GetText());
            secProfile.Width = Convert.ToDouble(GetValueOf("t2", tableRow));//Convert.ToDouble(tableRow.table_row_item().First(i => i.TEXT().GetText().Equals("t2")).data().GetText());           
            return secProfile;
        }
        IShapeProfile GetIShapeSectionProfile(SapParserParser.Table_rowContext tableRow)
        {
            IShapeProfile secProfile = new IShapeProfile();
            secProfile.SectionProfileName = (string)GetValueOf("SectionName", tableRow);//tableRow.table_row_item().First(i => i.TEXT().GetText().Equals("SectionName")).data().GetText();
            secProfile.OverallHeight = Convert.ToDouble(GetValueOf("t3", tableRow));//Convert.ToDouble(tableRow.table_row_item().First(i => i.TEXT().GetText().Equals("t3")).data().GetText());
            secProfile.WebThickness = Convert.ToDouble(GetValueOf("tw", tableRow));// Convert.ToDouble(tableRow.table_row_item().First(i => i.TEXT().GetText().Equals("tw")).data().GetText());
            secProfile.TopFlangeWidth = Convert.ToDouble(GetValueOf("t2", tableRow));//Convert.ToDouble(tableRow.table_row_item().First(i => i.TEXT().GetText().Equals("t2")).data().GetText());
            secProfile.TopFlangeThickness = Convert.ToDouble(GetValueOf("tf", tableRow));// Convert.ToDouble(tableRow.table_row_item().First(i => i.TEXT().GetText().Equals("tf")).data().GetText());
            secProfile.BottomFlangeWidth = Convert.ToDouble(GetValueOf("t2b", tableRow));//Convert.ToDouble(tableRow.table_row_item().First(i => i.TEXT().GetText().Equals("t2b")).data().GetText());
            secProfile.BottomFlangeThickness = Convert.ToDouble(GetValueOf("tfb", tableRow));//Convert.ToDouble(tableRow.table_row_item().First(i => i.TEXT().GetText().Equals("tfb")).data().GetText());
            return secProfile;
        }
        #endregion
        #region FrameElements
        public override object VisitFrameElementsJointsTable([NotNull] SapParserParser.FrameElementsJointsTableContext context)
        {
            var framElmntsJoints = context.table_content().table_row().ToList();
            foreach (var row in framElmntsJoints)
            {
                var id = (int)GetValueOf("Frame", row);
                List<Point> framPoints = new List<Point>();
                var elmntJointsIds = row.table_row_item().Where(i => i.TEXT().GetText().StartsWith("Joint")).ToList();
                foreach (var item in elmntJointsIds)
                    framPoints.Add(_points.First(p => p.Id.Equals(Visit(item.data()))));

                var fElmnt = new FrameElement() { Id = id, Vertices = framPoints };
                _frameElements.Add(fElmnt);
            }
            // return null;//return base.VisitFrameElementsJointsTable(context);
            return null;
        }
        public override object VisitFrameElementsSectionsTable([NotNull] SapParserParser.FrameElementsSectionsTableContext context)
        {
            var fElmntsSections = context.table_content().table_row().ToList();
            foreach (var row in fElmntsSections)
            {
                var fElmntId = GetValueOf("Frame", row);
                var fElmntSection = row.table_row_item().FirstOrDefault(i => i.TEXT().GetText().Equals("AnalSect")) == null ? null : (string)GetValueOf("AnalSect", row);
                if (fElmntSection != null)
                    _frameElements.First(f => f.Id.Equals(fElmntId)).Section = _frameSections.FirstOrDefault(s => s.Profile != null && s.Profile.SectionProfileName.Equals(fElmntSection));
            }
            return null;//return null;//return base.VisitFrameElementsSectionsTable(context);
        }
        #endregion

        #region Model Creation
        Model GetModel()
        {
            EnsureElementsHaveUniqueIds();
            EnsureLoadCombosAndLoadCasesHaveDifferenIds();
            return new Model
            {
                Units = _projectUnits,
                Elements = new Element[0].Concat(_frameElements).Concat(_areaElements).ToList(),
                LoadCases = _loadCases,
                LoadCombinations = _loadCombinations
            };
        }
        /// <summary>
        /// this function is used to assign unique ids to elements. This happense because SAP2000  treats areaElements and frame elements as different tables so it gives the same id to areaElement and frameElements however some other softwares like staad assigns different ids to area elements and frame elements and does not accept any file that has an areaElement with id identical to a frameElement id       
        /// </summary>
        void EnsureElementsHaveUniqueIds()
        {

            var maxFrameElmntId = _frameElements.Max(f => f.Id); // this object is used to assign unique ids to area elements by adding this int to each area element id from sap file. This happense because SAP2000  treats areaElements and frame elements as different tables so it can give the same id to areaElement and frameElements however some other softwares like staad assigns different ids to area elements and frame elements and does not accept any file that has an areaElement with id identical to a frameElement id
            foreach (var areaElmnt in _areaElements)
                areaElmnt.Id += maxFrameElmntId;

            //Ids are also used to relate loads to elements, so we have to modify that also
            var areaElmntsLoads = _loadPatLoads.SelectMany(l => l.Value).Where(l => l.LoadForce is SurfaceLoadForce);
            foreach (var areaElmntLoad in areaElmntsLoads)
                areaElmntLoad.AppliedOnId += maxFrameElmntId;


        }
        /// <summary>
        /// this function is used to assign unique ids to load combos and load cases. This happense because SAP2000  treats loadCases and loadCombos as different tables so it gives the same id to loadCombo and loadCase however some other softwares like staad assigns different ids to loadCombos and loadCases and does not accept any file that has a loadCombo with id identical to a loadCase id       
        /// </summary>

        void EnsureLoadCombosAndLoadCasesHaveDifferenIds()
        {
            var maxLoadCaseId = _loadCases.Max(l => l.Id);// this object is used to assign unique ids to loadCombos by adding this int to each loadCombo id from sap file.. This happense because SAP2000  treats loadCases and loadCombos as different tables so it gives the same id to loadCombo and loadCase however some other softwares like staad assigns different ids to loadCombos and loadCases and does not accept any file that has a loadCombo with id identical to a loadCase id       
            foreach (var loadCombo in _loadCombinations)
                loadCombo.Id += maxLoadCaseId;
        }
        #endregion  

        public override object VisitDoubleQoutedTextData([NotNull] SapParserParser.DoubleQoutedTextDataContext context)
        => context.GetText().Replace("\"", string.Empty);

        public override object VisitTextData([NotNull] SapParserParser.TextDataContext context)
        => context.GetText();

        public override object VisitDoubleData([NotNull] SapParserParser.DoubleDataContext context)
        => Convert.ToDouble(context.GetText());


        public override object VisitIntigerData([NotNull] SapParserParser.IntigerDataContext context)
        => Convert.ToInt32(context.GetText());


        object GetValueOf(string tableRowItemName, SapParserParser.Table_rowContext tableRow)
           => Visit(tableRow.table_row_item().First(i => i.TEXT().GetText().Equals(tableRowItemName)).data());

        ForceUnit GetForceUnit(string sapUnit)
        {
            switch (sapUnit)
            {
                case "lb":
                    return ForceUnit.Lb;
                case "Kip":
                    return ForceUnit.Kip;
                case "Kgf":
                    return ForceUnit.Kgf;
                case "N":
                    return ForceUnit.N;
                case "Tonf":
                    return ForceUnit.Tonf;
                default:
                    return ForceUnit.KN;
            }
        }

        LengthUnit GetLengthUnit(string sapUnit)
        {
            switch (sapUnit)
            {
                case "cm":
                    return LengthUnit.Cm;
                case "mm":
                    return LengthUnit.Mm;
                case "ft":
                    return LengthUnit.Ft;
                case "in":
                    return LengthUnit.In;
                default:
                    return LengthUnit.M;

            }
        }
        TemperatureUnit GetTemperUnit(string sapUnit)
        {
            switch (sapUnit)
            {
                case "F":
                    return TemperatureUnit.F;
                default:
                    return TemperatureUnit.C;
            }
        }

    }
}
