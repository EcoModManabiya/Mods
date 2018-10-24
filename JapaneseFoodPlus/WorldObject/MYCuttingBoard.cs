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
    public partial class MYCuttingBoardObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Cutting Board"; } } 

        public virtual Type RepresentedItemType { get { return typeof(MYCuttingBoardItem); } } 


        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(MYCuttingBoardItem.HousingVal);                                


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class MYCuttingBoardItem :
        WorldObjectItem<MYCuttingBoardObject> 
    {
        public override string FriendlyName { get { return "Cutting Board"; } } 
        public override string Description  { get { return  "Rythm of a knife tapping on cutting board."; } }

        static MYCuttingBoardItem()
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


    [RequiresSkill(typeof(WoodworkingSkill), 1)]
    public partial class MYCuttingBoardRecipe : Recipe
    {
        public MYCuttingBoardRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYCuttingBoardItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(WoodworkingEfficiencySkill), 1, WoodworkingEfficiencySkill.MultiplicativeStrategy), 
            };
            SkillModifiedValue value = new SkillModifiedValue(10, WoodworkingSpeedSkill.MultiplicativeStrategy, typeof(WoodworkingSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(MYCuttingBoardRecipe), Item.Get<MYCuttingBoardItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<MYCuttingBoardItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Cutting Board", typeof(MYCuttingBoardRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}