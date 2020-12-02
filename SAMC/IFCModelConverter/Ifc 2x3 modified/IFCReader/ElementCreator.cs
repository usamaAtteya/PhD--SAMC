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
    class ElementCreator
    {
        public static IEnumerable<Element> CreateElements(IfcStore ifcModel)
            => CreateElements(ifcModel.Instances.OfType<IIfcStructuralMember>());
        public static IEnumerable<Element> CreateElements(IEnumerable<IIfcStructuralMember> strMembers)
        {
            foreach (var strMember in strMembers)
                yield return CreateElement(strMember);
        }
        public static Element CreateElement(IIfcStructuralMember strMember)
        {
            if (strMember is IIfcStructuralCurveMember)
                return CreateElement<FrameElement>(strMember);
            else if (strMember is IIfcStructuralSurfaceMember)
                return CreateElement<AreaElement>(strMember);
            throw new Exception("Not Implemented Ifc structural member so CreateElement function cant create Element");
        }
        static Element CreateElement<T>(IIfcStructuralMember strMember) where T : Element, new()
    => new T() { Id = strMember.EntityLabel, Section = SectionCreator.Create(strMember), Vertices = GetStructuralMemberVertices(strMember).ToList() };


        static IEnumerable<Point> GetStructuralMemberVertices(IIfcStructuralMember strMember)
        {
            var strMemberPoints = strMember.ConnectedBy.Where(c => c.RelatedStructuralConnection is IIfcStructuralPointConnection);
            foreach (var point in strMemberPoints)
            {
                var nodeBoundaryCnd = point.RelatedStructuralConnection.AppliedCondition as IIfcBoundaryNodeCondition;
                var ifcCartesianPoint = (point.RelatedStructuralConnection.Representation.Representations.First().Items.First() as IIfcVertexPoint).VertexGeometry as IIfcCartesianPoint;
                yield return new Point() { Id = point.RelatedStructuralConnection.EntityLabel, X = ifcCartesianPoint.X, Y = ifcCartesianPoint.Y, Z = ifcCartesianPoint.Z, BoundaryCondition = GetBoundaryCondition(nodeBoundaryCnd) };
            }
            #region Old Way of getting vertices of structural curve member
            //var frameElements = _ifcModel.Instances.OfType<IIfcStructuralCurveMember>().ToList();
            //foreach (var elmnt in frameElements)
            // {
            //var curve = elmnt.Representation.Representations.First().Items.First as IIfcEdgeCurve;
            //var startPoint = (curve.EdgeStart as IIfcVertexPoint).VertexGeometry as IIfcCartesianPoint;
            //var endPoint = (curve.EdgeEnd as IIfcVertexPoint).VertexGeometry as IIfcCartesianPoint;
            // }  
            #endregion
            #region Old way of getting vertices of structural surface member
            //var surfaceElements = _ifcModel.Instances.OfType<IIfcStructuralSurfaceMember>().ToList();
            //foreach (var elmnt in surfaceElements)
            //{
            //    var surfPointsRels = elmnt.ConnectedBy;
            //    foreach (var surfPointRel in surfPointsRels)
            //    {
            //        var connection = surfPointRel.RelatedStructuralConnection; //as IfcStructuralPointConnection to get boundary condition
            //        var point = (connection.Representation.Representations.First().Items.First as IIfcVertexPoint).VertexGeometry as IIfcCartesianPoint;
            //    }              
            //}
            #endregion
        }

        static BoundaryCondition GetBoundaryCondition(IIfcBoundaryNodeCondition bndCnd)
          => bndCnd == null ? null : new BoundaryCondition()
          {
              IsFreeTransX = Convert.ToInt32(bndCnd.TranslationalStiffnessX.Value) == 0,
              IsFreeTransY = Convert.ToInt32(bndCnd.TranslationalStiffnessY.Value) == 0,
              IsFreeTransZ = Convert.ToInt32(bndCnd.TranslationalStiffnessZ.Value) == 0,
              IsFreeMomentX = Convert.ToInt32(bndCnd.RotationalStiffnessX.Value) == 0,
              IsFreeMomentY = Convert.ToInt32(bndCnd.RotationalStiffnessY.Value) == 0,
              IsFreeMomentZ = Convert.ToInt32(bndCnd.RotationalStiffnessZ.Value) == 0,
          };


    }
}
