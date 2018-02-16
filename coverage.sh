#!/usr/bin/env bash

set -e

export "MiniCover=dotnet minicover"

dotnet restore
dotnet build
cd tests/api.UnitTest
$MiniCover instrument --workdir ../../ --sources "src/api/Services/*.cs" --sources "src/api/Models/*.cs" --assemblies "tests/api.UnitTest/bin/**/*.dll" --exclude-sources "**/Services/HttpClient/*" --exclude-sources "**/Models/Context/*" --coverage-file "tests/api.UnitTest.Result/coverage.json" --hits-file "tests/api.UnitTest.Result/coverage-hits.txt"

dotnet test --no-build

$MiniCover uninstrument --workdir ../../ --coverage-file "tests/api.UnitTest.Result/coverage.json"
$MiniCover report --workdir ../../ --coverage-file "tests/api.UnitTest.Result/coverage.json" --threshold 90
$MiniCover htmlreport --workdir ../../ --coverage-file "tests/api.UnitTest.Result/coverage.json" --output "tests/api.UnitTest.Result/report" --threshold 90