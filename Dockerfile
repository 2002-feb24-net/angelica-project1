

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /app

COPY . ./

RUN dotnet publish -o publish


FROM mcr.microsoft.com/dotnet/core/runtime:3.1

WORKDIR /app


COPY --from=build /app/publish ./

CMD [ "dotnet", "FlowerShop2.WebUI.dll" ]

