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

    [RequiresSkill(typeof(LumberSkill), 1)]   
    public partial class MYLumberRecipe : Recipe
    {
        public MYLumberRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(),          

            new CraftingElement<WoodPulpItem>(3),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYWoodenNailItem>(typeof(LumberProcessingEfficiencySkill), 10, LumberProcessingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<LogItem>(typeof(LumberProcessingEfficiencySkill), 10, LumberProcessingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYLumberRecipe), Item.Get<LumberItem>().UILink(), 1, typeof(LumberProcessingSpeedSkill));    
            this.Initialize("Lumber", typeof(MYLumberRecipe));

            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}