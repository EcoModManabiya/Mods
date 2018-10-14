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
    public partial class MYEggItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Egg"; } }
        public override string Description                      { get { return "Among eggs, a thing liked for consumption use most is a chicken egg."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 5, Protein = 6, Vitamins = 1};
        public override float Calories                          { get { return 77; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }
}