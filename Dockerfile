# Use the official .NET SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

# Set the working directory to the root directory of the solution
WORKDIR /app

# Copy the solution file and restore dependencies
COPY AirplaneTicketing.sln .
COPY src/HospitalAPI/AirplaneTicketingAPI.csproj ./src/HospitalAPI/
COPY src/HospitalLibrary/AirplaneTicketingLibrary.csproj ./src/HospitalLibrary/
RUN dotnet restore

# Copy the source code and build the solution
COPY . .
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:5.0

# Set the working directory to the project directory
WORKDIR /app

# Copy the published output from the build environment
COPY --from=build-env /app/out .

# Expose port 80 for HTTP traffic
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "AirplaneTicketingAPI.dll"]