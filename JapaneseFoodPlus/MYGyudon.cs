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
    public partial class MYGyudonItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Gyudon"; } }
        public override string Description                      { get { return "It is salty-sweet and stews beef and the onion which I sliced with soy sauce, and a beef bowl is the dish which I picked up on the meal which I served in a bowl."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 105, Fat = 20, Protein = 22, Vitamins = 5};
        public override float Calories                          { get { return 735; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYGoldenProportionOfBoildSkill), 4)]    
    public partial class MYGyudonRecipe : Recipe
    {
        public MYGyudonRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYGyudonItem>(),
                new CraftingElement<GarbageItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 2, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RiceItem>(20), 
                new CraftingElement<ScrapMeatItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 30, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYGyudonRecipe), Item.Get<MYGyudonItem>().UILink(), 20, typeof(MYGoldenProportionOfBoildSpeedSkill)); 
            this.Initialize("Gyudon", typeof(MYGyudonRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}