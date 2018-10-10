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
    public partial class MYOkonomiyakiItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Okonomiyaki"; } }
        public override string Description                      { get { return "It is a kind of the grilling foods on an iron plate to use wheat flour and cabbage."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 73, Fat = 28, Protein = 20, Vitamins = 4};
        public override float Calories                          { get { return 1800; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 1)]    
    public partial class MYOkonomiyakiRecipe : Recipe
    {
        public MYOkonomiyakiRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYOkonomiyakiItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYEggItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<ScrapMeatItem>(typeof(HomeCookingEfficiencySkill), 30, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<VegetableMedleyItem>(typeof(HomeCookingEfficiencySkill), 30, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<FlourItem>(typeof(MillProcessingEfficiencySkill), 15, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<OilItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYOkonomiyakiRecipe), Item.Get<MYOkonomiyakiItem>().UILink(), 20, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Okonomiyaki", typeof(MYOkonomiyakiRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}