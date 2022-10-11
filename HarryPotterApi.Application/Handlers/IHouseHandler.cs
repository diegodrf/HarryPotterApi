using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarryPotterApi.Application.Comands;

namespace HarryPotterApi.Application.Handlers
{
    public interface IHouseHandler
    {
        Task<ICommandResult> AllHousesHandle(HouseCommand command);
        Task<ICommandResult> CharactersByHouseHandle(HouseCommand command);
    }
}