# ObjectBrawl ![.NET Core]
A .NET Core Brawl Stars Server for version 26

## Why?
We have seen way less private servers in the past, why? Because supercell has made it way harder to create a custom client. But thanks to Ultrapowa and many other people, there is still a chance for private servers. So here it is, sadly they are all not open source or not help anyone else to create such a project. 

Opegit/DNull have modified the frida-gadget lib to encrypt their script, so no one can read it. But Ultrapowa didn't and now we can just modify the client and use it for our project. Ultrapowa just disables the crypto for packets in the game, so we need no crypto at all, ofcourse this isn't the best solution in terms of security, but the easiest and fastest.

## Client
To connect to your server, you need a custom client. Here the only solution is to use a [pre-made client](https://drive.google.com/file/d/13CevFvqsLW2xzjEEOWGSh__1xRSXJmFh/view?usp=sharing).
Just edit the IP in the frida-gadget config (```/lib/armeabi-v7a/libgg.config.so```)
```{"interaction":{"interaction":{"type":"script","path":"libscript.so","on_change":"reload","parameters":{"redirectHost":"YOUR_IP","relocate":true}}}```

### Friendly reminder
The server is in a very early state. Right now, it is NOT recommended to run this on a production environment. Please not open issues about missing features, i'm well aware of this.
