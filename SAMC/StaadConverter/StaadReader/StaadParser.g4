grammar StaadParser;

file                 : (TEXT|WHITESPACE|newline_or_white_space)* (section | other)+ (TEXT|newline_or_white_space)* EOF;
section                : 'UNIT' WHITESPACE+ data WHITESPACE+ data newline_or_white_space+ #unitsSection
                     | 'JOINT COORDINATES' newline_or_white_space+ semi_colon_separated_section_content #pointsSection
                     | 'MEMBER INCIDENCES' newline_or_white_space+ semi_colon_separated_section_content #frameElementsSection
                     | 'ELEMENT INCIDENCES SHELL'newline_or_white_space+ semi_colon_separated_section_content #areaElementsSection
                     |'DEFINE MATERIAL START' newline_or_white_space+ material_definition* ('END DEFINE MATERIAL'|WHITESPACE)+ newline_or_white_space+ #materialSection
					 | 'ELEMENT PROPERTY' newline_or_white_space+ section_definition_section_content #areaElementsSectionsSection
					 | 'MEMBER PROPERTY' WHITESPACE? data? WHITESPACE? NEWLINE+ section_definition_section_content #frameElementsSectionsSection
					 | 'CONSTANTS' newline_or_white_space+ material_assignment_row* #materialAssignmentSection
					 | 'SUPPORTS' newline_or_white_space+ generic_row* #boundaryConditionsSection
					 | 'LOAD' WHITESPACE* INTIGER (data |WHITESPACE)+ newline_or_white_space+ load_inner_section* #loadCaseSection
                     | 'LOAD COMB' WHITESPACE+ 	INTIGER WHITESPACE (data | WHITESPACE)+ newline_or_white_space+ load_combination_row* #loadComboSection		 
					   ;
other                : data | newline_or_white_space;					   
					   


					   
load_inner_section : joint_load_section | element_load_section | member_load_section;					   
joint_load_section :'JOINT LOAD'  newline_or_white_space+ (joint_load_row | newline_or_white_space)* ;
element_load_section :'ELEMENT LOAD'  newline_or_white_space+ generic_row*;
member_load_section :'MEMBER LOAD'  newline_or_white_space+ generic_row*;


joint_load_row :id_definition_list (data | WHITESPACE)+ NEWLINE;

					  
newline_or_white_space : NEWLINE | WHITESPACE;	
	
generic_row : id_definition_list assignment_definition newline_or_white_space+;					   

material_definition :WHITESPACE* 'ISOTROPIC' ( data| WHITESPACE)+ newline_or_white_space+ material_property*;
material_property : (data | WHITESPACE)+ newline_or_white_space;
	
semi_colon_separated_section_content : (semi_colon_separated_row | newline_or_white_space)+;					    
semi_colon_separated_row  : (data | WHITESPACE)+ SEMICOLON ;

material_assignment_row   :WHITESPACE* data WHITESPACE+ data WHITESPACE+ material_assignment_row_value; 
material_assignment_row_value  : ('ALL' | ('MEMB' WHITESPACE* id_definition_list)) NEWLINE+;

section_definition_section_content : section_definition_row*;
section_definition_row : id_definition_list assignment_definition NEWLINE+;
assignment_definition   : TEXT (data | WHITESPACE)*;

load_combination_row : (load_combination_row_data | WHITESPACE)+ NEWLINE+ ;
load_combination_row_data : INTIGER | DOUBLE ;

id_definition_list : ( id_definition | row_data_separator)+  #IdDefinitionList;
id_definition      :   INTIGER #IntigerId
                        |range #RangeOfIds
						;
range       :INTIGER WHITESPACE* 'TO' WHITESPACE* INTIGER; 
row_data_separator : (WHITESPACE | '-'NEWLINE) ;

data:  'LOAD'  #LoadHeaderData
      | 'LOAD COMB' #LoadHeaderData
      |	 'SUPPORTS' #LoadHeaderData
	  | 'CONSTANTS'#LoadHeaderData
	  | 'MEMBER PROPERTY'  #LoadHeaderData
	  | ' AMERICAN' #LoadHeaderData
	  | 'ELEMENT PROPERTY' #LoadHeaderData
	  |'DEFINE MATERIAL START' #LoadHeaderData
	  | 'ELEMENT INCIDENCES SHELL' #LoadHeaderData
	  | 'MEMBER INCIDENCES' #LoadHeaderData
	  |'JOINT COORDINATES' #LoadHeaderData
	  |'UNIT' #LoadHeaderData
	  | 'ALL' #LoadHeaderData
	  | 'MEMB' #LoadHeaderData
	  | 'JOINT LOAD' #LoadHeaderData
	  | 'ELEMENT LOAD' #LoadHeaderData
	  |'MEMBER LOAD' #LoadHeaderData
	  |'MATERIAL' #LoadHeaderData
	  |'BETA'  #LoadHeaderData
	  | '-' #LoadHeaderData
	  | 'TO' #LoadHeaderData
      | INTIGER   #IntigerData
      | DOUBLE  #DoubleData
      | TEXT  #TextData
	  
 ;


fragment INT : '0' | [1-9] [0-9]* ; // no leading zeros
fragment EXP : [Ee] [+\-]? INT ; // \- since - means "range" inside [...]
fragment NL  : ('\r'? '\n' | '\r')+ ; 

COMMENT   : '*'+ [\n\r\t;*]? '*'? NL -> skip ;
 
INTIGER   :  '-'? INT EXP // 1e10 -3e4
           | '-'? INT // -3, 45
		   ;


DOUBLE  : '-'? INT '.' [0-9]* EXP? ; // 1.35, 1.35E-9, 0.3, -4.5

SEMICOLON             : ';';

WHITESPACE          : (' ' | '\t') ;

NEWLINE             : NL ;

NUMBER              : (INTIGER | DOUBLE) ;

TEXT                :  ~[\n\r\t; ]+; /* contains any thing except SEMICOLON, NEWLINE, WHITESPACE,  */

ANY : .  -> skip;

