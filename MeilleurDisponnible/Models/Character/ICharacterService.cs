﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeilleurDisponnible.Models.Character
{
    public interface ICharacterService
    {
        List<Character> GetCharacters();
        void CreateCharacter(Character character, Game.Game game);
        Character HandleStatusUpdate(Character character);
        Character Update(Character character);
        Character Manger(Character character, Foods selection);
        Character Boire(Character character, Drinks choice);
        Character Dormir(Character character);
        int GetFactor(DateTime lastUpdate);
        Character CalculHealthUpdate(Character character);
    }
}
