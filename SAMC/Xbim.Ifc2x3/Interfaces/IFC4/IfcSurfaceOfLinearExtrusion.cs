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
	public partial class @IfcSurfaceOfLinearExtrusion : IIfcSurfaceOfLinearExtrusion
	{

		[CrossSchemaAttribute(typeof(IIfcSurfaceOfLinearExtrusion), 3)]
		IIfcDirection IIfcSurfaceOfLinearExtrusion.ExtrudedDirection 
		{ 
			get
			{
				return ExtrudedDirection;
			} 
			set
			{
				ExtrudedDirection = value as IfcDirection;
				
			}
		}

		[CrossSchemaAttribute(typeof(IIfcSurfaceOfLinearExtrusion), 4)]
		Ifc4.MeasureResource.IfcLengthMeasure IIfcSurfaceOfLinearExtrusion.Depth 
		{ 
			get
			{
				return new Ifc4.MeasureResource.IfcLengthMeasure(Depth);
			} 
			set
			{
				Depth = new MeasureResource.IfcLengthMeasure(value);
				
			}
		}
		Common.Geometry.XbimVector3D IIfcSurfaceOfLinearExtrusion.ExtrusionAxis 
		{
			get 
			{
				return ExtrusionAxis;
			}
		}

	//## Custom code
	//##
	}
}