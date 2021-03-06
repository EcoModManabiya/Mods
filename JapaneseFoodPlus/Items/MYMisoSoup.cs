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
    public partial class MYMisoSoupItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Miso Soup"; } }
        public override string Description                      { get { return "One of the soup in Japan. It is cooked with many patterns like."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 2, Protein = 4, Vitamins = 0};
        public override float Calories                          { get { return 44; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYStockPotObject))]          
    [RequiresSkill(typeof(MYGoldenProportionOfBoildSkill), 1)]    
    public partial class MYMisoSoupRecipe : Recipe
    {
        public MYMisoSoupRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYMisoSoupItem>(),
                new CraftingElement<MYWoodenBowlItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GarbageItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 1, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYMisoItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 5, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYTofuItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<ClamItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<KelpItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYMisoSoupRecipe), Item.Get<MYMisoSoupItem>().UILink(), 5, typeof(MYGoldenProportionOfBoildSpeedSkill)); 
            this.Initialize("Miso Soup", typeof(MYMisoSoupRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}