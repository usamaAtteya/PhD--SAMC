using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using SAMC2;

namespace StaadConverter.StaadReader
{
    public class StaadVisitor : StaadParserBaseVisitor<Object>
    {
        ProjectUnits _projectUnits;
        List<Point> _points = new List<Point>();
        List<Element> _elements = new List<Element>();
        List<Material> _materials = new List<Material>();
        List<Section> _areaSections = new List<Section>();
        List<Section> _frameSections = new List<Section>();
        List<LoadCase> _loadCases = new List<LoadCase>();
        List<LoadCombination> _loadCombinations = new List<LoadCombination>();
        public override object VisitFile([NotNull] StaadParserParser.FileContext context)
        {

            var orderedSectionsToVisit = new List<StaadParserParser.SectionContext>();
            orderedSectionsToVisit.Add(context.GetChild<StaadParserParser.UnitsSectionContext>(0));
            orderedSectionsToVisit.Add(context.GetChild<StaadParserParser.PointsSectionContext>(0));
           // orderedSectionsToVisit.Add(context.GetChild<StaadParserParser.BoundaryConditionsSectionContext>(0));
            orderedSectionsToVisit.AddRange(context.children.Where(c => c.GetType().Equals(typeof(StaadParserParser.BoundaryConditionsSectionContext))).Cast<StaadParserParser.BoundaryConditionsSectionContext>());

            //orderedSectionsToVisit.Add(context.GetChild<StaadParserParser.FrameElementsSectionContext>(0));
            orderedSectionsToVisit.AddRange(context.children.Where(c => c.GetType().Equals(typeof(StaadParserParser.FrameElementsSectionContext))).Cast<StaadParserParser.FrameElementsSectionContext>());

           // orderedSectionsToVisit.Add(context.GetChild<StaadParserParser.FrameElementsSectionsSectionContext>(0));
            orderedSectionsToVisit.AddRange(context.children.Where(c => c.GetType().Equals(typeof(StaadParserParser.FrameElementsSectionsSectionContext))).Cast<StaadParserParser.FrameElementsSectionsSectionContext>());

           // orderedSectionsToVisit.Add(context.GetChild<StaadParserParser.AreaElementsSectionContext>(0));
            orderedSectionsToVisit.AddRange(context.children.Where(c => c.GetType().Equals(typeof(StaadParserParser.AreaElementsSectionContext))).Cast<StaadParserParser.AreaElementsSectionContext>());

            //orderedSectionsToVisit.Add(context.GetChild<StaadParserParser.AreaElementsSectionsSectionContext>(0));
            orderedSectionsToVisit.AddRange(context.children.Where(c => c.GetType().Equals(typeof(StaadParserParser.AreaElementsSectionsSectionContext))).Cast<StaadParserParser.AreaElementsSectionsSectionContext>());

            orderedSectionsToVisit.AddRange(context.children.Where(c => c.GetType().Equals(typeof(StaadParserParser.MaterialSectionContext))).Cast<StaadParserParser.SectionContext>());
            orderedSectionsToVisit.Add(context.GetChild<StaadParserParser.MaterialAssignmentSectionContext>(0));
            orderedSectionsToVisit.AddRange(context.children.Where(c => c.GetType().Equals(typeof(StaadParserParser.LoadCaseSectionContext))).Cast<StaadParserParser.SectionContext>());
            orderedSectionsToVisit.AddRange(context.children.Where(c => c.GetType().Equals(typeof(StaadParserParser.LoadComboSectionContext))).Cast<StaadParserParser.SectionContext>());
            foreach (var sectionCtx in orderedSectionsToVisit)
                if (sectionCtx != null)
                    Visit(sectionCtx);

            return GetModel();
        }

