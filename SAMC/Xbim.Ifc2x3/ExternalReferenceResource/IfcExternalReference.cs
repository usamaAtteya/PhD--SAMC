// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc2x3.PresentationOrganizationResource;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.MeasureResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Xbim.Common.Metadata;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.ExternalReferenceResource;
//## Custom using statements
//##

namespace Xbim.Ifc2x3.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcExternalReference
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcExternalReference : IPersistEntity, IfcLightDistributionDataSourceSelect, IfcObjectReferenceSelect
	{
		IfcLabel? @Location { get;  set; }
		IfcIdentifier? @ItemReference { get;  set; }
		IfcLabel? @Name { get;  set; }
	
	}
}

namespace Xbim.Ifc2x3.ExternalReferenceResource
{
	[ExpressType("IfcExternalReference", 133)]
	// ReSharper disable once PartialTypeWithSinglePart
	public abstract partial class @IfcExternalReference : PersistEntity, IIfcExternalReference, IEquatable<@IfcExternalReference>
	{
		#region IIfcExternalReference explicit implementation
		IfcLabel? IIfcExternalReference.Location { 
 
			get { return @Location; } 
			set { Location = value;}
		}	
		IfcIdentifier? IIfcExternalReference.ItemReference { 
 
			get { return @ItemReference; } 
			set { ItemReference = value;}
		}	
		IfcLabel? IIfcExternalReference.Name { 
 
			get { return @Name; } 
			set { Name = value;}
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcExternalReference(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcLabel? _location;
		private IfcIdentifier? _itemReference;
		private IfcLabel? _name;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 1)]
		public IfcLabel? @Location 
		{ 
			get 
			{
				if(_activated) return _location;
				Activate();
				return _location;
			} 
			set
			{
				SetValue( v =>  _location = v, _location, value,  "Location", 1);
			} 
		}	
		[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 2)]
		public IfcIdentifier? @ItemReference 
		{ 
			get 
			{
				if(_activated) return _itemReference;
				Activate();
				return _itemReference;
			} 
			set
			{
				SetValue( v =>  _itemReference = v, _itemReference, value,  "ItemReference", 2);
			} 
		}	
		[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 3)]
		public IfcLabel? @Name 
		{ 
			get 
			{
				if(_activated) return _name;
				Activate();
				return _name;
			} 
			set
			{
				SetValue( v =>  _name = v, _name, value,  "Name", 3);
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_location = value.StringVal;
					return;
				case 1: 
					_itemReference = value.StringVal;
					return;
				case 2: 
					_name = value.StringVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcExternalReference other)
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