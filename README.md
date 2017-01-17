# Benchmarks
Benchmark for NFX Unistack WAVE

## Scenarios

| url | Type | Action | Description |
| --- | ---- | ------ | ----------- |
| /plaintext | NFX.Wave.Benchmarks.Handlers.PlainTextHandler | | |
| /json | NFX.Wave.Benchmarks.Handlers.JsonHandler | | |
| /mvc/plaintext | NFX.Wave.Handlers.MVCHandler | Index.PlainText | |
| /mvc/json | NFX.Wave.Handlers.MVCHandler | Index.Json | |

## Setting Up

1. Clone this repo

1. Build solution in Release

1. Run
```
Output\Release\nfx-wave-bench
```

*Note: You may need to open port 8080 for external traffic in your firewall to successfully run*

# Details

## Environment
We're testing the following physical machines:

| Name | OS | Role | CPU | RAM | NIC | Notes |
| ---- | -- | ---- | --- | --- | --- | ----- |
| local | Windows 10 | Desktop | [Core i7-6700K](https://ark.intel.com/products/88195/Intel-Core-i7-6700K-Processor-8M-Cache-up-to-4_20-GHz) | 64 GB | local |

## Load Generation
```
ab -n200000 -c8 -k ...
```

## Plaintext

| Stack | Server | Req/sec |
| ----- | ------ | ------- |
| NFX.Wave | local | 102,320 |
| ASP.Net Core on Kestrel | local | 138,789 |

## Json

| Stack | Server | Req/sec |
| ----- | ------ | ------- |
| NFX.Wave | local | 93,647 |
| ASP.Net Core on Kestrel | local | 135,224 |

## MVC PlainText

| Stack | Server | Req/sec |
| ----- | ------ | ------- |
| NFX.Wave | local | 83,480 |
| ASP.Net Core on Kestrel | local | 106,297 |

## MVC Json

| Stack | Server | Req/sec |
| ----- | ------ | ------- |
| NFX.Wave | local | 75,608 |
| ASP.Net Core on Kestrel | local | 6,349 |
