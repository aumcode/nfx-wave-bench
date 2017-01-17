# NFX Wave Benchmarks
The purpose of this project is to realistically assess the performance of our web stack and compare it to the top tech offerings on the market. This work was sparked by a post about  [Kestrel achieving +1MM requests a second](https://www.ageofascent.com/2016/02/18/asp-net-core-exeeds-1-15-million-requests-12-6-gbps/) on .Net Core. Indeed, the MS team has implemented some tight optimizations and achieved very good results, however the question stands: **how is this applicable to the real web apps laden with business logic? Is this even needed? Does it justify the complexity?**. *When you need to carry a 1000lb rock, does it matter if your bag weights 1 lb or 10 lb?*

NFX Wave is a web-centric part of [NFX UNISTACK](https://github.com/aumcode/nfx) library. WAVE provides: web server, request handling pipeline (filters/handlers), and [MVCHandler](https://github.com/aumcode/nfx/blob/master/Source/NFX.Wave/Handlers/MVCHandler.cs) that operate on top.

At the present moment we have based the [WaveServer](https://github.com/aumcode/nfx/blob/master/Source/NFX.Wave/WaveServer.cs) implementation on the classic [HttpListener](https://msdn.microsoft.com/en-us/library/system.net.httplistener(v=vs.110).aspx) class. We really do not depend on HttpListener and plan to get rid of it altogether in favor of libuv or plain sockets.


## Testing Scenarios

We have tested two kinds of request handling:  [**direct handler**](./Source/NFX.Wave.Benchmarks/Handlers) that writes to the stream, and [**MVC Controller**](./Source/NFX.Wave.Benchmarks/Controllers) which is of course slower than plain handler as it is an extra layer that dispatches request/verbs into a class method invocation.

| url | Type | MVC Action | Description |
| --- | ---- | ------ | ----------- |
| /plaintext | NFX.Wave.Benchmarks.Handlers.PlainTextHandler | n/a |Plain Text with direct response writing |
| /json | NFX.Wave.Benchmarks.Handlers.JsonHandler | n/a |Simple JSON with direct response writing |
| /mvc/plaintext | NFX.Wave.Handlers.MVCHandler | Index.PlainText |Return Plain Text via MVC controller action |
| /mvc/json | NFX.Wave.Handlers.MVCHandler | Index.Json |Return simple JSON via MVC controller action |

## Setting Up

1. Clone this repo

1. Build VS solution in Release. This is a regular .NET project, not a Core project

1. Either run as Admin or grant HttpListener rights like so: `netsh http add urlacl url=http://+:8080/ user=Everyone`

1. Run
```
Output\Release\nfx-wave-bench
```

*Note: You may need to open port 8080 for external traffic to access the server rig*

# Details

## Our Test Environment
We are testing using the following physical machines:


| Name | OS | Role | CPU | RAM | NIC | Notes |
| ---- | --- | ---- | --- | --- | --- | ----- |
| CNONIM | Windows 10 | Desktop | [Core i7-6700K = 4 core @ 4.2 ghz](https://ark.intel.com/products/88195/Intel-Core-i7-6700K-Processor-8M-Cache-up-to-4_20-GHz) | 64 GB | 1 Gbit | |
| SEXTOD | Windows 7 | Desktop | [Core i7-3930K = 6 core @ 3.2 ghz](https://ark.intel.com/products/63697/Intel-Core-i7-3930K-Processor-12M-Cache-up-to-3_80-GHz)| 64 GB | 1 Gbit | |

## Load Generation
We generate load with Apache Bench (**AB**) for now, using `-k` for keep alives, `-nXXXX` number of requests, `-cXXXXX` concurrency level

```
ab -n200000 -c8 -k ...
```

## Plaintext

| Stack | Server | Client | Req/sec |
| ----- | ------ | ------- | ------- |
| NFX.Wave | CNONIM | AB local |  102,320 |
| ASP.Net Core on Kestrel | CNONIM |  AB local | 138,789 |

## Json

| Stack | Server | Client | Req/sec |
| ----- | ------ | ------- | ------- |
| NFX.Wave | CNONIM |  AB local | 93,647 |
| ASP.Net Core on Kestrel | CNONIM |  AB local| 135,224 |

## MVC PlainText

| Stack | Server | Client | Req/sec |
| ----- | ------ | ------- | ------- |
| NFX.Wave | CNONIM |  AB local | 83,480 |
| ASP.Net Core on Kestrel | CNONIM |  AB local| 106,297 |

## MVC Json

| Stack | Server |Client | Req/sec |
| ----- | ------ | ------- | ------- |
| NFX.Wave | CNONIM |  AB local | 75,608 |
| ASP.Net Core on Kestrel | CNONIM |  AB local | 6,349 |
