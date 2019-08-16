# 创建项目及使用CodeFirst方式创建SQLite数据库
## 配置环境
* 安装 [.NET Core 2.2](https://dotnet.microsoft.com/download)
    * 在CMD中输入`dotnet --version`检查是否安装成功
* 安装 [VS Code](https://code.visualstudio.com/)
    * 在CMD中输入`code --version`检查是否安装成功，否则需要[手动添加环境变量](https://code.visualstudio.com/docs/editor/command-line)
## 创建项目
1. 在CMD中输入`dotnet new mvc -au none -n RGProject`创建一个项目名为 `RGProject` `没有身份验证` 的 `.Net Core MVC Web` 程序，其他额外参数可以使用`-h`查看。
2. 输入`cd RGProject`进入项目目录，输入`code .`使用VScode打开项目。
## 安装依赖项
1. 安装EntityFrameworkCore.Design
`dotnet add package Microsoft.EntityFrameworkCore.Design`
2. 安装EntityFrameworkCore.SQLite
`dotnet add package Microsoft.EntityFrameworkCore.SQLite`