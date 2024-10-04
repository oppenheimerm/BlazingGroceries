
using Microsoft.AspNetCore.Http;

namespace BG.Shared.Middleware
{
    public class RandomFailure
    {
        private readonly RequestDelegate _next;
        public RandomFailure(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var _path = context.Request.Path.Value;

            if (_path is null || !_path.Contains(AppConstants.BASE_API_PRODUCT, StringComparison.InvariantCultureIgnoreCase))
                await _next(context);

            var randomNumber = Random.Shared.NextDouble();
            if (randomNumber >= 0.6)
            {
                throw new Exception($"Computer says no. Randdom value: {randomNumber}");
            }

            await  _next(context);
        }
    }
}
