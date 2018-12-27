using System;
using System.Collections.Generic;

namespace EliteAPI
{

    public class EngineerCraftInfo
    {
        public DateTime timestamp { get; set; }

        public string Slot { get; set; }
        public string Module { get; set; }
        public IngredientInfo[] Ingredients { get; set; }
        public string Engineer { get; set; }
        public int EngineerID { get; set; }
        public int BlueprintID { get; set; }
        public string BlueprintName { get; set; }
        public int Level { get; set; }
        public float Quality { get; set; }
        public ModifierInfo[] Modifiers { get; set; }
    }

    public class IngredientInfo
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }
    }

    public class ModifierInfo
    {
        public string Label { get; set; }
        public float Value { get; set; }
        public float OriginalValue { get; set; }
        public int LessIsGood { get; set; }
    }

}
