import os
import time
import asyncio
from watchdog.events import FileSystemEventHandler

class ConsumerEventHandler(FileSystemEventHandler):
    """
    This class will be called whenever a new bitmap file is detected in the 
    directory. The file will be opened and deleted after being processed
    """

    firstFileWatched = 0
    lastFileWatched = 0
    filesCount = 0

    def on_created(self, event):
        self.readFile(event.src_path)
        self.killFile(event.src_path)
        #loop = asyncio.get_event_loop()
        #loop.create_task(self.printResults())
        # Print the result asyncronously (fire and forget) to screen
        self.printResults()

    def readFile(self, path):
        if self.firstFileWatched == 0:
            self.firstFileWatched = time.time()
        fh = open(path, 'rb') # binary reading
        try:
           data = fh.read()
           # Nothing more to do with this data.
        finally:
            fh.close
            self.lastFileWatched = time.time()
            self.filesCount += 1

    def killFile(self, path):
        try:
            if os.path.exists(path):
                os.remove(path)
        finally:
            return

    def fire_and_forget(f):
        def wrapped(*args, **kwargs):
            return asyncio.get_event_loop().run_in_executor(None, f, *args, *kwargs)

        return wrapped

    #@fire_and_forget
    def printResults(self):
        print('Files processed: {0}'.format(self.filesCount))
        print('Processing time (s): {0}'.format(self.lastFileWatched - self.firstFileWatched))