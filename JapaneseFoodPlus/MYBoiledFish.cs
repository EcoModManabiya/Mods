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
    public partial class MYBoiledFishItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Boiled Fish"; } }
        public override string Description                      { get { return "The dish which boils a fish with the juice which I seasoned."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 4, Protein = 22, Vitamins = 1};
        public override float Calories                          { get { return 181; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }
}