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
    using Eco.Gameplay.Pipes.LiquidComponents; 

    [RequiresSkill(typeof(PetrolRefiningSkill), 3)]   
    public partial class MYBioethanolWheatRecipe : Recipe
    {
        public MYBioethanolWheatRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYBioethanolItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WheatSeedItem>(typeof(PetrolRefiningEfficiencySkill), 100, PetrolRefiningEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<BarrelItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYBioethanolWheatRecipe), Item.Get<MYBioethanolItem>().UILink(), 5, typeof(PetrolRefiningSpeedSkill));    
            this.Initialize("Bio Ethanol From Wheat", typeof(MYBioethanolWheatRecipe));

            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }
    }
}