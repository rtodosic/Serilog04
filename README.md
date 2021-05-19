
## .Net Core Serilog – Enrichers

Serilog enrichers add additional information to the output, which could be quite useful in debugging.

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
 
3.	Now add “Serilog.Enrichers.Environment” ” NuGet package to your project.
  
4.	In Program.cs, change the  CreateHostBuilder() method to the following:

5.	Run the application again and notice the output:
 
6.	Notice that we now see the MachineName and Assembly added to the log. 

### Additional
There are several different enrichers that you can add check the documentation for more information. 
 
From [Serilog’s documentation on enrichers](https://github.com/serilog/serilog/wiki/Enrichment)
