using SAMC2;
using SAMC2.ModelConverter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xbim.Common.Step21;
using Xbim.Ifc;
using Xbim.Ifc2x3.GeometricConstraintResource;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MaterialPropertyResource;
using Xbim.Ifc2x3.MaterialResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.ProfilePropertyResource;
using Xbim.Ifc2x3.ProfileResource;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.RepresentationResource;
using Xbim.Ifc2x3.StructuralAnalysisDomain;
using Xbim.Ifc2x3.StructuralLoadResource;
using Xbim.Ifc2x3.TopologyResource;
using Xbim.Ifc2x3.UtilityResource;
using Xbim.IO.Step21;

namespace IFCModelConverter.Ifc_2x3_modified.IFCWriter
{


    public class IfcWriter : DocumentWriter
    {
        IfcStore _ifcModel;
        IfcAxis2Placement3D _ifcProjLocalCoordinatesSys;  //#54
        IfcGeometricRepresentationContext _ifcGeoContext;  //#55
        Dictionary<string, IfcBoundaryNodeCondition> _ifcBoundaryConditions = new Dictionary<string, IfcBoundaryNodeCondition>();
        Dictionary<int, IfcVertexPoint> _ifcVertices = new Dictionary<int, IfcVertexPoint>();
        Dictionary<int, IfcStructuralPointConnection> _ifcPoints = new Dictionary<int, IfcStructuralPointConnection>();
        Dictionary<int, IfcStructuralCurveMember> _ifcMembers = new Dictionary<int, IfcStructuralCurveMember>();
        Dictionary<int, IfcStructuralSurfaceMember> _ifcSurfaces = new Dictionary<int, IfcStructuralSurfaceMember>();
        Dictionary<int, IfcEdgeCurve> _ifcCurves = new Dictionary<int, IfcEdgeCurve>();
        Dictionary<string, IfcStructuralProfileProperties> _ifcSections = new Dictionary<string, IfcStructuralProfileProperties>();
        Dictionary<string, IfcMaterial> _ifcMaterials = new Dictionary<string, IfcMaterial>();
        Dictionary<int, IfcStructuralLoadGroup> _ifcLoadCases = new Dictionary<int, IfcStructuralLoadGroup>();
        Dictionary<int, IfcStructuralLoadGroup> _ifcLoadCombos = new Dictionary<int, IfcStructuralLoadGroup>();

        public IfcWriter(IDocumentSectionsWritersProvider secsWritesProvider) : base(secsWritesProvider)
        {
        }
        public override string WriteContent(Model model)
        {
            using (_ifcModel = CreateandInitModel())
            {

            
                Model = model;

                // CreateBuilding();
                WriteUnits();
                WriteProjectLocalCoordinateSys();
                WriteFrameSections();
                WriteMaterials();
                WritePoints();
                WriteMembers();
                WriteSurfaces();
                WriteLoadCases();
                WriteLoadCombinations();
                WriteStrAnalysisModel();
                //WriteLines();
                using (var stream = new MemoryStream())
                {

                    TextWriter tw = new StreamWriter(stream);
                    Part21Writer.Write(_ifcModel, tw, _ifcModel.Metadata);
                    tw.Flush();

                  


                    stream.Position = 0;
                    using (var streamReader = new StreamReader(stream))
                    {

                        var ifc =  streamReader.ReadToEnd();
                        return ifc;
                    }
                }
                //  _ifcModel.SaveAs(@"C:\Users\Usama\Desktop\testIfcWriter\vs.ifc");
            }
            //return null;
        }

