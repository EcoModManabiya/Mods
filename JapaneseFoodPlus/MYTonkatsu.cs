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

        private static Nutrients nutrition = new Nutrients()    { Carbs = 13, Fat = 47, Protein = 31, Vitamins = 3};
        public override float Calories                          { get { return 1800; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 4)]    
    public partial class MYTonkatsuRecipe : Recipe
    {
        public MYTonkatsuRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYTonkatsuItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PrimeCutItem>(typeof(HomeCookingEfficiencySkill), 5, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<FlourItem>(typeof(MillProcessingEfficiencySkill), 15, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYMisoItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<OilItem>(typeof(HomeCookingEfficiencySkill), 20, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYTonkatsuRecipe), Item.Get<MYTonkatsuItem>().UILink(), 30, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Tonkatsu", typeof(MYTonkatsuRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}