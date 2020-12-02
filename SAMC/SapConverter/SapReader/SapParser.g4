grammar SapParser;

file                 : (TEXT|WHITESPACE |NEWLINE)* table+ (TEXT|WHITESPACE |NEWLINE)* EOF;
table                :  'TABLE:  "PROGRAM CONTROL"' NEWLINE table_content table_footer #programControlTable
                       |'TABLE:  "JOINT COORDINATES"' NEWLINE table_content table_footer #pointsTable
					   | 'TABLE:  "CONNECTIVITY - AREA"' NEWLINE table_content table_footer #areaElementsWithoutSectionsTable
					   | 'TABLE:  "AREA SECTION PROPERTIES"' NEWLINE table_content table_footer #areaSectionsTable
                       | 'TABLE:  "AREA SECTION ASSIGNMENTS"' NEWLINE table_content table_footer #areaSectionAssignmentsTable
					   | 'TABLE:  "JOINT RESTRAINT ASSIGNMENTS"' NEWLINE table_content table_footer #boundaryConditionsTable
					   | 'TABLE:  "MATERIAL PROPERTIES 01 - GENERAL"' NEWLINE table_content table_footer #materialsTable
					   | 'TABLE:  "MATERIAL PROPERTIES 02 - BASIC MECHANICAL PROPERTIES"' NEWLINE table_content table_footer #materialsPropertiesTable
					   | 'TABLE:  "ACTIVE DEGREES OF FREEDOM"' NEWLINE table_content table_footer #activeDegressTable
					   | 'TABLE:  "FRAME SECTION PROPERTIES 01 - GENERAL"' NEWLINE table_content table_footer #frameSectionsTable
					   | 'TABLE:  "FRAME SECTION ASSIGNMENTS"' NEWLINE table_content table_footer #frameElementsSectionsTable
					   | 'TABLE:  "CONNECTIVITY - FRAME"' NEWLINE table_content table_footer #frameElementsJointsTable
					   | 'TABLE:  "LOAD PATTERN DEFINITIONS"' NEWLINE table_content table_footer #loadPatternsTable
				       | 'TABLE:  "JOINT LOADS - FORCE"' NEWLINE table_content table_footer #pointsLoadsTable
					   | 'TABLE:  "FRAME LOADS - DISTRIBUTED"' NEWLINE table_content table_footer #frameLoadsTable
					   | 'TABLE:  "AREA LOADS - UNIFORM"' NEWLINE table_content table_footer #areaLoadsUniformTable
					   | 'TABLE:  "LOAD CASE DEFINITIONS"' NEWLINE table_content table_footer #loadCaseTable
					   | 'TABLE:  "CASE - STATIC 1 - LOAD ASSIGNMENTS"' NEWLINE table_content table_footer #loadCaseAssignmentsTable
					   | 'TABLE:  "COMBINATION DEFINITIONS"' NEWLINE table_content table_footer #loadCombinationTable
                       | 'TABLE:' WHITESPACE* DOUBLEQOUTEDTEXT WHITESPACE* NEWLINE  table_content table_footer #otherTable
					   
					   
					   ;
					   
					   
/*otherTable           :	table_header table_content table_footer;				   
table_header         : 'TABLE:' WHITESPACE* DOUBLEQOUTEDTEXT WHITESPACE* NEWLINE ;*/


table_content        : table_row*    ;
table_row            : (table_row_item | WHITESPACE | '_'NEWLINE)+ NEWLINE  ;
table_row_item       : TEXT EQUALS data;
table_footer         : WHITESPACE+ NEWLINE;  

/*activeDegressTable   :  'TABLE:  "ACTIVE DEGREES OF FREEDOM"' NEWLINE activeDegreesContent table_footer ; 
activeDegreesContent : activeDegressRow+ ;
activeDegressRow     :  ('UX' EQUALS data |  'UY' EQUALS data |  'UZ' EQUALS data |  'RX' EQUALS data |  'RY' EQUALS data|   'RZ' EQUALS data| WHITESPACE)+ NEWLINE;
*/
data:  INTIGER   #IntigerData
      | DOUBLE  #DoubleData
      | TEXT  #TextData
      | DOUBLEQOUTEDTEXT #DoubleQoutedTextData
 ;


fragment DOUBLEQOUTE  : '"'; 
fragment INT : '0' | [1-9] [0-9]* ; // no leading zeros
fragment EXP : [Ee] [+\-]? INT ; // \- since - means "range" inside [...]
fragment EQ  : '=';

INTIGER   :  '-'? INT EXP // 1e10 -3e4
           | '-'? INT // -3, 45
		   ;


DOUBLE  : '-'? INT '.' [0-9]* EXP? ; // 1.35, 1.35E-9, 0.3, -4.5


EQUALS              : EQ; 

WHITESPACE          : (' ' | '\t') ;

NEWLINE             : ('\r'? '\n' | '\r')+ ;

TEXT                :  ~["\n\r\t= ]+; /* contains any thing except DOUBLEQOUTE, NEWLINE, WHITESPACE, EQUALS */


DOUBLEQOUTEDTEXT    : DOUBLEQOUTE (TEXT | EQ | WHITESPACE)+  DOUBLEQOUTE;


ANY : .  -> skip;

