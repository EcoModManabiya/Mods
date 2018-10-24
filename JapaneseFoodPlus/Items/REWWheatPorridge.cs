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
    public partial class WheatPorridgeItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Wheat Porridge"; } }
        public override string FriendlyNamePlural               { get { return "Wheat Porridge"; } } 
        public override string Description                      { get { return "A thick gruel of wheat, wheat, more wheat, and a dash of huckleberry flavor."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 10, Fat = 0, Protein = 4, Vitamins = 10};
        public override float Calories                          { get { return 510; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYFlyingPanObject))]          
    [RequiresSkill(typeof(CampfireCreationsSkill), 1)]    
    public partial class WheatPorridgeRecipe : Recipe
    {
        public WheatPorridgeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WheatPorridgeItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WheatItem>(typeof(CampfireCreationsEfficiencySkill), 15, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<HuckleberriesItem>(typeof(CampfireCreationsEfficiencySkill), 20, CampfireCreationsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WheatPorridgeRecipe), Item.Get<WheatPorridgeItem>().UILink(), 3, typeof(CampfireCreationsSpeedSkill)); 
            this.Initialize("Wheat Porridge", typeof(WheatPorridgeRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}