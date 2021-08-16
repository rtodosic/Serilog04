## Context
1. [.Net Core Serilog – Basic](https://github.com/rtodosic/Serilog01/)
2. [.Net Core Serilog – Configuration](https://github.com/rtodosic/Serilog02/)
3. [.Net Core Serilog - Structured JSON output](https://github.com/rtodosic/Serilog03/)
4. .Net Core Serilog - Enrichers
5. [.Net Core Serilog - Custom JSON output](https://github.com/rtodosic/Serilog05/)
6. [.Net Core Serilog - Adding Sinks](https://github.com/rtodosic/Serilog06/)

This is part 4 of 6.

## 4. .Net Core Serilog – Enrichers

Serilog enrichers add additional information to the output, which acn be quite useful in debugging.

1.	To make the output smaller, change the appsettings.json file to the following:
  ```JSON
  {
    "Serilog": {
      "MinimumLevel": {
        "Default": "Error",
        "Override": {
          "Serilog04": "Debug",
          "Microsoft.Hosting.Lifetime": "Warning"
        }
      }
    },
    "AllowedHosts": "*"
  }
  ```

2.	Run the application and notice the output:
  ![Image alt text](Images/Console-No-Enrichers.png?raw=true)
 
3.	Now add “Serilog.Enrichers.Environment” NuGet package to your project.
  ![Image alt text](Images/NuGet-Serilog-Enricher-Env.png?raw=true)

4.	In Program.cs, change the  CreateHostBuilder() method to the following:
    ```C#
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
        .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
            .ReadFrom.Configuration(hostingContext.Configuration)
            //--> Add this Start
            .Enrich.FromLogContext() 
            .Enrich.WithMachineName() 
            .Enrich.WithProperty("Assembly", typeof(Program).Assembly.GetName().Name)
            //--> Add this Start
            .WriteTo.Console(new CompactJsonFormatter())
        );
    ```

5.	Run the application again and notice the output:
  ![Image alt text](Images/Console-Enrichers.png?raw=true)
 
6.	Notice that we now see the MachineName and Assembly in the log. 

### Additional
There are several different enrichers that you can add check the documentation for more information. 
 
[Serilog’s documentation on enrichers](https://github.com/serilog/serilog/wiki/Enrichment)
