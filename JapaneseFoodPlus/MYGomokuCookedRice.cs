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
    public partial class MYGomokuCookedRiceItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Gomoku Cooked Rice"; } }
        public override string Description                      { get { return "When I cook rice, it is a meal to cook an ingredient with rice, and to cook."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 7, Fat = 2, Protein = 1, Vitamins = 2};
        public override float Calories                          { get { return 1000; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 2)]    
    public partial class MYGomokuCookedRiceRecipe : Recipe
    {
        public MYGomokuCookedRiceRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYGomokuCookedRiceItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RiceItem>(20),
                new CraftingElement<MYSoySauceItem>(typeof(HomeCookingEfficiencySkill), 5, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<PreparedMeatItem>(typeof(HomeCookingEfficiencySkill), 8, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<FiddleheadsItem>(typeof(HomeCookingEfficiencySkill), 8, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<FireweedShootsItem>(typeof(HomeCookingEfficiencySkill), 8, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<CriminiMushroomsItem>(typeof(HomeCookingEfficiencySkill), 8, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<BeansItem>(typeof(HomeCookingEfficiencySkill), 8, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYGomokuCookedRiceRecipe), Item.Get<MYGomokuCookedRiceItem>().UILink(), 20, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Gomoku Cooked Rice", typeof(MYGomokuCookedRiceRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}