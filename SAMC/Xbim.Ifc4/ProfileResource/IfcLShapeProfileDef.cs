// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc4.MeasureResource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.ProfileResource;
//## Custom using statements
//##

namespace Xbim.Ifc4.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcLShapeProfileDef
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcLShapeProfileDef : IIfcParameterizedProfileDef
	{
		IfcPositiveLengthMeasure @Depth { get;  set; }
		IfcPositiveLengthMeasure? @Width { get;  set; }
		IfcPositiveLengthMeasure @Thickness { get;  set; }
		IfcNonNegativeLengthMeasure? @FilletRadius { get;  set; }
		IfcNonNegativeLengthMeasure? @EdgeRadius { get;  set; }
		IfcPlaneAngleMeasure? @LegSlope { get;  set; }
	
	}
}

namespace Xbim.Ifc4.ProfileResource
{
	[ExpressType("IfcLShapeProfileDef", 284)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcLShapeProfileDef : IfcParameterizedProfileDef, IInstantiableEntity, IIfcLShapeProfileDef, IContainsEntityReferences, IEquatable<@IfcLShapeProfileDef>
	{
		#region IIfcLShapeProfileDef explicit implementation
		IfcPositiveLengthMeasure IIfcLShapeProfileDef.Depth { 
 
			get { return @Depth; } 
			set { Depth = value;}
		}	
		IfcPositiveLengthMeasure? IIfcLShapeProfileDef.Width { 
 
			get { return @Width; } 
			set { Width = value;}
		}	
		IfcPositiveLengthMeasure IIfcLShapeProfileDef.Thickness { 
 
			get { return @Thickness; } 
			set { Thickness = value;}
		}	
		IfcNonNegativeLengthMeasure? IIfcLShapeProfileDef.FilletRadius { 
 
			get { return @FilletRadius; } 
			set { FilletRadius = value;}
		}	
		IfcNonNegativeLengthMeasure? IIfcLShapeProfileDef.EdgeRadius { 
 
			get { return @EdgeRadius; } 
			set { EdgeRadius = value;}
		}	
		IfcPlaneAngleMeasure? IIfcLShapeProfileDef.LegSlope { 
 
			get { return @LegSlope; } 
			set { LegSlope = value;}
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcLShapeProfileDef(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcPositiveLengthMeasure _depth;
		private IfcPositiveLengthMeasure? _width;
		private IfcPositiveLengthMeasure _thickness;
		private IfcNonNegativeLengthMeasure? _filletRadius;
		private IfcNonNegativeLengthMeasure? _edgeRadius;
		private IfcPlaneAngleMeasure? _legSlope;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 6)]
		public IfcPositiveLengthMeasure @Depth 
		{ 
			get 
			{
				if(_activated) return _depth;
				Activate();
				return _depth;
			} 
			set
			{
				SetValue( v =>  _depth = v, _depth, value,  "Depth", 4);
			} 
		}	
		[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 7)]
		public IfcPositiveLengthMeasure? @Width 
		{ 
			get 
			{
				if(_activated) return _width;
				Activate();
				return _width;
			} 
			set
			{
				SetValue( v =>  _width = v, _width, value,  "Width", 5);
			} 
		}	
		[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 8)]
		public IfcPositiveLengthMeasure @Thickness 
		{ 
			get 
			{
				if(_activated) return _thickness;
				Activate();
				return _thickness;
			} 
			set
			{
				SetValue( v =>  _thickness = v, _thickness, value,  "Thickness", 6);
			} 
		}	
		[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 9)]
		public IfcNonNegativeLengthMeasure? @FilletRadius 
		{ 
			get 
			{
				if(_activated) return _filletRadius;
				Activate();
				return _filletRadius;
			} 
			set
			{
				SetValue( v =>  _filletRadius = v, _filletRadius, value,  "FilletRadius", 7);
			} 
		}	
		[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 10)]
		public IfcNonNegativeLengthMeasure? @EdgeRadius 
		{ 
			get 
			{
				if(_activated) return _edgeRadius;
				Activate();
				return _edgeRadius;
			} 
			set
			{
				SetValue( v =>  _edgeRadius = v, _edgeRadius, value,  "EdgeRadius", 8);
			} 
		}	
		[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 11)]
		public IfcPlaneAngleMeasure? @LegSlope 
		{ 
			get 
			{
				if(_activated) return _legSlope;
				Activate();
				return _legSlope;
			} 
			set
			{
				SetValue( v =>  _legSlope = v, _legSlope, value,  "LegSlope", 9);
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
				case 1: 
				case 2: 
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 3: 
					_depth = value.RealVal;
					return;
				case 4: 
					_width = value.RealVal;
					return;
				case 5: 
					_thickness = value.RealVal;
					return;
				case 6: 
					_filletRadius = value.RealVal;
					return;
				case 7: 
					_edgeRadius = value.RealVal;
					return;
				case 8: 
					_legSlope = value.RealVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcLShapeProfileDef other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@Position != null)
					yield return @Position;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}