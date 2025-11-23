#!/usr/bin/env pwsh

param(
    [string]$DestinationPath = "C:\Program Files (x86)\Steam\steamapps\common\VoiceAttack 2\Apps\EliteAPI",
    [switch]$SkipVoiceAttackRestart
)

# Detect if running on Windows
$IsWindowsOS = ($PSVersionTable.PSVersion.Major -lt 6) -or ($IsWindows -eq $true)

Write-Host "Stopping VoiceAttack..." -ForegroundColor Cyan

if (-not $SkipVoiceAttackRestart -and $IsWindowsOS) {
    try {
        Stop-Process -Name "VoiceAttack" -Force -ErrorAction SilentlyContinue
        Write-Host "VoiceAttack stopped." -ForegroundColor Green
    } catch {
        Write-Host "VoiceAttack was not running." -ForegroundColor Yellow
    }

    Start-Sleep -Seconds 2
}

Write-Host "`nBuilding plugin..." -ForegroundColor Cyan
dotnet clean "EliteVA/EliteVA.csproj" -c Debug
dotnet build "EliteVA/EliteVA.csproj" -c Debug

if ($LASTEXITCODE -ne 0) {
    Write-Error "Build failed!"
    exit 1
}

Write-Host "`nCopying plugin files..." -ForegroundColor Cyan

# Create destination directory if it doesn't exist
if (-not (Test-Path $DestinationPath)) {
    New-Item -ItemType Directory -Path $DestinationPath -Force | Out-Null
}

Copy-Item "EliteVA/bin/Debug/net8.0/EliteVA.dll" "$DestinationPath/EliteVA.dll" -Force
Copy-Item "EliteVA/bin/Debug/net8.0/EliteAPI.dll" "$DestinationPath/EliteAPI.dll" -Force
Copy-Item "EliteAPI/bin/Debug/net48/Newtonsoft.Json.dll" "$DestinationPath/Newtonsoft.Json.dll" -Force

Write-Host "Plugin deployed successfully." -ForegroundColor Green

if (-not $SkipVoiceAttackRestart -and $IsWindowsOS) {
    Write-Host "`nStarting VoiceAttack..." -ForegroundColor Cyan
    $voiceAttackExe = "C:\Program Files (x86)\Steam\steamapps\common\VoiceAttack 2\VoiceAttack.exe"
    if (Test-Path $voiceAttackExe) {
        Start-Process $voiceAttackExe
        Write-Host "Done!" -ForegroundColor Green
    } else {
        Write-Warning "VoiceAttack.exe not found at: $voiceAttackExe"
    }
}
