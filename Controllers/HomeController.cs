using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using XmlImport.Models;

namespace XmlImport.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Метод с WebClient
        public string DownloadFile()
        {
            var qtr = "QTR1";
            var year = "2022";
            var file = "master.20220303.idx";
            string path = $"C:\\XML\\daily-index\\{year}\\{qtr}"; //путь к месту создания
            var url = $"https://www.sec.gov/Archives/edgar/daily-index/{year}/{qtr}/{file}";

            //1.сделать переменным файл xml
            //2.Создать переменную fullpath (path+файл из п.1) и подставить его в client.DownloadFile(url, path) вместо path
            var fullpath = $"{path}\\{file}";
            var client = GetWebClient();   //
            CreateDirectory(path);
            client.DownloadFile(url, fullpath);
            return "Получилось";

        }
        /// <summary>
        /// получение метода WebClient
        /// </summary>
        /// <returns>возвращаем клиент</returns>
        private WebClient GetWebClient()         //метод
        {
            WebClient client = new WebClient(); //внутри метода объект клиента
            client.Headers.Add("accept:text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            client.Headers.Add(@"cookie:_ga=GA1.2.521904397.1646656948; _gid=GA1.2.909744332.1646656948; _4c_={""_4c_s_"":""lVJNr9MwEPwrlc9N6 / gjtntDDwlxgAN6wLFKbKexGurIcRseVf87u / 2U + riQS7KzM5P1rI9k6vyOrMpKVEqyinGh5Jxs / dtIVkeSgsPXgayIMsy21rQFNaopBJeiaBomC0Wp1DUTNTeczMlv9JJCcGaEppqd5sQOV48jsdF58CrNohQLU7QjKPIfRDSFzyFFt7d5nd8GpE2 + mY1uCw3nD8H69RRc7qDBmVIPtPNh02U0UUwjPCQsFkxCMYWdi9NdWVaMPtCHUkgBcJPiNHpUv3Qp / vIzYwCNEAX5eVbgvMm3PqUzC6oxZBx19HaxiYcrAPFdsOKC / QiIutnryzfAv + JJMVLMq4 + 27tEBtjAnnz6sv3 / +CJVkpaGCG7XAzVSygjShv089NLuch3G1XE7TtLj + eAlZ + D4OMNYcrNB9SA7H8TaHuLuMA / VrCpuNT1987iLsFuraBWTUPUaHROfbet9nLDEb29fjGKzz4zbHgZyuOxaV5pIzwRjcl5xhLl0Jis / pcrzzyvmdrarSlLQ0 + j37EnuBefnd / 0lh1tsF1b7molVVUVKvC6EEK4yqeEGbymslHLVlTZ48maL / 8NzdLB9J3K61LCWoNNLCkK + 884qUhI5g / IkLCHLvjs9e2D + d / gI = ""}; bm_sv=E09EE8FEAD3A4B80201605710304B58E~PZa6vYuYqFOoHWCSvsZegoNSa6sorzdn0kS+KIbq8dm9voHwI/lAyR2gulavp3uA/4Yvg2duidvp5jdL+OG+vK2oygULQQhQuoniI36+Tm0ebg9WIyxubsJvJldIzbjDcqNHHzRPZLFvIm/zdJOlvQ==; bm_mi=EA0C90E7B24D92EE936E240B98097EA4~ORoomL2qiz3BaJhMYXVvwO56Gqxwyj8oRqFI1MFeZBIj+Ehlj7wEgoQImlTpafCTE3G1SB8QASK2XyqsSGHCVYtQfUWpzYdjcd14wNFeax4s+Bdx33gi1Q5z8Ir0dhrUvSOVrTzJukWfDZ0GNzMFn/FUY+MPxEtiZSTVbVVPcYgspbodfECYz4B/GVN3kxsnGhogU4aurlwf5RANCoDo1k3uksIinka49CCNtyv2Xt6NvVhfDS9vC1a06zSCEhE1n81IkCtkvmJjqdYi2DJhPuk/AJTHz6Yl+CSJ+9es7zfb4cMYM9m/vFLFrkiKg7ZLaYRbR3Aw3Bn4bvzYZF9uGg==; ak_bmsc=F4BC3609A186CFA07AF6911167FB695C~000000000000000000000000000000~YAAQFOzvUCMxvVF/AQAAfDxMag/1dBPYijAU+OlKf381ipx2PVdiJZkOn9HPgpOGZ9B7xNFoyMRwfSW01R9afrP7xraPrBRlPpnZCZAY+IBwbGj8AYco5jaDFJk1dF6dQTug+cZInkJNzqWajViMNM/0DadqhK0fL6oI5PxGFiAsnDOoWpsHFxR1/6U2SVXjo2qDjDGEqDifjanbXgJQ9gxp5GmNEmDza106f6OmoaQgx1LW1jtmxRHj6/JLOHWdcTu7f1KkLqx+e8bg+3rpQ338fh/DrM7bErnOXSKQjhOdLrkeJIpYrkt2Qiz+hXC74ZDPsJArFKhdkmfbYQKJU5JNvYs7kXIy/3a7d+waY3JRV4si9k5KaBlUfkVhyPUkCcOLNlwngi1thH44ZznEIKug+Xw=");
            client.Headers.Add(@"user-agent:Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.51 Safari/537.36");
            return client;

        }

        /// <su Папки на диске
        /// </summary>
        private void CreateDirectory(string path)
        {
            
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists) //определяет, существует ли каталог
            {
                dirInfo.Create();
            }
        }
    }
}