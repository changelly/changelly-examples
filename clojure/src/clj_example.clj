(ns clj-example
  (:require
   [cheshire.core :refer [generate-string]]
   [clj-http.client :as c]
   [buddy.core.keys :as kys]
   [buddy.core.mac :as mac]
   [buddy.core.codecs :as codecs]))

;; configure your key/secret
(def api-key "")
(def api-secret "")

(defn- base-changelly-request [params]
  (let [s-json (generate-string params)
        sign (-> s-json
                 (mac/hash {:key api-secret :alg :hmac+sha512})
                 (codecs/bytes->hex))]
    (let [resp (c/post "https://api.changelly.com"
                       {:headers {"api-key" api-key
                                  "sign" sign}
                        :body s-json
                        :as :json
                        :content-type :json})]
      (:body resp))))

(defn rand-id []
  (rand-int Integer/MAX_VALUE))

(def changelly-api-set
  #{"getCurrencies" "getCurrenciesFull" "getMinAmount"
    "getExchangeAmount" "generateAddress" "validateAddress"
    "createTransaction" "getStatus" "getTransactions"})

(defn changelly-call
  ([api]
   (changelly-call api {}))
  ([api params]
   {:pre [(changelly-api-set api)]}
   (base-changelly-request
    {"id" (rand-id)
     "jsonrpc" "2.0"
     "method" api
     "params" (or params {})})))


(comment
  "Read doc to set parameters, https://api-docs.changelly.com/" 
  (changelly-call "getMinAmount" {:from "eth" :to "btc"})
  )



