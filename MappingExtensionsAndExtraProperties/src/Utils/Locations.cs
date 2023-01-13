﻿using System;
using System.Collections.Generic;
using StardewValley;

namespace MappingExtensionsAndExtraProperties.Utils;

public class Locations
{
    public static void RemoveFakeNpcs(GameLocation location)
    {
        List<Tuple<GameLocation, NPC>> charactersToRemove = new();

        foreach (NPC character in location.characters)
        {
            if (character is FakeNpc)
                charactersToRemove.Add(Tuple.Create(location, character));
        }

        foreach (var character in charactersToRemove)
        {
            character.Item1.characters.Remove(character.Item2);
        }
    }

    public static void PlaceFakeNpcs(GameLocation location)
    {

    }
}