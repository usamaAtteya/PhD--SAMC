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
namespace Xbim.Ifc2x3.QuantityResource
{
	public partial class @IfcQuantityWeight : IIfcQuantityWeight
	{

		[CrossSchemaAttribute(typeof(IIfcQuantityWeight), 4)]
		Ifc4.MeasureResource.IfcMassMeasure IIfcQuantityWeight.WeightValue 
		{ 
			get
			{
				return new Ifc4.MeasureResource.IfcMassMeasure(WeightValue);
			} 
			set
			{
				WeightValue = new MeasureResource.IfcMassMeasure(value);
				
			}
		}

		private  Ifc4.MeasureResource.IfcLabel? _formula;


		[CrossSchemaAttribute(typeof(IIfcQuantityWeight), 5)]
		Ifc4.MeasureResource.IfcLabel? IIfcQuantityWeight.Formula 
		{ 
			get
			{
				return _formula;
			} 
			set
			{
				SetValue(v => _formula = v, _formula, value, "Formula", -5);
				
			}
		}
	//## Custom code
	//##
	}
}