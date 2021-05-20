# Project Notes






## ASP.NET Stuff

There are two (or three) default paths, and here is how they get mapped to code:

*   https://localhost:44309/ and https://localhost:44309/Home/Index hit the `HomeController` and the `Index` action.
*   https://localhost:44309/Home/Privacy hits the `HomeController` and the `Privacy` action.

What controls this? This is called "Routing" in ASP.NET. It's setup in `Startup.cs`. Search for the function `MapControllerRoute`.




