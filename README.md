# ExchangeService

A simple HTTP API to convert between 2 currencies (AUD, USD) making use of a public API [ExchangeRate-API](https://www.exchangerate-api.com/).

---

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 (preferred)
- A valid [ExchangeRate-API](https://www.exchangerate-api.com/) key

---

## Assumptions

- Only AUD ↔ USD conversion is supported, as per the task specification
- Currency codes must be valid ISO 4217 three-letter codes (`AUD` or `USD`)

---

## Setup & Running

**Step 1:** Clone the repository and navigate to the project directory.

**Step 2:** Add your API key to `appsettings.Development.json`:

```json
"ExchangeRate": {
  "ApiKey": "your-api-key-here"
}
```

**Step 3:** Run the API using one of the following options:

**Option A — Terminal:**
```bash
dotnet run
```
Then open `https://localhost:{port}/swagger` in your browser to access the Swagger UI.

**Option B — Visual Studio:**
Open the solution and press `F5`.

---

## Endpoints

### `POST /ExchangeService`
Converts an amount from one currency to another.

**Request:**
```json
{
  "amount": 15,
  "inputCurrency": "AUD",
  "outputCurrency": "USD"
}
```

**Response:**
```json
{
  "amount": 15,
  "inputCurrency": "AUD",
  "outputCurrency": "USD",
  "value": 10.53
}
```
> `value` reflects the live exchange rate at the time of the request.

---

### `GET /ExchangeService/HealthCheck`
Returns a simple liveness check.

---

## Design Notes

**Separate request/response models**

`ExchangeRateRequest` and `ExchangeRateApiRequest` are intentionally kept as separate models despite currently having the same shape. This separates the internal API contract from the external one — if the third-party API changes its contract, or if support for additional providers is added, only the provider layer needs to change.

**Spec discrepancy**

The task brief specifies an `Accept: text/plain` header alongside a JSON response body. This implementation returns JSON, as `text/plain` is not an appropriate content type for structured data. This was a technical decision, not an oversight.

---

## Improvements & Future Work

**High priority**
- Cache exchange rates to reduce redundant API calls and improve response times
- Expand error handling for specific API error types (e.g. invalid API key, rate limit exceeded, network failures)
- Implement unit tests to ensure reliability and maintainability before pushing to production
- Add logging for better observability and debugging

**Medium priority**
- Support additional currency pairs beyond AUD and USD
- Add an extension method for safe enum string parsing to handle unsupported currency codes gracefully
- Implement rate limit to prevent hitting the third-party API call limit

---

## Attribution

Rates By [Exchange Rate API](https://www.exchangerate-api.com)