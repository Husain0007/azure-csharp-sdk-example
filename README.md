# azure-csharp-sdk-example

### Install Azure on Github Codespaces

```
  curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash
```

### Creating .NET Project

* Initiate Azure login via Terminal to use Azure CLI Commandlets.
  ```
      az login --use-device-code
  ```

* Create a .NET Project.
  ```
      dotnet new console -n package-dotnet -f net 8.0
  ```
  
