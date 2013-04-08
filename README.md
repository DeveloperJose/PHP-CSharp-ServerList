ServerList
===================
PHP and C# powered heartbeater and server lister for any kind of game/application.
Created by Gamemakergm <gamemakergm@safaree.org>

To see a working example of the C# side, look at the ConsoleExample project.

Don't be afraid of making pull requests! All requests and comments/issues are welcome.
If you make modifications to my work I'd love for you to email me with the details of your modification, that would be awesome.

License
===================
For licensing details see LICENSE.txt.

Setting up the C# side
===================
1. Create a class that implements IHeartbeat and implement all of the IHeartbeat members.
2. Make your server class implement IHeartbeatServer and implement all of its members.
3. Make sure that the data you add to your heartbeat class gets added to beat.php

Setting up the PHP side
===================
1. Coming soon.

Setting up the Web side
===================
1. Add ip.php to the location you want on your site.
2. Add beat.php to the location you want on your site.
3. Make sure to update the C# side accordingly.