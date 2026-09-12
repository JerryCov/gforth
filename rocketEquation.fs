\ delta v = ve*ln(m0/mf) = Isp*g0*ln(m0/mf)
cr .( f? a word that fetches the value pointed to by an fvariable to the fp stack and prints it.)
cr .( An fvariable leaves the address pointing to the contents of a floating point variable)
cr .( on the data stack, f@ pushes the contents from that address to the fp stack,)
cr .( [poping the address from the data stack] then)
cr .( f. pops the value from the top of the fp stack and prints it to the console.)
cr .( Floating point equivalent to ? ) cr cr
: f? .( addr ---  , fnum -fp- ) f@ f. ;
." ,( address ---  , floatnumber -fp- )"
see f? cr
.( The stack comments show that f? leaves nothing on either stack.)
cr
cr .( Floating point constants: )
cr .( Universal gravitational constant: UG f. )
6.67408e-11 fconstant UG
UG f. ." _m^3/(kg*s^2)" cr
9.81e fconstant g0 \ _m/s^2
.( gravitational acceleration at Earth's surface: g0 f. ) 2 spaces g0 f. .( _m/s^2 ) cr 

0e fvariable ve ve f!
0e fvariable m0 m0 f!
0e fvariable mf mf f!
0e fvariable Isp Isp f!
0e fvariable delta_v delta_v f!

.( Floating point variables: ) cr
.( exhaust velocity: ve f? ) ve f? .( _km/s ) 2 spaces
.( original mass: m0 f? ) m0 f? .( _kg ) 2 spaces
cr .( final mass: mf f? ) mf f? .( _kg ) 2 spaces
.( Specific impulse: Isp f? ) Isp f? .( _s ) cr

cr ." delta v using exhaust velocity = ve*ln(m0/mf), using specific impulse = Isp*g0*ln(m0/mf)"
cr .( Computes delta v given exhaust velocity, original mass, and final mass.) cr cr
: delta-v-1 .( ve m0 mf -f- delta-v ) f/ fln f* ; 
see delta-v-1 cr

cr .( Computes delta v given specific impulse, original mass, and final mass.) cr cr
: delta-v-2 .( Isp m0 mf -f- delta-v ) f/ fln g0 f* f* ;
see delta-v-2 cr

cr .( Computes original mass given final mass, delta v, and exhaust velocity.) cr cr
: wet-mass .( mf delta-v ve -f- m0) f/ fexp f* ;
see wet-mass cr cr
\ ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
\ ;;; Specific impulse, Isp:
\ ;;; Isp = F/(mr*g0)
\ ;;;   where F = force, or amount of thrust per second in Newtons
\ ;;;         mr = rate of fuel burned per second (_kg/s)
\ ;;;         g0 = acceleration due to gravity at Earth's surface, 9.81_m/s^2
\ ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

.( ve = 450e, mo = 33000000e, mf = 25000e: delta-v-1 f. cr ) 450e 33000000e 25000e delta-v-1 f. cr
.( ve = 450e, mo = 33000000e, mf = 2500e: delta-v-1 f. cr ) 450e 33000000e 2500e delta-v-1 f. cr
.( ve = 450e, mo = 33000000e, mf = 250e: delta-v-1 f. cr ) 450e 33000000e 250e delta-v-1 f. cr
.( ve = 450e, mo = 38000000e, mf = 250e: delta-v-1 f. cr ) 450e 38000000e 250e delta-v-1 f. cr
.( ve = 800e, mo = 38000000e, mf = 250e: delta-v-1 f. cr ) 800e 38000000e 250e delta-v-1 f. cr

.( mf = 10000e, delta_v = 12e, ve = 1200e: wet-mass f. cr ) 10000e 12e 1200e wet-mass f. cr
.( mf = 10000e, delta_v = 12e, ve = 1200e: wet-mass f. cr ) 10000e 12e 2500e wet-mass f. cr

.( Isp = 46e, mo = 38000000e, mf = 250e: delta-v-2 f. cr ) 46e 38000000e 250e delta-v-2 f. cr
.( Isp = 52e, mo = 38000000e, mf = 250e: delta-v-2 f. cr ) 52e 38000000e 250e delta-v-2 f. cr
.( Isp = 82e, mo = 38000000e, mf = 250e: delta-v-2 f. cr ) 82e 38000000e 250e delta-v-2 f. cr


