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
    public partial class MYSaltItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Salt"; } }
        public override string FriendlyNamePlural 　　　　　　　　　　　　　　{ get { return "Salt"; } } 
        public override string Description                      { get { return "Produced by seawater it can be rock salt and use in industries."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0};
        public override float Calories                          { get { return 0; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }
}