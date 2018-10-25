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


    [Serialized]
    [Solid]
    [RequiresSkill(typeof(MYReusingEfficiencySkill), 0)]   
    public partial class MYWasteLiquorsBarrelBlock :
        PickupableBlock      
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(MYWasteLiquorsBarrelItem); } }    
    }

    [Serialized]
    [MaxStackSize(10)]                                       
    [Weight(30000)]      
    [Currency]              
    public partial class MYWasteLiquorsBarrelItem :
    BlockItem<MYWasteLiquorsBarrelBlock>
    {
        public override string FriendlyName { get { return "Waste Liquors Barrel"; } } 
        public override string Description { get { return ""; } }

    }

}