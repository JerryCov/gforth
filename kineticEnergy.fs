\ kinetic energy = 1/2 * m*v^2 or (m * v^2)/2
\ Tue Sep 10 13:52:47 EDT 2024
cr .( First let's set up some fvariables to put stuff in.)
0e fvariable m m f! \ create a floating point variable for mass, init to 0
0e fvariable v v f! \ create a floating point variable for velocity, init to 0
0e fvariable k_e k_e f! \ create a floating point variable for kinetic energy, init to 0
cr .( 0e fvariable m m f! )
cr .( 0e fvariable v v f! )
cr .( 0e fvariable k_e k_e f!) cr
\ Using floating point variables gives us some flexability as we will demonstrate below. 
\ For one thing we can use the variables as input to our word, or we can use the fp stack
\ for direct input 
.( kinetic energy = 1/2 * m*v^2 or [m * v^2]/2 ) cr
.( define our kinetic enerty computation word. ) cr cr
: ke .( m v -f- ke ) 2e f** f* 2e f/ ;
." ; mass velocity -fp- kinetic_energy "
see ke cr cr
.( For mass in kilograms and velocities in meters/second, energy is in Joules, _J. ) cr
.( and that's what we'll be using here so...) cr
.( Now for some examples. ) cr
.( Using variables: ) cr
.( 5e m f! ) 5e m f!
.( 15e v f! ) 15e v f! cr
.( m f@ v f@ ke fdup k_e f! f. ) m f@ v f@ ke fdup k_e f! f. .( _J) cr \ we'll save this result for later
.( 30e v f! ) 30e v f! cr
.( m f@ v f@ ke f. ) m f@ v f@ ke f. .( _J) cr
.( 80e m f! ) 80e m f! cr
.( m f@ v f@ ke f. ) m f@ v f@ ke f. .( _J) cr
.( 30e v f! ) 30e v f! cr
.( m f@ v f@ ke f. ) m f@ v f@ ke f. .( _J) cr
.( 100e v f! ) 100e v f! cr
.( m f@ v f@ ke f. ) m f@ v f@ ke f. .( _J) cr
.( Using direct inputs {on the fp stack} ) cr
.( 50e 1000e ke f. ) 50e 1000e ke f. .( _J) cr
.( 0.50e 1000e ke f. ) 0.50e 1000e ke f. .( _J) cr
.( 80e 18e ke f. ) 80e 18e ke f. .( _J) cr
.( 81e 10e ke f. ) 81e 10e ke f. .( _J) cr
.( And our first result was: k_e f@ f. ) k_e f@ f. .( _J) cr
cr .( Checking our stacks: Data Stack: ) .s .( Floating point stack: ) f.s cr
cr .( Done! ) cr

