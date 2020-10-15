# Curl requests

```bash
curl -X GET https://localhost:5001/api/order -H 'Content-Type:application/json' -k
curl -X GET https://localhost:5001/api/order/0f8fad5b-d9cb-469f-a165-70867728950e -H 'Content-Type:application/json' -i -k
curl -X POST https://localhost:5001/api/order -H 'Content-Type:application/json' -d '' -k
```