\ CompoundInterest.fs
\ A = P(1+r/n)^n*t || the formula as expressed in normal math
\ Set up some fvariables
.( Set up some fvariables, Note for those not familiar with Forth:)
cr .( fvariable takes the name following it and assigns one cell of fp data space for it,)
cr .( with the address of the cell embedded in the word.)
cr .( At run time the use of the variable name pushes the address of the 
cr .( cell for the f! or f@ word to use,)
cr .( so we put the value we want to store on the fp stack, use the ) 
cr .( fvariable name, then f! stores the value at the specified address.)
cr .( Then we use the name and f@ to retrieve the value to the fp stack.)
cr .( Thus to define and initialize our fvariable, put the value on the fp )
cr .( stack define the name, then use it to store the value,)
cr .( this is why the variable name appears twice, it's not an error.)
cr .( A = final amount: 0e fvariable A A f! ) 0e fvariable A A f!
cr .( P = principle amount: 4000e fvariable P P f! ) 4000e fvariable P P f!
cr .( r = rate as decimal fraction [9% here]: 0.09e fvariable r r f! ) 0.09e fvariable r r f! 
cr .( n = number of compounding periods per year: 12e fvariable n n f! ) 12e fvariable n n f! 
cr .( t = time in years: 5e fvariable t t f! ) 5e fvariable t t f!
cr
: .reasons .( --- )
  cr ." We are using floating point variables in our definition for two reasons:"
  cr ." 1: Without them the fp stack quickly becomes very confusing, and"
  cr ." 2: It becomes much easier to change any or all parameters, a very useful feature."
  cr ." Also note that we don't need to use any fp stack manipulation words, an added benefit." cr ;
." ( --- )"
see .reasons cr
cr .reasons
\ define compound interest word
: compoundInt .( -fp- A) \ this word uses fvariables as defined above
  r f@ n f@ f/ 1e f+ n f@ t f@ f* f** P f@ f* ;
\ I defined it this way because 2 reasons. 1: the fp stack gets confusing
\ pretty quickly here and 2: using fvariables makes it much easier to
\ change the parameters.
." ( -fp- )"
see compoundInt cr cr
\ some examples
\ 1: using the initial values set above the definition:
.( cr compoundInt fdup A f! f. ) compoundInt fdup A f! f. \ fdup the result, store it in fvariable A and print it.
\ 2: same values as above but for 10 years instead of 5:
cr .( Change the time to 10 years: 10e t f! )
10e t f! \ change time to 10 years
cr .( compoundInt fdup A f! f. ) compoundInt fdup A f! f. \ fdup the result, store it in fvariable A and print it.
cr .( Notice that our fvariables have all been created by fvariable so all we have to do is use them.)
cr .( Change all the parameters:)
cr .( 10000e P f! ) 10000e P f! \ $10,000.00
cr .( 0.06e r f! ) 0.06e r f!   \ 6%
cr .( 12e n f! ) 12e n f!       \ monthly
cr .( 20e t f! ) 20e t f!       \ 20 years
cr .( compoundInt fdup A f! f. ) compoundInt fdup A f! f. \ fdup the result, store it in fvariable A and print it.
cr
: ContinousInt .( -fp- A )
  r f@ t f@ f* fexp P f@ f* ;
." ( -fp- A )"
see ContinousInt cr

cr .( ContinousInt fdup A f! f. ) ContinousInt fdup A f! f. cr

cr .( Change all the parameters:)
cr .( 4000e P f! ) 4000e P f!
cr .( 0.09e r f! ) 0.09e r f!
cr .( 12e n f! ) 12e n f!
cr .( 5e t f! ) 5e t f!
cr .( ContinousInt fdup A f! f. ) ContinousInt fdup A f! f. cr
cr .( Notice that the continous interest is larger than the compounded interest.)
cr .( This will always be the case.)

cr
.( Check both stacks: Data Stack: .s ) .s .( Floating Point Stack: f.s ) f.s cr
cr .( Done!) cr
