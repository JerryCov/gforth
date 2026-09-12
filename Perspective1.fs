\ Perspective
\  A word about these files.  They are intended to demonstrate, among other things, how to write
\ words, therefore we are displaying the definitions as we go.  In an actual production program
\ typically the word definitions are never seen unless you are looking at the source code.
cr .( Define degrees to radians conversion constant d>r = )
pi 180e f/ fconstant d>r d>r f.
cr .( Define radians to degrees conversion constant r>d = )
180e pi f/ fconstant r>d r>d f.
cr .( To convert decimal degrees to radians multiply by d>r)
cr .( dd d>r f* -fp- r )
cr .( To convert radians to decimal degrees divide by r>d)
cr .( r d>r f/ -fp- dd )
cr .( or multiply by r>d)
cr .( r r>d f* -fp- dd ) cr
cr .( The floating point stack arrangements are displayed before the definitions here.)
cr cr
\ Notice my stack quoting technique to somewhat compensate for the shortcommings of see.
\ In the colon definition I use the .( ) to output a short form stack effect comment.
\ Then just before the see I use ." " to append a more detailed stack effect comment.
\ It works pretty well in Gforth, although other forths may not support this.
\ It works because .( ) happens at compile time and ." " happens at run time. However
\ gforth also allows ." " and .( ) to be used outside of a : ; definition, many forths do not.
\ For those forths that don't allow this you could define a word and use that instead.
\ Define our perspective words
: angular_size .( g r -fp- alpha )
  2e f* f/ fatan 2e f* ; \ 2 * arctan(g/(2 * r))
." , ( size, distance -fp- angle_alpha_in_radians. )"
see angular_size cr cr
 
cr .( When computing size or distance the results should never be negative ) cr
.( so both words end with fabs to ensure this outcome. ) cr

: actual_size .( r alpha -fp- g )
  2e f* ftan f* 2e f* fabs ; \ abs(2*tan(2 * alpha)*r))
." , ( distance, angle in radians -fp- size. )"
see actual_size cr cr

: distance .( g alpha -fp- r )
  2e f/ ftan 2e f* f/ fabs ; \ abs(g/(2 * tan(alpha/2)))
." , ( size, angle in radians -fp- distance. )"
see distance cr cr
cr

\ utility definitions
\ Documentation for how dms_to_dd works.
  \ degrees minutes seconds to decimal degrees
  \ dms_to_dd expects degrees minutes seconds on the fp stack, in that order
  \ minutes or seconds can be zero, if both are zero no conversion is necessary
  \ First divide TOFPS by 3600 to convert seconds, fswap to get minutes on top,
  \ divide by 60 to convert minutes, f+ to sum them fswap to get degrees on top,
  \ fdup so we can test the sign, put a zero on TOFPS, test with f<, if it's
  \ positive we just add using the else clause, if it's negative it gets a bit tricky,
  \ in the if clause we use f- but we want the result to be negative, so we fnegate.
  \ End of documentation for how dms_to_dd works.
: dms_to_dd .( d m s -fp- dd )
   3600e f/ fswap 60e f/ f+ fswap fdup 0e f< if f- fnegate else f+ then ;
." , ( degrees minutes seconds -fp- decimal_degrees )"
see dms_to_dd cr

