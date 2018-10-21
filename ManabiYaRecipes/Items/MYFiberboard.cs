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

    [RequiresSkill(typeof(WoodworkingSkill), 0)]   
    public partial class MYFiberboardRecipe : Recipe
    {
        public MYFiberboardRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(1),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WoodPulpItem>(typeof(WoodworkingEfficiencySkill), 25, WoodworkingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BoardRecipe), Item.Get<BoardItem>().UILink(), 0.5f, typeof(WoodworkingSpeedSkill));    
            this.Initialize("Fiberboard", typeof(MYFiberboardRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}