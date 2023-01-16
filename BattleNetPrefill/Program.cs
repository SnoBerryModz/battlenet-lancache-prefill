namespace BattleNetPrefill
{
    // TODO - Spectre - Once pull request has been merged into Spectre, remove reference to forked copy of the project
    // TODO - Documentation - Install instructions.Possibly add the wget + unzip command as well for linux users?
    // TODO - Documentation - Add linux command examples to readme.
    // TODO - Port Lancache common over to this repo
    // TODO - Add publish build pipeline 
    // TODO - Migrate to submodule
    public static class Program
    {
        public static async Task<int> Main()
        {
            var description = "Automatically fills a Lancache with games from Battle.net, so that subsequent downloads will be \n" +
                              "  served from the Lancache, improving speeds and reducing load on your internet connection.";
            return await new CliApplicationBuilder()
                         .AddCommandsFromThisAssembly()
                         .SetTitle("BattleNetPrefill")
                         .SetExecutableName($"BattleNetPrefill{(IsWindows() ? ".exe" : "")}")
                         .SetDescription(description)
                         .Build()
                         .RunAsync();
        }

        public static bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    }
}