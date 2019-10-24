using Smod2.EventHandlers;
using Smod2.Events;

namespace OneSCPRound {
    class MiscEventHandler : IEventHandlerWaitingForPlayers {
        private readonly OSRPlugin plugin;

        public MiscEventHandler(OSRPlugin plugin) => this.plugin = plugin;

        public void OnWaitingForPlayers(WaitingForPlayersEvent ev) {
            if (plugin.GetConfigBool("osr_disable")) plugin.PluginManager.DisablePlugin(plugin);
        }
    }
}
