\ AreaSphere = 4*pi*r^2
\ rearranging for the stack, r^2 pi * 4 *; ( r -fp- AreaSphere )
\ VolSphere = 4/3*pi*r^3
\ rearranging for the stack, r^3 pi * 4 * 3 / ; ( r -fp- VolSphere )

\ funtion for surface area of sphere
\ defining it this way avoids any stack manipulation gymnastics
\ thus simplifying things and making it faster
cr .( First off, let's define a few useful words.) cr
: AreaSphere .(  r -fp- a )
  2e f** pi f* 4e f* ; \ the e's push the numbers to the fp stack
." :( radius -fp- Area_Sphere )
see AreaSphere cr cr

: testAreaSphere .(  r -fp- a )
   fdup
   ." The area of a sphere of radius " f. ." units is: " AreaSphere
   f. ." square units." ;
." :( radius -fp- Area_Sphere )
see testAreaSphere cr cr
.( cr 6e testAreaSphere cr ) cr 6e testAreaSphere cr cr

\ funtion for volume of sphere
\ defining it this way avoids any stack manipulation gymnastics
\ thus simplifying things and making it faster
: VolSphere .(  r -fp- v )
  3e f** pi f* 4e f* 3e f/ ; \ the e's push the numbers to the fp stack
." :( radius -fp- Vol_Sphere )
see VolSphere cr cr

: testVolSphere .(  r -fp- v )
   fdup
   ." The volume of a sphere of radius " f. ." units is: " VolSphere
   f. ." cubic units." ;
." :( radius -fp- Vol_Sphere )
see testVolSphere cr cr
.( cr 6e testVolSphere ) cr 6e testVolSphere cr cr

: test+do .(  start end -- )
  +do i . 1 +loop ;
." :( start end -fp- ) "
see test+do cr cr
.( 11 1 test+do cr cr ) 11 1 test+do cr cr

: tableAreaSphere .(  end begin -- ) .( 0e -fp- )
  0e \ this provides an input of zero for the f+ first time through the loop
  +do cr ." #" i .
     1e f+ fdup  fdup ." radius: " f. AreaSphere ." area: " f.
     \ the fdups provide the radius for VolSphere and the input for f+ to increment
  1 +loop fdrop  cr ; \ We have to drop the last increment because it is never used.
." :( end begin -- ) :( 0e -fp-) | We are using both stacks here."
see tableAreaSphere cr cr

.( 11 1 tableAreaSphere) cr 11 1 tableAreaSphere cr

: tableVolSphere .(  end begin -- ) .( 0e -fp- )
  0e \ this provides an input of zero for the f+ first time through the loop
  +do cr ." #" i .
     1e f+ fdup fdup ." radius: " f. VolSphere ." volume: " f.
     \ the fdups provide the radius for VolSphere and the input for f+ to increment
  1 +loop fdrop  cr ; \ We have to drop the last increment because it is never used.
." :( end begin -- ) :( 0e -fp- ) | We are using both stacks here. "
see tableVolSphere cr cr

.( 11 1 tableVolSphere) cr 11 1 tableVolSphere cr

: tableAreaVolSphere .(  end begin -- ) .( 0e -fp- )
  cr ."     Table of surface areas and volumes of spheres of radius from 1 to 10" cr
  0e
  +do cr ." #"
     1e f+ fdup  fdup
     i 10 mod 0=
     if 
        i . testAreaSphere cr 4 spaces testVolSphere cr
     else i . 1 spaces testAreaSphere cr 4 spaces testVolSphere cr
     then
     \ the fdups provide the radius for testAreaSphere and testVolSphere
     1 +loop fdrop  cr ; \ We have to drop the last increment because it is never used.
." :( end begin -- ) :( 0e -fp- ) "
see tableAreaVolSphere cr cr

11 1 tableAreaVolSphere cr


cr .( Test stacks, Data: ) .s .( Floating Point: ) f.s cr

cr .( Done!) cr