        private void WriteUnits()
        {
            using (var txn = _ifcModel.BeginTransaction("Writing Units"))
            {
                var forceUnit = WriteForceUnit();
                var lengthUnit = WriteLengthUnit();
                var temprUnit = WriteTemperatureUnit();

                var unitsAssignment = _ifcModel.Instances.New<IfcUnitAssignment>(ua =>
                {

                    ua.Units.Add(forceUnit);
                    ua.Units.Add(lengthUnit);
                    ua.Units.Add(temprUnit);

                });

                _ifcModel.Instances.OfType<IfcProject>().First().UnitsInContext = unitsAssignment;
                txn.Commit();
            }

        }
        private IfcNamedUnit WriteForceUnit()
        {
            IfcNamedUnit ifcUnit;
            if (Model.Units.ForceUnit == ForceUnit.N || Model.Units.ForceUnit == ForceUnit.KN)
            {
                switch (Model.Units.ForceUnit)
                {
                    case ForceUnit.KN:
                        ifcUnit = _ifcModel.Instances.New<IfcSIUnit>(u =>
                        {
                            u.UnitType = IfcUnitEnum.FORCEUNIT;
                            u.Name = IfcSIUnitName.NEWTON;
                            u.Prefix = IfcSIPrefix.KILO;
                        });
                        break;
                    case ForceUnit.N:
                        ifcUnit = _ifcModel.Instances.New<IfcSIUnit>(u =>
                        {
                            u.UnitType = IfcUnitEnum.FORCEUNIT;
                            u.Name = IfcSIUnitName.NEWTON;
                        });
                        break;
                    default:
                        throw new Exception();
                }
            }
            else
            {
                var ifcNUnit = _ifcModel.Instances.New<IfcSIUnit>(u =>
               {
                   u.UnitType = IfcUnitEnum.FORCEUNIT;
                   u.Name = IfcSIUnitName.NEWTON;
               });
                var dimExponent = _ifcModel.Instances.New<IfcDimensionalExponents>(d =>
                {
                    d.LengthExponent = 1;
                    d.MassExponent = 1;
                    d.TimeExponent = -2;
                });
                var conversionRate = _ifcModel.Instances.New<IfcMeasureWithUnit>(m =>
                {
                    m.ValueComponent = new IfcForceMeasure(
                        Model.Units.ForceUnit == ForceUnit.Lb ? 4.4482220E+000
                        : Model.Units.ForceUnit == ForceUnit.Kip ? 4.4482220E+003
                        : Model.Units.ForceUnit == ForceUnit.Kgf ? 9.8066502E+000
                        : Model.Units.ForceUnit == ForceUnit.Tonf ? 9.8066502E+003
                          : throw new Exception());
                    m.UnitComponent = ifcNUnit;
                });
                ifcUnit = _ifcModel.Instances.New<IfcConversionBasedUnit>(u =>
                {
                    u.Dimensions = dimExponent;
                    u.UnitType = IfcUnitEnum.FORCEUNIT;
                    u.ConversionFactor = conversionRate;
                    u.Name = Model.Units.ForceUnit == ForceUnit.Lb ? "LBF"
                    : Model.Units.ForceUnit == ForceUnit.Kip ? "KIP"
                    : Model.Units.ForceUnit == ForceUnit.Kgf ? "KILOGRAM FORCE"
                    : Model.Units.ForceUnit == ForceUnit.Tonf ? "TON FORCE"
                    : throw new Exception();

                    ;
                });
            }

            return ifcUnit;
        }
        private IfcNamedUnit WriteLengthUnit()
        {
            IfcNamedUnit ifcUnit;

            if (Model.Units.LengthUnit == LengthUnit.M || Model.Units.LengthUnit == LengthUnit.Cm || Model.Units.LengthUnit == LengthUnit.Mm)
            {
                switch (Model.Units.LengthUnit)
                {
                    case LengthUnit.Mm:
                        ifcUnit = _ifcModel.Instances.New<IfcSIUnit>(u =>
                        {
                            u.UnitType = IfcUnitEnum.LENGTHUNIT;

                            u.Name = IfcSIUnitName.METRE;
                            u.Prefix = IfcSIPrefix.MILLI;
                        });
                        break;
                    case LengthUnit.Cm:
                        ifcUnit = _ifcModel.Instances.New<IfcSIUnit>(u =>
                        {
                            u.UnitType = IfcUnitEnum.LENGTHUNIT;

                            u.Name = IfcSIUnitName.METRE;
                            u.Prefix = IfcSIPrefix.CENTI;
                        });
                        break;
                    case LengthUnit.M:
                        ifcUnit = _ifcModel.Instances.New<IfcSIUnit>(u =>
                        {
                            u.UnitType = IfcUnitEnum.LENGTHUNIT;

                            u.Name = IfcSIUnitName.METRE;
                        });
                        break;
                    default:
                        throw new Exception();
                }
            }
            else
            {
                var ifcMmUnit = _ifcModel.Instances.New<IfcSIUnit>(u =>
               {
                   u.UnitType = IfcUnitEnum.LENGTHUNIT;
                   u.Name = IfcSIUnitName.METRE;
                   u.Prefix = IfcSIPrefix.MILLI;
               });
                var dimExponent = _ifcModel.Instances.New<IfcDimensionalExponents>(d =>
                {
                    d.LengthExponent = 1;
                });
                var conversionRate = _ifcModel.Instances.New<IfcMeasureWithUnit>(m =>
                {
                    m.ValueComponent = new IfcLengthMeasure(
                        Model.Units.LengthUnit == LengthUnit.Ft ? 3.0480000E+002
                        : Model.Units.LengthUnit == LengthUnit.In ? 2.5400000E+001
                        : throw new Exception());
                    m.UnitComponent = ifcMmUnit;
                });
                ifcUnit = _ifcModel.Instances.New<IfcConversionBasedUnit>(u =>
                {
                    u.Dimensions = dimExponent;
                    u.UnitType = IfcUnitEnum.LENGTHUNIT;
                    u.ConversionFactor = conversionRate;
                    u.Name =
                    Model.Units.LengthUnit == LengthUnit.Ft ? "FOOT"
                    : Model.Units.LengthUnit == LengthUnit.In ? "INCH"
                    : throw new Exception();
                });
            }

            return ifcUnit;
        }
        private IfcNamedUnit WriteTemperatureUnit()
        {
            IfcNamedUnit ifcUnit;

            switch (Model.Units.TemperatureUnit)
            {
                case TemperatureUnit.C:
                    ifcUnit = _ifcModel.Instances.New<IfcSIUnit>(u =>
                    {
                        u.UnitType = IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT;

                        u.Name = IfcSIUnitName.DEGREE_CELSIUS;
                    });
                    break;
                case TemperatureUnit.F:
                    var ifcKelvinUnit = _ifcModel.Instances.New<IfcSIUnit>(u =>
                    {
                        u.UnitType = IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT;
                        u.Name = IfcSIUnitName.KELVIN;
                    });
                    var conversionToFer = _ifcModel.Instances.New<IfcMeasureWithUnit>(m =>
                    {
                        m.ValueComponent = new IfcThermodynamicTemperatureMeasure(5.5555556E-001);
                        m.UnitComponent = ifcKelvinUnit;
                    });
                    var dimExponent = _ifcModel.Instances.New<IfcDimensionalExponents>(d =>
                    {
                        d.ThermodynamicTemperatureExponent = 1;
                    });
                    ifcUnit = _ifcModel.Instances.New<IfcConversionBasedUnit>(u =>
                    {
                        u.Dimensions = dimExponent;
                        u.UnitType = IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT;
                        u.Name = "FAHRENHEIT";
                        u.ConversionFactor = conversionToFer;
                    });
                    break;
                default:
                    throw new Exception("Un handeled Temperature Unit");
            }
            return ifcUnit;
        }
        private void WriteProjectLocalCoordinateSys()
        {
            using (var txn = _ifcModel.BeginTransaction("Project Local Coord Sys"))
            {


                var proj = _ifcModel.Instances.OfType<IfcProject>().First();
                var originPoint = _ifcModel.Instances.New<IfcCartesianPoint>(p => p.SetXYZ(0, 0, 0));
                var zDirection = _ifcModel.Instances.New<IfcDirection>(p => p.SetXYZ(0, 0, 1));
                var xDirection = _ifcModel.Instances.New<IfcDirection>(p => p.SetXYZ(1, 0, 0));
                var axisPlacement3D = _ifcModel.Instances.New<IfcAxis2Placement3D>();
                axisPlacement3D.Location = originPoint;
                axisPlacement3D.Axis = zDirection;
                axisPlacement3D.RefDirection = xDirection;
                //assign project coordinates to global var 
                _ifcProjLocalCoordinatesSys = axisPlacement3D;
                var geomRepCtx = _ifcModel.Instances.New<IfcGeometricRepresentationContext>();
                geomRepCtx.CoordinateSpaceDimension = 3;
                geomRepCtx.WorldCoordinateSystem = axisPlacement3D;
                _ifcGeoContext = geomRepCtx;
                proj.RepresentationContexts.Add(geomRepCtx);

                txn.Commit();
                _ifcProjLocalCoordinatesSys = axisPlacement3D;
            }
        }
        private void WriteFrameSections()
        {

            using (var txn = _ifcModel.BeginTransaction("Create Frame Section"))
            {
                foreach (var framSection in Model.FrameSections)
                {
                    //var cartesianPoint = model.Instances.New<IfcCartesianPoint>();
                    //cartesianPoint.SetXY(0, 0);
                    //var direction = model.Instances.New<IfcDirection>();
                    //direction.SetXY(1, 0);
                    //var axis = model.Instances.New<IfcAxis2Placement2D>();
                    //axis.Location = cartesianPoint;
                    //axis.RefDirection = direction;
                    if (framSection.Profile is RecangularProfile)
                    {
                        var rectangelProfile = _ifcModel.Instances.New<IfcRectangleProfileDef>();
                        rectangelProfile.ProfileType = IfcProfileTypeEnum.AREA;
                        rectangelProfile.ProfileName = framSection.Profile.SectionProfileName;
                        rectangelProfile.XDim = (framSection.Profile as RecangularProfile).Depth;
                        rectangelProfile.YDim = (framSection.Profile as RecangularProfile).Width;
                        var placement = _ifcModel.Instances.New<IfcAxis2Placement2D>();
                        rectangelProfile.Position = placement;
                        var cartesianPoint = _ifcModel.Instances.New<IfcCartesianPoint>();
                        placement.Location = cartesianPoint;
                        cartesianPoint.SetXY(0, 0);
                        var direction = _ifcModel.Instances.New<IfcDirection>();
                        placement.RefDirection = direction;
                        direction.SetXY(1, 0);
                        var profileProperts = _ifcModel.Instances.New<IfcStructuralProfileProperties>(s => s.ProfileDefinition = rectangelProfile);
                        _ifcSections.Add(framSection.Profile.SectionProfileName, profileProperts);
                    }
                    else if (framSection.Profile is IShapeProfile)
                    {
                        var iShapeProfile = _ifcModel.Instances.New<IfcIShapeProfileDef>();
                        iShapeProfile.ProfileType = IfcProfileTypeEnum.AREA;
                        iShapeProfile.ProfileName = framSection.Profile.SectionProfileName;
                        var placement = _ifcModel.Instances.New<IfcAxis2Placement2D>(); ;
                        iShapeProfile.Position = placement;
                        var cartesianPoint = _ifcModel.Instances.New<IfcCartesianPoint>();
                        placement.Location = cartesianPoint;
                        cartesianPoint.SetXY(0, 0);
                        var direction = _ifcModel.Instances.New<IfcDirection>();
                        placement.RefDirection = direction;
                        direction.SetXY(1, 0);
                        iShapeProfile.OverallWidth = (framSection.Profile as IShapeProfile).TopFlangeWidth;
                        iShapeProfile.OverallDepth = (framSection.Profile as IShapeProfile).OverallHeight;
                        iShapeProfile.WebThickness = (framSection.Profile as IShapeProfile).WebThickness;
                        iShapeProfile.FlangeThickness = (framSection.Profile as IShapeProfile).TopFlangeThickness;
                        iShapeProfile.FilletRadius = (framSection.Profile as IShapeProfile).TopFlangeFilletRadius;
                        var profileProperts = _ifcModel.Instances.New<IfcStructuralProfileProperties>(s => s.ProfileDefinition = iShapeProfile);
                        _ifcSections.Add(framSection.Profile.SectionProfileName, profileProperts);
                    }
                    else
                        throw new Exception("Not Frame Section");
                }
                txn.Commit();
            }
        }
        private void WriteMaterials()
        {
            using (var txn = _ifcModel.BeginTransaction("Create Materials"))
            {
                foreach (var material in Model.Materials)
                {

                    var ifcMaterial = _ifcModel.Instances.New<IfcMaterial>(m =>
                    {
                        
                        m.Name = material.Name;
                        switch (material.Type)
                        {
                            case MaterialType.Concrete:
                                
                             //   m.Category = "Concrete";
                                break;
                            case MaterialType.Steel:
                            //    m.Category = "Steel";
                                break;
                            default:
                                break;
                        }
                    });
                    _ifcMaterials.Add(material.Name, ifcMaterial);
                    var matMechanicalProps = _ifcModel.Instances.New<IfcMechanicalMaterialProperties>(mp =>
                    {
                        mp.Material = ifcMaterial;
                        mp.PoissonRatio = material.PoissonRatio;
                        mp.ShearModulus = material.ShearModulus;
                        mp.ThermalExpansionCoefficient = material.ThermalExpanssionC;
                        mp.YoungModulus = material.YoungModulus;

                    });
                    var matGeneralProps = _ifcModel.Instances.New<IfcGeneralMaterialProperties>(mp =>
                    {
                        mp.Material = ifcMaterial;
                        mp.MassDensity = material.MassDensityFor(Model.Units.LengthUnit);


                    });


                }
                txn.Commit();
            }
        }
        private void WritePoints()
        {
            using (var txn = _ifcModel.BeginTransaction("Create Points"))
            {
                foreach (var point in Model.ElementsPoints)
                {
                    var localPlacement = _ifcModel.Instances.New<IfcLocalPlacement>(l => l.RelativePlacement = _ifcProjLocalCoordinatesSys);
                    var cartesianPoint = _ifcModel.Instances.New<IfcCartesianPoint>(p => p.SetXYZ(point.X, point.Y, point.Z));
                    var vertex = _ifcModel.Instances.New<IfcVertexPoint>(p => p.VertexGeometry = cartesianPoint);
                    _ifcVertices.Add(point.Id, vertex);
                    //  _ifcCartesianPoints.Add(point.Id, cartesianPoint);
                    var topologyRep = _ifcModel.Instances.New<IfcTopologyRepresentation>(t =>
                        { t.ContextOfItems = _ifcGeoContext; t.RepresentationType = "Vertex"; t.Items.Add(vertex); });
                    var prodDefShape = _ifcModel.Instances.New<IfcProductDefinitionShape>(p => p.Representations.Add(topologyRep));
                    var strPointConction = _ifcModel.Instances.New<IfcStructuralPointConnection>();
                    strPointConction.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                    //strPointConction.OwnerHistory = new IfcOwnerHistory(); not created yet #26
                    strPointConction.Name = point.Id.ToString();
                    strPointConction.ObjectPlacement = localPlacement;
                    strPointConction.Representation = prodDefShape;
                    if (point.BoundaryCondition != null)
                    {

                        if (_ifcBoundaryConditions.ContainsKey(point.BoundaryCondition.Id))
                            strPointConction.AppliedCondition = _ifcBoundaryConditions[point.BoundaryCondition.Id];

                        else
                        {
                            var boundary = _ifcModel.Instances.New<IfcBoundaryNodeCondition>(b =>
                            {

                                b.Name = point.BoundaryCondition.Id;
                                b.LinearStiffnessX = new IfcLinearStiffnessMeasure((point.BoundaryCondition.IsFreeTransX) ? 0 : -1);
                                b.LinearStiffnessY = new IfcLinearStiffnessMeasure((point.BoundaryCondition.IsFreeTransY) ? 0 : -1);
                                b.LinearStiffnessZ = new IfcLinearStiffnessMeasure((point.BoundaryCondition.IsFreeTransZ) ? 0 : -1);
                                b.RotationalStiffnessX = new IfcRotationalStiffnessMeasure((point.BoundaryCondition.IsFreeMomentX) ? 0 : -1);
                                b.RotationalStiffnessY = new IfcRotationalStiffnessMeasure((point.BoundaryCondition.IsFreeMomentY) ? 0 : -1);
                                b.RotationalStiffnessZ = new IfcRotationalStiffnessMeasure((point.BoundaryCondition.IsFreeMomentZ) ? 0 : -1);
                            });
                            strPointConction.AppliedCondition = boundary;
                            _ifcBoundaryConditions.Add(boundary.Name, boundary);
                        }
                    }
                    _ifcPoints.Add(point.Id, strPointConction);
                }
                txn.Commit();
            }
        }
        //private void WriteLines()
        //{
        //    using (var txn = _ifcModel.BeginTransaction("Create Lines"))
        //    {
        //        foreach (var fram in Model.FrameElements)
        //        {
        //            // Get Vector and Abs
        //            int xVect, yVect, zVect;
        //            double vectAbs;
        //            GetVector(fram, out xVect, out yVect, out zVect, out vectAbs);
        //            //
        //            var localPlacement = _ifcModel.Instances.New<IfcLocalPlacement>(l => l.RelativePlacement = _ifcProjLocalCoordinatesSys);
        //            var direction = _ifcModel.Instances.New<IfcDirection>(d => d.SetXYZ(xVect, yVect, zVect));
        //            var vector = _ifcModel.Instances.New<IfcVector>(v => { v.Orientation = direction; v.Magnitude = vectAbs; });
        //            var line = _ifcModel.Instances.New<IfcLine>(l =>
        //            {
        //                l.Pnt = _ifcVertices[fram.Vertices[0].Id].VertexGeometry as IfcCartesianPoint;
        //                l.Dir = vector;
        //            });
        //            var edgeCurve = _ifcModel.Instances.New<IfcEdgeCurve>(e =>
        //            {
        //                e.EdgeStart = _ifcVertices[fram.Vertices[0].Id];
        //                e.EdgeEnd = _ifcVertices[fram.Vertices[1].Id];
        //                e.EdgeGeometry = line;
        //                e.SameSense = true;
        //            });
        //            //
        //            _ifcCurves.Add(fram.Id, edgeCurve);
        //            //                    
        //            var topologyRep = _ifcModel.Instances.New<IfcTopologyRepresentation>(t =>
        //            {
        //                t.ContextOfItems = _ifcGeoContext;
        //                t.RepresentationType = "Edge";
        //                t.Items.Add(edgeCurve);
        //            });
        //            var prodDefShape = _ifcModel.Instances.New<IfcProductDefinitionShape>(p => p.Representations.Add(topologyRep));
        //            var strCurveConnection = _ifcModel.Instances.New<IfcStructuralCurveConnection>(s =>
        //            {
        //                s.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
        //                //s.OwnerHistory 
        //                s.Name = fram.Id.ToString();
        //                s.ObjectPlacement = localPlacement;
        //                s.Representation = prodDefShape;
        //            });
        //        }
        //        txn.Commit();
        //    }
        //}
        private void WriteMembers()
        {
            using (var txn = _ifcModel.BeginTransaction("Create Members"))
            {
                foreach (var fram in Model.FrameElements)
                {
                    var vec = new Vector(fram);
                    // Get Vector and Abs
                    //int xVect, yVect, zVect;
                    //double vectAbs;
                    //GetVector(fram, out xVect, out yVect, out zVect, out vectAbs);
                    //
                    var localPlacement = _ifcModel.Instances.New<IfcLocalPlacement>(l => l.RelativePlacement = _ifcProjLocalCoordinatesSys);
                    var direction = _ifcModel.Instances.New<IfcDirection>(d => d.SetXYZ(vec.X, vec.Y, vec.Z));
                    var vector = _ifcModel.Instances.New<IfcVector>(v => { v.Orientation = direction; v.Magnitude = vec.Abs; });
                    var line = _ifcModel.Instances.New<IfcLine>(l =>
                    {
                        l.Pnt = _ifcVertices[fram.Vertices[0].Id].VertexGeometry as IfcCartesianPoint;
                        l.Dir = vector;
                    });
                    var edgeCurve = _ifcModel.Instances.New<IfcEdgeCurve>(e =>
                    {
                        e.EdgeStart = _ifcVertices[fram.Vertices[0].Id];
                        e.EdgeEnd = _ifcVertices[fram.Vertices[1].Id];
                        e.EdgeGeometry = line;
                        e.SameSense = true;
                    });
                    //
                    //_ifcCurves.Add(fram.Id, edgeCurve);
                    //                    
                    var topologyRep = _ifcModel.Instances.New<IfcTopologyRepresentation>(t =>
                    {
                        t.ContextOfItems = _ifcGeoContext;
                        t.RepresentationType = "Edge";
                        t.Items.Add(edgeCurve);
                    });
                    var prodDefShape = _ifcModel.Instances.New<IfcProductDefinitionShape>(p => p.Representations.Add(topologyRep));
                    var strCurveMember = _ifcModel.Instances.New<IfcStructuralCurveMember>(s =>
                    {
                        s.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                        //s.OwnerHistory #26
                        s.Name = fram.Id.ToString();
                        s.ObjectPlacement = localPlacement;
                        s.Representation = prodDefShape;
                        s.PredefinedType = IfcStructuralCurveTypeEnum.RIGID_JOINED_MEMBER;//usama ateya responsibility
                    });
                    _ifcMembers.Add(fram.Id, strCurveMember);
                    if (fram.Section?.Profile != null)
                    {
                        var section = _ifcModel.Instances.New<IfcRelAssociatesProfileProperties>(s =>
                        {
                            s.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                            s.RelatingProfileProperties = _ifcSections[fram.Section.Profile.SectionProfileName];
                            s.RelatedObjects.Add(strCurveMember);
                        });
                    }
                    if (fram.Section?.Material != null)
                    {


                        var material = _ifcModel.Instances.New<IfcRelAssociatesMaterial>(m =>
                        {
                            m.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                            m.RelatingMaterial = _ifcMaterials[fram.Section.Material.Name];
                            m.RelatedObjects.Add(strCurveMember);
                        });
                    }
                    var startConnection = _ifcModel.Instances.New<IfcRelConnectsStructuralMember>(c =>
                    {
                        c.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                        c.Name = "Node beg";
                        c.RelatingStructuralMember = strCurveMember;
                        c.RelatedStructuralConnection = _ifcPoints[fram.Vertices[0].Id];
                    });
                    var endConnection = _ifcModel.Instances.New<IfcRelConnectsStructuralMember>(e =>
                    {
                        e.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                        e.Name = "Node end";
                        e.RelatingStructuralMember = strCurveMember;
                        e.RelatedStructuralConnection = _ifcPoints[fram.Vertices[1].Id];
                    });
                }
                txn.Commit();
            }
        }
        private void WriteSurfaces()
        {
            using (var txn = _ifcModel.BeginTransaction("Writing Area Elements"))
            {


                foreach (var areaElmnt in Model.AreaElements)
                {
                    var areaElmntEdgeLoop = _ifcModel.Instances.New<IfcEdgeLoop>();
                    for (int i = 0; i < areaElmnt.Vertices.Count; i++)
                    {
                        var edgeStartPoit = areaElmnt.Vertices[i];
                        var edgeEndPoint = areaElmnt.Vertices[(i + 1) != areaElmnt.Vertices.Count ? i + 1 : 0];
                        var ifcEdge = _ifcModel.Instances.New<IfcEdge>();
                        ifcEdge.EdgeStart = _ifcVertices[edgeStartPoit.Id];
                        ifcEdge.EdgeEnd = _ifcVertices[edgeEndPoint.Id];

                        var ifcOrientedEdge = _ifcModel.Instances.New<IfcOrientedEdge>();
                        ifcOrientedEdge.EdgeElement = ifcEdge;
                        ifcOrientedEdge.Orientation = true;

                        areaElmntEdgeLoop.EdgeList.Add(ifcOrientedEdge);
                    }
                    var zDirection = _ifcModel.Instances.New<IfcDirection>(p => p.SetXYZ(0, 0, 1));
                    var xDirection = _ifcModel.Instances.New<IfcDirection>(p => p.SetXYZ(1, 0, 0));

                    var ifcPlacement = _ifcModel.Instances.New<IfcAxis2Placement3D>();

                    ifcPlacement.Location = _ifcVertices[areaElmnt.Vertices.First().Id].VertexGeometry as IfcCartesianPoint;//_ifcCartesianPoints[areaElmnt.Vertices.First().Id];
                    ifcPlacement.Axis = zDirection;
                    ifcPlacement.RefDirection = xDirection;

                    var ifcPlane = _ifcModel.Instances.New<IfcPlane>();
                    ifcPlane.Position = ifcPlacement;

                    var faceBound = _ifcModel.Instances.New<IfcFaceBound>();
                    faceBound.Bound = areaElmntEdgeLoop;
                    faceBound.Orientation = true;

                    var surface = _ifcModel.Instances.New<IfcFaceSurface>();
                    surface.Bounds.Add(faceBound);
                    surface.FaceSurface = ifcPlane;
                    surface.SameSense = true;

                    var topologicalRep = _ifcModel.Instances.New<IfcTopologyRepresentation>();
                    topologicalRep.ContextOfItems = _ifcGeoContext;
                    topologicalRep.RepresentationType = "FACE";
                    topologicalRep.Items.Add(surface);

                    var prodDefShape = _ifcModel.Instances.New<IfcProductDefinitionShape>();
                    prodDefShape.Representations.Add(topologicalRep);

                    var structSurfMember = _ifcModel.Instances.New<IfcStructuralSurfaceMember>();
                    var localPlacement = _ifcModel.Instances.New<IfcLocalPlacement>();
                    localPlacement.RelativePlacement = _ifcProjLocalCoordinatesSys;
                    structSurfMember.GlobalId = GetNewIfcGuid();
                    structSurfMember.Name = areaElmnt.Section.Profile.SectionProfileName;
                    structSurfMember.ObjectPlacement = localPlacement;
                    structSurfMember.Representation = prodDefShape;
                    structSurfMember.PredefinedType = IfcStructuralSurfaceTypeEnum.SHELL;
                    structSurfMember.Thickness = ((AreaSectionProfile)areaElmnt.Section.Profile).Thickness;

                    _ifcSurfaces.Add(areaElmnt.Id, structSurfMember);

                    if (areaElmnt.Section.Material != null)
                    {
                        var material = _ifcModel.Instances.New<IfcRelAssociatesMaterial>(m =>
                        {
                            m.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                            m.RelatingMaterial = _ifcMaterials[areaElmnt.Section.Material.Name];
                            m.RelatedObjects.Add(structSurfMember);
                        });
                    }
                    foreach (var point in areaElmnt.Vertices)
                    {
                        var relConnectStrucElmnt = _ifcModel.Instances.New<IfcRelConnectsStructuralMember>();
                        relConnectStrucElmnt.RelatingStructuralMember = structSurfMember;
                        relConnectStrucElmnt.RelatedStructuralConnection = _ifcPoints[point.Id];
                    }
                }
                txn.Commit();
            }
        }
        private void WriteLoadCases()
        {
            using (var txn = _ifcModel.BeginTransaction("Create Load Case"))
            {
                foreach (var lodCas in Model.LoadCases)
                {
                    var strLoadGroup = _ifcModel.Instances.New<IfcStructuralLoadGroup>(l =>
                    {
                        l.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                        l.Name = lodCas.Name;
                        l.PredefinedType = IfcLoadGroupTypeEnum.LOAD_CASE;
                        l.ActionType = IfcActionTypeEnum.NOTDEFINED;
                        //handles dead or live only
                        l.ActionSource = lodCas.LoadCaseType.Equals(LoadCaseType.Dead) ? IfcActionSourceTypeEnum.DEAD_LOAD_G : lodCas.LoadCaseType.Equals(LoadCaseType.Live) ? IfcActionSourceTypeEnum.LIVE_LOAD_Q : IfcActionSourceTypeEnum.NOTDEFINED;
                        l.Coefficient = lodCas.ScaleFactorCoefficient;
                    });
                    _ifcLoadCases.Add(lodCas.Id, strLoadGroup);
                    var relLoadGroup = _ifcModel.Instances.New<IfcRelAssignsToGroup>(r =>
                    {
                        r.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                        r.RelatingGroup = strLoadGroup;
                    });
                    foreach (var lod in lodCas.Loads)
                    {
                        if (lod.LoadForce is SurfaceLoadForce)
                        {
                            if (_ifcSurfaces.ContainsKey(lod.AppliedOnId))
                            {


                                var surfLoadForce = lod.LoadForce as SurfaceLoadForce;
                                var strPlanarForce = _ifcModel.Instances.New<IfcStructuralLoadPlanarForce>(pf =>
                                {
                                    pf.PlanarForceX = surfLoadForce.ForceX;
                                    pf.PlanarForceY = surfLoadForce.ForceY;
                                    pf.PlanarForceZ = surfLoadForce.ForceZ;
                                });
                                var strPlanarAction = _ifcModel.Instances.New<IfcStructuralPlanarAction>(pa =>
                                {
                                    pa.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                                    pa.AppliedLoad = strPlanarForce;
                                    pa.GlobalOrLocal = surfLoadForce.Coordinates.Equals(LoadForceCoordinates.Local) ? IfcGlobalOrLocalEnum.LOCAL_COORDS : IfcGlobalOrLocalEnum.GLOBAL_COORDS;
                                    pa.DestabilizingLoad = false; //not implemented just static value
                                    pa.ProjectedOrTrue = surfLoadForce.Coordinates.Equals(LoadForceCoordinates.Global_Projected_Length) ? IfcProjectedOrTrueLengthEnum.PROJECTED_LENGTH : IfcProjectedOrTrueLengthEnum.TRUE_LENGTH;
                                });
                                var relActivity = _ifcModel.Instances.New<IfcRelConnectsStructuralActivity>(a =>
                                {
                                    a.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                                    a.RelatingElement = _ifcSurfaces[lod.AppliedOnId];
                                    a.RelatedStructuralActivity = strPlanarAction;
                                });
                                relLoadGroup.RelatedObjects.Add(strPlanarAction);
                            }
                        }
                        else if (lod.LoadForce is LinearLoadForce)
                        {
                            if (_ifcMembers.ContainsKey(lod.AppliedOnId))
                            {


                                var linLoadForce = lod.LoadForce as LinearLoadForce;
                                var strLinearForce = _ifcModel.Instances.New<IfcStructuralLoadLinearForce>(lf =>
                                {
                                    lf.LinearForceX = linLoadForce.ForceX;
                                    lf.LinearForceY = linLoadForce.ForceY;
                                    lf.LinearForceZ = linLoadForce.ForceZ;
                                    lf.LinearMomentX = linLoadForce.MomentX;
                                    lf.LinearMomentY = linLoadForce.MomentY;
                                    lf.LinearMomentZ = linLoadForce.MomentZ;
                                });
                                var strLinearAction = _ifcModel.Instances.New<IfcStructuralLinearAction>(la =>
                                {
                                    la.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                                    la.AppliedLoad = strLinearForce;
                                    la.ObjectPlacement = _ifcMembers[lod.AppliedOnId].ObjectPlacement;
                                    la.Representation = _ifcMembers[lod.AppliedOnId].Representation;
                                    la.GlobalOrLocal = linLoadForce.Coordinates.Equals(LoadForceCoordinates.Local) ? IfcGlobalOrLocalEnum.LOCAL_COORDS : IfcGlobalOrLocalEnum.GLOBAL_COORDS;
                                    la.DestabilizingLoad = false; //static value
                                    la.ProjectedOrTrue = linLoadForce.Coordinates.Equals(LoadForceCoordinates.Global_Projected_Length) ? IfcProjectedOrTrueLengthEnum.PROJECTED_LENGTH : IfcProjectedOrTrueLengthEnum.TRUE_LENGTH;
                                });
                                var relActivity = _ifcModel.Instances.New<IfcRelConnectsStructuralActivity>(a =>
                                {
                                    a.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                                    a.RelatingElement = _ifcMembers[lod.AppliedOnId];
                                    a.RelatedStructuralActivity = strLinearAction;
                                });
                                relLoadGroup.RelatedObjects.Add(strLinearAction);
                            }
                        }
                        else if (lod.LoadForce is PointLoadForce)
                        {
                            if (_ifcPoints.ContainsKey(lod.AppliedOnId))
                            {


                                var pointLoadForce = lod.LoadForce as PointLoadForce;
                                var strPointForce = _ifcModel.Instances.New<IfcStructuralLoadSingleForce>(f =>
                                {
                                    f.ForceX = pointLoadForce.ForceX;
                                    f.ForceY = pointLoadForce.ForceY;
                                    f.ForceZ = pointLoadForce.ForceZ;
                                    f.MomentX = pointLoadForce.MomentX;
                                    f.MomentY = pointLoadForce.MomentY;
                                    f.MomentZ = pointLoadForce.MomentZ;
                                });
                                var strPointAction = _ifcModel.Instances.New<IfcStructuralPointAction>(a =>
                                {
                                    a.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                                    a.AppliedLoad = strPointForce;
                                    a.ObjectPlacement = _ifcPoints[lod.AppliedOnId].ObjectPlacement;
                                    a.Representation = _ifcPoints[lod.AppliedOnId].Representation;
                                    a.GlobalOrLocal = IfcGlobalOrLocalEnum.GLOBAL_COORDS;
                                    a.DestabilizingLoad = false;//                                
                            });
                                var relActivity = _ifcModel.Instances.New<IfcRelConnectsStructuralActivity>(a =>
                                {
                                    a.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                                    a.RelatingElement = _ifcPoints[lod.AppliedOnId];
                                    a.RelatedStructuralActivity = strPointAction;
                                });
                                relLoadGroup.RelatedObjects.Add(strPointAction);
                            }
                        }
                        else
                            throw new Exception("NO Loads");
                    }
                }
                txn.Commit();
            }
        }
        private void WriteLoadCombinations()
        {
            using (var txn = _ifcModel.BeginTransaction("Create Load Combinations"))
            {
                foreach (var lodComb in Model.LoadCombinations)
                {
                    var comboStrLoadGroup = _ifcModel.Instances.New<IfcStructuralLoadGroup>(cs =>
                    {
                        cs.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                        //   cs.Name = lodComb.Id.ToString();
                        cs.Name = lodComb.Name;
                        cs.PredefinedType = IfcLoadGroupTypeEnum.LOAD_COMBINATION;
                        cs.ActionType = IfcActionTypeEnum.NOTDEFINED;
                        cs.ActionSource = IfcActionSourceTypeEnum.NOTDEFINED;
                        cs.Coefficient = 1;
                    });
                    _ifcLoadCombos.Add(lodComb.Id , comboStrLoadGroup);
                    var comboRelAssignToGroup = _ifcModel.Instances.New<IfcRelAssignsToGroup>(cr =>
                    {
                        cr.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                        cr.RelatingGroup = comboStrLoadGroup;
                    });
                    foreach (var combItem in lodComb.LoadCombinationItems)
                    {
                        var itemStrLoadGroup = _ifcModel.Instances.New<IfcStructuralLoadGroup>(i =>
                        {
                            i.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                            i.PredefinedType = IfcLoadGroupTypeEnum.LOAD_COMBINATION_GROUP;
                            i.ActionType = IfcActionTypeEnum.NOTDEFINED;
                            i.ActionSource = IfcActionSourceTypeEnum.NOTDEFINED;
                            i.Coefficient = combItem.Factor;
                        });
                        var itemRelAssignToGroup = _ifcModel.Instances.New<IfcRelAssignsToGroup>(ir =>
                        {
                            ir.GlobalId = new IfcGloballyUniqueId(GetNewIfcGuid());
                            ir.RelatedObjects.Add(_ifcLoadCases[combItem.LoadCaseId]);
                            ir.RelatingGroup = itemStrLoadGroup;
                        });
                        comboRelAssignToGroup.RelatedObjects.Add(itemStrLoadGroup);
                    }
                }
                txn.Commit();
            }
        }

