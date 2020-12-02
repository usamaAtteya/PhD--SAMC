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
namespace Xbim.Ifc4.TopologyResource
{
	public partial class IfcOrientedEdge : IExpressValidatable
	{
		public enum IfcOrientedEdgeClause
		{
			EdgeElementNotOriented,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcOrientedEdgeClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcOrientedEdgeClause.EdgeElementNotOriented:
						retVal = !(Functions.TYPEOF(EdgeElement).Contains("IFC4.IFCORIENTEDEDGE"));
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger("Xbim.Ifc4.TopologyResource.IfcOrientedEdge");
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcOrientedEdge.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public virtual IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(IfcOrientedEdgeClause.EdgeElementNotOriented))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcOrientedEdge.EdgeElementNotOriented", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
