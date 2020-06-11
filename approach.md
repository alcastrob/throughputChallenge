# Current Approach: Write a file with multiple bitmaps

This is an improvemente over the approach of one file per bitmap. The main idea is try to redeem the penalty time for every I/O operation that we request to the OS. If we save a larger file (with multiple bitmaps inside), we're saving write operation times, and this will speed up the transfer between processes.

This approach requires **to create a buffer system on consumer and producer**, in order to accomodate the pace. In addition to that, this buffer is basically memory on both process. So **this approach is exchanging execution time by memory**. How big this buffer could be is a configuration parameter that must also to be keep in mind.



## Results

| Writing times                      | Buffer: None (previous approach) | Buffer: 1 bitmap | Buffer: 10 bitmaps | Buffer: 20 bitmaps | Buffer: 50 bitmaps | Buffer: 100 bitmaps | Buffer: 1,000 bitmaps |
| ---------------------------------- | -------------------------------- | ---------------- | ------------------ | ------------------ | ------------------ | ------------------- | --------------------- |
| Avg. time per bitmap               | 0.53899 ms                       | 1.70991 ms       | 1.90292 ms         | 1.98677 ms         | 2.01794 ms         | 2.15014 ms          | 2,39641 ms            |
| Total time (process 5,295 bitmaps) | 2,854 ms                         | 9054 ms          | 10,076 ms          | 10,520 ms          | 10,685 ms          | 11,385 ms           | 12,689 ms             |
| Max. file size                     | 27,000 bytes                     | 27,000 byter     | 272,000 bytes      | 544,000 bytes      | 1,360,000 bytes    | 2,720,000 bytes     | 27,200,000 bytes      |

The first thing you can observe in this table is that **my implementation of the buffer is not good in performace terms**. You can see it if you compare the first two columns of the table. Probably some adjustments could be done in this area.

Another important thing is that **the average time per bitmap is higher the bigger the buffer is**. That makes sense, because **some bitmaps will have to wait and extra time in the queue until they are finally flushed to disk**. And this is one of the concerns with this approach: you have to adjust carefully this buffer size in order to warranty that the consumer *never* will run out of bitmaps. If you set the buffer very big, you will save lots of I/O operations, but the data will be not availabe so often (but when it finally is available, you will have work for a long period).

Finally, the memory use is similar to the size of the file generated. In the most extreme case (1,000 bitmaps), you can see that **the buffer will only require 25,95 MB of memory**. Nowadays, this ammount of memory is perfectly feasible.

## Pros

 - Cheap in terms of CPU and network.
 - Cheaper in terms of I/O and disk in comparision to the previous approach.
 - No other infra but the OS required.
 - Not very expensive in terms of memory.

## Cons

- Bad for escalation. It will not work in multiple servers.
- If a file is corrupted, the number of affected bitmaps is also bigger.
- Having a buffer creates an extra delay between deliveries. This parameter will require a tune up in order to not render the consumer spare.
