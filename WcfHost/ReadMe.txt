Hosting Nancy with WCF
======================

Following the instructions at https://github.com/NancyFx/Nancy/wiki/Hosting-nancy-with-wcf, this is a host for NancyFX using WCF.
You'll need to ensure that you have permission to register the relevant URL, so run the following command (elevated):

> netsh http add urlacl url=http://+:1234/ user=HOME\roger
