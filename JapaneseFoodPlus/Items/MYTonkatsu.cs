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
    public partial class MYTonkatsuItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Tonkatsu"; } }
        public override string Description                      { get { return "The pork cutlet is the dish which I let you wear wheat flour, a beaten egg, bread crumbs, and fried the slice meat of sirloin and the fin of the pig with the thickness in edible oil."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 13, Fat = 30, Protein = 20, Vitamins = 5};
        public override float Calories                          { get { return 418; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYHeatOfTheOilSkill), 2)]    
    public partial class MYTonkatsuRecipe : Recipe
    {
        public MYTonkatsuRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYTonkatsuItem>(),
                new CraftingElement<MYWoodenBowlItem>(typeof(MillProcessingEfficiencySkill), 15, MillProcessingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<MYWoodenBowlItem>(typeof(MYHeatOfTheOilEfficiencySkill), 40, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GarbageItem>(typeof(MYHeatOfTheOilEfficiencySkill), 1, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PrimeCutItem>(typeof(MYHeatOfTheOilEfficiencySkill), 5, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<FlourItem>(typeof(MillProcessingEfficiencySkill), 15, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYMisoItem>(typeof(MYHeatOfTheOilEfficiencySkill), 10, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(MYHeatOfTheOilEfficiencySkill), 10, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<OilItem>(typeof(MYHeatOfTheOilEfficiencySkill), 20, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYTonkatsuRecipe), Item.Get<MYTonkatsuItem>().UILink(), 20, typeof(MYHeatOfTheOilSpeedSkill)); 
            this.Initialize("Tonkatsu", typeof(MYTonkatsuRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}