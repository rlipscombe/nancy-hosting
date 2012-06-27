Self-hosting Nancy
==================

This is a host for NancyFX using self-hosting.

You'll need to ensure that you have permission to register the relevant URL,
so run the following command (elevated):

> netsh http add urlacl url=http://localhost:1234/ user=HOME\roger

This is different from the WCF host, which used '+' for the URL ACL.
Nancy self-hosting uses HttpListener, which expects the URL ACL to match exactly.
Unfortunately, you can't pass '+' to the Uri constructor, because it's not a valid hostname.
This is a problem.

If you specify a URL on the command line, you'll need to ensure that you
have permission for that. For example, if you want to port-share with IIS:

> netsh http add urlacl url=http://localhost:80/nancy user=HOME\roger

Note: Nancy requires .NET 4.0.
To install this on a default-install Windows Server 2008 R2 Standard box,
you'll need to download and install it from [1] (for the standalone installer).
You need *no* other Windows Features or Roles installed, at least for this sample.

[1] Microsoft .NET Framework 4 (Standalone Installer)
    http://www.microsoft.com/en-us/download/details.aspx?id=17718

Bugs:
 * [ ] It appears that sometimes you *don't* need to register the URL ACL.
       More investigation required.
