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
namespace Xbim.Ifc2x3.DateTimeResource
{
	public partial struct IfcDaylightSavingHour : IExpressValidatable
	{
		public enum IfcDaylightSavingHourClause
		{
			WR1,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcDaylightSavingHourClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcDaylightSavingHourClause.WR1:
						retVal = ((0 <= this) && (this <= 2) );
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger("Xbim.Ifc2x3.DateTimeResource.IfcDaylightSavingHour");
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcDaylightSavingHour.{0}'.", clause), ex);
			}
			return retVal;
		}

		public IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(IfcDaylightSavingHourClause.WR1))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcDaylightSavingHour.WR1", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
