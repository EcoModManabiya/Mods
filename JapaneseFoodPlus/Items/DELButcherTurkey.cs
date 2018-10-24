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

    [RequiresSkill(typeof(SmallButcherySkill), 1)] 
    public class ButcherTurkeyRecipe : Recipe
    {
        public ButcherTurkeyRecipe()
        {
            this.Products = new CraftingElement[]
            {

               new CraftingElement<RawMeatItem>(2f),
               new CraftingElement<LeatherHideItem>(1f),
               new CraftingElement<MYEggItem>(1f),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TurkeyCarcassItem>(typeof(SmallButcheryEfficiencySkill), 1, SmallButcheryEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Butcher Turkey", typeof(ButcherTurkeyRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ButcherTurkeyRecipe), this.UILink(), 1, typeof(SmallButcherySpeedSkill));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}