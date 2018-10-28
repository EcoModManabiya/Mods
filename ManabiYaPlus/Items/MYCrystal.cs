namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Gameplay.Pipes;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;

    [RequiresSkill(typeof(MortarProductionSkill), 4)] 
    public class MYCrystalRecipe : Recipe
    {
        public MYCrystalRecipe()
        {
            this.Products = new CraftingElement[]
            {

               new CraftingElement<MYCrystalItem>(5),
               new CraftingElement<SandItem>(72000f),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StoneItem>(typeof(MortarProductionEfficiencySkill), 360000, MortarProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Crystal Fragments", typeof(MYCrystalRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MasonryPitchRecipe), this.UILink(), 14400f, typeof(MortarProductionSpeedSkill));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }

    [Serialized]
    [Weight(10)]      
    [Currency]              
    public partial class MYCrystalItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Crystal Fragments"; } } 
        public override string FriendlyNamePlural { get { return "Crystal Fragments"; } } 
        public override string Description { get { return "Are these fragments of crystals?"; } }

    }
	
}