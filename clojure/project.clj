(defproject clj "0.1.0-SNAPSHOT"
  :description "changelly clojure example"
  :license {:name "Eclipse Public License"
            :url "http://www.eclipse.org/legal/epl-v10.html"}
  :dependencies [[org.clojure/clojure "1.8.0"]
                 [cheshire "5.8.0"]
                 [clj-http "3.9.1"]
                 [buddy/buddy-sign "3.0.0" :exclusions [cheshire]]
                 [buddy/buddy-auth "2.1.0" :exclusions [buddy/buddy-sign cheshire]]])
