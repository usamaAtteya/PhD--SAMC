// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.TimeSeriesResource;
using Xbim.Ifc2x3.MaterialResource;
using Xbim.Ifc2x3.MeasureResource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.SharedBldgServiceElements;
//## Custom using statements
//##

namespace Xbim.Ifc2x3.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcFluidFlowProperties
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcFluidFlowProperties : IIfcPropertySetDefinition
	{
		IfcPropertySourceEnum @PropertySource { get;  set; }
		IIfcTimeSeries @FlowConditionTimeSeries { get;  set; }
		IIfcTimeSeries @VelocityTimeSeries { get;  set; }
		IIfcTimeSeries @FlowrateTimeSeries { get;  set; }
		IIfcMaterial @Fluid { get;  set; }
		IIfcTimeSeries @PressureTimeSeries { get;  set; }
		IfcLabel? @UserDefinedPropertySource { get;  set; }
		IfcThermodynamicTemperatureMeasure? @TemperatureSingleValue { get;  set; }
		IfcThermodynamicTemperatureMeasure? @WetBulbTemperatureSingleValue { get;  set; }
		IIfcTimeSeries @WetBulbTemperatureTimeSeries { get;  set; }
		IIfcTimeSeries @TemperatureTimeSeries { get;  set; }
		IIfcDerivedMeasureValue @FlowrateSingleValue { get;  set; }
		IfcPositiveRatioMeasure? @FlowConditionSingleValue { get;  set; }
		IfcLinearVelocityMeasure? @VelocitySingleValue { get;  set; }
		IfcPressureMeasure? @PressureSingleValue { get;  set; }
	
	}
}

