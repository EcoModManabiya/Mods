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
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class MYAnimalTrapObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Animal Trap"; } } 

        public virtual Type RepresentedItemType { get { return typeof(MYAnimalTrapItem); } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Economy");                                 


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class MYAnimalTrapItem :
        WorldObjectItem<MYAnimalTrapObject> 
    {
        public override string FriendlyName { get { return "Animal Trap"; } } 
        public override string Description  { get { return  "A trap to catch Animal as looking for feed. A trap to catch Animal as looking for feed. It's too large to catch the smaller Animal."; } }

        static MYAnimalTrapItem()
        {
            
        }

        
    }


    [RequiresSkill(typeof(FishingSkill), 3)]
    public partial class MYAnimalTrapRecipe : Recipe
    {
        public MYAnimalTrapRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYAnimalTrapItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(FishingSkill), 20, FishingSkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(10, FishingSkill.MultiplicativeStrategy, typeof(FishingSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(MYAnimalTrapRecipe), Item.Get<MYAnimalTrapItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<MYAnimalTrapItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Fish Trap", typeof(MYAnimalTrapRecipe));
            CraftingComponent.AddRecipe(typeof(FisheryObject), this);
        }
    }
}