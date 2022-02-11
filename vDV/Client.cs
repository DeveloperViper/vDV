using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vDV
{
    public class Client : BaseScript
    {
        [Command("dv")]
        public void DvCommand(int source, List<object> args, string raw)
        {
           
            var ped = PlayerPedId();
            if (IsPedInAnyVehicle(ped, false))
            {
                var curVehicle = GetVehiclePedIsIn(ped, false);
                if (GetPedInVehicleSeat(curVehicle, -1) == ped)
                {
                    DeleteEntity(ref curVehicle);

                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        multiline = true,
                        args = new[] { "^2Your vehicle has been deleted!" }
                    });

                }
            }
        }
    }
}
