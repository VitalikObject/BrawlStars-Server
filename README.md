# ObjectBrawl ![.NET Core](https://github.com/VitalikObject/BrawlStars-Server/workflows/.NET%20Core/badge.svg?branch=master)
A first open source .NET Core Brawl Stars Server for version 26!
![ScreenShot](https://cdn.discordapp.com/attachments/728556050285985823/728667043397632010/Screenshot_20200703-204228_BS_v26.jpg) 

## Configuration
You can change default name in config.json
(```"default_name": "YOUR_NAME"```)
And you can change the starting resources in config.json

## Client
To connect to your server, you need a custom client. Here the only solution is to use a [pre-made client](https://drive.google.com/file/d/13CevFvqsLW2xzjEEOWGSh__1xRSXJmFh/view?usp=sharing).
Just edit the IP in the frida-gadget config (```/lib/armeabi-v7a/libgg.config.so```)
```{"interaction":{"interaction":{"type":"script","path":"libscript.so","on_change":"reload","parameters":{"redirectHost":"YOUR_IP","relocate":true}}}```

### Friendly reminder
The server is in a very early state. Right now, it is NOT recommended to run this on a production environment. Please not open issues about missing features, i'm well aware of this. 

##### Need help? Join my [Discord](https://discord.gg/VPWMxWm)