        #region Units
        public override object VisitUnitsSection([NotNull] StaadParserParser.UnitsSectionContext context)
        {
            if (_projectUnits == null) //there is a bug in staad file that allows users to define multiple units Sections
                _projectUnits = new ProjectUnits() { LengthUnit = GetLengthUnit(context), ForceUnit = GetForceUnit(context) };
            return null;//return base.VisitUnitsSection(context);
        }
        LengthUnit GetLengthUnit(StaadParserParser.UnitsSectionContext context)
        {
            var staadLengthUnit = context.data()[0].GetText();
            switch (staadLengthUnit.ToUpper())
            {
                case "INCHES":
                    return LengthUnit.In;
                case "FEET":
                    return LengthUnit.Ft;
                case "MMS":
                    return LengthUnit.Mm;
                case "CM":
                    return LengthUnit.Cm;
                default:
                    return LengthUnit.M;
            }
        }
        ForceUnit GetForceUnit(StaadParserParser.UnitsSectionContext context)
        {
            var staadForceUnit = context.data()[1].GetText();
            switch (staadForceUnit.ToUpper())
            {

                case "POUND":
                    return ForceUnit.Lb;
                case "KIP":
                    return ForceUnit.Kip;
                case "MTON":
                    return ForceUnit.Tonf;
                case "KG":
                    return ForceUnit.Kgf;
                case "NEWTON":
                    return ForceUnit.N;
                default:
                    return ForceUnit.KN;
            }
        }
        #endregion
        #region Points
        public override object VisitPointsSection([NotNull] StaadParserParser.PointsSectionContext context)
        {

            foreach (var pointCtx in context.semi_colon_separated_section_content().semi_colon_separated_row())
            {
                var pointDeatilsCtx = pointCtx.data();
                _points.Add(
                  new Point()
                  {
                      Id = (int)Visit(pointDeatilsCtx[0]),
                      X = Convert.ToDouble(Visit(pointDeatilsCtx[1])),
                      Y = Convert.ToDouble(Visit(pointDeatilsCtx[2])),
                      Z = Convert.ToDouble(Visit(pointDeatilsCtx[3]))
                  }
                    );

            }
            return null;//return base.VisitPointsSection(context);
        }
        #endregion
        #region Frame Eleemnts
        public override object VisitFrameElementsSection([NotNull] StaadParserParser.FrameElementsSectionContext context)
        {

            foreach (var frameElmntCtx in context.semi_colon_separated_section_content().semi_colon_separated_row())
            {
                var frameElmntDeatilsCtx = frameElmntCtx.data();
                _elements.Add(
                  new FrameElement()
                  {
                      Id = (int)Visit(frameElmntDeatilsCtx[0]),
                      Vertices = new List<Point>()
                      {
                        GetPointById(Visit(frameElmntDeatilsCtx[1])),
                        GetPointById(Visit(frameElmntDeatilsCtx[2]))
                      }
                  }
                    );

            }
            return null;//return base.VisitFrameElementsSection(context);
        }
        #endregion
        #region Area Elements
        public override object VisitAreaElementsSection([NotNull] StaadParserParser.AreaElementsSectionContext context)
        {
            foreach (var areaElmntCtx in context.semi_colon_separated_section_content().semi_colon_separated_row())
            {
                var areaElmntDeatilsCtx = areaElmntCtx.data();
                var areaElmnt = new AreaElement() { Id = (int)Visit(areaElmntDeatilsCtx[0]), Vertices = new List<Point>() };
                foreach (var pointIdCtx in areaElmntDeatilsCtx.Skip(1))
                    areaElmnt.Vertices.Add(GetPointById(Visit(pointIdCtx)));
                _elements.Add(areaElmnt);
            }
            return null;//return base.VisitAreaElementsSection(context);
        }
        #endregion
        #region Material Definition
        public override object VisitMaterialSection([NotNull] StaadParserParser.MaterialSectionContext context)
        {
            foreach (var matDefCtx in context.material_definition())
            {
                var matName = String.Join(" ", matDefCtx.data().Select(e => Visit(e).ToString()));
                var poisonRatio = GetMaterialProperty("POISSON", matDefCtx);//matDefCtx.material_property().FirstOrDefault(p => Visit(p.data()[0]).Equals("POISSON"));
                var shearMod = GetMaterialProperty("G", matDefCtx);
                var thermalExp = GetMaterialProperty("ALPHA", matDefCtx);
                var weightUnitVol = GetMaterialProperty("DENSITY", matDefCtx);
                var youngMod = GetMaterialProperty("E", matDefCtx);
                var materialType = matDefCtx.material_property().FirstOrDefault(p => Visit(p.data()[0]).Equals("TYPE"))?.data()?[1].GetText();
                _materials.Add(
                    new Material()
                    {
                        Name = matName,
                        PoissonRatio = poisonRatio,
                        ShearModulus = shearMod,
                        ThermalExpanssionC = thermalExp,
                        WeightDensity = weightUnitVol,
                        YoungModulus = youngMod,
                        Type=GetType(materialType)
                    });

            }



            return null;//return base.VisitMaterialSection(context);
        }
        MaterialType GetType(string matrilType)
        {
            switch (matrilType)
            {
                case "CONCRETE":
                    return MaterialType.Concrete;
                case "STEEL":
                    return MaterialType.Steel;
                default:
                    return MaterialType.Other;
            }
        }
        double GetMaterialProperty(string matPropName, StaadParserParser.Material_definitionContext matDefCtx)
   => Convert.ToDouble(matDefCtx.material_property().FirstOrDefault(p => Visit(p.data()[0]).Equals(matPropName))?.data()?[1].GetText() ?? "0");

