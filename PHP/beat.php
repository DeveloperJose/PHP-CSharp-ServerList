<?php
/*
 * Copyright 2013 Gamemakergm <gamemakergm@safaree.org>
 * This work is licensed under the Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License. 
 * To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-sa/3.0/ or send a letter to
 * Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.
 */
require 'beatFunctions.php';
require 'beatSettings.php';

/* Don't modify below this point! */
$ip = $_POST['ip']; // We use IP to allow only one entry per server.
if(!isset($ip)) {
	die ("Primary key was not found. Report to Gamemakergm!");
}
$validIP = filter_var($ip, FILTER_VALIDATE_IP);
if(!$validIP){ // I'd be amazed if they got past my C# filter. But just in case.
	die ("Invalid IP!");
}
$validData = CheckPOSTData($_POST, $postData);

if(!validData){
	die($invalidHeartbeatMessage); // Not a valid heartbeat so stop.
}

if(!$useDatabase) {
	/*
	 * a+ will
	 * Create if not exists.
	 * Add to end of file.
	 */
	$fileHandle = fopen($infoStoragePath, 'a+') or die ("Couldn't open flatfile!");
	
	$foundLine = false; // If we found the line to replace.
	$i = 0; // What line number it is.
	while(!feof($fileHandle)){ // While there's no end of file.
		$line = fgets($fileHandle);
		$lineArray = explode('|', $line); // Get the whole line
		if($lineArray[0] == $ip){ // Check key
			$foundLine = true;
			break;
		}
		$i++;
	}
	array_unshift($validData, $ip); // Put ip in the beginning as key.
	$dataLine = implode("|", $validData);
	if($foundLine){
		ReplaceLine($infoStoragePath, $i, $dataLine);
	}
	else{
		fwrite($fileHandle, $dataLine."/n");
	}
	fclose($fileHandle);
}
echo $succesfulHeartbeatMessage;
?>