        private void WriteStrAnalysisModel()
        {
            using (var txn = _ifcModel.BeginTransaction("Write Str Analysis Model"))
            {
                var strAnalysisModel = _ifcModel.Instances.New<IfcStructuralAnalysisModel>(m =>
               {
                   m.GlobalId = GetNewIfcGuid();
                   m.Name = "Structural Model";
                   m.PredefinedType = IfcAnalysisModelTypeEnum.LOADING_3D;
                   m.OrientationOf2DPlane = _ifcProjLocalCoordinatesSys;
                   m.LoadedBy.AddRange(_ifcLoadCases.Values);
                   m.LoadedBy.AddRange(_ifcLoadCombos.Values);

               });

                var relAssignToGroup = _ifcModel.Instances.New<IfcRelAssignsToGroup>(a =>
                    {
                        a.GlobalId = GetNewIfcGuid();
                        a.RelatedObjects.AddRange(_ifcPoints.Values);
                        a.RelatedObjects.AddRange(_ifcMembers.Values);
                        a.RelatedObjects.AddRange(_ifcSurfaces.Values);
                        a.RelatedObjectsType = IfcObjectTypeEnum.PRODUCT;
                        a.RelatingGroup = strAnalysisModel;
                    }
                    );
                var relServiceBuilding = _ifcModel.Instances.New<IfcRelServicesBuildings>(sb =>
               {
                   sb.GlobalId = GetNewIfcGuid();
                   sb.RelatingSystem = strAnalysisModel;
                   sb.RelatedBuildings.Add( _ifcModel.Instances.OfType<IfcBuilding>().First());
               });
                txn.Commit();
            }
        }
        string GetNewIfcGuid()
        => IfcGuid.ToIfcGuid(Guid.NewGuid());


