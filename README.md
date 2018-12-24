# config-manager

Creates a specified configuration file (in JSON) for use in your application.

## Installation

```
dotnet add package JJConfigManager
```

## Included Dependencies

* Newtonsoft.Json

## Basic Usage

Setup your own config model then use it like so:


```cs
public class Config
{
    public string AppName {get;set;}
    public string Path {get;set;}

    public Config(string name, string path)
    {
        AppName = name;
        Path = path;
    }
}
```
```cs
public class Example
{
    private Configuration<Config> _config;

    public Example()
    {
        // no parameter will create "config.json" in root directory
        _config = new Configuration<Config>();

        SetupConfig();
        DoStuff();
    }

    public void SetupConfig()
    {
        var defaultConfig = new Config("myapp", "path/to/exe");

        _config.WriteJSON(defaultConfig);
        _config.ReadJSON();
    }

    public void DoStuff()
    {
        Console.WriteLine(_config.Data.AppName);
    }
}
```