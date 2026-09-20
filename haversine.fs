\ gforth ./haversine.fs -e bye

: hi ( -- ) cr ." Hello there." cr ;
hi
cr .( IMPORTANT NOTICE! If you want to use these functions in other files be ) cr
.( absolutly certain to copy all of these required constants to go with them. ) cr
.( Also grab any of the utility conversion words you might need. ) cr
\ define some constants
cr .( First we define a couple of floating point constants we will need.)
cr .( D2R is the degrees to radians conversion constant.)
pi 180e f/ fconstant D2R
cr .( D2R is: ) D2R f. cr
6371e fconstant Erkm \ Earth's radius in kilometers
3959e fconstant ErSmi \ Earth's radius in miles
3440e fconstant ErNmi \ Earth's radius in nautical miles
cr .( ErNmi is the earth's radius in nautical miles.) cr
.( ErNmi is: ) ErNmi f. cr cr
.( ErSmi is the earth's radius in statute miles.) cr
.( ErSmi is: ) ErSmi f. cr cr
.( Erkm is the earth's radius in kilometers.) cr
.( Erkm is: ) Erkm f. cr cr
: f? .( addr_of_value --  -fp- ) f@ f. ; \ destructively display the top item on the fp stack
see f? cr cr


\ haversine on the stack
\ utility definitions
\ ________________________________________________________________________________________
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
: dms_to_dd .( d m s -fp- dd ) \ The input: seconds on top, minutes next, degrees on the bottom
   3600e f/ fswap 60e f/ f+ fswap fdup 0e f< if f- fnegate else f+ then ;

\ ________________________________________________________________________________________
." :( degrees minutes seconds -fp- decimal_degrees )." \ A more detailed stack effect
see dms_to_dd cr  \ List our word definition.
cr .( dms to dd conversion examples: ) cr
.( 31e 27e 28e dms_to_dd f. )
31e 27e 28e dms_to_dd f. cr
.( -31e 27e 28e dms_to_dd f. )
-31e 27e 28e dms_to_dd f. cr
.( Check positive and negative degrees work the same.) cr cr
\ Documentation of how dd_to_dms works
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
: dd_to_dms .( dd -fp- deg mins sec ) \ Using .( ) gives a printed stack effect before we use see.
  fdup f>d 2dup d>f f- 60e f* fabs \ chop off and save the degrees and convert minutes and make sure it's positive
  fdup f>d 2dup d>f f- 60e f* fabs \ chop off and save the minutes and convert seconds and make sure it's positive
  d>f d>f \ convert degrees and minutes back to floats and leave the results on the fp stack.
;
  \ The sign of the degrees is automaticlly preserved in this conversion routine.
  \ This is because the degree part undergoes no conversion because they are the same in either case.
  \ Amazingly this all happens with no swapping on either stack.
  \ This works because the sequence of operations we use leaves the results on the
  \ stack in the correct order.   
  \ End of documentation of how dd_to_dms works
\ ________________________________________________________________________________________
." :( decimal_degrees -fp- degrees minutes seconds )." \ A more detailed stack effect
see dd_to_dms cr  \ List our word definition.
cr .( dd to dms conversion examples: ) cr
.( 31.458e dd_to_dms ) 
31.458e dd_to_dms  f. ." degrees " f. ." minutes " f. ." seconds." cr
.( -31.458e dd_to_dms ) 
-31.458e dd_to_dms  f. ." degrees " f. ." minutes " f. ." seconds." cr
.( Check positive and negative degrees work the same.) cr cr


: .info ( -- )
    cr ." We will be using the haversine formula to find the distance between"
    cr ." two points on the Earth's surface.  To do so, we will first compute"
    cr ." the sin squared of half the difference between the latitudes.  Next we take"
    cr ." the cosines of the two latitudes, and then we take the sin squared of half the"
    cr ." difference between the longitudes. This leaves us with four values on the"
    cr ." floating point stack.  Next we multiply the top three items then add that to"
    cr ." the final item, this result is our haversine formula result.  To get the"
    cr ." distance in nautical miles, we take the square root of our haversine,"
    cr ." take the arcsine of that, and multiply it by two times the radius of"
    cr ." the Earth in nautical miles."
    cr ." If we are given Degrees minutes seconds, use the handy utility dms_to_dd to convert to"
    cr ." decimal degrees for our trig functions as shown in the example above."
    cr ." Remember not to f. it away before fduping it for later use. (or just don't f. it at all)"
    cr
;
.info
: .Note1 ( -- )
    cr ." The easist way to make a floating point number and put it on the fp stack"
    cr ." is to end the number with an e, with no space between the number and the e."
    cr ." What this does is tell the number input routine to convert the number to"
    cr ." floating point format and push it to the fp stack."
    cr
;
: .Note2 ( -- )
    cr ." In actual use we would probably round this result to 1244 nMi."
;
cr .( In the following, we fdup our intermediate results so we can f. them as we go. ) cr
.( In actual practice we wouldn't bother with this and we would only fdup and f. the final result ) cr
.( if we needed it for further processing, [like maybe storing it in an fvariable for later.] ) cr
.( It all depends on what we may be doing with it obviously. ) cr

cr .( haversine on the stack: ) cr
.( 8.52e 2e f/ D2R f* fsin 2e f** fdup f. )
8.52e 2e f/ D2R f* fsin 2e f** fdup f. cr
.( 41.98e D2R f* fcos fdup f. )
41.98e D2R f* fcos fdup f. cr
.( 33.45e D2R f* fcos fdup f. )
33.45e D2R f* fcos fdup f. cr 
.( 24.16e 2e f/ D2R f* fsin 2e f** fdup f. )
24.16e 2e f/ D2R f* fsin 2e f** fdup f. cr
.( f* f* f+ fdup f. )
f* f* f+ fdup f. cr
.( 2e 1/f f** fasin 2e ErnMi f* f* fdup f. )
2e 1/f f** fasin 2e ErnMi f* f* fdup f. .( nautical miles ) cr
.Note2

cr f.s .( This is left on the fp stack by the final fdup) cr
fdrop \ we never use this later so we fdrop it here to keep our fp stack clean
.Note1 
.( To see how we did this:  )    
cr .( 8.52e 2e f/ D2R f* fsin 2e f** fdup f.)
cr .( 41.98e D2R f* fcos fdup f.)
cr .( 33.45e D2R f* fcos fdup f.)
cr .( 24.16e 2e f/ D2R f* fsin 2e f** fdup f. cr)
cr .( f* f* f+ fdup f.)
cr .( 2e 1/f f** fasin 2e ErnMi f* f* fdup f.)
cr .( The second to last result is our haversine formula result in radians,)
cr .( and of course the final result is the distance in nautical miles.)
cr .( We also did a nondestrutive fp stack print to show that we kept)
cr .( a copy of the result on the fp stack for further use if needed.) cr
cr .( And now for some definitions to make life with haversines easier.)
: .info2 ( -- )
    cr ." To use these defintions to find distance in nautical miles:"
    cr ." put the difference in latitudes in decimal degrees on the fp stack and use haversin,"
    cr ." put the first latitude in decimal degrees on the fp stack and use dfcos,"
    cr ." put the second latitude in decimal degrees on the fp stack and use dfcos,"
    cr ." put the difference in longitudes in decimal degrees on the fp stack and use haversin again,"
    cr ." then use haverform to combine the values to complete the haversine formula,"
    cr ." then use haverdistNmi to finally compute the distance in nautical miles."
    cr ." At this point the result is on the fp stack where you can fdup and f. it,"
    cr ." saving a copy for future use or simply f. it according to your current needs."
    cr ." Notice that this can all be done in a single line from the keyboard,"
    cr ." or loaded in a file as in the last line in this file."
    cr ." To compute the distance in statute miles, simply use haverdistSmi instead of"
    cr ." haverdistNmi, for kilometers use haverdistkm."
    cr
;
cr .( The following 6 words do not affect the data stack. ) cr
.( The following 6 words all have the following floating point stack effect: ) cr
." ( -fp- result )" cr
: haversin  2e f/ D2R f* fsin 2e f** 
	    \ divide the input angle by 2, multiply by our conversion factor,
	    \ take the sin and square it.
;
: haverform f* f* f+ 
            \ multiply the top 3 items and add the forth, yielding our haversine
;
: haverdistNmi 2e 1/f f** fasin 2e ErnMi f* f*
	    \ This word takes the square root of the top of the fp stack
	    \ (2e 1/f f** is forth's square root), then takes the arcsine of
	    \ that (the step the haversine formula actually requires -- distance
	    \ is 2*R*asin(sqrt(a)), not just 2*R*sqrt(a)), the first f* doubles
	    \ ErNmi, the second multiplies by the arcsine, yielding result in nautical miles
;
: haverdistSmi 2e 1/f f** fasin 2e ErSmi f* f*
	    \ This word takes the square root of the top of the fp stack
	    \ (2e 1/f f** is forth's square root), then takes the arcsine of
	    \ that (the step the haversine formula actually requires -- distance
	    \ is 2*R*asin(sqrt(a)), not just 2*R*sqrt(a)), the first f* doubles
	    \ ErSmi, the second multiplies by the arcsine, yielding result in statute miles
;
: haverdistkm 2e 1/f f** fasin 2e Erkm f* f*
	    \ This word takes the square root of the top of the fp stack
	    \ (2e 1/f f** is forth's square root), then takes the arcsine of
	    \ that (the step the haversine formula actually requires -- distance
	    \ is 2*R*asin(sqrt(a)), not just 2*R*sqrt(a)), the first f* doubles
	    \ Erkm, the second multiplies by the arcsine, yielding result in kilometers
;
: dfcos D2R f* fcos 
	\ converts input decimal degrees to radians for fcos, you can use this technique
	\ for any forth trig function
;
\ dfcos is a utility word that takes a decimal degree value on the fp stack
\ and converts it to radians and then takes the cosine of it.


\ list our definitions
see haversin cr
see haverform cr
see haverdistNmi cr
see haverdistSmi cr
see haverdistkm cr
see dfcos cr
cr .( dfcos is a utility word that takes a decimal degree value on the fp stack)
cr .( and converts it to radians and then takes the cosine of it.)
cr .info2
cr .( An example of using haversin: 8.52e haversin f.)
cr 8.52e haversin f.
cr .( 8.52e haversin 41.98e dfcos 33.45e dfcos 24.16e haversin haverform haverdistNmi )
cr 8.52e haversin 41.98e dfcos 33.45e dfcos 24.16e haversin haverform haverdistNmi 
.( And our result is: ) f. .( nautical miles.) cr 

cr .( 8.52e haversin 41.98e dfcos 33.45e dfcos 24.16e haversin haverform haverdistSmi )
cr 8.52e haversin 41.98e dfcos 33.45e dfcos 24.16e haversin haverform haverdistSmi 
.( And our result is: ) f. .( statute miles.) cr

cr .( 8.52e haversin 41.98e dfcos 33.45e dfcos 24.16e haversin haverform haverdistkm )
cr 8.52e haversin 41.98e dfcos 33.45e dfcos 24.16e haversin haverform haverdistkm 
.( And our result is: ) f. .( kilometers.) cr


0e fvariable myLat myLat f!
0e fvariable myLon myLon f!
34.0e fvariable degLat1 degLat1 f! \ my latitude degrees
5.0e fvariable minLat1 minLat1 f! \ my latitude minutes
43.996e fvariable secLat1 secLat1 f! \ my latitude seconds

81.0e fvariable degLon1 degLon1 f! \ my longitude degrees
11.0e fvariable minLon1 minLon1 f! \ my longitude minutes
7.033e fvariable secLon1 secLon1 f! \ my longitude seconds

degLat1 f@ minLat1 f@ secLat1 f@ dms_to_dd myLat f! \ convert my latitude from DMS to DD
degLon1 f@ minLon1 f@ secLon1 f@ dms_to_dd myLon f! \ convert my longitude from DMS to DD
cr \ display latitude and longitude in DMS
." degLat1 = " degLat1 f? ." minLat1 = " minLat1 f? ." secLat1 = " secLat1 f? cr
." degLon1 = " degLon1 f? ." minLon1 = " minLon1 f? ." secLon1 = " secLon1 f? cr
 \ display latitude and longitude in DD
." myLat = " myLat f? cr
." myLon = " myLon f? cr

0e fvariable Lat2 Lat2 f!
0e fvariable Lon2 Lon2 f!
30.0e fvariable degLat2 degLat2 f!
15.0e fvariable minLat2 minLat2 f!
49.575e fvariable secLat2 secLat2 f!

83.0e fvariable degLon2 degLon2 f!
17.0e fvariable minLon2 minLon2 f!
27.047e fvariable secLon2 secLon2 f!

degLat2 f@ minLat2 f@ secLat2 f@ dms_to_dd Lat2 f!
degLon2 f@ minLon2 f@ secLon2 f@ dms_to_dd Lon2 f!
cr
." degLat2 = " degLat2 f? ." minLat2 = " minLat2 f? ." secLat2 = " secLat2 f? cr
." degLon2 = " degLon2 f? ." minLon2 = " minLon2 f? ." secLon2 = " secLon2 f? cr

." Lat2 = " Lat2 f? cr
." Lon2 = " Lon2 f? cr

0e fvariable degLat3 degLat3 f!
0e fvariable minLat3 minLat3 f!
0e fvariable secLat3 secLat3 f!
0e fvariable degLon3 degLon3 f!
0e fvariable minLon3 minLon3 f!
0e fvariable secLon3 secLon3 f!


30.3055e fvariable Lat3 Lat3 f!
80.4505e fvariable Lon3 Lon3 f!

Lat3 f@ dd_to_dms degLat3 f! minLat3 f! secLat3 f!
Lon3 f@ dd_to_dms degLon3 f! minLon3 f! secLon3 f!
cr
." Lat3 = " Lat3 f? ." ,degLat3 = " degLat3 f? ." ,minLat3 = " minLat3 f? ." ,secLat3 = " secLat3 f? cr
." Lon3 = " Lon3 f? ." ,degLon3 = " degLon3 f? ." ,minLon3 = " minLon3 f? ." ,secLon3 = " secLon3 f? cr


.( Lat2 f@ Lat3 f@ f- f. ) Lat2 f@ Lat3 f@ f- f. cr
.( Lon2 f@ Lon3 f@ f- f. ) Lon2 f@ Lon3 f@ f- f. cr

.( Lat3 f@ Lat2 f@ f- f. ) Lat3 f@ Lat2 f@ f- f. cr
.( Lon3 f@ Lon2 f@ f- f. ) Lon3 f@ Lon2 f@ f- f. cr



cr .( Checking our stacks: Data Stack: ) .s .( Floating point stack: ) f.s cr
.( Done!) cr
