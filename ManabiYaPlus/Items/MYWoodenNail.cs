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
    public partial class MYWoodenNailRecipe : Recipe
    {
        public MYWoodenNailRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYWoodenNailItem>(10),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(typeof(WoodworkingEfficiencySkill), 5, WoodworkingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYWoodenNailRecipe), Item.Get<MYWoodenNailItem>().UILink(), 0.5f, typeof(WoodworkingSpeedSkill));    
            this.Initialize("Wooden Nail", typeof(MYWoodenNailRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }


    [Serialized]
    [Weight(250)]      
    [Currency]              
    public partial class MYWoodenNailItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Wooden Nail"; } } 
        public override string Description { get { return ""; } }

    }

}