# Feature Flags Demo
This is an example implementation of [Microsoft.FeatureManagement](https://learn.microsoft.com/en-us/azure/azure-app-configuration/use-feature-flags-dotnet-core).

The flags can be overridden using appsettings.{environment}.json or using environment variables like `FeatureManagement__FeatureA`.

## Build and Run
1. Clone solution
2. Start debugging, Swagger should open automatically

## Filters
The behaviour can be extended and customised using [conditional feature flags](https://learn.microsoft.com/en-us/azure/azure-app-configuration/howto-feature-filters-aspnet-core). 
By using [targeting filters](https://learn.microsoft.com/en-us/azure/azure-app-configuration/howto-targetingfilter-aspnet-core), features can also be enabled on user/organization level.
