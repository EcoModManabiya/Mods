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
    [Weight(200)]                                          
    public partial class SimpleSyrupItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Simple Syrup"; } }
        public override string Description                      { get { return "A simple water and suger combination heated until the sugar dissolves."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 12, Fat = 3, Protein = 0, Vitamins = 0};
        public override float Calories                          { get { return 400; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYStockPotObject))]          
    [RequiresSkill(typeof(CulinaryArtsSkill), 2)]    
    public partial class SimpleSyrupRecipe : Recipe
    {
        public SimpleSyrupRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SimpleSyrupItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SugarItem>(typeof(CulinaryArtsEfficiencySkill), 20, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SimpleSyrupRecipe), Item.Get<SimpleSyrupItem>().UILink(), 5, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Simple Syrup", typeof(SimpleSyrupRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}