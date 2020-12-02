// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ActorResource;
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
    /// Readonly interface for IfcBuilding
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcBuilding : IIfcSpatialStructureElement
	{
		IfcLengthMeasure? @ElevationOfRefHeight { get;  set; }
		IfcLengthMeasure? @ElevationOfTerrain { get;  set; }
		IIfcPostalAddress @BuildingAddress { get;  set; }
	
	}
}

namespace Xbim.Ifc2x3.ProductExtension
{
	[ExpressType("IfcBuilding", 169)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcBuilding : IfcSpatialStructureElement, IInstantiableEntity, IIfcBuilding, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<@IfcBuilding>
	{
		#region IIfcBuilding explicit implementation
		IfcLengthMeasure? IIfcBuilding.ElevationOfRefHeight { 
 
			get { return @ElevationOfRefHeight; } 
			set { ElevationOfRefHeight = value;}
		}	
		IfcLengthMeasure? IIfcBuilding.ElevationOfTerrain { 
 
			get { return @ElevationOfTerrain; } 
			set { ElevationOfTerrain = value;}
		}	
		IIfcPostalAddress IIfcBuilding.BuildingAddress { 
 
 
			get { return @BuildingAddress; } 
			set { BuildingAddress = value as IfcPostalAddress;}
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcBuilding(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcLengthMeasure? _elevationOfRefHeight;
		private IfcLengthMeasure? _elevationOfTerrain;
		private IfcPostalAddress _buildingAddress;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 19)]
		public IfcLengthMeasure? @ElevationOfRefHeight 
		{ 
			get 
			{
				if(_activated) return _elevationOfRefHeight;
				Activate();
				return _elevationOfRefHeight;
			} 
			set
			{
				SetValue( v =>  _elevationOfRefHeight = v, _elevationOfRefHeight, value,  "ElevationOfRefHeight", 10);
			} 
		}	
		[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 20)]
		public IfcLengthMeasure? @ElevationOfTerrain 
		{ 
			get 
			{
				if(_activated) return _elevationOfTerrain;
				Activate();
				return _elevationOfTerrain;
			} 
			set
			{
				SetValue( v =>  _elevationOfTerrain = v, _elevationOfTerrain, value,  "ElevationOfTerrain", 11);
			} 
		}	
		[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 21)]
		public IfcPostalAddress @BuildingAddress 
		{ 
			get 
			{
				if(_activated) return _buildingAddress;
				Activate();
				return _buildingAddress;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _buildingAddress = v, _buildingAddress, value,  "BuildingAddress", 12);
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
				case 4: 
				case 5: 
				case 6: 
				case 7: 
				case 8: 
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 9: 
					_elevationOfRefHeight = value.RealVal;
					return;
				case 10: 
					_elevationOfTerrain = value.RealVal;
					return;
				case 11: 
					_buildingAddress = (IfcPostalAddress)(value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcBuilding other)
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
				if (@ObjectPlacement != null)
					yield return @ObjectPlacement;
				if (@Representation != null)
					yield return @Representation;
				if (@BuildingAddress != null)
					yield return @BuildingAddress;
			}
		}
		#endregion


		#region IContainsIndexedReferences
        IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences 
		{ 
			get
			{
				if (@ObjectPlacement != null)
					yield return @ObjectPlacement;
				if (@Representation != null)
					yield return @Representation;
				
			} 
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}