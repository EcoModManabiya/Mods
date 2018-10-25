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
    using Eco.Gameplay.Pipes.LiquidComponents; 

    [RequiresSkill(typeof(MYReusingSkill), 2)]   
    public partial class MYWashedBarrelRecipe : Recipe
    {
        public MYWashedBarrelRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BarrelItem>(5),          
                new CraftingElement<MYWasteLiquorsBarrelItem>(typeof(MYReusingEfficiencySkill), 5, MYReusingEfficiencySkill.MultiplicativeStrategy),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYUsedBarrelItem>(5), 
                new CraftingElement<MYUsedBarrelItem>(typeof(MYReusingEfficiencySkill), 5, MYReusingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYDetergentsItem>(typeof(MYReusingEfficiencySkill), 5, MYReusingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYWashedBarrelRecipe), Item.Get<BarrelItem>().UILink(), 10, typeof(MYReusingSpeedSkill));    
            this.Initialize("Washed Barrel", typeof(MYWashedBarrelRecipe));

            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }
    }
}