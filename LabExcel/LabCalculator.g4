grammar LabCalculator;

/*
* Parser Rules
*/
compileUnit : expression EOF;
expression : 
LPAREN expression RPAREN #ParenthesizedExpr
|expression EXPONENT expression #ExponentialExpr
| expression operatorToken=(MULTIPLY | DIV | MOD) expression #MultiplicativeExpr
| expression operatorToken=(ADD | SUBTRACT) expression #AdditiveExpr
| expression operatorToken=(INC | DEC) #IncExpr
| NUMBER #NumberExpr
| IDENTIFIER #IdentifierExpr 
;
/*
* Lexer Rules
*/
NUMBER : INT ('.' INT)?;
IDENTIFIER : [a-zA-Z]+[1-9][0-9]+;
INT : ('0'..'9')+;
ADD : '+';
SUBTRACT : '-';
MULTIPLY : '*';
DIV : '/';
MOD: '%';
EXPONENT : '^';
INC: '++';
DEC: '--';
LPAREN : '(';
RPAREN : ')';
WS : [ \t\r\n] -> channel(HIDDEN);