# Curl requests

```bash
curl -X GET https://localhost:5001/api/order -H 'Content-Type:application/json' -k
curl -X GET https://localhost:5001/api/order/b4c59be8-15eb-45e8-a14b-5f07072ef643 -H 'Content-Type:application/json' -i -k
curl -X POST https://localhost:5001/api/order -H 'Content-Type:application/json' -d '{"itemsIds": ["1","4"]}' -i -k
```