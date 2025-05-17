using System;
using System.Threading;

public static class ThreadSafeCounter
{
    // shared counter
    private static int count = 0;

    // reader-writer access manager
    private static ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

    
    public static int GetCount()
    {
        // enter read lock so multiple threads can read at the same time
        rwLock.EnterReadLock();
        try
        {
            return count;  // return the current value
        }
        finally
        {
            rwLock.ExitReadLock();  //  release the lock after reading
        }
    }

    
    public static void AddToCount(int value)
    {
        // only one thread can write at a timeso enter write lock
        rwLock.EnterWriteLock();
        try
        {
            count += value;  // update the shared counter
        }
        finally
        {
            rwLock.ExitWriteLock();  // release the lockk
        }
    }
}
