\ D:/GForth/gforth/gforth ./mathtests.fs -e bye

: hi ( -- ) cr ." Hello there." cr ;
hi
cr .( Our first goal will be to fool around with various ways of generating pi. )
\ define some constants
cr .( First we define a couple of floating point constants we will need.)
cr .( D2R is the degrees to radians conversion constant.)
cr .( R2D is the radians to degrees conversion constant.)
pi 180e f/ fconstant D2R
D2R 1/f fconstant R2D
cr .( Now show them )
cr .( D2R f. ) D2R f. .( R2D f. ) R2D f. cr 
cr .( Now let the games begin, shenanigans! ) cr
.( pi using fatan, 1e fatan 4e f* f.: )1e fatan 4e f* f. cr
.( pi using fasin, 1e fasin 2e f* f.: )1e fasin 2e f* f. cr
.( pi using facos, -1e facos f.: )-1e facos f. cr
.( The equivalent of facos using fatan2: ) cr
.( 0e -1e fatan2 f.: ) 0e -1e fatan2 f. cr
.( The equivalent of fasin using fatan2: ) cr
.( 1e 0e fatan2 2e f* f.: ) 1e 0e fatan2 2e f* f. cr
cr .( Now for some other constants and fun stuff )
\ The golden ratio, phi
cr .( 5e 2e 1/f f** 1e f+ 2e f/ fconstant phi ) cr
5e 2e 1/f f** 1e f+ 2e f/ fconstant phi
.( The Golden Ratio, phi ) phi f. cr
.( 5e 2e 1/f f** 1e f- 2e f/ fconstant ihp ) cr
5e 2e 1/f f** 1e f- 2e f/ fconstant ihp
.( The inverse of the Golden Ratio, ihp ) ihp f. cr
: .magnitudes ( --- )
  ." Astronomical magnitudes compute the brightness of objects based on the " cr
  ." dimmest naked eye star being magnitude 6 and the brightest star at magnitude 1" cr
  ." with magnitude 1 being 100 times brighter than magnitude 6." cr
  ." Other objects such as the moon and some planets are much brighter than the stars." cr
;
cr .magnitudes
cr .( 100e 5e 1/f f** fconstant sm ) cr
100e 5e 1/f f** fconstant sm
.( The base of astronomical brightness magnitudes, sm ) sm f. cr
.( Now for a word to compute relative brightnesses from magnitudes. )
: smag ( mag -fp- brightness )
  sm 6e frot f- f** ;
see smag cr
.( Examples of magnitudes )
cr .( magnitude 1e smag brightness f. ) 1e smag f.
cr .( magnitude 6e smag brightness f. ) 6e smag f.
cr .( magnitude 0e smag brightness f. ) 0e smag f.

cr .( Checking our stacks: Data Stack: ) .s .( Floating point stack: ) f.s cr
cr .( Done! ) cr

