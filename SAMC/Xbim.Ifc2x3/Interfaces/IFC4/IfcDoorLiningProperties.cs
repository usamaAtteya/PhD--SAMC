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
namespace Xbim.Ifc2x3.SharedBldgElements
{
	public partial class @IfcDoorLiningProperties : IIfcDoorLiningProperties
	{

		[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 5)]
		Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcDoorLiningProperties.LiningDepth 
		{ 
			get
			{
				if (!LiningDepth.HasValue) return null;
				return new Ifc4.MeasureResource.IfcPositiveLengthMeasure(LiningDepth.Value);
			} 
			set
			{
				LiningDepth = value.HasValue ? 
					new MeasureResource.IfcPositiveLengthMeasure(value.Value) :  
					 new MeasureResource.IfcPositiveLengthMeasure?() ;
				
			}
		}

		[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 6)]
		Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcDoorLiningProperties.LiningThickness 
		{ 
			get
			{
				if (!LiningThickness.HasValue) return null;
				return new Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(LiningThickness.Value);
			} 
			set
			{
				LiningThickness = value.HasValue ? 
					new MeasureResource.IfcPositiveLengthMeasure(value.Value) :  
					 new MeasureResource.IfcPositiveLengthMeasure?() ;
				
			}
		}

		[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 7)]
		Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcDoorLiningProperties.ThresholdDepth 
		{ 
			get
			{
				if (!ThresholdDepth.HasValue) return null;
				return new Ifc4.MeasureResource.IfcPositiveLengthMeasure(ThresholdDepth.Value);
			} 
			set
			{
				ThresholdDepth = value.HasValue ? 
					new MeasureResource.IfcPositiveLengthMeasure(value.Value) :  
					 new MeasureResource.IfcPositiveLengthMeasure?() ;
				
			}
		}

		[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 8)]
		Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcDoorLiningProperties.ThresholdThickness 
		{ 
			get
			{
				if (!ThresholdThickness.HasValue) return null;
				return new Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(ThresholdThickness.Value);
			} 
			set
			{
				ThresholdThickness = value.HasValue ? 
					new MeasureResource.IfcPositiveLengthMeasure(value.Value) :  
					 new MeasureResource.IfcPositiveLengthMeasure?() ;
				
			}
		}

		[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 9)]
		Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcDoorLiningProperties.TransomThickness 
		{ 
			get
			{
				if (!TransomThickness.HasValue) return null;
				return new Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(TransomThickness.Value);
			} 
			set
			{
				TransomThickness = value.HasValue ? 
					new MeasureResource.IfcPositiveLengthMeasure(value.Value) :  
					 new MeasureResource.IfcPositiveLengthMeasure?() ;
				
			}
		}

		[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 10)]
		Ifc4.MeasureResource.IfcLengthMeasure? IIfcDoorLiningProperties.TransomOffset 
		{ 
			get
			{
				if (!TransomOffset.HasValue) return null;
				return new Ifc4.MeasureResource.IfcLengthMeasure(TransomOffset.Value);
			} 
			set
			{
				TransomOffset = value.HasValue ? 
					new MeasureResource.IfcLengthMeasure(value.Value) :  
					 new MeasureResource.IfcLengthMeasure?() ;
				
			}
		}

		[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 11)]
		Ifc4.MeasureResource.IfcLengthMeasure? IIfcDoorLiningProperties.LiningOffset 
		{ 
			get
			{
				if (!LiningOffset.HasValue) return null;
				return new Ifc4.MeasureResource.IfcLengthMeasure(LiningOffset.Value);
			} 
			set
			{
				LiningOffset = value.HasValue ? 
					new MeasureResource.IfcLengthMeasure(value.Value) :  
					 new MeasureResource.IfcLengthMeasure?() ;
				
			}
		}

		[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 12)]
		Ifc4.MeasureResource.IfcLengthMeasure? IIfcDoorLiningProperties.ThresholdOffset 
		{ 
			get
			{
				if (!ThresholdOffset.HasValue) return null;
				return new Ifc4.MeasureResource.IfcLengthMeasure(ThresholdOffset.Value);
			} 
			set
			{
				ThresholdOffset = value.HasValue ? 
					new MeasureResource.IfcLengthMeasure(value.Value) :  
					 new MeasureResource.IfcLengthMeasure?() ;
				
			}
		}

		[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 13)]
		Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcDoorLiningProperties.CasingThickness 
		{ 
			get
			{
				if (!CasingThickness.HasValue) return null;
				return new Ifc4.MeasureResource.IfcPositiveLengthMeasure(CasingThickness.Value);
			} 
			set
			{
				CasingThickness = value.HasValue ? 
					new MeasureResource.IfcPositiveLengthMeasure(value.Value) :  
					 new MeasureResource.IfcPositiveLengthMeasure?() ;
				
			}
		}

		[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 14)]
		Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcDoorLiningProperties.CasingDepth 
		{ 
			get
			{
				if (!CasingDepth.HasValue) return null;
				return new Ifc4.MeasureResource.IfcPositiveLengthMeasure(CasingDepth.Value);
			} 
			set
			{
				CasingDepth = value.HasValue ? 
					new MeasureResource.IfcPositiveLengthMeasure(value.Value) :  
					 new MeasureResource.IfcPositiveLengthMeasure?() ;
				
			}
		}

		[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 15)]
		IIfcShapeAspect IIfcDoorLiningProperties.ShapeAspectStyle 
		{ 
			get
			{
				return ShapeAspectStyle;
			} 
			set
			{
				ShapeAspectStyle = value as RepresentationResource.IfcShapeAspect;
				
			}
		}

		private  Ifc4.MeasureResource.IfcLengthMeasure? _liningToPanelOffsetX;


		[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 16)]
		Ifc4.MeasureResource.IfcLengthMeasure? IIfcDoorLiningProperties.LiningToPanelOffsetX 
		{ 
			get
			{
				return _liningToPanelOffsetX;
			} 
			set
			{
				SetValue(v => _liningToPanelOffsetX = v, _liningToPanelOffsetX, value, "LiningToPanelOffsetX", -16);
				
			}
		}

		private  Ifc4.MeasureResource.IfcLengthMeasure? _liningToPanelOffsetY;


		[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 17)]
		Ifc4.MeasureResource.IfcLengthMeasure? IIfcDoorLiningProperties.LiningToPanelOffsetY 
		{ 
			get
			{
				return _liningToPanelOffsetY;
			} 
			set
			{
				SetValue(v => _liningToPanelOffsetY = v, _liningToPanelOffsetY, value, "LiningToPanelOffsetY", -17);
				
			}
		}
	//## Custom code
	//##
	}
}