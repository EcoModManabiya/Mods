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
    public partial class MYWoodenPlateRecipe : Recipe
    {
        public MYWoodenPlateRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYWoodenPlateItem>(2),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYWoodenPlateRecipe), Item.Get<MYWoodenPlateItem>().UILink(), 0.5f, typeof(WoodworkingSpeedSkill));    
            this.Initialize("Wooden Plate", typeof(MYWoodenPlateRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }


    [Serialized]
    [Weight(50)]      
    [Fuel(100)]          
    [Currency]              
    public partial class MYWoodenPlateItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Wooden Plate"; } } 
        public override string FriendlyNamePlural { get { return "Wooden Plate"; } } 
        public override string Description { get { return "A flat, shallow container to serve foods."; } }

    }

}