<?php
$hostname = 'localhost';
$username = 'root';
$password = '0000';
$database = 'highscores';

try
{
	
		$dbh = new PDO('mysql:host='.$hostname.';dbname='.$database, $username, $password);
}

catch(PDOException $e)
{
	
	echo '<h1> An error has occureed. </h1><pre>', $e ->getMessage(), '</pre>';
}

$sth = $dbh->query('SELECT * FROM scores ORDER BY score DESC LIMIT 5');
$sth -> setFetchMode(PDO::FETCH_ASSOC);

$result = $sth->fetchALL();

if(count($result) >0)
{
	foreach($result as $r)
	{
		echo $r['name'], "\n_";
		echo $r['score'], "\n_";
		
	}
	
}

?>