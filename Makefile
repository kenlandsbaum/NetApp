dev:
	dotnet run --project BlazorWeb

sec:
	dotnet run --project BlazorWeb -lp https

test:
	dotnet test BlazorWeb.Testing