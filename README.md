# ITIS_2021_2_DocumentService

Cервис, который заполняет документы. Шаблоны документов берутся из сервиса шаблонов, данные пользователя берутся из сервиса пользовательских данных, непостоянные данные ( типо даты начала и конца отпуска) запрашиваем у пользователя. На вход получаем тип заявления, id пользователя, переменные данные. Возвращаем заполненный шаблон.

## Getting started

### Prerequisites 


* .NET [download](https://dotnet.microsoft.com/download/dotnet/5.0)
* [TemplateService](https://github.com/ITIS-MICROSERVICES-2021/TemplateService)

### Running

#### Running with CLI

```
dotnet run ./DocumentService/DocumentService.csproj
```

Run the following command in your solutiuon (DocumentService.sln) directory:

#### Running with Visual Studio/Rider

1. Open `DocumentService.sln` with your preferred IDE
2. Set startup project in your build configuration to `BadSmellingDocumentServiceUsingCSharp.csproj`
3. Run the solution
