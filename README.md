# WoocommerceSharp
A C# client for the WooCommerce REST Api. Forked from `putuyoga/WoocommerceSharp`.
I just change the behavior, refactor and bug fixing from the original codes.

## What is the Difference
1. Asynchronous Call
2. Support WinRT (Moved from WebClient to HttpClient)
3. Connects with the latest version of the WooCommerce API v.2.6.4 - `wp-json/wc/v1/`

## Usage
Keep it simple, just instantiate the WoocommerceApiClient and you are ready to go.
```cs
const string StoreUrl = "https://mywebsite.com/";
const string ConsumerKey = "ck_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
const string ConsumerSecret = "cs_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
const bool IsSsl = true;
const bool QueryStringAuth = false;
var api = new WoocommerceApiClient(StoreUrl, ConsumerKey, ConsumerSecret, IsSsl, QueryStringAuth);
```
### Examples

#### Get All Products
```csharp
var result = api.Products.Get().Result; // to call normally
var result = await api.Products.Get(); // to call async
```

#### Get All Orders
```csharp
var OrdersList = api.Orders.Get().Result;
foreach (Order Order in OrdersList) {
	Console.WriteLine("Order: #{0}; Order Total Value: {1}; Order Status: {2}; Payment Method: {3}", Order.Number, Order.Total, Order.Status, Order.PaymentMethodTitle);
}
```

#### Create a Category
```csharp
var category = new ProductCategory {
	Name = "My Products Category",
	Slug = "my-products-category",
	Descripton = "Thi is my custom products category"
};
var categoryResult = api.ProductCategories.Create(category).Result;
Console.WriteLine("Category: {0} - {1} - {2}", categoryResult.Id, categoryResult.Name, categoryResult.Slug);
```

* Will be updated later for full usage documentation.

## To Do List
- ...;
