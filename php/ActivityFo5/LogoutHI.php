<?php
session_start();
session_destroy();
header("Location: loginHI.php");
exit();
