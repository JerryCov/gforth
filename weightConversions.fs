\ weight conversions
\ first we set up our conversion constants
0.45359237e fconstant lb2kg
lb2kg 1/f fconstant kg2lb
28.349523125e fconstant oz2g
oz2g 1/f fconstant g2oz
cr
: showConstants .( -f- ) ." Display Conversion Constants" cr
		." lb2kg: " lb2kg f. 8 spaces ." pounds to kilograms" cr
		." kg2lb: " kg2lb f. 2 spaces ." kilograms to pounds" cr
		." oz2g:  " oz2g f.  6 spaces ." ounces to grams" cr
		." g2oz:  " g2oz f.  0 spaces ." grams to ounces" cr ;
." ( -f- )"
see showConstants cr
cr showConstants
\ now we define our conversion words
.( Show the definitions of our conversion words. ) cr

: lb-to-kg .( lb -f- kg ) lb2kg f* ;
." ( pounds -f- kilograms )"
see lb-to-kg cr
: kg-to-lb .( kg -f- lb ) kg2lb f* ;
." ( kilograms -f- pounds )"
see kg-to-lb cr
: oz-to-g .( oz -f- g ) oz2g f* ;
." ( ounces -f- grams )"
see oz-to-g cr
: g-to-oz .( g -f- oz ) g2oz f* ;
." ( grams -f- ounces )"
see g-to-oz cr cr
cr .( Now for a few examples: ) cr
.( 195e lb-to-kg f. cr ) 195e lb-to-kg f. .( _kg. ) cr
.( 200e lb-to-kg f. cr ) 200e lb-to-kg f. .( _kg. ) cr
.( 88.45051215e kg-to-lb f. cr ) 88.45051215e kg-to-lb f. .( _lb. ) cr
.( 90.718474e kg-to-lb f. cr ) 90.718474e kg-to-lb f. .( _lb. ) cr
.( 16e oz-to-g f. cr ) 16e oz-to-g f. .( _g. ) cr
.( 453.59237e g-to-oz f. cr ) 453.59237e g-to-oz f. .( _oz. ) cr
.( Thus we see that our conversions work both ways. ) cr

.( 200e lb-to-kg fdup f. cr ) 200e lb-to-kg fdup f. .( _kg. ) cr
fdup f. .( kg-to-lb f. cr )  kg-to-lb f. .( _lb. ) cr
.( 500e lb-to-kg fdup f. cr ) 500e lb-to-kg fdup f. .( _kg. ) cr
fdup f. .( kg-to-lb f. cr )  kg-to-lb f. .( _lb. ) cr
.( 50e lb-to-kg fdup f. cr ) 50e lb-to-kg fdup f. .( _kg. ) cr
fdup f. .( kg-to-lb f. cr )  kg-to-lb f. .( _lb. ) cr


cr .( Checking our stacks: Data Stack: ) .s .( Floating point stack: ) f.s cr
.( Done!) cr
