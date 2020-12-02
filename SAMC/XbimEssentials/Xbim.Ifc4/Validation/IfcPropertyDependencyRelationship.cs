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
namespace Xbim.Ifc4.PropertyResource
{
	public partial class IfcPropertyDependencyRelationship : IExpressValidatable
	{
		public enum IfcPropertyDependencyRelationshipClause
		{
			NoSelfReference,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcPropertyDependencyRelationshipClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcPropertyDependencyRelationshipClause.NoSelfReference:
						retVal = !Object.ReferenceEquals(DependingProperty, DependantProperty);
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger("Xbim.Ifc4.PropertyResource.IfcPropertyDependencyRelationship");
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcPropertyDependencyRelationship.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public virtual IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(IfcPropertyDependencyRelationshipClause.NoSelfReference))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcPropertyDependencyRelationship.NoSelfReference", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
