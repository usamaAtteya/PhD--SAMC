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
using Xbim.Ifc4.PropertyResource;
//## Custom using statements
//##

namespace Xbim.Ifc4.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcPropertyDependencyRelationship
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcPropertyDependencyRelationship : IIfcResourceLevelRelationship
	{
		IIfcProperty @DependingProperty { get;  set; }
		IIfcProperty @DependantProperty { get;  set; }
		IfcText? @Expression { get;  set; }
	
	}
}

namespace Xbim.Ifc4.PropertyResource
{
	[ExpressType("IfcPropertyDependencyRelationship", 444)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcPropertyDependencyRelationship : IfcResourceLevelRelationship, IInstantiableEntity, IIfcPropertyDependencyRelationship, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<@IfcPropertyDependencyRelationship>
	{
		#region IIfcPropertyDependencyRelationship explicit implementation
		IIfcProperty IIfcPropertyDependencyRelationship.DependingProperty { 
 
 
			get { return @DependingProperty; } 
			set { DependingProperty = value as IfcProperty;}
		}	
		IIfcProperty IIfcPropertyDependencyRelationship.DependantProperty { 
 
 
			get { return @DependantProperty; } 
			set { DependantProperty = value as IfcProperty;}
		}	
		IfcText? IIfcPropertyDependencyRelationship.Expression { 
 
			get { return @Expression; } 
			set { Expression = value;}
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcPropertyDependencyRelationship(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcProperty _dependingProperty;
		private IfcProperty _dependantProperty;
		private IfcText? _expression;
		#endregion
	
		#region Explicit attribute properties
		[IndexedProperty]
		[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 3)]
		public IfcProperty @DependingProperty 
		{ 
			get 
			{
				if(_activated) return _dependingProperty;
				Activate();
				return _dependingProperty;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _dependingProperty = v, _dependingProperty, value,  "DependingProperty", 3);
			} 
		}	
		[IndexedProperty]
		[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 4)]
		public IfcProperty @DependantProperty 
		{ 
			get 
			{
				if(_activated) return _dependantProperty;
				Activate();
				return _dependantProperty;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _dependantProperty = v, _dependantProperty, value,  "DependantProperty", 4);
			} 
		}	
		[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 5)]
		public IfcText? @Expression 
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
					_dependingProperty = (IfcProperty)(value.EntityVal);
					return;
				case 3: 
					_dependantProperty = (IfcProperty)(value.EntityVal);
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
        public bool Equals(@IfcPropertyDependencyRelationship other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@DependingProperty != null)
					yield return @DependingProperty;
				if (@DependantProperty != null)
					yield return @DependantProperty;
			}
		}
		#endregion


		#region IContainsIndexedReferences
        IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences 
		{ 
			get
			{
				if (@DependingProperty != null)
					yield return @DependingProperty;
				if (@DependantProperty != null)
					yield return @DependantProperty;
				
			} 
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}