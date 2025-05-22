# Use the .NET 9.0 SDK image to build the application
# WHY: This image includes the full .NET SDK needed to restore, build, and publish your app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env

# Set the working directory inside the container to /app
# WHY: Keeps file paths consistent and isolates build files to this folder
WORKDIR /app

# Copy the project file into the container
# WHY: Allows restoring NuGet dependencies before copying the entire source code, leveraging Docker layer caching
COPY *.csproj ./

# Restores Nuget packages 
# WHY: Betters performance because it only runs if the csproj has changed from previous 
# NOTE: From .NET 5+ it's not really needed because dotnet publish does it automatically if needed, but including it gives better performance
RUN dotnet restore

# Copy the rest of the source code into the container
# WHY: Needed to actually compile and publish the application
COPY . ./

# Publish the app in Release configuration to the /out directory
# WHY: Produces a self-contained output ready for deployment, optimized for performance
RUN dotnet publish -c Release -o out

# Use the smaller ASP.NET Core Runtime image to run the app
# WHY: This runtime-only image is smaller and more secure for production than the full SDK
FROM mcr.microsoft.com/dotnet/aspnet:9.0

# Set the working directory for the runtime container
# WHY: Keeps the runtime files organized in a known location
WORKDIR /app

# Copy the published output from the build stage into the runtime container
# WHY: Brings in only the compiled app, leaving behind build tools and source files
COPY --from=build-env /app/out .

# Define the entry point command to run the application
# WHY: Tells the container how to start your .NET app when the container is launched
ENTRYPOINT [ "dotnet", "PlatformService.dll" ]
