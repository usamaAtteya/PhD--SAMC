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
namespace Xbim.Ifc2x3.PresentationDefinitionResource
{
	public partial class @IfcTextureCoordinate : IIfcTextureCoordinate
	{

		[CrossSchemaAttribute(typeof(IIfcTextureCoordinate), 1)]
		IItemSet<IIfcSurfaceTexture> IIfcTextureCoordinate.Maps 
		{ 
			get
			{
				//## Handle return of Maps for which no match was found
                return _ifcTextureCoordinate ?? (_ifcTextureCoordinate = new ItemSet<IIfcSurfaceTexture>(this, 0, -1));
				//##
			} 
		}
	//## Custom code
	    private IItemSet<IIfcSurfaceTexture> _ifcTextureCoordinate;
	    //##
	}
}