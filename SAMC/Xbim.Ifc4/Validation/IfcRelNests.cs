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
namespace Xbim.Ifc4.Kernel
{
	public partial class IfcRelNests : IExpressValidatable
	{
		public enum IfcRelNestsClause
		{
			NoSelfReference,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcRelNestsClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcRelNestsClause.NoSelfReference:
						retVal = Functions.SIZEOF(RelatedObjects.Where(Temp => Object.ReferenceEquals(RelatingObject, Temp))) == 0;
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger("Xbim.Ifc4.Kernel.IfcRelNests");
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcRelNests.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public virtual IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(IfcRelNestsClause.NoSelfReference))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcRelNests.NoSelfReference", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
