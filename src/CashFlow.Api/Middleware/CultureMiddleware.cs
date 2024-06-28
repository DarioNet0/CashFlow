using System.Globalization;

namespace CashFlow.Api.Middleware;

public class CultureMiddleware {
    private readonly RequestDelegate _next;
    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context) {
        var supportedLanguage = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();//criando uma lista com todas as tags possíveis
        var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault(); //extraindo da requisição, o idioma
        var cultureInfo = new CultureInfo("en"); // Setando idioma padrão caso não tenha idioma no header
        if (string.IsNullOrWhiteSpace(requestedCulture) == false 
            && supportedLanguage.Exists(l => l.Equals(requestedCulture))) {
            cultureInfo = new CultureInfo(requestedCulture); // reescrevendo o valor padrão antes setado
        }
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;
        await _next(context); //permitindo seguir para o endpoint
    }
}