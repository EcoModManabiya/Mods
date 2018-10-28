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

    [RequiresSkill(typeof(SmallButcherySkill), 0)] 
    public partial class MYButcherChickRecipe : Recipe
    {
        public MYButcherChickRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RawMeatItem>(1),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYTurkeyChickItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYButcherChickRecipe), Item.Get<RawMeatItem>().UILink(), 1, typeof(SmallButcherySpeedSkill));    
            this.Initialize("Butcher Chick", typeof(MYButcherChickRecipe));

            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }

    [RequiresSkill(typeof(SmallButcherySkill), 1)] 
    public partial class MYButcherTurkeyRecipe : Recipe
    {
        public MYButcherTurkeyRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RawMeatItem>(2f),
                new CraftingElement<LeatherHideItem>(1f),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYTurkeyAnimalItem>(1), 
            };
            this.Initialize("Butcher Turkey", typeof(MYButcherTurkeyRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYButcherTurkeyRecipe), this.UILink(), 1, typeof(SmallButcherySpeedSkill));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}