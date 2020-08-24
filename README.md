Haceau.Google.Translate
===========
![Language](https://img.shields.io/badge/Language-C%23-blue.svg?style=flat-square) ![.Net Core](https://img.shields.io/badge/.Net&nbsp;Core-3.1-blue.svg?style=flat-square)

[![Gitee](https://img.shields.io/badge/Gitee-辰落火辉Haceau-red.svg?style=flat-square)](https://gitee.com/haceau/Haceau.Google.Translate) [![Github](https://img.shields.io/badge/Github-HaceauZoac-blue.svg?style=flat-square)](https://github.com/Haceau-Zoac/Haceau.Google.Translate)

介绍
---
Haceau.Google.Translate是一个类库，用于向Google翻译发出请求并获取返回的数据。

使用
---
1. 导入[dll文件](https://github.com/Haceau-Zoac/Haceau.Google.Translate/releases/tag/v1.0.0)
2. 添加using Haceau.Google
3. 创建[HttpClient](https://docs.microsoft.com/zh-cn/dotnet/api/system.net.http.httpclient?view=netcore-3.1)类的实例（例：HttpClient httpClient = new HttpClient()）
4. 创建Translation类的实例，参数1为源语言（可忽略，默认为zh-cn），参数2为目标语言（可忽略，默认为en），参数3为HttpClient（例：Translation t = new Translation("en", "ja", httpClient)）
5. 使用Translate方法获取结果（例：t.Translate("hello world!")）
