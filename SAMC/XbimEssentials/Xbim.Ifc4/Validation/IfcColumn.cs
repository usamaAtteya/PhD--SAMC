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
	public partial class IfcColumn : IExpressValidatable
	{
		public enum IfcColumnClause
		{
			CorrectPredefinedType,
			CorrectTypeAssigned,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcColumnClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcColumnClause.CorrectPredefinedType:
						retVal = !(Functions.EXISTS(PredefinedType)) || (PredefinedType != IfcColumnTypeEnum.USERDEFINED) || ((PredefinedType == IfcColumnTypeEnum.USERDEFINED) && Functions.EXISTS(this/* as IfcObject*/.ObjectType));
						break;
					case IfcColumnClause.CorrectTypeAssigned:
						retVal = (Functions.SIZEOF(IsTypedBy) == 0) || (Functions.TYPEOF(this/* as IfcObject*/.IsTypedBy.ItemAt(0).RelatingType).Contains("IFC4.IFCCOLUMNTYPE"));
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger("Xbim.Ifc4.SharedBldgElements.IfcColumn");
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcColumn.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public override IEnumerable<ValidationResult> Validate()
		{
			foreach (var value in base.Validate())
			{
				yield return value;
			}
			if (!ValidateClause(IfcColumnClause.CorrectPredefinedType))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcColumn.CorrectPredefinedType", IssueType = ValidationFlags.EntityWhereClauses };
			if (!ValidateClause(IfcColumnClause.CorrectTypeAssigned))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcColumn.CorrectTypeAssigned", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
