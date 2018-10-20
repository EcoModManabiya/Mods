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
    
    [RequiresSkill(typeof(WoodworkingSkill), 4)]   
    public partial class MYMeasureRecipe : Recipe
    {
        public MYMeasureRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYMeasureItem>(),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYMeasureRecipe), Item.Get<MYMeasureItem>().UILink(), 0.5f, typeof(WoodworkingSpeedSkill));    
            this.Initialize("Measure", typeof(MYMeasureRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }


    [Serialized]
    [Weight(50)]      
    [Fuel(100)]          
    [Currency]              
    public partial class MYMeasureItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Measure"; } } 
        public override string Description { get { return "One of the Japanese traditional measure. Masu is a square made by wood, they use it to measure liquid or grains."; } }

    }

}