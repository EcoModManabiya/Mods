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
    public partial class MYBuridaikonItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Buridaikon"; } }
        public override string Description                      { get { return "A Japaneseee dish called Buri-daikon is made with amberfish called buri and Japanese radish called daikon it is flavored by soy sauce."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 11, Fat = 11, Protein = 15, Vitamins = 12};
        public override float Calories                          { get { return 211; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYStockPotObject))]          
    [RequiresSkill(typeof(MYGoldenProportionOfBoildSkill), 3)]    
    public partial class MYBuridaikonRecipe : Recipe
    {
        public MYBuridaikonRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYBuridaikonItem>(),
                new CraftingElement<GarbageItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 1, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawFishItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<BeetItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYBuridaikonRecipe), Item.Get<MYBuridaikonItem>().UILink(), 15, typeof(MYGoldenProportionOfBoildSpeedSkill)); 
            this.Initialize("Buridaikon", typeof(MYBuridaikonRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}