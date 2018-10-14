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
    public partial class MYTempuraItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Tempura"; } }
        public override string Description                      { get { return "It is Japanese food that the tempura fries the ingredients such as fishery products or vegetables in a parcel, oil with clothes mainly composed of the wheat flour and cooks."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 21, Fat = 24, Protein = 13, Vitamins = 6};
        public override float Calories                          { get { return 354; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYHeatOfTheOilSkill), 4)]    
    public partial class MYTempuraRecipe : Recipe
    {
        public MYTempuraRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYTempuraItem>(),
                new CraftingElement<GarbageItem>(typeof(MYHeatOfTheOilEfficiencySkill), 2, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FireweedShootsItem>(typeof(MYHeatOfTheOilEfficiencySkill), 10, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<CriminiMushroomsItem>(typeof(MYHeatOfTheOilEfficiencySkill), 10, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<RawFishItem>(typeof(MYHeatOfTheOilEfficiencySkill), 10, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<FlourItem>(typeof(MillProcessingEfficiencySkill), 15, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSaltItem>(typeof(MYHeatOfTheOilEfficiencySkill), 10, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<OilItem>(typeof(MYHeatOfTheOilEfficiencySkill), 20, MYHeatOfTheOilEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<PaperItem>(1), 
                new CraftingElement<MYWoodenPlatterItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYTempuraRecipe), Item.Get<MYTempuraItem>().UILink(), 30, typeof(MYHeatOfTheOilSpeedSkill)); 
            this.Initialize("Tempura", typeof(MYTempuraRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}