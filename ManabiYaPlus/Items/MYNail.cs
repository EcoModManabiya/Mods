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
    
    [RequiresSkill(typeof(MetalworkingSkill), 1)]   
    public partial class MYNailRecipe : Recipe
    {
        public MYNailRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYNailItem>(10),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(MetalworkingEfficiencySkill), 5, MetalworkingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYNailRecipe), Item.Get<MYNailItem>().UILink(), 2.5f, typeof(MetalworkingSpeedSkill));    
            this.Initialize("Nail", typeof(MYNailRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }


    [Serialized]
    [Weight(10)]      
    [Currency]              
    public partial class MYNailItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Nail"; } } 
        public override string FriendlyNamePlural { get { return "Nail"; } } 
        public override string Description { get { return "Oh! I have run a nail into my foot."; } }

    }

}