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
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
//## Custom using statements
//##

namespace Xbim.Ifc4.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcRelDefinesByTemplate
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcRelDefinesByTemplate : IIfcRelDefines
	{
		IItemSet<IIfcPropertySetDefinition> @RelatedPropertySets { get; }
		IIfcPropertySetTemplate @RelatingTemplate { get;  set; }
	
	}
}

namespace Xbim.Ifc4.Kernel
{
	[ExpressType("IfcRelDefinesByTemplate", 1251)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcRelDefinesByTemplate : IfcRelDefines, IInstantiableEntity, IIfcRelDefinesByTemplate, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<@IfcRelDefinesByTemplate>
	{
		#region IIfcRelDefinesByTemplate explicit implementation
		IItemSet<IIfcPropertySetDefinition> IIfcRelDefinesByTemplate.RelatedPropertySets { 
			get { return new Common.Collections.ProxyItemSet<IfcPropertySetDefinition, IIfcPropertySetDefinition>( @RelatedPropertySets); } 
		}	
		IIfcPropertySetTemplate IIfcRelDefinesByTemplate.RelatingTemplate { 
 
 
			get { return @RelatingTemplate; } 
			set { RelatingTemplate = value as IfcPropertySetTemplate;}
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcRelDefinesByTemplate(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_relatedPropertySets = new ItemSet<IfcPropertySetDefinition>( this, 0,  5);
		}

		#region Explicit attribute fields
		private readonly ItemSet<IfcPropertySetDefinition> _relatedPropertySets;
		private IfcPropertySetTemplate _relatingTemplate;
		#endregion
	
		#region Explicit attribute properties
		[IndexedProperty]
		[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, 1, -1, 5)]
		public IItemSet<IfcPropertySetDefinition> @RelatedPropertySets 
		{ 
			get 
			{
				if(_activated) return _relatedPropertySets;
				Activate();
				return _relatedPropertySets;
			} 
		}	
		[IndexedProperty]
		[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 6)]
		public IfcPropertySetTemplate @RelatingTemplate 
		{ 
			get 
			{
				if(_activated) return _relatingTemplate;
				Activate();
				return _relatingTemplate;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _relatingTemplate = v, _relatingTemplate, value,  "RelatingTemplate", 6);
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
					_relatedPropertySets.InternalAdd((IfcPropertySetDefinition)value.EntityVal);
					return;
				case 5: 
					_relatingTemplate = (IfcPropertySetTemplate)(value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcRelDefinesByTemplate other)
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
				foreach(var entity in @RelatedPropertySets)
					yield return entity;
				if (@RelatingTemplate != null)
					yield return @RelatingTemplate;
			}
		}
		#endregion


		#region IContainsIndexedReferences
        IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences 
		{ 
			get
			{
				foreach(var entity in @RelatedPropertySets)
					yield return entity;
				if (@RelatingTemplate != null)
					yield return @RelatingTemplate;
				
			} 
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}