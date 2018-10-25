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
    [RequiresSkill(typeof(PetrolRefiningEfficiencySkill), 0)]   
    public partial class MYUsedBarrelBlock :
        PickupableBlock      
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(MYUsedBarrelItem); } }    
    }

    [Serialized]
    [MaxStackSize(10)]                                       
    [Weight(2000)]      
    [Currency]              
    public partial class MYUsedBarrelItem :
    BlockItem<MYUsedBarrelBlock>
    {
        public override string FriendlyName { get { return "Used Barrel"; } } 
        public override string Description { get { return "To reuse it you have to wash it."; } }

    }

}