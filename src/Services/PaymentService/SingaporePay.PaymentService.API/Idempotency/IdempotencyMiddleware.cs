namespace SingaporePay.PaymentService.API.Idempotency;

public sealed class IdempotencyMiddleware
{
    private const string HeaderName = "Idempotency-Key";

    private static readonly Dictionary<string, string> Cache = new();

    private readonly RequestDelegate _next;

    public IdempotencyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(HeaderName, out var key))
        {
            await _next(context);
            return;
        }

        var idempotencyKey = key.ToString();

        if (Cache.TryGetValue(idempotencyKey, out var cachedResponse))
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(cachedResponse);
            return;
        }

        var originalBodyStream = context.Response.Body;
        using var responseStream = new MemoryStream();
        context.Response.Body = responseStream;

        await _next(context);

        responseStream.Seek(0, SeekOrigin.Begin);
        var responseBody = await new StreamReader(responseStream).ReadToEndAsync();

        Cache[idempotencyKey] = responseBody;

        responseStream.Seek(0, SeekOrigin.Begin);
        await responseStream.CopyToAsync(originalBodyStream);
    }
}