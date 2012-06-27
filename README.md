# nancy-hosting #

Figuring out the minimal installation requirements for hosting NancyFX.

## Summary ##

If you want to use IIS as a container, you'll need to use the ASP.NET Hosting. This has the advantage that you don't need to write a separate service. In some circumstances, this can reduce your deployment overhead. It has the disadvantage of requiring (some of) IIS.

If you want to avoid a dependency on IIS, you'll need to use either the WCF hosting or Self-hosting.

It might be possible to use the OWIN host, but I've not looked at that yet.

You could also write a custom host, but I've assumed that, at best, it's equivalent to Nancy's built-in self-hosting.

## WCF Hosting ##

Requirements:

 * .NET 4.0

Advantages:

***TODO*** 

Disadvantages:

***TODO***

## ASP.NET Hosting ##

Requirements:

 * .NET 4.0
 * `Add-WindowsFeature Web-Asp-Net`
 * `aspnet_regiis -i`

Advantages:

***TODO*** 

Disadvantages:

***TODO***

## Self Hosting ##

Requirements:

 * .NET 4.0

Advantages:

***TODO*** 

Disadvantages:

***TODO***
