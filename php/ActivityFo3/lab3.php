<html>

<head>
    <title>Welcome to h_Ihsan's page</title>
</head>

<body>
    <h1>simple calculator - Hassan Ihsan</hi>

        <?php

        if (isset($_POST['num1']) && isset($_POST['num2'])) {


            $num1 = $_POST['num1'];
            $num2 = $_POST['num2'];

            $result = $num1 + $num2;
        }
        ?>
        <form method="post">
            <label style="font-size: small;">number 1</label>
            <input type="text" name="num1" placeholder="Enter first number" required value="<?php if (!empty($num1)) {
                                                                                                echo "$num1";
                                                                                            }  ?>">
            <br>
            <label style="font-size: small;">+ number 2</label>
            <input type="text" name="num2" placeholder="Enter second number" required value="<?php if (!empty($num2)) {
                                                                                                    echo "$num2";
                                                                                                }  ?>">

            <br>
            <input type="submit" value="Calculate">


        </form>

        <?php

        if (!empty($result)) {
            echo "Total: $num1 + $num2 = $result";
        }

        ?>


</body>

</html>