#!/bin/bash

url="http://api.identifier-generator.example-zone.com"
nOfProcesses=20
nOfRequestsInProcess=100

send() {
    for i in $(seq 1 $nOfRequestsInProcess); do
        factory=$(head -c 100 /dev/urandom | tr -dc 'a-c' | fold -w 3 | head -n 1)
        category=$(head -c 100 /dev/urandom | tr -dc 'a-c' | fold -w 3 | head -n 1)
        curl -X POST $url/api/identifier/$factory/$category -d {} 2 &>/dev/null
        if [[ $(($i % 10)) == 0 ]]; then
            echo PID: $BASHPID - sent $i
        fi
    done
}

for i in $(seq 1 $nOfProcesses); do
    echo starting $i process...
    send &
    pids[${i}]=$!
done

for pid in ${pids[*]}; do
    echo "waiting for $i process..."
    wait $pid
done
