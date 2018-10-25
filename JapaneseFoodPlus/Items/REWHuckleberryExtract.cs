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
    [Weight(200)]                                          
    public partial class HuckleberryExtractItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Huckleberry Extract"; } }
        public override string Description                      { get { return "A concentrated blast of huckleberry goodness."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 15};
        public override float Calories                          { get { return 60; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYStockPotObject))]          
    [RequiresSkill(typeof(CulinaryArtsSkill), 1)]    
    public partial class HuckleberryExtractRecipe : Recipe
    {
        public HuckleberryExtractRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<HuckleberryExtractItem>(),
                new CraftingElement<GarbageItem>(typeof(CulinaryArtsEfficiencySkill), 1, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HuckleberriesItem>(typeof(CulinaryArtsEfficiencySkill), 50, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(HuckleberryExtractRecipe), Item.Get<HuckleberryExtractItem>().UILink(), 5, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Huckleberry Extract", typeof(HuckleberryExtractRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}