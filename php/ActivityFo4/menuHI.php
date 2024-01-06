<?php
session_start();


if (empty($_SESSION['user'])) {
    header("Location: loginHI.php");
    die();
} else {
    $username = $_SESSION['user'];
}

?>

<!DOCTYPE html>
<html>

<head>
    <title>Welcome Page</title>
</head>

<body>
    <h1>Welcome, <?php echo "$username" ?>!</h1>
    <p>This is the home page. You are logged in.</p>
    <a href="logoutHI.php">Logout</a>
</body>

</html>