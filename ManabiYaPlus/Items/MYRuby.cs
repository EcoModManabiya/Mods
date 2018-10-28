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
    public class MYRubyFromEckoRecipe : Recipe
    {
        public MYRubyFromEckoRecipe()
        {
            this.Products = new CraftingElement[]
            {

               new CraftingElement<MYRubyItem>(2),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<EckoStatueItem>(1), 
            };
            this.Initialize("Ecko's Ruby", typeof(MYRubyFromEckoRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYRubyFromEckoRecipe), this.UILink(), 0.5f, typeof(MortarProductionSpeedSkill));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }

    [RequiresSkill(typeof(MortarProductionSkill), 4)] 
    public class MYRubyFromMeteoRecipe : Recipe
    {
        public MYRubyFromMeteoRecipe()
        {
            this.Products = new CraftingElement[]
            {

               new CraftingElement<MYRubyItem>(2),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MeteorShardItem>(1), 
            };
            this.Initialize("Ruby　From　Meteo", typeof(MYRubyFromMeteoRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYRubyFromMeteoRecipe), this.UILink(), 1.5f, typeof(MortarProductionSpeedSkill));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
	
    [RequiresSkill(typeof(MYReusingSkill), 4)] 
    public class MYArtificialRubyRecipe : Recipe
    {
        public MYArtificialRubyRecipe()
        {
            this.Products = new CraftingElement[]
            {

               new CraftingElement<MYRubyItem>(1),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYCrystalItem>(5), 
            };
            this.Initialize("Artificial Ruby", typeof(MYArtificialRubyRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYArtificialRubyRecipe), this.UILink(), 1.5f, typeof(MYReusingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
        }
    }

    [Serialized]
    [Weight(50)]      
    [Currency]              
    public partial class MYRubyItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Ruby"; } } 
        public override string FriendlyNamePlural { get { return "Ruby"; } } 
        public override string Description { get { return "How can I obtain rubies?"; } }

    }
	
}