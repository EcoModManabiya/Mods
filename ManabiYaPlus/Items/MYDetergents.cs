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
    [RequireComponent(typeof (PropertyAuthComponent))]
    [RequireComponent(typeof (SolidGroundComponent))]            
    public partial class MYDetergentsObject :
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Detergents"; } } 

        public virtual Type RepresentedItemType { get { return typeof(MYDetergentsItem); } } 


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
    [Currency]              
    public partial class MYDetergentsItem :
    WorldObjectItem<MYDetergentsObject>
    {
        public override string FriendlyName { get { return "Detergents"; } } 
        public override string FriendlyNamePlural { get { return "Detergents"; } } 
        public override string Description { get { return "This oil engine will drop hazardous waste. Be careful to properly dispose of it."; } }

    }

}