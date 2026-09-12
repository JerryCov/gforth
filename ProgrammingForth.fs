
\ Some stuff
: .HELLO ( -- )
    cr ." Hello "
;
." ( -- ), nothing in or out on the stack."
see .HELLO cr
.HELLO cr

: NewName ( -- )
    CR ." This is a new word. " CR 
;
." ( -- ), nothing in or out on the stack."
see NewName cr 
NewName

: TIMES  ( n1 n2 -- n3)
    * .
;
." ( n1 n2 -- n3)"
see TIMES cr
.( 2 4 TIMES )
2 4 TIMES cr

: MULTIPLY  ( n1 n2 -- )
    cr 2dup swap . ." multiplied by " .
    ." equals " TIMES cr
;
." ( n1 n2 -- ), two inputs on the stack, no output to the stack"
see MULTIPLY cr 

.( 4 3 MULTIPLY )
4 3 MULTIPLY

: .FRED
    ." Fred  "
;
see .FRED cr
: .MARY
    ." Mary "
;
see .MARY cr
: .NEIL
    ." Neil "
;
see .NEIL cr
: .LINDA
    ." Linda "
;
: .AND 
    ." and "
;
see .AND cr
: .GREET ( -- )
    .HELLO .MARY .AND .FRED 
    .AND .LINDA .AND .NEIL ." ." CR 
;
." ( -- ) Nothing on the stack."
see .GREET
.GREET

decimal  \ make sure base is decimal
13 constant enter-key
1 constant daffodil
2 constant tulip
3 constant rose
4 constant snowdrop

variable flower
: yellow ( -- )
    ." yellow ink. " cr 
;
: ink ( -- )
    ." ink blot. "
;
daffodil flower !
: daff ( -- )
    flower @ daffodil =
    if yellow ink THEN
    cr ." daffodil!"
;

cr daff cr
cr
: wait-enter ( -- )
    begin key enter-key = until
;

55 value FOO
: test ( n --)
    cr ." The value of FOO was " foo .
    to foo
    ." and is now " foo . cr
;
." ( n --) number n on the input stack, nothing left on the stack"
see test cr
100 test

: TEST1 ( flag -- )
    if ." top of stack is non-zero " then
;

." ( flag -- ) a zero or 1 flag on input, nothing on exit"
see TEST1 cr
.(  1 TEST1 cr ) 1 TEST1 cr
.(  0 TEST1 cr ) 0 TEST1 cr

: TEST2 ( flag -- )
    if ." top of stack is non-zero "
    else ." Top of stack is zero "
    then
;

." ( flag -- ) a zero or 1 flag on input, nothing on exit"
see TEST2 cr
.( 1 TEST2 cr ) 1 TEST2 cr
.( 0 TEST2 cr )  0 TEST2 cr

\ three do loops
: doloop1 ( -- )
    ." doloop1, a simple upcounting loop" cr
    10 1
	do I . loop
;
." ( -- ) Nothing on stack."
see doloop1 cr
doloop1 cr

: doloop2 ( -- )
    ." doloop2, a loop which increments by 3 using +loop" cr
     30 1 do i . 3 +loop
;
." ( -- ) Nothing on stack."
see doloop2 cr
doloop2 cr

: doloop3 ( -- )
    ." doloop3, a down counting loop using -1 and +loop" cr
    0 9 do i . -1 +loop
;
." ( -- ) Nothing on stack."
see doloop3 cr
doloop3 cr

.( cr ?do does not run the loop if the index and start values are equal. )

0 [IF]
\ BEGIN WHILE REPEAT loops
variable counter
: keytimecounter ( -- )
    ." Demo of a begin while repeat loop..." cr
    ." Press a key:" cr
    0 counter !
    begin key? 0=
        while 1 counter +!
    repeat
    ." times through the loop: " counter ? cr
;
keytimecounter cr
[THEN]

: STYLE? ( n -- )
    case
        1   of ." Mummy, I like you." endof
        2   of ." Pleased to meet you, " endof
        3   of ." Hi!" endof
        4   of ." Hello, " endof
        5   of ." Where's the coffee? " endof
        6   of ." Yes? " endof
            ." And who are you?"
    endcase
;

7 STYLE? cr
1 STYLE? cr
6 STYLE? cr
5 STYLE? cr

: HELLO$ ( -- )
    C" Hello there. "
;

HELLO$ count TYPE cr

: .ucase ( -- ) ." Print upper case Ascii chart." cr 
    91 65 do i dup . space emit space 
    \ The line above starts the loop and then
    \ prints the integer value then the character
    i 64 - 13 mod 0 = if cr then loop 
    \ The line above geneates a mod 13 offset count
    \ to split the output into 2 lines of 13 data pairs
    \ and terminates the loop. Notice that the offset is computed
    \ by subtracting 1 less than the start value from the loop count.
