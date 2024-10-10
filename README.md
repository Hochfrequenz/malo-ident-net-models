![Nuget Package](https://badgen.net/nuget/v/MaLoIdentModels)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

# MaLo Ident .NET Models

This repository contains the nuget package `MaLoIdentModels` which contains C# model classes with `System.Text.Json` attributes for the Marktlokation Identification API by EDI@Energy.

## Installation and Use

Install it from nuget [MaLoIdentModels](https://www.nuget.org/packages/MaLoIdentModels):

```bash
dotnet add package MaLoIdentModels
```

Then use it

```c#
using MaLoIdentModels;
// ...
var myNegativeResponse = new ResultNegative()
{
   DecisionTree = "E_0594",
   ResponseCode = "A10",
   Reason = "Ich bin ein Freitext.",
   NetworkOperator = 9900987654321
};
var myJson = System.Text.Json.JsonSerializer.Serialize(myNegativeResponse);
Console.Out.WriteLine(myJson);
```

## Why are only parts of the code autogenerated?

The classes are generally based on the [MaLo Ident OpenAPI specification](https://app.swaggerhub.com/apis/edi-energy/MaLoIdent_2024-07-03/v1.0.0).
But although auto-generation of code is theoretically possible, the classes are _not_ autogenerated for multiple reasons:

1. The official OpenAPI Spec has several problems. We at Hochfrequenz maintain a better version of the `openapi.yml` without all the shortcomings here: [Hochfrequenz/malo-ident-python-models/openapi/openapi.yml](https://github.com/Hochfrequenz/malo-ident-python-models/blob/main/openapi/openapi.yml)
2. (Technical) We wanted to use System.Text.Json in .NET8 (and not Newtonsoft in .NET6) and did not find a a working code generator.
3. We didn't want to deal with magic JsonSettings, so we manually added all JsonPropertyName attributes and JsonConverters where needed.

## See also

We also maintain a [Python version of this data model](https://github.com/Hochfrequenz/malo-ident-python-models).

## Contributing

You are very welcome to contribute to this template repository by opening a pull request against the main branch.

## Hochfrequenz

[Hochfrequenz Unternehmensberatung GmbH](https://www.hochfrequenz.de) is a consulting company with offices in Berlin, Leipzig, Köln and Bremen.
We're not only the main contributor to open source in the field of German utilities but, according to [Kununu ratings](https://www.kununu.com/de/hochfrequenz-unternehmensberatung1), also among the most attractive employers within the German energy market.
Applications of talented developers are welcome at any time!
Please consider visiting our [career page](https://www.hochfrequenz.de/index.php/karriere/aktuelle-stellenausschreibungen/full-stack-entwickler) (German only).
