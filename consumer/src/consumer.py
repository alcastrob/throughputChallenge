#!/usr/bin/python3

import sys
import time
import logging
import asyncio

from watchdog.observers import Observer
from consumerEventHandler import ConsumerEventHandler

class ConsumerWatcher:
    def __init__(self, src_path):
        self.__src_path = src_path
        self.__event_observer = Observer()

    def run(self):
        event_handler = ConsumerEventHandler()
        self.__event_observer.schedule(event_handler, path=self.__src_path, recursive=False)
        self.__event_observer.start()

        try:
            while True:
                time.sleep(1)
        except KeyboardInterrupt:
            self.stop()
            return
    
    def stop(self):
        # properly dismiss the file watcher
        self.__event_observer.join()

#async def main():

if __name__ == "__main__":
    #loop = asyncio.get_event_loop()
    #loop.run_until_complete(main())
    src_path = sys.argv[1] if len(sys.argv) > 1 else '.'
    print("Consumer watching on " + src_path)
    ConsumerWatcher(src_path).run()