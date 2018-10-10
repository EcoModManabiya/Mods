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
    
    [RequiresSkill(typeof(HomeCookingSkill), 1)]    
    public partial class MYGrilledSalmonRecipe : Recipe
    {
        public MYGrilledSalmonRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYGrilledFishItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SalmonItem>(1), 
                new CraftingElement<MYSaltItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYGrilledSalmonRecipe), Item.Get<MYGrilledFishItem>().UILink(), 30, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Grilled Salmon", typeof(MYGrilledSalmonRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}