// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc2x3.MeasureResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Xbim.Common.Metadata;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.PresentationOrganizationResource;
//## Custom using statements
//##

namespace Xbim.Ifc2x3.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcPresentationLayerAssignment
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcPresentationLayerAssignment : IPersistEntity
	{
		IfcLabel @Name { get;  set; }
		IfcText? @Description { get;  set; }
		IItemSet<IIfcLayeredItem> @AssignedItems { get; }
		IfcIdentifier? @Identifier { get;  set; }
	
	}
}

namespace Xbim.Ifc2x3.PresentationOrganizationResource
{
	[ExpressType("IfcPresentationLayerAssignment", 258)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcPresentationLayerAssignment : PersistEntity, IInstantiableEntity, IIfcPresentationLayerAssignment, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<@IfcPresentationLayerAssignment>
	{
		#region IIfcPresentationLayerAssignment explicit implementation
		IfcLabel IIfcPresentationLayerAssignment.Name { 
 
			get { return @Name; } 
			set { Name = value;}
		}	
		IfcText? IIfcPresentationLayerAssignment.Description { 
 
			get { return @Description; } 
			set { Description = value;}
		}	
		IItemSet<IIfcLayeredItem> IIfcPresentationLayerAssignment.AssignedItems { 
			get { return new Common.Collections.ProxyItemSet<IfcLayeredItem, IIfcLayeredItem>( @AssignedItems); } 
		}	
		IfcIdentifier? IIfcPresentationLayerAssignment.Identifier { 
 
			get { return @Identifier; } 
			set { Identifier = value;}
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcPresentationLayerAssignment(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_assignedItems = new ItemSet<IfcLayeredItem>( this, 0,  3);
		}

		#region Explicit attribute fields
		private IfcLabel _name;
		private IfcText? _description;
		private readonly ItemSet<IfcLayeredItem> _assignedItems;
		private IfcIdentifier? _identifier;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 1)]
		public IfcLabel @Name 
		{ 
			get 
			{
				if(_activated) return _name;
				Activate();
				return _name;
			} 
			set
			{
				SetValue( v =>  _name = v, _name, value,  "Name", 1);
			} 
		}	
		[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 2)]
		public IfcText? @Description 
		{ 
			get 
			{
				if(_activated) return _description;
				Activate();
				return _description;
			} 
			set
			{
				SetValue( v =>  _description = v, _description, value,  "Description", 2);
			} 
		}	
		[IndexedProperty]
		[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, 1, -1, 3)]
		public IItemSet<IfcLayeredItem> @AssignedItems 
		{ 
			get 
			{
				if(_activated) return _assignedItems;
				Activate();
				return _assignedItems;
			} 
		}	
		[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 4)]
		public IfcIdentifier? @Identifier 
		{ 
			get 
			{
				if(_activated) return _identifier;
				Activate();
				return _identifier;
			} 
			set
			{
				SetValue( v =>  _identifier = v, _identifier, value,  "Identifier", 4);
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_name = value.StringVal;
					return;
				case 1: 
					_description = value.StringVal;
					return;
				case 2: 
					_assignedItems.InternalAdd((IfcLayeredItem)value.EntityVal);
					return;
				case 3: 
					_identifier = value.StringVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcPresentationLayerAssignment other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				foreach(var entity in @AssignedItems)
					yield return entity;
			}
		}
		#endregion


		#region IContainsIndexedReferences
        IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences 
		{ 
			get
			{
				foreach(var entity in @AssignedItems)
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