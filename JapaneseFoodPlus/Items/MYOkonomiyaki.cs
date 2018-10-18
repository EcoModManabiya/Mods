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
    public partial class MYOkonomiyakiItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Okonomiyaki"; } }
        public override string Description                      { get { return "It is a kind of the grilling foods on an iron plate to use wheat flour and cabbage."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 46, Fat = 30, Protein = 19, Vitamins = 47};
        public override float Calories                          { get { return 545; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYCharcoalGrillSkill), 3)]    
    public partial class MYOkonomiyakiRecipe : Recipe
    {
        public MYOkonomiyakiRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYOkonomiyakiItem>(),
                new CraftingElement<MYWoodenBowlItem>(typeof(MYCharcoalGrillEfficiencySkill), 40, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<MYWoodenBowlItem>(typeof(MillProcessingEfficiencySkill), 15, MillProcessingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GarbageItem>(typeof(MYCharcoalGrillEfficiencySkill), 2, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYEggItem>(typeof(MYCharcoalGrillEfficiencySkill), 10, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<ScrapMeatItem>(typeof(MYCharcoalGrillEfficiencySkill), 30, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<VegetableMedleyItem>(typeof(MYCharcoalGrillEfficiencySkill), 30, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<FlourItem>(typeof(MillProcessingEfficiencySkill), 15, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<OilItem>(typeof(MYCharcoalGrillEfficiencySkill), 10, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlatterItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYOkonomiyakiRecipe), Item.Get<MYOkonomiyakiItem>().UILink(), 20, typeof(MYCharcoalGrillSpeedSkill)); 
            this.Initialize("Okonomiyaki", typeof(MYOkonomiyakiRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}