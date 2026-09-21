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
fvariable g
fvariable t

1e   len f!   \ a 1-meter pendulum
9.8e g   f!   \ standard gravity

cr .( A 1-meter pendulum [approximately the classic "seconds pendulum"]: ) cr
cr ." Length L = " len f@ f. ." _m, gravity g = " g f@ f. ." _m/s^2" cr

len f@ g f@ period t f!
cr ." Period T = 2*pi*sqrt(L/g) = " t f@ f. ." _s"

cr ." Cross-check: recovering L from T and g: "
t f@ g f@ pendulum-length f. ." _m (should match the " len f@ f. ." _m above)" cr

cr .( Check stacks, Data: ) .s .( FP: ) f.s cr
cr .( Done! ) cr
