\ pathagorus.fs
\ The Pythagorean theorem: c = sqrt(a^2 + b^2)
\ Demonstrates that right triangles with legs that are integer
\ multiples of 3 and 4 (and so a hypotenuse that's always a multiple
\ of 5) always have an integer area, for four different scale factors.

: hypotenuse ( a b -f- c )
  fdup f* fswap fdup f* f+ fsqrt
;
." ( a b -f- c )"
see hypotenuse cr

: area ( a b -f- area )  f* 2e f/ ;
." ( a b -f- area )"
see area cr

fvariable scale
fvariable a
fvariable b

: setup-triangle ( k -f- )
  fdup scale f!
  fdup 3e f* a f!
  4e f* b f!
;

: show-example ( k -f- )
  setup-triangle
  cr ." For k = " scale f@ f. ." : legs are " a f@ f. ." and " b f@ f.
  cr ." Hypotenuse = " a f@ b f@ hypotenuse f. ."  (should be 5k = " scale f@ 5e f* f. ." )"
  cr ." Area = " a f@ b f@ area f. ." square units" cr
;

cr .( Demonstrating: right triangles with legs 3k and 4k [hypotenuse 5k] )
cr .( always have an integer area, for k = 1, 2, 3, 4. ) cr
1e show-example
2e show-example
3e show-example
4e show-example

cr .( Check stacks, Data: ) .s .( FP: ) f.s cr
cr .( Done! ) cr
