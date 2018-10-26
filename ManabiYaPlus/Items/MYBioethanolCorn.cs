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
    public partial class MYBioethanolCornRecipe : Recipe
    {
        public MYBioethanolCornRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYBioethanolItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CornSeedItem>(typeof(PetrolRefiningEfficiencySkill), 100, PetrolRefiningEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<BarrelItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYBioethanolCornRecipe), Item.Get<MYBioethanolItem>().UILink(), 5, typeof(PetrolRefiningSpeedSkill));    
            this.Initialize("Bio Ethanol From Corn", typeof(MYBioethanolCornRecipe));

            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }
    }
}