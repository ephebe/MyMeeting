FROM mcr.microsoft.com/dotnet/sdk:6.0 as builder

WORKDIR /src

COPY ./src/Directory.Build.props ./
COPY ./src/Directory.Build.targets ./
COPY ./src/Directory.Packages.props ./
COPY ./src/Packages.props ./
COPY ./src/Services/Meetings/Directory.Build.props ./Services/Meetings/

COPY ["src/Services/Meetings/MyMeeting.Services.Meeting.Api/MyMeeting.Services.Meeting.Api.csproj", "src/Services/Meetings/MyMeeting.Services.Meeting.Api/"]
COPY ["src/building-blocks/BuildBlocks.Persistence.EfCore.SqlServer/BuildBlocks.Persistence.EfCore.SqlServer.csproj", "src/building-blocks/BuildBlocks.Persistence.EfCore.SqlServer/"]
COPY ["src/building-blocks/BuildingBlocks.Core/BuildingBlocks.Core.csproj", "src/building-blocks/BuildingBlocks.Core/"]
COPY ["src/building-blocks/BuildingBlocks.Abstractions/BuildingBlocks.Abstractions.csproj", "src/building-blocks/BuildingBlocks.Abstractions/"]
COPY ["src/building-blocks/BuildingBlocks.Integration.MassTransit/BuildingBlocks.Integration.MassTransit.csproj", "src/building-blocks/BuildingBlocks.Integration.MassTransit/"]
COPY ["src/building-blocks/BuildingBlocks.Messaging.Persistence.SqlServer/BuildingBlocks.Messaging.Persistence.SqlServer.csproj", "src/building-blocks/BuildingBlocks.Messaging.Persistence.SqlServer/"]

COPY ["src/Services/Meetings/MyMeeting.Services.Meeting.Infrastructure/MyMeeting.Services.Meeting.Infrastructure.csproj", "src/Services/Meetings/MyMeeting.Services.Meeting.Infrastructure/"]
COPY ["src/Services/Meetings/MyMeeting.Services.Meetings.Application/MyMeeting.Services.Meetings.Application.csproj", "src/Services/Meetings/MyMeeting.Services.Meetings.Application/"]
COPY ["src/Services/Meetings/MyMeeting.Services.Meetings.Core/MyMeeting.Services.Meetings.Core.csproj", "src/Services/Meetings/MyMeeting.Services.Meetings.Core/"]
COPY ["src/Services/Shared/MyMeeting.Services.Shared/MyMeeting.Services.Shared.csproj", "src/Services/Shared/MyMeeting.Services.Shared/"]

RUN ls

RUN dotnet restore "src/Services/Meetings/MyMeeting.Services.Meeting.Api/MyMeeting.Services.Meeting.Api.csproj"

COPY ./src/BuildingBlocks/ ./BuildingBlocks/
COPY ./src/Services/Meetings/MyMeeting.Services.Meeting.Api/  ./Services/Meetings/MyMeeting.Services.Meeting.Api/
COPY ./src/Services/Meetings/MyMeeting.Services.Meeting.Infrastructure/  ./Services/Meetings/MyMeeting.Services.Meeting.Infrastructure/
COPY ./src/Services/Meetings/MyMeeting.Services.Meetings.Application/  ./Services/Meetings/MyMeeting.Services.Meetings.Application/
COPY ./src/Services/Meetings/MyMeeting.Services.Meetings.Core/  ./Services/Meetings/MyMeeting.Services.Meetings.Core/
COPY ./src/Services/Shared/  ./Services/shared/

RUN dotnet build -c Release --no-restore "MyMeeting.Services.Meeting.Api.csproj"  -o /app/build

WORKDIR "/src/src/Services/Meetings/MyMeeting.Services.Meeting.Api"

RUN ls
RUN dotnet publish -c Release --no-build --no-restore -o out

WORKDIR /app
COPY --from=builder /src/Services/Meetings/MyMeeting.Services.Meeting.Api/out  .

EXPOSE 80
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT docker

ENTRYPOINT ["dotnet", "MyMeeting.Services.Meeting.Api.dll"]