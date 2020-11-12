using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace api.evl.watch.Handlers
{
    public class LogRequestAndResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
        {
            using ( var context = new EvlWatchContext() )
            {
                if ( request.Method.ToString() != "OPTIONS" )
                {
                    try
                    {
                        string requestBody = await request.Content.ReadAsStringAsync();

                        var _ResponseID = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(BCrypt.Net.BCrypt.HashPassword(DateTimeOffset.Now + new Random(32).NextDouble().ToString())));
                        string ResponseID = "EVL00" + string.Concat(_ResponseID.Select(b => b.ToString("x2"))).ToUpper();
                        var ctx = request.Properties["MS_HttpContext"] as HttpContextBase;

                        context.ExecuteStoreCommand("EXEC dbo.InsertApiLog @id, @io, @type, @method, @uri, @ipaddress, @body",
                            new SqlParameter("id", ResponseID),
                            new SqlParameter("io", "I"),
                            new SqlParameter("type", "Standard Log"),
                            new SqlParameter("method", request.Method.ToString()),
                            new SqlParameter("uri", request.RequestUri.ToString()),
                            new SqlParameter("ipaddress", ctx.Request.UserHostAddress),
                            new SqlParameter("body", requestBody));

                        request.Properties.Add("RequestID", ResponseID);

                        var result = await base.SendAsync(request, cancellationToken);

                        if ( result.Content != null )
                        {
                            var responseBody = string.Empty;

                          
                            responseBody = await result.Content.ReadAsStringAsync();
                          

                            context.ExecuteStoreCommand("EXEC dbo.InsertApiLog @id, @io, @type, @method, @uri, @ipaddress, @body",
                               new SqlParameter("id", ResponseID),
                               new SqlParameter("io", "O"),
                               new SqlParameter("type", "Standard Log"),
                               new SqlParameter("method", request.Method.ToString()),
                               new SqlParameter("uri", request.RequestUri.ToString()),
                               new SqlParameter("ipaddress", ctx.Request.UserHostAddress),
                               new SqlParameter("body", responseBody));

                        }

                        return result;
                    }
                    catch ( Exception ex )
                    {
                        throw ex;
                    }
                }
                else
                {
                    var result = await base.SendAsync(request, cancellationToken);
                    return result;
                }
            }
        }
    }
}