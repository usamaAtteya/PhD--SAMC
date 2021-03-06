//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from SapParser.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="SapParserParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public interface ISapParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="SapParserParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFile([NotNull] SapParserParser.FileContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SapParserParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFile([NotNull] SapParserParser.FileContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>programControlTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgramControlTable([NotNull] SapParserParser.ProgramControlTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>programControlTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgramControlTable([NotNull] SapParserParser.ProgramControlTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>pointsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPointsTable([NotNull] SapParserParser.PointsTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>pointsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPointsTable([NotNull] SapParserParser.PointsTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>areaElementsWithoutSectionsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAreaElementsWithoutSectionsTable([NotNull] SapParserParser.AreaElementsWithoutSectionsTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>areaElementsWithoutSectionsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAreaElementsWithoutSectionsTable([NotNull] SapParserParser.AreaElementsWithoutSectionsTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>areaSectionsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAreaSectionsTable([NotNull] SapParserParser.AreaSectionsTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>areaSectionsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAreaSectionsTable([NotNull] SapParserParser.AreaSectionsTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>areaSectionAssignmentsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAreaSectionAssignmentsTable([NotNull] SapParserParser.AreaSectionAssignmentsTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>areaSectionAssignmentsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAreaSectionAssignmentsTable([NotNull] SapParserParser.AreaSectionAssignmentsTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>boundaryConditionsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoundaryConditionsTable([NotNull] SapParserParser.BoundaryConditionsTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>boundaryConditionsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoundaryConditionsTable([NotNull] SapParserParser.BoundaryConditionsTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>materialsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMaterialsTable([NotNull] SapParserParser.MaterialsTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>materialsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMaterialsTable([NotNull] SapParserParser.MaterialsTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>materialsPropertiesTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMaterialsPropertiesTable([NotNull] SapParserParser.MaterialsPropertiesTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>materialsPropertiesTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMaterialsPropertiesTable([NotNull] SapParserParser.MaterialsPropertiesTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>activeDegressTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterActiveDegressTable([NotNull] SapParserParser.ActiveDegressTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>activeDegressTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitActiveDegressTable([NotNull] SapParserParser.ActiveDegressTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>frameSectionsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFrameSectionsTable([NotNull] SapParserParser.FrameSectionsTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>frameSectionsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFrameSectionsTable([NotNull] SapParserParser.FrameSectionsTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>frameElementsSectionsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFrameElementsSectionsTable([NotNull] SapParserParser.FrameElementsSectionsTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>frameElementsSectionsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFrameElementsSectionsTable([NotNull] SapParserParser.FrameElementsSectionsTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>frameElementsJointsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFrameElementsJointsTable([NotNull] SapParserParser.FrameElementsJointsTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>frameElementsJointsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFrameElementsJointsTable([NotNull] SapParserParser.FrameElementsJointsTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>loadPatternsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLoadPatternsTable([NotNull] SapParserParser.LoadPatternsTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>loadPatternsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLoadPatternsTable([NotNull] SapParserParser.LoadPatternsTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>pointsLoadsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPointsLoadsTable([NotNull] SapParserParser.PointsLoadsTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>pointsLoadsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPointsLoadsTable([NotNull] SapParserParser.PointsLoadsTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>frameLoadsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFrameLoadsTable([NotNull] SapParserParser.FrameLoadsTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>frameLoadsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFrameLoadsTable([NotNull] SapParserParser.FrameLoadsTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>areaLoadsUniformTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAreaLoadsUniformTable([NotNull] SapParserParser.AreaLoadsUniformTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>areaLoadsUniformTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAreaLoadsUniformTable([NotNull] SapParserParser.AreaLoadsUniformTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>loadCaseTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLoadCaseTable([NotNull] SapParserParser.LoadCaseTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>loadCaseTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLoadCaseTable([NotNull] SapParserParser.LoadCaseTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>loadCaseAssignmentsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLoadCaseAssignmentsTable([NotNull] SapParserParser.LoadCaseAssignmentsTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>loadCaseAssignmentsTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLoadCaseAssignmentsTable([NotNull] SapParserParser.LoadCaseAssignmentsTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>loadCombinationTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLoadCombinationTable([NotNull] SapParserParser.LoadCombinationTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>loadCombinationTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLoadCombinationTable([NotNull] SapParserParser.LoadCombinationTableContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>otherTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOtherTable([NotNull] SapParserParser.OtherTableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>otherTable</c>
	/// labeled alternative in <see cref="SapParserParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOtherTable([NotNull] SapParserParser.OtherTableContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SapParserParser.table_content"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTable_content([NotNull] SapParserParser.Table_contentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SapParserParser.table_content"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTable_content([NotNull] SapParserParser.Table_contentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SapParserParser.table_row"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTable_row([NotNull] SapParserParser.Table_rowContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SapParserParser.table_row"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTable_row([NotNull] SapParserParser.Table_rowContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SapParserParser.table_row_item"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTable_row_item([NotNull] SapParserParser.Table_row_itemContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SapParserParser.table_row_item"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTable_row_item([NotNull] SapParserParser.Table_row_itemContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SapParserParser.table_footer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTable_footer([NotNull] SapParserParser.Table_footerContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SapParserParser.table_footer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTable_footer([NotNull] SapParserParser.Table_footerContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>IntigerData</c>
	/// labeled alternative in <see cref="SapParserParser.data"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIntigerData([NotNull] SapParserParser.IntigerDataContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>IntigerData</c>
	/// labeled alternative in <see cref="SapParserParser.data"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIntigerData([NotNull] SapParserParser.IntigerDataContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>DoubleData</c>
	/// labeled alternative in <see cref="SapParserParser.data"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDoubleData([NotNull] SapParserParser.DoubleDataContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>DoubleData</c>
	/// labeled alternative in <see cref="SapParserParser.data"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDoubleData([NotNull] SapParserParser.DoubleDataContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>TextData</c>
	/// labeled alternative in <see cref="SapParserParser.data"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTextData([NotNull] SapParserParser.TextDataContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>TextData</c>
	/// labeled alternative in <see cref="SapParserParser.data"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTextData([NotNull] SapParserParser.TextDataContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>DoubleQoutedTextData</c>
	/// labeled alternative in <see cref="SapParserParser.data"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDoubleQoutedTextData([NotNull] SapParserParser.DoubleQoutedTextDataContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>DoubleQoutedTextData</c>
	/// labeled alternative in <see cref="SapParserParser.data"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDoubleQoutedTextData([NotNull] SapParserParser.DoubleQoutedTextDataContext context);
}
