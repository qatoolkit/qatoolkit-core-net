# QAToolKit Core library
[![Build .NET Library](https://github.com/qatoolkit/qatoolkit-core-net/workflows/.NET%20Core/badge.svg?branch=main)](https://github.com/qatoolkit/qatoolkit-core-net/actions)
[![CodeQL](https://github.com/qatoolkit/qatoolkit-core-net/workflows/CodeQL%20Analyze/badge.svg)](https://github.com/qatoolkit/qatoolkit-core-net/security/code-scanning)
[![Sonarcloud Quality gate](https://github.com/qatoolkit/qatoolkit-core-net/workflows/Sonarqube%20Analyze/badge.svg)](https://sonarcloud.io/dashboard?id=qatoolkit_qatoolkit-core-net)
[![NuGet package](https://img.shields.io/nuget/v/QAToolKit.Core?label=QAToolKit.Core)](https://www.nuget.org/packages/QAToolKit.Core/)

## Description
`QAToolKit.Core` is a .NET Standard 2.1 library, that contains core objects and functions of the toolkit. It's normally not used as a standalone library but is a dependency for other QAToolKit libraries.

Supported .NET frameworks and standards: `netstandard2.0`, `netstandard2.1`, `netcoreapp3.1`, `net5.0`

## 1. HttpRequest functions
HttpRequest object is one of the main objects that is shared among the QA Toolkit libraries. `QAToolKit.Core` library contains `HttpRequestTools` which can manipulate the HttpRequest object.

For example URL, header and Body generators: `HttpRequestUrlGenerator`, `HttpRequestBodyGenerator` and `HttpRequestHeaderGenerator`.

### 1.1. HttpRequestUrlGenerator
This is a method that will accept key/value pairs for replacement of placeholders in the `HttpRequest` object. Replacement object are stored in a dictionary, which `prevents mistakes with duplicated keys`.
Also dictionary keys are case insensitive when looking for values to replace.

```csharp
options.AddReplacementValues(new Dictionary<string, object> {
    {
        "version",
        "1"
    },
    {
        "parentId",
        "4"
    }
});
```

In the example above we say: "Replace `{version}` and {parentId} placeholders in Path and URL parameters and JSON body models."

In other words, if you have a test API endpoint like this: https://api.demo.com/v{version}/categories?parent={parentId} that will be set to https://api.demo.com/v1/categories?parent=4.

That, does not stop there, you can also populate JSON request bodies.

### 1.2. HttpRequestBodyGenerator

For example if you set the replacement value to stringified json:

```csharp
options.AddReplacementValues(new Dictionary<string, object> {
    {
        "id",
        "100"
    },
    {
        "category",
        "{\"id\":1,\"name\":\"dog\"}"
    }
});
```
than the parent model object will be replaced with the stringified json above.

What happend behind the curtains, the model proxy class is generated, which is then used to Deserialized the JSON into the object.
`HttpRequest` list is then scanned and values are properly replaced.

### 1.3. HttpRequestHeaderGenerator

To-do

## To-do

- **This library is an early alpha version**
- `HttpRequestHeaderGenerator` is missing implementation.
- `HttpRequestBodyGenerator` need to cover the whole spectrum of object tipes. Currently it's missing arrays, and nested objects. It's on the priority list.

## License

MIT License

Copyright (c) 2020 Miha Jakovac

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.