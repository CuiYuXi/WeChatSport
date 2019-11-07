# 微信运动刷步 [卓易健康]

** 原理：利用卓易健康官方API同步微信步数 **

## 使用帮助

1. 安装下载【卓易健康】APP,可在各大应用市场下载 
2. 苹果可在App Store或其他平台下载。安卓下载卓易健康app 
3. 安装APP并注册账号后点击-我-微信运动-绑定至相关微信设备即可 
4. 绑定微信后，在本页面输入刚刚注册的账号及要修改的步数点击提交修改 
5. 建议每次递交步数间隔不得超过9000,如第一次8999,第二次17998以此类推。微信上限98800 

## 本地部署教程

### IIS部署
1. 下载dotNet Core 2.1运行时 <https://dotnet.microsoft.com/download/dotnet-core>
2. 下载编译好的文件 <https://github.com/CuiYuXi/WeChatSport/tree/master/publish/v1.0.0>
> https://github.com/CuiYuXi/WeChatSport/tree/master/publish/v1.0.0 (v1.0.0 是版本号 要想使用其他版本可以自行修改)

3. 打开IIS→网站→添加网站→确定
4. 应用程序池→找到刚刚添加的那个右键→基本设置→.NET CLR 版本 修改为无托管代码

5. 访问 <http://localhost/index.html> 即可看到应用程序界面



### Docker部署

> Markdown增强版中比较有名的有Markdown Extra、MultiMarkdown、 Maruku等。这些衍生版本要么基于工具，如~~Pandoc~~，Pandao；要么基于网站，如GitHub和Wikipedia，在语法上基本兼容，但在一些语法和渲染效果上有改动。
