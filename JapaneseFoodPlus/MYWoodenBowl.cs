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
    
    [RequiresSkill(typeof(WoodworkingSkill), 2)]   
    public partial class MYWoodenBowlRecipe : Recipe
    {
        public MYWoodenBowlRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYWoodenBowlItem>(4),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYWoodenBowlRecipe), Item.Get<MYWoodenBowlItem>().UILink(), 1.0f, typeof(WoodworkingSpeedSkill));    
            this.Initialize("Wooden Bowl", typeof(MYWoodenBowlRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }


    [Serialized]
    [Weight(100)]      
    [Fuel(500)]          
    [Currency]              
    public partial class MYWoodenBowlItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Wooden Bowl"; } } 
        public override string Description { get { return "It is tableware with the depth in heaviness to serve boiled rice and soup, noodles dish."; } }

    }

}