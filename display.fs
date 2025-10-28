\ spat out by ChatGPT to drive a 7-segment display via 74HC595 shift register


25 constant DATA     \ SER
26 constant CLOCK    \ SRCLK
27  constant LATCH    \ RCLK

: setup-pins
  DATA  OUTPUT pinMode
  CLOCK OUTPUT pinMode
  LATCH OUTPUT pinMode ;
setup-pins

: pulse ( pin -- )  dup 1 swap digitalWrite  0 swap digitalWrite ;

: shift-out ( byte -- )
  8 0 do
    dup 128 and if 1 else 0 then 
    \ dup .
    DATA digitalWrite  \ MSB first
    
    CLOCK pulse
    2*  \ shift left
  loop
  drop ;


  : setlatch ( -- )  LATCH pulse ;

  binary

  create digits
  \ a b c d e f g dp
  
  00111111 c,  \ 0
  00000110 c,  \ 1
  01011011 c,  \ 2
  01001111 c,  \ 3
  01100110 c,  \ 4
  01101101 c,  \ 5
  01111101 c,  \ 6
  00000111 c,  \ 7
  01111111 c,  \ 8
  01101111 c,  \ 9

  decimal

  : show-digit ( n -- )
  digits + c@    \ fetch pattern
  shift-out
  setlatch ;


  : count-demo
  10 0 do
    i show-digit
    500 ms
  loop ;

