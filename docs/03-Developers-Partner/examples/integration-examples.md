# Partner Integration Examples

## List Available Books

```http
GET /api/books/available HTTP/1.1
Host: library-api.example.com
Accept: application/json
```

### Response
```json
[
  {
    "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
    "title": "Clean Architecture",
    "author": "Robert C. Martin",
    "isbn": "978-0134494166",
    "publishedYear": 2017,
    "isAvailable": true,
    "bookCategoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  }
]
```

## Create a Customer

```http
POST /api/customers HTTP/1.1
Host: library-api.example.com
Content-Type: application/json

{
  "firstName": "Ali",
  "lastName": "Yılmaz",
  "email": "ali.yilmaz@example.com",
  "phone": "+905551234567",
  "address": "İstanbul, Türkiye",
  "membershipNumber": "MBR-2024-001"
}
```

### Response (201 Created)
```json
{
  "id": "b2c3d4e5-f6a7-8901-bcde-f12345678901",
  "firstName": "Ali",
  "lastName": "Yılmaz",
  "email": "ali.yilmaz@example.com",
  "phone": "+905551234567",
  "address": "İstanbul, Türkiye",
  "membershipNumber": "MBR-2024-001",
  "registeredDate": "2024-01-15T10:30:00Z",
  "isActive": true
}
```

## Update a Book

```http
PUT /api/books/a1b2c3d4-e5f6-7890-abcd-ef1234567890 HTTP/1.1
Host: library-api.example.com
Content-Type: application/json

{
  "title": "Clean Architecture (Updated)",
  "author": "Robert C. Martin",
  "isbn": "978-0134494166",
  "publishedYear": 2017,
  "isAvailable": false,
  "bookCategoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

### Response (204 No Content)
No response body.

## Error Handling Example

```http
GET /api/books/00000000-0000-0000-0000-000000000000 HTTP/1.1
Host: library-api.example.com
```

### Response (404 Not Found)
No response body.
