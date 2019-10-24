using System;
using System.Collections.Generic;
using System.Linq;

using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;

namespace OneSCPRound {
    class StartOSR : IEventHandlerRoundStart {
        private readonly OSRPlugin plugin;

        public StartOSR(OSRPlugin plugin) => this.plugin = plugin;

        public void OnRoundStart(RoundStartEvent ev) {
            Random rnd = new Random();

            // Chance of a OSR. (One SCP Round)
            if (rnd.NextDouble() < plugin.GetConfigFloat("osr_round_chance") && ev.Server.NumPlayers >= plugin.GetConfigInt("osr_players_threshold"))
            {
                List<Player> scpPlayers = ev.Server.GetPlayers(Smod2.API.Team.SCP);
                List<Role> allSCPS = new List<Role> { Role.SCP_049, Role.SCP_096, Role.SCP_106, Role.SCP_173, Role.SCP_939_53, Role.SCP_939_89 };
                List<Role> allowedSCPS = new List<Role>();

                // Filter disallowed SCPs from list.
                foreach (Role scpRole in allSCPS)
                {
                    if (!plugin.GetConfigList("osr_scps_disallowed").Contains(scpRole.ToString()))
                    {
                        allowedSCPS.Add(scpRole);
                    }
                }

                Role newScpRole = allowedSCPS[rnd.Next(allowedSCPS.Count)];

                foreach (Player scpPlayer in scpPlayers)
                {
                    scpPlayer.ChangeRole(newScpRole);
                }
            }
        }
    }
}
