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
namespace Xbim.Ifc4.ProductExtension
{
	public partial class IfcRelContainedInSpatialStructure : IExpressValidatable
	{
		public enum IfcRelContainedInSpatialStructureClause
		{
			WR31,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcRelContainedInSpatialStructureClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcRelContainedInSpatialStructureClause.WR31:
						retVal = Functions.SIZEOF(RelatedElements.Where(temp => Functions.TYPEOF(temp).Contains("IFC4.IFCSPATIALSTRUCTUREELEMENT"))) == 0;
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger("Xbim.Ifc4.ProductExtension.IfcRelContainedInSpatialStructure");
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcRelContainedInSpatialStructure.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public virtual IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(IfcRelContainedInSpatialStructureClause.WR31))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcRelContainedInSpatialStructure.WR31", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
