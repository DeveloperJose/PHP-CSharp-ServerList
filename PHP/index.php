<html>
<!--
    Copyright 2013 Gamemakergm <gamemakergm@safaree.org>
    This work is licensed under the Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License.
    To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-sa/3.0/ or send a letter to
    Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.
-->
<head>
<title>Server Lister by Gamemakergm </title>
<link rel="stylesheet" type="text/css" href="beatStyle.css"/> <!-- Get our styles! -->
</head>
<body>
<?php require 'beatSettings.php'; ?> <!-- Require our file -->
<table>
<tr>
<?php
for($i = 0; $i < count($postDataTableTitles); $i++){ // Loop through our titles.
	echo "<th>".$postDataTableTitles[$i]."</th>"; // Print them as table heads.
}
?>
</tr>
<tr>
<?php
if(!$useDatabase){
	// TODO: Delete older entries.
	// TODO: Sorting.
	$serverList = file($infoStoragePath); // Read the data from our file.
	for($i = 0; $i < count($serverList); $i++){ // Get all of our servers.
			$currentServer = explode("|", $serverList[$i]); // Separate all of our server details into an array.
		for($ii = 1; $ii < count($currentServer); $ii++){ // Our index is at 1 to not print the IP(Key) value.
			echo "<td>".$currentServer[$ii]."</td>"; // Print the rest of the values.
		}
	}
}
?>
</tr>
</table>
<hr />
<p style="font-size:8px">
Copyright 2013 Gamemakergm. Created by Gamemakergm, <a href="mailto:gamemakergm@safaree.org?Subject=ServerListWebsite">Contact Me </a>
</p>
</body>
</html>