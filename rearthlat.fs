: .showtime ( -- ) cr \ time is hh mm ss
	   time&date \ date is:  year, month, day
	   ." Date: " . ." / " . ." / " . cr
	   ." Time: " . ." : " . ." : " . cr ;
\ cr see .showtime cr
.showtime
cr
\ reue = radius earth units equator, lat latitude in degrees, radius earth in units
\ requires fconstant d>r defined as pi 180e f/ fconstant d>r, usually defined by caller
\ uncomment following line if d2r not defined by caller
\ pi 180e f/ fconstant d2r
: .explain ( -- )cr
	  ." relat expects the radius of Earth at the equator and the lattitue of" cr
	  ." interest and returns the radius of the Earth at that latitude with" cr
	  ." respect to the spin axis. It works for both north{+} and south{-} latitudes." cr
	  ." The input radius is given in nautical miles _nmi, statute miles _smi, or " cr
	  ." kilometers _km, the returned radius is in the same units." cr
	  ." The latitiude is given in decimal degrees." cr
	  ." 0 degrees is the equator, +90 is the north pole, -90 is the south pole." cr
	  cr ;

cr .explain
3040e fconstant re_nmi
3959e fconstant re_smi
6371e fconstant re_km
\ reue = radius earth units equator, lat latitude in degrees, radius earth in units
\ requires fconstant d>r defined as pi 180e f/ fconstant d>r
pi 180e f/ fconstant d2r
: relat ( reue lat -- reu ) d2r f* fcos f* ;

cr .( re_nmi 0e relat f. ) re_nmi 0e relat f. .( _nmi)
cr .( re_nmi 38e relat f. ) re_nmi 38e relat f.
cr .( re_nmi 90e relat f. ) re_nmi 90e relat f.
cr

cr .( re_nmi 0e relat f. ) re_nmi 0e relat f.
cr .( re_nmi -38e relat f. ) re_nmi -38e relat f.
cr .( re_nmi -90e relat f. ) re_nmi -90e relat f.
cr

cr .( re_smi 0e relat f. ) re_smi 0e relat f.
cr .( re_smi -38e relat f. ) re_smi 38e relat f.
cr .( re_smi 90e relat f. ) re_smi 90e relat f.
cr

cr .( re_smi 0e relat f. ) re_smi 0e relat f.
cr .( re_smi -38e relat f. ) re_smi -38e relat f.
cr .( re_smi -90e relat f. ) re_smi -90e relat f.
cr

cr .( re_km 0e relat f. ) re_km 0e relat f.
cr .( re_km 38e relat f. ) re_km 38e relat f.
cr .( re_km 90e relat f.  ) re_km 90e relat f.
cr

cr .( re_km 0e relat f. ) re_km 0e relat f.
cr .( re_km -38e relat f. ) re_km -38e relat f.
cr .( re_km -90e relat f.  ) re_km -90e relat f.
cr

cr 10 spaces .( Check Stacks, Data Stack: ) .s .( ,FP Stack: ) f.s cr
cr 40 spaces .( Done!)
