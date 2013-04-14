<?php
/*
 * Copyright 2013 Gamemakergm <gamemakergm@safaree.org>
 * This work is licensed under the Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License. 
 * To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-sa/3.0/ or send a letter to
 * Creative Commons, 444 Castro Street, Suite 900, Mountain View, California, 94041, USA.
 */
/**
 * Replaces a specified line in a file with the specified line.
 * @author Gamemakergm
 * @param string $filePath - Path to file
 * @param int	 $lineNumber - Line number to replace.
 * @param string $newLine - The new line to put.
 */
function ReplaceLine($filePath, $lineNumber, $newLine){
	$contents = file($filePath);
	$countents[$lineNumber - 1] = $newLine;
	file_put_contents($filePath, implode('', $contents));
}
/**
 * Checks the $_POST data to make sure it's correct.
 * @author Gamemakergm
 * @param array $postData - $_POST data array passed from beat.php
 * @param array $expectedData - Array containing data that is expected.
 * @return - False if invalid data, array with post values if good data.
 */
function CheckPOSTData($postData, $expectedData){
	$data = array(); // We will return array with good values if we can.
	for($i = 0; $i < count($expectedData); ++$i){
		$currentItem = $expectedData[$i];
		$validItem = isset($postData[$currentItem]);
		if(!$validItem){ // The post data didn't have the expected item.
			return false; // Oh noes.
			break;
		}
		$data[$i] = $postData[$currentItem]; // Otherwise add it to the array!
	}
	return $data;
}
?>