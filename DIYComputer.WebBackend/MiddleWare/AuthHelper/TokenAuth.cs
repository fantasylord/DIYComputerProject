using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DIYComputer.WebBackend.MiddleWare.AuthHelper
{
    /// <summary>
    /// Token验证授权中间件
    /// </summary>
    public class TokenAuth
    {
        private readonly RequestDelegate _next;

        public TokenAuth(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 身份验证---授权
        /// </summary>
        /// <param name="httpcontext"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext httpcontext)
        {
            //  var headers = httpcontext.Request.Headers;

            //通过设置一个头来告知客户端用utf-8码表去解码
          //  httpcontext.Response.Headers.Append("Content-Disposition", "text/html;charset=utf-8");
            
            var cookies = httpcontext.Request.Cookies;
            if(!cookies.ContainsKey("Authorization"))
            {
                return _next(httpcontext);
            }
            
            var tokenStr = cookies["Authorization"];
            if(tokenStr!=null)
            try
            {
                string jwtStr = tokenStr.ToString().Substring("Bearer".Length).Trim();//截取Bearer之后的字符串 
                if (!MyNetCoreMemoryCache.Exists(jwtStr))
                {
                    httpcontext.Response.Cookies.Delete("Authorization");
                    return httpcontext.Response.WriteAsync("非法请求",Encoding.UTF8);
                }
                TokenModel tml = (TokenModel)MyNetCoreMemoryCache.Get(jwtStr);
                List<Claim> lc = new List<Claim>();
                Claim c = new Claim(tml.Sub + "Type", tml.Sub);
                lc.Add(c);
                ClaimsIdentity identity = new ClaimsIdentity(lc);//lc为查询到该角色的信息 identity 代表创建一个信息lc身份标识
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);//封装好的安全上下文
                httpcontext.User = claimsPrincipal;
              
                return _next(httpcontext);
            }
            catch (Exception)
            {
                return httpcontext.Response.WriteAsync("验证异常", Encoding.UTF8);
            }
            else
            {
                httpcontext.Response.Cookies.Delete("Authorization");
                return _next(httpcontext);
            }
        }

    }
}
