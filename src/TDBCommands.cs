using System;
using System.Threading.Tasks;
using DSharpPlus.SlashCommands.Attributes;
using DSharpPlus.SlashCommands.Entities;
using Nixill.Utils;

namespace Nixill.Discord
{
  public class CommandListing : BaseSlashCommandModule
  {
    public CommandListing(IServiceProvider p) : base(p) { }

    [SlashCommand("ping")]
    [DSharpPlus.CommandsNext.Attributes.Description("Gives you a pong!")]
    public async Task PingCommandAsync(InteractionContext ctx)
    {
      await ctx.ReplyAsync($"Pong! {TDBMain.Discord.Ping}");
    }

    [SlashCommand("frombase", 608847976554692611)]
    [DSharpPlus.CommandsNext.Attributes.Description("Converts a number from a given base to base 10.")]
    public async Task FromBaseCommandAsync(InteractionContext ctx,
      [DSharpPlus.CommandsNext.Attributes.Description("The number as represented in the given base.")] string text,
      [DSharpPlus.CommandsNext.Attributes.Description("The base from which to convert the number.")] int from_base = 16
    )
    {
      try
      {
        int val = NumberUtils.StringToInt(text, from_base);
        await ctx.ReplyAsync($"{text} in base {from_base} => {val} in base 10.");
      }
      catch (Exception ex)
      {
        await ctx.ReplyAsync($"{ex.StackTrace}");
      }
    }

    // [SlashCommand("tobase", 1)]
    // [DSharpPlus.CommandsNext.Attributes.Description("Converts a number to a given base from base 10.")]
    // public async Task ToBaseCommandAsync(InteractionContext ctx,
    //   [System.ComponentModel.Description("The number as represented in base 10.")] int val,
    //   [System.ComponentModel.Description("The base to which to convert the number.")] int toBase)
    // {
    //   string text = NumberUtils.IntToString(val, toBase);
    //   await ctx.ReplyAsync($"{val} in base 10 => {text} in base {toBase}.");
    // }
  }
}