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
    public partial class MYUdonNoodlesItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Udon Noodles"; } }
        public override string Description                      { get { return "Noodles having some width and thickness that the udon kneads wheat flour and was under for a long time or the dish."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 61, Fat = 1, Protein = 9, Vitamins = 1};
        public override float Calories                          { get { return 309; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYGoldenProportionOfBoildSkill), 3)]    
    public partial class MYUdonNoodlesRecipe : Recipe
    {
        public MYUdonNoodlesRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYUdonNoodlesItem>(),
                new CraftingElement<GarbageItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 1, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FlourItem>(typeof(MillProcessingEfficiencySkill), 30, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYUdonNoodlesRecipe), Item.Get<MYUdonNoodlesItem>().UILink(), 30, typeof(MYGoldenProportionOfBoildSpeedSkill)); 
            this.Initialize("Udon Noodles", typeof(MYUdonNoodlesRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}