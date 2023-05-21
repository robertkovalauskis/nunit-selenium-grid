FROM mcr.microsoft.com/dotnet/sdk:6.0

RUN apt-get update \
    && apt-get install -y

COPY . .

ENV HUB_HOST localhost 
ENV BROWSER chrome
ENV CATEGORY Smoke
ENV ASPNETCORE_ENVIRONMENT Development
ENV EasycruitUsername CompleteUser
ENV Password defaultPassword123

ENTRYPOINT dotnet test --filter TestCategory="$CATEGORY" --logger html