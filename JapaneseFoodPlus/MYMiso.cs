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
    [Weight(10)]                                          
    public partial class MYMisoItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Miso"; } }
        public override string Description                      { get { return "One of the seasonings of the Japanese style. I steamed soybeans and let I added salt, malted rice and ferment."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 1, Protein = 2, Vitamins = 0};
        public override float Calories                          { get { return 35; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }
}