        #endregion
        #region Material Assignment
        public override object VisitMaterialAssignmentSection([NotNull] StaadParserParser.MaterialAssignmentSectionContext context)
        {


            if (context.material_assignment_row() != null)
            {

                foreach (var matAssignRowCtx in context.material_assignment_row())
                {
                    if (matAssignRowCtx.data()[0].GetText().ToUpper().Equals("MATERIAL"))
                    {


                        var matName = matAssignRowCtx.data()[1].GetText();
                        var material = _materials.First(m => m.Name.Split(' ')[0].Equals(matName));
                        var materialSections = GetMaterialSections(matAssignRowCtx);
                        foreach (var section in materialSections)
                            section.Material = material;
                    }
                }
            }
            return null;//return base.VisitMaterialAssignmentSection(context);
        }
        List<Section> GetMaterialSections(StaadParserParser.Material_assignment_rowContext context)
        {
            //if (context.material_assignment_row_value().children[0].GetText().ToUpper().Equals("ALL"))
            //    return _elements;
            var elmntsIdCtx = context.material_assignment_row_value().id_definition_list();
            if (elmntsIdCtx == null)
                return _elements.Select(e => e.Section).Where(s=>s.Material ==null).ToList();//new Section[0].Concat(_areaSections.Where(s => s.Material == null)).Concat(_frameSections.Where(s => s.Material == null)).ToList();
            var ids = (List<int>)Visit(elmntsIdCtx);
            return _elements.Where(e => ids.Contains(e.Id))
                .Select(e => e.Section)
                .Where(s => s.Material == null).ToList();
                //.GroupBy(s => s.Profile.SectionProfileName)
                //.Select(s => s.First())
                //.Where(s => s.Material == null).ToList();
         
        }
        #endregion
        #region Load Case
        public override object VisitLoadCaseSection([NotNull] StaadParserParser.LoadCaseSectionContext context)
        {

            var loadCaseId = GetLoadCaseId(context);
            var loadCaseType = GetLoadCaseType(context);
            var loadCaseTitle = GetLoadCaseTitle(context);
            var loadInnerSectionsCtx = context.load_inner_section();
            _loadCases.Add(new LoadCase()
            {
                Id = loadCaseId,
                LoadCaseType = loadCaseType,
                Name = loadCaseTitle,
                Loads = new Load[0].Concat(GetLoadCaseJointLoads(loadInnerSectionsCtx.FirstOrDefault(i => i.joint_load_section() != null)?.joint_load_section()))
                .Concat(GetLoadCaseFrameLoads(loadInnerSectionsCtx.FirstOrDefault(i => i.member_load_section() != null)?.member_load_section()))
                .Concat(GetLoadCaseAreaLoads(loadInnerSectionsCtx.FirstOrDefault(i => i.element_load_section() != null)?.element_load_section()))
                .ToList()
            });
            return null;//return base.VisitLoadCaseSection(context);
        }


