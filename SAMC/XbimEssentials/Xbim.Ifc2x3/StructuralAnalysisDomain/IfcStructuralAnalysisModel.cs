// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.GeometryResource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.StructuralAnalysisDomain;
//## Custom using statements
//##

namespace Xbim.Ifc2x3.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcStructuralAnalysisModel
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcStructuralAnalysisModel : IIfcSystem
	{
		IfcAnalysisModelTypeEnum @PredefinedType { get;  set; }
		IIfcAxis2Placement3D @OrientationOf2DPlane { get;  set; }
		IItemSet<IIfcStructuralLoadGroup> @LoadedBy { get; }
		IItemSet<IIfcStructuralResultGroup> @HasResults { get; }
	
	}
}

namespace Xbim.Ifc2x3.StructuralAnalysisDomain
{
	[ExpressType("IfcStructuralAnalysisModel", 230)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcStructuralAnalysisModel : IfcSystem, IInstantiableEntity, IIfcStructuralAnalysisModel, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<@IfcStructuralAnalysisModel>
	{
		#region IIfcStructuralAnalysisModel explicit implementation
		IfcAnalysisModelTypeEnum IIfcStructuralAnalysisModel.PredefinedType { 
 
			get { return @PredefinedType; } 
			set { PredefinedType = value;}
		}	
		IIfcAxis2Placement3D IIfcStructuralAnalysisModel.OrientationOf2DPlane { 
 
 
			get { return @OrientationOf2DPlane; } 
			set { OrientationOf2DPlane = value as IfcAxis2Placement3D;}
		}	
		IItemSet<IIfcStructuralLoadGroup> IIfcStructuralAnalysisModel.LoadedBy { 
			get { return new Common.Collections.ProxyItemSet<IfcStructuralLoadGroup, IIfcStructuralLoadGroup>( @LoadedBy); } 
		}	
		IItemSet<IIfcStructuralResultGroup> IIfcStructuralAnalysisModel.HasResults { 
			get { return new Common.Collections.ProxyItemSet<IfcStructuralResultGroup, IIfcStructuralResultGroup>( @HasResults); } 
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcStructuralAnalysisModel(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_loadedBy = new OptionalItemSet<IfcStructuralLoadGroup>( this, 0,  8);
			_hasResults = new OptionalItemSet<IfcStructuralResultGroup>( this, 0,  9);
		}

		#region Explicit attribute fields
		private IfcAnalysisModelTypeEnum _predefinedType;
		private IfcAxis2Placement3D _orientationOf2DPlane;
		private readonly OptionalItemSet<IfcStructuralLoadGroup> _loadedBy;
		private readonly OptionalItemSet<IfcStructuralResultGroup> _hasResults;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, -1, -1, 13)]
		public IfcAnalysisModelTypeEnum @PredefinedType 
		{ 
			get 
			{
				if(_activated) return _predefinedType;
				Activate();
				return _predefinedType;
			} 
			set
			{
				SetValue( v =>  _predefinedType = v, _predefinedType, value,  "PredefinedType", 6);
			} 
		}	
		[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 14)]
		public IfcAxis2Placement3D @OrientationOf2DPlane 
		{ 
			get 
			{
				if(_activated) return _orientationOf2DPlane;
				Activate();
				return _orientationOf2DPlane;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _orientationOf2DPlane = v, _orientationOf2DPlane, value,  "OrientationOf2DPlane", 7);
			} 
		}	
		[IndexedProperty]
		[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, 1, -1, 15)]
		public IOptionalItemSet<IfcStructuralLoadGroup> @LoadedBy 
		{ 
			get 
			{
				if(_activated) return _loadedBy;
				Activate();
				return _loadedBy;
			} 
		}	
		[IndexedProperty]
		[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, 1, -1, 16)]
		public IOptionalItemSet<IfcStructuralResultGroup> @HasResults 
		{ 
			get 
			{
				if(_activated) return _hasResults;
				Activate();
				return _hasResults;
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
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 5: 
                    _predefinedType = (IfcAnalysisModelTypeEnum) System.Enum.Parse(typeof (IfcAnalysisModelTypeEnum), value.EnumVal, true);
					return;
				case 6: 
					_orientationOf2DPlane = (IfcAxis2Placement3D)(value.EntityVal);
					return;
				case 7: 
					_loadedBy.InternalAdd((IfcStructuralLoadGroup)value.EntityVal);
					return;
				case 8: 
					_hasResults.InternalAdd((IfcStructuralResultGroup)value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcStructuralAnalysisModel other)
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
				if (@OrientationOf2DPlane != null)
					yield return @OrientationOf2DPlane;
				foreach(var entity in @LoadedBy)
					yield return entity;
				foreach(var entity in @HasResults)
					yield return entity;
			}
		}
		#endregion


		#region IContainsIndexedReferences
        IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences 
		{ 
			get
			{
				foreach(var entity in @LoadedBy)
					yield return entity;
				foreach(var entity in @HasResults)
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