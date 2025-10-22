# all my forth stuff

## ESPForth

load this into the board with the Arduino IDE and a suitably aged ESP IDF


 * ESP32forth v7.0.7.21
 * Revision: 134cc8215b261f1e5eb29fdcc0aa89a91424fdb5
 

 ## communication

 ### tio commands

 Key Action Notes
Ctrl-t ?    Show help menu  Quick reference of all keys
Ctrl-t q    Quit            Graceful exit
Ctrl-t s    Send file       Prompts for filename; sends contents down the serial link
Ctrl-t p    Toggle local echo   See what you type if your board doesn’t echo
Ctrl-t l    Log session to file Starts/stops logging serial output
Ctrl-t r    Reset serial port   Reopen connection (useful after flashing, etc.)


### rlwrap

rlwrap tio -b 115200 /dev/tty.usbserial-110

