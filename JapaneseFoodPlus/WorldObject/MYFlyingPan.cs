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
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class MYFlyingPanObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Flying Pan"; } } 

        public virtual Type RepresentedItemType { get { return typeof(MYFlyingPanItem); } } 


        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(MYFlyingPanItem.HousingVal);                                


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class MYFlyingPanItem :
        WorldObjectItem<MYFlyingPanObject> 
    {
        public override string FriendlyName { get { return "Flying Pan"; } } 
        public override string Description  { get { return  "The handle of this pan is easy to hold."; } }

        static MYFlyingPanItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Kitchen",
                                                    Val = 0.5f,                                   
                                                    TypeForRoomLimit = "KitchenTools", 
                                                    DiminishingReturnPercent = 0.8f    
        };}}
        
    }


    [RequiresSkill(typeof(MetalworkingSkill), 2)]
    public partial class MYFlyingPanRecipe : Recipe
    {
        public MYFlyingPanRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYFlyingPanItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(MetalworkingEfficiencySkill), 10, MetalworkingEfficiencySkill.MultiplicativeStrategy), 
            };
            SkillModifiedValue value = new SkillModifiedValue(10, MetalworkingSpeedSkill.MultiplicativeStrategy, typeof(MetalworkingSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(MYFlyingPanRecipe), Item.Get<MYFlyingPanItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<MYFlyingPanItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Flying Pan", typeof(MYFlyingPanRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}