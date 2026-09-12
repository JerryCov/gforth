\ chartable.fs
[IFDEF] my-code
    my-code
[ENDIF]

marker my-code
: chartab cr 128 31 do
	     i dup 16 mod 0= if cr then
	     emit loop cr ;

chartab

: mattab cr 128 31 do
	   i 16 mod 0= if cr then
	   i 100 < if 1 spaces else
	   0 spaces then
	   i . loop cr ;

mattab
.s

cr
64 emit 32 emit 91 emit 96 emit 95 emit 90 emit 122 emit 93 emit cr
16 emit 33 emit 48 emit 57 emit 17 emit 94 emit