        #region Point Loads
        List<Load> GetLoadCaseJointLoads(StaadParserParser.Joint_load_sectionContext context)
        {
            var loads = new List<Load>();
            //   var joinLoadSection = context.GetChild<StaadParserParser.Joint_load_sectionContext>(0);
            if (context == null)
                return loads;
            foreach (var jointLoadRowCtx in context.joint_load_row())
            {
                var elmntsIds = (List<int>)Visit(jointLoadRowCtx.id_definition_list());
                var loadForce = GetPointLoadForce(jointLoadRowCtx);
                foreach (var elmntId in elmntsIds)
                    loads.Add(new Load() { AppliedOnId = elmntId, LoadForce = loadForce });

            }

            return loads;
        }
        PointLoadForce GetPointLoadForce([NotNull]StaadParserParser.Joint_load_rowContext jointLoadRowCtx)
        {
            var loadForce = new PointLoadForce();

            loadForce.ForceX = GetPointLoadForceOf("FX", jointLoadRowCtx);
            loadForce.ForceY = GetPointLoadForceOf("FY", jointLoadRowCtx);
            loadForce.ForceZ = GetPointLoadForceOf("FZ", jointLoadRowCtx);
            loadForce.MomentX = GetPointLoadForceOf("MX", jointLoadRowCtx);
            loadForce.MomentY = GetPointLoadForceOf("MY", jointLoadRowCtx);
            loadForce.MomentZ = GetPointLoadForceOf("MZ", jointLoadRowCtx);

            return loadForce;
        }
        double GetPointLoadForceOf(string staadForceName, [NotNull] StaadParserParser.Joint_load_rowContext jointLoadRowCtx)
        {
            var forceLoadCtx = jointLoadRowCtx.data().ToList();

            if (forceLoadCtx.FirstOrDefault(d => Visit(d).Equals(staadForceName)) == null)
                return 0;
            var forceLoadIndex = forceLoadCtx.FindIndex(d => Visit(d).Equals(staadForceName));
            return Convert.ToDouble(jointLoadRowCtx.data()[forceLoadIndex + 1].GetText());
        }
        #endregion
        #region Area Loads
        List<Load> GetLoadCaseAreaLoads(StaadParserParser.Element_load_sectionContext context)
        {
            var loads = new List<Load>();
            // var elmntLoadSection = context.GetRuleContext<StaadParserParser.Element_load_sectionContext>(0);
            if (context == null)
                return loads;
            foreach (var elmntLoadRowCtx in context.generic_row())
            {
                var elmntsIds = (List<int>)Visit(elmntLoadRowCtx.id_definition_list());
                var loadForce = GetSurfaceLoadForce(elmntLoadRowCtx);
                foreach (var elmntId in elmntsIds)
                    loads.Add(new Load() { AppliedOnId = elmntId, LoadForce = loadForce });

            }
            return loads;
        }
        SurfaceLoadForce GetSurfaceLoadForce(StaadParserParser.Generic_rowContext elementLoadRowCtx)
        {
            //if (!elementLoadRowCtx.assignment_definition().TEXT().GetText().Equals("PR"))
            //    return null;
            var surfaceLoadForce = new SurfaceLoadForce();
            var forceLoadCtx = elementLoadRowCtx.assignment_definition().data();
            var forceLoadDir = forceLoadCtx[0].GetText();
            var forceLoadValue = GetAreaLoadForceValue(elementLoadRowCtx);

            surfaceLoadForce.Coordinates = GetAreaLoadForceCoordinate(elementLoadRowCtx);

            if (forceLoadCtx[0].GetText().Contains("Y"))
                surfaceLoadForce.ForceY = forceLoadValue;
            else if (forceLoadCtx[0].GetText().Contains("X"))
                surfaceLoadForce.ForceX = forceLoadValue;
            else
                surfaceLoadForce.ForceZ = forceLoadValue;


            return surfaceLoadForce;
        }

        LoadForceCoordinates GetAreaLoadForceCoordinate(StaadParserParser.Generic_rowContext elementLoadRowCtx)
        {
            var forceLoadCtx = elementLoadRowCtx.assignment_definition().data();
            var forceLoadDir = forceLoadCtx[0].GetText();
            if (forceLoadDir.Contains("G"))
                return LoadForceCoordinates.Global_True_Length;
            return LoadForceCoordinates.Local;
            //if (forceLoadCtx.Count() == 1) // it is the case of local Y No Need to handle this case coz if the load direction is ommited then the value at data[0] is number and of course does not contain G
            //    return LoadForceCoordinates.Local;

        }
        double GetAreaLoadForceValue(StaadParserParser.Generic_rowContext elementLoadRowCtx)
        {
            var forceLoadCtx = elementLoadRowCtx.assignment_definition().data();
            if (forceLoadCtx.Count() == 1)
                return Convert.ToDouble(Visit(forceLoadCtx[0]));
            return Convert.ToDouble(Visit(forceLoadCtx[1]));

        }
        #endregion
        #region Frame Loads
        List<Load> GetLoadCaseFrameLoads(StaadParserParser.Member_load_sectionContext context)
        {
            var loads = new List<Load>();

            // var memberLoadSection = context.GetRuleContext<StaadParserParser.Member_load_sectionContext>(0);
            if (context == null)
                return loads;
            foreach (var memberLoadRowCtx in context.generic_row())
            {
                var elmntsIds = (List<int>)Visit(memberLoadRowCtx.id_definition_list());
                var loadForce = GetLinearLoadForce(memberLoadRowCtx);
                foreach (var elmntId in elmntsIds)
                    loads.Add(new Load() { AppliedOnId = elmntId, LoadForce = loadForce });

            }

            return loads;
        }

