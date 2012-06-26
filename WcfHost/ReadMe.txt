Hosting Nancy with WCF
======================

Following the instructions at https://github.com/NancyFx/Nancy/wiki/Hosting-nancy-with-wcf,
this is a host for NancyFX using WCF.

You'll need to ensure that you have permission to register the relevant URL,
so run the following command (elevated):

> netsh http add urlacl url=http://+:1234/ user=HOME\roger

If you specify a URL on the command line, you'll need to ensure that you
have permission for that. For example:

> netsh http add urlacl url=http://+:80/nancy user=HOME\roger

Note: Nancy requires .NET 4.0.
To install this on a default-install Windows Server 2008 R2 Standard box,
you'll need to download and install it from [1] (for the standalone installer).
You need *no* other Windows Features or Roles installed, at least for this sample.

[1] Microsoft .NET Framework 4 (Standalone Installer)
    http://www.microsoft.com/en-us/download/details.aspx?id=17718

Bugs:
 * [ ] If you specify a URL on the command line, and you don't specify a trailing /,
       the base path no longer matches, so you'll get a "404 Not Found".
       As a quick fix, I added a route for /nancy to match the second URL example above.
