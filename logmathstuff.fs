\ logmathstuff.fs
: .intro ( ) cr
	 ." We'll be doing some logarithmic stuff in here." cr
	 ." First we'll set up a few useful constants, then " cr
	 ." we'll do a little log math to warm up. " cr
	 ." Some notes:   1. our log functions are all floating point," cr
	 ." so by convention they all start with f, thus:" cr
	 ." fln expects a number on the fp stack and returns the natural log," cr
	 ." flog is the same but returns the common (base 10) log," cr
	 ." our defined word flogbn expects 2 numbers on the fp stack," cr
	 ." the base and the number in that order, and returns the log to that base" cr
	 ." to the fp stack." cr
;
.intro
cr
.( 1e fexp fconstant e to store the base of natural logs as the constant e) cr
1e fexp fconstant e e f.
cr
.( e f. ) e f.
cr
.( e fln f. ) e fln f. cr
.( 100e flog f. cr )
100e flog f. cr
cr
." fln2 stack: (N -f- ln2(N))"
: fln2 ( N -f- log2{N} )
  2e \ base 2
  fswap fln fswap fln f/ ;
see fln2 cr

cr
." flog2 stack: (N -f- log2(N))"
: flog2 ( N -f- log2{N} )
  2e \ base 2
  fswap flog fswap flog f/ ;
see flog2 cr
cr
0 [if] Multi line comment!
By using the stack order B N in our flnbn and flogbn words
we eliminate an fswap which would otherwise be
necessary, thus our definition is slightly smaller and faster.
[then]
." flnbn stack: (B N -f- lnb(N))" 
: flnbn ( b n -f- lognb ) \ natural log version
  fln fswap fln f/ ;
see flnbn cr
cr
." flogbn stack: (B N -f- logb(N))" 
: flogbn ( b n -f- lognb ) \ common log version
  flog fswap flog f/ ;
see flogbn cr
.( flogbn is log base b of number n, stack order: base, number ) cr
cr
.( 45e fln2 f. cr ) 45e fln2 f. .( is ln2[45]) cr
.( 455e fln2 f. cr ) 455e fln2 f. .( is ln2[455])cr
.( 45e fln f. ) 45e fln f. .( is ln[45] ) cr
.( 455e fln f. ) 455e fln f. .( is ln[455] ) cr

cr
.( 2e 45e flnbn f. cr ) 2e 45e flnbn f. .( is ln2[45]) cr
.( 2e 455e flnbn f. cr ) 2e 455e flnbn f. .( is ln2[455])cr
.( 10e 45e flogbn f. cr ) 10e 45e flogbn f. .( is log10[45]) cr
.( 10e 455e flogbn f. cr ) 10e 455e flogbn f. .( is log10[455])cr
.( 10e 45e flnbn f. cr ) 10e 45e flnbn f. .( is ln10[45]) cr
.( 10e 455e flnbn f. cr ) 10e 455e flnbn f. .( is ln10[455])cr

: .example1 ( ) cr
	    ." To multiply two numbers using logarithms first we take the" cr
	    ." log of both numbers, then add them and take the antilog." cr
	    ." What is the antilog I hear you ask? It's the exponential function." cr
	    ." In Forth it's fexp, which expects a number on the fp stack," cr
	    ." and returns the exponential of that number, that is e^n, on the fp stack," cr
	    ." where e is the base of natural logarithms and n is our number." cr
;

.example1
.( 45e fln 55e fln f+ fexp f. cr ) 45e fln 55e fln f+ fexp f. cr
.( 455e fln 55e fln f+ fexp f. cr ) 455e fln 55e fln f+ fexp f. cr


: .example2 ( ) cr
	    ." To divide two numbers using logarithms first we take the" cr
	    ." log of both numbers, then subtract them and take the antilog." cr
	   
;

.example2
.( 2475e fln 55e fln f- fexp f. cr ) 2475e fln 55e fln f- fexp f. cr
.( 25025e fln 55e fln f- fexp f. cr ) 25025e fln 55e fln f- fexp f. cr
.( Check our stacks: Data stack: ) .s .( Floating point stack: ) f.s

