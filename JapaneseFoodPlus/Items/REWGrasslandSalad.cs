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

    [RequiresModule(typeof(MYCuttingBoardObject))]          
    [RequiresSkill(typeof(HomeCookingSkill), 1)] 
    public class GrasslandSaladRecipe : Recipe
    {
        public GrasslandSaladRecipe()
        {
            this.Products = new CraftingElement[]
            {

               new CraftingElement<BasicSaladItem>(1f),
               new CraftingElement<GarbageItem>(typeof(HomeCookingEfficiencySkill), 1, HomeCookingEfficiencySkill.MultiplicativeStrategy),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CornItem>(typeof(HomeCookingEfficiencySkill), 15, HomeCookingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<TomatoItem>(typeof(HomeCookingEfficiencySkill), 15, HomeCookingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BeetItem>(typeof(HomeCookingEfficiencySkill), 15, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.Initialize("Grassland Salad", typeof(GrasslandSaladRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(GrasslandSaladRecipe), this.UILink(), 2, typeof(HomeCookingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}