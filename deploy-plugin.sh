#!/bin/bash

DESTINATION_PATH="${1:-C:/Program Files (x86)/Steam/steamapps/common/VoiceAttack 2/Apps/EliteAPI}"

echo "Building plugin..."
dotnet clean VoiceAttack/VoiceAttack.csproj -c Debug
dotnet build VoiceAttack/VoiceAttack.csproj -c Debug

if [ $? -ne 0 ]; then
    echo "Build failed!"
    exit 1
fi

echo ""
echo "Copying plugin files..."

# Create destination directory if it doesn't exist
mkdir -p "$DESTINATION_PATH"

cp -f VoiceAttack/bin/Debug/net8.0/VoiceAttack.dll "$DESTINATION_PATH/VoiceAttack.dll"
cp -f VoiceAttack/bin/Debug/net8.0/EliteAPI.dll "$DESTINATION_PATH/EliteAPI.dll"

echo "Plugin deployed successfully."
