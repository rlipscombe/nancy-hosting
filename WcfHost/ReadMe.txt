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

Configuring for SSL:

> netsh http add urlacl url=https://+:12344/ user=HOME\roger
> certutil -store My

(this displays a list of the available certificates; pick the appropriate one)

> netsh http add sslcert ipport=0.0.0.0:12344 certhash=dbd7af60fac84478ba507de1b638ed6f40c6c46b appid={795E1F1F-13AE-4145-9AB1-7B504031442D}

(replace the certhash value with the one displayed by certutil -- remove the spaces; the appid is an arbitrary GUID).

Bugs:
 * [ ] If you specify a URL on the command line, and you don't specify a trailing /,
       the base path no longer matches, so you'll get a "404 Not Found".
       As a quick fix, I added a route for /nancy to match the second URL example above.
