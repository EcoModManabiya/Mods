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
    [Weight(100)]                                          
    public partial class MYGrilledFishItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Grilled Fish"; } }
        public override string Description                      { get { return "A grilled fish."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 9, Protein = 16, Vitamins = 5};
        public override float Calories                          { get { return 170; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }
}