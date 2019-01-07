﻿using MeilleurDisponnible.CustomMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public class CharacterEntityMappingProvider : IMappingProvider
    {
        public TDestination Map<TDestination>(object input)
        {
            object character = null;

            if (input is CreateCharacterDTO)
            {
                character = Map((CreateCharacterDTO)input);
            }

            return (TDestination)character;
        }

        private Character Map(CreateCharacterDTO input)
        {
            Character character = new Character
            {
                Name = input.name
            };
            return character;
        }
    }
}