        LinearLoadForce GetLinearLoadForce(StaadParserParser.Generic_rowContext elementLoadRowCtx)
        {
            //if (!elementLoadRowCtx.assignment_definition().TEXT().GetText().Equals("UNI"))
            //    return null;
            var linearLoadForce = new LinearLoadForce();
            var forceLoadCtx = elementLoadRowCtx.assignment_definition().data();
            var forceLoadDir = forceLoadCtx[0].GetText();
            var forceLoadValue = GetFrameLoadForceValue(elementLoadRowCtx);

            linearLoadForce.Coordinates = GetFrameLoadForceCoordinate(elementLoadRowCtx);

            if (forceLoadCtx[0].GetText().Contains("Z"))
                linearLoadForce.ForceZ = forceLoadValue;
            else if (forceLoadCtx[0].GetText().Contains("X"))
                linearLoadForce.ForceX = forceLoadValue;
            else
                linearLoadForce.ForceY = forceLoadValue;


            return linearLoadForce;
        }
        LoadForceCoordinates GetFrameLoadForceCoordinate(StaadParserParser.Generic_rowContext elementLoadRowCtx)
        {
            var forceLoadCtx = elementLoadRowCtx.assignment_definition().data();
            var forceLoadDir = forceLoadCtx[0].GetText();
            if (forceLoadDir.Contains("G"))
                return LoadForceCoordinates.Global_True_Length;
            else if (forceLoadDir.Contains("P"))
                return LoadForceCoordinates.Global_Projected_Length;
            else
                return LoadForceCoordinates.Local;
        }
        double GetFrameLoadForceValue(StaadParserParser.Generic_rowContext elementLoadRowCtx)
      => Convert.ToDouble(Visit(elementLoadRowCtx.assignment_definition().data()[1]));

        #endregion
        int GetLoadCaseId([NotNull] StaadParserParser.LoadCaseSectionContext context)
            => Convert.ToInt32(context.INTIGER().GetText());
        LoadCaseType GetLoadCaseType([NotNull] StaadParserParser.LoadCaseSectionContext context)
        {
            var loadCaseTypeCtxIndex = context.data().ToList().FindIndex(d => d.GetText().Equals("LOADTYPE"));
            var loadCaseTypeText = context.data()[loadCaseTypeCtxIndex + 1].GetText();
            switch (loadCaseTypeText.ToUpper())
            {
                case "DEAD":
                    return LoadCaseType.Dead;
                case "LIVE":
                    return LoadCaseType.Live;
                case "WIND":
                    return LoadCaseType.Wind;
                default:
                    return LoadCaseType.Other;
            }

        }
        string GetLoadCaseTitle([NotNull] StaadParserParser.LoadCaseSectionContext context)
        {
            var dataCtx = context.data().ToList();
            var loadCaseTypeCtxIndex = dataCtx.FindIndex(d => d.GetText().Equals("LOADTYPE"));
            var loadCaseTitleCtxIndex = dataCtx.FindIndex(d => d.GetText().Equals("TITLE"));
            if (loadCaseTypeCtxIndex > loadCaseTitleCtxIndex)
                return context.data()[loadCaseTitleCtxIndex].GetText();
            return string.Join(" ", dataCtx.Where(d => dataCtx.IndexOf(d) > loadCaseTitleCtxIndex).Select(d => d.GetText()));

        }

