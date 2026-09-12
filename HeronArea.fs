.( Heronarea.fs  Heron's formula for finding the area of a triangle given the sides.) cr
: f? .( var_addr -ps-  -fp- var_value ) f@ f. ; \ fvariable display word
see f? cr
.( Set up some fvariables to make life easier:) cr
.( 0e fvariable a a f! a f? cr ) 0e fvariable a a f! a f? .( Side a) cr
.( 0e fvariable b b f! b f? cr ) 0e fvariable b b f! b f? .( Side b)  cr
.( 0e fvariable c c f! c f? cr ) 0e fvariable c c f! c f? .( Side c)  cr
.( 0e fvariable s s f! s f? cr ) 0e fvariable s s f! s f? .( Semiperimeter s)  cr
cr
.( Our word definitions:) cr
\ sgen is a utility word which saves the stack input to variables,
\ then uses them to compute and store the semiperimeter.
: sgen .( a b c -fp- ) \ store our a b and c values for future use
  \  A word to generate the semiperimeter, s
  c f! b f! a f! a f@ b f@ c f@ \ and bring them back for use here
  f+ f+ 2e f/ s f! ; \ generate and store our semiperimeter
cr ."  A word to generate the semiperimeter, s"
see sgen cr cr
\ heronarea is the word that actually computes the area by using
\ sgen to handle setting all the required variables and
\ computing the semiperimeter.
: heronarea .( a b c -fp- area) \ compute our triangle area
  \  This word actually computes the area.
  sgen s f@ s f@ a f@ f- s f@ b f@ f- s f@ c f@ f- 
  f* f* f* 2e 1/f f** ; \ sqrt(s*(s-a)*(s-b)*(s-c)) in more normal math expression
cr ." This word actually computes the area."
see heronarea cr cr
.( Some examples:) cr
.( 3e 4e 5e heronarea f. ) 3e 4e 5e heronarea f. .( square units.) cr
.( 6e 8e 10e heronarea f. ) 6e 8e 10e heronarea f. .( square units.) cr
.( 9e 12e 15e heronarea f. ) 9e 12e 15e heronarea f. .( square units.) cr
.( 12e 16e 20e heronarea f. ) 12e 16e 20e heronarea f. .( square units.) cr
.( 15e 20e 25e heronarea f. ) 15e 20e 25e heronarea f. .( square units.) cr
.( 15e 21e 25e heronarea f. ) 15e 21e 25e heronarea f. .( square units.) cr
.( 15e 21e 26e heronarea f. ) 15e 21e 26e heronarea f. .( square units.) cr


cr .( Checking our stacks: Data Stack: ) .s .( Floating point stack: ) f.s cr
.( Done!) cr

