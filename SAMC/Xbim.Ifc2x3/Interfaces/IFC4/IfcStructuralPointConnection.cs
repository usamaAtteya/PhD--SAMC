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
namespace Xbim.Ifc2x3.StructuralAnalysisDomain
{
	public partial class @IfcStructuralPointConnection : IIfcStructuralPointConnection
	{

		private  IIfcAxis2Placement3D _conditionCoordinateSystem;


		[CrossSchemaAttribute(typeof(IIfcStructuralPointConnection), 9)]
		IIfcAxis2Placement3D IIfcStructuralPointConnection.ConditionCoordinateSystem 
		{ 
			get
			{
				return _conditionCoordinateSystem;
			} 
			set
			{
				SetValue(v => _conditionCoordinateSystem = v, _conditionCoordinateSystem, value, "ConditionCoordinateSystem", -9);
				
			}
		}
	//## Custom code
	//##
	}
}