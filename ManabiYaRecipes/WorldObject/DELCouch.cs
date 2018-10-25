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
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class CouchObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Couch"; } } 

        public virtual Type RepresentedItemType { get { return typeof(CouchItem); } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Housing");                                 
            this.GetComponent<HousingComponent>().Set(CouchItem.HousingVal);                                


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class CouchItem :
        WorldObjectItem<CouchObject> 
    {
        public override string FriendlyName { get { return "Couch"; } } 
        public override string Description  { get { return  "A sweet couch to lounge on. Now with room for your friends!"; } }

        static CouchItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 3,                                   
                                                    TypeForRoomLimit = "Seating", 
                                                    DiminishingReturnPercent = 0.6f    
        };}}
        
    }


    [RequiresSkill(typeof(ClothProductionSkill), 4)]
    public partial class CouchRecipe : Recipe
    {
        public CouchRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CouchItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(ClothProductionEfficiencySkill), 10, ClothProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BoardItem>(typeof(ClothProductionEfficiencySkill), 20, ClothProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ClothItem>(typeof(ClothProductionEfficiencySkill), 20, ClothProductionEfficiencySkill.MultiplicativeStrategy),   
                new CraftingElement<MYNailItem>(typeof(ClothProductionEfficiencySkill), 20, ClothProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            SkillModifiedValue value = new SkillModifiedValue(5, ClothProductionSpeedSkill.MultiplicativeStrategy, typeof(ClothProductionSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(CouchRecipe), Item.Get<CouchItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<CouchItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Couch", typeof(CouchRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
}