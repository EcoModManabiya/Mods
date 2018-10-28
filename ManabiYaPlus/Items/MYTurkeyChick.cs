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

    public partial class MYTurkeyChickRecipe : Recipe
    {
        public MYTurkeyChickRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYTurkeyChickItem>(1),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(SmallButcheryEfficiencySkill), 30, SmallButcheryEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYEggItem>(typeof(SmallButcheryEfficiencySkill), 5, SmallButcheryEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYTurkeyChickRecipe), Item.Get<MYTurkeyChickItem>().UILink(), 120, typeof(SmallButcherySpeedSkill));    
            this.Initialize("Turkey Chick", typeof(MYTurkeyChickRecipe));

            CraftingComponent.AddRecipe(typeof(MYTurkeyHouseObject), this);
        }
    }

    [Serialized]
    [Weight(250)]  
    [Currency]              
    public partial class MYTurkeyChickItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Turkey Chick"; } } 
        public override string Description { get { return ""; } }

    }

}