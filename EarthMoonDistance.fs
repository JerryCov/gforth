0 [if] This is the forth work-around for multi line comments.
       EarthMoonDistance.fs
       ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
       ;;;; Distance to the moon
       ;;;; from a Martymer 81 video
       ;;;; r = (d/2)/(tan(p/2))
       ;;;; r is distance to the moon
       ;;;; d is distance between two observers on the Earth
       ;;;; p is the parallax angle between the observers and the moon
       ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
       ; the closing bracket-then keyword below terminates the multiline comment.
[then]
cr .( Word to display value of a floating point variable.) cr 
: f? .( fvar-addr -ds- ) f@ f. ;
see f? cr
cr .( Distance to the moon from Earth.)
cr .( There is a diagram for this file in the EarthMoonDistance/images subfolder.)
cr .( It can be viewed by double clicking on it.)
cr .( Now some basic stuff:)
cr ." r = ((d/2)/(tan(p/2))) The distance equation we'll be using."
cr .( r is distance to the moon)
cr .( d is distance between two observers on the Earth)
cr .( p is the parallax angle between the observers and the moon)

cr pi 180.0e f/ fconstant D2R D2R .( D2R = ) f. .( Degrees to radians conversion constant.)cr
0e fvariable d d f! \ distance to object on Flat Earth
0e fvariable p p f! \ observed angle in decimal degrees
0e fvariable r r f! \ approximated distance to object on Flat Earth
0e fvariable ra ra f! \ distance to object on Globe Earth ;; This variable allows us to show the difference
0e fvariable gr gr f! \ approximated distance to object on Globe Earth ;; in accuracy between Flat and Globe Earth
0e fvariable gra gra f! \ approximated distance to object on Globe Earth ;; in accuracy between Flat and Globe Earth
\ ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
\ ;;;; Define our functions here
cr .( Our functions [words] are as follows:)
cr
: accudistance .( d p -fp- dist)
  \ Compute distance accurately. The angle p is given in decimal degrees and must be
  \  converted to radians for the tan function to work correctly, hence
  \  the conversion constant."
  \ (/ (/ d 2) (tan (* D2R (/ p 2))))) ;; Notice here that the angle is halved before we convert to radians.
  \ The distance is found by halving the distance d between two observers, then
  \ dividing by the tangent of half of the angle p (the angle being converted to radians as stated above).
  2e f/ D2R f* ftan fswap 2e f/ fswap f/
;
see accudistance
cr cr
: approxDist .( d p -fp- distapprox)
  \ "Compute approximated distance.  Divide the distance between two observers, d by the
  \  tangent of the angle p in radians"
  \ (/ d (tan (* D2R p))))
  D2R f* ftan f/
;
see approxDist
cr
\ ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
\ ;;;; Use the functions here
cr .( Flat Earth distance calculations:)
10200e d f! \ Observer distance in kilometers (Flat Earth)
1.42e p f! \ Observation angles in degrees
d f@ p f@ accudistance r f! \ Compute the distance and store it as r
cr .( d f@ p f@ accudistance r f!)
\ display the result
cr .( observer seperation distance ) d f? .( _km, observed angle ) p f? .( _d: calculated accurate distance ) r f? .( _km)
d f@ p f@ approxDist ra f! \ Compute the approximate distance and store it as ra
cr .( d f@ p f@ approxDist ra f!)
\ display the result
cr .( observer seperation distance ) d f? .( _km, observed angle ) p f? .( _d: calculated approximated distance ) ra f? .( _km)
\ Display the difference between the accurate and approximate results 
cr .( The difference between the accurate observer distance and the approximation is ) r f@ ra f@ f- f. .( _km)
cr .( Globe Earth calculations:)
9100.0e d f! \ The angle is the same for both calculations, so we only have to change observer distance here
cr .( Change the observer seperation distance to Globe value: 9100.0e d f!)
d f@ p f@ accudistance gr f! \ Compute the distance and store it as gr
cr .( d f@ p f@ accudistance gr f!)
cr .( observer seperation distance ) d f? .( _km, observed angle ) p f? .( _d: calculated accurate distance ) gr f? .( _km)
d f@ p f@ approxDist gra f! \ Compute the approximate distance and store it as gra
cr .( d f@ p f@ approxDist gra f!)
cr .( observer seperation distance ) d f? .( _km, observed angle ) p f? .( _d: calculated approximated distance ) gra f? .( _km)
\ Display the difference between the accurate and approximate results 
cr .( The difference between the accurate observer distance and the approximation is ) gr f@ gra f@ f- f. .( _km)

cr \ Compute the difference between Flat and Globe calculations and display them
cr .( The difference between the accurate observer distance Flat Earth and Globe Earth is ) r f@ gr f@ f- f. .( _km)
cr .( The difference between the approximate observer distance Flat Earth and Globe Earth is ) ra f@ gra f@ f- f. .( _km)
cr .( The difference between the two: r f@ gr f@ f- ra f@ gra f@ f- f- f. ) r f@ gr f@ f- ra f@ gra f@ f- f- f. .( _km)
