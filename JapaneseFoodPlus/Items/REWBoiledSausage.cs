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
    [Weight(300)]                                          
    public partial class BoiledSausageItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Boiled Sausage"; } }
        public override string Description                      { get { return "Boiled sausages might not be as pretty as grilled ones, but they're still tasty."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 22, Protein = 27, Vitamins = 0};
        public override float Calories                          { get { return 600; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYStockPotObject))]          
    [RequiresSkill(typeof(CulinaryArtsSkill), 3)]    
    public partial class BoiledSausageRecipe : Recipe
    {
        public BoiledSausageRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BoiledSausageItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawSausageItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<MeatStockItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BoiledSausageRecipe), Item.Get<BoiledSausageItem>().UILink(), 10, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Boiled Sausage", typeof(BoiledSausageRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}