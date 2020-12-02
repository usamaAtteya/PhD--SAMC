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
namespace Xbim.Ifc2x3.SharedBldgElements
{
	public partial class @IfcRailing : IIfcRailing
	{

		[CrossSchemaAttribute(typeof(IIfcRailing), 9)]
		Ifc4.Interfaces.IfcRailingTypeEnum? IIfcRailing.PredefinedType 
		{ 
			get
			{
				//## Custom code to handle enumeration of PredefinedType
				//##
				switch (PredefinedType)
				{
					case IfcRailingTypeEnum.HANDRAIL:
						return Ifc4.Interfaces.IfcRailingTypeEnum.HANDRAIL;
					case IfcRailingTypeEnum.GUARDRAIL:
						return Ifc4.Interfaces.IfcRailingTypeEnum.GUARDRAIL;
					case IfcRailingTypeEnum.BALUSTRADE:
						return Ifc4.Interfaces.IfcRailingTypeEnum.BALUSTRADE;
					case IfcRailingTypeEnum.USERDEFINED:
						//## Optional custom handling of PredefinedType == .USERDEFINED. 
						//##
						return Ifc4.Interfaces.IfcRailingTypeEnum.USERDEFINED;
					case IfcRailingTypeEnum.NOTDEFINED:
						return Ifc4.Interfaces.IfcRailingTypeEnum.NOTDEFINED;
					case null: 
						return null;
					
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
					case Ifc4.Interfaces.IfcRailingTypeEnum.HANDRAIL:
						PredefinedType = IfcRailingTypeEnum.HANDRAIL;
						return;
					case Ifc4.Interfaces.IfcRailingTypeEnum.GUARDRAIL:
						PredefinedType = IfcRailingTypeEnum.GUARDRAIL;
						return;
					case Ifc4.Interfaces.IfcRailingTypeEnum.BALUSTRADE:
						PredefinedType = IfcRailingTypeEnum.BALUSTRADE;
						return;
					case Ifc4.Interfaces.IfcRailingTypeEnum.USERDEFINED:
						PredefinedType = IfcRailingTypeEnum.USERDEFINED;
						return;
					case Ifc4.Interfaces.IfcRailingTypeEnum.NOTDEFINED:
						PredefinedType = IfcRailingTypeEnum.NOTDEFINED;
						return;
					
					case null:
						PredefinedType = null;
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