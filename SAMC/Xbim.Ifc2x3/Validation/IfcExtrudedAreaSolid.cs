using System;
using log4net;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Xbim.Common.Enumerations;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.ProfileResource;
using Xbim.Ifc2x3.ProfilePropertyResource;
// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.Ifc2x3.GeometricModelResource
{
	public partial class IfcExtrudedAreaSolid : IExpressValidatable
	{
		public enum IfcExtrudedAreaSolidClause
		{
			WR31,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcExtrudedAreaSolidClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcExtrudedAreaSolidClause.WR31:
						retVal = Functions.IfcDotProduct(Functions.IfcDirection(0, 0, 1), this.ExtrudedDirection) != 0;
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger("Xbim.Ifc2x3.GeometricModelResource.IfcExtrudedAreaSolid");
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcExtrudedAreaSolid.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public override IEnumerable<ValidationResult> Validate()
		{
			foreach (var value in base.Validate())
			{
				yield return value;
			}
			if (!ValidateClause(IfcExtrudedAreaSolidClause.WR31))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcExtrudedAreaSolid.WR31", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
