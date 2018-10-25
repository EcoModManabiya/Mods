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
        public override string Description                      { get { return "A dish that is made with beefs and sliced onions by seasoning soy souce it is serve by bowl that putting the beefs on the top of the rice."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 105, Fat = 20, Protein = 22, Vitamins = 5};
        public override float Calories                          { get { return 735; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYStockPotObject))]          
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
                new CraftingElement<RiceItem>(typeof(MYRiceCookingEfficiencySkill), 100, MYRiceCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<ScrapMeatItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 30, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYGyudonRecipe), Item.Get<MYGyudonItem>().UILink(), 10, typeof(MYGoldenProportionOfBoildSpeedSkill)); 
            this.Initialize("Gyudon", typeof(MYGyudonRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}