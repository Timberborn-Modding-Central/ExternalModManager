using System;

namespace ExternalModManager.Core;

public class GlobalCounter
{
    public delegate void Notify();
    
    public event Notify ProcessCompleted;
    
    public int Counter { get; private set; }
    
    public void Add()
    {
        Counter++;
    }
}