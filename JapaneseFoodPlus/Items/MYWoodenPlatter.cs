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
    
    [RequiresSkill(typeof(WoodworkingSkill), 1)]   
    public partial class MYWoodenPlatterRecipe : Recipe
    {
        public MYWoodenPlatterRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYWoodenPlatterItem>(2),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYWoodenPlatterRecipe), Item.Get<MYWoodenPlatterItem>().UILink(), 0.5f, typeof(WoodworkingSpeedSkill));    
            this.Initialize("Wooden Platter", typeof(MYWoodenPlatterRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }


    [Serialized]
    [Weight(50)]      
    [Fuel(100)]          
    [Currency]              
    public partial class MYWoodenPlatterItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Wooden Platter"; } } 
        public override string Description { get { return "A flat, shallow container to serve food in."; } }

    }

}