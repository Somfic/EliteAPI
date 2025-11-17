{
  description = "EliteAPI development environment";

  inputs = { nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable"; };

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system:
      let pkgs = nixpkgs.legacyPackages.${system};
      in {
        devShells.default = pkgs.mkShell {
          buildInputs = with pkgs; [ dotnet-sdk_10 ];

          # Set up environment variables
          shellHook = ''
            # Disable .NET telemetry
            export DOTNET_CLI_TELEMETRY_OPTOUT=1

            # Set up .NET tools path
            export DOTNET_ROOT="${pkgs.dotnet-sdk_10}"
            export PATH="$HOME/.dotnet/tools:$PATH"
          '';
        };
      });
}
