<?php
    $apiKey = ' ed19ea6c890d425f9a7954030a15aeab';
    $apiSecret = ' 0cd47a64df2eda4ec46d0c206ce09ff7a66e33f3d6293260c65176c476925012';
    $apiUrl = 'https://api.changelly.com';

    $message = json_encode(
        array('jsonrpc' => '2.0', 'id' => 1, 'method' => 'getCurrencies', 'params' => array())
    );
    $sign = hash_hmac('sha512', $message, $apiSecret);
    $requestHeaders = [
        'api-key:' . $apiKey,
        'sign:' . $sign,
        'Content-type: application/json'
    ];

    $ch = curl_init($apiUrl);
    curl_setopt($ch, CURLOPT_POST, 1);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($ch, CURLOPT_POSTFIELDS, $message);
    curl_setopt($ch, CURLOPT_HTTPHEADER, $requestHeaders);
    
    $response = curl_exec($ch);
    curl_close($ch);

    var_dump($response);
