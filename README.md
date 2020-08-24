Haceau-Calculator
=================
![Language](https://img.shields.io/badge/Language-C%23-blue.svg?style=flat-square) ![.Net Core](https://img.shields.io/badge/.Net&nbsp;Core-3.1-blue.svg?style=flat-square)

[![Gitee](https://img.shields.io/badge/Gitee-辰落火辉Haceau-red.svg?style=flat-square)](https://gitee.com/haceau/Haceau.Log)
[![Github](https://img.shields.io/badge/Github-HaceauZoac-blue.svg?style=flat-square)](https://github.com/Haceau-Zoac/Haceau.Log)

简介
---
该项目为适用于C#的日志输出类库。当前版本为v1.0.0。开源协议为MIT。保持更新中。

类
---
Log：日志类。

使用
---
1. 创建实例
* 无参数：Log() : base(Environment.CurrentDirectory + $@"\log\", DateTime.Now.ToString("G").Replace('/', '-').Replace(':', '-') + ".txt")
* 有一个参数：Log(string fileName) : base(Environment.CurrentDirectory + $@"\log\", fileName)
* 有两个参数：Log(string src, string fileName)
2. 打印日志
* Write：Write(string type, string message)
* Debug：Debug(string message)
* Warning：Warning(string message)
* Info：Info(string message)
* Error：Error(string message)
* Fatal：Fatal(string message)


待办清单
------
|完成版本|内容|
|---|---|
|-|长期维护|