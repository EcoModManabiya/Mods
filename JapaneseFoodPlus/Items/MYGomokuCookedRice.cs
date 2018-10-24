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
        public override string Description                      { get { return "A rice meal that is it cooked. Ingredients and rice cooked together."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 68, Fat = 5, Protein = 11, Vitamins = 2};
        public override float Calories                          { get { return 386; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYStockPotObject))]          
    [RequiresSkill(typeof(MYGoldenProportionOfBoildSkill), 4)]    
    public partial class MYGomokuCookedRiceRecipe : Recipe
    {
        public MYGomokuCookedRiceRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYGomokuCookedRiceItem>(),
                new CraftingElement<MYWoodenBowlItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 5, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GarbageItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 3, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RiceItem>(20),
                new CraftingElement<MYSoySauceItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 5, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<PreparedMeatItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 8, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<FiddleheadsItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 8, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<FireweedShootsItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 8, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<CriminiMushroomsItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 8, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<BeansItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 8, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYGomokuCookedRiceRecipe), Item.Get<MYGomokuCookedRiceItem>().UILink(), 30, typeof(MYGoldenProportionOfBoildSpeedSkill)); 
            this.Initialize("Gomoku Cooked Rice", typeof(MYGomokuCookedRiceRecipe));
            CraftingComponent.AddRecipe(typeof(MYMortarOvenObject), this);
        }
    }
}