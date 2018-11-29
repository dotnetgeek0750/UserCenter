using RuPeng.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using UserCenter.IServices;

namespace UserCenter.OpenAPI
{
    public class UCAuthorizationFilter : IAuthorizationFilter
    {
        //一个对象比如是IOC容器创建出来的，IOC容器才会自动帮我们注入
        public IAppInfoService appInfoService { get; set; }

        public bool AllowMultiple => true;

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            IEnumerable<string> appKeys;
            actionContext.Request.Headers.TryGetValues("appkey", out appKeys);
            if (appKeys == null || appKeys.Count() == 0)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("报文头中的AppKey为空")
                };
            }
            IEnumerable<string> signs;
            actionContext.Request.Headers.TryGetValues("Sign", out signs);
            if (signs == null || signs.Count() == 0)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("报文头中的appsecret为空")
                };
            }

            string appKey = appKeys.First();
            string sign = signs.First();

            var appInfo = await appInfoService.GetByAppKeyAsync(appKey);
            if (appInfo == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("不存在的appkey")
                };
            }
            if (!appInfo.IsEnabled)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("APPKey被封禁")
                };
            }

            //计算用户输入参数的连接+AppSecret的Md5值
            //orderedQS就是按照key（参数的名字）进行排序的QueryString集合
            var orderedQS = actionContext.Request.GetQueryNameValuePairs().OrderBy(kv => kv.Key);
            var segments = orderedQS.Select(kv => kv.Key + "=" + kv.Value);//拼接key=value的数组
            string qs = string.Join("&", segments);//用&符号拼接起来
            string computedSign = MD5Helper.ComputeMd5(qs + appInfo.AppSecret);//计算qs+secret的md5值
                                                                               //用户传进来md5值和计算出来的比对一下，就知道数据是否有被篡改过
            if (sign.Equals(computedSign, StringComparison.CurrentCultureIgnoreCase))
            {
                return await continuation();
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("sign验证失败")
                };
            }


        }
    }
}