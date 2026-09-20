\ TemperatureConv.fs
\ Wed Feb  4 16:58:00 EST 2026
: .showtime ( -- ) cr \ time is hh mm ss
	   time&date \ date is:  year, month, day
	   ." Date: " . ." / " . ." / " . cr
	   ." Time: " . ." : " . ." : " . cr ;
\ cr see .showtime cr
.showtime
cr
.( ____________________________________________________________________________________ )
cr .( Define some constants. )
cr .( -273.15e fconstant ABS-ZERO-C \ Absolute zero C )
-273.15e fconstant ABS-ZERO-C \ Absolute zero C
cr .( -459.67e fconstant ABS-ZERO-F \ Absolute zero F )
-459.67e fconstant ABS-ZERO-F \ Absolute zero F
cr .( Conversion words )
cr
: C>F .( C -fp- F ) \ Convert Centigrade to Fahrenheit
  1.8e f* 32e f+ ;
see C>F
cr cr
: F>C .( F -fp- C ) \ Convert Fahrenheit to Centigrade
  32e f- 1.8e f/ ;
see F>C
cr cr

: C>K .( C -fp- K ) \ Convert Centigrade to Kelvin
  273.15e f+ ;
see C>K
cr cr

: K>C .( K -fp- C ) \ Convert Kelvin to Centigrade
  273.15e f- ;
see K>C
cr cr

: F>R .( F -fp- R ) \ Convert Fahrenheit to Rankine
  459.67e f+ ;
see F>R
cr cr

: R>F .( R -fp- F ) \  Convert Rankine to Fahrenheit
  459.67e f- ;
see R>F
cr cr

cr .( Some display words. ) cr
: .ABSZEROS .( -fp- )
   cr ." Absolute zero C: " ABS-ZERO-C f.
   cr ." Absolute zero F: " ABS-ZERO-F f. ;
see .ABSZEROS
cr cr

: .C>F .( C -fp- )
  cr fdup f. ." Degrees Centigrade is " C>F f. ." Degrees Fahrenheit." ;
see .C>F
cr cr

: .F>C .( F -fp- )
  cr fdup f. ." Degrees Fahrenheit is " F>C f. ." Degrees Centigrade." ;
see .F>C
cr cr


: .K>C .( K -fp- )
  cr fdup f. ." Degrees Kelvin is " K>C f. ." Degrees Centigrade." ;
see .K>C
cr cr

: .C>K .( K -fp- )
  cr fdup f. ." Degrees Centigrade is " C>K f. ." Degrees Kelvin." ;
see .C>K
cr cr

: .F>R .( F -fp- )
  cr fdup f. ." Degrees Fahrenheit is " F>R f. ." Degrees Rankine." ;
see .F>R
cr cr

: .R>F .( R -fp- )
  cr fdup f. ." Degrees Rankine is " R>F f. ." Degrees Fahrenheit." ;
see .R>F
cr cr


cr
cr .( Now we can put some values on the fp stack and test our words. )
cr
.( ____________________________________________________________________________________ )
cr .( Display our constants: )
cr .ABSZEROS cr cr

cr .( Test some values on the fp stack. )
cr .( 0e .C>F )
0e .C>F
cr .( 0e .F>C )
0e .F>C
cr .( 37e .C>F )
37e .C>F
cr .( 98.6e .F>C )
98.6e .F>C
cr .( 45e .C>F )
45e .C>F
cr .( 113e .F>C )
113e F>C 113e .F>C fdup cr f. 1 spaces .( .C>F ) .C>F

-17.7777777777778e .C>F
cr .( 32e .F>C )
32e .F>C
cr .( -40e .C>F )
-40e .C>F
cr .( -40e .F>C )
-40e .F>C
cr .( ABS-ZERO-C .C>F )
ABS-ZERO-C .C>F
cr .( ABS-ZERO-F .F>C )
ABS-ZERO-F .F>C
cr .( 300e .K>C )
300e .K>C
cr .( 26.85e .C>K )
26.85e .C>K
cr .( 80e .F>R )
80e .F>R
cr .( 539.67e .R>F )
539.67e .R>F
cr .( 24e .C>F )
24e .C>F
cr .( 18e .F>C )
18e .F>C
cr
cr .( 14e .C>F )
14e .C>F
cr
cr .( 57.2e .F>C )
57.2e .F>C
cr
cr .( 70.0e .F>C )
70.0e F>C 70.0e .F>C fdup cr f. 1 spaces .( .C>F ) .C>F
cr
cr .( 19.0e .C>F )
19.0e C>F 19.0e .C>F fdup cr f. 1 spaces .( .F>C ) .F>C
cr
cr .( 28.0e .C>F )
28.0e C>F 28.0e .C>F fdup cr f. 1 spaces .( .F>C ) .F>C
cr

.( ____________________________________________________________________________________ )

cr
cr .( Check our stacks; Data Stack: ) .s .( , Floating Point Stack: ) f.s
cr .( Done!)
cr
