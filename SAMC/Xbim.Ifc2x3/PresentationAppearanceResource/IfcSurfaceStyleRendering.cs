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
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.PresentationAppearanceResource;
//## Custom using statements
//##

namespace Xbim.Ifc2x3.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcSurfaceStyleRendering
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcSurfaceStyleRendering : IIfcSurfaceStyleShading
	{
		IfcNormalisedRatioMeasure? @Transparency { get;  set; }
		IIfcColourOrFactor @DiffuseColour { get;  set; }
		IIfcColourOrFactor @TransmissionColour { get;  set; }
		IIfcColourOrFactor @DiffuseTransmissionColour { get;  set; }
		IIfcColourOrFactor @ReflectionColour { get;  set; }
		IIfcColourOrFactor @SpecularColour { get;  set; }
		IIfcSpecularHighlightSelect @SpecularHighlight { get;  set; }
		IfcReflectanceMethodEnum @ReflectanceMethod { get;  set; }
	
	}
}

namespace Xbim.Ifc2x3.PresentationAppearanceResource
{
	[ExpressType("IfcSurfaceStyleRendering", 317)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcSurfaceStyleRendering : IfcSurfaceStyleShading, IInstantiableEntity, IIfcSurfaceStyleRendering, IContainsEntityReferences, IEquatable<@IfcSurfaceStyleRendering>
	{
		#region IIfcSurfaceStyleRendering explicit implementation
		IfcNormalisedRatioMeasure? IIfcSurfaceStyleRendering.Transparency { 
 
			get { return @Transparency; } 
			set { Transparency = value;}
		}	
		IIfcColourOrFactor IIfcSurfaceStyleRendering.DiffuseColour { 
 
 
			get { return @DiffuseColour; } 
			set { DiffuseColour = value as IfcColourOrFactor;}
		}	
		IIfcColourOrFactor IIfcSurfaceStyleRendering.TransmissionColour { 
 
 
			get { return @TransmissionColour; } 
			set { TransmissionColour = value as IfcColourOrFactor;}
		}	
		IIfcColourOrFactor IIfcSurfaceStyleRendering.DiffuseTransmissionColour { 
 
 
			get { return @DiffuseTransmissionColour; } 
			set { DiffuseTransmissionColour = value as IfcColourOrFactor;}
		}	
		IIfcColourOrFactor IIfcSurfaceStyleRendering.ReflectionColour { 
 
 
			get { return @ReflectionColour; } 
			set { ReflectionColour = value as IfcColourOrFactor;}
		}	
		IIfcColourOrFactor IIfcSurfaceStyleRendering.SpecularColour { 
 
 
			get { return @SpecularColour; } 
			set { SpecularColour = value as IfcColourOrFactor;}
		}	
		IIfcSpecularHighlightSelect IIfcSurfaceStyleRendering.SpecularHighlight { 
 
 
			get { return @SpecularHighlight; } 
			set { SpecularHighlight = value as IfcSpecularHighlightSelect;}
		}	
		IfcReflectanceMethodEnum IIfcSurfaceStyleRendering.ReflectanceMethod { 
 
			get { return @ReflectanceMethod; } 
			set { ReflectanceMethod = value;}
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcSurfaceStyleRendering(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcNormalisedRatioMeasure? _transparency;
		private IfcColourOrFactor _diffuseColour;
		private IfcColourOrFactor _transmissionColour;
		private IfcColourOrFactor _diffuseTransmissionColour;
		private IfcColourOrFactor _reflectionColour;
		private IfcColourOrFactor _specularColour;
		private IfcSpecularHighlightSelect _specularHighlight;
		private IfcReflectanceMethodEnum _reflectanceMethod;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 2)]
		public IfcNormalisedRatioMeasure? @Transparency 
		{ 
			get 
			{
				if(_activated) return _transparency;
				Activate();
				return _transparency;
			} 
			set
			{
				SetValue( v =>  _transparency = v, _transparency, value,  "Transparency", 2);
			} 
		}	
		[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 3)]
		public IfcColourOrFactor @DiffuseColour 
		{ 
			get 
			{
				if(_activated) return _diffuseColour;
				Activate();
				return _diffuseColour;
			} 
			set
			{
				var entity = value as IPersistEntity;
				if (entity != null && !(ReferenceEquals(Model, entity.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _diffuseColour = v, _diffuseColour, value,  "DiffuseColour", 3);
			} 
		}	
		[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 4)]
		public IfcColourOrFactor @TransmissionColour 
		{ 
			get 
			{
				if(_activated) return _transmissionColour;
				Activate();
				return _transmissionColour;
			} 
			set
			{
				var entity = value as IPersistEntity;
				if (entity != null && !(ReferenceEquals(Model, entity.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _transmissionColour = v, _transmissionColour, value,  "TransmissionColour", 4);
			} 
		}	
		[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 5)]
		public IfcColourOrFactor @DiffuseTransmissionColour 
		{ 
			get 
			{
				if(_activated) return _diffuseTransmissionColour;
				Activate();
				return _diffuseTransmissionColour;
			} 
			set
			{
				var entity = value as IPersistEntity;
				if (entity != null && !(ReferenceEquals(Model, entity.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _diffuseTransmissionColour = v, _diffuseTransmissionColour, value,  "DiffuseTransmissionColour", 5);
			} 
		}	
		[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 6)]
		public IfcColourOrFactor @ReflectionColour 
		{ 
			get 
			{
				if(_activated) return _reflectionColour;
				Activate();
				return _reflectionColour;
			} 
			set
			{
				var entity = value as IPersistEntity;
				if (entity != null && !(ReferenceEquals(Model, entity.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _reflectionColour = v, _reflectionColour, value,  "ReflectionColour", 6);
			} 
		}	
		[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 7)]
		public IfcColourOrFactor @SpecularColour 
		{ 
			get 
			{
				if(_activated) return _specularColour;
				Activate();
				return _specularColour;
			} 
			set
			{
				var entity = value as IPersistEntity;
				if (entity != null && !(ReferenceEquals(Model, entity.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _specularColour = v, _specularColour, value,  "SpecularColour", 7);
			} 
		}	
		[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 8)]
		public IfcSpecularHighlightSelect @SpecularHighlight 
		{ 
			get 
			{
				if(_activated) return _specularHighlight;
				Activate();
				return _specularHighlight;
			} 
			set
			{
				SetValue( v =>  _specularHighlight = v, _specularHighlight, value,  "SpecularHighlight", 8);
			} 
		}	
		[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, -1, -1, 9)]
		public IfcReflectanceMethodEnum @ReflectanceMethod 
		{ 
			get 
			{
				if(_activated) return _reflectanceMethod;
				Activate();
				return _reflectanceMethod;
			} 
			set
			{
				SetValue( v =>  _reflectanceMethod = v, _reflectanceMethod, value,  "ReflectanceMethod", 9);
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 1: 
					_transparency = value.RealVal;
					return;
				case 2: 
					_diffuseColour = (IfcColourOrFactor)(value.EntityVal);
					return;
				case 3: 
					_transmissionColour = (IfcColourOrFactor)(value.EntityVal);
					return;
				case 4: 
					_diffuseTransmissionColour = (IfcColourOrFactor)(value.EntityVal);
					return;
				case 5: 
					_reflectionColour = (IfcColourOrFactor)(value.EntityVal);
					return;
				case 6: 
					_specularColour = (IfcColourOrFactor)(value.EntityVal);
					return;
				case 7: 
					_specularHighlight = (IfcSpecularHighlightSelect)(value.EntityVal);
					return;
				case 8: 
                    _reflectanceMethod = (IfcReflectanceMethodEnum) System.Enum.Parse(typeof (IfcReflectanceMethodEnum), value.EnumVal, true);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcSurfaceStyleRendering other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@SurfaceColour != null)
					yield return @SurfaceColour;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}