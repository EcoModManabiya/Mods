namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    public partial class MYTurkeyEggRecipe : Recipe
    {
        public MYTurkeyEggRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYEggItem>(1),  
                new CraftingElement<MYTurkeyAnimalItem>(1), 
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYTurkeyAnimalItem>(1), 
                new CraftingElement<MYTurkeyBaitItem>(typeof(SmallButcheryEfficiencySkill), 5, SmallButcheryEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYTurkeyEggRecipe), Item.Get<MYEggItem>().UILink(), 120, typeof(SmallButcherySpeedSkill));    
            this.Initialize("Turkey Egg", typeof(MYTurkeyEggRecipe));

            CraftingComponent.AddRecipe(typeof(MYTurkeyHouseObject), this);
        }
    }
}