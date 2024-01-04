using System.Web;

namespace AuthServer.Web.Endpoints;

public class Getlogin
{
    internal static async Task Handler(string returnUrl, HttpResponse response)
    {
        response.Headers.ContentType = "text/html";

        await response.WriteAsync(
            $"""
                 <html>
                     <head><title>Login</title></head>
                     <body>
                         <form action="/login?returnUrl={HttpUtility.UrlEncode(returnUrl)}" method="post">
                             <input value="submit" type="submit"/>
                         </form>
                     </body>
                 </html>
             """);
    }
}