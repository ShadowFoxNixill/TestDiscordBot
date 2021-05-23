using System.IO;
using System.Threading.Tasks;
using DSharpPlus;

namespace Nixill.Discord
{
  class TDBMain
  {
    static void Main(string[] args)
    {
      MainAsync().GetAwaiter().GetResult();
    }

    static async Task MainAsync()
    {
      var discord = new DiscordClient(new DiscordConfiguration()
      {
        Token = File.ReadAllLines("token")[0],
        TokenType = TokenType.Bot
      });

      discord.MessageCreated += async (s, e) =>
      {
        if (e.Message.Content.ToLower().StartsWith("ping"))
          await e.Message.RespondAsync("pong!");
      };

      await discord.ConnectAsync();
      await Task.Delay(-1);
    }
  }
}