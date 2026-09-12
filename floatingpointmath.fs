\ floatingpointmath.fs
\ gforth ./floatingpointmath.fs
\ to gforth a file using relative paths, do this:
\ gforth ./filename
.( First show some environment stuff. ) cr
s" gforth" environment? [IF] .( Gforth version ) TYPE
                        [ELSE] .( Not Gforth ) [THEN] cr
environment-wordlist >order words previous cr

100e 5e 1/f f** fconstant sm \ define the base of stellar magnitudes
cr ." The base of astronomical brightness magnitudes sm: " sm f. cr \ display it with explanitory text
5e 2e 1/f f** 1e f+ 2e f/ fconstant phi \ define the Golden Ratio
cr ." The Golden Ratio, phi: " phi f. cr \ display it with explanitory text
5e 2e 1/f f** 1e f- 2e f/ fconstant ihp \ define the inverse of the Golden Ratio
cr ." The inverse of the Golden Ratio, ihp: " ihp f. cr \ display it with explanitory text
." The fconstant pi is predefined in gforth."
cr ." pi = " pi f. cr
\ in the following n or b is a floating point number: example 33e, where the e forces the number onto the fp stack
\ the natural log in gforth is fln, common logs is flog, logs any base is n fln b fln f/
\ exponential is n fexp
: flogbn ( b n -fp- logbn ) fln fswap fln f/ ;
cr .( b n -fp- logbn ) 
see flogbn cr
1e fexp fconstant e \ make the base of natural logs and display same.
cr ." The base of natural logarithms is: " e f. cr

: .descParsec .( --- )
    cr ." The parsec is defined as the cotangent of 1 arc-second."
    cr ." One arc-second is 1/3600th of one degree. In gforth all"
    cr ." trig functions expect their arguments to be in radians."
    cr ." Thus we make a degrees to radians conversion factor by "
    cr ." dividing pi by 180.0 which we name d2r."
    cr ." To compute the parsec therefore we take the"
    cr ." floating point inverse of 3600, multiply by our conversion"
    cr ." factor, take the tangent, and finally take the inverse of that"
    cr ." to get the cotangent."
;
." ( --- ) "
see .descParsec cr
.descParsec cr
pi 180e f/ fconstant d2r ( degrees to radians )
.( Compute the parsec in gforth. )
3600e 1/f d2r f* ftan 1/f fconstant psec ( compute the parsec)
.( 3600e 1/f d2r f* ftan 1/f fconstant psec )
cr .( The parsec is: ) psec f. cr

149597870700e fconstant AUM \ the astronomical unit in meters

: nexps ( n -- )
    \ Obviously this will generate n fp values
    \ dup the index and mod it with 5 to make 5 columns
    \ then pump out a cr to start the next row.
    \ convert the remaining index to float, get the exp of it
    \ and fprint it to clear the fp stack for the next round
    dup cr ." Generate the exponentials of the first " . ." integers: " 
    0 do i dup dup 5 mod 0 = if cr THEN s>f fexp f. loop \ we convert the count to float because...
    \ we can include 0 here because exp(0) is 1
;
\ examples
34 nexps cr
35 nexps cr

: nlns ( n -- )
    \ Obviously this will generate n fp values
    \ dup the index and mod it with 6 to make 6 columns
    \ then pump out a cr to start the next row.
    \ convert the remaining index to float, get the log of it
    \ and fprint it to clear the fp stack for the next round
    dup cr ." Generate the natural logs of the first " . ." integers: " cr
    1+ 1 do i dup 6 mod 0 = if cr then s>f fln f. loop \ we convert the count to float because...
    \ We skip zero because ln(0) is undefined, also we add 1 to the loop count
    \ when we start because we need to account for the fact that we are not
    \ including zero (we skipped it as noted above) and we want to generate n values.
;
: nlogs ( n -- )
    \ Obviously this will generate n fp values
    \ dup the index and mod it with 6 to make 6 columns
    \ then pump out a cr to start the next row.
    \ convert the remaining index to float, get the log of it
    \ and fprint it to clear the fp stack for the next round
    dup cr ." Generate the common logs of the first " . ." integers: " cr
    1+ 1 do i dup 6 mod 0 = if cr then s>f flog f. loop \ we convert the count to float because...
    \ We skip zero because log(0) is undefined, also we add 1 to the loop count
    \ when we start because we need to account for the fact that we are not
    \ including zero (we skipped it as noted above). and we want to generate n values.
;
\ more examples
cr 
34 nlns cr
35 nlns cr cr 
34 nlogs cr cr 
35 nlogs cr
48 nlogs cr
cr
.( Demonstrate the logs to any base function [word] flogbn.) cr
.( b n flogbn; that is base and number on fp stack in that order ) cr
.( The commmon log of 1000:) cr
.( 10e 1000e flogbn f. )
10e 1000e flogbn f. cr
.( The base 2 log of 1000:) cr
.( 2e 1000e flogbn f. )
2e 1000e flogbn f. cr
cr
\ random numbers
require ./random.fs
\ generate 10 random numbers from 1 to n
\ the dup in the loop ensures that n is
\ available for random each time through the loop
\ To clean up the stack we must drop the final dup
\ which doesn't get used.
: main ( n -- ) 10 0 do dup i cr . random . loop drop ;
.( Random numbers...) cr 
utime drop seed ! \ generate a fresh seed for the random number generator based on current time
.( rnd . ) rnd . cr
cr .( 10 random numbers from 1 to 300 ) cr 
300 main cr
cr .( 10 random numbers from 1 to 1000 ) cr 
1000 main cr
cr .( Show that our stacks are clean: )
cr .( data stack ) .s .( floating point stack ) f.s cr
cr .( Done ) cr