;
." ( -- ) Nothing on stack."
see .ucase cr

.ucase cr
: .lcase ( -- ) ." Print lower case Ascii chart." cr 
    123 97 do i dup . space emit space 
    \ The line above starts the loop and then
    \ prints the integer value then the character
    i 96 - 13 mod 0 = if cr then loop 
    \ The line above geneates a mod 13 offset count
    \ to split the output into 2 lines of 13 data pairs
    \ and terminates the loop. Notice that the offset is computed
    \ by subtracting 1 less than the start value from the loop count.
;
." ( -- ) Nothing on stack."
see .lcase cr

.lcase cr

: .achars ( -- ) ." Print upper and lower case Ascii chart."
    cr .ucase 
    .lcase cr
;
." ( -- ) Nothing on stack."
see .achars cr

.achars cr 
0 [IF] \ block comment this out, to uncomment just change the 0 to a 1
\ string buffers and input
create BUFFER$ 80 allot
cr BUFFER$ 80 accept
( now enter a string at the keyboard. )
 BUFFER$ swap dump \ and dump it
[THEN]
\ number formatting

hex
: .pounds ( u -- )
    [char] £ emit
    S>D <# # # [char] . hold #S #> TYPE
;
." ( -- ) Nothing on stack."
see .pounds cr



\ page 
decimal
.( 5050 .pounds ) 5050 .pounds cr
.( 10007895 .pounds ) 10007895 .pounds cr 

: #B ( d1 -- d2)
    2dup d0= if bl hold else # then ;
." ( d1 -- d2 ) double1 on input, double2 on output stack."
see #B cr

: .P ( d1 -- )
    <# # # [char] . hold # #B #B #B #B #B #> TYPE ;
." ( d1 -- ) double1 on input, nothing on output stack."
see .P cr

.( 500.00 .P ) 500.00 .P cr 
.( 50000000. .P ) 50000000. .P cr cr 

\ ****************************************************

: within? ( x n1 n2 -- flag )
    1+ within
;
." ( x n1 n2 -- flag )
see within? cr
 
: year? ( year -- t|f)
    1752 2050 within?
;
." ( x n1 n2 -- flag )
see year? cr

: month? ( month -- t|f )
    1 12 within?
;
." ( x n1 n2 -- flag )
see month? cr

: >otherdays ( month -- maxdays )
    dup 4 =
    over 6 = or
    over 9 = or
    swap 11 = or
    if 30 else 31 then
;
." ( x n1 n2 -- flag )
see >otherdays cr



: leap? ( year -- t|f )
    dup 4 mod 0=
    over 100 mod 0<>
    and
    swap 400 mod 0=
    or
;
." ( x n1 n2 -- flag )
see  leap? cr


: >leapdays ( year -- maxdays )
    leap?
    if 29 else 28 then
;
." ( x n1 n2 -- flag )
see >leapdays cr


: >days ( year month -- maxdays )
    dup 2 =
    if drop >leapdays
    else nip >otherdays
    then
;
." ( x n1 n2 -- flag )
see >days cr


: day? ( day year month -- t|f )
    >days 1 swap within?
;
." ( x n1 n2 -- flag )
see day? cr


: valid? ( day month year -- t|f )
    dup year?
    if over month?
        if swap day?
        else 2drop drop 0 \ cleanup and leave false
        then
    else 2drop drop 0 \ cleanup and leave false
    then 
;
." ( x n1 n2 -- flag )
see valid? cr


\ page
cr
.( 8 10 1954 valid? . )
8 10 1954 valid? . cr 
.( 1954 year? . )
1954 year? . cr 
.( 8 1954 10 day? . )
8 1954 10 day? . cr 
cr .( 1954 >leapdays . )
1954 >leapdays . cr
.( 1956 >leapdays . )
1956 >leapdays . cr
cr .( 1954 10 >days . )
1954 10 >days . cr
.( 10 >otherdays . )
10 >otherdays . cr
cr .( 1954 leap? . )
1954 leap? . cr
.( 2021 leap? . )
2021 leap? . cr
.( 2000 leap? . )
2000 leap? . cr
.( 1996 leap? . )
1996 leap? . cr
.( 1960 leap? . )
1960 leap? . cr
.( 1956 leap? . )
1956 leap? . cr
.( 1952 leap? . )
1952 leap? . cr

: .saydone ( -- )
    cr ." Done!" cr 
;
." ( x n1 n2 -- flag )
see .saydone cr


\ page
\ see enter-key cr
\ enter-key is predefined in gforth
\ If you change the 0 below to 1 
\ you will redefine enter-key
0 [IF] \ block comment
: enter-key ( --)
    cr ." Enter character: " key
    cr ." You entered: " emit
;
[THEN]
\ enter-key cr

.saydone
cr .( Checking our stacks: Data Stack: ) .s .( Floating point stack: ) f.s cr
