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
    public partial class MYWienerSchnitzelItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Wiener Schnitzel"; } }
        public override string Description                      { get { return "Viennese cuisine in Austria."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 9, Fat = 28, Protein = 28, Vitamins = 3};
        public override float Calories                          { get { return 414; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYHeatOfTheOilSkill), 2)]    
    public partial class MYWienerSchnitzelRecipe : Recipe
    {
        public MYWienerSchnitzelRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYWienerSchnitzelItem>(),
                new CraftingElement<MYWoodenBowlItem>(typeof(MillProcessingEfficiencySkill), 15, MillProcessingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<MYWoodenBowlItem>(typeof(MYHeatOfTheOilEfficiencySkill), 30, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GarbageItem>(typeof(MYHeatOfTheOilEfficiencySkill), 1, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawMeatItem>(typeof(MYHeatOfTheOilEfficiencySkill), 15, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<FlourItem>(typeof(MillProcessingEfficiencySkill), 15, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSaltItem>(typeof(MYHeatOfTheOilEfficiencySkill), 10, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<OilItem>(typeof(MYHeatOfTheOilEfficiencySkill), 20, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYEggItem>(typeof(MYHeatOfTheOilEfficiencySkill), 5, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYWienerSchnitzelRecipe), Item.Get<MYWienerSchnitzelItem>().UILink(), 30, typeof(MYHeatOfTheOilSpeedSkill)); 
            this.Initialize("Wiener Schnitzel", typeof(MYWienerSchnitzelRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}