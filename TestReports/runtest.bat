taskkill /im chromedriver.exe /f
dotnet test ..\AmazonTest.csproj --filter TestCategory=regression
livingdoc test-assembly ..\bin\Debug\net6.0\AmazonTest.dll -t ..\bin\Debug\net6.0\TestExecution.json --title "Regression"
pause