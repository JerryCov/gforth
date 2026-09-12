\ xx
: .showtime ( -- ) cr \ time is hh mm ss
	   time&date \ date is:  year, month, day
	   ." Date: " . ." / " . ." / " . cr
	   ." Time: " . ." : " . ." : " . cr ;
\ cr see .showtime cr
.showtime
cr

.( Temperature conversions.) cr
.( Fahrenheit to Centigrade:) cr

: f>c .( f -fp- c) 32e f- 1.8e f/ ;
see f>c cr cr
.( Centigrade to Fahrenheit:) cr

: c>f .( c -fp- f) 1.8e f* 32e f+ ;
see c>f cr cr

.( 37e c>f f. )
37e c>f fdup f. ." _f" cr
fdup f. .( _f f>c f. )
f>c f. cr cr

.( 113e f>c f. )
113e f>c fdup f. ." _f" cr
fdup f. .( _f c>f f. )
c>f f. cr cr


.( 35e c>f f. )
35e c>f fdup f. ." _f" cr
fdup f. .( _f f>c f. )
f>c f. cr cr

.( 27e c>f f. )
27e c>f fdup f. ." _f" cr
fdup f. .( _f f>c f. )
f>c f. cr cr

