# ������� ����� ��� ������
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# �������� ���� ������� � ��������������� �����������
COPY *.csproj .
RUN dotnet restore

# �������� ���� �������� ���
COPY . .

# �������� � ��������� ����������
RUN dotnet publish -c Release -o /app/publish

# ��������� �����
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# �������� ��������� ����������
COPY --from=build /app/publish .

# ��������� ��� Railway
ENV ASPNETCORE_URLS=http://+:8080
ENV DOTNET_RUNNING_IN_CONTAINER=true
EXPOSE 8080

# ��������� ����������
ENTRYPOINT ["dotnet", "MyShop.dll"]