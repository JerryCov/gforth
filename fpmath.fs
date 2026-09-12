.( fpmath.fs Demonstrates some interesting floating point words. ) cr
.( Show some environmet stuff first. ) cr
s" gforth" environment? [IF] .( Gforth version ) TYPE
                        [ELSE] .( Not Gforth ) [THEN] cr
environment-wordlist >order words previous cr
\ Just for grins, and because we might want it,
\ we'll define f?, the floating point version of ?
: f? .( --- ) f@ f. ;
see f? cr
.( test f? ) cr
.( 45e fvariable t1 t1 f! t1 f? )
45e fvariable t1 t1 f! t1 f? cr 
6.67408e-11 fconstant G \ The universal gravitational constant
.( The universal gravitational constant G: ) G f. cr
\ Compute the base of astronomical brightness magnitudes
100e 5e 1/f f** fconstant sm \ It is the 5'th root of 100
\ display it with explanitory text
cr ." The base of astronomical brightness magnitudes sm: " sm f.
\ define the Golden Ratio
5e 2e 1/f f** 1e f+ 2e f/ fconstant phi
\ display it with explanitory text
cr ." The Golden Ratio, phi: " phi f.
\ define the inverse of the Golden Ratio
5e 2e 1/f f** 1e f- 2e f/ fconstant ihp
\ display it with explanitory text
cr ." The inverse of the Golden Ratio, ihp: " ihp f.

cr ." The fconstant pi is predefined in gforth."
cr ." pi = " pi f. cr
\ in the following n or b is a floating point number: example 33e,
\ where the e forces the number onto the fp stack
\ the natural log in gforth is fln, common logs is flog, logs any
\ base is n fln b fln f/
\ exponential is n fexp
1e fexp fconstant e \ make the base of natural logs and display same.
cr .( The base of natural logarithms is: ) e f.

pi 180e f/ fconstant d2r ( degrees to radians )
cr .( degrees to radians conversion constant d2r: ) d2r f. cr
: fcot .( n -fp- cotn ) ftan 1/f ;
." ( n -fp- cotn )"cr
see fcot cr
cr .( The parsec is defined as the cotangent of 1 arcsecond )
cr .( or 1/3600th of 1 degree.)
cr .( Compute the parsec in gforth. )
3600e 1/f d2r f* fcot fconstant psec ( compute the parsec)
cr .( 3600e 1/f d2r f* fcot fconstant psec )
cr .( The parsec is: ) psec f.