\ ______________________________________________________________________________________
cr .( dms to dd conversion examples: ) cr
.( Check that both positive and negative degrees work the same.) cr
\ .( 31d 27' 28" dms_to_dd f. ) cr
.( 31e 27e 28e dms_to_dd f. )
31e 27e 28e dms_to_dd f. cr
.( -31e 27e 28e dms_to_dd f. )
-31e 27e 28e dms_to_dd f. cr
cr .( Close enough for government work! )
cr .( The following stack comment shows input and output on the fp stack.)
cr cr
\ Documentation for how dd_to_dms works
  \ First we fdup our input because we need to chop off the degrees and we
  \ do this by converting the float to a double which we also 2dup so we
  \ have a copy which is our degree result and a copy we can use to
  \ convert back to float to subtract the integer part off and multiply
  \ that fraction by 60.0 to get the minutes.  Then we rinse and repeat to get
  \ seconds from minutes. At this point we have 2 doubles on the data stack
  \ representing our degrees and minutes and we want to convert them back to
  \ floats so that everything is on the fp stack in the correct order.
  \ That is degrees on top, minutes in the middle, and seconds last
  \ so that we print it out or pass it on as Degrees Minutes Seconds. 
: dd_to_dms .( dd -fp- s m d ) \ degrees on top, then minutes, seconds on the bottom
  fdup f>d 2dup d>f f- 60e f* fabs \ chop off and save the degrees and convert minutes and make sure it's positive
  fdup f>d 2dup d>f f- 60e f* fabs \ chop off and save the minutes and convert seconds and make sure it's positive
  d>f d>f \ convert degrees and minutes (minutes first, degrees on top) back to floats and leave the results on 
; \ the fp stack.   The sign of the degrees is automaticlly preserved in this conversion routine.
  \ This is because the degree part undergoes no conversion because they are the same in either case.
  \ Amazingly this all happens with no swapping on either stack.
  \ This works because the sequence of operations we use leaves the results on the
  \ stack in the correct order.   
  \ End of documentation for how dd_to_dms works
\ ______________________________________________________________________________________
." , ( decimal_degrees -fp- seconds minutes degrees. )"
see dd_to_dms cr cr
cr .( dd to dms conversion examples: ) cr
.( 31.458e dd_to_dms ) 
31.458e dd_to_dms f. ." degrees " f. ." minutes " f. ." seconds." cr
.( -31.458e dd_to_dms ) 
-31.458e dd_to_dms f. ." degrees " f. ." minutes " f. ." seconds." cr
.( Check that both positive and negative degrees work the same.)
cr .( Close enough for government work! )

\ some rounding stuff
\ define a forth int word to chop off the decimal part
\ cr .( Note: Blue)
cr .( Note: in the next few stack comments ff stands for floating fraction,)
cr .( wf stands for whole float.) cr cr
: fint .( ff -fp- wf )
  f>d d>f ; \ float to double, double to float gives the whole part of the float
." , ( floating_fraction -fp- whole_part_of_fp_number. )"
see fint cr cr

: fround1 .( ff -fp- wf )
  0.5e f+ fint ; \ round up before we fint
." , ( floating_fraction -fp- rounded_whole_part_of_fp_number. )"
see fround1 cr cr
: f? f@ f. ; \ quick fvariable display word
see f? cr cr


cr

cr .( Problem Example)
: .problem .( -- )
  cr ." _________________________________________________________________________________"
  cr ." We want to know how far away a 2.5_in tennis ball would need to be"
  cr ." to appear to be the same size as the full moon."
  cr ." Since the full moon subtends 30 arcminutes, so must our ball."
  cr ." To exercise our function collection we will input the desired"
  cr ." apparent size in dms, so:" ;
.problem 
cr .( Set up our variables:)
cr .( 0e fvariable deg2 deg2 f!)
0e fvariable deg2 deg2 f!
cr .( 30.0 fvariable min2 min2 f!)
30.0e fvariable min2 min2 f!
cr .( 0e fvariable sec2 sec2 f!)
0e fvariable sec2 sec2 f!
cr .( 2.5e fvariable ball ball f!)
2.5e fvariable ball ball f!

cr ." deg2 = " deg2 f? .( min2 = ) min2 f? .( sec2 = ) sec2 f? .( ball = ) ball f?
cr .( Now we  need to convert our DMS to decimal degrees, then to radians.)
cr .( deg2 f@ min2 f@ sec2 f@ dms_to_dd fvariable angdd angdd f! )
deg2 f@ min2 f@ sec2 f@ dms_to_dd fvariable angdd angdd f!
cr .( angdd = ) angdd f? .( _dd)
cr .( angdd f@ d>r f* fvariable angrad angrad f!)
angdd f@ d>r f* fvariable angrad angrad f!
cr .( angrad = ) angrad f? .( _r)
cr .( Now we can compute the distance and output the results.)
cr .( 0e fvariable r2 r2 f! ) 3 spaces
0e fvariable r2 r2 f!  .( set up and compute our distance variable )
cr .( ball f@ angrad f@ distance r2 f! ) 3 spaces 
ball f@ angrad f@ distance r2 f!  .( do the math )
cr .( So our distance to observer is ) r2 f? .( _in or ) r2 f@ 12e f/ fdup f. .( _ft )
cr .( or very nearly ) fround1 f. .( feet.)
\ The fround1 word rounds a float up if the first digit of the fraction is 5 or greater
\ else it simply truncates the float to a whole number (still in float format) 
\ leaving only the whole number part on the fp stack where we can then f. it.  
   
cr
cr .( Stack Checks: Data Stack .s ) .s .( Floating Point Stack f.s ) f.s cr
cr .( Done! ) cr
