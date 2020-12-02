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
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.ProcessExtension;
//## Custom using statements
//##

namespace Xbim.Ifc2x3.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcProcedure
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcProcedure : IIfcProcess
	{
		IfcIdentifier @ProcedureID { get;  set; }
		IfcProcedureTypeEnum @ProcedureType { get;  set; }
		IfcLabel? @UserDefinedProcedureType { get;  set; }
	
	}
}

namespace Xbim.Ifc2x3.ProcessExtension
{
	[ExpressType("IfcProcedure", 294)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcProcedure : IfcProcess, IInstantiableEntity, IIfcProcedure, IContainsEntityReferences, IEquatable<@IfcProcedure>
	{
		#region IIfcProcedure explicit implementation
		IfcIdentifier IIfcProcedure.ProcedureID { 
 
			get { return @ProcedureID; } 
			set { ProcedureID = value;}
		}	
		IfcProcedureTypeEnum IIfcProcedure.ProcedureType { 
 
			get { return @ProcedureType; } 
			set { ProcedureType = value;}
		}	
		IfcLabel? IIfcProcedure.UserDefinedProcedureType { 
 
			get { return @UserDefinedProcedureType; } 
			set { UserDefinedProcedureType = value;}
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcProcedure(IModel model, int label, bool activated) : base(model, label, activated)  
		{
		}

		#region Explicit attribute fields
		private IfcIdentifier _procedureID;
		private IfcProcedureTypeEnum _procedureType;
		private IfcLabel? _userDefinedProcedureType;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 14)]
		public IfcIdentifier @ProcedureID 
		{ 
			get 
			{
				if(_activated) return _procedureID;
				Activate();
				return _procedureID;
			} 
			set
			{
				SetValue( v =>  _procedureID = v, _procedureID, value,  "ProcedureID", 6);
			} 
		}	
		[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, -1, -1, 15)]
		public IfcProcedureTypeEnum @ProcedureType 
		{ 
			get 
			{
				if(_activated) return _procedureType;
				Activate();
				return _procedureType;
			} 
			set
			{
				SetValue( v =>  _procedureType = v, _procedureType, value,  "ProcedureType", 7);
			} 
		}	
		[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 16)]
		public IfcLabel? @UserDefinedProcedureType 
		{ 
			get 
			{
				if(_activated) return _userDefinedProcedureType;
				Activate();
				return _userDefinedProcedureType;
			} 
			set
			{
				SetValue( v =>  _userDefinedProcedureType = v, _userDefinedProcedureType, value,  "UserDefinedProcedureType", 8);
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
					_procedureID = value.StringVal;
					return;
				case 6: 
                    _procedureType = (IfcProcedureTypeEnum) System.Enum.Parse(typeof (IfcProcedureTypeEnum), value.EnumVal, true);
					return;
				case 7: 
					_userDefinedProcedureType = value.StringVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcProcedure other)
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
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}