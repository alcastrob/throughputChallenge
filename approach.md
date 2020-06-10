# Current Approach: Write one file per data item

This is a **really bad idea**. Basically is the producer process writing a file to disk for each data item. The performance here is conditioned by the capacity of the OS to write files. 
Even counting with SSD disks and async write operations, this operation is extremely expensive in terms of execution time. At least, it could be **usefull to have a performance baseline for comparison**.

Therefore, it's not worthy to build the consumer. The producer times are high enough to not continue with this approach.

## Pros
 - Cheap in terms of CPU, memory and network.
 - No other infra but the OS required.

## Cons
- Bad for escalation. It will not work in multiple servers.
- Relatively expensive in terms of I/O and disk.

## Notes

- There's an important difference writing text files or binary files

|                         | Text File    | Binary File  |
| ----------------------- | ------------ | ------------ |
| Avg. time per data item | 32.2 ms      | 22.5 ms      |
| File size               | 34,500 bytes | 13,600 bytes |
