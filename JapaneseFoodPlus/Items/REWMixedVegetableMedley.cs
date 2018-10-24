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
    public class MixedVegetableMedleyRecipe : Recipe
    {
        public MixedVegetableMedleyRecipe()
        {
            this.Products = new CraftingElement[]
            {

               new CraftingElement<VegetableMedleyItem>(1f),
               new CraftingElement<GarbageItem>(typeof(HomeCookingEfficiencySkill), 1, HomeCookingEfficiencySkill.MultiplicativeStrategy),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CornItem>(typeof(HomeCookingEfficiencySkill), 15, HomeCookingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CamasBulbItem>(typeof(HomeCookingEfficiencySkill), 15, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.Initialize("Mixed Vegetable Medley", typeof(MixedVegetableMedleyRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MixedVegetableMedleyRecipe), this.UILink(), 2, typeof(HomeCookingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}