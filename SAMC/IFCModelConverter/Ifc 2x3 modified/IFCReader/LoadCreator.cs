using SAMC2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;

namespace IFCModelConverter.Ifc_2x3_modified.IFCReader
{
    static class LoadCreator
    {
        public static IEnumerable<LoadCase> GetLoadCases(IfcStore ifcModel)
        {
            var ifcLoadCases = ifcModel.Instances.OfType<IIfcStructuralLoadGroup>().Where(r => r.PredefinedType == IfcLoadGroupTypeEnum.LOAD_CASE);
            return GetLoadCases(ifcLoadCases);
        }
        static IEnumerable<LoadCase> GetLoadCases(IEnumerable<IIfcStructuralLoadGroup> ifcLoadCases)
        {
            foreach (var ifcLoadCase in ifcLoadCases)
                yield return GetLoadCase(ifcLoadCase);
        }
        static LoadCase GetLoadCase(IIfcStructuralLoadGroup ifcLoadCase)
        => new LoadCase()
        {
            Id = ifcLoadCase.EntityLabel,
            Name = ifcLoadCase.Name.Value,
            ScaleFactorCoefficient = Convert.ToDouble(ifcLoadCase.Coefficient?.Value ?? 0),
            LoadCaseType = GetLoadCaseType(ifcLoadCase),

            Loads = GetLoads(ifcLoadCase).ToList()
        };

        static LoadCaseType GetLoadCaseType(IIfcStructuralLoadGroup ifcLoadCase)
        {
            switch (ifcLoadCase.ActionSource)
            {
                case IfcActionSourceTypeEnum.DEAD_LOAD_G:
                    return LoadCaseType.Dead;
                case IfcActionSourceTypeEnum.LIVE_LOAD_Q:
                    return LoadCaseType.Live;
                case IfcActionSourceTypeEnum.WIND_W:
                    return LoadCaseType.Wind;
                default:
                    return LoadCaseType.Other;
            }
        }


        static IEnumerable<Load> GetLoads(IIfcStructuralLoadGroup ifcLoadGroup)
        {
            var ifcRelAssignToGroup = ifcLoadGroup.IsGroupedBy.FirstOrDefault();
            if (ifcRelAssignToGroup == null)
                return new List<Load>();
            var innerloadsGroup = ifcRelAssignToGroup.RelatedObjects.OfType<IIfcStructuralLoadGroup>().FirstOrDefault();
            if (innerloadsGroup != null && innerloadsGroup.IsGroupedBy.Any())
                return GetLoads(innerloadsGroup);
            return GetLoads(ifcRelAssignToGroup.RelatedObjects.OfType<IIfcStructuralAction>());
        }
        static IEnumerable<Load> GetLoads(IEnumerable<IIfcStructuralAction> ifcLooadActions)
        {
            foreach (var ifcLoadAction in ifcLooadActions)
                yield return GetLoad(ifcLoadAction);
        }
        static Load GetLoad(IIfcStructuralAction ifcLoadAction)
        {
            var assignedTo = ifcLoadAction.AssignedToStructuralItem.First().RelatingElement.EntityLabel;
            return new Load()
            {
                //LoadCoordinates = ifcLoadAction.GlobalOrLocal == IfcGlobalOrLocalEnum.GLOBAL_COORDS? LoadCoordinates.Global : LoadCoordinates.Local
                AppliedOnId = assignedTo,
                LoadForce = GetLoadForce(ifcLoadAction)
            };
        }

        static LoadForce GetLoadForce(IIfcStructuralAction ifcStrAction)
        {
            if (ifcStrAction is IIfcStructuralPointAction)
                return GetLoadForce((IIfcStructuralPointAction)ifcStrAction);
            else if (ifcStrAction is IIfcStructuralLinearAction)
                return GetLoadForce((IIfcStructuralLinearAction)ifcStrAction);
            else if (ifcStrAction is IIfcStructuralPlanarAction)
                return GetLoadForce((IIfcStructuralPlanarAction)ifcStrAction);
            throw new Exception("Not Known Str Action In GetLoadForce Function");
        }

