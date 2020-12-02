// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MaterialResource;
//## Custom using statements
//##

namespace Xbim.Ifc4.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcMaterialRelationship
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcMaterialRelationship : IIfcResourceLevelRelationship
	{
		IIfcMaterial @RelatingMaterial { get;  set; }
		IItemSet<IIfcMaterial> @RelatedMaterials { get; }
		IfcLabel? @Expression { get;  set; }
	
	}
}

namespace Xbim.Ifc4.MaterialResource
{
	[ExpressType("IfcMaterialRelationship", 1210)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcMaterialRelationship : IfcResourceLevelRelationship, IInstantiableEntity, IIfcMaterialRelationship, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<@IfcMaterialRelationship>
	{
		#region IIfcMaterialRelationship explicit implementation
		IIfcMaterial IIfcMaterialRelationship.RelatingMaterial { 
 
 
			get { return @RelatingMaterial; } 
			set { RelatingMaterial = value as IfcMaterial;}
		}	
		IItemSet<IIfcMaterial> IIfcMaterialRelationship.RelatedMaterials { 
			get { return new Common.Collections.ProxyItemSet<IfcMaterial, IIfcMaterial>( @RelatedMaterials); } 
		}	
		IfcLabel? IIfcMaterialRelationship.Expression { 
 
			get { return @Expression; } 
			set { Expression = value;}
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcMaterialRelationship(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_relatedMaterials = new ItemSet<IfcMaterial>( this, 0,  4);
		}

		#region Explicit attribute fields
		private IfcMaterial _relatingMaterial;
		private readonly ItemSet<IfcMaterial> _relatedMaterials;
		private IfcLabel? _expression;
		#endregion
	
		#region Explicit attribute properties
		[IndexedProperty]
		[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 3)]
		public IfcMaterial @RelatingMaterial 
		{ 
			get 
			{
				if(_activated) return _relatingMaterial;
				Activate();
				return _relatingMaterial;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _relatingMaterial = v, _relatingMaterial, value,  "RelatingMaterial", 3);
			} 
		}	
		[IndexedProperty]
		[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, 1, -1, 4)]
		public IItemSet<IfcMaterial> @RelatedMaterials 
		{ 
			get 
			{
				if(_activated) return _relatedMaterials;
				Activate();
				return _relatedMaterials;
			} 
		}	
		[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 5)]
		public IfcLabel? @Expression 
		{ 
			get 
			{
				if(_activated) return _expression;
				Activate();
				return _expression;
			} 
			set
			{
				SetValue( v =>  _expression = v, _expression, value,  "Expression", 5);
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
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 2: 
					_relatingMaterial = (IfcMaterial)(value.EntityVal);
					return;
				case 3: 
					_relatedMaterials.InternalAdd((IfcMaterial)value.EntityVal);
					return;
				case 4: 
					_expression = value.StringVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcMaterialRelationship other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@RelatingMaterial != null)
					yield return @RelatingMaterial;
				foreach(var entity in @RelatedMaterials)
					yield return entity;
			}
		}
		#endregion


		#region IContainsIndexedReferences
        IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences 
		{ 
			get
			{
				if (@RelatingMaterial != null)
					yield return @RelatingMaterial;
				foreach(var entity in @RelatedMaterials)
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