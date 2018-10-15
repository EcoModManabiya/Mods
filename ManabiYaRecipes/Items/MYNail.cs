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
    
    [RequiresSkill(typeof(BasicSmeltingSkill), 2)]   
    public partial class MYNailRecipe : Recipe
    {
        public MYNailRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYNailItem>(5),  
                new CraftingElement<TailingsItem>(typeof(BasicSmeltingEfficiencySkill), 1, BasicSmeltingEfficiencySkill.MultiplicativeStrategy),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(BasicSmeltingEfficiencySkill), 5, BasicSmeltingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYNailRecipe), Item.Get<MYNailItem>().UILink(), 4, typeof(BasicSmeltingSpeedSkill));    
            this.Initialize("Nail", typeof(MYNailRecipe));

            CraftingComponent.AddRecipe(typeof(BloomeryObject), this);
        }
    }


    [Serialized]
    [Weight(50)]      
    [Fuel(100)]          
    [Currency]              
    public partial class MYNailItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Wooden Bowl"; } } 
        public override string Description { get { return "It is tableware with the depth in heaviness to serve boiled rice and soup, noodles dish."; } }

    }

}