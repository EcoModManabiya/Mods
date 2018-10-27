namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;

    [Serialized]
    [RequireComponent(typeof (PropertyAuthComponent))]
    [RequireComponent(typeof (SolidGroundComponent))]            
    public partial class MYBioethanolObject :
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Bioethanol"; } } 

        public virtual Type RepresentedItemType { get { return typeof(MYBioethanolItem); } } 


        protected override void Initialize()
        {

        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized]
    [MaxStackSize(10)]                                       
    [Weight(30000)]      
    [Fuel(80000)]          
    [Currency]              
    public partial class MYBioethanolItem :
    WorldObjectItem<MYBioethanolObject>
    {
        public override string FriendlyName { get { return "Bioethanol"; } } 
        public override string FriendlyNamePlural { get { return "Bioethanol"; } } 
        public override string Description { get { return "Bioethanol can be made from things like corn and wheat."; } }

    }

}