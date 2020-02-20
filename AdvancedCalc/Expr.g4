grammar Expr;
NUM : [0-9]+ ('.' [0-9]+)? ;
WS : [ \t\r\n] -> skip ;
OP_ADD : '+' ;
OP_SUB : '-' ;
OP_MUL : '*' ;
OP_DIV : '/' ;
OP_POW : '^' ;
OP_EQ : '=' ;
OP_LS : '<' ;
OP_GR : '>' ;
OP_NE : '!=' ;
OP_LE : '<=' ;
OP_GE : '>=' ;
SEP_COM : ',' ;

ID : [a-zA-Z_]+ ;

compileUnit
	: expr EOF
	;

expr 
	: '(' expr ')' # purenExpr
	| '-' expr # negExpr
	| value=NUM # numExpr
	| func=ID '(' args=funcArgs ')' #funcExpr
	| <assoc=right> left=expr op='^' right=expr #p0Expr
	| left=expr op=('*'|'/') right=expr # p0Expr
	| left=expr op=('+'|'-') right=expr # p0Expr
	| left=expr op=('='|'!='|'>'|'<'|'<='|'>=') right=expr # p0Expr 
	;

funcArgs
	: expr (',' expr)* ;