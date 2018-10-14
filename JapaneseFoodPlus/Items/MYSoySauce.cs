namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    
    [Serialized]
    [Weight(50)]                                          
    public partial class MYSoySauceItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Soy Sauce"; } }
        public override string Description                      { get { return "The liquid seasoning which I assume cereals raw materials mainly, and I let you ferment, and is prepared by a brewing technology."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 1, Fat = 0, Protein = 1, Vitamins = 0};
        public override float Calories                          { get { return 4; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }
}