        //void GetVector(Element fram,out int x,out int y, out int z,out double abs )
        //{

        //    x= (fram.Vertices[1].X > fram.Vertices[0].X) ? 1 : (fram.Vertices[1].X < fram.Vertices[0].X) ? -1 : 0;
        //    y= (fram.Vertices[1].Y > fram.Vertices[0].Y) ? 1 : (fram.Vertices[1].Y < fram.Vertices[0].Y) ? -1 : 0;
        //    z= (fram.Vertices[1].Z > fram.Vertices[0].Z) ? 1 : (fram.Vertices[1].Z < fram.Vertices[0].Z) ? -1 : 0;
        //    abs = Math.Sqrt((Math.Pow((fram.Vertices[1].X - fram.Vertices[0].X),2)) + (Math.Pow((fram.Vertices[1].Y - fram.Vertices[0].Y), 2)) + (Math.Pow((fram.Vertices[1].Z - fram.Vertices[0].Z), 2)));
        //}

        //}
        /// <summary>
        /// Sets up the basic parameters any model must provide, units, ownership etc
        /// </summary>
        /// <param name="projectName">Name of the project</param>
        /// <returns></returns>
        private IfcStore CreateandInitModel()
        {
            //first we need to set up some credentials for ownership of data in the new model
            var credentials = new XbimEditorCredentials
            {
               // ApplicationDevelopersName = "Usama.Atteya",
                ApplicationFullName = "SAMC",
                ApplicationIdentifier = "SAMC",
                ApplicationVersion = "1.0",
               // EditorsFamilyName = "Team",
               // EditorsGivenName = "usama.atteya@gmail.com",
              //  EditorsOrganisationName = "E++"
            };
            var model = IfcStore.Create(credentials, IfcSchemaVersion.Ifc2X3, XbimStoreType.InMemoryModel);

            //Begin a transaction as all changes to a model are ACID
            using (var txn = model.BeginTransaction("Initialise Model"))
            {

                #region Create a project
                var project = model.Instances.New<IfcProject>();
                //set the units to SI (mm and metres)
                //    project.Initialize(Xbim.Common.ProjectUnits.SIUnitsUK);
                project.Name = "Model";
                project.LongName = "Model";
                #endregion
                //now commit the changes, else they will be rolled back at the end of the scope of the using statement
                #region Create Site
                var site = model.Instances.New<IfcSite>();
                site.Name = "Site";
                site.CompositionType = IfcElementCompositionEnum.ELEMENT;
                project.AddSite(site);
                #endregion

                #region Create Building
                var building = model.Instances.New<IfcBuilding>();
                building.Name = "Building";

                building.CompositionType = IfcElementCompositionEnum.ELEMENT;
                site.AddBuilding(building);
                #endregion

                #region Building Storey
                var buildingStorey = model.Instances.New<IfcBuildingStorey>();
                buildingStorey.Name = "Building Storey";
                buildingStorey.CompositionType = IfcElementCompositionEnum.ELEMENT;
                var aggregates = model.Instances.New<IfcRelAggregates>();
                aggregates.RelatingObject = building;
                aggregates.RelatedObjects.Add(buildingStorey);
                #endregion


                txn.Commit();
            }
            return model;

        }
        //Int64 GetPointsGroupId(Point p1, Point p2)
        //    => (p1.Id << 32) + p2.Id;



    }
}
