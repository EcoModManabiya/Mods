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
    using Eco.Gameplay.Pipes.LiquidComponents; 

    [RequiresSkill(typeof(PetrolRefiningSkill), 3)]   
    public partial class MYDetergentsRecipe : Recipe
    {
        public MYDetergentsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYDetergentsItem>(),          
                new CraftingElement<MYUsedBarrelItem>(typeof(PetrolRefiningEfficiencySkill), 5, PetrolRefiningEfficiencySkill.MultiplicativeStrategy),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYBioethanolItem>(typeof(PetrolRefiningEfficiencySkill), 5, PetrolRefiningEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<OilItem>(typeof(PetrolRefiningEfficiencySkill), 5, PetrolRefiningEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<BarrelItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYDetergentsRecipe), Item.Get<MYDetergentsItem>().UILink(), 5, typeof(PetrolRefiningSpeedSkill));    
            this.Initialize("Detergents", typeof(MYDetergentsRecipe));

            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }
    }

    [Serialized]
    [Solid]
    [RequiresSkill(typeof(PetrolRefiningEfficiencySkill), 3)]   
    public partial class DetergentsBlock :
        PickupableBlock      
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(MYDetergentsItem); } }    
    }

    [Serialized]
    [MaxStackSize(10)]                                       
    [Weight(30000)]      
    [Currency]              
    public partial class MYDetergentsItem :
    BlockItem<DetergentsBlock>
    {
        public override string FriendlyName { get { return "Detergents"; } } 
        public override string FriendlyNamePlural { get { return "Detergents"; } } 
        public override string Description { get { return ""; } }

    }

}