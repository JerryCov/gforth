\ ____________________________________________________________________________________
\ DegreeConversions.fs
\ Sun Aug 30 15:05:30 EDT 2026
: f? f@ f. ; \ fetch the value pointed to by the address on the data stack
\ to the fp stack then pop the fp stack and display the value fetched.
\ Typically used to display the value of an fvariable, like this: fv1 f?.
\ 
cr .( A predefined constant: )
cr .( pi f. ) pi f.
cr .( We define these constants: )
cr .( The following two constants will be handy if we need to deal with radians )
cr .( pi 180e f/ fconstant D2R D2R degrees to radians conversion constant: f. )
pi 180e f/ fconstant D2R D2R f.
cr .( 180e pi f/ fconstant R2D R2D radians to degrees conversion constant: f. )
180e pi f/ fconstant R2D R2D f.
cr .( Define and display the fconstant e, the base of natural logarithms: )
cr .( 1e fexp fconstant e e f. )1e fexp fconstant e e f.
cr
\ Define our conversion words:
\ Degrees Minutes Seconds to Decimal Degrees and
\ Decimal Degrees to Degrees Minutes Seconds
\ ______________________________________________________________________________________

\ Documentation for how dms_to_dd works.
  \ degrees minutes seconds to decimal degrees
  \ dms_to_dd expects degrees minutes seconds on the fp stack, in that order.
  \ Minutes or seconds can be zero, if both are zero no conversion is necessary
  \ First divide TOFPS by 3600.0 to convert seconds, fswap to get minutes on top,
  \ divide by 60.0 to convert minutes, f+ to sum them fswap to get degrees on top,
  \ fdup so we can test the sign, put a zero on TOFPS, test with f<, if it's
  \ positive we just add using the else clause, if it's negative it gets a bit tricky,
  \ in the if clause we use f- which returns a positive result but we want the
  \ result to be negative, so we fnegate.
\ End of documentation for how dms_to_dd works.
: dms_to_dd .( d m s -fp- dd )
   3600e f/ fswap 60e f/ f+ fswap fdup 0e f< if f- fnegate else f+ then ;


\ The old version, it works but it is too clumsy
\ : dms_to_dd .( d m s -fp- dd ) \ Using .( ) gives a printed stack effect before we use see.
\   frot fdup 0e f< if frot frot 3600e f/ fswap 60e f/ f+ f- \ subtract the sum from -degrees
\                   else frot frot 3600e f/ fswap 60e f/ f+ f+ \ just add the sum to degrees 
\ 		  then 
\ ;

\ ______________________________________________________________________________________
cr ." ( degrees minutes seconds -fp- decimal_degrees )"
see dms_to_dd cr
\ ______________________________________________________________________________

cr .( First we test our dms_to_dd word:)
cr .( 45e 30e 36e dms_to_dd fdup f. ) 45e 30e 36e dms_to_dd fdup f.
cr .( We fdup our result so we can use it to test our dd_to_dms word.)
cr .( -45e 30e 36e dms_to_dd fdup f. ) -45e 30e 36e dms_to_dd fdup f.
cr .( We fdup our result so we can use it to test our dd_to_dms word.)

cr cr
\ Document how dd_to_dms works
  \ First we fdup our input because we need to chop off the degrees and we
  \ do this by converting the float to a double which we also 2dup so we
  \ have a copy which is our degree result and a copy we can use to
  \ convert back to float to subtract the integer part off and multiply
  \ that fraction by 60.0 to get the minutes.  Then we rinse and repeat to get
  \ seconds from minutes At this point we have 2 doubles on the data stack
  \ representing our degrees and minutes and we want to convert them back to
  \ floats so that everything is on the fp stack in the correct order.
  \ That is degrees on top minutes in the middle and seconds last
  \ so that we print it out or pass it on as Degrees Minutes Seconds. 
\ End of documentation for how dd_to_dms works.
: dd_to_dms .( decimal_degrees -fp- degrees minutes seconds)
  fdup f>d 2dup d>f f- 60e f* fabs \ chop off and save the degrees and convert minutes and make sure it's positive
  fdup f>d 2dup d>f f- 60e f* fabs \ chop off and save the minutes and convert seconds and make sure it's positive
  d>f d>f \ convert degrees and minutes back to floats and leave the results on the fp stack.
;
  \ The sign of the degrees is automaticlly preserved in this conversion routine.
  \ This is because the degree part undergoes no conversion because they are the same in either case.
  \ Amazingly this all happens with no swapping on either stack.
  \ This works because the sequence of operations we use leaves the results on the
  \ stack in the correct order.   
