// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.QuantityResource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.ProductExtension;
//## Custom using statements
//##

namespace Xbim.Ifc2x3.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcElementQuantity
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcElementQuantity : IIfcPropertySetDefinition
	{
		IfcLabel? @MethodOfMeasurement { get;  set; }
		IItemSet<IIfcPhysicalQuantity> @Quantities { get; }
	
	}
}

namespace Xbim.Ifc2x3.ProductExtension
{
	[ExpressType("IfcElementQuantity", 458)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcElementQuantity : IfcPropertySetDefinition, IInstantiableEntity, IIfcElementQuantity, IContainsEntityReferences, IEquatable<@IfcElementQuantity>
	{
		#region IIfcElementQuantity explicit implementation
		IfcLabel? IIfcElementQuantity.MethodOfMeasurement { 
 
			get { return @MethodOfMeasurement; } 
			set { MethodOfMeasurement = value;}
		}	
		IItemSet<IIfcPhysicalQuantity> IIfcElementQuantity.Quantities { 
			get { return new Common.Collections.ProxyItemSet<IfcPhysicalQuantity, IIfcPhysicalQuantity>( @Quantities); } 
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcElementQuantity(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_quantities = new ItemSet<IfcPhysicalQuantity>( this, 0,  6);
		}

		#region Explicit attribute fields
		private IfcLabel? _methodOfMeasurement;
		private readonly ItemSet<IfcPhysicalQuantity> _quantities;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 8)]
		public IfcLabel? @MethodOfMeasurement 
		{ 
			get 
			{
				if(_activated) return _methodOfMeasurement;
				Activate();
				return _methodOfMeasurement;
			} 
			set
			{
				SetValue( v =>  _methodOfMeasurement = v, _methodOfMeasurement, value,  "MethodOfMeasurement", 5);
			} 
		}	
		[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, 1, -1, 9)]
		public IItemSet<IfcPhysicalQuantity> @Quantities 
		{ 
			get 
			{
				if(_activated) return _quantities;
				Activate();
				return _quantities;
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
					_methodOfMeasurement = value.StringVal;
					return;
				case 5: 
					_quantities.InternalAdd((IfcPhysicalQuantity)value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcElementQuantity other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@OwnerHistory != null)
					yield return @OwnerHistory;
				foreach(var entity in @Quantities)
					yield return entity;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}