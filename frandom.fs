\ frandom.fs
\ Floating-point pseudo-random number generation, written from scratch.
\ Bitwise techniques like xorshift (used in random.fs for integers) don't
\ meaningfully apply to IEEE floating point without an ugly bit-reinterpret
\ trick, so this uses a genuinely different, purely floating-point
\ technique instead: a Weyl sequence -- an additive recurrence that
\ repeatedly adds an irrational constant (here, the golden ratio's
\ conjugate) and keeps only the fractional part each time. This is
\ well-known public-domain mathematics (Hermann Weyl's equidistribution
\ theorem), not any particular author's code.

5e fsqrt 1e f- 2e f/ fconstant phi-conj  \ (sqrt(5)-1)/2, same constant
                                          \ used as ihp elsewhere tonight

fvariable fseed
phi-conj fseed f!  \ arbitrary nonzero starting seed -- reusing phi-conj
                    \ itself avoids hand-typing yet another decimal

: ffrac ( F: x -- F: frac )  \ fractional part of x, result always in [0,1)
  fdup floor f-
;

: frnd ( F: -- x )  \ raw random float in [0,1); also advances the generator
  fseed f@ phi-conj f+ ffrac fdup fseed f!
;

: frandom ( F: lo hi -- F: x )  \ random float in [lo, hi)
  fover f-      \ ( lo hi -- lo range )   range = hi - lo
  frnd f* f+    \ ( lo range -- lo+range*frnd )
;
