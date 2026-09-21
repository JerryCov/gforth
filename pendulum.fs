\ pendulum.fs
\ Simple pendulum period: T = 2*pi*sqrt(L/g)
\ L is the pendulum's length, g is gravitational acceleration.
\ Demonstrates with a 1-meter pendulum (close to the classic "seconds
\ pendulum" length, giving an approximately 2-second period), then
\ recovers L back from the computed period as a round-trip check.
\
\ SCOPE NOTE: this is the small-angle approximation, only valid for
\ swings of a few degrees or less. Large swing angles need a more
\ complex formula involving elliptic integrals.

: period          ( L g -f- T )  f/ fsqrt 2e pi f* f* ;
: pendulum-length ( T g -f- L )  fswap 2e pi f* f/ fdup f* f* ;

." ( L g -f- T )"  see period cr
." ( T g -f- L )"  see pendulum-length cr

fvariable len
9.80665e fconstant g   \ standard gravity, full-precision internationally
                        \ defined value -- a real physical constant, not
                        \ mutable state, so fconstant fits better than fvariable
fvariable t

1e   len f!   \ a 1-meter pendulum

cr .( A 1-meter pendulum [approximately the classic "seconds pendulum"]: ) cr
cr ." Length L = " len f@ f. ." _m, gravity g = " g f. ." _m/s^2" cr

len f@ g period t f!
cr ." Period T = 2*pi*sqrt(L/g) = " t f@ f. ." _s"

cr ." Cross-check: recovering L from T and g: "
t f@ g pendulum-length f. ." _m (should match the " len f@ f. ." _m above)" cr

cr .( Check stacks, Data: ) .s .( FP: ) f.s cr
cr .( Done! ) cr
