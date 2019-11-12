openssl genrsa -out ingress.key 2048

openssl req -new -key ingress.key -out ingress.csr \
    -config csr-ingress.conf -batch

openssl x509 -req -days 365 -in ingress.csr -signkey ingress.key \
    -out ingress.crt -extfile csr-ingress.conf -extensions extensions

openssl req -in ingress.csr  -text -noout
openssl x509 -in ingress.crt  -text -noout

echo cert:
base64 ingress.crt | tr -d '\n'
echo 

echo key:
base64 ingress.key | tr -d '\n'
echo