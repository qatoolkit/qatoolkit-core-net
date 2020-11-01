# QAToolKit Core library
![.NET Core](https://github.com/qatoolkit/qatoolkit-core-net/workflows/.NET%20Core/badge.svg?branch=main)
![Nuget](https://img.shields.io/nuget/v/QAToolKit.Core)

## Description
`QAToolKit.Core` is a .NET Standard 2.1 library, that contains core features of the ToolKit.

It contains general interfaces and models for QAToolKit libraries, but also core logic and functions to modify `HttpRequest` object.

## 1. HttpRequest functions
HttpRequest object is one of the main objects that is shared among the QA Toolkit libraries. `QAToolKit.Core` library contains `HttpRequestTools` which gives us functions to manipulate the HttpRequest object.

Currently there are `HttpRequestDataReplacer` and `HttpRequestDataGenerator` which is still experimental.

### 1.1. HttpRequestDataReplacer
This is a method that will accept key/value pairs for replacement of placeholders in the `HttpRequest` object.

```csharp
options.AddReplacementValues(new ReplacementValue[] {
new ReplacementValue()
    {
        Key = "version",
        Value = "1"
    },
    {
        Key = "parentId",
        Value = "4"
    }
});
```

In the example above we say: "Replace `{version}` and {parentId} placeholders in Path and URL parameters and JSON body models."

In other words, if you have a test API endpoint like this: https://api.demo.com/v{version}/categories?parent={parentId} that will be set to https://api.demo.com/v1/categories?parent=4.

That, does not stop there, you can also populate JSON request bodies.

For example if you set the replacement value to stringified json:

```csharp
options.AddReplacementValues(new ReplacementValue[] {
new ReplacementValue()
    {
        Key = "parent",
        Value = "{\"id\":\"100\",\"name\":\"Parent Name\"}"
    }
});
```
than the parent model object will be replaced with the stringified json above.

What happend behind the curtains, the model proxy class is generated, which is then used to Deserialized the JSON into the object.
`HttpRequest` list is then scanned and values are properly replaced.


### 1.2. HttpRequestDataGenerator - Experimental
##### !! EXPERIMENTAL !!
This is an experimental feature. It will generate the missing data in the `List<HttpRequest>` object from the swagger models, uri and query parameters.

Wait for official announcement to use this feature.

# License

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