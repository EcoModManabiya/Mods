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
    
    [RequiresSkill(typeof(HomeCookingSkill), 3)]    
    public partial class MYBoiledTroutMisoSauceRecipe : Recipe
    {
        public MYBoiledTroutMisoSauceRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYBoiledFishItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TroutItem>(1), 
                new CraftingElement<MYMisoItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYBoiledTroutMisoSauceRecipe), Item.Get<MYBoiledFishItem>().UILink(), 30, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Boiled Trout Miso Sauce", typeof(MYBoiledTroutMisoSauceRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}