using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.SlashCommands;

namespace Nixill.Discord
{
  class TDBMain
  {
    internal static DiscordClient Discord;
    internal static DiscordSlashClient Commands;

    static void Main(string[] args)
    {
      MainAsync().GetAwaiter().GetResult();
    }

    static async Task MainAsync()
    {
      string botToken = File.ReadAllLines("token")[0];

      Discord = new DiscordClient(new DiscordConfiguration()
      {
        Token = botToken,
        TokenType = TokenType.Bot
      });

      Commands = new DiscordSlashClient(new DiscordSlashConfiguration()
      {
        Token = botToken,
        Client = Discord,
        Logger = Discord.Logger,
      });

      Discord.InteractionCreated += Commands.HandleGatewayEvent;

      await Discord.ConnectAsync();

      Commands.RegisterCommands(Assembly.GetExecutingAssembly());

      await Commands.StartAsync();
      await Task.Delay(-1);
    }
  }
}