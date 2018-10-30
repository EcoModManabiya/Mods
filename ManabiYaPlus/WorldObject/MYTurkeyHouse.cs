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
	[RequireComponent(typeof(AttachmentComponent))]    
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(CraftingComponent))]               
    [RequireComponent(typeof(SolidGroundComponent))]            
	public partial class MYTurkeyHouseObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Turkey House"; } } 

        public virtual Type RepresentedItemType { get { return typeof(MYTurkeyHouseItem); } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Crafting");                                 
			((PublicStorageComponent) this.GetComponent<PublicStorageComponent>()).Initialize(2);

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class MYTurkeyHouseItem :
        WorldObjectItem<MYTurkeyHouseObject> 
    {
        public override string FriendlyName { get { return "Turkey House"; } } 
        public override string Description  { get { return  ""; } }

        static MYTurkeyHouseItem()
        {
            
        }

        
    }

    [RequiresSkill(typeof(LumberWoodworkingSkill), 1)]   
    public partial class MYTurkeyHouseRecipe : Recipe
    {
        public MYTurkeyHouseRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYTurkeyHouseItem>(),          

			};
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(LumberProcessingEfficiencySkill), 10, LumberProcessingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<BoardItem>(typeof(LumberProcessingEfficiencySkill), 30, LumberProcessingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYTurkeyHouseRecipe), Item.Get<MYTurkeyHouseItem>().UILink(), 30, typeof(LumberProcessingSpeedSkill));    
            this.Initialize("Turkey House", typeof(MYTurkeyHouseRecipe));

            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}