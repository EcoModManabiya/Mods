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
    
    [RequiresModule(typeof(MYStockPotObject))]          
    [RequiresSkill(typeof(MYGoldenProportionOfBoildSkill), 2)]    
    public partial class MYBoiledTroutSoySauceRecipe : Recipe
    {
        public MYBoiledTroutSoySauceRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYBoiledFishItem>(),
                new CraftingElement<GarbageItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 1, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TroutItem>(1), 
                new CraftingElement<MYSoySauceItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYBoiledTroutSoySauceRecipe), Item.Get<MYBoiledFishItem>().UILink(), 15, typeof(MYGoldenProportionOfBoildSpeedSkill)); 
            this.Initialize("Boiled Trout Soy Sauce", typeof(MYBoiledTroutSoySauceRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}