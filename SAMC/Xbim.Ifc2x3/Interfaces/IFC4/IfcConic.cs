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
namespace Xbim.Ifc2x3.GeometryResource
{
	public partial class @IfcConic : IIfcConic
	{

		[CrossSchemaAttribute(typeof(IIfcConic), 1)]
		IIfcAxis2Placement IIfcConic.Position 
		{ 
			get
			{
				if (Position == null) return null;
				var ifcaxis2placement2d = Position as IfcAxis2Placement2D;
				if (ifcaxis2placement2d != null) 
					return ifcaxis2placement2d;
				var ifcaxis2placement3d = Position as IfcAxis2Placement3D;
				if (ifcaxis2placement3d != null) 
					return ifcaxis2placement3d;
				return null;
			} 
			set
			{
				if (value == null)
				{
					Position = null;
					return;
				}	
				var ifcaxis2placement2d = value as IfcAxis2Placement2D;
				if (ifcaxis2placement2d != null) 
				{
					Position = ifcaxis2placement2d;
					return;
				}
				var ifcaxis2placement3d = value as IfcAxis2Placement3D;
				if (ifcaxis2placement3d != null) 
				{
					Position = ifcaxis2placement3d;
					return;
				}
				
			}
		}
	//## Custom code
	//##
	}
}