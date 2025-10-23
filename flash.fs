: flash

\ flash led on pin 26 10 times

26 output pinmode

10 0 do
    high 26 pin
    800 ms
    low 26 pin
    800 ms
loop

;


