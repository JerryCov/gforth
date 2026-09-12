\ sa = 2*pi*r^2+2*pi*r*h
\ v = pi*r^2*h

\ funtion for surface area of cylinder
cr .( Our word [funtion] for surface area of a right circular cylinder.)
cr .( It expects the height and radius on the fp stack, radius on top, i.e. last in.) cr
: cylSA .( h r -fp- sa)
  fdup fdup f* pi f* 2e f* fswap pi f* 2e f* frot f* f+ ;
."  :( heght radius -fp- surface_area )"
see cylSA cr
\ test our word
.( 5e 6e cylSA f. ) 5e 6e cylSA ." cylinder surface area " f. cr

\ funtion for volume of cylinder
cr .( Our word [funtion] for the volume of a right circular cylinder.)
cr .( It expects the height and radius on the fp stack, radius on top, i.e. last in.) cr
: cylVol .( h r -fp- vol)
  2e f** pi f* f* ;
."  :( height radius -fp- volume )"
see cylVol cr
\ test our word
.( 5e 6e cylVol f. ) 5e 6e cylVol ." cylinder volume " f. cr

cr .( Now a word [function] that expects the height and radius on the fp stack, radius on top, i.e. last in,)
cr .( and outputs the surface area and volume.) cr
\ I'm kinda proud of this one becaue it took me quite a bit of fiddling to figure out the
\ stack shuffling required to do this with just the two inputs. The most amazing thing
\ about it was that once I was done fiddling around in the gforth shell I actually got
\ the stack sequences right the first time when defining the word, it usualy takes me several trys
: cylSAVol .( h r -fp- )
  fdup frot fdup frot \ do some duping and rotating so we can display the input values
  cr ." For a cylinder of radius " f. ." units and a height of " f. ." units"
  fdup frot fdup frot fswap cylSA \ more duping, rotating, and a swap for the input for our words
  cr ." the surface area will be " f. ." square units" cr \ output from our first word to clear the fp stack
  cylVol \ this word pops the last two values from the fp stack and pops it's result for output,
  ." and the volume will be " f. ." cubic units." cr ; \ leaving the fp stack clean
."  :( height radius -fp- ) 
see cylSAVol cr \ display the definition
\ test our words

cr .( 5e 6e cylSAVol cr ) 5e 6e cylSAVol cr

cr .( Test our stacks, Data: ) .s .( Floating point: ) f.s cr

cr .( Done! ) cr

