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
    [Weight(150)]                                          
    public partial class MYFriedChickenItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Fried Chicken"; } }
        public override string Description                      { get { return "I covered chicken with wheat flour or dogtooth violet starch thinly and fried it in oil."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 13, Fat = 16, Protein = 15, Vitamins = 4};
        public override float Calories                          { get { return 274; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYHeatOfTheOilSkill), 1)]    
    public partial class MYFriedChickenRecipe : Recipe
    {
        public MYFriedChickenRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYFriedChickenItem>(),
                new CraftingElement<GarbageItem>(typeof(MYHeatOfTheOilEfficiencySkill), 1, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawMeatItem>(typeof(MYHeatOfTheOilEfficiencySkill), 15, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<FlourItem>(typeof(MillProcessingEfficiencySkill), 15, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSaltItem>(typeof(MYHeatOfTheOilEfficiencySkill), 10, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<OilItem>(typeof(MYHeatOfTheOilEfficiencySkill), 20, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlatterItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYFriedChickenRecipe), Item.Get<MYFriedChickenItem>().UILink(), 30, typeof(MYHeatOfTheOilSpeedSkill)); 
            this.Initialize("Fried Chicken", typeof(MYFriedChickenRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}