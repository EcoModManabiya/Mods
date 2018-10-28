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
    [RequireComponent(typeof(PipeComponent))]                    
    [RequireComponent(typeof(AttachmentComponent))]              
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(CraftingComponent))]               
    [RequireComponent(typeof(PowerGridComponent))]              
    [RequireComponent(typeof(PowerConsumptionComponent))]                     
    [RequireComponent(typeof(FuelSupplyComponent))]                      
    [RequireComponent(typeof(FuelConsumptionComponent))]                 
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class MYRecycleFurnaceObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Recycle Furnace"; } } 

        public virtual Type RepresentedItemType { get { return typeof(MYRecycleFurnaceItem); } } 

        private static Type[] fuelTypeList = new Type[]
        {
            typeof(TailingsItem),
        };

        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Crafting");                                 
            this.GetComponent<FuelSupplyComponent>().Initialize(1, fuelTypeList);                           
            this.GetComponent<FuelConsumptionComponent>().Initialize(100);                    
            this.GetComponent<PowerConsumptionComponent>().Initialize(100);                      
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());        
            this.GetComponent<HousingComponent>().Set(MYRecycleFurnaceItem.HousingVal);                                

            var tankList = new List<LiquidTank>();
            
            tankList.Add(new LiquidProducer("Chimney", typeof(SmogItem), 200,
                    null,                                                                
                    this.Occupancy.Find(x => x.Name == "ChimneyOut"),   
                        (float)(1 * SmogItem.SmogItemsPerCO2PPM) / TimeUtil.SecondsPerHour)); 
            
            
            
            this.GetComponent<PipeComponent>().Initialize(tankList);

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class MYRecycleFurnaceItem :
        WorldObjectItem<MYRecycleFurnaceObject> 
    {
        public override string FriendlyName { get { return "Recycle Furnace"; } } 
        public override string Description  { get { return  "An excellent furnace to reduce pollution."; } }

        static MYRecycleFurnaceItem()
        {
            
            
            
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Industrial",
                                                    TypeForRoomLimit = "", 
        };}}
        
        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(100))); } } 
    }


    [RequiresSkill(typeof(IndustrialEngineeringSkill), 4)]
    public partial class MYRecycleFurnaceRecipe : Recipe
    {
        public MYRecycleFurnaceRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYRecycleFurnaceItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ReinforcedConcreteItem>(typeof(IndustrialEngineeringEfficiencySkill), 10, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SteelPlateItem>(typeof(IndustrialEngineeringEfficiencySkill), 20, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ScrewsItem>(typeof(IndustrialEngineeringEfficiencySkill), 20, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<IronPipeItem>(typeof(IndustrialEngineeringEfficiencySkill), 10, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(60, IndustrialEngineeringSpeedSkill.MultiplicativeStrategy, typeof(IndustrialEngineeringSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(MYRecycleFurnaceRecipe), Item.Get<MYRecycleFurnaceItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<MYRecycleFurnaceItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Recycle Furnace", typeof(MYRecycleFurnaceRecipe));
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
}