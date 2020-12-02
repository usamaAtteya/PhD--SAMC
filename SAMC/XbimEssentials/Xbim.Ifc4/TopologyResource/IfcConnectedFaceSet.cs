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
using Xbim.Ifc4.TopologyResource;
//## Custom using statements
//##

namespace Xbim.Ifc4.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcConnectedFaceSet
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcConnectedFaceSet : IIfcTopologicalRepresentationItem
	{
		IItemSet<IIfcFace> @CfsFaces { get; }
	
	}
}

namespace Xbim.Ifc4.TopologyResource
{
	[ExpressType("IfcConnectedFaceSet", 160)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcConnectedFaceSet : IfcTopologicalRepresentationItem, IInstantiableEntity, IIfcConnectedFaceSet, IContainsEntityReferences, IEquatable<@IfcConnectedFaceSet>
	{
		#region IIfcConnectedFaceSet explicit implementation
		IItemSet<IIfcFace> IIfcConnectedFaceSet.CfsFaces { 
			get { return new Common.Collections.ProxyItemSet<IfcFace, IIfcFace>( @CfsFaces); } 
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcConnectedFaceSet(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_cfsFaces = new ItemSet<IfcFace>( this, 0,  1);
		}

		#region Explicit attribute fields
		private readonly ItemSet<IfcFace> _cfsFaces;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, 1, -1, 3)]
		public IItemSet<IfcFace> @CfsFaces 
		{ 
			get 
			{
				if(_activated) return _cfsFaces;
				Activate();
				return _cfsFaces;
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_cfsFaces.InternalAdd((IfcFace)value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcConnectedFaceSet other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				foreach(var entity in @CfsFaces)
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