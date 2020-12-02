// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc4.GeometryResource;
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
    /// Readonly interface for IfcArbitraryProfileDefWithVoids
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcArbitraryProfileDefWithVoids : IIfcArbitraryClosedProfileDef
	{
		IItemSet<IIfcCurve> @InnerCurves { get; }
	
	}
}

namespace Xbim.Ifc4.ProfileResource
{
	[ExpressType("IfcArbitraryProfileDefWithVoids", 116)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcArbitraryProfileDefWithVoids : IfcArbitraryClosedProfileDef, IInstantiableEntity, IIfcArbitraryProfileDefWithVoids, IContainsEntityReferences, IEquatable<@IfcArbitraryProfileDefWithVoids>
	{
		#region IIfcArbitraryProfileDefWithVoids explicit implementation
		IItemSet<IIfcCurve> IIfcArbitraryProfileDefWithVoids.InnerCurves { 
			get { return new Common.Collections.ProxyItemSet<IfcCurve, IIfcCurve>( @InnerCurves); } 
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcArbitraryProfileDefWithVoids(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_innerCurves = new ItemSet<IfcCurve>( this, 0,  4);
		}

		#region Explicit attribute fields
		private readonly ItemSet<IfcCurve> _innerCurves;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, 1, -1, 6)]
		public IItemSet<IfcCurve> @InnerCurves 
		{ 
			get 
			{
				if(_activated) return _innerCurves;
				Activate();
				return _innerCurves;
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
					_innerCurves.InternalAdd((IfcCurve)value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcArbitraryProfileDefWithVoids other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@OuterCurve != null)
					yield return @OuterCurve;
				foreach(var entity in @InnerCurves)
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