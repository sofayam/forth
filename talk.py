#!/usr/bin/env python3
import serial, sys, threading, readline, time

PORT = "/dev/tty.usbserial-110"
BAUD = 115200

ser = serial.Serial(PORT, BAUD, timeout=0.1)

def reader():
    """ Continuously print data coming from the board """
    while True:
        data = ser.read(1024)
        if data:
            sys.stdout.write(data.decode(errors="replace"))
            sys.stdout.flush()

threading.Thread(target=reader, daemon=True).start()

print(f"Connected to {PORT} @ {BAUD}. Type :send <file> to inject a file. Ctrl-C to quit.")

while True:
    try:
        line = input("> ")
        if line.startswith(":send "):
            fname = line[6:].strip()
            try:
                with open(fname, "r") as f:
                    for l in f:
                        ser.write(l.encode())
                        time.sleep(0.01)  # small pacing delay
                print(f"[Sent file: {fname}]")
            except Exception as e:
                print(f"[Error: {e}]")
        else:
            ser.write((line + "\r\n").encode())
    except KeyboardInterrupt:
        print("\nExiting...")
        ser.close()
        sys.exit(0)