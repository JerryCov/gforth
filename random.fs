\ random.fs
\ Independently written replacement for gforth's own bundled example
\ file of the same name, which was GNU/FSF third-party content and
\ was removed from this repo (kept locally only, gitignored) for
\ copyright reasons -- see .gitignore for the note.
\
\ Implements the xorshift algorithm (George Marsaglia, explicitly
\ published as public domain), written from scratch in Forth, using
\ the 32-bit parameter set to match this gforth build's native cell
\ size (checked via `1 cells .`). Exposes the same public interface
\ as the original -- seed, rnd, random -- so nothing else that uses
\ this file needs to change.

Variable seed
1 seed !  \ xorshift requires a nonzero seed; reseed with the current
          \ time before real use, e.g.: utime drop seed !

: xorshift-step ( x -- x' )
  dup 13 lshift xor
  dup 17 rshift xor
  dup 5 lshift xor
;

: rnd ( -- n )  \ raw pseudo-random cell, also advances the generator
  seed @ xorshift-step dup seed !
;

: random ( n -- 0..n-1 )  \ scale a raw random value into [0,n)
  rnd um* nip             \ classic multiply-by-range, take high bits
;
