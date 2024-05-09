using Service;
using System.Diagnostics;

CreateHostBuilder(args).Build().Run();
    static IHostBuilder CreateHostBuilder(string[] args)
{
	var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
	var pathToContentRoot = Path.GetDirectoryName(pathToExe);

	return Host.CreateDefaultBuilder(args)
			.ConfigureWebHostDefaults(
			webBuilder =>
			{
				webBuilder.UseContentRoot(pathToContentRoot)
						.UseStartup<Startup>()
						.UseUrls("http://localhost:37590/");
			});

}
