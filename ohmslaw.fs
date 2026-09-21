\ ohmslaw.fs
\ Ohm's Law: V = I*R (Voltage = Current * Resistance)
\ Also demonstrates Joule's law (electrical power), computed three
\ different, equivalent ways -- P = I*V = I^2*R = V^2/R -- and confirms
\ all three agree, using a real 120V, 60W household lightbulb as the
\ example.
\
\ SCOPE NOTE: these formulas only hold for DC circuits, or for AC
\ circuits driving a purely resistive load (no reactance). A real
\ incandescent lightbulb's filament is close enough to pure resistance
\ that this simplification is valid for it specifically. A general AC
\ circuit with inductance or capacitance (motors, transformers, etc.)
\ needs complex-valued impedance (Z = R + jX) and a power-factor term
\ (P = V*I*cos(theta)) instead of the plain real-number formulas here.

: voltage    ( i r -f- v )  f* ;
: amperage   ( v r -f- i )  f/ ;
: resistance ( v i -f- r )  f/ ;

: power-iv  ( i v -f- p )  f* ;
: power-i2r ( r i -f- p )  fdup f* f* ;
: power-v2r ( v r -f- p )  fswap fdup f* fswap f/ ;

." ( i r -f- v )"    see voltage cr
." ( v r -f- i )"    see amperage cr
." ( v i -f- r )"    see resistance cr
." ( i v -f- p )"    see power-iv cr
." ( r i -f- p )"    see power-i2r cr
." ( v r -f- p )"    see power-v2r cr

fvariable v
fvariable amps
fvariable r
fvariable p

120e v f!   \ standard household voltage
60e  p f!   \ a 60W lightbulb

cr .( A 120V household lightbulb rated at 60W: ) cr
cr ." Voltage V = " v f@ f. ." _V, Power P = " p f@ f. ." _W" cr

p f@ v f@ f/ amps f!   \ I = P/V
cr ." Current  I = P/V = " amps f@ f. ." _A"

v f@ amps f@ resistance r f!   \ R = V/I
cr ." Resistance R = V/I = " r f@ f. ." _ohms"

cr ." Cross-check: recomputing I from V and R using amperage: "
v f@ r f@ amperage f. ." _A (should match the " amps f@ f. ." _A above)" cr

cr .( Checking power three equivalent ways: ) cr
." P = I*V   = " amps f@ v f@ power-iv f. ." _W" cr
." P = I^2*R = " r f@ amps f@ power-i2r f. ." _W" cr
." P = V^2/R = " v f@ r f@ power-v2r f. ." _W" cr

cr .( Check stacks, Data: ) .s .( FP: ) f.s cr
cr .( Done! ) cr