\ ______________________________________________________________________________
\ Further notes: This conversion occurs in 3 stages the first two of which
\ are identical, the last stage just converts the double integer results
\ and puts them on the fp stack (as floats of course). In each of the first two
\ stages we have to duplicate the float because we need it twice, once to
\ convert it to a double int which is 2duped on the data stack and next to
\ have the double int reconverted to a float which we then subtract and
\ multiply the result by 60.0 to generate minutes in the first stage and
\ seconds in the second stage. We leave the seconds as a float so that
\ the decimal fractional part remains, thus increasing the accuracy.
\ The double ints left behind on the data stack is our degrees result for the
\ first stage and our minutes result for the second stage.  These are what the
\ final stage converts back to floats on the fp stack, leaving degrees on top.
\ End dd_to_dms documentation
\ ______________________________________________________________________________

\ cr ." ( decimal_degrees -fp- degrees minutes seconds)"
see dd_to_dms 

cr
cr .( Second we test our dd_to_dms word:)
cr .( And then we fdup it again so we can display it as an input value.)
cr .( fdup f. ) fdup f. .( dd_to_dms ) dd_to_dms .( f. f. f. ) f. f. f. cr
cr .( fdup f. ) fdup f. .( dd_to_dms ) dd_to_dms .( f. f. f. ) f. f. f. cr
cr .( Our second conversion word is well within reasonable tolerence )

cr .( so I calls it good!)
cr
\ ______________________________________________________________________________

\ Here we use our conversion functions with floating point variables.
\ Set up some floating point variables
0e fdup fdup fdup \ Zeros for initializing our fvariables
fvariable DecDegrees DecDegrees f!
fvariable Degrees Degrees f!
fvariable Minutes Minutes f!
fvariable Seconds Seconds f!
0e fdup fdup
fvariable deg deg f!
fvariable miu miu f! \ we use miu instead of min because min is a predefined forth word
fvariable sec sec f!
34.095582e fvariable lat1 lat1 f! \ My home latitude
-81.18525e fvariable long1 long1 f! \ My home longitude

\ Do some display words
\ display the contents of an fvariable
\ like this: deg f?
\ Just as an aside, to display an fconstant we just use f. because fconstants
\ are defined so that just naming them puts their value on the fp stack, so for
\ example pi f. prints out the value of pi:

\ display our fvariables
cr .( cr DecDegrees f? ) DecDegrees f?
cr .( cr Degrees f? ) Degrees f?
cr .( cr Minutes f? ) Minutes f?
cr .( cr Seconds f? ) Seconds f?
\ Set Degrees, Minutes, and Seconds
cr .( 45e degrees f!)45e degrees f!
cr .( 30e minutes f!)30e minutes f!
cr .( 36e seconds f!)36e seconds f!
cr .( degrees f@ minutes f@ seconds f@ dms_to_dd fdup f. )
degrees f@ minutes f@ seconds f@ dms_to_dd fdup f. .( decimal degrees )
cr fdup f. .( dd_to_dms deg f! miu f! sec f! )
dd_to_dms deg f! miu f! sec f!
cr .( deg f? miu f? sec f? ) deg f? miu f? sec f?
cr .( The conversion difference is: seconds f@ sec f@ f- f. )
seconds f@ sec f@ f- f.
cr
cr .( lat1 in decimal degrees ) lat1 f?
cr .( long1 in decimal degrees ) long1 f?
cr .( lat1 in degrees minutes seconds: lat1 f@ dd_to_dms f. f. f. )
lat1 f@ dd_to_dms f. .( _d ) f. .( _m ) f. .( _s )
cr .( long1 in degrees minutes seconds: long1 f@ dd_to_dms f. f. f. )
long1 f@ dd_to_dms f. .( _d ) f. .( _m ) f. .( _s )
cr
cr .( Now a few temp fvariables we can use to quickly display the output from dd_to_dms)
0e fdup fdup fvariable d1 d1 f!
fvariable m1 m1 f!
fvariable s1 s1 f!
cr .( d1, m1, s1)
cr .( and now the utility display words) 
cr .( dms1 calls dd_to_dms and stores the results in the temp fvars,)
cr .( .dms1 recalls the results and displays them.) cr
: .dms1 .( -fp- ) d1 f? m1 f? s1 f? ;
see .dms1 cr
: dms1 .( -fp- ) dd_to_dms d1 f! m1 f! s1 f! ; \ a word to store the results of dd_to_dms
see dms1 cr
cr .( use dms1 thus 35.6254e dms1 to store the results in the temp fvars, then)
cr .( use .dms1 to display the results.)
cr .( You can also store d1 m1 s1 elsewhere if you will need them later.)
cr .( 35.6254e dms1) 35.6254e dms1
cr .( .dms1 ) .dms1
cr .( My home latitude in decimal degrees: ) lat1 f?
cr .( My home longitude in decimal degrees: ) long1 f?

cr ." My home latitude in degrees minutes seconds: " lat1 f@ dms1 .dms1
cr .( My home longitude degrees minutes seconds: ) long1 f@ dms1 .dms1
cr

cr .( Check our stacks status, Data: ) .s .( Floating Point: ) f.s cr
cr .( If both stacks are zero we hopefully don't have any serious problems!)
cr .( And we're Done!)

