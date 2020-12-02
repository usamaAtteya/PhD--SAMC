using System;
using log4net;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Xbim.Common.Enumerations;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.Ifc4.SharedBldgElements
{
	public partial class IfcSlabStandardCase : IExpressValidatable
	{
		public enum IfcSlabStandardCaseClause
		{
			HasMaterialLayerSetusage,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcSlabStandardCaseClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcSlabStandardCaseClause.HasMaterialLayerSetusage:
						retVal = Functions.SIZEOF(Functions.USEDIN(this, "IFC4.IFCRELASSOCIATES.RELATEDOBJECTS").Where(temp => (Functions.TYPEOF(temp).Contains("IFC4.IFCRELASSOCIATESMATERIAL")) && (Functions.TYPEOF(temp.AsIfcRelAssociatesMaterial().RelatingMaterial).Contains("IFC4.IFCMATERIALLAYERSETUSAGE")))) == 1;
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger("Xbim.Ifc4.SharedBldgElements.IfcSlabStandardCase");
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcSlabStandardCase.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public override IEnumerable<ValidationResult> Validate()
		{
			foreach (var value in base.Validate())
			{
				yield return value;
			}
			if (!ValidateClause(IfcSlabStandardCaseClause.HasMaterialLayerSetusage))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcSlabStandardCase.HasMaterialLayerSetusage", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
