![SonarQUbe](https://sonarcloud.io/api/project_badges/measure?project=netcore-lab&metric=alert_status)

# netcore-lab

For my learning .NET CORE 2

## Set Variable Environment
export LAB_DBCONNECTION="server=localhost;userid=root;password=1234;database=esb_lab;convert zero datetime=True;"

or set permanant on
### macOS 11+ (bash)
~/.bash_profile
### windows
Variable Environement

## Create Container Database
docker build -t mysql_db -f Dockerfile_mysql .
docker run -it -p 3306:3306 -v /Users/ifew/mysql_db:/var/lib/mysql --name mysql_db mysql_db

## Create Database
Import file *.sql (exclude from GIT)

## RUN as Development
``ASPNETCORE_ENVIRONMENT=Development dotnet run``

## Get Token to access API
Request Token Endpoint: http://localhost:5001/api/token

Send JSON Data

``
{
	"Username": "iFew",
	"Password": "1234"
}
``

Example Return

``
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1MTY4MTM0ODgsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS8iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEvIn0.Px5vkJovQLNWd3C-RjOhXJSbqL9Opnxg5jSEmlfZetE"
}
``

## Access API via Token
Using Authorize in Header

Header Example to access to http://localhost:5001/api/member/test

``
Authorization Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1MTY4MTM0ODgsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS8iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDEvIn0.Px5vkJovQLNWd3C-RjOhXJSbqL9Opnxg5jSEmlfZetE
``


## Test Multi-Language URL
- /api/values/test_lang?culture=en-US
- /api/values/test_lang?culture=th-TH
- /api/values/test_lang?culture=zh-CN

## example cmd msbuild
2msbuild.exe" "D:\a\1\s\aspnetapp.sln" /nologo /nr:false /dl:CentralLogger,"D:\a\_tasks\VSBuild_71a9a2d3-a98a-4caa-96ab-affca411ecda\1.126.0\ps_modules\MSBuildHelpers\Microsoft.TeamFoundation.DistributedTask.MSBuild.Logger.dll";"RootDetailId=773c7c06-0fa8-4ebd-a3c3-f31879bbdd07|SolutionDir=D:\a\1\s"*ForwardingLogger,"D:\a\_tasks\VSBuild_71a9a2d3-a98a-4caa-96ab-affca411ecda\1.126.0\ps_modules\MSBuildHelpers\Microsoft.TeamFoundation.DistributedTask.MSBuild.Logger.dll" /p:DeployOnBuild=true /p:WebPublishMethod=Package /p:PackageAsSingleFile=true /p:SkipInvalidConfigurations=true /p:PackageLocation="D:\a\1\a\\" /p:platform="any cpu" /p:configuration="release" /p:VisualStudioVersion="15.0" /p:_MSDeployUserAgent="VSTS_3a02d011-28d5-42db-bc71-65f5a894057d_build_4_0"
