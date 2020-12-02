// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc4.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

// ReSharper disable once CheckNamespace
namespace Xbim.Ifc2x3.ElectricalDomain
{
	public partial class @IfcMotorConnectionType : IIfcMotorConnectionType
	{

		[CrossSchemaAttribute(typeof(IIfcMotorConnectionType), 10)]
		Ifc4.Interfaces.IfcMotorConnectionTypeEnum IIfcMotorConnectionType.PredefinedType 
		{ 
			get
			{
				//## Custom code to handle enumeration of PredefinedType
				//##
				switch (PredefinedType)
				{
					case IfcMotorConnectionTypeEnum.BELTDRIVE:
						return Ifc4.Interfaces.IfcMotorConnectionTypeEnum.BELTDRIVE;
					case IfcMotorConnectionTypeEnum.COUPLING:
						return Ifc4.Interfaces.IfcMotorConnectionTypeEnum.COUPLING;
					case IfcMotorConnectionTypeEnum.DIRECTDRIVE:
						return Ifc4.Interfaces.IfcMotorConnectionTypeEnum.DIRECTDRIVE;
					case IfcMotorConnectionTypeEnum.USERDEFINED:
						//## Optional custom handling of PredefinedType == .USERDEFINED. 
						//##
						return Ifc4.Interfaces.IfcMotorConnectionTypeEnum.USERDEFINED;
					case IfcMotorConnectionTypeEnum.NOTDEFINED:
						return Ifc4.Interfaces.IfcMotorConnectionTypeEnum.NOTDEFINED;
					
					default:
						throw new System.ArgumentOutOfRangeException();
				}
			} 
			set
			{
				//## Custom code to handle setting of enumeration of PredefinedType
				//##
				switch (value)
				{
					case Ifc4.Interfaces.IfcMotorConnectionTypeEnum.BELTDRIVE:
						PredefinedType = IfcMotorConnectionTypeEnum.BELTDRIVE;
						return;
					case Ifc4.Interfaces.IfcMotorConnectionTypeEnum.COUPLING:
						PredefinedType = IfcMotorConnectionTypeEnum.COUPLING;
						return;
					case Ifc4.Interfaces.IfcMotorConnectionTypeEnum.DIRECTDRIVE:
						PredefinedType = IfcMotorConnectionTypeEnum.DIRECTDRIVE;
						return;
					case Ifc4.Interfaces.IfcMotorConnectionTypeEnum.USERDEFINED:
						PredefinedType = IfcMotorConnectionTypeEnum.USERDEFINED;
						return;
					case Ifc4.Interfaces.IfcMotorConnectionTypeEnum.NOTDEFINED:
						PredefinedType = IfcMotorConnectionTypeEnum.NOTDEFINED;
						return;
					default:
						throw new System.ArgumentOutOfRangeException();
				}
				
			}
		}
	//## Custom code
	//##
	}
}