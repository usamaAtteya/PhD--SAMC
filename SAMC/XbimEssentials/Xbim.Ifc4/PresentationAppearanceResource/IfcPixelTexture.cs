// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc4.MeasureResource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;
//## Custom using statements
//##

namespace Xbim.Ifc4.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcPixelTexture
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcPixelTexture : IIfcSurfaceTexture
	{
		IfcInteger @Width { get;  set; }
		IfcInteger @Height { get;  set; }
		IfcInteger @ColourComponents { get;  set; }
		IItemSet<IfcBinary> @Pixel { get; }
	
	}
}

namespace Xbim.Ifc4.PresentationAppearanceResource
{
	[ExpressType("IfcPixelTexture", 728)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcPixelTexture : IfcSurfaceTexture, IInstantiableEntity, IIfcPixelTexture, IContainsEntityReferences, IEquatable<@IfcPixelTexture>
	{
		#region IIfcPixelTexture explicit implementation
		IfcInteger IIfcPixelTexture.Width { 
 
			get { return @Width; } 
			set { Width = value;}
		}	
		IfcInteger IIfcPixelTexture.Height { 
 
			get { return @Height; } 
			set { Height = value;}
		}	
		IfcInteger IIfcPixelTexture.ColourComponents { 
 
			get { return @ColourComponents; } 
			set { ColourComponents = value;}
		}	
		IItemSet<IfcBinary> IIfcPixelTexture.Pixel { 
			get { return @Pixel; } 
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcPixelTexture(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_pixel = new ItemSet<IfcBinary>( this, 0,  9);
		}

		#region Explicit attribute fields
		private IfcInteger _width;
		private IfcInteger _height;
		private IfcInteger _colourComponents;
		private readonly ItemSet<IfcBinary> _pixel;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 8)]
		public IfcInteger @Width 
		{ 
			get 
			{
				if(_activated) return _width;
				Activate();
				return _width;
			} 
			set
			{
				SetValue( v =>  _width = v, _width, value,  "Width", 6);
			} 
		}	
		[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 9)]
		public IfcInteger @Height 
		{ 
			get 
			{
				if(_activated) return _height;
				Activate();
				return _height;
			} 
			set
			{
				SetValue( v =>  _height = v, _height, value,  "Height", 7);
			} 
		}	
		[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 10)]
		public IfcInteger @ColourComponents 
		{ 
			get 
			{
				if(_activated) return _colourComponents;
				Activate();
				return _colourComponents;
			} 
			set
			{
				SetValue( v =>  _colourComponents = v, _colourComponents, value,  "ColourComponents", 8);
			} 
		}	
		[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, 1, -1, 11)]
		public IItemSet<IfcBinary> @Pixel 
		{ 
			get 
			{
				if(_activated) return _pixel;
				Activate();
				return _pixel;
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
					_width = value.IntegerVal;
					return;
				case 6: 
					_height = value.IntegerVal;
					return;
				case 7: 
					_colourComponents = value.IntegerVal;
					return;
				case 8: 
					_pixel.InternalAdd(value.HexadecimalVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcPixelTexture other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@TextureTransform != null)
					yield return @TextureTransform;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}