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
    public partial class MYFriedChickenItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Fried Chicken"; } }
        public override string Description                      { get { return "I covered chicken with wheat flour or dogtooth violet starch thinly and fried it in oil."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 3, Fat = 24, Protein = 14, Vitamins = 1};
        public override float Calories                          { get { return 1200; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 2)]    
    public partial class MYFriedChickenRecipe : Recipe
    {
        public MYFriedChickenRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYFriedChickenItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawMeatItem>(typeof(HomeCookingEfficiencySkill), 15, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<FlourItem>(typeof(MillProcessingEfficiencySkill), 15, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSaltItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<OilItem>(typeof(HomeCookingEfficiencySkill), 20, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYFriedChickenRecipe), Item.Get<MYFriedChickenItem>().UILink(), 30, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Fried Chicken", typeof(MYFriedChickenRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}