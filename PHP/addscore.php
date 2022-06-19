<?php
$hostname = 'localhost';
$username = 'root';
$password = '0000';
$database = 'highscores';
$secrtKey = "UnityC";

try
{
	
	$dbh = new PDO('mysql:host='.$hostname.';dbname='.$database, $username, $password);
}

catch(PDOException $e)
{
	
	echo '<h1> An error has occureed. </h1><pre>', $e ->getMessage(), '</pre>';
}


$hash = $_GET['hash'];
$realHash =hash('sha256',$_GET['name'].$_GET['score'].$secrtKey);

if($realHash == $hash) 

{
	
	$sth = $dbh->prepare('INSERT INTO scores VALUES (/*null,*/ :name, :score);'); 

	try
	{
		$sth -> bindParam(':name', $_GET['name'],
		PDO::PARAM_STR);
		
		$sth -> bindParam(':score', $_GET['score'],
		PDO::PARAM_INT);
		
		if($sth -> execute())
		{
			echo "excute 성공!!!";

		}

		else
		{

			echo "excute 실패 ㅠㅠㅠ!!!";
		}
	}
	
	catch(Exception $e)
	{
		echo'<h1>An error has ocurred</h1><pre>',
		$e-> getMessage(),'</pre>';
		
	}
}

else
{

	echo "Hash is Not Match";
}


?>