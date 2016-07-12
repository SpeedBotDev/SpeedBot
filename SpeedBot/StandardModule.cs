using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Commands.Permissions.Levels;
using Discord.Modules;

namespace SpeedBot
{
    class StandardModule : IModule
    {
        private DiscordClient _client;
        private ModuleManager _manager;

        void IModule.Install(ModuleManager manager)
        {
            _manager = manager;
            _client = manager.Client;

            manager.CreateCommands("", cgb =>
            {
                cgb.MinPermissions((int)PermissionLevel.User);

                // Start of the say command
                cgb.CreateCommand("say")                     // name of command
                .MinPermissions((int)PermissionLevel.User)   // Change this to change restrictions
                .Description("Make the bot speak!")          // description derp
                .Parameter("text", ParameterType.Unparsed)   
                .Do(async e =>
                    {
                        await e.Channel.SendMessage(e.GetArg("text"));
                    });

                // Start of params command
                cgb.CreateCommand("params") // This command doesn't have any use, just an example for ParamenterType.Multiple
                .Description("Multiple paramter test")
                .Parameter("text", ParameterType.Multiple)
                .Do(async e =>
                {
                    StringBuilder output = new StringBuilder();

                    output.AppendLine("Parameters:");

                    for (int i = 0; i < e.Args.Length; i++)
                    {
                        output.AppendLine($"{i}: {e.Args[i]}");
                    }

                    await e.Channel.SendMessage(output.ToString());

                });

            });

        }

    }

}
