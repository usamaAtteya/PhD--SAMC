// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc4.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

// ReSharper disable once CheckNamespace
namespace Xbim.Ifc2x3.GeometryResource
{
	public partial class @IfcCompositeCurve : IIfcCompositeCurve
	{

		[CrossSchemaAttribute(typeof(IIfcCompositeCurve), 1)]
		IItemSet<IIfcCompositeCurveSegment> IIfcCompositeCurve.Segments 
		{ 
			get
			{
			
				return new Common.Collections.ProxyItemSet<IfcCompositeCurveSegment, IIfcCompositeCurveSegment>(Segments);
			} 
		}

		[CrossSchemaAttribute(typeof(IIfcCompositeCurve), 2)]
		Ifc4.MeasureResource.IfcLogical IIfcCompositeCurve.SelfIntersect 
		{ 
			get
			{
				//## Handle return of SelfIntersect for which no match was found
                return new Ifc4.MeasureResource.IfcLogical(SelfIntersect);
				//##
			} 
			set
			{
				SelfIntersect = value;
				
			}
		}
		Ifc4.MeasureResource.IfcInteger IIfcCompositeCurve.NSegments 
		{
			get 
			{
				return new Ifc4.MeasureResource.IfcInteger(NSegments);
			}
		}

		Ifc4.MeasureResource.IfcLogical IIfcCompositeCurve.ClosedCurve 
		{
			get 
			{
				return new Ifc4.MeasureResource.IfcLogical(ClosedCurve);
			}
		}

	//## Custom code
	//##
	}
}