namespace Xbim.Ifc2x3.SharedBldgServiceElements
{
	[ExpressType("IfcFluidFlowProperties", 466)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcFluidFlowProperties : IfcPropertySetDefinition, IInstantiableEntity, IIfcFluidFlowProperties, IContainsEntityReferences, IEquatable<@IfcFluidFlowProperties>
	{
		#region IIfcFluidFlowProperties explicit implementation
		IfcPropertySourceEnum IIfcFluidFlowProperties.PropertySource { 
 
			get { return @PropertySource; } 
			set { PropertySource = value;}
		}	
		IIfcTimeSeries IIfcFluidFlowProperties.FlowConditionTimeSeries { 
 
 
			get { return @FlowConditionTimeSeries; } 
			set { FlowConditionTimeSeries = value as IfcTimeSeries;}
		}	
		IIfcTimeSeries IIfcFluidFlowProperties.VelocityTimeSeries { 
 
 
			get { return @VelocityTimeSeries; } 
			set { VelocityTimeSeries = value as IfcTimeSeries;}
		}	
		IIfcTimeSeries IIfcFluidFlowProperties.FlowrateTimeSeries { 
 
 
			get { return @FlowrateTimeSeries; } 
			set { FlowrateTimeSeries = value as IfcTimeSeries;}
		}	
		IIfcMaterial IIfcFluidFlowProperties.Fluid { 
 
 
			get { return @Fluid; } 
			set { Fluid = value as IfcMaterial;}
		}	
		IIfcTimeSeries IIfcFluidFlowProperties.PressureTimeSeries { 
 
 
			get { return @PressureTimeSeries; } 
			set { PressureTimeSeries = value as IfcTimeSeries;}
		}	
		IfcLabel? IIfcFluidFlowProperties.UserDefinedPropertySource { 
 
			get { return @UserDefinedPropertySource; } 
			set { UserDefinedPropertySource = value;}
		}	
		IfcThermodynamicTemperatureMeasure? IIfcFluidFlowProperties.TemperatureSingleValue { 
 
			get { return @TemperatureSingleValue; } 
			set { TemperatureSingleValue = value;}
		}	
		IfcThermodynamicTemperatureMeasure? IIfcFluidFlowProperties.WetBulbTemperatureSingleValue { 
 
			get { return @WetBulbTemperatureSingleValue; } 
			set { WetBulbTemperatureSingleValue = value;}
		}	
		IIfcTimeSeries IIfcFluidFlowProperties.WetBulbTemperatureTimeSeries { 
 
 
			get { return @WetBulbTemperatureTimeSeries; } 
			set { WetBulbTemperatureTimeSeries = value as IfcTimeSeries;}
		}	
		IIfcTimeSeries IIfcFluidFlowProperties.TemperatureTimeSeries { 
 
 
			get { return @TemperatureTimeSeries; } 
			set { TemperatureTimeSeries = value as IfcTimeSeries;}
		}	
		IIfcDerivedMeasureValue IIfcFluidFlowProperties.FlowrateSingleValue { 
 
 
			get { return @FlowrateSingleValue; } 
			set { FlowrateSingleValue = value as IfcDerivedMeasureValue;}
		}	
		IfcPositiveRatioMeasure? IIfcFluidFlowProperties.FlowConditionSingleValue { 
 
			get { return @FlowConditionSingleValue; } 
			set { FlowConditionSingleValue = value;}
		}	
		IfcLinearVelocityMeasure? IIfcFluidFlowProperties.VelocitySingleValue { 
 
			get { return @VelocitySingleValue; } 
			set { VelocitySingleValue = value;}
		}	
		IfcPressureMeasure? IIfcFluidFlowProperties.PressureSingleValue { 
 
			get { return @PressureSingleValue; } 
			set { PressureSingleValue = value;}
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcFluidFlowProperties(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcPropertySourceEnum _propertySource;
		private IfcTimeSeries _flowConditionTimeSeries;
		private IfcTimeSeries _velocityTimeSeries;
		private IfcTimeSeries _flowrateTimeSeries;
		private IfcMaterial _fluid;
		private IfcTimeSeries _pressureTimeSeries;
		private IfcLabel? _userDefinedPropertySource;
		private IfcThermodynamicTemperatureMeasure? _temperatureSingleValue;
		private IfcThermodynamicTemperatureMeasure? _wetBulbTemperatureSingleValue;
		private IfcTimeSeries _wetBulbTemperatureTimeSeries;
		private IfcTimeSeries _temperatureTimeSeries;
		private IfcDerivedMeasureValue _flowrateSingleValue;
		private IfcPositiveRatioMeasure? _flowConditionSingleValue;
		private IfcLinearVelocityMeasure? _velocitySingleValue;
		private IfcPressureMeasure? _pressureSingleValue;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, -1, -1, 8)]
		public IfcPropertySourceEnum @PropertySource 
		{ 
			get 
			{
				if(_activated) return _propertySource;
				Activate();
				return _propertySource;
			} 
			set
			{
				SetValue( v =>  _propertySource = v, _propertySource, value,  "PropertySource", 5);
			} 
		}	
		[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 9)]
		public IfcTimeSeries @FlowConditionTimeSeries 
		{ 
			get 
			{
				if(_activated) return _flowConditionTimeSeries;
				Activate();
				return _flowConditionTimeSeries;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _flowConditionTimeSeries = v, _flowConditionTimeSeries, value,  "FlowConditionTimeSeries", 6);
			} 
		}	
		[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 10)]
		public IfcTimeSeries @VelocityTimeSeries 
		{ 
			get 
			{
				if(_activated) return _velocityTimeSeries;
				Activate();
				return _velocityTimeSeries;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _velocityTimeSeries = v, _velocityTimeSeries, value,  "VelocityTimeSeries", 7);
			} 
		}	
		[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 11)]
		public IfcTimeSeries @FlowrateTimeSeries 
		{ 
			get 
			{
				if(_activated) return _flowrateTimeSeries;
				Activate();
				return _flowrateTimeSeries;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _flowrateTimeSeries = v, _flowrateTimeSeries, value,  "FlowrateTimeSeries", 8);
			} 
		}	
		[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 12)]
		public IfcMaterial @Fluid 
		{ 
			get 
			{
				if(_activated) return _fluid;
				Activate();
				return _fluid;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _fluid = v, _fluid, value,  "Fluid", 9);
			} 
		}	
		[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 13)]
		public IfcTimeSeries @PressureTimeSeries 
		{ 
			get 
			{
				if(_activated) return _pressureTimeSeries;
				Activate();
				return _pressureTimeSeries;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _pressureTimeSeries = v, _pressureTimeSeries, value,  "PressureTimeSeries", 10);
			} 
		}	
		[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 14)]
		public IfcLabel? @UserDefinedPropertySource 
		{ 
			get 
			{
				if(_activated) return _userDefinedPropertySource;
				Activate();
				return _userDefinedPropertySource;
			} 
			set
			{
				SetValue( v =>  _userDefinedPropertySource = v, _userDefinedPropertySource, value,  "UserDefinedPropertySource", 11);
			} 
		}	
		[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 15)]
		public IfcThermodynamicTemperatureMeasure? @TemperatureSingleValue 
		{ 
			get 
			{
				if(_activated) return _temperatureSingleValue;
				Activate();
				return _temperatureSingleValue;
			} 
			set
			{
				SetValue( v =>  _temperatureSingleValue = v, _temperatureSingleValue, value,  "TemperatureSingleValue", 12);
			} 
		}	
		[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 16)]
		public IfcThermodynamicTemperatureMeasure? @WetBulbTemperatureSingleValue 
		{ 
			get 
			{
				if(_activated) return _wetBulbTemperatureSingleValue;
				Activate();
				return _wetBulbTemperatureSingleValue;
			} 
			set
			{
				SetValue( v =>  _wetBulbTemperatureSingleValue = v, _wetBulbTemperatureSingleValue, value,  "WetBulbTemperatureSingleValue", 13);
			} 
		}	
		[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 17)]
		public IfcTimeSeries @WetBulbTemperatureTimeSeries 
		{ 
			get 
			{
				if(_activated) return _wetBulbTemperatureTimeSeries;
				Activate();
				return _wetBulbTemperatureTimeSeries;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _wetBulbTemperatureTimeSeries = v, _wetBulbTemperatureTimeSeries, value,  "WetBulbTemperatureTimeSeries", 14);
			} 
		}	
		[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 18)]
		public IfcTimeSeries @TemperatureTimeSeries 
		{ 
			get 
			{
				if(_activated) return _temperatureTimeSeries;
				Activate();
				return _temperatureTimeSeries;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _temperatureTimeSeries = v, _temperatureTimeSeries, value,  "TemperatureTimeSeries", 15);
			} 
		}	
		[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 19)]
		public IfcDerivedMeasureValue @FlowrateSingleValue 
		{ 
			get 
			{
				if(_activated) return _flowrateSingleValue;
				Activate();
				return _flowrateSingleValue;
			} 
			set
			{
				SetValue( v =>  _flowrateSingleValue = v, _flowrateSingleValue, value,  "FlowrateSingleValue", 16);
			} 
		}	
		[EntityAttribute(17, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 20)]
		public IfcPositiveRatioMeasure? @FlowConditionSingleValue 
		{ 
			get 
			{
				if(_activated) return _flowConditionSingleValue;
				Activate();
				return _flowConditionSingleValue;
			} 
			set
			{
				SetValue( v =>  _flowConditionSingleValue = v, _flowConditionSingleValue, value,  "FlowConditionSingleValue", 17);
			} 
		}	
		[EntityAttribute(18, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 21)]
		public IfcLinearVelocityMeasure? @VelocitySingleValue 
		{ 
			get 
			{
				if(_activated) return _velocitySingleValue;
				Activate();
				return _velocitySingleValue;
			} 
			set
			{
				SetValue( v =>  _velocitySingleValue = v, _velocitySingleValue, value,  "VelocitySingleValue", 18);
			} 
		}	
		[EntityAttribute(19, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 22)]
		public IfcPressureMeasure? @PressureSingleValue 
		{ 
			get 
			{
				if(_activated) return _pressureSingleValue;
				Activate();
				return _pressureSingleValue;
			} 
			set
			{
				SetValue( v =>  _pressureSingleValue = v, _pressureSingleValue, value,  "PressureSingleValue", 19);
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
                    _propertySource = (IfcPropertySourceEnum) System.Enum.Parse(typeof (IfcPropertySourceEnum), value.EnumVal, true);
					return;
				case 5: 
					_flowConditionTimeSeries = (IfcTimeSeries)(value.EntityVal);
					return;
				case 6: 
					_velocityTimeSeries = (IfcTimeSeries)(value.EntityVal);
					return;
				case 7: 
					_flowrateTimeSeries = (IfcTimeSeries)(value.EntityVal);
					return;
				case 8: 
					_fluid = (IfcMaterial)(value.EntityVal);
					return;
				case 9: 
					_pressureTimeSeries = (IfcTimeSeries)(value.EntityVal);
					return;
				case 10: 
					_userDefinedPropertySource = value.StringVal;
					return;
				case 11: 
					_temperatureSingleValue = value.RealVal;
					return;
				case 12: 
					_wetBulbTemperatureSingleValue = value.RealVal;
					return;
				case 13: 
					_wetBulbTemperatureTimeSeries = (IfcTimeSeries)(value.EntityVal);
					return;
				case 14: 
					_temperatureTimeSeries = (IfcTimeSeries)(value.EntityVal);
					return;
				case 15: 
					_flowrateSingleValue = (IfcDerivedMeasureValue)(value.EntityVal);
					return;
				case 16: 
					_flowConditionSingleValue = value.RealVal;
					return;
				case 17: 
					_velocitySingleValue = value.RealVal;
					return;
				case 18: 
					_pressureSingleValue = value.RealVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcFluidFlowProperties other)
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
				if (@FlowConditionTimeSeries != null)
					yield return @FlowConditionTimeSeries;
				if (@VelocityTimeSeries != null)
					yield return @VelocityTimeSeries;
				if (@FlowrateTimeSeries != null)
					yield return @FlowrateTimeSeries;
				if (@Fluid != null)
					yield return @Fluid;
				if (@PressureTimeSeries != null)
					yield return @PressureTimeSeries;
				if (@WetBulbTemperatureTimeSeries != null)
					yield return @WetBulbTemperatureTimeSeries;
				if (@TemperatureTimeSeries != null)
					yield return @TemperatureTimeSeries;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}