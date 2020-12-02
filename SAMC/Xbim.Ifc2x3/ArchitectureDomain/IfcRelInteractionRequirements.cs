// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProductExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.ArchitectureDomain;
//## Custom using statements
//##

namespace Xbim.Ifc2x3.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcRelInteractionRequirements
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcRelInteractionRequirements : IIfcRelConnects
	{
		IfcCountMeasure? @DailyInteraction { get;  set; }
		IfcNormalisedRatioMeasure? @ImportanceRating { get;  set; }
		IIfcSpatialStructureElement @LocationOfInteraction { get;  set; }
		IIfcSpaceProgram @RelatedSpaceProgram { get;  set; }
		IIfcSpaceProgram @RelatingSpaceProgram { get;  set; }
	
	}
}

namespace Xbim.Ifc2x3.ArchitectureDomain
{
	[ExpressType("IfcRelInteractionRequirements", 708)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcRelInteractionRequirements : IfcRelConnects, IInstantiableEntity, IIfcRelInteractionRequirements, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<@IfcRelInteractionRequirements>
	{
		#region IIfcRelInteractionRequirements explicit implementation
		IfcCountMeasure? IIfcRelInteractionRequirements.DailyInteraction { 
 
			get { return @DailyInteraction; } 
			set { DailyInteraction = value;}
		}	
		IfcNormalisedRatioMeasure? IIfcRelInteractionRequirements.ImportanceRating { 
 
			get { return @ImportanceRating; } 
			set { ImportanceRating = value;}
		}	
		IIfcSpatialStructureElement IIfcRelInteractionRequirements.LocationOfInteraction { 
 
 
			get { return @LocationOfInteraction; } 
			set { LocationOfInteraction = value as IfcSpatialStructureElement;}
		}	
		IIfcSpaceProgram IIfcRelInteractionRequirements.RelatedSpaceProgram { 
 
 
			get { return @RelatedSpaceProgram; } 
			set { RelatedSpaceProgram = value as IfcSpaceProgram;}
		}	
		IIfcSpaceProgram IIfcRelInteractionRequirements.RelatingSpaceProgram { 
 
 
			get { return @RelatingSpaceProgram; } 
			set { RelatingSpaceProgram = value as IfcSpaceProgram;}
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcRelInteractionRequirements(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcCountMeasure? _dailyInteraction;
		private IfcNormalisedRatioMeasure? _importanceRating;
		private IfcSpatialStructureElement _locationOfInteraction;
		private IfcSpaceProgram _relatedSpaceProgram;
		private IfcSpaceProgram _relatingSpaceProgram;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 5)]
		public IfcCountMeasure? @DailyInteraction 
		{ 
			get 
			{
				if(_activated) return _dailyInteraction;
				Activate();
				return _dailyInteraction;
			} 
			set
			{
				SetValue( v =>  _dailyInteraction = v, _dailyInteraction, value,  "DailyInteraction", 5);
			} 
		}	
		[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 6)]
		public IfcNormalisedRatioMeasure? @ImportanceRating 
		{ 
			get 
			{
				if(_activated) return _importanceRating;
				Activate();
				return _importanceRating;
			} 
			set
			{
				SetValue( v =>  _importanceRating = v, _importanceRating, value,  "ImportanceRating", 6);
			} 
		}	
		[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 7)]
		public IfcSpatialStructureElement @LocationOfInteraction 
		{ 
			get 
			{
				if(_activated) return _locationOfInteraction;
				Activate();
				return _locationOfInteraction;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _locationOfInteraction = v, _locationOfInteraction, value,  "LocationOfInteraction", 7);
			} 
		}	
		[IndexedProperty]
		[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 8)]
		public IfcSpaceProgram @RelatedSpaceProgram 
		{ 
			get 
			{
				if(_activated) return _relatedSpaceProgram;
				Activate();
				return _relatedSpaceProgram;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _relatedSpaceProgram = v, _relatedSpaceProgram, value,  "RelatedSpaceProgram", 8);
			} 
		}	
		[IndexedProperty]
		[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 9)]
		public IfcSpaceProgram @RelatingSpaceProgram 
		{ 
			get 
			{
				if(_activated) return _relatingSpaceProgram;
				Activate();
				return _relatingSpaceProgram;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _relatingSpaceProgram = v, _relatingSpaceProgram, value,  "RelatingSpaceProgram", 9);
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
					_dailyInteraction = value.NumberVal;
					return;
				case 5: 
					_importanceRating = value.RealVal;
					return;
				case 6: 
					_locationOfInteraction = (IfcSpatialStructureElement)(value.EntityVal);
					return;
				case 7: 
					_relatedSpaceProgram = (IfcSpaceProgram)(value.EntityVal);
					return;
				case 8: 
					_relatingSpaceProgram = (IfcSpaceProgram)(value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcRelInteractionRequirements other)
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
				if (@LocationOfInteraction != null)
					yield return @LocationOfInteraction;
				if (@RelatedSpaceProgram != null)
					yield return @RelatedSpaceProgram;
				if (@RelatingSpaceProgram != null)
					yield return @RelatingSpaceProgram;
			}
		}
		#endregion


		#region IContainsIndexedReferences
        IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences 
		{ 
			get
			{
				if (@RelatedSpaceProgram != null)
					yield return @RelatedSpaceProgram;
				if (@RelatingSpaceProgram != null)
					yield return @RelatingSpaceProgram;
				
			} 
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}