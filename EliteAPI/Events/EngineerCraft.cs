using System;
using System.Collections.Generic;

namespace EliteAPI
{

    public class EngineerCraftInfo
    {
        public DateTime timestamp { get; }

        public string Slot { get; }
        public string Module { get; }
        public IngredientInfo[] Ingredients { get; }
        public string Engineer { get; }
        public int EngineerID { get; }
        public int BlueprintID { get; }
        public string BlueprintName { get; }
        public int Level { get; }
        public float Quality { get; }
        public ModifierInfo[] Modifiers { get; }
    }

    public class IngredientInfo
    {
        public string Name { get; }
        public string Name_Localised { get; }
        public int Count { get; }
    }

    public class ModifierInfo
    {
        public string Label { get; }
        public float Value { get; }
        public float OriginalValue { get; }
        public int LessIsGood { get; }
    }

}
