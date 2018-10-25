namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;

    [RequiresModule(typeof(MYFlyingPanObject))]          
    [RequiresSkill(typeof(CampfireCreationsSkill), 4)] 
    public class RenderFatRecipe : Recipe
    {
        public RenderFatRecipe()
        {
            this.Products = new CraftingElement[]
            {

               new CraftingElement<TallowItem>(2f),
                new CraftingElement<GarbageItem>(typeof(CampfireCreationsEfficiencySkill), 1, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawMeatItem>(typeof(CampfireCreationsEfficiencySkill), 4, CampfireCreationsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenBowlItem>(2), 
            };
            this.Initialize("Render Fat", typeof(RenderFatRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RenderFatRecipe), this.UILink(), 2, typeof(CampfireCreationsSpeedSkill));
            CraftingComponent.AddRecipe(typeof(MYMortarOvenObject), this);
        }
    }
}