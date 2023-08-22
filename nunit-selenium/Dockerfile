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

# Use the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /App

# Copy the published application
COPY . ./

# Set the entry point to run tests when the container is started
ENTRYPOINT ["dotnet", "test"]
