namespace MvvmDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var builder = WebApplication.CreateBuilder(args);
            //var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            //app.Run();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(WebuBuilder =>
            {
                _ = WebuBuilder.Configure((bc, x) =>
                {
                    x.Run((context) =>
                    {
                        string html = "";

                        if (context.Request.Path == "/Virus/Create")
                        {
                            if (context.Request.Method == "GET")
                            {
                                html = @"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8' />
<link href='file/abc.css' rel='stylesheet' />
    <title></title>
</head>
<body>
    <form method='POST'>
        病毒代码：<input id='Text1' type='text' name='VirusCode' /><br />
        病毒名称：<input id='Text2' type='text' name='VirusName' /><br />
         <button type='submit' >提交</button>
    </form>
</body>
</html>";
                                context.Response.ContentType = "text/html";
                                return context.Response.WriteAsync(html);
                            }
                            if (context.Request.Method == "POST")
                            {
                                html = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8' />
<link href='file/abc.css' rel='stylesheet' />
    <title></title>
</head>
<body>
  添加成功！<br/>
        病毒代码：{context.Request.Form["VirusCode"]}   <br />
        病毒名称： {context.Request.Form["VirusName"]}  <br />
        <a href='/Virus/Create'>再次添加</a><br/>
    <a href='/'>返回首页</a>
</body>
</html>
";
                            }
                            context.Response.ContentType = "text/html";
                            return context.Response.WriteAsync(html);
                        }
                        if (context.Request.Path == "/")
                        {
                            html = @"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8' />
<link href='file/abc.css' rel='stylesheet' />
    <title></title>
</head>
<body>
    欢迎进入病毒库管理<br/>
    <a href='/virus/create'>添加病毒</a>
</body>
</html>";
                            context.Response.ContentType = "text/html";
                            return context.Response.WriteAsync(html);
                        }
                        if (context.Request.Path.HasValue)
                        {

                            if (context.Request.Path.Value.EndsWith(".css"))
                            {
                                string path = bc.HostingEnvironment.ContentRootPath + "/file/abc.css";
                                string css = File.ReadAllText(path);
                                context.Response.ContentType = "text/css";
                                return context.Response.WriteAsync(css);
                            }
                        }

                        context.Response.StatusCode = 404;
                        return context.Response.WriteAsync("");
                    });
                });
            });
    }
}