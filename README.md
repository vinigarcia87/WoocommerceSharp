# WoocommerceSharp
A C# client for the WooCommerce REST Api. Forked from SharCommerce by Zachary Keeton. I just change the behavior, refactor and bug fixing from the original codes.

## What is the Difference
1. Asynchronous Call
2. Support WinRT (Moved from WebClient to HttpClient)
3. ...

## Usage
Keep it simple, just instantiate the WoocommerceApiClient and you are ready to go.
```cs
  var api = new WoocommerceApiClient(StoreUrl, ConsumerKey, ConsumerSecret);
```
### Example: Get All Products
```csharp
var result = api.Products.Get().Result; // to call normally
var result = await api.Products.Get(); // to call async
```
Will be updated later for full usage documentation.
