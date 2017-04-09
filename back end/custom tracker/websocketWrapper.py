import websocket
try:
    import thread
except ImportError:  # TODO use Threading instead of _thread in python3
    import _thread as thread
import time
import sys

ws = None

def on_message(ws, message):
    print(message)


def on_error(ws, error):
    print(error)


def on_close(ws):
    print("### closed ###")


def on_open(ws):
    print "starting websocket"

def init():
    websocket.enableTrace(True)
    host = "ws://127.0.0.1:4040"
    ws = websocket.WebSocketApp(host,
                                on_message=on_message,
                                on_error=on_error,
                                on_close=on_close)
    ws.on_open = on_open
    ws.run_forever()

def send(x, y):
    # push on socket
    ws.send(x, y)