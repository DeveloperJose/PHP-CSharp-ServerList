<?php
/*
 * Copyright 2013 Gamemakergm <gamemakergmdev@gmail.com>
 * This work is licensed under the Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License. 
 * To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-sa/3.0/ or send a letter to
 * Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.
 *
 * Modify these variables below to your needs.
 */
// NOTE: DATABASE DOESN'T WORK YET. DON'T ENABLE IT YET. NOTHING WILL HAPPEN IF YOU DO.
$useDatabase = false; // Whether to use SQL Databse. If false, flatfile will be used.

$infoStoragePath = "serverList.txt"; // Change if using flatfile instead of database.

$postData = array('isPublic', 'serverName'); // Data to get. C# and this have to match. Make sure these match the order of the titles below.
$postDataTableTitles = array('Server is Public', 'Name of Server'); // These will be the titles for the HTML table.

$succesfulHeartbeatMessage = "Succesful heartbeat!"; // This is shown when the heartbeat is good.
$invalidHeartbeatMessage = "Invalid heartbeat! :("; // This is shown the the heartbeat is missing information.
?>