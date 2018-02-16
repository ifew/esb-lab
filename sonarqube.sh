#!/usr/bin/env bash

set -e

mono /Users/ifew/Downloads/sonar-scanner-msbuild-4.0.2.892/SonarQube.Scanner.MSBuild.exe begin /k:"netcore-lab" /d:sonar.organization="few-bitbucket" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="ab7fd8fecb4a7b5d668d1ec8572ffed8d60061a5" /d:sonar.exclusions="**/wwwroot/lib/**/*, **/Startup.cs, **/Program.cs" 
#dotnet restore
dotnet msbuild
#dotnet test
mono /Users/ifew/Downloads/sonar-scanner-msbuild-4.0.2.892/SonarQube.Scanner.MSBuild.exe# end /d:sonar.login="ab7fd8fecb4a7b5d668d1ec8572ffed8d60061a5"