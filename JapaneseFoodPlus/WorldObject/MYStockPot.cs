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
    public partial class MYStockPotObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Stock Pot"; } } 

        public virtual Type RepresentedItemType { get { return typeof(MYStockPotItem); } } 


        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(MYStockPotItem.HousingVal);                                


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class MYStockPotItem :
        WorldObjectItem<MYStockPotObject> 
    {
        public override string FriendlyName { get { return "Stock Pot"; } } 
        public override string Description  { get { return  "Let's cook the dish of many people."; } }

        static MYStockPotItem()
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


    [RequiresSkill(typeof(MetalworkingSkill), 3)]
    public partial class MYStockPotRecipe : Recipe
    {
        public MYStockPotRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYStockPotItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(MetalworkingEfficiencySkill), 20, MetalworkingEfficiencySkill.MultiplicativeStrategy), 
            };
            SkillModifiedValue value = new SkillModifiedValue(10, MetalworkingSpeedSkill.MultiplicativeStrategy, typeof(MetalworkingSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(MYStockPotRecipe), Item.Get<MYStockPotItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<MYStockPotItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Stock Pot", typeof(MYStockPotRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}