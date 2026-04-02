# Mapping & SSO Scenarios

## Data Mapping

### Customer Fields Mapping

When integrating external systems with the Library API, map your customer fields as follows:

| External System Field | Library API Field | Type | Required | Constraints |
|---|---|---|---|---|
| Name / GivenName | `firstName` | string | ✅ | Max 100 chars |
| Surname / FamilyName | `lastName` | string | ✅ | Max 100 chars |
| Email Address | `email` | string | ✅ | Max 200 chars, unique |
| Phone Number | `phone` | string | ❌ | Max 20 chars |
| Address / Location | `address` | string | ❌ | Max 500 chars |
| Member ID | `membershipNumber` | string | ✅ | Max 50 chars, unique |

### Book Fields Mapping

| External System Field | Library API Field | Type | Required | Constraints |
|---|---|---|---|---|
| Title | `title` | string | ✅ | Max 200 chars |
| Author Name | `author` | string | ✅ | Max 150 chars |
| ISBN-13 | `isbn` | string | ✅ | Max 20 chars, unique |
| Year Published | `publishedYear` | int | ✅ | — |
| Availability Status | `isAvailable` | bool | ✅ | Default: true |
| Category Reference | `bookCategoryId` | GUID | ❌ | Must be valid category ID |

## SSO Scenarios (Planned)

### Overview

Single Sign-On (SSO) integration is planned for future releases. The following scenarios are under consideration:

### Scenario 1: OAuth 2.0 / OpenID Connect

```
Customer App  →  Identity Provider (IdP)  →  Library API
     │                    │                       │
     │  1. Redirect to IdP login                  │
     │  2. User authenticates                     │
     │  3. IdP returns auth code                  │
     │  4. Exchange code for tokens               │
     │  5. Call API with access token   ──────────│
```

### Scenario 2: API Key + Customer Mapping

For server-to-server integrations where SSO is not applicable:

1. Partner receives an API key
2. API key is sent via `X-API-Key` header
3. Each API key maps to a specific customer/partner profile

### Scenario 3: SAML 2.0 Federation

For enterprise customers with existing SAML infrastructure:

1. Customer IdP configured as trusted provider
2. SAML assertions exchanged for JWT tokens
3. Claims mapped to Library API roles/scopes

## Current State

- **Authentication:** Not yet implemented (all endpoints are open)
- **SSO:** Planned for a future release
- Partners should design integrations to be auth-ready by supporting:
  - `Authorization: Bearer <token>` header
  - Token refresh logic
  - Error handling for `401 Unauthorized` responses