        static PointLoadForce GetLoadForce(IIfcStructuralPointAction ifcStrucAction)
        {
            var pointLoadForce = ifcStrucAction.AppliedLoad as IIfcStructuralLoadSingleForce;
            return new PointLoadForce()
            {
                ForceX = pointLoadForce.ForceX,
                ForceY = pointLoadForce.ForceY,
                ForceZ = pointLoadForce.ForceZ,
                MomentX = pointLoadForce.MomentX,
                MomentY = pointLoadForce.MomentY,
                MomentZ = pointLoadForce.MomentZ
            };
        }
        static LinearLoadForce GetLoadForce(IIfcStructuralLinearAction ifcStrucAction)
        {
            var linearLoadForce = ifcStrucAction.AppliedLoad as IIfcStructuralLoadLinearForce;
            return new LinearLoadForce()
            {
                Coordinates = GetLoadForceCoordinates(ifcStrucAction),
                ForceX = linearLoadForce.LinearForceX,
                ForceY = linearLoadForce.LinearForceY,
                ForceZ = linearLoadForce.LinearForceZ,
                MomentX = linearLoadForce.LinearMomentX,
                MomentY = linearLoadForce.LinearMomentY,
                MomentZ = linearLoadForce.LinearMomentZ
            };
        }
        static SurfaceLoadForce GetLoadForce(IIfcStructuralPlanarAction ifcStrucAction)
        {
            var surfaceLoadForce = ifcStrucAction.AppliedLoad as IIfcStructuralLoadPlanarForce;
            return new SurfaceLoadForce()
            {
                Coordinates = GetLoadForceCoordinates(ifcStrucAction),
                ForceX = surfaceLoadForce.PlanarForceX,
                ForceY = surfaceLoadForce.PlanarForceY,
                ForceZ = surfaceLoadForce.PlanarForceZ
            };
        }
        static LoadForceCoordinates GetLoadForceCoordinates(IIfcStructuralAction ifcStrAction)
        {
            if (ifcStrAction is IIfcStructuralPointAction)
                throw new Exception("Sending Object of type IfcStructuralPointAction is invalid. It does not have a property called ProjectedOrTrue");
            return ifcStrAction.GlobalOrLocal == IfcGlobalOrLocalEnum.LOCAL_COORDS ? LoadForceCoordinates.Local
              : (IfcProjectedOrTrueLengthEnum)ifcStrAction.GetType().GetProperty("ProjectedOrTrue").GetValue(ifcStrAction) == IfcProjectedOrTrueLengthEnum.TRUE_LENGTH ? LoadForceCoordinates.Global_True_Length
              : LoadForceCoordinates.Global_Projected_Length;
        }
        // static LoadForceCoordinates GetLoadForceCoordinates(IIfcStructuralLinearAction ifcStrLinearAction)
        //=> ifcStrLinearAction.GlobalOrLocal == IfcGlobalOrLocalEnum.LOCAL_COORDS ? LoadForceCoordinates.Local
        //     : ifcStrLinearAction.ProjectedOrTrue == IfcProjectedOrTrueLengthEnum.TRUE_LENGTH ? LoadForceCoordinates.Global_True_Length
        //     : LoadForceCoordinates.Global_Projected_Length;

        //static LoadForce GetLoadForce(IIfcStructuralLoad ifcStrucLoad)
        //{
        //    if (ifcStrucLoad is IIfcStructuralLoadSingleForce)
        //        return GetLoadForce((IIfcStructuralLoadSingleForce)ifcStrucLoad);
        //    else if (ifcStrucLoad is IIfcStructuralLoadLinearForce)
        //        return GetLoadForce((IIfcStructuralLoadLinearForce)ifcStrucLoad);
        //    else if (ifcStrucLoad is IIfcStructuralLoadPlanarForce)
        //        return GetLoadForce((IIfcStructuralLoadPlanarForce)ifcStrucLoad);
        //    throw new Exception("Not Known Load Force In GetLoadForce Function");
        //}

        // static PointLoadForce GetLoadForce(IIfcStructuralLoadSingleForce ifcStrucLoad)
        //=> new PointLoadForce() { ForceX = ifcStrucLoad.ForceX, ForceY = ifcStrucLoad.ForceY, ForceZ = ifcStrucLoad.ForceZ, MomentX = ifcStrucLoad.MomentX, MomentY = ifcStrucLoad.MomentY, MomentZ = ifcStrucLoad.MomentZ };
        // static LinearLoadForce GetLoadForce(IIfcStructuralLoadLinearForce ifcStrucLoad)
        //=> new LinearLoadForce() { ForceX = ifcStrucLoad.LinearForceX, ForceY = ifcStrucLoad.LinearForceY, ForceZ = ifcStrucLoad.LinearForceZ, MomentX = ifcStrucLoad.LinearMomentX, MomentY = ifcStrucLoad.LinearMomentY, MomentZ = ifcStrucLoad.LinearMomentZ };
        // static SurfaceLoadForce GetLoadForce(IIfcStructuralLoadPlanarForce ifcStrucLoad)
        // => new SurfaceLoadForce() { ForceX = ifcStrucLoad.PlanarForceX, ForceY = ifcStrucLoad.PlanarForceY, ForceZ = ifcStrucLoad.PlanarForceZ };

        public static IEnumerable<LoadCombination> GetLoadCombinations(IfcStore ifcModel)
        {
            var strLoadGroups = ifcModel.Instances.OfType<IIfcStructuralLoadGroup>().Where(r => r.PredefinedType == IfcLoadGroupTypeEnum.LOAD_COMBINATION);
            return GetLoadCombinations(strLoadGroups);
        }

        static IEnumerable<LoadCombination> GetLoadCombinations(IEnumerable<IIfcStructuralLoadGroup> ifcStrGroups)
        {
            foreach (var ifcStrGroup in ifcStrGroups)
                yield return GetLoadCombination(ifcStrGroup);
        }
        static LoadCombination GetLoadCombination(IIfcStructuralLoadGroup ifcStrGroup)
            => new LoadCombination() { Id = ifcStrGroup.EntityLabel, Name = ifcStrGroup.Name, LoadCombinationItems = GetLoadCombinationItems(ifcStrGroup.IsGroupedBy.First().RelatedObjects.OfType<IIfcStructuralLoadGroup>()).ToList() };
        static IEnumerable<LoadCombinationItem> GetLoadCombinationItems(IEnumerable<IIfcStructuralLoadGroup> ifcStrGroups)
        {
            foreach (var ifcStrGroup in ifcStrGroups.Where(s => s.IsGroupedBy.Any()))
                foreach (var combinationItem in GetLoadCombinationItem(ifcStrGroup))
                    yield return combinationItem;
        }
        static IEnumerable<LoadCombinationItem> GetLoadCombinationItem(IIfcStructuralLoadGroup ifcStrGroup)
        {
            var ifcLoadCases = ifcStrGroup.IsGroupedBy.First().RelatedObjects;
            foreach (var ifcLoadCase in ifcLoadCases)
                yield return new LoadCombinationItem() { Factor = ifcStrGroup.Coefficient.Value, LoadCaseId = ifcLoadCase.EntityLabel, LoadCaseName = ifcLoadCase.Name };
        }
    }
}
