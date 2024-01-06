<html>

<head>
    <title>Welcome to h_Ihsan's page</title>
</head>

<body>
    <h1>loging with sql- Hassan Ihsan</hi>


        <form method="post">
            <label style="font-size: small;">username</label>
            <input type="text" name="username" placeholder="Enter usrename" required>
            <br>
            <label style="font-size: small;">password</label>
            <input type="text" name="password" placeholder="Enter password" required>

            <br>
            <input type="submit" value="Login">


        </form>

        <?php
        session_start();
        $error = '';



        if (isset($_POST['username']) && isset($_POST['password'])) {

            require("./connectvars.php");

            $mysqli = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_NAME);

            if ($mysqli->connect_errno) {
                echo "Failed to connect to MySQL: (" .
                    $mysqli->connect_errno . ") " .
                    $mysqli->connect_error;
            }
            $userid = $mysqli->real_escape_string($_POST['username']);
            $password = $mysqli->real_escape_string($_POST['password']);


            $query = "SELECT * FROM users WHERE userid='$userid' AND password='$password'";

            $result = $mysqli->query($query);

            if ($result->num_rows > 0) {
                $_SESSION['userid'] = $userid;
                header("Location:  MenuHI.php");
                die();
            } else {
                echo "error";
            }
        }

        ?>


</body>

</html>