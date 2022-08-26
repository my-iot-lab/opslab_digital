﻿using Admin.NET.Application.Const;
using Furion.DatabaseAccessor;
using Furion.Localization;
using Furion.Logging.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Admin.NET.Application.Service;

/// <summary>
/// 自己业务服务
/// </summary>
[ApiDescriptionSettings(TestConst.GroupName, Name = "XXX模块", Order = 200)]
[AllowAnonymous]
public class TestService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<Test> _testRep;

    public TestService(SqlSugarRepository<Test> testRep)
    {
        _testRep = testRep;
    }

    /// <summary>
    /// 测试
    /// </summary>
    public string GetName()
    {
        return "Furion";
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    [HttpGet("/test/list")]
    public async Task<List<Test>> GetTestList()
    {
        return await _testRep.GetListAsync();
    }

    /// <summary>
    /// 事务和工作单元测试
    /// </summary>
    /// <returns></returns>
    [HttpGet("/test/list2")]
    [UnitOfWork]
    public async Task<List<Test>> TestUnitOfWork()
    {
        await _testRep.InsertAsync(new Test() { Name = "admin" });
        throw new Exception("异常");
        return await _testRep.GetListAsync();
    }

    /// <summary>
    /// 多语言测试
    /// </summary>
    /// <returns></returns>
    public string TestCulture()
    {
        "ddd".LogWarning();
        //L.SetCulture("zh-CN");
        //var a = L.GetSelectCulture();
        //var a1 = L.Text["API Interfaces"];
        //return $"当前语言【{a.Culture.Name}】 {a1}";

        L.SetCulture("en-US");
        var b = L.GetSelectCulture();
        var b1 = L.Text["API 接口"];

        return $"当前语言【{b.Culture.Name}】 {b1}";
    }

    /// <summary>
    /// 测试 Markdown
    /// </summary>
    /// <remarks>
    /// # 先知 / Furion ([探索版](https://gitee.com/dotnetchina/Furion/tree/experimental/))
    ///
    ///     一个应用程序框架，您可以将它集成到任何.NET/C# 应用程序中。
    ///
    /// An application framework that you can integrate into any.NET/C# application.
    ///
    /// ## 安装 / Installation
    ///
    /// - [Package Manager] (https://www.nuget.org/packages/Furion)
    ///
    /// ```powershell
    /// Install-Package Furion
    /// ```
    ///
    /// - [.NET CLI] (https://www.nuget.org/packages/Furion)
    ///
    /// ```powershell
    /// dotnet add package Furion
    /// ```
    ///
    /// ## 例子 / Examples
    ///
    /// 我们在[主页](https://dotnetchina.gitee.io/furion)上有不少例子，这是让您入门的第一个：
    ///
    /// We have several examples [on the website] (https://dotnetchina.gitee.io/furion). Here is the first one to get you started:
    ///
    /// ```cs
    /// Serve.Run();
    ///
    ///     [DynamicApiController]
    ///     public class HelloService
    ///     {
    ///         public string Say()
    ///         {
    ///             return "Hello, Furion";
    ///         }
    ///     }
    /// ```
    ///
    /// 打开浏览器访问 `https://localhost:5001`。
    ///
    /// Open browser access `https://localhost:5001`.
    ///
    /// ## 文档 / Documentation
    ///
    /// 您可以在[主页] (https://dotnetchina.gitee.io/furion)或[备份主页](https://furion.icu)找到 Furion 文档。
    ///
    /// You can find the Furion documentation[on the website](https://dotnetchina.gitee.io/furion) or [on the backup website](https://furion.icu).
    ///
    /// ## 贡献 / Contributing
    ///
    /// 该存储库的主要目的是继续发展 Furion 核心，使其更快、更易于使用。 Furion 的开发在[Gitee](https://gitee.com/dotnetchina/Furion) 上公开进行，我们感谢社区贡献错误修复和改进。
    ///
    /// 阅读[贡献指南] (https://dotnetchina.gitee.io/furion/docs/contribute)内容，了解如何参与改进 Furion。
    ///
    /// The main purpose of this repository is to continue evolving Furion core, making it faster and easier to use.Development of Furion happens in the open on[Gitee] (https://gitee.com/dotnetchina/Furion), and we are grateful to the community for contributing bugfixes and improvements.
    ///
    /// Read[contribution documents] (https://dotnetchina.gitee.io/furion/docs/contribute) to learn how you can take part in improving Furion.
    ///
    /// ## 许可证 / License
    ///
    /// Furion 采用[MulanPSL - 2.0](https://gitee.com/dotnetchina/Furion/blob/master/LICENSE) 开源许可证。
    ///
    /// Furion uses the[MulanPSL - 2.0] (https://gitee.com/dotnetchina/Furion/blob/master/LICENSE) open source license.
    ///
    /// ```
    /// Copyright(c) 2020-2022 百小僧, Baiqian Co., Ltd.
    /// Furion is licensed under Mulan PSL v2.
    /// You can use this software according to the terms andconditions of the Mulan PSL v2.
    /// You may obtain a copy of Mulan PSL v2 at:
    ///             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
    /// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUTWARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
    /// See the Mulan PSL v2 for more details.
    /// ```
    ///
    /// </remarks>
    /// <returns></returns>
    public string GetDescription()
    {
        return "Furion";
    }
}