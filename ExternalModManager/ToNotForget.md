## 

# Create async comment for HTTP request with a input throttle
```csharp
[Reactive]
public string Search { get; set; } = String.Empty;

[Reactive]
public string OutputString { get; private set; } = String.Empty;

public ReactiveCommand<Unit, Unit> AsyncCommand { get; set; } 

public CustomerVM()
{
    AsyncCommand = ReactiveCommand.CreateFromTask(AsyncMethod);
    
    this.WhenAnyValue(x => x.Search)
        .Throttle(TimeSpan.FromMilliseconds(500))
        .Select(time => Unit.Default)
        .InvokeCommand(this, x => x.AsyncCommand);
}
    
public async Task AsyncCommand()
{
    Console.WriteLine("Before");

    await Task.Delay(3000);
    
    Console.WriteLine("After");
    
    OutputString = "Hello world: " + Search 
}
```

# Cancel async commands
```csharp
public ReactiveCommand<Unit, Unit> CancelableCommand { get; }

public ReactiveCommand<Unit, Unit> CancelCommand { get; }

public CustomerVM()
{
    CancelableCommand = ReactiveCommand.CreateFromObservable(
            () => Observable
                .StartAsync(ct => DoSomethingAsync(ct))
                .TakeUntil(CancelCommand));
    
    CancelCommand = ReactiveCommand.Create(() => { }, CancelableCommand!.IsExecuting);
    
    var interval = TimeSpan.FromSeconds(1);
    Observable.Timer(interval, interval)
        .Select(time => Unit.Default)
        .InvokeCommand(this, x => x.CancelCommand);
}

private async Task DoSomethingAsync(CancellationToken ct)
{
    Console.WriteLine("Starting");
    
    await Task.Delay(TimeSpan.FromSeconds(5), ct);
    
    Console.WriteLine("Stopping");
}
```