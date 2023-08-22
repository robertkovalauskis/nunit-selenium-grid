#FROM mcr.microsoft.com/dotnet/sdk:6.0
#
#RUN apt-get update \
#    && apt-get install -y
#
#COPY . .
#
#ENV HUB_HOST localhost 
#ENV BROWSER chrome
#ENV CATEGORY Smoke
#ENV ASPNETCORE_ENVIRONMENT Development
#ENV ProjectUsername CompleteUser
#ENV Password defaultPassword123
#
#ENTRYPOINT dotnet test --filter TestCategory="$CATEGORY" --logger html

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out
# Run tests
RUN dotnet test --filter TestCategory="$CATEGORY" --logger html

# Variables
ENV HUB_HOST localhost 
ENV BROWSER chrome
ENV CATEGORY Smoke
ENV ASPNETCORE_ENVIRONMENT Development
ENV ProjectUsername CompleteUser
ENV Password defaultPassword123

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]