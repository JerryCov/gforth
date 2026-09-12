: .showtime ( -- ) cr \ time is hh mm ss
	   time&date \ date is:  year, month, day
	   ." Date: " . ." / " . ." / " . cr
	   ." Time: " . ." : " . ." : " . cr ;
cr see .showtime cr

: .time cr time&date 2drop drop  \ drop the date
	." Time: " \ label the output,  time is hh mm ss
	. ." : " . ." : " . cr ;
cr see .time cr

: .date cr time&date rot rot \ date is:  month, day, year
	." Date: " \ label the output
	. ." / " . ." / " . 2drop drop cr ; \ drop the time
cr see .date cr

: .explain ( -- ) cr
	   ." In all three words, we use the time&date word to" cr
	   ." put the time data on the stack and then ..." cr
	   ." To display the date and time, we print 'Date: '," cr
	   ." then dot the date with decoration (the slashes)," cr
	   ." then we print 'Time: ', then we dot the time with" cr
	   ." decorations (the colons)." cr
	   ." To display just the time, we first drop off the date," cr
	   ." we print 'Time: ' then we dot the time with a little" cr
	   ." decoration (the colons.)" cr
	   ." To display the date we print 'Date: ', we dot it with" cr
	   ." decorations (the slashes), then we drop the time off the stack." cr
	   ." Note that if we don't care for the date or time order" cr
	   ." we can switch it about any way we like by using swap," cr
	   ." rot, etc in our .date or .time word definitions before we dot." cr
	   ." I like time as is, but prefer m/d/y, two rots before we print" cr
	   ." does the trick.  You can see the default used in .showtime." cr
	   cr ;
.explain

.showtime
.time
.date

cr 10 spaces .( Check stacks, Data Stack: ) .s .( , FP Stack: ) f.s cr
40 spaces .( Done!) cr
