FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /App

COPY . ./

ENV HUB_HOST localhost 
ENV BROWSER chrome
ENV CATEGORY Smoke
ENV ASPNETCORE_ENVIRONMENT Development
ENV ProjectUsername CompleteUser
ENV Password defaultPassword123

ENTRYPOINT ["dotnet", "test", "--filter", "TestCategory=$CATEGORY", "--logger", "html"]
