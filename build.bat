@echo off
set version=%1
echo Build docker image university version: %version%

echo cleanup...
dotnet clean -c Debug
dotnet clean -c Release

echo delete old publish folders
for /d /r . %%d in (Publish) do @if exist "%%d" rd /s/q "%%d"

echo create publish...
dotnet publish -c Release --self-contained false -o ./Publish

echo remove previous docker images...
docker image rm university:%version% -f

echo create docker image...
docker image build -t university:%version% .

echo Download docker image universityversion: %version%
docker save university -o ./university-%version%.tar

echo Successfully done.
pause