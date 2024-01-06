<!DOCTYPE html>
<html>

<head>
    <title>Login Page</title>
</head>

<body>
    <h1>Login Page</h1>

    <?php

    session_start();


    if (isset($_POST['username']) && isset($_POST['password'])) {
        $username = $_POST['username'];
        $password = $_POST['password'];



        $_SESSION["user"] = "$username";

        echo $_SESSION["username"];
        // Redirect to the home page
        // echo '<br /><a href="home.php?' . SID . '">page 2</a>';

        header("Location: menuHI.php");
    }
    ?>

    <form method="post">
        <label for="username">Username:</label>
        <input type="text" id="username" name="username" required>
        <br>
        <label for="password">Password:</label>
        <input type="password" id="password" name="password" required>
        <br>
        <input type="submit" value="Login">
    </form>
</body>

</html>