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
namespace Xbim.Ifc2x3.GeometricConstraintResource
{
	public partial class @IfcGridAxis : IIfcGridAxis
	{

		[CrossSchemaAttribute(typeof(IIfcGridAxis), 1)]
		Ifc4.MeasureResource.IfcLabel? IIfcGridAxis.AxisTag 
		{ 
			get
			{
				if (!AxisTag.HasValue) return null;
				return new Ifc4.MeasureResource.IfcLabel(AxisTag.Value);
			} 
			set
			{
				AxisTag = value.HasValue ? 
					new MeasureResource.IfcLabel(value.Value) :  
					 new MeasureResource.IfcLabel?() ;
				
			}
		}

		[CrossSchemaAttribute(typeof(IIfcGridAxis), 2)]
		IIfcCurve IIfcGridAxis.AxisCurve 
		{ 
			get
			{
				return AxisCurve;
			} 
			set
			{
				AxisCurve = value as GeometryResource.IfcCurve;
				
			}
		}

		[CrossSchemaAttribute(typeof(IIfcGridAxis), 3)]
		Ifc4.MeasureResource.IfcBoolean IIfcGridAxis.SameSense 
		{ 
			get
			{
				return new Ifc4.MeasureResource.IfcBoolean(SameSense);
			} 
			set
			{
				SameSense = new MeasureResource.IfcBoolean(value);
				
			}
		}
		IEnumerable<IIfcGrid> IIfcGridAxis.PartOfW 
		{ 
			get
			{
				return Model.Instances.Where<IIfcGrid>(e => e.WAxes != null &&  e.WAxes.Contains(this), "WAxes", this);
			} 
		}
		IEnumerable<IIfcGrid> IIfcGridAxis.PartOfV 
		{ 
			get
			{
				return Model.Instances.Where<IIfcGrid>(e => e.VAxes != null &&  e.VAxes.Contains(this), "VAxes", this);
			} 
		}
		IEnumerable<IIfcGrid> IIfcGridAxis.PartOfU 
		{ 
			get
			{
				return Model.Instances.Where<IIfcGrid>(e => e.UAxes != null &&  e.UAxes.Contains(this), "UAxes", this);
			} 
		}
		IEnumerable<IIfcVirtualGridIntersection> IIfcGridAxis.HasIntersections 
		{ 
			get
			{
				return Model.Instances.Where<IIfcVirtualGridIntersection>(e => e.IntersectingAxes != null &&  e.IntersectingAxes.Contains(this), "IntersectingAxes", this);
			} 
		}
	//## Custom code
	//##
	}
}