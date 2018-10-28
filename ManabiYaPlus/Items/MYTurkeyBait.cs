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

    [RequiresSkill(typeof(SeedProductionSkill), 2)]    
    public partial class MYTurkeyBaitFromWheatRecipe : Recipe
    {
        public MYTurkeyBaitFromWheatRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYTurkeyBaitItem>(1),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WheatItem>(typeof(SeedProductionEfficiencySkill), 30, SeedProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            SkillModifiedValue value = new SkillModifiedValue(5, SeedProductionSpeedSkill.MultiplicativeStrategy, typeof(SeedProductionSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(MYTurkeyBaitFromWheatRecipe), Item.Get<MYTurkeyBaitItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<MYTurkeyBaitItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Turkey Bait", typeof(MYTurkeyBaitFromWheatRecipe));

            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }

    [RequiresSkill(typeof(SeedProductionSkill), 2)]    
    public partial class MYTurkeyBaitFromHuckleberriesRecipe : Recipe
    {
        public MYTurkeyBaitFromHuckleberriesRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYTurkeyBaitItem>(1),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HuckleberriesItem>(typeof(SeedProductionEfficiencySkill), 30, SeedProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            SkillModifiedValue value = new SkillModifiedValue(5, SeedProductionSpeedSkill.MultiplicativeStrategy, typeof(SeedProductionSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(MYTurkeyBaitFromHuckleberriesRecipe), Item.Get<MYTurkeyBaitItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<MYTurkeyBaitItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Turkey Bait", typeof(MYTurkeyBaitFromHuckleberriesRecipe));

            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }

    [RequiresSkill(typeof(SeedProductionSkill), 2)]    
    public partial class MYTurkeyBaitFromCornRecipe : Recipe
    {
        public MYTurkeyBaitFromCornRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYTurkeyBaitItem>(1),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CornItem>(typeof(SeedProductionEfficiencySkill), 30, SeedProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            SkillModifiedValue value = new SkillModifiedValue(5, SeedProductionSpeedSkill.MultiplicativeStrategy, typeof(SeedProductionSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(MYTurkeyBaitFromCornRecipe), Item.Get<MYTurkeyBaitItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<MYTurkeyBaitItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Turkey Bait", typeof(MYTurkeyBaitFromCornRecipe));

            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }

    [Serialized]
    [Weight(200)]  
    [Currency]              
    public partial class MYTurkeyBaitItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Turkey Bait"; } } 
        public override string Description { get { return ""; } }

    }

}