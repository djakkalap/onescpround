using Smod2;
using Smod2.Attributes;
using Smod2.Config;
using Smod2.EventHandlers;

namespace OneSCPRound {
    [PluginDetails(
        author = "djakkalap",
        name = "One SCP Round",
        description = "This plugin gives a chance for a round with multiple of one type of SCP.",
        id = "djakkalap.osrplugin",
        configPrefix = "osr",
        version = "0.1",
        SmodMajor = 3,
        SmodMinor = 5,
        SmodRevision = 0
        )]

    public class OSRPlugin : Plugin {
        public override void OnEnable() {}

        public override void OnDisable() {}

        // Register the parts of the plugin.
        public override void Register() {
            AddConfig(new ConfigSetting("osr_disable", false, true, "This boolean determines whether to disable the plugin."));
            AddConfig(new ConfigSetting("osr_round_chance", 0.2f, true, "This number is the chance of an OSR round happening."));
            AddConfig(new ConfigSetting("osr_players_threshold", 20, true, "This number is the amount of players needed on the server for an OSR to be possible."));
            AddConfig(new ConfigSetting("osr_scps_disallowed", new string[] { }, true, "This list contains the names of SCPs that are not allowed to spawn for a OSR round."));

            AddEventHandler(typeof(IEventHandlerRoundStart), new StartOSR(this));
            AddEventHandler(typeof(IEventHandlerWaitingForPlayers), new MiscEventHandler(this));
        }
    }
}
