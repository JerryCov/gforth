0 [if]
      EarthRotations.fs
[then]

cr .( Variable display word; use it thus var1 f? ) cr
: f? .( var_addr -ps-  -fp- var_value ) f@ f. ; \ variable display word
see f?
cr .( Define the Earth's radius in three different units.)
cr .( Also define degrees to radians conversion constant) cr
3440e fconstant ERnmi ERnmi .( ERnmi = ) f. .( Earth radius in nautical miles.) cr \ (defconstant ERnmi 3440)
3959e fconstant ERsmi ERsmi .( ERsmi = ) f. .( Earth radius in statute miles.) cr \ (defconstant ERsmi 3959)
6371e fconstant ERkm ERkm .( ERkm = ) f. .( Earth radius in kilometers.) cr    \ (defconstant ERkm 6371)
pi 180.0e f/ fconstant D2R D2R .( D2R = ) f. .( D2R conversion constant.) cr  \ (defconstant D2R (/ pi 180.0))
cr .( Note: Latitudes 90 degrees is north pole, -90 degrees is south pole, 0 degrees is equator,)
cr .(   This is because by convention Northern latitudes and Western longitudes are positive,)
cr .(   and Southern latitudes and Eastern longitudes are negative.)
cr .(   Also by convention East and West are measured from the Prime Meridian [longitude])
cr .(   passing through Greenwitch, England with 0 degrees being from pole to pole)
cr .(   on the Greenwitch side of the globe and 180 degrees from pole to pole)
cr .(   on the opposite side of the globe.)
cr .(   Also note that the translational velocity is always with respect to the rotational axis.)
cr
0.0e fvariable latrad1 latrad1 f! \ We only need fvariable once to define the variable
cr .( First we compute the radius of the Earth at a given latitude latrad1.)
cr .( Thus, at 34 degrees latitude we have:)
cr .( ERNMI D2R 34.0e f* fcos f* latrad1 f!)
ERNMI D2R 34.0e f* fcos f* latrad1 f! \ (setf latrad1 (* ERNMI (cos (* D2R 34.0))))

cr .( latrad1 f?) 2 spaces latrad1 f? .( _nmi)
cr .( Next we compute translational velocity of rotation by latrad1 f@ 2.0e pi f* f* 24e f/ )
cr .( Translational velocity of rotation at 34.0 degrees latitude: ) latrad1 f@ 2.0e pi f* f* 24e f/ f.
.( _nmph.)

cr .( ERNMI D2R 0.0e f* fcos f* latrad1 f!)
ERNMI D2R 0.0e f* fcos f* latrad1 f! \ Now that it has been defined we can reuse it at will.
cr .( latrad1 f?) 2 spaces latrad1 f? .( _nmi)
cr .( Translational velocity of rotation at 0.0 degrees latitude: ) latrad1 f@ 2.0e pi f* f* 24e f/ f.
.( _nmph.)


0.0e latrad1 f! \ reset latrad1
cr .( ERSMI D2R 0.0e f* fcos f* latrad1 f!)
ERSMI D2R 0.0e f* fcos f* latrad1 f!
cr .( latrad1 f?) 2 spaces latrad1 f? .( _smi)
cr .( Translational velocity of rotation at 0.0 degrees latitude: ) latrad1 f@ 2.0e pi f* f* 24e f/ f.
.( _mph.)

0.0e latrad1 f! \ reset latrad1
cr .( ERKM D2R 0.0e f* fcos f* latrad1 f!)
ERKM D2R 0.0e f* fcos f* latrad1 f!
cr .( latrad1 f?) 2 spaces latrad1 f? .( _km)
cr .( Translational velocity of rotation at 0.0 degrees latitude: ) latrad1 f@ 2.0e pi f* f* 24e f/ f.
.( _kph.)

