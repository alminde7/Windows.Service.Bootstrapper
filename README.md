# Windows Service Bootstrapper

Windows.Service.Bootstrapper is a wrapper around Topshelf, to make the creation of windows services even easier. 

## Use


```csharp
class Program
{
    static void Main(string[] args)
    {
        Windows.Service.Bootstrapper.Service.Bootstrap<Service>();
    }
}
```



```csharp
public class Service : IService
{
    public void Start()
    {
        // Do initialization stuff
    }

    public void Stop()
    {
        // Do cleanup stuff
    }
}
```