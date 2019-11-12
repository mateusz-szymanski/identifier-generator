#!/bin/bash

for i in $(seq 1 1000); do
    factory=$(head -c 500 /dev/urandom | tr -dc 'a-h0-2' | fold -w 5 | head -n 1)
    category=$(head -c 500 /dev/urandom | tr -dc 'a-h0-2' | fold -w 5 | head -n 1)
    curl -X POST http://api.identifier-generator.example-zone.com/api/identifier/$factory/$category -d {}
done
