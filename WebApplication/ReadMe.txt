Hosting Nancy with ASP.NET
==========================

Following the instructions at https://github.com/NancyFx/Nancy/wiki/Hosting-nancy-with-asp.net,
this is a host for NancyFX using ASP.NET.

It uses an HTTP Handler, which requires some of IIS to be installed.

Note: Nancy requires .NET 4.0.
To install this on a default-install Windows Server 2008 R2 Standard box,
you'll need to download and install it from [1] (for the standalone installer).
You all also need some other Windows Features installed, as detailed below.

[1] Microsoft .NET Framework 4 (Standalone Installer)
    http://www.microsoft.com/en-us/download/details.aspx?id=17718

Note: This mode requires ASP.NET v4.0.
To install this on a default-install Windows Server 2008 R2 Standard box,
use the following PowerShell command:

PS> Add-WindowsFeature Web-Asp-Net

This will install the following list of dependent features:

Display Name                                            Name                   
------------                                            ----                   
[X] Web Server (IIS)                                    Web-Server             
    [X] Web Server                                      Web-WebServer          
        [X] Common HTTP Features                        Web-Common-Http        
            [X] Default Document                        Web-Default-Doc        
        [X] Application Development                     Web-App-Dev            
            [X] ASP.NET                                 Web-Asp-Net            
            [X] .NET Extensibility                      Web-Net-Ext            
            [X] ISAPI Extensions                        Web-ISAPI-Ext          
            [X] ISAPI Filters                           Web-ISAPI-Filter       
        [X] Security                                    Web-Security           
            [X] Request Filtering                       Web-Filtering          

On Windows Server 2008, use the following command (taken from http://learn.iis.net/page.aspx/132/installing-iis-from-the-command-line/):

> start /w pkgmgr /iu:IIS-WebServerRole;IIS-WebServer;IIS-CommonHttpFeatures;IIS-StaticContent;IIS-DefaultDocument;IIS-DirectoryBrowsing;IIS-HttpErrors;IIS-HttpRedirect
> start /w pkgmgr /iu:IIS-ApplicationDevelopment;IIS-ASPNET;IIS-NetFxExtensibility;IIS-ISAPIExtensions;IIS-ISAPIFilter
> start /w pkgmgr /iu:IIS-Security;IIS-RequestFiltering

If you install ASP.NET _after_ .NET 4.0, you'll need to register it:

> C:\Windows\Microsoft.NET\Framework64\v4.0.30319\aspnet_regiis.exe -i

To install the web application, use the following PowerShell command
("`" is the PowerShell line continuation character):

PS> New-WebApplication -Site "Default Web Site" `
		-Name "nancy" `
		-PhysicalPath D:\Source\nancy-hosting\WebApplication `
		-ApplicationPool "ASP.NET v4.0"

A few notes about PowerShell modules:

To get the 'Add-WindowsFeature' command, you'll need to load the 'ServerManager' PowerShell module:

PS> Import-Module ServerManager

To get the 'New-WebApplication' command, you'll need to load the 'WebAdministration' PowerShell module:

PS> Import-Module WebAdministration

Note that the 'WebAdministration' module isn't installed by default; you need to add the ASP.NET bits, above.

Bugs:
 * FIXED - Getting a 403 Forbidden when attempting to browse to the site.
           To diagnose, first I installed Web-Mgmt-Console. NOTE: Revert the VM later.
	       Problem: "ASP.NET v4.0" Application Pool doesn't exist. Use "aspnet_regiis -i" to install it.

Aside:

If you install Web-Mgmt-Console, you get the following:

Display Name                                            Name                   
------------                                            ----                   
[X] Web Server (IIS)                                    Web-Server             
    [X] Management Tools                                Web-Mgmt-Tools         
        [X] IIS Management Console                      Web-Mgmt-Console       
[X] Remote Server Administration Tools                  RSAT                   
    [X] Role Administration Tools                       RSAT-Role-Tools        
        [X] Web Server (IIS) Tools                      RSAT-Web-Server        
