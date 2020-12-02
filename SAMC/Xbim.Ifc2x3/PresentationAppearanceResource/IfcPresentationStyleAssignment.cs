// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Xbim.Common.Metadata;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.PresentationAppearanceResource;
//## Custom using statements
//##

namespace Xbim.Ifc2x3.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcPresentationStyleAssignment
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcPresentationStyleAssignment : IPersistEntity
	{
		IItemSet<IIfcPresentationStyleSelect> @Styles { get; }
	
	}
}

namespace Xbim.Ifc2x3.PresentationAppearanceResource
{
	[ExpressType("IfcPresentationStyleAssignment", 584)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcPresentationStyleAssignment : PersistEntity, IInstantiableEntity, IIfcPresentationStyleAssignment, IEquatable<@IfcPresentationStyleAssignment>
	{
		#region IIfcPresentationStyleAssignment explicit implementation
		IItemSet<IIfcPresentationStyleSelect> IIfcPresentationStyleAssignment.Styles { 
			get { return new Common.Collections.ProxyItemSet<IfcPresentationStyleSelect, IIfcPresentationStyleSelect>( @Styles); } 
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcPresentationStyleAssignment(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_styles = new ItemSet<IfcPresentationStyleSelect>( this, 0,  1);
		}

		#region Explicit attribute fields
		private readonly ItemSet<IfcPresentationStyleSelect> _styles;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, 1, -1, 1)]
		public IItemSet<IfcPresentationStyleSelect> @Styles 
		{ 
			get 
			{
				if(_activated) return _styles;
				Activate();
				return _styles;
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_styles.InternalAdd((IfcPresentationStyleSelect)value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcPresentationStyleAssignment other)
	    {
	        return this == other;
	    }
        #endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}