149597870700e fconstant AUM \ the astronomical unit in meters
psec AUM f* fconstant parsecm \ the astronomical parsec in meters
cr
.( The AUM is: ) AUM f. .( _m)  cr
.( The parsecm is: ) parsecm f. .( _m) cr
cr ." Display using .(  "
.( The cotangent of 1 is:  ) 1e fcot f. cr
.( Display using ."  )
." The cotangent of 1 is:  " 1e fcot f. cr
.( Showing that dot-paren and dot-quote are somewhat inter changeable in gforth.) cr
.( The major difference is that dot-paren shouldn't be used within a definition.) cr
.( You can do it but the results are a bit disconcerting, although usually nothing breaks.) cr
.( That said I sometimes use it as the stack comment within a word definition.) cr
.( It is also worth noting that many Forths don't allow ." outside of a definition, Gforth does.) cr
cr
: showpi .( -f- )
  cr ." Various ways to produce pi in gforth: "
  cr ." pi f. " pi f. ." as a predefined constant."
  cr ." -1e facos f. " -1e facos f. ." as the facos function of -1"
  cr ." 2e 1e fasin f* f. " 2e 1e fasin f* f. ." as 2 times the fasin function of 1"
  cr ." 4e 1e fatan f* f. " 4e 1e fatan f* f. ." as 4 times the fatan of 1"
  cr ." 0e -1e fatan2 f. " 0e -1e fatan2 f. ." as 0 -1 fatan2"
;
." |  ( -f- )"
showpi cr cr

: showG .( -f- )
  ." The universal gravitational constant G: " G f. ." _m^3/(s^2*kg)"
;
." |  ( -f- )"
see showG cr
showG cr cr
\ distance and velocity equations
\ ;;;; d = vo*t + 1/2 * a * t^2
\ ;;;; d = 1/2*[vo + vf]*t
\ ;;;; vf^2 = vo^2 + 2*a*d
\ ;;;; vf = vo + a * t
\ ;;;; d = v*t \ this is for constant speed
0e fvariable d d f!
0e fvariable a a f!
0e fvariable vo vo f!
0e fvariable vf vf f!
0e fvariable t t f!
: .d d f? ;
: .a a f? ;
: .vf vf f? ;
: .vo vo f? ;
: .t t f? ;

: .motionnotes .( --- )
  cr ." In the motion computations distances are in meters,"
  cr ." velocities and speeds are in meters per second and"
  cr ." time is in seconds. "
;
." |  ( --- )" 
see .motionnotes cr cr
.motionnotes cr

: .motionvars .( --- )
  cr ." The values of the motion variables are: "
  ." a = " .a ." d = " .d ." vf = " .vf
  ." vo = " .vo ." t = " .t cr
;
." |  ( --- )"
see .motionvars cr cr
.motionvars cr
\ cr .d .a .vf .vo .t cr
9.8e a f!
5e t f!
cr .( .a ) .a .( .t ) .t cr
: d1 .( --- )
  t f@ 2e f** a f@ f* 2e f/ t f@ vo f@ f* f+
;
." |  ( --- )"
see d1 cr cr

cr .( vo = ) .vo .( a = ) .a .( t = ) .t
cr .( d = vo*t + 1/2 * a * t^2, d: )
d1 fdup d f! f. ." _m. "
.motionvars cr
: d2 .( --- ) \ d = 1/2*[vo + vf]*t
  vo f@ vf f@ f+ t f@ f* 2e f/
;
." |  ( --- )"
see d2 cr cr

49e vf f!
cr .( vo = ) .vo .( t = ) .t
cr .( d = 1/2*[vo + vf]*t, d: ) d2 f. ." _m. "
.motionvars cr

cr .( Because see does not print out the stack comment, )
cr .( we use dot paren in the word definition to print a stack comment with )
cr .( ."  above the call to see to print an extended stack comment. )
cr .( The .( happens first, then the ." due to the way forth works. )
cr .( The word compiles and the .( happens, then the ." happens, )
cr .( then see displays the definition of the word. I use | at the beginning )
cr .( of the ." as a visual indicator to seperate the two stack comments.)
cr .( The -f- is the before and after stack seperator with the the f  )
cr .( indicating floating point stack, the data stack uses --- )
cr cr

: flog10 .( N -f- log10{N} )
  10e \ base 10 )
  fswap flog fswap flog f/ ;
." |  ( N -f- log10{N} )"
see flog10 cr cr

: flog2 .( N -f- log2{N} )
  2e \ base 2
  fswap flog fswap flog f/ ;
." |  ( N -f- log2{N} )"
see flog2 cr cr


: flogbN .( b N -f- logb{N} )
  flog fswap flog  f/ ;
\ This definition puts the base then the number on the fp stack
\ (N on TOS) which saves an fswap making it slightly more efficent.
\ It is also more general. The advantage of the flog10 and flog2
\ words is that they are slightly easier to use since they don't
\ require the user to enter the base onto the fp stack.
." |  b N -f- logb(N)"
see flogbN cr cr

cr .( 10e flog10 = ) 10e flog10 f. \ log10 of 10
cr .( 10e flog2 = ) 10e flog2 f.   \ log2 of 10
cr .( 2e 10e flogbN = ) 2e 10e flogbN f.  \ log2 of 10 using flogbN
cr .( 3e 100e flogbN = ) 3e 100e flogbN f. \ log 3 of 100 using flogbN
cr .( 5e 100e flogbN = ) 5e 100e flogbN f. \ log 5 of 100 using flogbN

cr
cr .( Checking our stacks: Data Stack: ) .s .( Floating point stack: ) f.s cr
: .done .( --- ) cr ." DONE!" cr ;
." |  ( --- )"
see .done cr cr

.done
