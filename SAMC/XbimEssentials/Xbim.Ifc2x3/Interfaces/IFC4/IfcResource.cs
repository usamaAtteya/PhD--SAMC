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
namespace Xbim.Ifc2x3.Kernel
{
	public partial class @IfcResource : IIfcResource
	{

		private  Ifc4.MeasureResource.IfcIdentifier? _identification;


		[CrossSchemaAttribute(typeof(IIfcResource), 6)]
		Ifc4.MeasureResource.IfcIdentifier? IIfcResource.Identification 
		{ 
			get
			{
				return _identification;
			} 
			set
			{
				SetValue(v => _identification = v, _identification, value, "Identification", -6);
				
			}
		}

		private  Ifc4.MeasureResource.IfcText? _longDescription;


		[CrossSchemaAttribute(typeof(IIfcResource), 7)]
		Ifc4.MeasureResource.IfcText? IIfcResource.LongDescription 
		{ 
			get
			{
				return _longDescription;
			} 
			set
			{
				SetValue(v => _longDescription = v, _longDescription, value, "LongDescription", -7);
				
			}
		}
		IEnumerable<IIfcRelAssignsToResource> IIfcResource.ResourceOf 
		{ 
			get
			{
				return Model.Instances.Where<IIfcRelAssignsToResource>(e => (e.RelatingResource as IfcResource) == this, "RelatingResource", this);
			} 
		}
	//## Custom code
	//##
	}
}