"ShoppingBasket" 

This is a .NET Core 3.1. Web API application which is using postgresql, so please make sure that you change the connection string accordingly.

Work in progress:
- improve discount logic to cover more cases
- refactor base repository to accept models instead of entites so the mapping from model to entity and in reverse, can be moved to repositories completely
- fix efcore eager loading issues with product, check for circular references
- improve error handling
- improve controllers logic - handle errors, use better routing conventions
- move REST models from controllers to a separate folder in API project
- modify logging to log errors, system info along with analytics.log
