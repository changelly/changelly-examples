<?php
    /**
    * @author Sachin kumar
    */

    // Check error if exists
    ini_set('display_errors', 1);
    ini_set('display_startup_errors', 1);
    error_reporting(E_ALL);

    class changelly
    {
        // public and private members
        public $apiKey;
        private $apiSecret;
        public static $apiUrl = 'https://api.changelly.com';
        public $response;

        /**
         * Create a new changelly instance.
         *
         * @return void
         */
        function __construct($apiKey, $apiSecret)
        {
            $this->apiKey = $apiKey;
            $this->apiSecret = $apiSecret;
        }

        /**
        * Show the Response.
        *
        * @return response as JSON.
        */
        function response(){
            return $this->response;
        }

        /**
        * This function is used to perform all type of methods in challengely APIs.
        * @param  array  $params, methodName string
        * @return call to response function.
        */
        function commonFunction($methodName, $params = array()){
            $message = json_encode(
                array('jsonrpc' => '2.0', 'id' => 1, 'method' => $methodName, 'params' => $params)
            );
            $sign = hash_hmac('sha512', $message, $this->apiSecret);
            $requestHeaders = [
                'api-key:' . $this->apiKey,
                'sign:' . $sign,
                'Content-type: application/json'
            ];
            $this->curl($message, $requestHeaders);
            return $this->response();           
        }
        /**
        * Curl function to perform curl operation
        *
        * @param  json_encoded string $message, requestHeaders array
        * @return void
        */
        function curl($message,$requestHeaders){
            $ch = curl_init(self::$apiUrl);
            curl_setopt($ch, CURLOPT_POST, 1);
            curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
            curl_setopt($ch, CURLOPT_POSTFIELDS, $message);
            curl_setopt($ch, CURLOPT_HTTPHEADER, $requestHeaders);
            
            $this->response = curl_exec($ch);
            curl_close($ch); 
        }
    }

    $changelly = new changelly('YOUR_API_KEY', 'YOUR_API_SECRET');

    print_r($changelly->commonFunction('getCurrencies'));
    $params = array("from" => "eth", "to" => "btc", "amount" => "1");
    print_r($changelly->commonFunction('getExchangeAmount', $params));
    $params = array("from" => "eth", "to" => "btc");
    print_r($changelly->commonFunction('getMinAmount', $params));