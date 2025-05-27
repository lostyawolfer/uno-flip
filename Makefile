build:
	dotnet publish -c Release -r linux-x64 -p:AssemblyName=uno-flip-linux
	dotnet publish -c Release -r win-x64 -p:AssemblyName=uno-flip