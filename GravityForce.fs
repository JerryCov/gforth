\ __________________________________________________________________________
\ Wed Feb  4 16:58:00 EST 2026
\ F = G*((m1*m2)/r^2)
cr .( The formula to find the gravitational force between two objects)
cr .( given their masses and the distance between their centers of mass.)
cr ." F = G*((m1*m2)/r^2)" cr
6.6743e-11 fconstant G .( 6.674e-11_N[m/kg]^2 fconstant G, Universal Gravitational Constant)
5.972e24 fconstant ME cr .( 5.97e24_kg fconstant ME, Mass of the Earth in kilograms)
6371000e fconstant RE cr .( 6371000e_m fconstant RE, radius of Earth in meters) cr
.( The gforth word used to compute gravitational force between two masses:) cr
: gforce .( m1 m2 r1 -f- f1)
  \ computes the force of gravity
  2e f** frot frot f* fswap f/ G f* ;
see gforce cr
.( Example: the force between the Earth and an 81_kg object on the surface.) cr
.( ME 81.e RE gforce f. )
ME 81.e RE gforce f. .( _N) cr
cr .( Check our stacks. Data stack: ) .s .( Floating point stack: ) f.s cr
