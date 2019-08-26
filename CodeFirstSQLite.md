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
## 创建上下文类 
新建`RGProjectDbContext.cs`，写入以下代码
```CSharp
using Microsoft.EntityFrameworkCore;

namespace RGProject.Models
{
    public class RGProjectDbContext : DbContext
    {
        public RGProjectDbContext(DbContextOptions<RGProjectDbContext> options)
            : base(options)
        { }
    }
}
```
## 创建实体类
1. 新建`UserModel.cs`，写入
```CSharp
namespace RGProject.Models
{
    public class User
    {
        public int ID { get; set; }
        public int Gold { get; set; }
        public int STR { get; set; }
        public int DEX { get; set; }
        public int Lucky { get; set; }
        public bool DayCheck { get; set; }
    }
}
```
类对应位数据库中的表。
属性对应数据库中表中的一列。

2. 在`RGProjectDbContext.cs`的`RGProjectDbContext`中增加一行代码
```CSharp
public DbSet<User> Users { get; set; }
```
## 配置数据库连接字符串
1. 在`appsettings.json`中添加一个`ConnectionStrings`如下
```json
"ConnectionStrings":{
"SqliteDb":"Data Source=mydb.db;"
}
```
表示数据将存储在`mydb.db`文件中。

2. 还需要通过依赖注入注册上下文，在`Startup.cs`文件中的`ConfigureServices`函数里添加
```CSharp
services.AddDbContext<RGProjectDbContext>( options => options.UseSqlite(Configuration.GetConnectionString("SqliteDb")) );
```
表示将从`appsettings.json`读取节点名为`SqliteDb`的内容作为连接数据库的`ConnectionStrings`。
这样EF才可以正确连接至数据库。

## 使用移植命令生成数据库表
1. 使用`Ctrl+~`打开终端，输入`dotnet ef migrations add Initialize`命令。意思是我需要增加一次名为`Initialize(可以修改为别的名称)`的移植操作。
EF会读取代码并在项目目录的`Migrations`文件夹内生成相应的类，例如`20190826080100_Initialize.cs`，文件中会显示这个移植操作确认后将会对数据库进行的操作，内容如下
```CSharp
using Microsoft.EntityFrameworkCore.Migrations;

namespace RGProject.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Gold = table.Column<int>(nullable: false),
                    STR = table.Column<int>(nullable: false),
                    DEX = table.Column<int>(nullable: false),
                    Lucky = table.Column<int>(nullable: false),
                    DayCheck = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
```
这里可以确认一下是否符合预期操作。

2. 确认无误后输入`dotnet ef database update`确认并执行移植操作，这时数据库中才会生成相应的表。