        #endregion
        #region Frame/Area Sections
        public override object VisitAreaElementsSectionsSection([NotNull] StaadParserParser.AreaElementsSectionsSectionContext context)
        {
            FillSectionsList(_areaSections, context.section_definition_section_content().section_definition_row());
            return null;//return base.VisitAreaElementsSectionsSection(context);
        }
        public override object VisitFrameElementsSectionsSection([NotNull] StaadParserParser.FrameElementsSectionsSectionContext context)
        {
            FillSectionsList(_frameSections, context.section_definition_section_content().section_definition_row());
            return null;//return base.VisitFrameElementsSectionsSection(context);
        }
        void FillSectionsList(List<Section> listToFill, [NotNull] StaadParserParser.Section_definition_rowContext[] sectionsCtx)
        {
            foreach (var sectionCtx in sectionsCtx)
            {
                var section = new Section();
                section.Profile = GetSectionProfile(sectionCtx.assignment_definition());
                var elmntsIds = (List<int>)Visit(sectionCtx.id_definition_list());
                foreach (var elmntId in elmntsIds)
                    _elements.First(e => e.Id.Equals(elmntId)).Section = section;
                listToFill.Add(section);
            }
        }
        SectionProfile GetSectionProfile(StaadParserParser.Assignment_definitionContext assignmetCtx)
        {
            var sectionIndicator = assignmetCtx.TEXT().GetText();
            if (sectionIndicator.Equals("THICKNESS"))
                return GetAreaSectionProfile(assignmetCtx);
            else if (sectionIndicator.Equals("PRIS") || sectionIndicator.Equals("TAPERED") || sectionIndicator.Equals("TAPPERED"))
                return GetFrameSectionProfile(assignmetCtx);
            else
                return null;
        }
        SectionProfile GetAreaSectionProfile(StaadParserParser.Assignment_definitionContext assignmetCtx)
        {
            var thickness = Convert.ToDouble(Visit(assignmetCtx.data()[0]));
            return new AreaSectionProfile() { SectionProfileName = $"Area-{assignmetCtx.Start.Line}-{thickness.ToString()}", Thickness = thickness };
        }

        SectionProfile GetFrameSectionProfile(StaadParserParser.Assignment_definitionContext assignmetCtx)
        {
            var sectionType = assignmetCtx.TEXT().GetText();
            if (sectionType.Equals("TAPERED") || sectionType.Equals("TAPPERED"))
                return GetISecProfile(assignmetCtx);
            else if (sectionType.Equals("PRIS"))
                return GetRectSecProfile(assignmetCtx);
            return null;
        }
        SectionProfile GetRectSecProfile(StaadParserParser.Assignment_definitionContext assignmetCtx)
        {
            StaadParserParser.DataContext depthCtx = null;
            StaadParserParser.DataContext widthCtx = null;
            var depth = 0d;
            var width = 0d;
            if (Visit(assignmetCtx.data()[0]).Equals("YD"))
            {
                depthCtx = assignmetCtx.data()[1];
                widthCtx = assignmetCtx.data()[3];
            }
            else
            {
                depthCtx = assignmetCtx.data()[3];
                widthCtx = assignmetCtx.data()[1];
            }
            depth = Convert.ToDouble(Visit(depthCtx));
            width = Convert.ToDouble(Visit(widthCtx));
            return new RecangularProfile() { Depth = depth, Width = width, SectionProfileName = $"RectSection-{assignmetCtx.Start.Line}- {depth}x{width}" };

        }
        SectionProfile GetISecProfile(StaadParserParser.Assignment_definitionContext assignmetCtx)
        => new IShapeProfile()
        {
            SectionProfileName = $"ISection-{assignmetCtx.Start.Line}",
            OverallHeight = Convert.ToDouble(Visit(assignmetCtx.data()[0])),
            WebThickness = Convert.ToDouble(Visit(assignmetCtx.data()[1])),
            TopFlangeWidth = Convert.ToDouble(Visit(assignmetCtx.data()[3])),
            TopFlangeThickness = Convert.ToDouble(Visit(assignmetCtx.data()[4])),
            BottomFlangeWidth = Convert.ToDouble(Visit(assignmetCtx.data()[5])),
            BottomFlangeThickness = Convert.ToDouble(Visit(assignmetCtx.data()[6])),

        };
        #endregion
        #region Boundary Conditions
        public override object VisitBoundaryConditionsSection([NotNull] StaadParserParser.BoundaryConditionsSectionContext context)
        {
            foreach (var bndCndRowCtx in context.generic_row())
            {
                var bndCnd = GetBoundaryCondition(bndCndRowCtx.assignment_definition());
                var pointsIds = (List<int>)Visit(bndCndRowCtx.id_definition_list());
                foreach (var pointId in pointsIds)
                    _points.First(p => p.Id.Equals(pointId)).BoundaryCondition = bndCnd;
            }
            return null;//return base.VisitBoundaryConditionsSection(context);
        }

