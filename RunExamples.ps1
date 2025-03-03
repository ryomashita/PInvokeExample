$currentDir = Get-Location

# 1. Build CppLib
Write-Host "Building CppLib..." -ForegroundColor Green
Set-Location -Path ".\CppLib"
if (-not (Test-Path -Path ".\build")) {
    New-Item -Path ".\build" -ItemType Directory
}
Set-Location -Path ".\build"
cmake -G "Visual Studio 17 2022" -A x64 ..
cmake --build . --config Debug

Set-Location -Path $currentDir

# 2. Build CSharpApp
Write-Host "Building CSharpApp..." -ForegroundColor Green
dotnet build .\CSharpApp\CSharpApp.csproj -c Debug /p:Platform=x64

# 3. Run CSharpApp.exe
Write-Host "Running CSharpApp..." -ForegroundColor Green
# ビルドされた実行ファイルを実行
.\CSharpApp\bin\x64\Debug\CSharpApp.exe
