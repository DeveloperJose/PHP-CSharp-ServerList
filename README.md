ServerList
===================
PHP and C# powered heartbeater and server lister for any kind of game/application. Inspired by Minecraft's classic server lister.

To see a working example of the C# side, look at the ConsoleExample project.

Don't be afraid of making pull requests! All requests and comments/issues are welcome.
If you make modifications to my work I'd love for you to email me with the details of your modification, that would be awesome.

Analyze, ask questions, and build upon this! The index provided is only a minimal index with minimal styling! Modify to your style :D

License
===================
For licensing details see LICENSE.txt.

Setting up the C# side
===================
1. Build the ServerListAPI project and reference it in your project.
2. Create a class that implements IHeartbeat and implement all of the IHeartbeat members.
3. Make your server class implement IHeartbeatServer and implement all of its members.
4. Make sure that the data you add to your heartbeat class gets added to beat.php

Setting up the PHP side
===================
1. Edit beatSettings.php to your desires.
2. Make sure that the data in $postData matches the one in your C# heartbeat!

![C# Image example](/serverList.PNG "C# side.")

![PHP Image example](/beatSettingsPHP.PNG "PHP side.")
Setting up the Web side
===================
1. Add ip.php to any location you want on your site and make sure to link it to your server class implementing IHeartbeatServer
![IHeartbeatServer Implementation](/IPAddress.PNG "Make sure this is the address to your ip.php file")
2. Add beat.php, beatSettings.php, and beatFunctions.php to your site root.
3. Add index.php and beatStyle.css to your site root.