        BoundaryCondition GetBoundaryCondition([NotNull] StaadParserParser.Assignment_definitionContext contex)
        {
            var bndCnd = new BoundaryCondition() { };
            var type = contex.TEXT().GetText();
            if (type.Equals("PINNED"))
            {
                bndCnd.IsFreeMomentX = true;
                bndCnd.IsFreeMomentY = true;
                bndCnd.IsFreeMomentZ = true;
            }
            if (contex.data()?.FirstOrDefault(d => Visit(d).Equals("FX")) != null)
                bndCnd.IsFreeTransX = true;
            if (contex.data()?.FirstOrDefault(d => Visit(d).Equals("FY")) != null)
                bndCnd.IsFreeTransY = true;
            if (contex.data()?.FirstOrDefault(d => Visit(d).Equals("FZ")) != null)
                bndCnd.IsFreeTransZ = true;
            if (contex.data()?.FirstOrDefault(d => Visit(d).Equals("MX")) != null)
                bndCnd.IsFreeMomentX = true;
            if (contex.data()?.FirstOrDefault(d => Visit(d).Equals("MY")) != null)
                bndCnd.IsFreeMomentY = true;
            if (contex.data()?.FirstOrDefault(d => Visit(d).Equals("MZ")) != null)
                bndCnd.IsFreeMomentZ = true;


            return bndCnd;
        }
        #endregion
        #region Load Combo
        public override object VisitLoadComboSection([NotNull] StaadParserParser.LoadComboSectionContext context)
        {
            var loadCombo = new LoadCombination()
            {
                Id = Convert.ToInt32(context.INTIGER().GetText()),
                Name = String.Join(" ", context.data().Select(d => d.GetText())),
                LoadCombinationItems = new List<LoadCombinationItem>()
            };
            if (context.load_combination_row() != null)
            {
                foreach (var loadComboRowCtx in context.load_combination_row())
                {
                    var loadComboRowDataCtx = loadComboRowCtx.load_combination_row_data();
                    for (int i = 0; i < loadComboRowDataCtx.Count(); i += 2)
                    {
                        var loadCaseId = Convert.ToInt32(loadComboRowDataCtx[i].GetText());
                        var loadCaseFactor = Convert.ToDouble(loadComboRowDataCtx[i + 1].GetText());
                        var loadCase = _loadCases.First(l => l.Id.Equals(loadCaseId));
                        loadCombo.LoadCombinationItems.Add(
                            new LoadCombinationItem()
                            {
                                LoadCaseId = loadCaseId,
                                LoadCaseName = loadCase.Name,
                                Factor = loadCaseFactor
                            }
                            );
                    }

                }
            }
            _loadCombinations.Add(loadCombo);

            return null;//return base.VisitLoadComboSection(context);
        }
        #endregion
        #region Model Creation
        Model GetModel()
         => new Model
         {
             Units = _projectUnits,
             Elements = _elements,
             LoadCases = _loadCases,
             LoadCombinations = _loadCombinations
         };

        #endregion
        public override object VisitIdDefinitionList([NotNull] StaadParserParser.IdDefinitionListContext context)
        {
            var ids = new List<int>();
            foreach (var idDefCtx in context.id_definition())
                ids.AddRange((List<int>)Visit(idDefCtx));
            return ids;
        }



        Point GetPointById(Object id)
       => _points.First(p => p.Id.Equals(id));
        public override object VisitIntigerId([NotNull] StaadParserParser.IntigerIdContext context)
        => new List<int>() { Convert.ToInt32(context.INTIGER().GetText()) };
        public override object VisitRangeOfIds([NotNull] StaadParserParser.RangeOfIdsContext context)
        {
            var ids = new List<int>();
            for (int i = Convert.ToInt32(context.range().INTIGER()[0].GetText()); i <= Convert.ToInt32(context.range().INTIGER()[1].GetText()); i++)
                ids.Add(i);
            return ids;
            // return null;//return base.VisitRangeOfIds(context);
        }
        public override object VisitLoadHeaderData([NotNull] StaadParserParser.LoadHeaderDataContext context)
       => context.GetText();
        public override object VisitIntigerData([NotNull] StaadParserParser.IntigerDataContext context)
        => Convert.ToInt32(context.GetText());
        public override object VisitDoubleData([NotNull] StaadParserParser.DoubleDataContext context)
        => Convert.ToDouble(context.GetText());
        public override object VisitTextData([NotNull] StaadParserParser.TextDataContext context)
       => context.GetText();
    }
}
