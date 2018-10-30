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

    [RequiresSkill(typeof(MYRecyclingSkill), 2)] 
    public class MYCokeRecipe : Recipe
    {
        public MYCokeRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CoalItem>(5),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CoalItem>(typeof(MYRecyclingEfficiencySkill), 5, MYRecyclingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<WoodPulpItem>(typeof(MYRecyclingEfficiencySkill), 100, MYRecyclingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Coke", typeof(MYCokeRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYCokeRecipe), this.UILink(), 10f, typeof(MYRecyclingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(MYCokeFurnaceObject), this);
        }
    }
}