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
    [RequiresSkill(typeof(HomeCookingSkill), 2)] 
    public class MixedFruitSaladRecipe : Recipe
    {
        public MixedFruitSaladRecipe()
        {
            this.Products = new CraftingElement[]
            {

               new CraftingElement<FruitSaladItem>(1f),
               new CraftingElement<GarbageItem>(typeof(HomeCookingEfficiencySkill), 1, HomeCookingEfficiencySkill.MultiplicativeStrategy),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HuckleberriesItem>(typeof(HomeCookingEfficiencySkill), 40, HomeCookingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BeetItem>(typeof(HomeCookingEfficiencySkill), 20, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.Initialize("Mixed Fruit Salad", typeof(MixedFruitSaladRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MixedFruitSaladRecipe), this.UILink(), 2, typeof(HomeCookingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}