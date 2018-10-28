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

    public partial class MYTurkeyAnimalRecipe : Recipe
    {
        public MYTurkeyAnimalRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYTurkeyAnimalItem>(1),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYTurkeyChickItem>(1), 
                new CraftingElement<MYTurkeyBaitItem>(typeof(SmallButcheryEfficiencySkill), 30, SmallButcheryEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYTurkeyAnimalRecipe), Item.Get<MYTurkeyAnimalItem>().UILink(), 240, typeof(SmallButcherySpeedSkill));    
            this.Initialize("Livestock Turkey", typeof(MYTurkeyAnimalRecipe));

            CraftingComponent.AddRecipe(typeof(MYTurkeyHouseObject), this);
        }
    }

    [Serialized]
    [Weight(1000)]  
    [Currency]              
    public partial class MYTurkeyAnimalItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Livestock Turkey"; } } 
        public override string Description { get { return ""; } }

    }

}