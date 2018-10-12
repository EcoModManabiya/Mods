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
    
    [RequiresSkill(typeof(StoneworkingSkill), 3)]    
    public partial class MYRockSaltRecipe : Recipe
    {
        public MYRockSaltRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYSaltItem>(10),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StoneItem>(typeof(StoneworkingEfficiencySkill), 20, StoneworkingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYRockSaltRecipe), Item.Get<MYSaltItem>().UILink(), 60, typeof(StoneworkingSpeedSkill)); 
            this.Initialize("Rock Salt", typeof(MYRockSaltRecipe));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
}