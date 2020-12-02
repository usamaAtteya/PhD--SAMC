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
    /// Readonly interface for IfcCircleHollowProfileDef
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcCircleHollowProfileDef : IIfcCircleProfileDef
	{
		IfcPositiveLengthMeasure @WallThickness { get;  set; }
	
	}
}

namespace Xbim.Ifc4.ProfileResource
{
	[ExpressType("IfcCircleHollowProfileDef", 114)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcCircleHollowProfileDef : IfcCircleProfileDef, IInstantiableEntity, IIfcCircleHollowProfileDef, IContainsEntityReferences, IEquatable<@IfcCircleHollowProfileDef>
	{
		#region IIfcCircleHollowProfileDef explicit implementation
		IfcPositiveLengthMeasure IIfcCircleHollowProfileDef.WallThickness { 
 
			get { return @WallThickness; } 
			set { WallThickness = value;}
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcCircleHollowProfileDef(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcPositiveLengthMeasure _wallThickness;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 7)]
		public IfcPositiveLengthMeasure @WallThickness 
		{ 
			get 
			{
				if(_activated) return _wallThickness;
				Activate();
				return _wallThickness;
			} 
			set
			{
				SetValue( v =>  _wallThickness = v, _wallThickness, value,  "WallThickness", 5);
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
				case 3: 
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 4: 
					_wallThickness = value.RealVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcCircleHollowProfileDef other)
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