#!/usr/bin/env pwsh

param(
    [ValidateSet("VA1", "VA2", "Both")]
    [string]$Version = "Both",

    [string]$VA1Path = "C:\Program Files (x86)\Steam\steamapps\common\VoiceAttack\Apps\EliteAPI",
    [string]$VA2Path = "C:\Program Files (x86)\Steam\steamapps\common\VoiceAttack 2\Apps\EliteAPI",

    [switch]$SkipRestart,
    [switch]$NoTest
)

# Detect if running on Windows
$IsWindowsOS = ($PSVersionTable.PSVersion.Major -lt 6) -or ($IsWindows -eq $true)

function Stop-VoiceAttackProcess {
    param([string]$ProcessName)

    if ($IsWindowsOS) {
        try {
            $process = Get-Process -Name $ProcessName -ErrorAction SilentlyContinue
            if ($process) {
                Stop-Process -Name $ProcessName -Force -ErrorAction SilentlyContinue
                Write-Host "Stopped $ProcessName." -ForegroundColor Green
                Start-Sleep -Seconds 2
            }
        }
        catch {
            Write-Host "$ProcessName was not running." -ForegroundColor Yellow
        }
    }
}

function Start-VoiceAttackProcess {
    param([string]$ExePath, [string]$Name)

    if ($IsWindowsOS -and (Test-Path $ExePath)) {
        Write-Host "Starting $Name..." -ForegroundColor Cyan
        Start-Process $ExePath
        Write-Host "$Name started." -ForegroundColor Green
    }
    else {
        Write-Warning "$Name not found at: $ExePath"
    }
}

function Deploy-Plugin {
    param(
        [string]$TargetFramework,
        [string]$DestinationPath,
        [string]$Name
    )

    Write-Host "`nDeploying to $Name ($TargetFramework)..." -ForegroundColor Cyan

    # Create destination directory if it doesn't exist
    if (-not (Test-Path $DestinationPath)) {
        New-Item -ItemType Directory -Path $DestinationPath -Force | Out-Null
    }

    # Copy all items from build output to destination
    $buildOutputPath = "EliteVA/bin/Debug/$TargetFramework/"
    if (Test-Path $buildOutputPath) {
        Get-ChildItem -Path $buildOutputPath -Filter *.dll | ForEach-Object {
            Copy-Item $_.FullName -Destination $DestinationPath -Force
            Write-Host "  Copied $($_.Name)" -ForegroundColor Gray
        }
        Write-Host "$Name deployment complete." -ForegroundColor Green
    }
    else {
        Write-Error "Build output not found at: $buildOutputPath"
        return $false
    }

    return $true
}

# Stop VoiceAttack instances
if (-not $SkipRestart) {
    Write-Host "Stopping VoiceAttack instances..." -ForegroundColor Cyan

    if ($Version -eq "VA1" -or $Version -eq "Both") {
        Stop-VoiceAttackProcess -ProcessName "VoiceAttack"
    }

    if ($Version -eq "VA2" -or $Version -eq "Both") {
        Stop-VoiceAttackProcess -ProcessName "VoiceAttack"
    }
}

# Build plugin
Write-Host "`nBuilding plugin..." -ForegroundColor Cyan
dotnet clean "EliteVA/EliteVA.csproj" -c Debug | Out-Null
dotnet build "EliteVA/EliteVA.csproj" -c Debug

if ($LASTEXITCODE -ne 0) {
    Write-Error "Build failed!"
    exit 1
}

Write-Host "Build successful." -ForegroundColor Green

# Deploy to selected version(s)
$deploySuccess = $true

if ($Version -eq "VA1" -or $Version -eq "Both") {
    if (-not (Deploy-Plugin -TargetFramework "net48" -DestinationPath $VA1Path -Name "VoiceAttack 1")) {
        $deploySuccess = $false
    }
}

if ($Version -eq "VA2" -or $Version -eq "Both") {
    if (-not (Deploy-Plugin -TargetFramework "net8.0" -DestinationPath $VA2Path -Name "VoiceAttack 2")) {
        $deploySuccess = $false
    }
}

if (-not $deploySuccess) {
    Write-Error "Deployment failed for one or more versions!"
    exit 1
}

# Start VoiceAttack for testing
if (-not $SkipRestart -and -not $NoTest) {
    Write-Host "`nStarting VoiceAttack for testing..." -ForegroundColor Cyan

    if ($Version -eq "VA1") {
        $va1Exe = "C:\Program Files (x86)\Steam\steamapps\common\VoiceAttack\VoiceAttack.exe"
        Start-VoiceAttackProcess -ExePath $va1Exe -Name "VoiceAttack 1"
    }
    elseif ($Version -eq "VA2") {
        $va2Exe = "C:\Program Files (x86)\Steam\steamapps\common\VoiceAttack 2\VoiceAttack.exe"
        Start-VoiceAttackProcess -ExePath $va2Exe -Name "VoiceAttack 2"
    }
    elseif ($Version -eq "Both") {
        Write-Host "`nBoth versions deployed. Start manually to test:" -ForegroundColor Yellow
        Write-Host "  VA1: $(Join-Path (Split-Path $VA1Path -Parent) 'VoiceAttack.exe')" -ForegroundColor Gray
        Write-Host "  VA2: C:\Program Files (x86)\Steam\steamapps\common\VoiceAttack 2\VoiceAttack.exe" -ForegroundColor Gray
    }
}

Write-Host "`nDone!" -ForegroundColor Green
