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
    [Weight(800)]                                          
    public partial class MeatStockItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Meat Stock"; } }
        public override string Description                      { get { return "A meaty stock made from the flesh of animals."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 5, Fat = 9, Protein = 8, Vitamins = 3};
        public override float Calories                          { get { return 700; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYStockPotObject))]          
    [RequiresSkill(typeof(HomeCookingSkill), 2)]    
    public partial class MeatStockRecipe : Recipe
    {
        public MeatStockRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MeatStockItem>(),
                new CraftingElement<GarbageItem>(typeof(HomeCookingEfficiencySkill), 1, HomeCookingEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ScrapMeatItem>(typeof(HomeCookingEfficiencySkill), 20, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MeatStockRecipe), Item.Get<MeatStockItem>().UILink(), 20, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Meat Stock", typeof(MeatStockRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}