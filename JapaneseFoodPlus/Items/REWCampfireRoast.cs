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
    [Weight(500)]                                          
    public partial class CampfireRoastItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Campfire Roast"; } }
        public override string Description                      { get { return "The uneven flame might be mediocre for cooking, but the open flame imparts a great flavor."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 12, Protein = 16, Vitamins = 0};
        public override float Calories                          { get { return 1000; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYFlyingPanObject))]          
    [RequiresSkill(typeof(CampfireCreationsSkill), 3)]    
    public partial class CampfireRoastRecipe : Recipe
    {
        public CampfireRoastRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CampfireRoastItem>(),
               
               new CraftingElement<TallowItem>(1), 
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawRoastItem>(typeof(CampfireCreationsEfficiencySkill), 3, CampfireCreationsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CampfireRoastRecipe), Item.Get<CampfireRoastItem>().UILink(), 10, typeof(CampfireCreationsSpeedSkill)); 
            this.Initialize("Campfire Roast", typeof(CampfireRoastRecipe));
            CraftingComponent.AddRecipe(typeof(MYMortarOvenObject), this);
        }
    }
}